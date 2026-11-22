using BrutalAPI;
using SaltEnemies_Reseasoned;
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
            Add_Hard();
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.NeverMind.Med, "Salt_NeverMindEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NeverMindSong";
            med.RoarEvent = "event:/Hawthorne/Surround/CNSRoar";

            med.SimpleAddEncounter(2, "NeverMind_EN");
            med.SimpleAddEncounter(1, "NeverMind_EN", 3, Enemies.Shivering);
            med.AddRandomEncounter("NeverMind_EN", Enemies.Help, Enemies.Help);
            med.AddRandomEncounter("NeverMind_EN", "OdeToHumanity_EN", "Indicator_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.NeverMind.Hard, "Salt_NeverMindEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NeverMindSong";
            med.RoarEvent = "event:/Hawthorne/Surround/CNSRoar";

            med.SimpleAddEncounter(3, "NeverMind_EN");
            med.SimpleAddEncounter(2, "NeverMind_EN", 1, Spoggle.Grey);
            med.SimpleAddEncounter(2, "NeverMind_EN", 1, Enemies.Foundling);
            med.SimpleAddEncounter(1, "NeverMind_EN", 3, "InHerImage_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {

        }
    }
}
