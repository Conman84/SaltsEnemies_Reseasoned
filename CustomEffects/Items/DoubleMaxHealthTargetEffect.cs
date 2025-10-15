using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class DoubleMaxHealthTargetEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach  (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int orig = target.Unit.MaximumHealth;

                    target.Unit.MaximizeHealth(target.Unit.MaximumHealth * 2);

                    int final = target.Unit.MaximumHealth;

                    exitAmount += final - orig;
                }
            }
            return exitAmount > 0;
        }
    }
}
