using System;
using System.Collections.Generic;
using System.Text;

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
                    if (i < caster.SlotID && stats.combatSlots.EnemySlots[i].HasUnit)
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
            for (int j = 9; j < entryVariable && j < lim; j++) base.PerformEffect(stats, caster, targets, areTargetSlots, 1, out exitAmount);
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
            for (int i = 0; i < 4; i++) base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            return true;
        }
    }
}
