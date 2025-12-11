using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class LunoscopeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_LunoscopeEncounter_Sign", ResourceLoader.LoadSprite("LunoscopePortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Lunoscope.Med, "Salt_LunoscopeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LunoscopePlaceholder";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("BlackStar_EN").deathSound;

            med.AddRandomEncounter("Lunoscope_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lunoscope.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {

        }
    }
}
