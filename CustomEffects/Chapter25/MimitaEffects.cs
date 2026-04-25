using BrutalAPI;
using SaltEnemies_Reseasoned;
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
            Effect._spawnTypeID = "Spawn_Basic";
            Effect._enemies = [
                LoadedAssetsHandler.GetEnemy("Chordophone_EN"),
                LoadedAssetsHandler.GetEnemy("Psaltery_EN"),
                LoadedAssetsHandler.GetEnemy("Woodwind_EN"),
                LoadedAssetsHandler.GetEnemy("TaintedYolk_EN"),
                ];

            LoadedDBsHandler.EnemyDB.m_SpawnRandomListPools.Add(ID, Effect);
        }

        public static void Post()
        {
            if (Check.EnemyExist("Surrogate_EN")) LoadedAssetsHandler.GetEnemy("Surrogate_EN").AddToToysPool();
        }
    }

    public class FitSizeCondition : EffectConditionSO
    {
        public int Size;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.IsUnitCharacter) return CombatManager.Instance._stats.CharactersOnField.Count <= 4;

            int temp = 0;
            for (int i = 0; i < CombatManager.Instance._stats.combatSlots.EnemySlots.Length; i++)
            {
                if (CombatManager.Instance._stats.combatSlots.EnemySlots[i].HasUnit) temp = 0;
                else temp++;

                if (temp >= Size) return true;
            }
            return false;
        }

        public static FitSizeCondition Create(int size)
        {
            FitSizeCondition ret = ScriptableObject.CreateInstance<FitSizeCondition>();
            ret.Size = size;
            return ret;
        }
    }
}
