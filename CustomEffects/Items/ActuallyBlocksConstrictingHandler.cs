using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Reflection;

namespace SaltsEnemies_Reseasoned
{
    public static class ActuallyBlocksConstrictingHandler
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(ConstrictedConnectedAction).GetMethod(nameof(ConstrictedConnectedAction.Execute), ~BindingFlags.Default), typeof(ActuallyBlocksConstrictingHandler).GetMethod(nameof(ConstrictedConnectedAction_Execute), ~BindingFlags.Default));
        }
        public static IEnumerator ConstrictedConnectedAction_Execute(Func<ConstrictedConnectedAction, CombatStats, IEnumerator> orig, ConstrictedConnectedAction self, CombatStats stats)
        {
            if (!stats.IsPassiveLocked(Passives.Constricting.m_PassiveID))
            {
                yield return orig(self, stats);
            }
            else yield break;
        }
    }
}
