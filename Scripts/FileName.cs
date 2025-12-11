using UnityEngine;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using System.Collections;
using System;
using MonoMod.RuntimeDetour;

namespace SaltsEnemies_Reseasoned
{
    public static class Legacy
    {
        public static bool OnlyMod => Chainloader.PluginInfos.Count <= 2;
        public static string Solo => "SaltEnemies_Soloist";
        public static bool Check
        {
            get
            {
                return LoadedDBsHandler.InfoHolder.Game.GetBoolData(Solo);
            }
        }
        public static IEnumerator CombatManager_ProcessSpecialSceneEnd(Func<CombatManager, string, IEnumerator> orig, CombatManager self, string scene)
        {
            if (OnlyMod && scene == SpecialSceneType.HardEnding.ToString())
            {
                if (SaltsReseasoned.Testing) Debug.Log("completed salt enemies soloist special quest");
                LoadedDBsHandler.InfoHolder.Game.SetBoolData(Solo, true);
            }

            return orig(self, scene);
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.ProcessSpecialSceneEnd), ~BindingFlags.Default), typeof(Legacy).GetMethod(nameof(CombatManager_ProcessSpecialSceneEnd), ~BindingFlags.Default));
        }
    }
}
