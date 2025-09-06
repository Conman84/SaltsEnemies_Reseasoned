using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TvEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_MegalaniaEncounter_Sign", ResourceLoader.LoadSprite("TemplateWorld.png"), Portals.BossIDColor);

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone02_Megalania_EnemyBundle", "Salt_MegalaniaEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/TVSong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            boss.BossID = "Megalania_BOSS";

            boss.CreateNewEnemyEncounterData(["Megalania_BOSS"], [2]);

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone02_Megalania_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);
        }
    }
}
