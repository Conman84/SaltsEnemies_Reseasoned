using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class StageFrightCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is DamageDealtValueChangeException change)
            {
                foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter))
                {
                    if (target.HasUnit) return false;
                }
                unit.ShowItem();
                change.AddModifier(new FloatMod(1.3f, true));
            }
            return false;
        }
    }
}
