using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class ConsumeAllTargetHealthManaEffect : ConsumeColorManaEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    mana = target.Unit.HealthColor;
                    base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi);
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
}
