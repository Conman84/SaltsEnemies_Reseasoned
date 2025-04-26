using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class AttackSlotsErrorHook
    {
        public static void selectThisMove(Action<AttackListLayout, int, bool> orig, AttackListLayout self, int attackID, bool playSound)
        {
            if (self.CurrentAttackSelected >= self._attackSlots.Length)
            {
                Debug.Log("ITS FUCKED");
                return;
            }
            if (attackID >= self._attackSlots.Length)
            {
                Debug.Log("ITS FUCKED");
                return;
            }
            orig(self, attackID, playSound);
        }
        public static void Setup()
        {
            IDetour HOOKAAA = (IDetour)new Hook((MethodBase)typeof(AttackListLayout).GetMethod(nameof(AttackListLayout.SelectAttack), ~BindingFlags.Default), typeof(AttackSlotsErrorHook).GetMethod(nameof(selectThisMove), ~BindingFlags.Default));
        }
    }
    public static class MainMenuException
    {
        public static List<Action> Actions;
        public static void OnMainMenu(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            orig(self);
            if (Actions != null)
            {
                foreach (Action action in Actions)
                {
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("MainMenuExceptionHook Action falure");
                        Debug.LogError(e.ToString());
                    }
                }
            }
        }
        public static void Setup()
        {
            IDetour addMainMenuExceptionIDetour = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OnMainMenuPressed), ~BindingFlags.Default), typeof(MainMenuException).GetMethod(nameof(OnMainMenu), ~BindingFlags.Default));
        }
        public static void AddAction(Action action)
        {
            if (Actions == null) Actions = new List<Action>();
            Actions.Add(action);
        }
    }
    public static class NotificationHook
    {
        public static List<Action<string, object, object>> BeforeActions;
        public static List<Action<string, object, object>> AfterActions;
        public static void AddAction(Action<string, object, object> action, bool before = false)
        {
            if (BeforeActions == null) BeforeActions = new List<Action<string, object, object>>();
            if (AfterActions == null) AfterActions = new List<Action<string, object, object>>();
            if (before) BeforeActions.Add(action);
            else AfterActions.Add(action);
        }
        public static void PostNotification(Action<CombatManager, string, object, object> orig, CombatManager self, string notificationName, object sender, object args)
        {
            if (BeforeActions != null) foreach (Action<string, object, object> action in BeforeActions) action(notificationName, sender, args);
            orig(self, notificationName, sender, args);
            if (AfterActions != null) foreach (Action<string, object, object> action in AfterActions) action(notificationName, sender, args);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.PostNotification), ~BindingFlags.Default), typeof(NotificationHook).GetMethod(nameof(PostNotification), ~BindingFlags.Default));
        }
    }
}
