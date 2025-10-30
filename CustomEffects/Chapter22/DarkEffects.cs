using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class ApplyFrailIfNoFrailEffect : ApplyFrailEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && !target.Unit.ContainsStatusEffect(StatusField_GameIDs.Frail_ID.ToString()))
                {
                    base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi);
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
}
