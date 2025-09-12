using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class InventionEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_InventionEncounter_Sign", ResourceLoader.LoadSprite("InventionWorld.png"), Portals.BossIDColor);

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Random, "BOSS_Zone02_Invention_EnemyBundle", "Salt_InventionEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/InventionSong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            boss.AddRandomEncounter("Invention_BOSS");

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone02_Invention_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);
        }
    }
}
