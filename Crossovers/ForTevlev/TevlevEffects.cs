using UnityEngine;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class RerollTargetFirstAbilitiesEffect : ReRollTargetTimelineAbilityEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && !targetSlotInfo.IsTargetCharacterSlot)
                {
                    int turnsToReRoll = (_useRandomBetween ? Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
                    EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                    exitAmount += TryReRollFirstEnemyTurns(stats.timeline, unit, turnsToReRoll, dontRerollIfNoAbilitiesLeft);
                }
            }
            return exitAmount > 0;
        }
        public int TryReRollFirstEnemyTurns(Timeline_Base self, ITurn unit, int turnsToReRoll, bool dontRerollIfNoAbilitiesLeft)
        {
            int num = 0;
            List<int> list = new List<int>();
            for (int i = self.CurrentTurn + 1; i < self.Round.Count; i++)
            {
                if (self.Round[i].turnUnit == unit && unit.CanRerollAbility(self.Round[i].abilitySlot))
                {
                    list.Add(i);
                }
            }
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            List<int> list4 = new List<int>();
            while (turnsToReRoll > 0 && list.Count > 0)
            {
                int index = 0;
                int num2 = list[index];
                list.RemoveAt(index);
                TurnInfo value = self.Round[num2];
                int singleAbilitySlotUsage = unit.GetSingleAbilitySlotUsage(value.abilitySlot, dontRerollIfNoAbilitiesLeft);
                if (singleAbilitySlotUsage == -1)
                {
                    break;
                }
                list3.Add(value.abilitySlot);
                list4.Add(singleAbilitySlotUsage);
                list2.Add(num2);
                value.abilitySlot = singleAbilitySlotUsage;
                self.Round[num2] = value;
                turnsToReRoll--;
                num++;
            }
            if (list2.Count > 0)
            {
                CombatManager.Instance.AddUIAction(new UpdateReRolledSlotTimelineUIAction(unit.ID, list2.ToArray(), list3.ToArray(), list4.ToArray()));
            }
            return num;
        }
    }
}
