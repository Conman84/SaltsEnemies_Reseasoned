using BepInEx.Configuration;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace SaltsEnemies_Reseasoned
{
    public static class Gatekeeper
    {
        public static string Gatekeeps => "SaltEnemies_RunTracker";
        public static int StoredRuns;

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(Gatekeeper).GetMethod(nameof(MainMenuController_OnEmbarkPressed), ~BindingFlags.Default));
            IDetour hook1 = new Hook(typeof(EnemyEncounterSelectorSO).GetMethod(nameof(EnemyEncounterSelectorSO.GetEnemyBundle), ~BindingFlags.Default), typeof(Gatekeeper).GetMethod(nameof(EnemyEncounterSelectorSO_GetEnemyBundle), ~BindingFlags.Default));
        }
        public static void MainMenuController_OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
        {
            StoredRuns = LoadedDBsHandler.InfoHolder.Game.GetIntData(Gatekeeps);
            StoredRuns++;
            LoadedDBsHandler.InfoHolder.Game.SetIntData(Gatekeeps, StoredRuns);

            orig(self);
        }

        public static bool AllowEnemy(string enemy)
        {
            return true;
        }

        public static EnemyCombatBundle EnemyEncounterSelectorSO_GetEnemyBundle(Func<EnemyEncounterSelectorSO, EnemyCombatBundle> orig, EnemyEncounterSelectorSO self)
        {
            EnemyCombatBundle ret = orig(self);

            for (int i = 0; i < 999; i++)
            {
                foreach (EnemyBundleData enemyData in ret.Enemies)
                {
                    if (!AllowEnemy(enemyData.enemy.name))
                    {
                        ret = orig(self);
                        break;
                    }
                }

                return ret;
            }

            return ret;
        }
    }
}
