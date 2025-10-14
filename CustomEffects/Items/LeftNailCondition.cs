using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class LeftNailCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new PercentageValueModifier(true, 30, true));
                return false;
            }
            return true;
        }
    }
    public class CasterGainActionEffect : AddTurnCasterToTimelineEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (!caster.IsUnitCharacter) return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            exitAmount = 0;
            if (!caster.RefreshAbilityUse())
            {
                caster.SimpleSetStoredValue(Inspiration.Multiattack, caster.SimpleGetStoredValue(Inspiration.Multiattack) + 1);
            }
            return true;
        }
    }
}
