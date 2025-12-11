using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class LunoscopeEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_LunoscopeEncounter_Sign", ResourceLoader.LoadSprite("LunoscopePortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Lunoscope.Med, "Salt_LunoscopeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LunoscopePlaceholder";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("BlackStar_EN").deathSound;

            med.AddRandomEncounter("Lunoscope_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Lunoscope_EN", Spoggle.Grey, "EyePalm_EN");
            med.SimpleAddEncounter(1, "Lunoscope_EN", 3, "PawnA_EN");
            med.SimpleAddEncounter(1, "Lunoscope_EN", 4, "NextOfKin_EN");
            med.AddRandomEncounter("Lunoscope_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Lunoscope_EN", Enemies.Shivering, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("Lunoscope_EN", Enemies.Minister, Jumble.Grey);
            med.AddRandomEncounter("Lunoscope_EN", "WindSong_EN", Spoggle.Grey);
            med.AddRandomEncounter("Lunoscope_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Grandfather_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("Lunoscope_EN", "LittleAngel_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Shua_EN", "MiniReaper_EN");
            med.AddRandomEncounter("Lunoscope_EN", "GlassFigurine_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Hunter_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Lunoscope_EN", "YNL_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Firebird_EN", "LittleAngel_EN");
            med.AddRandomEncounter("Lunoscope_EN", "BlackStar_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Indicator_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("Lunoscope_EN", "Children6_EN", "Firebird_EN");
            med.AddRandomEncounter("Lunoscope_EN", "EvilDog_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("Lunoscope_EN", "OdeToHumanity_EN", "Damocles_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Starless_EN", "Skyloft_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Yang_EN", "Hauntling_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Insider_EN", "Insider_EN");
            med.AddRandomEncounter("Lunoscope_EN", "Sundowner_EN", "Sundowner_EN");
            med.AddRandomEncounter("Lunoscope_EN", "CorpseChan_EN", "Damocles_EN");
            med.AddRandomEncounter("Lunoscope_EN", Bots.Grey, "Skyloft_EN");
            med.AddRandomEncounter("Lunoscope_EN", "BlackStar_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lunoscope.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Lunoscope.Hard, "Salt_LunoscopeEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/LunoscopePlaceholder";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemy("BlackStar_EN").deathSound;

            hard.AddRandomEncounter("Lunoscope_EN", "InHisImage_EN", "InHisImage_EN", "InHerImage_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "ChoirBoy_EN", Bots.Grey);
            hard.AddRandomEncounter("Lunoscope_EN", "ChoirBoy_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "EvilDog_EN", "EvilDog_EN", Flower.Blue);
            hard.AddRandomEncounter("Lunoscope_EN", "EvilDog_EN", "EvilDog_EN", Flower.Red);
            hard.AddRandomEncounter("Lunoscope_EN", "PersonalAngel_EN", "Shua_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "Shua_EN", "WindSong_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "Grandfather_EN", "PersonalAngel_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "Hunter_EN", "Indicator_EN", "Damocles_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "YNL_EN", "Yang_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "Starless_EN", "Yang_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "MiniReaper_EN", "BlackStar_EN");
            hard.SimpleAddEncounter(1, "Lunoscope_EN", 2, "BlackStar_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "Insider_EN", "Insider_EN", "Insider_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "CorpseChan_EN", "EyePalm_EN", "EyePalm_EN");
            hard.SimpleAddEncounter(1, "Lunoscope_EN", 2, "EyePalm_EN", 1, Flower.Blue);
            hard.SimpleAddEncounter(1, "Lunoscope_EN", 2, "EyePalm_EN", 1, Flower.Red);
            hard.AddRandomEncounter("Lunoscope_EN", Enemies.Minister, Spoggle.Grey);
            hard.AddRandomEncounter("Lunoscope_EN", Jumble.Grey, "Sundowner_EN", "Sundowner_EN");
            hard.AddRandomEncounter("Lunoscope_EN", "OdeToHumanity_EN", Enemies.Camera, Enemies.Camera);
            hard.AddRandomEncounter("Lunoscope_EN", "Sundowner_EN", "Sundowner_EN", Enemies.Minister);
            hard.AddRandomEncounter("Lunoscope_EN", "Yang_EN", "PawnA_EN", "PawnA_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lunoscope.Hard, 8 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", Noses.Red, "EyePalm_EN");
            med.AddRandomGroup("Lunoscope_EN", Noses.Yellow, "EyePalm_EN");
            med.SimpleAddGroup(1, "Lunoscope_EN", 3, "Romantic_EN");
            med.AddRandomGroup("Lunoscope_EN", "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup("Lunoscope_EN", "Git_EN", "Git_EN");
            med.AddRandomGroup("Lunoscope_EN", "Bonsai_EN", "Bonsai_EN");
            med.AddRandomGroup("Lunoscope_EN", "Beakart_EN", "Children6_EN");
            med.AddRandomGroup("Lunoscope_EN", "EggKeeper_EN", "MiniReaper_EN");
            med.AddRandomGroup("Lunoscope_EN", Enemies.Polyp, "PawnA_EN", "PawnA_EN");

            AddTo hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "EggKeeper_EN", "BlackStar_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Attrition_EN", "Attrition_EN", Jumble.Gray);
            hard.AddRandomGroup("Lunoscope_EN", "Bonsai_EN", "Bonsai_EN", Jumble.Gray);
            hard.AddRandomGroup("Lunoscope_EN", "Git_EN", "Git_EN", "OdeToHumanity_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Romantic_EN", "Romantic_EN", "CorpseChan_EN");
            hard.AddRandomGroup("Lunoscope_EN", "InHisImage_EN", "InHerImage_EN", Noses.Gray);
            hard.AddRandomGroup("Lunoscope_EN", Noses.Blue, "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomGroup("Lunoscope_EN", Noses.Purple, "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Beakart_EN", "Surrogate_EN", "Surrogate_EN", "Surrogate_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Starless_EN", "Beakart_EN");
            hard.AddRandomGroup("Lunoscope_EN", Flower.Gray, "Beakart_EN");
            hard.AddRandomGroup("Lunoscope_EN", Enemies.Polyp, "InHisImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Lunoscope_EN", "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Lunoscope_EN", "Bonsai_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Lunoscope_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Lunoscope_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomGroup("ClockTower_EN", "Lunoscope_EN", "Attrition_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Gray, "Lunoscope_EN", Flower.Blue);
            hard.AddRandomGroup(Flower.Gray, "Lunoscope_EN", Flower.Red);

            hard = new AddTo(Garden.H.Merced.Hard);
            hard.SimpleAddGroup(1, "Merced_EN", 2, "Lunoscope_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Lunoscope_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Lunoscope_EN", "Romantic_EN");
            med.AddRandomGroup("Stoplight_EN", "Lunoscope_EN", "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Lunoscope_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomGroup("Stoplight_EN", "Lunoscope_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Lunoscope_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Lunoscope_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Lunoscope_EN", "Indicator_EN");
            hard.AddRandomGroup("Eyeless_EN", "Lunoscope_EN", "Damocles_EN", "Damocles_EN");
            hard.AddRandomGroup("Eyeless_EN", "Lunoscope_EN", "Bonsai_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Lunoscope_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Lunoscope_EN", "Children6_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", "Lunoscope_EN", "EggKeeper_EN");
            hard.AddRandomGroup("InTheDark_EN", "Lunoscope_EN", "Grandfather_EN");
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Lunoscope_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, "Lunoscope_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Lunoscope_EN");
        }
    }
}
