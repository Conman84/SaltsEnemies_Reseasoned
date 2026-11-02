using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EclipseEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_EclipseEncounter_Sign", ResourceLoader.LoadSprite("RisingWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Eclipse.Med, "Salt_EclipseEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EclipseTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/KnightRoar";

            med.AddRandomEncounter("EclipseRising_EN", "InHisImage_EN", "InHisImage_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Eclipse.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Eclipse.Hard, "Salt_EclipseEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/EclipseTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/KnightRoar";

            hard.AddRandomEncounter("EclipseRising_EN", "EclipseRising_EN", Enemies.Minister);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Eclipse.Hard, 10 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {

        }
    }
}
