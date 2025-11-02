using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EcstasyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_EcstasyEncounter_Sign", ResourceLoader.LoadSprite("EcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Tortoise.Hard, "Salt_EcstasyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Foxtrot_EN").deathSound;

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Grandfather.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
