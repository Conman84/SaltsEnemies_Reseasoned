using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//call Haste.Add() in awake

namespace SaltEnemies_Reseasoned
{
    public static class Haste
    {
        public static string StatusID => "Haste_ID";
        public static string Intent => "Status_Haste";
        public static HasteSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO HasteInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            HasteInfo.icon = ResourceLoader.LoadSprite("Haste.png");
            HasteInfo._statusName = "Haste";
            HasteInfo._description = "This unit can perform an extra action each round. Decreases by 1 at the start of each round.";
            HasteInfo._applied_SE_Event = "event:/Hawthorne/Misc/Haste";
            HasteInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            HasteInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            HasteSE_SO HasteSO = ScriptableObject.CreateInstance<HasteSE_SO>();
            HasteSO._StatusID = StatusID;
            HasteSO._EffectInfo = HasteInfo;
            Object = HasteSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = HasteSO;
            if (!LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(HasteSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Haste.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            if (!LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);

            Setup();
            AddValue();
        }
        public static string Trigger => "SaltEnemies_Haste_Trigger";
        public static void CombatStats_TurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                enemy.TriggerNotification(Trigger, null);
            }
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~System.Reflection.BindingFlags.Default), typeof(Haste).GetMethod(nameof(CombatStats_TurnStart), ~System.Reflection.BindingFlags.Default));
        }


        public static string Refresh => "SaltEnemies_Haste_Refresh";
        public static void AddValue()
        {
            UnitStoreData.CreateAndAdd_IntTooltip_UnitStoreDataToPool(Refresh, "Haste +{0}", Misc.GetInGame_UITextColor(Misc.UITextColorIDs.Positive));
            NotificationHook.AddAction(RefreshHook);
            NotificationHook.AddAction(RemoveHook);
        }
        public static void RefreshHook(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnAbilityUsed.ToString() && sender is IUnit chara && chara.SimpleGetStoredValue(Refresh) > 0)
            {
                if (chara.RefreshAbilityUse())
                    chara.SimpleSetStoredValue(Refresh, chara.SimpleGetStoredValue(Refresh) - 1);
            }
        }
        public static void RemoveHook(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnTurnFinished.ToString() && sender is IUnit unit)
            {
                unit.SimpleSetStoredValue(Refresh, 0);
            }
        }
    }
    public class HasteSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter)
            {
                CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnStart.ToString(), caller);
            }
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_03, Haste.Trigger, caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.AttacksPerTurn.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter)
            {
                CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnStart.ToString(), caller);
            }
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_03, Haste.Trigger, caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.AttacksPerTurn.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                unit.SimpleSetStoredValue(Haste.Refresh, unit.SimpleGetStoredValue(Haste.Refresh) + 1);
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is IntegerReference integerReference)
                integerReference.value += 1;
        }
        public override void OnEventCall_03(StatusEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder, sender as IStatusEffector);
        }
        public override void ReduceDuration(StatusEffect_Holder holder, IStatusEffector effector)
        {
            if (CanReduceDuration || effector.IsStatusEffectorCharacter)
            {
                int contentMain = holder.m_ContentMain;
                holder.m_ContentMain = Mathf.Max(0, contentMain - 1);
                if (!TryRemoveStatusEffect(holder, effector) && contentMain != holder.m_ContentMain)
                {
                    effector.StatusEffectValuesChanged(_StatusID, holder.m_ContentMain - contentMain, doesPopUp: true);
                }
            }
        }
    }
    public class ApplyHasteEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Haste.Object;
            if (Haste.Object == null || Haste.Object.Equals(null)) Haste.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
