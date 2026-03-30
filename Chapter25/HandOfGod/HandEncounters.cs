using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HandEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_HandOfGodEncounter_Sign", ResourceLoader.LoadSprite("HandOfGodWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Abyss.H.Hand.Med, "Salt_HandOfGodEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/HauntlingSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.AddRandomEncounter("HandOfGod_EN", "AbandonedPuppet_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Abyss.H.Hand.Med, 8, "TheAbyss_Zone3", BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Abyss.H.Hand.Hard, "Salt_HandOfGodEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/HauntlingSong";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            hard.AddRandomEncounter("HandOfGod_EN", "AbandonedPuppet_EN", "AbandonedPuppet_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Abyss.H.Hand.Hard, 8, "TheAbyss_Zone3", BundleDifficulty.Hard);
        }
        public static void Post()
        {

        }
    }
}
