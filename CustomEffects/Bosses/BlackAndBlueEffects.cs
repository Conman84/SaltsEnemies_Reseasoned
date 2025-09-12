using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class PermenantApplyWaterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (stats.combatSlots.ApplyFieldEffect(target.SlotID, target.IsTargetCharacterSlot, Water.Object, 0, 1)) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public class RemoveRestrictorWaterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (stats.combatSlots.DettachSlotStatusRestrictor("Water_ID", target.SlotID, target.IsTargetCharacterSlot)) exitAmount++;
            }
            return exitAmount > 0;
        }
    }
}
