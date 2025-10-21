using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoneds
{
    public class NoFallofCascadeCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is CascadeSpecialBooleanReference reference)
            {
                reference.value = true;
                reference.IgnoreFallof = true;
                (effector as IUnit).ShowItem();
            }
            return false;
        }
    }
}
