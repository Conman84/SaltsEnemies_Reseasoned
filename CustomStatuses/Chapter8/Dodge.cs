using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

//call Dodge.Add() in awake

namespace SaltEnemies_Reseasoned
{
    public static class Dodge
    {
        public static string Call => "Dodge_OnTargetted_SaltEnemies";
        static string NoteForThoseWhoDecompile = "If you want to copy and paste the dodge code to your mod, i recommend changing some part of the trigger call name so it doesnt end up triggering dodge twice with multiple mods";
        public static string StatusID => "Dodge_ID";
        public static string Intent => "Status_Dodge";
        public static DodgeSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO DodgeInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            DodgeInfo.icon = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Dodge.Add. put the right sprite here");
            DodgeInfo._statusName = "Dodge";
            DodgeInfo._description = "Get the description";
            Debug.LogError("Dodge.Add. get the status description");
            DodgeInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            DodgeInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            DodgeInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            DodgeSE_SO DodgeSO = ScriptableObject.CreateInstance<DodgeSE_SO>();
            DodgeSO._StatusID = StatusID;
            DodgeSO._EffectInfo = DodgeInfo;
            Object = DodgeSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = DodgeSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(DodgeSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Dodge.Add. set the right sprite for the intent also");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);

            DodgeHandler.Setup();
        }
    }
    public static class DodgeHandler
    {
        public static SwapToSidesEffect swap = ScriptableObject.CreateInstance<SwapToSidesEffect>();
        public static void SwapUnitToSides(TargetSlotInfo slot, IUnit unit)
        {
            swap.PerformEffect(CombatManager.Instance._stats, unit, new TargetSlotInfo[] { slot }, true, 1, out var exit);
        }
        public static int StartEffect(Func<EffectInfo, CombatStats, IUnit, TargetSlotInfo[], bool, int, int> orig, EffectInfo self, CombatStats stats, IUnit caster, TargetSlotInfo[] possibleTargets, bool areTargetSlots, int previousExitValue)
        {
            bool allSlotsSelected = false;
            List<int> slots = new List<int>();
            foreach (TargetSlotInfo slot in possibleTargets)
            {
                if (!slots.Contains(slot.SlotID))
                    slots.Add(slot.SlotID);
            }
            if (slots.Count >= 5) allSlotsSelected = true;
            if (areTargetSlots && !allSlotsSelected)
            {
                bool redoTarget = false;
                foreach (TargetSlotInfo target in possibleTargets)
                {
                    if (target.HasUnit && target.Unit.ContainsStatusEffect(Dodge.StatusID))
                    {
                        if (target.Unit.IsUnitCharacter != caster.IsUnitCharacter)
                        {
                            CombatManager.Instance.PostNotification(Dodge.Call.ToString(), target.Unit, null);
                            SwapUnitToSides(target, target.Unit);
                            redoTarget = true;
                        }
                    }
                }
                if (redoTarget)
                {
                    possibleTargets = ((self.targets != null) ? self.targets.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter) : new TargetSlotInfo[0]);
                    areTargetSlots = !(self.targets != null) || self.targets.AreTargetSlots;
                }
            }
            return orig(self, stats, caster, possibleTargets, areTargetSlots, previousExitValue);
        }
        public static void Setup()
        {
            IDetour dodgeHook = new Hook(typeof(EffectInfo).GetMethod(nameof(EffectInfo.StartEffect), ~BindingFlags.Default), typeof(Dodge).GetMethod(nameof(StartEffect), ~BindingFlags.Default));
        }
    }
    public class DodgeSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, Dodge.Call, caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, Dodge.Call, caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class ApplyDodgeEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Dodge.Object;
            if (Dodge.Object == null || Dodge.Object.Equals(null)) Dodge.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
