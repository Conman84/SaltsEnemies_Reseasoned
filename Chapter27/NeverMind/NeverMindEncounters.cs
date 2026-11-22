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
            med.SimpleAddEncounter(1, "NeverMind_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("NeverMind_EN", Enemies.Help, Enemies.Help);
            med.AddRandomEncounter("NeverMind_EN", "OdeToHumanity_EN", "Indicator_EN");
            med.SimpleAddEncounter(1, "NeverMind_EN", 3, "PawnA_EN");
            med.AddRandomEncounter("NeverMind_EN", Flower.Red, Flower.Blue);
            med.SimpleAddEncounter(1, "NeverMind_EN", 2, "Panopticon_EN");
            med.AddRandomEncounter("NeverMind_EN", "ChoirBoy_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("NeverMind_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("NeverMind_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "NeverMind_EN", 1, Enemies.Shivering);
            med.AddRandomEncounter("NeverMind_EN", Spoggle.Grey, "PawnA_EN", "PawnA_EN");
            med.AddRandomEncounter("NeverMind_EN", Jumble.Gray, Enemies.Minister);
            med.SimpleAddEncounter(1, "NeverMind_EN", 2, Enemies.Camera);
            med.AddRandomEncounter("NeverMind_EN", "Grandfather_EN", Enemies.Shivering);
            med.AddRandomEncounter("NeverMind_EN", "MiniReaper_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("NeverMind_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("NeverMind_EN", "EyePalm_EN", "EyePalm_EN", "BlackStar_EN");
            med.AddRandomEncounter("NeverMind_EN", "Shua_EN", "EyePalm_EN");
            med.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", "Damocles_EN");
            med.AddRandomEncounter("NeverMind_EN", "Hunter_EN", "Damocles_EN");
            med.AddRandomEncounter("NeverMind_EN", "Firebird_EN", "Damocles_EN");
            med.AddRandomEncounter("NeverMind_EN", "Indicator_EN", Flower.Blue);
            med.AddRandomEncounter("NeverMind_EN", "YNL_EN", Ecstasy.Gray);
            med.SimpleAddEncounter(1, "NeverMind_EN", 2, Ecstasy.Gray);
            med.AddRandomEncounter("NeverMind_EN", Bots.Grey, Ecstasy.Gray);
            med.AddRandomEncounter("NeverMind_EN", Bots.Gray, "YNL_EN");
            med.SimpleAddEncounter(1, "NeverMind_EN", 2, "EvilDog_EN");
            med.AddRandomEncounter("NeverMind_EN", "OdeToHumanity_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.NeverMind.Hard, "Salt_NeverMindEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/NeverMindSong";
            hard.RoarEvent = "event:/Hawthorne/Surround/CNSRoar";

            hard.SimpleAddEncounter(3, "NeverMind_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, Spoggle.Grey);
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, Enemies.Foundling);
            hard.SimpleAddEncounter(1, "NeverMind_EN", 3, "InHerImage_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, "ChoirBoy_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, Enemies.Minister);
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, "Starless_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, "OdeToHumanity_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, Flower.Grey);
            hard.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", Jumble.Gray);
            hard.SimpleAddEncounter(2, "NeverMind_EN", 2, "EyePalm_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 2, "Panopticon_EN");
            hard.SimpleAddEncounter(1, "NeverMind_EN", 3, "Panopticon_EN");
            hard.SimpleAddEncounter(1, "NeverMind_EN", 3, "InHerImage_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {

        }
    }
}
