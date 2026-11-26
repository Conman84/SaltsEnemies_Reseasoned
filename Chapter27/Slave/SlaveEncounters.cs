using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SlaveEncounters
    {
        public static void Add()
        {
            Add_Med();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_SlaveEncounter_Sign", ResourceLoader.LoadSprite("SlaveWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Med, "Salt_SlaveEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SlaveTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            med.SimpleAddEncounter(3, "Slave_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Eclipse);
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Celebration_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Indicator_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Slave.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {

        }
    }
}
