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
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Hard, "Salt_SlaveEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/SlaveTheme";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            hard.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Eclipse);
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "LittleAngel_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 1, Flower.Grey);
            hard.SimpleAddEncounter(3, "Slave_EN", 1, Jumble.Gray);
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Grandfather_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Merced_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Skyloft_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Damocles_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "GlassFigurine_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Indicator_EN");
            hard.AddRandomEncounter("Slave_EN", "Slave_EN", Flower.Red, Flower.Blue);
            hard.SimpleAddEncounter(2, "Slave_EN", 2, "EvilDog_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "EvilDog_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 2, "InHerImage_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 2, "InHisImage_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "YNL_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Yang_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 3, "PawnA_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 2, "Hauntling_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 2, "Insider_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Insider_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 2, "Panopticon_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Panopticon_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 2, Ecstasy.Gray);
            hard.SimpleAddEncounter(3, "Slave_EN", 1, Ecstasy.Gray);
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Celebration_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Lightbulbkin_EN");
            hard.SimpleAddEncounter(3, "Slave_EN", 1, "Vivarium_EN");
            hard.SimpleAddEncounter(2, "Slave_EN", 2, Enemies.Troller);
            hard.SimpleAddEncounter(3, "Slave_EN", 1, Enemies.Troller);

            hard.AddEncounterToDataBases();
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

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Slave_EN", "EvilDog_EN");
            med.AddRandomGroup("Stoplight_EN", "Slave_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Slave_EN", "Slave_EN");
            hard.AddRandomGroup("Stoplight_EN", "Slave_EN", Enemies.Minister);

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
            med.AddRandomGroup("Starless_EN", "Slave_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, "Slave_EN");
            hard.AddRandomGroup("Eyeless_EN", "Slave_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Slave_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(2, "Yang_EN", 1, "Slave_EN", 1, "PawnA_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.SimpleAddGroup(2, "Yin_EN", 1, "Slave_EN");
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Slave_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.SimpleAddGroup(1, "CorpseChan_EN", 2, "Slave_EN");
            med.AddRandomGroup("CorpseChan_EN", "Slave_EN", "Firebird_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Slave_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup("InTheDark_EN", "Slave_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(1, "InTheDark_EN", 2, "Slave_EN");
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Slave_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Slave_EN", "Skyloft_EN");
            med.AddRandomGroup("Lunoscope_EN", "Slave_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.SimpleAddGroup(1, "Lunoscope_EN", 2, "Slave_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Slave_EN", "YNL_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Slave_EN");
            hard.AddRandomGroup(Enemies.Eclipse, "Slave_EN", "Celebration_EN");

            med = new AddTo(Garden.H.NeverMind.Med);
            med.AddRandomGroup("NeverMind_EN", "Slave_EN", "Insider_EN");
            med.AddRandomGroup("NeverMind_EN", "Attrition_EN", "Slave_EN");

            hard = new AddTo(Garden.H.NeverMind.Hard);
            hard.SimpleAddGroup(1, "NeverMind_EN", 2, "Slave_EN");
            hard.SimpleAddGroup(2, "NeverMind_EN", 1, "Slave_EN");

            //minibosses
            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, "Slave_EN");
            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.SimpleAddGroup(1, "SnakeGod_EN", 1, "Slave_EN");
            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Slave_EN");

            //mods
            med = new AddTo(Garden.H.Slave.Med);
            med.AddRandomGroup("Slave_EN", Enemies.MainSister, "Damocles_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, Enemies.Prior);
            med.SimpleAddGroup(2, "Slave_EN", 1, Enemies.Prioress);
            med.SimpleAddGroup(2, "Slave_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, Noses.Red);
            med.SimpleAddGroup(2, "Slave_EN", 1, Noses.Blue);
            med.SimpleAddGroup(2, "Slave_EN", 1, Noses.Yellow);
            med.SimpleAddGroup(2, "Slave_EN", 1, Noses.Purple);
            med.SimpleAddGroup(2, "Slave_EN", 1, Noses.Gray);
            med.SimpleAddGroup(2, "Slave_EN", 1, Enemies.Leviat);
            med.SimpleAddGroup(2, "Slave_EN", 1, Enemies.Screaming);
            med.SimpleAddGroup(2, "Slave_EN", 1, "Bonsai_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, "Attrition_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, "Slave_EN", 2, "Romantic_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "Slave_EN", 1, Jumble.Mythos);
            med.SimpleAddGroup(2, "Slave_EN", 1, Spoggle.Mythos);
            med.SimpleAddGroup(2, "Slave_EN", 1, Enemies.Polyp);
            med.SimpleAddGroup(2, "Slave_EN", 1, "Allusion_EN");

            hard = new AddTo(Garden.H.Slave.Hard);
            hard.SimpleAddGroup(2, "Slave_EN", 1, Enemies.MainSister);
            hard.SimpleAddGroup(3, "Slave_EN", 1, "EggKeeper_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, Enemies.Prior);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Enemies.Prioress);
            hard.SimpleAddGroup(2, "Slave_EN", 1, Enemies.Prior, 1, Enemies.Prioress);
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Drippings_EN");
            hard.SimpleAddGroup(2, "Slave_EN", 1, "Idiotware_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, Noses.Red);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Noses.Blue);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Noses.Yellow);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Noses.Purple);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Noses.Gray);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Enemies.Screaming);
            hard.SimpleAddGroup(2, "Slave_EN", 2, "Bonsai_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Bonsai_EN");
            hard.SimpleAddGroup(2, "Slave_EN", 2, "Attrition_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Attrition_EN");
            hard.SimpleAddGroup(2, "Slave_EN", 2, "Git_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Git_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Romantic_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Surrogate_EN");
            hard.SimpleAddGroup(2, "Slave_EN", 1, "Ascendant_EN");
            hard.SimpleAddGroup(3, "Slave_EN", 1, Jumble.Mythos);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Spoggle.Mythos);
            hard.SimpleAddGroup(3, "Slave_EN", 1, Enemies.Polyp);
            hard.SimpleAddGroup(3, "Slave_EN", 1, "Allusion_EN");

            med = new AddTo(Garden.H.Vessel.Med);
            med.AddRandomGroup(Enemies.Vessel, "Slave_EN");
            med.AddRandomGroup(Enemies.Vessel, "Slave_EN", Enemies.Spirit);

            hard = new AddTo(Garden.H.Vessel.Med);
            hard.SimpleAddGroup(1, Enemies.Vessel, 2, "Slave_EN");
            hard.SimpleAddGroup(1, Enemies.Vessel, 2, "Slave_EN", 1, Enemies.Spirit);

            hard = new AddTo(Garden.H.Sisters.Hard);
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, "Slave_EN");

            med = new AddTo(Garden.H.Phobia.Med);
            med.AddRandomGroup(Enemies.Phobia, "Slave_EN", "Vivarium_EN");
            med.AddRandomGroup(Enemies.Phobia, "Slave_EN");

            hard = new AddTo(Garden.H.Phobia.Hard);
            hard.SimpleAddGroup(1, Enemies.Phobia, 2, "Slave_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "Slave_EN");

            hard = new AddTo(Garden.H.Portrait.Hard);
            hard.AddRandomGroup(Enemies.Portrait, "Slave_EN", "NextOfKin_EN", "NextOfKin_EN");
            hard.SimpleAddGroup(1, Enemies.Portrait, 2, "Slave_EN");

            med = new AddTo(Garden.H.Idiotware.Med);
            med.AddRandomGroup("Idiotware_EN", "Slave_EN");

            med = new AddTo(Garden.H.Shambler.Med);
            med.AddRandomGroup(Enemies.Shambler, "Slave_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Shivering, "Slave_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.Shambler.Hard);
            hard.AddRandomGroup(Enemies.Shambler, "Slave_EN", "Slave_EN");
            hard.AddRandomGroup(Enemies.Shambler, "Slave_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "Slave_EN", "Slave_EN");
            med.AddRandomGroup("Beakart_EN", "Slave_EN", "Celebration_EN");

            


        }
    }
}
