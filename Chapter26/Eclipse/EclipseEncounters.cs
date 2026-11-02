using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EclipseEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_EclipseEncounter_Sign", ResourceLoader.LoadSprite("RisingWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Eclipse.Med, "Salt_EclipseEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EclipseTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/KnightRoar";

            med.AddRandomEncounter("EclipseRising_EN", "InHisImage_EN", "InHisImage_EN");
            med.SimpleAddEncounter(1, Enemies.Eclipse, 4, "NextOfKin_EN");
            med.SimpleAddEncounter(1, Enemies.Eclipse, 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, Enemies.Eclipse, 2, "InHerImage_EN");
            med.AddRandomEncounter(Enemies.Eclipse, Enemies.Minister, "LittleAngel_EN");
            med.AddRandomEncounter(Enemies.Eclipse, Spoggle.Grey, "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter(Enemies.Eclipse, Jumble.Grey, "ChoirBoy_EN");
            med.AddRandomEncounter(Enemies.Eclipse, Flower.Red, Flower.Blue);
            med.AddRandomEncounter(Enemies.Eclipse, "WindSong_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Grandfather_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "MiniReaper_EN", Enemies.Shivering);
            med.AddRandomEncounter(Enemies.Eclipse, "Merced_EN", "Skyloft_EN", "Children6_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Shua_EN", "EyePalm_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "GlassFigurine_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter(Enemies.Eclipse, "Hunter_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Firebird_EN", "LittleAngel_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "BlackStar_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Indicator_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter(Enemies.Eclipse, "YNL_EN", "Shua_EN");
            med.AddRandomEncounter(Enemies.Eclipse, Bots.Grey, "NextOfKin_EN", "NextOfKin_EN");
            med.SimpleAddEncounter(1, Enemies.Eclipse, 4, "TortureMeNot_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "OdeToHumanity_EN", "BlackStar_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "PersonalAngel_EN", "Damocles_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Starless_EN", "GlassFigurine_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Yang_EN", "Yang_EN");
            med.SimpleAddEncounter(1, Enemies.Eclipse, 3, "Hauntling_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "Insider_EN", "BlackStar_EN", "BlackStar_EN");
            med.AddRandomEncounter(Enemies.Eclipse, "CorpseChan_EN", Enemies.Shivering);
            med.AddRandomEncounter(Enemies.Eclipse, "Panopticon_EN", "Panopticon_EN");
            med.AddRandomEncounter(Enemies.Eclipse, Ecstasy.Gray, Ecstasy.Gray);
            med.SimpleAddEncounter(1, Enemies.Eclipse, 2, "Sundowner_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Eclipse.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Eclipse.Hard, "Salt_EclipseEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/EclipseTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/KnightRoar";

            hard.AddRandomEncounter("EclipseRising_EN", "EclipseRising_EN", Enemies.Minister);
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "InHisImage_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 2, "InHerImage_EN", 1, "InHisImage_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "ChoirBoy_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 1, Flower.Red, 1, Flower.Blue, 1, Flower.Gray);
            hard.AddRandomEncounter(Enemies.Eclipse, Enemies.Eclipse, "WindSong_EN");
            hard.AddRandomEncounter(Enemies.Eclipse, Enemies.Eclipse, "Grandfather_EN");
            hard.AddRandomEncounter(Enemies.Eclipse, "MiniReaper_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomEncounter(Enemies.Eclipse, Enemies.Eclipse, Enemies.Eclipse);
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "EyePalm_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Shua_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Hunter_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Firebird_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Indicator_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "BlackStar_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "YNL_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, Bots.Grey);
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "OdeToHumanity_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "EvilDog_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Complimentary_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "PersonalAngel_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Starless_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "Yang_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 4, "PawnA_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Insider_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "CorpseChan_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "Panopticon_EN");
            hard.SimpleAddEncounter(2, Enemies.Eclipse, 1, "Lunoscope_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "Sundowner_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, "Panopticon_EN");
            hard.SimpleAddEncounter(1, Enemies.Eclipse, 3, Ecstasy.Gray);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Eclipse.Hard, 10 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Eclipse, Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Eclipse, Enemies.Eclipse);

            med = new AddTo(Garden.H.Foundling.Med);
            med.SimpleAddGroup(2, Enemies.Foundling, 1, Enemies.Eclipse);

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.SimpleAddGroup(2, Enemies.Foundling, 2, Enemies.Eclipse);

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Eclipse, "BlackStar_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Eclipse, Enemies.Eclipse);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Eclipse, Enemies.Eclipse, "Skyloft_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Eclipse);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Eclipse, "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.SimpleAddGroup(1, "Stoplight_EN", 2, Enemies.Eclipse);

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(2, "GlassedSun_EN", 1, Enemies.Eclipse);

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Eclipse);

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", Enemies.Eclipse, Enemies.Shivering, Enemies.Shivering);
        }
    }
}
