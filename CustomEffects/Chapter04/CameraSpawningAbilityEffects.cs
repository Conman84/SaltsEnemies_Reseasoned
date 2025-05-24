using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class Test
    {
        CopyAndSpawnRandomCharacterAnywhereEffect random;
        CopyAndSpawnCustomCharacterAnywhereEffect custom;
        CopyCasterAndSpawnCharacterAnywhereEffect caster;
        ResurrectEffect revive;//done
    }
    public class CameraSpawningHandler
    {
        public static List<EnemyAbilityInfo> GetAbilities(CharacterSO chara, int level, int[] abils)
        {
            if (chara == null || chara.Equals(null)) return [];
            CharacterRankedData rank = chara.rankedData[chara.ClampRank(level)];

            //chara abils
            List<CharacterAbility> yummy = new List<CharacterAbility>();
            if (chara.usesBasicAbility && chara.basicCharAbility != null) yummy.Add(chara.basicCharAbility);
            if (chara.usesAllAbilities)
            {
                foreach (CharacterAbility abi in rank.rankAbilities) yummy.Add(abi);
            }
            else
            {
                foreach (int num in abils) yummy.Add(rank.rankAbilities[num]);
            }

            //convert to enemy abiliies
            List<EnemyAbilityInfo> ret = new List<EnemyAbilityInfo>();
            foreach (CharacterAbility ability in yummy)
            {
                EnemyAbilityInfo add = new EnemyAbilityInfo()
                {
                    ability = ability.ability,
                    rarity = Rarity.GetCustomRarity("rarity5")
                };
            }

            return ret;
        }
    }

    public class CameraCopyEffectAction : EffectAction
    {
        public CameraCopyEffectAction(EffectInfo[] effects, IUnit caster, int startResult = 0) : base(new EffectInfo[effects.Length], caster, startResult)
        {
            //set effects
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            try
            {
                return base.Execute(stats);
            }
            catch (Exception ex)
            {
                Debug.LogWarning("Something has gone horribly wrong but its trying it's best!");
                Debug.LogWarning(ex.ToString());
                return new ShowAttackInformationUIAction(_caster.ID, _caster.IsUnitCharacter, "Something has gone horribly wrong but it's trying it's best!").Execute(stats);
            }
        }
    }


    //effects
    public class Camera_CopyAndSpawnRandomCharacterAnywhereEffect : SpawnEnemyAnywhereEffect
    {
        [Header("Rank Data")]
        public int _rank;

        public NameAdditionLocID _nameAddition;

        public bool _permanentSpawn;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CharacterDataBase characterDB = LoadedDBsHandler.CharacterDB;
            if (characterDB == null || characterDB.Equals(null))
            {
                return false;
            }

            List<CharacterSO> randomCharacters = characterDB.GetRandomCharacters(entryVariable);
            string nameAdditionData = LocUtils.GameLoc.GetNameAdditionData(_nameAddition);
            foreach (CharacterSO item in randomCharacters)
            {
                int maxHealth = item.GetMaxHealth(_rank);
                int[] usedAbilities = item.GenerateAbilities();


                EnemySO toCopy = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemy("MechanicalLens_EN"));
                toCopy.abilities = CameraSpawningHandler.GetAbilities(item, _rank, usedAbilities);
                string Name = "Image of ";
                if (nameAdditionData != "")
                {
                    Name += string.Format(nameAdditionData, item.GetName());
                }
                else
                {
                    Name += item.GetName();
                }
                toCopy._enemyName = Name;
                toCopy.passiveAbilities = item.passiveAbilities;
                toCopy.health = maxHealth;
                toCopy.healthColor = item.healthColor;

                base.enemy = toCopy;

                if (base.PerformEffect(stats, caster, targets, areTargetSlots, 1, out int ex)) exitAmount++;
                //CombatManager.Instance.AddSubAction(new SpawnCharacterAction(item, -1, trySpawnAnyways: false, nameAdditionData, _permanentSpawn, _rank, usedAbilities, maxHealth));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class Camera_CopyAndSpawnCustomCharacterAnywhereEffect : SpawnEnemyAnywhereEffect
    {
        [Header("Rank Data")]
        [CharacterRef]
        public string _characterCopy = "";

        public int _rank;

        public NameAdditionLocID _nameAddition;

        public bool _permanentSpawn;

        public bool _usePreviousAsHealth;

        public WearableStaticModifierSetterSO[] _extraModifiers;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CharacterSO character = LoadedAssetsHandler.GetCharacter(_characterCopy);
            if (character == null || character.Equals(null))
            {
                return false;
            }

            int currentHealth = (_usePreviousAsHealth ? Mathf.Max(1, base.PreviousExitValue) : character.GetMaxHealth(_rank));
            int[] usedAbilities = character.GenerateAbilities();
            WearableStaticModifiers modifiers = new WearableStaticModifiers();
            WearableStaticModifierSetterSO[] extraModifiers = _extraModifiers;
            for (int i = 0; i < extraModifiers.Length; i++)
            {
                extraModifiers[i].OnAttachedToCharacter(modifiers, character, _rank);
            }

            string nameAdditionData = LocUtils.GameLoc.GetNameAdditionData(_nameAddition);

            EnemySO toCopy = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemy("MechanicalLens_EN"));
            toCopy.abilities = CameraSpawningHandler.GetAbilities(character, _rank, usedAbilities);
            string Name = "Image of ";
            if (nameAdditionData != "")
            {
                Name += string.Format(nameAdditionData, character.GetName());
            }
            else
            {
                Name += character.GetName();
            }
            toCopy._enemyName = Name;
            toCopy.passiveAbilities = character.passiveAbilities;
            toCopy.health = currentHealth;
            toCopy.healthColor = character.healthColor;

            base.enemy = toCopy;

            //for (int j = 0; j < entryVariable; j++)
            //{
            //CombatManager.Instance.AddSubAction(new SpawnCharacterAction(character, -1, trySpawnAnyways: false, nameAdditionData, _permanentSpawn, _rank, usedAbilities, currentHealth, modifiers));
            //}
            base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);

            return true;
        }
    }
    //reviver
    public class Camera_ResurrectEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public bool IsntSuperboss(EnemyCombat enemy)
        {
            if (enemy.Enemy._enemyName == "Strange Box")
                return false;
            if (enemy.Enemy._enemyName == "544517")
                return false;
            if (enemy.Enemy._enemyName == "544516")
                return false;
            if (enemy.Enemy._enemyName == "544515")
                return false;
            if (enemy.Enemy._enemyName == "544514")
                return false;
            if (enemy.Enemy._enemyName == "544513")
                return false;
            return true;
        }
        public bool IsntBronzo(EnemyCombat enemy)
        {
            if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo1_EN"))
                return false;
            if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo2_EN"))
                return false;
            if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo3_EN"))
                return false;
            if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo4_EN"))
                return false;
            if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo5_EN"))
                return false;
            return true;
        }
        public static bool ContainsPassiveAbility(EnemySO enemy, string passive)
        {
            foreach (BasePassiveAbilitySO passi in enemy.passiveAbilities)
            {
                if (passi.m_PassiveID == passive) return true;
            }
            return false;
        }
        public bool CanLive(EnemyCombat enemy)
        {
            if (ContainsPassiveAbility(enemy.Enemy, PassiveType_GameIDs.Dying.ToString())) return false;
            if (ContainsPassiveAbility(enemy.Enemy, PassiveType_GameIDs.Inanimate.ToString())) return false;
            return true;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit) continue;

                int candidatesLength = 0;
                for (int index = 0; index < stats.Enemies.Count; index++)
                {
                    EnemyCombat targetEnemy = stats.Enemies[index];
                    if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy) && IsntBronzo(targetEnemy))
                    {
                        candidatesLength++;
                    }
                }
                if (candidatesLength <= 0)
                {
                    return false;
                }
                int[] candidates = new int[candidatesLength];
                int addAt = 0;
                for (int index = 0; index < stats.Enemies.Count; index++)
                {
                    EnemyCombat targetEnemy = stats.Enemies[index];
                    if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
                    {
                        if (addAt < candidates.Length)
                        {
                            candidates[addAt] = index;
                            addAt++;
                        }
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    int picking = UnityEngine.Random.Range(0, candidates.Length);
                    int choosing = candidates[picking];
                    EnemyCombat targetEnemy = stats.Enemies[choosing];
                    if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy))
                    {
                        int num = stats.GetRandomEnemySlot(targetEnemy.Enemy.size);
                        if (num != -1)
                        {
                            float newMax = entryVariable;
                            if (stats.AddNewEnemy(targetEnemy.Enemy, num, false, _spawnType, Math.Max(1, (int)Math.Floor(newMax))))
                            {
                                targetEnemy.HasFled = true;
                                exitAmount++;
                            }
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
