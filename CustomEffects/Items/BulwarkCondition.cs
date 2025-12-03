using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class BulwarkCondition : EffectorConditionSO
    {
        public int MaxInclusive;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException change)
            {
                change.AddModifier(new BulwarkModifier(MaxInclusive, effector as IUnit));
            }
            return true;
        }
        public static BulwarkCondition Create (int maxInc)
        {
            BulwarkCondition ret = ScriptableObject.CreateInstance<BulwarkCondition>();
            ret.MaxInclusive = maxInc;
            return ret;
        }
    }

    public class BulwarkModifier : IntValueModifier
    {
        public int MaxInclusive;
        public IUnit Caster;
        public BulwarkModifier(int maxInclusive, IUnit itemHolder = null) : base(55)
        {
            MaxInclusive = maxInclusive;
            Caster = itemHolder;
        }
        public override int Modify(int value)
        {
            if (value <= MaxInclusive && value > 0)
            {
                if (Caster != null) Caster.ShowItem();
                return 0;
            }
            return value;
        }
    }

    public class BooleanValueInSlipSetter : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference reference)
            {
                reference.value = (effector as IUnit).ContainsFieldEffect("Slip_ID");
                if (reference.value) (effector as IUnit).ShowItem();
            }
            return true;
        }
    }
}
