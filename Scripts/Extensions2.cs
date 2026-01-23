using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltEnemies_Reseasoned
{
    public static class EnemyExtensions
    {
        public static void SilentAddEnemy(this Enemy self, bool addToBronzoPool = false, bool addToSepulchrePool = false, bool addToSmallPool = false)
        {
            LoadedAssetsHandler.AddExternalEnemy(self.enemy.name, self.enemy);
            if (addToBronzoPool)
            {
                EnemyUtils.AddEnemyToSpawnPool(self.enemy, PoolList_GameIDs.Bronzo);
            }

            if (addToSepulchrePool)
            {
                EnemyUtils.AddEnemyToHealthSpawnPool(self.enemy, PoolList_GameIDs.Sepulchre);
            }

            if (addToSmallPool)
            {
                EnemyUtils.AddEnemyToSpawnPool(self.enemy, PoolList_GameIDs.SmallEnemy);
            }
        }
        public static void AddToSynodPool(this EnemySO self)
        {
            EnemySO synod = LoadedAssetsHandler.GetEnemy(Enemies.Synod);
            AbilitySO abil = synod.abilities[0].ability;
            SpawnRandomEnemyAnywhereEffect spawn = abil.effects[0].effect as SpawnRandomEnemyAnywhereEffect;
            spawn._enemies.Add(self);
        }
    }
}
