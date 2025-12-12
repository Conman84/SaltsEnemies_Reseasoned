using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Blacklister
    {
        public static bool Randoming => Gatekeeper.Randoming;
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(EnemyEncounterSelectorSO).GetMethod(nameof(EnemyEncounterSelectorSO.GetEnemyBundle), ~BindingFlags.Default), typeof(Blacklister).GetMethod(nameof(EnemyEncounterSelectorSO_GetEnemyBundle), ~BindingFlags.Default));

        }
        public static EnemyCombatBundle EnemyEncounterSelectorSO_GetEnemyBundle(Func<EnemyEncounterSelectorSO, EnemyCombatBundle> orig, EnemyEncounterSelectorSO self)
        {
            EnemyCombatBundle ret = orig(self);

            for (int i = 0; i < 9999; i++)
            {
                bool safe = true;

                foreach (EnemyBundleData enemyData in ret.Enemies)
                {
                    if (!AllowEnemy(enemyData.enemy.name))
                    {
                        if (SaltsReseasoned.Testing) Debug.LogWarning("SECOND blocking enemy for second checking: " + enemyData.enemy.name);
                        ret = orig(self);
                        safe = false;
                        break;
                    }
                }

                if (safe)
                {
                    return ret;
                }
            }

            if (SaltsReseasoned.Testing) Debug.LogError("failed sub-gatekeeper blocking i think.");

            return ret;
        }


        public static bool AllowEnemy(string enemy)
        {
            if (enemy == "Untitled_EN") return false;

            if (enemy == "ReverseFalseHydra_EN") return false;

            return true;
        }
    }
}
