using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class YellowBotSpecialEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsUnitCharacter && caster.HealthColor.UsedBy(target.Unit.ID))
                {
                    base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi);
                    exitAmount += exi;
                }
                else
                {
                    base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 0, out int exi);
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
    public class BlueBotSpecialEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsUnitCharacter && caster.HealthColor.UsedBy(target.Unit.ID))
                {
                    base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi);
                    exitAmount += exi;
                    target.Unit.MaximizeHealth(target.Unit.CurrentHealth);
                }
                else
                {
                    base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 0, out int exi);
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
}
