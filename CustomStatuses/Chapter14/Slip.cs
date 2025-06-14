﻿using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Slip
    {
        public static string FieldID => "Slip_ID";
        public static string Intent => "Field_Slip";
        public static SlipFE_SO Object;
        public static string Trigger => "Slip_Trigger";
        public static void Add()
        {
            SlotStatusEffectInfoSO SlipInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
            SlipInfo.icon = ResourceLoader.LoadSprite("SlipIcon.png");
            SlipInfo._fieldName = "Slip";
            SlipInfo._description = "On moving into Slip, decrease Slip by 1 and move again in the same direction.";
            SlipInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo._applied_SE_Event;
            SlipInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            SlipInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.OilSlicked_ID.ToString()]._EffectInfo.UpdatedSoundEvent;


            GameObject Fool = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/SlipChara2.prefab").gameObject;
            GameObject FoolPart = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/SlipChara3.prefab").gameObject;
            FoolPart.transform.SetParent(Fool.transform);
            GameObject_CFE_Layout LayoutFool = Fool.AddComponent<GameObject_CFE_Layout>();
            LayoutFool.m_Swap = new RectTransform[] { FoolPart.GetComponent<RectTransform>() };
            LayoutFool.m_Back = new RectTransform[] { Fool.GetComponent<RectTransform>() };
            LayoutFool.m_Objects = new GameObject[] { Fool, FoolPart };
            SlipInfo.m_CharacterLayoutTemplate = LayoutFool;

            GameObject Enemy = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("Assets/train/SlipEnemy.prefab");
            GameObject_EFE_Layout LayoutEnemy = Enemy.AddComponent<GameObject_EFE_Layout>();
            LayoutEnemy.m_Objects = new GameObject[] { Enemy };
            SlipInfo.m_EnemyLayoutTemplate = LayoutEnemy;

            SlipFE_SO SlipSO = ScriptableObject.CreateInstance<SlipFE_SO>();
            SlipSO._FieldID = FieldID;
            SlipSO._EffectInfo = SlipInfo;
            Object = SlipSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(FieldID)) LoadedDBsHandler.StatusFieldDB.FieldEffects[FieldID] = SlipSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewFieldEffect(SlipSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("SlipIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }

    public class SlipFE_SO : FieldEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnSlotEffectorTriggerAttached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, Slip.Trigger, holder.Effector);
        }
        public override void OnSlotEffectorTriggerDettached(FieldEffect_Holder holder)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, Slip.Trigger, holder.Effector);
        }
        public override void OnTriggerAttached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnMoved.ToString(), caller);
        }
        public override void OnTriggerDettached(FieldEffect_Holder holder, IUnit caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnMoved.ToString(), caller);
        }
        public override void OnEventCall_01(FieldEffect_Holder holder, object sender, object args)
        {
            if (holder.m_ContentMain + holder.Restrictor <= 0) return;
            if (sender is IUnit unit && args is IntegerReference oldslot && oldslot.value != unit.SlotID)
            {

                CombatManager.Instance.AddSubAction(new SlipAction(unit.SlotID, unit, oldslot.value < unit.SlotID, holder.Effector as CombatSlot));
                return;

                CombatStats stats = CombatManager.Instance._stats;
                SwapToOneSideEffect perform = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                perform._swapRight = oldslot.value < unit.SlotID;
                perform.PerformEffect(stats, unit, (holder.Effector as CombatSlot).TargetSlotInformation.SelfArray(), true, 1, out int exitAmount);

                /*int num = oldslot.value < unit.SlotID ? (unit.IsUnitCharacter ? 1 : unit.Size) : (-1);
                if (unit.IsUnitCharacter)
                {
                    if (unit.SlotID + num >= 0 && unit.SlotID + num < stats.combatSlots.CharacterSlots.Length)
                    {
                        stats.combatSlots.SwapCharacters(unit.SlotID, unit.SlotID + num, isMandatory: true);

                    }
                }
                else
                {
                    if (stats.combatSlots.CanEnemiesSwap(unit.SlotID, unit.SlotID + num, out var firstSlotSwap, out var secondSlotSwap))
                    {
                        stats.combatSlots.SwapEnemies(unit.SlotID, firstSlotSwap, unit.SlotID + num, secondSlotSwap);
                    }
                }*/
            }
        }
        public override void OnEventCall_02(FieldEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder);
        }
        public override void ReduceDuration(FieldEffect_Holder holder)
        {
            int contentMain = holder.m_ContentMain;
            holder.m_ContentMain = Mathf.Max(0, contentMain - 1);
            if (!TryRemoveFieldEffect(holder) && contentMain != holder.m_ContentMain)
            {
                holder.Effector.FieldEffectValuesChanged(_FieldID, useSpecialSound: false, holder.m_ContentMain - contentMain);
            }
        }
    }
    public class SlipAction : CombatAction
    {
        public int originSlot;
        public CombatSlot slot;
        public IUnit unit;
        public bool swapRight;
        public SlipAction(int origin, IUnit unit, bool right, CombatSlot slot)
        {
            originSlot = origin;
            this.unit = unit;
            swapRight = right;
            this.slot = slot;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (unit.SlotID == originSlot && slot.ContainsFieldEffect(Slip.FieldID))
            {
                CombatManager.Instance.PostNotification(Slip.Trigger, slot, null);
                SwapToOneSideEffect perform = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                perform._swapRight = swapRight;
                perform.PerformEffect(stats, unit, slot.TargetSlotInformation.SelfArray(), true, 1, out int exitAmount);
            }
            yield return null;
        }
    }
    public class ApplySlipSlotEffect : FieldEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Field = Slip.Object;
            if (Slip.Object == null || Slip.Object.Equals(null)) Debug.LogError("CALL \"Slip.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
