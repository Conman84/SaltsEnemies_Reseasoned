using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class DamageByCasterHealthEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, caster.CurrentHealth * entryVariable, out exitAmount);
        }
    }
}
