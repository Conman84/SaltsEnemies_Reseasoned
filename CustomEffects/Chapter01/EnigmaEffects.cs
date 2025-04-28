using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned.CustomEffects
{
    public class IsFrailEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int length = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    if (targetSlotInfo.Unit.ContainsStatusEffect("Frail_ID"))
                    {
                        exitAmount++;
                    }
                }
                length++;
            }
            return exitAmount >= length;
        }
    }
}
