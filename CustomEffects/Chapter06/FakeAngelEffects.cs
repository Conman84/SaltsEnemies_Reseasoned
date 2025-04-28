using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class GenerateTargetHealthManaEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    try
                    {
                        target.Unit.GenerateHealthMana(entryVariable);
                        exitAmount += entryVariable;
                    }
                    catch
                    {
                        UnityEngine.Debug.LogError("generate target health mana fail, prob target unit null");
                    }
                }
            }
            return exitAmount > 0;
        }
    }
}
