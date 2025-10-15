using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlackAndBlueEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_BlackAndBlueEncounter_Sign", ResourceLoader.LoadSprite("WarCriminalWorld.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/BB_Arena.prefab", "BlackAndBlue_Arena", SaltsReseasoned.Dreams);
            LoadedAssetsHandler.TryGetCombatEnvironmentPrefab("BlackAndBlue_Arena").gameObject.SetMinesMaterial();

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone01_BlackAndBlue_EnemyBundle", "Salt_BlackAndBlueEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/BlackAndBlueSong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            boss.BossID = "BlackAndBlue_BOSS";
            boss.AddSpecialEnvironment("BlackAndBlue_Arena");

            boss.CreateNewEnemyEncounterData(["BlackAndBlue_BOSS"], [2]);

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone01_BlackAndBlue_EnemyBundle", 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Boss);
        }
        public static void SetMinesMaterial(this GameObject self)
        {
            Transform holder = self.transform.Find("Mines");

            Material use = BlueSkyEncounters.GettingTheShader();

            for (int i = 0; i < 8; i++)
            {
                holder.GetChild(i).GetComponent<SpriteRenderer>().material = use;
            }
        }
    }
}
