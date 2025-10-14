using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{

    public class DamageByTurnsEffect : DamageEffect
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, stats.TurnsPassed, out exitAmount);
        }
    }
}
