using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class WoodChipsEffect : EffectSO
    {
        public EnemySO[] enemies = new EnemySO[]
        {
            LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS"),
            LoadedAssetsHandler.GetEnemy("HeavensGateBlue_BOSS"),
            LoadedAssetsHandler.GetEnemy("HeavensGateYellow_BOSS"),
            LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS")
        };

        public EnemySO enemy
        {
            get
            {
                return enemies[UnityEngine.Random.Range(0, enemies.Length)];
            }
        }

        public ManaColorSO[] pigments = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };

        public ManaColorSO pigment
        {
            get
            {
                return pigments[UnityEngine.Random.Range(0, pigments.Length)];
            }
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.CurrentHealth <= 5)
                {
                    EnemySO thisGuy = enemy;
                    CombatManager.Instance.AddSubAction(new WoodChipsAction(thisGuy, -1, false, trySpawnAnyways: false, CombatType_GameIDs.Spawn_Basic.ToString(), new AddManaToManaBarAction(thisGuy.healthColor, 1, caster.IsUnitCharacter, caster.ID)));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class WoodChipsAction : CombatAction
    {
        public int _preferredSlot;

        public EnemySO _enemy;

        public bool _givesExperience;

        public bool _trySpawnAnyways;

        public string _spawnType;

        public AddManaToManaBarAction pigment;

        public WoodChipsAction(EnemySO enemy, int preferredSlot, bool givesExperience, bool trySpawnAnyways, string spawnType, AddManaToManaBarAction Pigment)
        {
            _preferredSlot = preferredSlot;
            _givesExperience = givesExperience;
            _enemy = enemy;
            _trySpawnAnyways = trySpawnAnyways;
            _spawnType = spawnType;
            this.pigment = Pigment;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            int num;
            if (_preferredSlot >= 0)
            {
                num = stats.combatSlots.GetEnemyFitSlot(_preferredSlot, _enemy.size);
                if (num == -1 && _trySpawnAnyways)
                {
                    num = stats.GetRandomEnemySlot(_enemy.size);
                }
            }
            else
            {
                num = stats.GetRandomEnemySlot(_enemy.size);
            }

            if (num != -1)
            {
                stats.AddNewEnemy(_enemy, num, _givesExperience, _spawnType, _enemy.health);
            }
            pigment.Execute(stats);
            yield return null;
        }
    }
    public class PainStarEffect : EffectSO
    {
        [SerializeField]
        public bool _fullyHeal = true;

        [SerializeField]
        public bool _maintainTimelineAbilities;

        [SerializeField]
        public bool _maintainMaxHealth = false;

        [SerializeField]
        public bool _currentToMaxHealth;

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

        public bool Check(EnemyCombat enemy)
        {
            if (IsntSuperboss(enemy) && !enemy.Enemy._enemyName.Contains("Bronzo") && enemy.Enemy != LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS") && enemy.Enemy._enemyName != "Sepulchre" && (!(enemy.Enemy._enemyName.Contains("Fountain") && enemy.Enemy._enemyName.Contains("Youth"))))
            {
                return true;
            }
            return false;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter)
            {
                return false;
            }

            EnemySO _enemyTransformation = (caster as EnemyCombat).Enemy;
            List<EnemySO> enemies = new List<EnemySO>();
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.Enemy != (caster as EnemyCombat).Enemy && enemy.Size == 1 && !enemies.Contains(enemy.Enemy) && Check(enemy)) enemies.Add(enemy.Enemy);
            }
            if (enemies.Count > 0) _enemyTransformation = enemies[UnityEngine.Random.Range(0, enemies.Count)];

            return stats.TryTransformEnemy(caster.ID, _enemyTransformation, _fullyHeal, _maintainTimelineAbilities, _maintainMaxHealth, _currentToMaxHealth);
        }
    }
    public class RandomizeCostsEffect : EffectSO
    {
        public static ManaColorSO[] RandomArray(int length)
        {
            List<ManaColorSO> list = new List<ManaColorSO>();
            for (int i = 0; i < length; i++)
            {
                list.Add(RandomPig());
            }
            return list.ToArray();
        }
        public static ManaColorSO RandomPig()
        {
            int choose = UnityEngine.Random.Range(0, 100);
            if (choose < 30) return Pigments.Red;
            else if (choose < 55) return Pigments.Blue;
            else if (choose < 80) return Pigments.Yellow;
            else return Pigments.Purple;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (!targetSlotInfo.HasUnit || !(targetSlotInfo.Unit is CharacterCombat characterCombat))
                {
                    continue;
                }
                foreach (CombatAbility combatAbility in characterCombat.CombatAbilities)
                {
                    int num = combatAbility.cost.Length;
                    combatAbility.cost = RandomArray(num);
                    exitAmount += num;
                }
                foreach (CharacterCombatUIInfo value in stats.combatUI._charactersInCombat.Values)
                {
                    if (value.SlotID != targetSlotInfo.Unit.SlotID)
                    {
                        continue;
                    }
                    CharacterCombatUIInfo characterCombatUIInfo = value;
                    List<CombatAbility> combatAbilities = (targetSlotInfo.Unit as CharacterCombat).CombatAbilities;
                    int num2 = 0;
                    CombatAbility[] array = new CombatAbility[combatAbilities.Count];
                    foreach (CombatAbility item in combatAbilities)
                    {
                        array[num2] = item;
                        num2++;
                    }
                    characterCombatUIInfo.UpdateAttacks(array);
                    break;
                }
                CombatManager instance = CombatManager.Instance;
                int iD = (targetSlotInfo.Unit as CharacterCombat).ID;
                List<CombatAbility> combatAbilities2 = (targetSlotInfo.Unit as CharacterCombat).CombatAbilities;
                int num3 = 0;
                CombatAbility[] array2 = new CombatAbility[combatAbilities2.Count];
                foreach (CombatAbility item2 in combatAbilities2)
                {
                    array2[num3] = item2;
                    num3++;
                }
                instance.AddUIAction(new CharacterUpdateAllAttacksUIAction(iD, array2));
            }
            return exitAmount > 0;
        }
    }
}
