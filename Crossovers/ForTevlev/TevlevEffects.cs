using UnityEngine;
using System.Collections.Generic;
using System.Text;
using BrutalAPI;

namespace SaltsEnemies_Reseasoned
{
    public static class Demonstration
    {
        public static void Add()
        {
            //1st ability
            RemovePassiveEffect rem_1st = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            AddPassiveEffect add_2nd = ScriptableObject.CreateInstance<AddPassiveEffect>();

            Ability first = new Ability("First_A");
            first.Effects = [
                Effects.GenerateEffect(rem_1st, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(add_2nd, 1, Targeting.Slot_SelfSlot)
                ];

            BasePassiveAbilitySO passive_1st = Passives.BonusAttackGenerator(new ExtraAbilityInfo() { ability = first.ability, rarity = Rarity.Impossible });

            rem_1st.m_PassiveID = passive_1st.m_PassiveID;

            //2nd ability
            RemovePassiveEffect rem_2nd = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            AddPassiveEffect add_3rd = ScriptableObject.CreateInstance<AddPassiveEffect>();

            Ability second = new Ability("Second_A");
            second.Effects = [
                Effects.GenerateEffect(rem_2nd, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(add_3rd, 1, Targeting.Slot_SelfSlot)
                ];

            BasePassiveAbilitySO passive_2nd = Passives.BonusAttackGenerator(new ExtraAbilityInfo() { ability = second.ability, rarity = Rarity.Impossible });

            add_2nd._passiveToAdd = passive_2nd;

            rem_2nd.m_PassiveID = passive_2nd.m_PassiveID;

            
        }
    }


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
