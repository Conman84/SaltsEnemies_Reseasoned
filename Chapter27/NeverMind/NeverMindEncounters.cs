using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NeverMindEncounters
    {
        public static void Add()
        {
            Add_Med();
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.NeverMind.Med, "Salt_NeverMindEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NeverMindSong";
            med.RoarEvent = "event:/Hawthorne/Surround/CNSRoar";

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.NeverMind.Hard, "Salt_NeverMindEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NeverMindSong";
            med.RoarEvent = "event:/Hawthorne/Surround/CNSRoar";

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Hard, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
