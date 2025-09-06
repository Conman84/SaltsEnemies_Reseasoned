using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class SystemicCondition : EffectorConditionSO
    {
        public int Max;
        public string Counter;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            bool ret = false;

            int count = (effector as IUnit).SimpleGetStoredValue(Counter);
            count++;

            if (count >= Max)
            {
                count = 0;
                ret = true;
            }

            (effector as IUnit).SimpleSetStoredValue(Counter, count);

            return ret;
        }
        public static SystemicCondition Create(int amount, string name)
        {
            SystemicCondition ret = ScriptableObject.CreateInstance<SystemicCondition>();
            ret.Max = amount;
            ret.Counter = name;
            return ret;
        }
    }
}
