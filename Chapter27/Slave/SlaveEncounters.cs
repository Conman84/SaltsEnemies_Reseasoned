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
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_SlaveEncounter_Sign", ResourceLoader.LoadSprite("SlaveWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Med, "Salt_SlaveEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SlaveTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            med.SimpleAddEncounter(3, "Slave_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Slave_EN", 1, Enemies.Eclipse);
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
            

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Slave.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            Portals.AddPortalSign("Salt_SlaveEncounter_Sign", ResourceLoader.LoadSprite("SlaveWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Slave.Hard, "Salt_SlaveEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SlaveTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle(Shore.H.Jumble.Yellow.Med)._roarReference.roarEvent;

            med.SimpleAddEncounter(4, "Slave_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Slave.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Slave_EN", "EyePalm_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, "Slave_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Slave_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.SimpleAddGroup(1, "Hunter_EN", 2, "Slave_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.SimpleAddGroup(1, "OdeToHumanity_EN", 2, "Slave_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Slave_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.SimpleAddGroup(1, "PersonalAngel_EN", 2, "Slave_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.SimpleAddGroup(1, "Starless_EN", 2, "Slave_EN");

            
        }
    }
}
