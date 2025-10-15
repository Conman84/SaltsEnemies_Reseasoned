using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class SwapDirectionCondition : EffectorConditionSO
    {
        public bool IsRight;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference value)
            {
                if (IsRight) return value.value < effector.SlotID;
                else return value.value > effector.SlotID;
            }
            return false;
        }

        public static SwapDirectionCondition Create(bool checkRight)
        {
            SwapDirectionCondition ret = ScriptableObject.CreateInstance<SwapDirectionCondition>();
            ret.IsRight = checkRight;
            return ret;
        }
    }
}
