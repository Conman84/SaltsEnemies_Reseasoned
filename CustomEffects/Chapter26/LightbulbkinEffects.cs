using SaltEnemies_Reseasoned;
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
    public class MoveTowardsEdgeEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _swapRight = Random.Range(0, 100) < 50;
            switch (caster.Size)
            {
                case 1:
                    if (caster.SlotID < 2) _swapRight = false;
                    else if (caster.SlotID > 2) _swapRight = true;
                    break;
                case 2:
                    if (caster.SlotID <= 1) _swapRight = false;
                    else _swapRight = true;
                    break;
                case 3:
                    if (caster.SlotID <= 0) _swapRight = false;
                    else if (caster.SlotID >= 2) _swapRight = true;
                    break;
                case 4:
                    if (caster.SlotID <= 0) _swapRight = false;
                    else _swapRight = true;
                    break;
            }
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class HasDodgeCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.ContainsStatusEffect(Dodge.StatusID);
        }
    }
    public class QueueShiftEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromName("ShiftDistalParadigm_A") });
            }
            return true;
        }
    }
}

