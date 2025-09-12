using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CrowChildEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_CrowChildEncounter_Sign", ResourceLoader.LoadSprite("CrowChildWorld.png"), Portals.BossIDColor);

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone01_CrowChild_EnemyBundle", "Salt_CrowChildEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/CrowChildSong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            boss.BossID = "CrowChild_BOSS";

            boss.CreateNewEnemyEncounterData(["CrowChild_BOSS"], [2]);

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone01_CrowChild_EnemyBundle", 999, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Boss);
        }
    }
}
