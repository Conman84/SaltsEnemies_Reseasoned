using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class StarlessEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_StarlessEncounter_Sign", ResourceLoader.LoadSprite("StarlessWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Starless.Med, "Salt_StarlessEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/StarlessSong";
            med.RoarEvent = "event:/Hawthorne/Sound/StarlessRoar";

            med.SimpleAddEncounter(1, "Starless_EN", 3, "InHisImage_EN");
            med.SimpleAddEncounter(1, "Starless_EN", 2, "InHerImage_EN", 1, "NextOfKin_EN");
            med.AddRandomEncounter("Starless_EN", "MiniReaper_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Starless_EN", "EyePalm_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "Starless_EN", 3, "EyePalm_EN");
            med.SimpleAddEncounter(1, "Starless_EN", 2, "EyePalm_EN", 1, "MiniReaper_EN");
            med.AddRandomEncounter("Starless_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomEncounter("Starless_EN", "Starless_EN", "MiniReaper_EN");
            med.AddRandomEncounter("Starless_EN", "Starless_EN", Enemies.Minister);
            med.AddRandomEncounter("Starless_EN", "Grandfather_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Starless_EN", Flower.Red, "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Starless_EN", Flower.Blue, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("Starless_EN", "InHisImage_EN", "InHisImage_EN", "Damocles_EN");
            med.AddRandomEncounter("Starless_EN", "GlassFigurine_EN", "Grandfather_EN", "Damocles_EN");
            med.AddRandomEncounter("Starless_EN", "Indicator_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Starless_EN", "Merced_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Starless_EN", "Hunter_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Starless_EN", "Shua_EN", "Hunter_EN");
            med.AddRandomEncounter("Starless_EN", "Shua_EN", Enemies.Minister);
            med.AddRandomEncounter("Starless_EN", "WindSong_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Starless_EN", "Shua_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Starless_EN", "EvilDog_EN", "EvilDog_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Starless_EN", "YNL_EN", "Grandfather_EN");
            med.AddRandomEncounter("Starless_EN", "YNL_EN", Enemies.Minister);
            med.SimpleAddEncounter(1, "Starless_EN", 4, "TortureMeNot_EN");
            med.AddRandomEncounter("Starless_EN", "ChoirBoy_EN", "Shua_EN");
            med.AddRandomEncounter("Starless_EN", "PersonalAngel_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("Starless_EN", Flower.Red, "WindSong_EN");
            med.AddRandomEncounter("Starless_EN", Flower.Blue, "GlassFigurine_EN");
            med.AddRandomEncounter("Starless_EN", "BlackStar_EN", "EyePalm_EN", "EyePalm_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Starless.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            Portals.AddPortalSign("Salt_EyelessEncounter_Sign", ResourceLoader.LoadSprite("EyelessWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Eyeless.Hard, "Salt_EyelessEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/StarlessSong";
            hard.RoarEvent = "event:/Hawthorne/Sound/EyelessDie";

            hard.SimpleAddEncounter(1, "Eyeless_EN", 3, "InHerImage_EN");
            hard.SimpleAddEncounter(1, "Eyeless_EN", 3, "InHisImage_EN");
            hard.AddRandomEncounter("Eyeless_EN", "Starless_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Eyeless_EN", "Starless_EN", Enemies.Minister);
            hard.AddRandomEncounter("Eyeless_EN", Flower.Red, Flower.Blue, "NextOfKin_EN");
            hard.AddRandomEncounter("Eyeless_EN", Flower.Grey, "YNL_EN");
            hard.AddRandomEncounter("Eyeless_EN", "WindSong_EN", "PersonalAngel_EN");
            hard.SimpleAddEncounter(1, "Eyeless_EN", 4, "EyePalm_EN");
            hard.AddRandomEncounter("Eyeless_EN", "Hunter_EN", Enemies.Camera, Enemies.Camera);
            hard.AddRandomEncounter("Eyeless_EN", "MiniReaper_EN", "InHisImage_EN", "InHerImage_EN");
            hard.AddRandomEncounter("Eyeless_EN", "MiniReaper_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomEncounter("Eyeless_EN", "Firebird_EN", "YNL_EN", "NextOfKin_EN", "NextOfKin_EN");
            hard.SimpleAddEncounter(1, "Eyeless_EN", 1, "Starless_EN", 3, "BlackStar_EN");
            hard.SimpleAddEncounter(1, "Eyeless_EN", 1, "Starless_EN", 3, "Damocles_EN");
            hard.AddRandomEncounter("Eyeless_EN", "Indicator_EN", "Skyloft_EN", "Grandfather_EN");
            hard.SimpleAddEncounter(3, "Eyeless_EN");
            hard.SimpleAddEncounter(2, "Eyeless_EN", 1, "Starless_EN");
            hard.SimpleAddEncounter(1, "Eyeless_EN", 2, "Starless_EN");
            hard.AddRandomEncounter("Eyeless_EN", "OdeToHumanity_EN", "YNL_EN");
            hard.AddRandomEncounter("Eyeless_EN", "OdeToHumanity_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomEncounter("Eyeless_EN", "Starless_EN", "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomEncounter("Eyeless_EN", Enemies.Minister, "Firebird_EN", "Children6_EN");
            hard.AddRandomEncounter("Eyeless_EN", Enemies.Minister, "WindSong_EN", "Children6_EN");
            hard.AddRandomEncounter("Eyeless_EN", "ChoirBoy_EN", "Firebird_EN", "Children6_EN");
            hard.SimpleAddEncounter(1, "Eyeless_EN", 1, "MiniReaper_EN", 3, "EyePalm_EN");
            hard.AddRandomEncounter("Eyeless_EN", Bots.Grey, "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomEncounter("Eyeless_EN", Spoggle.Grey, "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomEncounter("Eyeless_EN", Jumble.Grey, "Hunter_EN", Enemies.Shivering);
            hard.AddRandomEncounter("Eyeless_EN", "Starless_EN", "LittleAngel_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Eyeless_EN", Enemies.Minister, "LittleAngel_EN", "Children6_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Eyeless.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Starless_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Satyr_EN", "Starless_EN", "MiniReaper_EN");
            med.AddRandomGroup("Satyr_EN", "Starless_EN", "GlassFigurine_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Eyeless_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup("Satyr_EN", "Eyeless_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Satyr_EN", "Eyeless_EN", Enemies.Skinning);
            hard.AddRandomGroup("Satyr_EN", "Eyeless_EN", "OdeToHumanity_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Eyeless_EN", "Starless_EN", "Damocles_EN", "Damocles_EN");
            hard.AddRandomGroup("ClockTower_EN", "Starless_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("ClockTower_EN", "Eyeless_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup("ClockTower_EN", "Starless_EN", Enemies.Skinning, "MiniReaper_EN");
            hard.AddRandomGroup("ClockTower_EN", "Starless_EN", "Eyeless_EN", "Hunter_EN");
            hard.AddRandomGroup("ClockTower_EN", "Starless_EN", "Eyeless_EN", "WindSong_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Eyeless_EN", "Damocles_EN");
            hard.AddRandomGroup(Enemies.Tank, "Starless_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Merced.Hard);
            hard.SimpleAddGroup(1, "Merced_EN", 3, "Starless_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Starless_EN", "MiniReaper_EN");
            med.AddRandomGroup("Stoplight_EN", "Starless_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Stoplight_EN", "Starless_EN", Spoggle.Grey);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Starless_EN", "Eyeless_EN");
            hard.AddRandomGroup("Stoplight_EN", "Starless_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "Eyeless_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "Starless_EN", Bots.Grey);

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.AddRandomGroup("GlassedSun_EN", "GlassedSun_EN", "Starless_EN", "Eyeless_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "Starless_EN", "Starless_EN");
            hard.AddRandomGroup("Miriam_EN", "Eyeless_EN", "Eyeless_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Starless_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Starless_EN", Enemies.Minister);
            med.AddRandomGroup("OdeToHumanity_EN", "Starless_EN", "Grandfather_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Starless_EN", "TortureMeNot_EN");
            med.AddRandomGroup("Complimentary_EN", "Starless_EN", "EyePalm_EN");
            med.AddRandomGroup("Complimentary_EN", "Starless_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Starless_EN", Enemies.Minister);
            med.AddRandomGroup("PersonalAngel_EN", "Starless_EN", "Shua_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Starless_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Starless_EN", "WindSong_EN");
            med.AddRandomGroup(Enemies.Skinning, "Starless_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Skinning, "Starless_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Starless_EN", "Eyeless_EN");
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Starless_EN");
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Eyeless_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Starless_EN", "Starless_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Starless_EN");
            med.AddRandomGroup(Enemies.Minister, "Starless_EN", "YNL_EN");
            med.AddRandomGroup(Enemies.Minister, "Starless_EN", "Hunter_EN", "Skyloft_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Eyeless_EN");
            hard.AddRandomGroup(Enemies.Minister, "Eyeless_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Starless_EN", "Damocles_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Starless_EN", "Skyloft_EN");
        }
    }
}
