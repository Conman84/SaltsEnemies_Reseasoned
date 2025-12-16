using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Research
    {
        public static void Setup()
        {
            if (!SaltsReseasoned.Testing) return;

            IDetour hook1 = new Hook(typeof(UnboxOnNoEnemies_UUH).GetMethod(nameof(UnboxOnNoEnemies_UUH.CanBeUnboxed), ~BindingFlags.Default), typeof(Research).GetMethod(nameof(UnboxOnNoEnemies_UUH_CanUnbox), ~BindingFlags.Default));

        }

        public static bool UnboxOnNoEnemies_UUH_CanUnbox(Func<UnboxOnNoEnemies_UUH, CombatStats, BoxedUnit, object, bool> orig, UnboxOnNoEnemies_UUH self, CombatStats stats, BoxedUnit unit, object senderData)
        {
            foreach (TriggerCalls call in self.UnboxConditions) Debug.Log(call);
            return orig(self, stats, unit, senderData);
        }
    }
}
