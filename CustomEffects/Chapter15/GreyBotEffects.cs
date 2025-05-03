using BrutalAPI;
using System;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class MoveTowardsNearestEnemyEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int lim = -1;
            bool rightByRandom = UnityEngine.Random.Range(0f, 1f) < 0.5f;
            if (caster.IsUnitCharacter)
            {
                int leftLim = 5;
                int rightLim = 5;
                for (int i = 0; i < 5; i++)
                {
                    if (i < caster.SlotID && stats.combatSlots.EnemySlots[i].HasUnit && stats.combatSlots.EnemySlots[i].Unit.Size - 1 + i < caster.SlotID)
                    {
                        int calc = Math.Abs(i - caster.SlotID);
                        if (calc < leftLim) leftLim = calc;
                    }
                    else if (i > caster.SlotID + (caster.Size - 1) && stats.combatSlots.EnemySlots[i].HasUnit)
                    {
                        int calc = Math.Abs(i - caster.SlotID);
                        if (calc < rightLim) rightLim = calc;
                    }
                    else if (stats.combatSlots.EnemySlots[i].HasUnit) return false;
                }
                if (leftLim < rightLim)
                {
                    lim = leftLim;
                    _swapRight = false;
                }
                else if (rightLim < leftLim)
                {
                    lim = rightLim;
                    _swapRight = true;
                }
                else
                {
                    lim = leftLim;
                    _swapRight = rightByRandom;
                }
            }
            else
            {
                int leftLim = 5;
                int rightLim = 5;
                for (int i = 0; i < 5; i++)
                {
                    if (i < caster.SlotID && stats.combatSlots.CharacterSlots[i].HasUnit)
                    {
                        int calc = Math.Abs(i - caster.SlotID);
                        if (calc < leftLim) leftLim = calc;
                    }
                    else if (i > caster.SlotID + (caster.Size - 1) && stats.combatSlots.CharacterSlots[i].HasUnit)
                    {
                        int calc = Math.Abs(i - caster.SlotID);
                        if (calc < rightLim) rightLim = calc;
                    }
                    else if (stats.combatSlots.CharacterSlots[i].HasUnit) return false;
                }
                if (leftLim < rightLim)
                {
                    lim = leftLim;
                    _swapRight = false;
                }
                else if (rightLim > leftLim)
                {
                    lim = rightLim;
                    _swapRight = true;
                }
                else
                {
                    lim = leftLim;
                    _swapRight = rightByRandom;
                }
            }
            for (int j = 0; j < entryVariable && j < lim; j++) base.PerformEffect(stats, caster, targets, areTargetSlots, 1, out exitAmount);
            return lim > 0;
        }
    }
    public class MoveAllTheWayOneSideEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.SlotID == 0) _swapRight = true;
            else if (caster.SlotID + (caster.Size - 1) >= 4) _swapRight = false;
            else
            {
                if (caster.IsUnitCharacter)
                {
                    if (stats.combatSlots.CharacterSlots[caster.SlotID - 1].HasUnit && !stats.combatSlots.CharacterSlots[caster.SlotID - 1].Unit.CanBeSwapped) _swapRight = true;
                    else if (stats.combatSlots.CharacterSlots[caster.SlotID + caster.Size].HasUnit && !stats.combatSlots.CharacterSlots[caster.SlotID + caster.Size].Unit.CanBeSwapped) _swapRight = false;
                    else _swapRight = UnityEngine.Random.Range(0f, 1f) < 0.5f;
                }
                else
                {
                    if (stats.combatSlots.EnemySlots[caster.SlotID - 1].HasUnit && !stats.combatSlots.EnemySlots[caster.SlotID - 1].Unit.CanBeSwapped) _swapRight = true;
                    else if (stats.combatSlots.EnemySlots[caster.SlotID + caster.Size].HasUnit && !stats.combatSlots.EnemySlots[caster.SlotID + caster.Size].Unit.CanBeSwapped) _swapRight = false;
                    else _swapRight = UnityEngine.Random.Range(0f, 1f) < 0.5f;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out exitAmount);
            }
            return true;
        }
    }
    public static class CCTVHandler
    {
        public static TriggerCalls Trigger => (TriggerCalls)9992372;
    }
    public class CCTVCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IUnit unit)
            {
                if (unit.SlotID + (unit.Size - 1) < effector.SlotID)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowCCTVPassiveEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    }, effector as IUnit));
                }
                else if (unit.SlotID > effector.SlotID + ((effector as IUnit).Size - 1))
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowCCTVPassiveEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                    }, effector as IUnit));
                }
            }
            return false;
        }
    }
    public class ShowCCTVPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "C.C.T.V.", ResourceLoader.LoadSprite("CCTVPassive.png")));
            return true;
        }
    }
}
