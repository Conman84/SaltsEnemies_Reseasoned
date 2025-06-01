using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class YangEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_YangEncounter_Sign", ResourceLoader.LoadSprite("YangWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Yang.Med, "Salt_YangEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/BishopSong";
            med.RoarEvent = "event:/Hawthorne/Noi3e/PawnRoar";

            med.SimpleAddEncounter(2, "Yang_EN");
            med.SimpleAddEncounter(1, "Yang_EN", 4, "PawnA_EN");
            med.SimpleAddEncounter(1, "Yang_EN", 2, "InHerImage_EN");
            med.SimpleAddEncounter(1, "Yang_EN", 2, "InHisImage_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, Spoggle.Grey);
            med.SimpleAddEncounter(2, "Yang_EN", 1, "BlackStar_EN");
            med.AddRandomEncounter("Yang_EN", "PawnA_EN", "Starless_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "Hunter_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 2, "EyePalm_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "MiniReaper_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, Flower.Red);
            med.SimpleAddEncounter(2, "Yang_EN", 1, Flower.Blue);
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "WindSong_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "Shua_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", Enemies.Camera, "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "Firebird_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "Damocles_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "BlackStar_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "Indicator_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "GlassFigurine_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "Grandfather_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "YNL_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "Children6_EN", "PawnA_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", Bots.Grey, "PawnA_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 3, "TortureMeNot_EN");
            med.AddRandomEncounter("Yang_EN", "Yang_EN", "EvilDog_EN", "PawnA_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "Starless_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "ChoirBoy_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, Enemies.Minister);


            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Yang.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Yang.Hard, "Salt_YangEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/BishopSong";
            hard.RoarEvent = "event:/Hawthorne/Noi3e/PawnRoar";

            hard.SimpleAddEncounter(3, "Yang_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 3, "PawnA_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 2, "InHisImage_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 2, "InHerImage_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "BlackStar_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "PawnA_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", Flower.Red, Flower.Blue);
            hard.SimpleAddEncounter(1, "Yang_EN", 1, Flower.Grey, 3, "PawnA_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", "Starless_EN", "Eyeless_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "WindSong_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", "Hunter_EN", "MiniReaper_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", "Starless_EN", "MiniReaper_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", Bots.Grey, "MiniReaper_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", "Firebird_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Yang_EN", "Yang_EN", "PawnA_EN", Enemies.Minister);
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "Grandfather_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 1, "Shua_EN", 2, "PawnA_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "MiniReaper_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "Damocles_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "GlassFigurine_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "TortureMeNot_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "Skyloft_EN");
            hard.SimpleAddEncounter(3, "Yang_EN", 1, "Indicator_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 1, "YNL_EN", 1, "Skyloft_EN");
            hard.SimpleAddEncounter(1, "Yang_EN", 1, "PersonalAngel_EN", 2, "PawnA_EN");
            hard.SimpleAddEncounter(1, "Yang_EN", 1, "Eyeless_EN", 2, "PawnA_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 1, "OdeToHumanity_EN", 1, "PawnA_EN");
            hard.SimpleAddEncounter(2, "Yang_EN", 1, "ChoirBoy_EN", 2, "PawnA_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Yang.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Yang_EN", "Yang_EN");
            med.AddRandomGroup("Satyr_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Satyr_EN", "Yang_EN", Flower.Blue);
            med.AddRandomGroup("Satyr_EN", "Yang_EN", "GlassFigurine_EN");
            med.AddRandomGroup("Satyr_EN", "Yang_EN", "Grandfather_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Yang_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Satyr_EN", "Yang_EN", Enemies.Skinning);
            hard.AddRandomGroup("Satyr_EN", "Yang_EN", "Stoplight_EN");
            med.AddRandomGroup("Satyr_EN", "Yang_EN", "Yang_EN", "MiniReaper_EN");
            med.AddRandomGroup("Satyr_EN", "Yang_EN", "Starless_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Yang_EN", "Yang_EN");
            med.AddRandomGroup(Flower.Grey, "Yang_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Flower.Grey, "Yang_EN", "BlackStar_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "Yang_EN", "Yang_EN", "PawnA_EN");
            hard.AddRandomGroup(Flower.Grey, "Yang_EN", "Yang_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Yang_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("ClockTower_EN", "Yang_EN", "Yang_EN", "Starless_EN");
            hard.AddRandomGroup("ClockTower_EN", "Yang_EN", Enemies.Skinning, Enemies.Shivering);
            hard.AddRandomGroup("ClockTower_EN", "Yang_EN", "Yang_EN", "Stoplight_EN");
            hard.AddRandomGroup("ClockTower_EN", "Satyr_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("ClockTower_EN", "Yang_EN", "Yang_EN", "YNL_EN");
            hard.AddRandomGroup("ClockTower_EN", "Yang_EN", "Yang_EN", Bots.Grey);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "Yang_EN");
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "Hunter_EN");
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "OdeToHumanity_EN");
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "ClockTower_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Stoplight_EN", "Yang_EN", "Yang_EN");
            med.AddRandomGroup("Stoplight_EN", "Yang_EN", "BlackStar_EN");
            med.AddRandomGroup("Stoplight_EN", "Yang_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "Yang_EN", "PawnA_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "Yang_EN", "MiniReaper_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", Enemies.Minister);
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "Starless_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "Eyeless_EN");
            hard.AddRandomGroup("Stoplight_EN", "Yang_EN", "Yang_EN", Bots.Grey);

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Yang_EN", "Yang_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Yang_EN", "YNL_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Yang_EN", Bots.Grey);
            med.AddRandomGroup("OdeToHumanity_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "Yang_EN", "Yang_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Yang_EN", "PawnA_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("PersonalAngel_EN", "Yang_EN", "Starless_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Yang_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Starless_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Starless_EN", "Yang_EN", Bots.Grey);

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "Yang_EN", "Yang_EN");
            hard.AddRandomGroup("Eyeless_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Eyeless_EN", "Yang_EN", "PawnA_EN", "Starless_EN");
            hard.AddRandomGroup("Eyeless_EN", "Yang_EN", "PawnA_EN", "MiniReaper_EN");
            hard.AddRandomGroup("Eyeless_EN", "Yang_EN", "PawnA_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Yang_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Yang_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Yang_EN", "EyePalm_EN");
            hard.AddRandomGroup(Enemies.Minister, "Yang_EN", "Starless_EN");
            hard.AddRandomGroup(Enemies.Minister, "Yang_EN", Bots.Grey);
            hard.AddRandomGroup(Enemies.Minister, "Yang_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", "BlackStar_EN");
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Yang_EN");
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", Bots.Grey);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Stoplight_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Satyr_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Starless_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Eyeless_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", Enemies.Skinning);
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Yang_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "Yang_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Yang_EN", "ChoirBoy_EN");
        }
    }
}
