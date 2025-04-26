using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class HealHalfHealthEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public bool entryAsPercentage = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && (!_onlyIfHasHealthOver0 || targetSlotInfo.Unit.CurrentHealth > 0))
                {
                    int num = 30;
                    if (entryAsPercentage)
                    {
                        num = targetSlotInfo.Unit.CalculatePercentualAmount(num);
                    }

                    exitAmount += targetSlotInfo.Unit.Heal(num, null, true);
                }
            }

            return exitAmount > 0;
        }
    }
}
