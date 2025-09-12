using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoneds
{
    public class RandomizeLightsEffects : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            foreach (TargetSlotInfo target in targets)
            {
                RemoveFieldEffect("GreenLight_ID", stats, target);
                RemoveFieldEffect("RedLight_ID", stats, target);
                RemoveFieldEffect("BlueLight_ID", stats, target);
            }
            foreach (TargetSlotInfo target in targets)
            {
                stats.combatSlots.ApplyFieldEffect(target.SlotID, target.IsTargetCharacterSlot, (new FieldEffect_SO[] { Green.Object, Red.Object, Blue.Object }).GetRandom(), 1);
            }
            exitAmount = 0;
            return true;
        }
        public void RemoveFieldEffect(string field, CombatStats stats, TargetSlotInfo target)
        {
            CombatSlot combatSlot = ((!target.IsTargetCharacterSlot) ? stats.combatSlots.EnemySlots[target.SlotID] : stats.combatSlots.CharacterSlots[target.SlotID]);
            int num = 0;
            foreach (IFieldEffect fieldEffect in combatSlot.FieldEffects)
            {
                if (!(fieldEffect.FieldID != field))
                {
                    num = fieldEffect.FieldContent;
                    break;
                }
            }

            if (num > 0)
            {
                combatSlot.RemoveFieldEffect(field);
            }
        }
    }
    public class RemoveLightsEffects : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            foreach (TargetSlotInfo target in targets)
            {
                RemoveFieldEffect("GreenLight_ID", stats, target);
                RemoveFieldEffect("RedLight_ID", stats, target);
                RemoveFieldEffect("BlueLight_ID", stats, target);
            }
            exitAmount = 0;
            return true;
        }
        public void RemoveFieldEffect(string field, CombatStats stats, TargetSlotInfo target)
        {
            CombatSlot combatSlot = ((!target.IsTargetCharacterSlot) ? stats.combatSlots.EnemySlots[target.SlotID] : stats.combatSlots.CharacterSlots[target.SlotID]);
            int num = 0;
            foreach (IFieldEffect fieldEffect in combatSlot.FieldEffects)
            {
                if (!(fieldEffect.FieldID != field))
                {
                    num = fieldEffect.FieldContent;
                    break;
                }
            }

            if (num > 0)
            {
                combatSlot.RemoveFieldEffect(field);
            }
        }
    }
}
