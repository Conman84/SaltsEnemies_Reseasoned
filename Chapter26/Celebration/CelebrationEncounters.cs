using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CelebrationEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_CelebrationEncounter_Sign", ResourceLoader.LoadSprite("CelebrationWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Celebration.Med, "Salt_CelebrationEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CelebrationTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/PumkinDie";

            med.AddRandomEncounter("Celebration_EN", "PawnA_EN", "PawnA_EN", "Celebration_EN");
            med.SimpleAddEncounter(1, "Celebration_EN", 3, Enemies.Shivering);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Celebration.Med, 8 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Celebration.Hard, "Salt_CelebrationEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/CelebrationTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/PumkinDie";

            hard.AddRandomEncounter("Celebration_EN", "InHerImage_EN", "InHerImage_EN", "Celebration_EN");
            hard.SimpleAddEncounter(3, "Celebration_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Celebration.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {

        }
    }
}
