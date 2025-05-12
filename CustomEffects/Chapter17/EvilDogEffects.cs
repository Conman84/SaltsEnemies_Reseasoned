using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class RingingNoiseEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Ringing Noise") });
            }
            return true;
        }
    }
    public class ApplySlipIfNoneEffect : ApplySlipSlotEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (!stats.combatSlots.UnitInSlotContainsFieldEffect(target.SlotID, target.IsTargetCharacterSlot, Slip.FieldID))
                {
                    if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi)) exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
    public class StingingPainEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Stinging Pain") });
            }
            return true;
        }
    }
    public class FrontHas3ConstrictedEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
            {
                if (target.GetFieldAmount(StatusField_GameIDs.Constricted_ID.ToString(), true) >= 3) return true;
            }
            return false;
        }
    }
    public class FlipFlopEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Flip Flop") });
            }
            return true;
        }
    }
    public class FrontHas2SlipEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
            {
                if (target.GetFieldAmount(Slip.FieldID, true) >= 2) return true;
            }
            return false;
        }
    }
    public class SwapSidesReturnTrueEffect : SwapToSidesEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            return true;
        }
    }
    public class RemoveAllConstrictedEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].IsTargetCharacterSlot)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveFieldEffect(StatusField_GameIDs.Constricted_ID.ToString());
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveFieldEffect(StatusField_GameIDs.Constricted_ID.ToString());
                }
            }

            return exitAmount > 0;
        }
    }
    public class RemoveAllSlipEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].IsTargetCharacterSlot)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveFieldEffect(Slip.FieldID);
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveFieldEffect(Slip.FieldID);
                }
            }

            return exitAmount > 0;
        }
    }
    public class ToggleEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Toggle") });
            }
            return true;
        }
    }
    public class LRHas1SlipEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (TargetSlotInfo target in Slots.LeftRight.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
            {
                if (target.GetFieldAmount(Slip.FieldID, true) >= 1) return true;
            }
            return false;
        }
    }
    public class RingerEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Ringer") });
            }
            return true;
        }
    }
    public class FrontHas1SlipEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
            {
                if (target.GetFieldAmount(Slip.FieldID, true) >= 1) return true;
            }
            return false;
        }
    }
    public class NylonPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Nylon", ResourceLoader.LoadSprite("NylonPassive.png")));
            exitAmount = 0;
            return true;
        }
    }
    public class MoveTowardsSlipEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int rightMod = 1;
            int leftMod = 1;
            if (!caster.IsUnitCharacter)
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == caster.SlotID + caster.Size) rightMod = enemy.Size;
                    if (enemy.SlotID == caster.SlotID - enemy.Size) leftMod = enemy.Size;
                }
            }
            TargetSlotInfo Left = null;
            TargetSlotInfo Right = null;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.SlotID == caster.SlotID - leftMod) Left = target;
                else if (target.SlotID == caster.SlotID + rightMod) Right = target;
            }
            bool Lefting = (Left != null && Left.GetFieldAmount(Slip.FieldID) > 0);
            bool righting = (Right != null && Right.GetFieldAmount(Slip.FieldID) > 0);
            if (Lefting && righting)
            {
                ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else if (Lefting)
            {
                BasicEffects.GoLeft.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else if (righting)
            {
                BasicEffects.GoRight.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else
            {
                ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int grag);
                return false;
            }
        }
    }
}
