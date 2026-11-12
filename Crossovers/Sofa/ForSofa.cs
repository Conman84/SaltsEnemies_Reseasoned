using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned.Crossovers.Sofa
{
    public class DamageLosingMissingHealthEffect : DamageEffect // just inherit damage effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int amount = Math.Max(0, entryVariable - (caster.MaximumHealth - caster.CurrentHealth));

            return base.PerformEffect(stats, caster, targets, areTargetSlots, amount, out exitAmount);
        }
    }
}
