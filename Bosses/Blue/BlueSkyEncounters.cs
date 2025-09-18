using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueSkyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_BlueSkyEncounter_Sign", ResourceLoader.LoadSprite("MikuWorld.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/BlueSky_Arena.prefab", "BlueSky_Arena", SaltsReseasoned.Dreams);
            LoadedAssetsHandler.TryGetCombatEnvironmentPrefab("BlueSky_Arena").gameObject.SetGrassMaterial();

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone03_BlueSky_EnemyBundle", "Salt_BlueSkyEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/BlueSkySong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            boss.BossID = "BlueSky_BOSS";
            boss.SpecialEnvironmentID = "BlueSky_Arena";
            boss.UsesSpecialEnvironment = true;

            boss.CreateNewEnemyEncounterData(["BlueSky_BOSS"], [2]);

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone03_BlueSky_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Boss);
        }
        public static void SetGrassMaterial(this GameObject self)
        {
            Transform holder = self.transform.Find("Grass");

            Material use = GettingTheShader();

            for (int i = 0; i < 193; i++)
            {
                holder.GetChild(i).GetComponent<SpriteRenderer>().material = use;
            }
        }
        public static Material GettingTheShader()
        {
            return LoadedAssetsHandler.TryGetCombatEnvironmentPrefab(LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01").CombatEnvironment)._propPrefabs[4].transform.Find("PropLocations").Find("SmallProps").GetChild(0).GetComponent<SpriteRenderer>().material;
        }
    }
}
