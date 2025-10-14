using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class HexedScopeCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                if (FirstPerTurnHandler.FirstAbilityUsed) value.AddModifier(new PercentageValueModifier(true, 15, false));
                else value.AddModifier(new PercentageValueModifier(true, 50, true));
            }
            return true;
        }
    }
}
