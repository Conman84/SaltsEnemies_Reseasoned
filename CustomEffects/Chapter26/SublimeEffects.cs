using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class ZeroOrEntryEffect : EffectSO
    {
        public EffectSO effect;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                bool yes = UnityEngine.Random.Range(0, 100) < 50;

                effect.PerformEffect(stats, caster, [target], areTargetSlots, !yes ? 0 : entryVariable, out int exit);
                exitAmount += exit;
            }

            return exitAmount > 0;
        }

        public static ZeroOrEntryEffect Create(EffectSO effect)
        {
            ZeroOrEntryEffect ret = ScriptableObject.CreateInstance<ZeroOrEntryEffect>();
            ret.effect = effect;
            return ret;
        }
    }
    public class TargettingFurthestSide : BaseCombatTargettingSO
    {
        public bool getAllies;
        public override bool AreTargetAllies => getAllies;
        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            int size = 1;
            if (!isCasterCharacter)
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if (slot.SlotID == casterSlotID)
                    {
                        if (slot.HasUnit) size = slot.Unit.Size;
                        break;
                    }
                }
            }

            List<TargetSlotInfo> left = [];
            List<TargetSlotInfo> right = [];

            foreach (CombatSlot slot in isCasterCharacter == getAllies ? slots.CharacterSlots : slots.EnemySlots)
            {
                if (slot.HasUnit)
                {
                    if (slot.SlotID < casterSlotID) left.Add(slot.TargetSlotInformation);
                    else if (slot.SlotID > casterSlotID + size - 1) right.Add(slot.TargetSlotInformation);
                }
            }

            if (left.Count > right.Count) return left.ToArray();
            else if (right.Count > left.Count) return right.ToArray();
            else
            {
                left.AddRange(right);
                return left.ToArray();
            }
        }
    }
}
