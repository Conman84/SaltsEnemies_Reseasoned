using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class TinCanCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference reference)
            {
                if ((effector as IUnit).Heal(1, effector as IUnit, true) > 0)
                {
                    reference.value = false;
                }
            }
            return true;
        }
    }
}
