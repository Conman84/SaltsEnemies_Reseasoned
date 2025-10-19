using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaltsEnemies_Reseasoneds
{
    public class RandomizeLightsEffects : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            StatusFieldSpeedSecondUIAction.SpeedUp(stats);

            foreach (TargetSlotInfo target in targets)
            {
                RemoveFieldEffect("GreenLight_ID", stats, target);
                RemoveFieldEffect("RedLight_ID", stats, target);
                RemoveFieldEffect("BlueLight_ID", stats, target);
            }
            foreach (TargetSlotInfo target in targets)
            {
                stats.combatSlots.ApplyFieldEffect(target.SlotID, target.IsTargetCharacterSlot, (new FieldEffect_SO[] { Green.Object, Red.Object, Blue.Object }).GetRandom(), 1);
            }

            CombatManager.Instance.AddUIAction(new StatusFieldSpeedSecondUIAction());

            exitAmount = 0;
            return true;
        }
        public void RemoveFieldEffect(string field, CombatStats stats, TargetSlotInfo target)
        {
            CombatSlot combatSlot = ((!target.IsTargetCharacterSlot) ? stats.combatSlots.EnemySlots[target.SlotID] : stats.combatSlots.CharacterSlots[target.SlotID]);
            int num = 0;
            foreach (IFieldEffect fieldEffect in combatSlot.FieldEffects)
            {
                if (!(fieldEffect.FieldID != field))
                {
                    num = fieldEffect.FieldContent;
                    break;
                }
            }

            if (num > 0)
            {
                combatSlot.RemoveFieldEffect(field);
            }
        }
    }
    public class RemoveLightsEffects : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            StatusFieldSpeedSecondUIAction.SpeedUp(stats);

            foreach (TargetSlotInfo target in targets)
            {
                RemoveFieldEffect("GreenLight_ID", stats, target);
                RemoveFieldEffect("RedLight_ID", stats, target);
                RemoveFieldEffect("BlueLight_ID", stats, target);
            }

            CombatManager.Instance.AddUIAction(new StatusFieldSpeedSecondUIAction());

            exitAmount = 0;
            return true;
        }
        public void RemoveFieldEffect(string field, CombatStats stats, TargetSlotInfo target)
        {
            CombatSlot combatSlot = ((!target.IsTargetCharacterSlot) ? stats.combatSlots.EnemySlots[target.SlotID] : stats.combatSlots.CharacterSlots[target.SlotID]);
            int num = 0;
            foreach (IFieldEffect fieldEffect in combatSlot.FieldEffects)
            {
                if (!(fieldEffect.FieldID != field))
                {
                    num = fieldEffect.FieldContent;
                    break;
                }
            }

            if (num > 0)
            {
                combatSlot.RemoveFieldEffect(field);
            }
        }
    }
    public class HotspotEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.GetFieldAmount("GreenLight_ID") > 0 && StatusExtensions.GetFieldAmountFromID(caster.SlotID, caster.IsUnitCharacter, "GreenLight_ID") > 0) ret.Add(target);
                if (target.GetFieldAmount("RedLight_ID") > 0 && StatusExtensions.GetFieldAmountFromID(caster.SlotID, caster.IsUnitCharacter, "RedLight_ID") > 0) ret.Add(target);
                if (target.GetFieldAmount("BlueLight_ID") > 0 && StatusExtensions.GetFieldAmountFromID(caster.SlotID, caster.IsUnitCharacter, "BlueLight_ID") > 0) ret.Add(target);
            }
            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class ShiftCostsEffect : EffectSO
    {
        public static ManaColorSO[] RandomArray(ManaColorSO[] origin)
        {
            List<ManaColorSO> list = new List<ManaColorSO>();
            for (int i = 0; i < origin.Length; i++)
            {
                list.Add(RandomPig(origin[i]));
            }
            return list.ToArray();
        }
        public static ManaColorSO RandomPig(ManaColorSO source)
        {
            if (source.pigmentTypes.Count <= 0) return source;
            if (source.pigmentTypes.Count == 1) return Shift(source.pigmentTypes[0]);
            List<ManaColorSO> param = new List<ManaColorSO>();
            foreach (string id in source.pigmentTypes) param.Add(Shift(id));
            return Pigments.SplitPigment(param.ToArray());
        }
        public static ManaColorSO Shift(string id)
        {
            if (id == Pigments.Red.pigmentTypes[0]) return Pigments.Blue;
            if (id == Pigments.Blue.pigmentTypes[0]) return Pigments.Yellow;
            if (id == Pigments.Yellow.pigmentTypes[0]) return Pigments.Purple;
            if (id == Pigments.Purple.pigmentTypes[0]) return Pigments.Red;
            return Pigments.GetPigmentWithID(id);
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (!targetSlotInfo.HasUnit || !(targetSlotInfo.Unit is CharacterCombat characterCombat))
                {
                    continue;
                }
                foreach (CombatAbility combatAbility in characterCombat.CombatAbilities)
                {
                    combatAbility.cost = RandomArray(combatAbility.cost);
                    exitAmount += combatAbility.cost.Length;
                }
                foreach (CharacterCombatUIInfo value in stats.combatUI._charactersInCombat.Values)
                {
                    if (value.SlotID != targetSlotInfo.Unit.SlotID)
                    {
                        continue;
                    }
                    CharacterCombatUIInfo characterCombatUIInfo = value;
                    List<CombatAbility> combatAbilities = (targetSlotInfo.Unit as CharacterCombat).CombatAbilities;
                    int num2 = 0;
                    CombatAbility[] array = new CombatAbility[combatAbilities.Count];
                    foreach (CombatAbility item in combatAbilities)
                    {
                        array[num2] = item;
                        num2++;
                    }
                    characterCombatUIInfo.UpdateAttacks(array);
                    break;
                }
                CombatManager instance = CombatManager.Instance;
                int iD = (targetSlotInfo.Unit as CharacterCombat).ID;
                List<CombatAbility> combatAbilities2 = (targetSlotInfo.Unit as CharacterCombat).CombatAbilities;
                int num3 = 0;
                CombatAbility[] array2 = new CombatAbility[combatAbilities2.Count];
                foreach (CombatAbility item2 in combatAbilities2)
                {
                    array2[num3] = item2;
                    num3++;
                }
                instance.AddUIAction(new CharacterUpdateAllAttacksUIAction(iD, array2));
            }
            return exitAmount > 0;
        }
    }
    public class HotspotTargetting : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (CombatSlot target in isCasterCharacter == getAllies ? slots.CharacterSlots : slots.EnemySlots)
            {
                if (target.GetFieldAmount("GreenLight_ID") > 0 && StatusExtensions.GetFieldAmountFromID(casterSlotID, isCasterCharacter, "GreenLight_ID") > 0) ret.Add(target.TargetSlotInformation);
                else if (target.GetFieldAmount("RedLight_ID") > 0 && StatusExtensions.GetFieldAmountFromID(casterSlotID, isCasterCharacter, "RedLight_ID") > 0) ret.Add(target.TargetSlotInformation);
                else if (target.GetFieldAmount("BlueLight_ID") > 0 && StatusExtensions.GetFieldAmountFromID(casterSlotID, isCasterCharacter, "BlueLight_ID") > 0) ret.Add(target.TargetSlotInformation);
            }
            return ret.ToArray();
        }
    }
    public class StatusFieldSpeedUIAction : CombatAction
    {
        public static string Original;
        public bool Fast;

        public StatusFieldSpeedUIAction(bool fast)
        {
            Fast = fast;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (Fast)
            {
                Original = CombatManager.Instance._pauseHandler._optionsData.GetModularData("MOpt_StatusFieldPopUpShowTime");
                CombatManager.Instance._pauseHandler._optionsData.UpdateModularData("MOpt_StatusFieldPopUpShowTime", "0");

                Debug.Log("test test " + Original);
            }
            else
            {
                CombatManager.Instance._pauseHandler._optionsData.UpdateModularData("MOpt_StatusFieldPopUpShowTime", Original);

                Debug.Log("test test test test");
            }
            yield break;
        }
    }
    public class StatusFieldSpeedSecondUIAction : CombatAction
    {
        public static float Origin;
        public static bool Sped;
        public static void SpeedUp(CombatStats stats)
        {
            if (!Sped) Origin = stats.combatUI._popUpHandler3D._StatusWaitTime;
            stats.combatUI._popUpHandler3D._StatusWaitTime = 0;
            Sped = true;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            stats.combatUI._popUpHandler3D._StatusWaitTime = Origin;
            Sped = false;
            yield break;
        }
    }
    public class StoredValueEffectorCondition : EffectorConditionSO
    {
        public string Value;
        public bool ShouldZero;
        public bool onlyOnce;

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            bool ret = (effector as IUnit).SimpleGetStoredValue(Value) == 0 == ShouldZero;
            if (onlyOnce) (effector as IUnit).SimpleSetStoredValue(Value, 1);
            return ret;
        }

        public static StoredValueEffectorCondition Create(string value, bool zero, bool once = false)
        {
            StoredValueEffectorCondition ret = ScriptableObject.CreateInstance<StoredValueEffectorCondition>();
            ret.Value = value;
            ret.ShouldZero = zero;
            ret.onlyOnce = once;
            return ret;
        }
    }
}
