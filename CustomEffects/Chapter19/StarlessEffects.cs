using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class RightMostCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.SlotID == 5 - (effector as IUnit).Size;
        }
    }
    public class LeftMostCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.SlotID == 0;
        }
    }
    public class HasUnitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) exitAmount++;
            return exitAmount > 0;
        }
    }
    public class MoveByLastExitEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = PreviousExitValue;
            for (int i = 0; i < exitAmount; i++) base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            return exitAmount > 0;
        }
    }
    public class KillIfBelowPercentEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    float calc = (float)target.Unit.CurrentHealth / target.Unit.MaximumHealth;
                    if (calc * 100 < entryVariable)
                    {
                        if (target.Unit.DirectDeath(caster)) exitAmount++;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class FixCasterTimelineIntentsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter || !caster.IsAlive) return false;
            if (stats.timeline.IsConfused) return false;
            for (int i = 0; i < stats.combatUI._TimelineHandler.TimelineSlotInfo.Count; i++)
            {
                TimelineInfo timeline = stats.combatUI._TimelineHandler.TimelineSlotInfo[i];
                if (timeline.isSecret) continue;
                if (timeline.enemyID == caster.ID)
                {
                    timeline.timelineIcon = (caster as EnemyCombat).Enemy.enemySprite;
                    foreach (TimelineSlotGroup slotgroup in stats.combatUI._timeline._slotsInUse)
                    {
                        if (slotgroup.slot.TimelineSlotID == i)
                        {
                            Sprite[] intents = null;
                            Color[] spriteColors = null;
                            bool cansee = timeline.timelineIcon != null && !timeline.timelineIcon.Equals(null);
                            if (cansee) intents = stats.combatUI._timeline.IntentHandler.GenerateSpritesFromAbility(timeline.ability, casterIsCharacter: false, out spriteColors);
                            slotgroup.SetInformation(slotgroup.slot.TimelineSlotID, cansee ? timeline.timelineIcon : stats.combatUI._timeline._blindTimelineIcon, true, intents, spriteColors);
                        }
                    }
                }
            }
            return true;
        }
    }
}
