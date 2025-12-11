using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class MoveToRandomEmptyTileEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            List<IUnit> list = new List<IUnit>();
            List<IUnit> list2 = new List<IUnit>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    IUnit unit = targets[i].Unit;
                    if (unit.IsUnitCharacter && !list.Contains(unit))
                    {
                        list.Add(unit);
                    }
                    else if (!unit.IsUnitCharacter && !list2.Contains(unit))
                    {
                        list2.Add(unit);
                    }
                }
            }

            //fools
            foreach (IUnit item in list)
            {
                List<int> slots = [];
                foreach (CombatSlot slot in stats.combatSlots.CharacterSlots) if (!slot.HasUnit) slots.Add(slot.SlotID);
                if (slots.Count <= 0) continue;

                int targetSlot = slots.GetRandom();

                if (targetSlot >= 0 && targetSlot < stats.combatSlots.CharacterSlots.Length && stats.combatSlots.SwapCharacters(item.SlotID, targetSlot, isMandatory: true))
                {
                    exitAmount++;
                }
            }

            //enemies
            foreach (IUnit item2 in list2)
            {
                if (item2.Size > 1) continue;

                List<int> slots = [];
                foreach (CombatSlot slot in stats.combatSlots.EnemySlots) if (!slot.HasUnit) slots.Add(slot.SlotID);
                if (slots.Count <= 0) continue;

                int targetSlot = slots.GetRandom();

                if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, targetSlot, out var firstSlotSwap, out var secondSlotSwap) && stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, targetSlot, secondSlotSwap, isMandatory: true))
                {
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
}
