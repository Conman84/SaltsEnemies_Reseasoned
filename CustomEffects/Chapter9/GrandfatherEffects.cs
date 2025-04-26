using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class DisabledCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference skinteger)
            {
                if (skinteger.value >= 2)
                    return true;
            }
            return false;
        }
    }
    public class ApplyPermanentRupturedEffect : PermenantStatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = StatusField.Ruptured;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class TargettingUnitsEitherSide : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool right;

        public bool ignoreDirectNextAllyOnly = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        Targetting_ByUnit_Side source = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            source.getAllies = getAllies;
            source.getAllUnitSlots = false;
            source.ignoreCastSlot = true;
            TargetSlotInfo[] chumby = source.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in chumby)
            {
                if (right)
                {
                    if (target.SlotID <= casterSlotID || !target.HasUnit) continue;
                    if (getAllies)
                    {
                        if (!ignoreDirectNextAllyOnly || target.SlotID != casterSlotID + 1)
                        {
                            targets.Add(target);
                        }
                    }
                    else
                    {
                        targets.Add(target);
                    }
                }
                else
                {
                    if (target.SlotID >= casterSlotID || !target.HasUnit) continue;
                    if (getAllies)
                    {
                        if (!ignoreDirectNextAllyOnly || target.SlotID != casterSlotID - target.Unit.Size)
                        {
                            targets.Add(target);
                        }
                    }
                    else
                    {
                        targets.Add(target);
                    }
                }
            }
            if (!right) targets.Reverse();
            return targets.ToArray();
        }
    }
    public class SinkMovementEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            TargettingUnitsEitherSide left = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
            left.right = false;
            left.getAllies = false;
            TargettingUnitsEitherSide right = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
            right.right = true;
            right.getAllies = false;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;
            EffectInfo[] info = new EffectInfo[]
            {
                Effects.GenerateEffect(goLeft, 1, right),
                Effects.GenerateEffect(goRight, 1, left),
            };

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(info, target.Unit));
                }
            }
            return exitAmount > 0;
        }
    }
}
