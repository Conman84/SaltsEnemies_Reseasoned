using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueSkyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_BlueSkyEncounter_Sign", ResourceLoader.LoadSprite("MikuWorld.png"), Portals.BossIDColor);

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone03_BlueSky_EnemyBundle", "Salt_BlueSkyEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/BlueSkySong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            boss.BossID = "BlueSky_BOSS";

            boss.CreateNewEnemyEncounterData(["BlueSky_BOSS"], [2]);

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone03_BlueSky_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Boss);
        }
    }
}
