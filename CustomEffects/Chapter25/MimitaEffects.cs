using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class ToysPool
    {
        public static SpawnRandomEnemyAnywhereEffect Effect;
        public static string ID => "SaltEnemies_ToysPool";
        public static void Add()
        {
            Effect = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
            Effect._spawnTypeID = "Basic";
            Effect._enemies = [
                LoadedAssetsHandler.GetEnemy("Chordophone_EN"),
                LoadedAssetsHandler.GetEnemy("Psaltery_EN"),
                LoadedAssetsHandler.GetEnemy("Woodwind_EN"),
                LoadedAssetsHandler.GetEnemy("TaintedYolk_EN"),
                ];

            LoadedDBsHandler.EnemyDB.m_SpawnRandomListPools.Add(ID, Effect);
        }
    }
}
