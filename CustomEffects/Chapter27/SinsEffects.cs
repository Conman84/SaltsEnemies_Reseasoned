using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class DamageCompareHealthToCasterEffect : DamageEffect
    {
        public bool More;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (More && target.Unit.CurrentHealth > caster.CurrentHealth) ret.Add(target);
                    else if (!More && target.Unit.CurrentHealth < caster.CurrentHealth) ret.Add(target);
                }
            }

            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class FullyHealSinsEffect : FullHealEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.UnitTypes != null && target.Unit.UnitTypes.Contains("Sin")) ret.Add(target);
            }

            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class TempRankDownEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            for (int k = 0; k < entryVariable; k++)
            {
                foreach (TargetSlotInfo target in targets)
                {
                    if (target.HasUnit && target.Unit is CharacterCombat chara)
                    {
                        if (!chara.Character.HasRankedData) continue;
                        if (chara.Rank <= 0) continue;

                        CharacterRankedData prev = chara.Character.rankedData[chara.Rank];

                        chara._rank--;

                        CharacterRankedData rank = chara.Character.rankedData[chara.Rank];
                        int difference = rank.health - prev.health;

                        foreach (CombatAbility ability in chara._combatAbilities)
                        {
                            for (int i = 0; i < prev.rankAbilities.Length; i++)
                            {
                                if (ability.ability == prev.rankAbilities[i].ability)
                                {
                                    ability.ability = rank.rankAbilities[i].ability;
                                    ability.cost = new ManaColorSO[rank.rankAbilities[i].cost.Length];
                                    for (int g = 0; g < ability.cost.Length; g++)
                                    {
                                        ability.cost[g] = rank.rankAbilities[i].cost[g];
                                    }
                                    break;
                                }
                            }
                        }

                        CombatManager.Instance.AddUIAction(new CharacterUpdateAllAttacksUIAction(chara.ID, chara.CombatAbilities.ToArray()));

                        CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(chara.ID, chara.IsUnitCharacter, "Leveled Down", chara.Character.characterSprite));

                        if (difference != 0) chara.MaximizeHealth(chara.MaximumHealth + difference);

                        chara.SimpleSetStoredValue("Aprils_Level", chara.SimpleGetStoredValue("Aprils_Level") - 1);
                        exitAmount++;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class SpawnEnemyCopyBasedOffExitEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [CombatIDsEnumRef]
        public string _spawnTypeID = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_spawnTypeID == "") _spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            if (caster is EnemyCombat en) enemy = en.Enemy;
            else return false;
            if (PreviousExitValue <= 0) return false;
            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnTypeID, Math.Max(1, PreviousExitValue)));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class SpawnEnemyCopyHealthByEntryEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemm)
            {
                EnemySO enemy = enemm.Enemy;
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnType, entryVariable));
            }
            else return false;
            exitAmount = entryVariable;
            return true;
        }
    }
    public class ReviveSinWithSelfHealthEffect : EffectSO
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
            if (ContainsPassiveAbility(enemy.Enemy, Passives.Inanimate.m_PassiveID)) return false;
            if (enemy.UnitTypes != null && enemy.UnitTypes.Contains("Sin")) return true;
            return false;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int candidatesLength = 0;
            exitAmount = 0;
            if (caster.CurrentHealth <= 0) return false;
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
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy) && CanLive(targetEnemy) && IsntBronzo(targetEnemy))
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
                        if (stats.AddNewEnemy(targetEnemy.Enemy, num, false, _spawnType, caster.CurrentHealth))
                        {
                            targetEnemy.HasFled = true;
                            exitAmount++;
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class SoloSinEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int sins = 0;
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (enemy.UnitTypes != null && enemy.UnitTypes.Contains("Sin")) sins++;
            }
            return sins <= 1;
        }
    }
    public class ReturnExitZeroToEntryEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = UnityEngine.Random.Range(0, entryVariable + 1);
            return true;
        }
    }
}
