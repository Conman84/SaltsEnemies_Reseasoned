using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class IncreaseDamageMultiplyCondition : EffectorConditionSO
    {
        public float Mod;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException hitting)
            {
                (effector as IUnit).ShowItem();
                hitting.AddModifier(new FloatModMin1(Mod, false));
            }
            return true;
        }
        public static IncreaseDamageMultiplyCondition Create(float mod)
        {
            IncreaseDamageMultiplyCondition ret = ScriptableObject.CreateInstance<IncreaseDamageMultiplyCondition>();
            ret.Mod = mod;
            return ret;
        }
    }
}
