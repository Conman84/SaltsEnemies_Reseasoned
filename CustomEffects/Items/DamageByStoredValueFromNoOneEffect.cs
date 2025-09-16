using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class DamageByStoredValueFromNoOneEffect : EffectSO
    {
        public string Value;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int amount = caster.SimpleGetStoredValue(Value);

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    exitAmount += target.Unit.Damage(amount * entryVariable, null, "Basic", -1).damageAmount;
                }
            }

            return exitAmount > 0;
        }

        public static DamageByStoredValueFromNoOneEffect Create(string value)
        {
            DamageByStoredValueFromNoOneEffect ret = ScriptableObject.CreateInstance<DamageByStoredValueFromNoOneEffect>();
            ret.Value = value;
            return ret;
        }
    }
    public class StoredValueCondition : EffectorConditionSO
    {
        public string Value;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return (effector as IUnit).SimpleGetStoredValue(Value) > 0):
        }

        public static StoredValueCondition Create(string value)
        {
            StoredValueCondition ret = ScriptableObject.CreateInstance<StoredValueCondition>();
            ret.Value = value;
            return ret;
        }
    }
}
