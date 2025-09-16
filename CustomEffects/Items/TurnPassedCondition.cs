using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{

    public class TurnPassedCondition : EffectorConditionSO
    {
        public int turn;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return CombatManager.Instance._stats.TurnsPassed == turn - 1;
        }
        public static TurnPassedCondition Create(int turns)
        {
            TurnPassedCondition ret = ScriptableObject.CreateInstance<TurnPassedCondition>();
            ret.turn = turns;
            return ret;
        }
    }
}
