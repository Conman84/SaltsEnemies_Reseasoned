using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class StarlessEncounterHandler
    {
        public delegate TResult EncounterHook<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out T5 arg7);

        public static bool RandomEnemyGroup_TryGenerateBundle(EncounterHook<RandomEnemyBundleSO, int, BundleDifficulty, string, EnemyCombatBundle, bool> orig, RandomEnemyBundleSO self, int index, BundleDifficulty bundleDifficulty, string roomPrefabName, out EnemyCombatBundle combatBundle)
        {
            combatBundle = null;
            RandomEnemyGroup randomEnemyGroup = self._enemyBundles[index];
            if (randomEnemyGroup == null || randomEnemyGroup.EnemyNames == null || randomEnemyGroup.EnemyNames.Length == 0)
            {
                return false;
            }

            if (!randomEnemyGroup.EnemyNames.Contains("Starless_EN")) return orig(self, index, bundleDifficulty, roomPrefabName, out combatBundle);

            List <EnemySO> list = new List<EnemySO>();
            int num = 5;
            int num2 = 0;
            string[] enemyNames = randomEnemyGroup.EnemyNames;
            foreach (string text in enemyNames)
            {
                EnemySO enemy = LoadedAssetsHandler.GetEnemy(text);
                if (enemy == null)
                {
                    Debug.LogError(text + " is not on Resources folder");
                    continue;
                }

                if (enemy.size > num)
                {
                    break;
                }

                list.Add(enemy);
                num -= enemy.size;
                num2++;
            }

            if (num2 == 0)
            {
                return false;
            }

            if (num > 0)
            {
                for (int j = 0; j < num; j++)
                {
                    list.Add(null);
                }
            }

            EnemyBundleData[] array = new EnemyBundleData[num2];
            int num3 = 0;
            int num4 = 0;
            int quit = 0;
            while (list.Count > 0)
            {
                int index2 = UnityEngine.Random.Range(0, list.Count);

                int stars = 0;
                int first = -1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != null && list[i]._enemyName == "Starless")
                    {
                        stars++;
                        first = i;
                    }
                }
                if (stars >= list.Count - 1 && first >= 0) index2 = first;

                EnemySO enemy = list[index2];

                if (quit <= 99 && num == 0 && enemy != null && enemy._enemyName == "Starless")
                {
                    quit++;
                    continue;
                }

                list.RemoveAt(index2);
                if (enemy == null)
                {
                    num4++;
                    continue;
                }

                array[num3] = new EnemyBundleData(enemy, num4);
                num3++;
                num4 += enemy.size;
            }

            string specialEnvironment = (self._usesSpecialEnvironment ?self. _specialCombatEnvironment : "");
            string dialogueReference = (self._usesDialogueEvent ? self._preCombatDialogueEventReference : "");
            combatBundle = new EnemyCombatBundle(array, dialogueReference, self._musicEventReference, self._roarReference, self._BossID, bundleDifficulty, specialEnvironment, roomPrefabName, self.m_BundleSignID);
            return true;
        }
    
        public static void Setup()
        {
            IDetour hook7 = new Hook(typeof(RandomEnemyBundleSO).GetMethod(nameof(RandomEnemyBundleSO.TryGenerateBundle), ~BindingFlags.Default), typeof(StarlessEncounterHandler).GetMethod(nameof(RandomEnemyGroup_TryGenerateBundle), ~BindingFlags.Default));
        }
    }
}
