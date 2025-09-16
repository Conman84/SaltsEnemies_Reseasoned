using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class EvenTurnCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return CombatManager.Instance._stats.TurnsPassed % 2 != 0;
        }
    }
}
