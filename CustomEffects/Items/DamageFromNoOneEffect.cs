using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class DamageFromNoOneEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    exitAmount += target.Unit.Damage(entryVariable, null, "Basic", areTargetSlots ? (target.SlotID - target.Unit.SlotID) : (-1)).damageAmount;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TriggerOnceEffectorCondition : EffectorConditionSO
    {
        public string Value;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if ((effector as IUnit).SimpleGetStoredValue(Value) <= 0)
            {
                (effector as IUnit).SimpleSetStoredValue(Value, 1);
                return true;
            }
            return false;
        }
        public static TriggerOnceEffectorCondition Create(string value)
        {
            TriggerOnceEffectorCondition ret = ScriptableObject.CreateInstance<TriggerOnceEffectorCondition>();
            ret.Value = value;
            return ret;
        }
    }
    public class DamageToStatusCondition : EffectorConditionSO
    {
        public float Mod;
        public string Status;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                if (value.damagedUnit.ContainsStatusEffect(Status))
                {
                    value.AddModifier(new FloatModMin1(Mod, false));
                    (effector as IUnit).ShowItem();
                    return true;
                }
            }
            return false;
        }
        public static DamageToStatusCondition Create(float mod, string stat)
        {
            DamageToStatusCondition ret = ScriptableObject.CreateInstance<DamageToStatusCondition>();
            ret.Mod = mod;
            ret.Status = stat;
            return ret;
        }
    }
}
