using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MechanicalAngelEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_MechanicalAngelEncounter_Sign", ResourceLoader.LoadSprite("MechanismPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Abyss.H.Mechanism.Med, "Salt_MechanicalAngelEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/MechanicalAngelTheme";
            med.RoarEvent = "event:/Hawthorne/Sound5/MechanismRoar";

            med.AddRandomEncounter("MechanicalAngel_EN", "AbandonedPuppet_EN", "AbandonedPuppet_EN");
            med.AddRandomEncounter("MechanicalAngel_EN", "EyePalm_EN", "EyePalm_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Abyss.H.Mechanism.Med, 8, "TheAbyss_Zone3", BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Abyss.H.Mechanism.Hard, "Salt_MechanicalAngelEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/MechanicalAngelTheme";
            hard.RoarEvent = "event:/Hawthorne/Sound5/MechanismRoar";

            hard.AddRandomEncounter("MechanicalAngel_EN", "AbandonedPuppet_EN", "AbandonedPuppet_EN", "Nine_EN");
            hard.AddRandomEncounter("MechanicalAngel_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Abyss.H.Mechanism.Hard, 8, "TheAbyss_Zone3", BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Abyss.H.Hand.Hard);
            hard.AddRandomGroup("HandOfGod_EN", "MechanicalAngel_EN");
        }
    }
}
