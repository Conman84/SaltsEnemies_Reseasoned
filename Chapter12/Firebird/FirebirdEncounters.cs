using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class FirebirdEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_FirebirdEncounter_Sign", ResourceLoader.LoadSprite("FirebirdWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Firebird.Med, "Salt_FirebirdEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewCoffinTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Firebird.Med, 6, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
