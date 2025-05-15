using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TurnStarter
    {
        public static void Setup()
        {
            IDetour idetour6 = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(TurnStarter).GetMethod(nameof(InitializeCombat), ~BindingFlags.Default));
            IDetour idetour7 = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(TurnStarter).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour idetour8 = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(TurnStarter).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
        }
        public static void AddInitialize(Action add)
        {
            if (CombatStart == null) CombatStart = new List<Action>();
            CombatStart.Add(add);
        }
        public static void AddAction(Action add, bool start)
        {
            if (PlayerStart == null) PlayerStart = new List<Action>();
            if (PlayerEnd == null) PlayerEnd = new List<Action>();
            if (start) PlayerStart.Add(add);
            else PlayerEnd.Add(add);
        }

        public static List<Action> CombatStart;
        public static List<Action> PlayerStart;
        public static List<Action> PlayerEnd;

        public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            if (CombatStart != null) foreach (Action act in CombatStart) SaltsReseasoned.PCall(act);
        }
        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            if (PlayerStart != null) foreach (Action act in PlayerStart) SaltsReseasoned.PCall(act);
        }
        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            if (PlayerEnd != null) foreach (Action act in PlayerEnd) SaltsReseasoned.PCall(act);
        }
    }
}
