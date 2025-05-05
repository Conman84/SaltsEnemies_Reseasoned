using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class CritDamageEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && UnityEngine.Random.Range(0, 100) < 5)
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(target.Unit.ID, target.Unit.IsUnitCharacter, "Critical Hit!"));
                    base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable * 3, out int exi);
                    exitAmount += exi;
                }
                else
                {
                    base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi);
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TriggerOnlyOnceEffectCondition : EffectConditionSO
    {
        public static string Value => "TriggerOnlyOnceEffectConditionSO";
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.SimpleGetStoredValue(Value) == 0)
            {
                caster.SimpleSetStoredValue(Value, 1);
                return true;
            }
            return false;
        }
    }
}
