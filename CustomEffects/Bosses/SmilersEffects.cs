using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    //StatusEffectCheckerEffect

    public class AddTurnIfStatusEffect : AddTurnTargetToTimelineEffect
    {
        public string Status;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsStatusEffect(Status)) ret.Add(target);
            }

            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
