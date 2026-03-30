using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class DirectCascadeIncreaseByEntryEffect : EffectSO
    {
        public bool _doLeft;
        public bool _doRight;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int start = target.Unit.Damage(caster.WillApplyDamage(0, target.Unit), caster, "Basic", target.SlotID - target.Unit.SlotID).damageAmount;
                    exitAmount += start;

                    int left = start + entryVariable;
                    int right = start + entryVariable;

                    int left_id = target.SlotID - 1;
                    int right_id = target.SlotID + 1;

                    int ticks = 0;

                    while (left > 0 || right > 0 || left_id >= 0 || right_id < 5)
                    {
                        if (left_id >= 0 && _doLeft)
                        {
                            CombatSlot left_slot = target.IsTargetCharacterSlot ? stats.combatSlots.CharacterSlots[left_id] : stats.combatSlots.EnemySlots[left_id];
                            if (!left_slot.HasUnit || left < 0)
                            {
                                left = -1;
                                left_id = -1;
                            }
                            else
                            {
                                left = left_slot.Unit.Damage(caster.WillApplyDamage(left, left_slot.Unit), caster, "Basic", left_slot.SlotID - left_slot.Unit.SlotID).damageAmount;
                                exitAmount += left;
                                left += entryVariable;
                                left_id--;
                            }
                        }
                        else
                        {
                            left = -1;
                            left_id = -1;
                        }

                        if (right_id < 5 && _doRight)
                        {
                            CombatSlot right_slot = target.IsTargetCharacterSlot ? stats.combatSlots.CharacterSlots[right_id] : stats.combatSlots.EnemySlots[right_id];
                            if (!right_slot.HasUnit || right < 0)
                            {
                                right = -1;
                                right_id = 6;
                            }
                            else
                            {
                                right = right_slot.Unit.Damage(caster.WillApplyDamage(right, right_slot.Unit), caster, "Basic", right_slot.SlotID - right_slot.Unit.SlotID).damageAmount;
                                exitAmount += right;
                                right += entryVariable;
                                right_id++;
                            }
                        }
                        else
                        {
                            right = -1;
                            right_id = 6;
                        }

                        ticks++;

                        if (ticks > 5) break;
                    }
                }
            }

            caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }

    public class Targetting_Furthest_Unit_To_Side : BaseCombatTargettingSO
    {
        public bool getAllies;
        public override bool AreTargetAllies => getAllies;
        public override bool AreTargetSlots => true;

        public bool _leftmost;
        public bool _rightmost;
        public int[] _offset;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = [];

            bool got = false;
            int counting = 0;

            if (_leftmost)
            {
                for (int i = 0; i < 5; i++)
                {
                    CombatSlot slot = getAllies == isCasterCharacter ? slots.CharacterSlots[i] : slots.EnemySlots[i];

                    if (slot.HasUnit || got)
                    {
                        if (_offset.Contains(counting)) ret.Add(slot.TargetSlotInformation);
                        got = true;
                        counting++;
                    }
                }
            }

            got = false;
            counting = 0;

            if (_rightmost)
            {
                for (int i = 4; i >= 0; i--)
                {
                    CombatSlot slot = getAllies == isCasterCharacter ? slots.CharacterSlots[i] : slots.EnemySlots[i];

                    if (slot.HasUnit || got)
                    {
                        if (_offset.Contains(counting)) ret.Add(slot.TargetSlotInformation);
                        got = true;
                        counting++;
                    }
                }
            }

            return ret.ToArray();
        }
    }
}
