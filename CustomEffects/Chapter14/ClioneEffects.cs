using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class RemoveAllWaterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].IsTargetCharacterSlot)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveFieldEffect(Water.FieldID);
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveFieldEffect(Water.FieldID);
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyWaterLastExitEffect : ApplyWaterSlotEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (base.PreviousExitValue <= 0) return false;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, Math.Max(1, (int)Math.Floor(((float)base.PreviousExitValue) / 2)), out exitAmount);
        }
    }
}
