using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SlaveEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
            Add_Special();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_SlaveEncounter_Sign", ResourceLoader.LoadSprite("SlaveWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Med, "Salt_SlaveEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SlaveTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            med.SimpleAddEncounter(3, "Slave_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Celebration_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Indicator_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 3, "NextOfKin_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, Enemies.Shivering);
            med.SimpleAddEncounter(2, "Slave_EN", 1, "ChoirBoy_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "LittleAngel_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Spoggle.Gray);
            med.SimpleAddEncounter(2, "Slave_EN", 1, Jumble.Gray);
            med.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Camera);
            med.SimpleAddEncounter(2, "Slave_EN", 1, Flower.Red);
            med.SimpleAddEncounter(2, "Slave_EN", 1, Flower.Blue);
            med.SimpleAddEncounter(2, "Slave_EN", 1, "WindSong_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Grandfather_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "MiniReaper_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Merced_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "EyePalm_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Shua_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "Damocles_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "GlassFigurine_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Firebird_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "BlackStar_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "YNL_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Bots.Grey);
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Children6_EN", 1, Enemies.Shivering);
            med.SimpleAddEncounter(2, "Slave_EN", 3, "TortureMeNot_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "EvilDog_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Yang_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "CorpseChan_EN");
            med.AddRandomEncounter("Slave_EN", Enemies.Eclipse, "GlassFigurine_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "Hauntling_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Insider_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Ecstasy.Gray);
            med.SimpleAddEncounter(2, "Slave_EN", 1, "Lightbulbkin_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "Vivarium_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Troller);
            med.AddRandomEncounter("Slave_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Slave_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Shivering);
            

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Slave.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Hard, "Salt_SlaveEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SlaveTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            med.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Eclipse);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Slave.Hard, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Add_Special()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Special, "Salt_SlaveEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SlaveTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            med.SimpleAddEncounter(4, "Slave_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Slave.Special, 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Slave_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, "Slave_EN", "GlassFigurine_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(1, Enemies.Skinning, 2, "Slave_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Slave_EN", Bots.Gray);

            med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("ChoirBoy_EN", "Slave_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Slave_EN", "Vivarium_EN");
            med.AddRandomGroup(Enemies.Minister, "Slave_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Slave_EN", "Slave_EN");
            hard.AddRandomGroup(Enemies.Minister, "Slave_EN", Enemies.Troller, Enemies.Troller);

            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, "Slave_EN", "BlackStar_EN");
            med.AddRandomGroup(Enemies.Foundling, "Slave_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Slave_EN");
            hard.SimpleAddGroup(1, Enemies.Foundling, 2, "Slave_EN");
            
            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Slave_EN", "EyePalm_EN");
            med.AddRandomGroup("Satyr_EN", "Slave_EN", "Vivarium_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, "Slave_EN");
            hard.AddRandomGroup("Satyr_EN", "Slave_EN", "InHerImage_EN", "InHisImage_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Slave_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, "Slave_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Foundling, "Slave_EN", "Slave_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.SimpleAddGroup(1, "Hunter_EN", 2, "Slave_EN");
            med.AddRandomGroup("Hunter_EN", "Slave_EN", "Firebird_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.SimpleAddGroup(1, "OdeToHumanity_EN", 2, "Slave_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Slave_EN", "Git_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Slave_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.SimpleAddGroup(1, "PersonalAngel_EN", 2, "Slave_EN");
            med.AddRandomGroup("PersonalAngel_EN", "Slave_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.SimpleAddGroup(1, "Starless_EN", 2, "Slave_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, "Slave_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.SimpleAddGroup(2, "Yin_EN", 1, "Slave_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.SimpleAddGroup(1, "CorpseChan_EN", 2, "Slave_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Slave_EN", "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(1, "InTheDark_EN", 2, "Slave_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Slave_EN", "Skyloft_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.SimpleAddGroup(1, "Lunoscope_EN", 2, "Slave_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Slave_EN");

            //minibosses
            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, "Slave_EN");
            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.SimpleAddGroup(1, "SnakeGod_EN", 1, "Slave_EN");
            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Slave_EN");
        }
    }
}
