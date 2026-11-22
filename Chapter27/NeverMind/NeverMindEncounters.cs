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
            med.AddRandomEncounter("NeverMind_EN", "Complimentary_EN");
            med.AddRandomEncounter("NeverMind_EN", "Starless_EN", "MiniReaper_EN");
            med.AddRandomEncounter("NeverMind_EN", "Yang_EN", "PawnA_EN");
            med.SimpleAddEncounter(1, "NeverMind_EN", 2, "PawnA_EN");
            med.AddRandomEncounter("NeverMind_EN", "Insider_EN", "Insider_EN");
            med.AddRandomEncounter("NeverMind_EN", "CorpseChan_EN", "BlackStar_EN");
            med.AddRandomEncounter("NeverMind_EN", "Lunoscope_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("NeverMind_EN", "Panopticon_EN", "Panopticon_EN");
            med.AddRandomEncounter("NeverMind_EN", Enemies.Eclipse, "Merced_EN");
            med.AddRandomEncounter("NeverMind_EN", Enemies.Eclipse, "Skyloft_EN");
            med.AddRandomEncounter("NeverMind_EN", "Celebration_EN", "PawnA_EN");
            med.AddRandomEncounter("NeverMind_EN", "Lightbulbkin_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("NeverMind_EN", Enemies.Troller, Enemies.Troller);
            med.AddRandomEncounter("NeverMind_EN", "PawnA_EN", "PawnA_EN", "Vivarium_EN");

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
            hard.SimpleAddEncounter(1, "NeverMind_EN", 3, Enemies.Camera);
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, "WindSong_EN");
            hard.AddRandomEncounter("NeverMind_EN", "Grandfather_EN", "OdeToHumanity_EN");
            hard.SimpleAddEncounter(1, "NeverMind_EN", 3, "PawnA_EN");
            hard.AddRandomEncounter("NeverMind_EN", "Yang_EN", "Yang_EN");
            hard.AddRandomEncounter("NeverMind_EN", "Yang_EN", "Yang_EN", "PawnA_EN");
            hard.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomEncounter("NeverMind_EN", Enemies.Troller, Enemies.Troller, Enemies.Troller);
            hard.AddRandomEncounter("NeverMind_EN", Bots.Gray, "CorpseChan_EN");
            hard.AddRandomEncounter("NeverMind_EN", "Celebration_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomEncounter("NeverMind_EN", "Celebration_EN", Enemies.Troller, Enemies.Troller);
            hard.AddRandomEncounter("NeverMind_EN", Enemies.Eclipse, Enemies.Eclipse);
            hard.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", "Shua_EN");
            hard.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", "Hunter_EN");
            hard.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", "OdeToHumanity_EN", "Vivarium_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, "Lunoscope_EN", 1, "Vivarium_EN");
            hard.SimpleAddEncounter(2, "NeverMind_EN", 1, "Starless_EN", 1, "Vivarium_EN");
            hard.AddRandomEncounter("NeverMind_EN", "NeverMind_EN", Enemies.Minister);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.NeverMind.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "NeverMind_EN", "Damocles_EN");
            med.AddRandomGroup(Enemies.Skinning, "NeverMind_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, "NeverMind_EN", "Yang_EN");
            med.AddRandomGroup(Enemies.Skinning, "NeverMind_EN", "BlackStar_EN");
            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(2, Enemies.Skinning, 1, "NeverMind_EN");
            hard.SimpleAddGroup(1, Enemies.Skinning, 2, "NeverMind_EN");
            hard.AddRandomGroup(Enemies.Skinning, "NeverMind_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomGroup(Enemies.Skinning, "NeverMind_EN", Enemies.Foundling);

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "NeverMind_EN", "ChoirBoy_EN");
            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "NeverMind_EN");
            hard.AddRandomGroup(Enemies.Minister, "NeverMind_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, "NeverMind_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Foundling, "NeverMind_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup(Enemies.Foundling, "NeverMind_EN", "MiniReaper_EN");
            med.AddRandomGroup(Enemies.Foundling, "NeverMind_EN", "OdeToHumanity_EN");
            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.SimpleAddGroup(2, Enemies.Foundling, 1, "NeverMind_EN");
            hard.SimpleAddGroup(3, Enemies.Foundling, 1, "NeverMind_EN");
            hard.AddRandomGroup(Enemies.Foundling, "NeverMind_EN", "Satyr_EN");
            hard.AddRandomGroup(Enemies.Foundling, "NeverMind_EN", "Lunoscope_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "NeverMind_EN", "LittleAngel_EN");
            med.AddRandomGroup("Satyr_EN", "NeverMind_EN", "BlackStar_EN");
            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "NeverMind_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Satyr_EN", "NeverMind_EN", "OdeToHumanity_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, "NeverMind_EN", 1, "MiniReaper_EN");
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, "NeverMind_EN", 1, "Indicator_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "NeverMind_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "NeverMind_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Miriam_EN", "NeverMind_EN", "OdeToHumanity_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "NeverMind_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "NeverMind_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "NeverMind_EN", Enemies.Foundling);
            hard.AddRandomGroup("Stoplight_EN", "NeverMind_EN", "InHerImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "NeverMind_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(1, "InTheDark_EN", 2, "NeverMind_EN");
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "NeverMind_EN");
            hard.AddRandomGroup("InTheDark_EN", "NeverMind_EN", Enemies.Eclipse);
        }
    }
}
