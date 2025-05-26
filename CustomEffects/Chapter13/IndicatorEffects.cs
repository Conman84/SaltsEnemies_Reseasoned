using BrutalAPI;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class LinkedDamageEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.ContainsStatusEffect(StatusField_GameIDs.Linked_ID.ToString())) caster.Damage(entryVariable, null, DeathType_GameIDs.Linked.ToString(), -1, false, false, true, CombatType_GameIDs.Dmg_Linked.ToString());
            CombatManager.Instance.AddSubAction(new PerformLinkedEffectAction(caster, new IntegerReference(entryVariable), true, StatusField.Linked.StatusID, LoadedDBsHandler.CombatDB.TryGetSoundEventName(CombatType_GameIDs.Dmg_Linked.ToString())));
            return true;
        }
    }
    public class EmptyEnemySpaceNoWitheringEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.ContainsPassiveAbility(PassiveType_GameIDs.Withering.ToString())) return false;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots) if (!slot.HasUnit) return true;
            return false;
        }
    }
    public class SwapToRandomZoneFoolEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int num = UnityEngine.Random.Range(0, 5);
                    if (num == targetSlotInfo.SlotID)
                    {
                        if (num <= 0) num++;
                        else if (num >= 4) num--;
                        else if (UnityEngine.Random.Range(0f, 1f) < 0.5f) num++;
                        else num--;
                    }
                    stats.combatSlots.SwapCharacters(targetSlotInfo.SlotID, num, isMandatory: true);
                }
            }
            return exitAmount > 0;
        }
    }
    public class SpasmEffect : AddTurnTargetToTimelineEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<EnemyCombat> enemies = new List<EnemyCombat>();
            List<int> abilities = new List<int>();

            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                int num = 1;
                if (UnityEngine.Random.Range(0f, 1f) < 0.25f) num++;

                for (int i = 0; i < num; i++)
                {
                    enemies.Add(enemy);
                    abilities.Add(enemy.GetSingleAbilitySlotUsage(-1));
                }
            }

            stats.timeline.AddExtraEnemyTurns(enemies, abilities);

            exitAmount = abilities.Count;

            return exitAmount > 0;
        }
    }
}
