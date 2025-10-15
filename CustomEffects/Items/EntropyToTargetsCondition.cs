using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class EntropyToTargetsCondition : EffectorConditionSO
    {
        public float percent = 1f;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is AdvancedDamageInfo info && info.Target != null)
            {
                (effector as IUnit).ShowItem();
                info.Target.ApplyStatusEffect(Entropy.Object, (int)Math.Ceiling(info.value * percent));
            }
            return false;
        }
        public static EntropyToTargetsCondition Create(float amount = 1f)
        {
            EntropyToTargetsCondition ret = ScriptableObject.CreateInstance<EntropyToTargetsCondition>();
            ret.percent = amount;
            return ret;
        }
    }
}
