using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MidnightTrafficLightEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_MidnightTrafficLightEncounter_Sign", ResourceLoader.LoadSprite("TrainWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Stoplight.Med, "Salt_MidnightTrafficLightEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewTrainSong";
            med.RoarEvent = "event:/Hawthorne/Noise/TrainRoar";

            med.SimpleAddEncounter(1, "Stoplight_EN", 4, "NextOfKin_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 2, "InHerImage_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 2, "InHisImage_EN");
            med.AddRandomEncounter("Stoplight_EN", "ChoirBoy_EN", "Indicator_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, "Stoplight_EN", 2, Enemies.Minister);
            med.SimpleAddEncounter(1, "Stoplight_EN", 3, "LittleAngel_EN");
            med.AddRandomEncounter("Stoplight_EN", Jumble.Grey, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("Stoplight_EN", Spoggle.Grey, Enemies.Shivering, Enemies.Shivering);
            med.SimpleAddEncounter(1, "Stoplight_EN", 3, Enemies.Camera);
            med.AddRandomEncounter("Stoplight_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Stoplight_EN", Flower.Grey, "LittleAngel_EN");
            med.AddRandomEncounter("Stoplight_EN", "WindSong_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 1, "Grandfather_EN", 3, "NextOfKin_EN");
            med.AddRandomEncounter("Stoplight_EN", "MiniReaper_EN", "MiniReaper_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Stoplight_EN", "Skyloft_EN", "ChoirBoy_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 3, "Damocles_EN");
            med.AddRandomEncounter("Stoplight_EN", "Shua_EN", "EyePalm_EN");
            med.AddRandomEncounter("Stoplight_EN", "GlassFigurine_EN", Enemies.Minister);
            med.AddRandomEncounter("Stoplight_EN", "Hunter_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Stoplight_EN", "Firebird_EN", "BlackStar_EN", "BlackStar_EN");
            med.SimpleAddEncounter(1, "Stoplight_EN", 3, "BlackStar_EN");
            med.AddRandomEncounter("Stoplight_EN", "Indicator_EN", Enemies.Minister);
            med.AddRandomEncounter("Stoplight_EN", "YNL_EN", "WindSong_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Stoplight.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Stoplight.Hard, "Salt_MidnightTrafficLightEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/NewTrainSong";
            hard.RoarEvent = "event:/Hawthorne/Noise/TrainRoar";

            hard.SimpleAddEncounter(1, "Stoplight_EN", 4, Enemies.Shivering);
            hard.AddRandomEncounter("Stoplight_EN", "InHerImage_EN", "InHerImage_EN", "NextOfKin_EN");
            hard.SimpleAddEncounter(1, "Stoplight_EN", 3, "InHisImage_EN");
            hard.SimpleAddEncounter(1, "Stoplight_EN", 2, "ChoirBoy_EN");
            hard.AddRandomEncounter("Stoplight_EN", Enemies.Minister, Enemies.Minister);
            hard.AddRandomEncounter("Stoplight_EN", Enemies.Minister, "LittleAngel_EN", "WindSong_EN");
            hard.AddRandomEncounter("Stoplight_EN", Jumble.Grey, Enemies.Minister, "ClockTower_EN");
            hard.AddRandomEncounter("Stoplight_EN", "ClockTower_EN", "WindSong_EN", "NextOfKin_EN", "NextOfKin_EN");
            hard.AddRandomEncounter("Stoplight_EN", "InHerImage_EN", "InHerImage_EN", "MiniReaper_EN");
            hard.AddRandomEncounter("Stoplight_EN", "InHerImage_EN", "InHisImage_EN", Flower.Blue);
            hard.AddRandomEncounter("Stoplight_EN", "InHisImage_EN", "InHisImage_EN", Flower.Grey);
            hard.AddRandomEncounter("Stoplight_EN", "Grandfather_EN", "WindSong_EN", "Shua_EN");
            hard.AddRandomEncounter("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", "MiniReaper_EN");
            hard.AddRandomEncounter("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", "ClockTower_EN");
            hard.AddRandomEncounter("Stoplight_EN", "Merced_EN", "Skyloft_EN", "Damocles_EN", "GlassFigurine_EN");
            hard.AddRandomEncounter("Stoplight_EN", "Hunter_EN", "InHisImage_EN", "InHerImage_EN");
            hard.AddRandomEncounter("Stoplight_EN", "ClockTower_EN", "Firebird_EN", "Firebird_EN");
            hard.AddRandomEncounter("Stoplight_EN", "ClockTower_EN", Enemies.Minister, Enemies.Minister);
            hard.AddRandomEncounter("Stoplight_EN", "WindSong_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Stoplight_EN", "Indicator_EN", Enemies.Minister, "BlackStar_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Stoplight.Hard, 10 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Stoplight_EN", "Damocles_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Stoplight_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Satyr_EN", "Stoplight_EN", Enemies.Minister);
            hard.AddRandomGroup("Satyr_EN", "Stoplight_EN", Enemies.Skinning);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "Stoplight_EN", "Skyloft_EN", "Skyloft_EN", "Skyloft_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Stoplight_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Stoplight_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Stoplight_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", "WindSong_EN");
        }
    }
}
