using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CelebrationEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_CelebrationEncounter_Sign", ResourceLoader.LoadSprite("CelebrationWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Celebration.Med, "Salt_CelebrationEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CelebrationTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/PumkinDie";

            med.AddRandomEncounter("Celebration_EN", "PawnA_EN", "PawnA_EN", "Celebration_EN");
            med.SimpleAddEncounter(1, "Celebration_EN", 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, "Celebration_EN", 2, "InHerImage_EN");
            med.AddRandomEncounter("Celebration_EN", "InHerImage_EN", "InHisImage_EN");
            med.SimpleAddEncounter(1, "Celebration_EN", 4, "NextOfKin_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 1, "ChoirBoy_EN");
            med.AddRandomEncounter("Celebration_EN", Spoggle.Gray, "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Celebration_EN", Jumble.Gray, "PawnA_EN", "PawnA_EN");
            med.AddRandomEncounter("Celebration_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("Celebration_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "WindSong_EN");
            med.AddRandomEncounter("Celebration_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Grandfather_EN");
            med.AddRandomEncounter("Celebration_EN", "Shua_EN", "BlackStar_EN", "BlackStar_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Damocles_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Indicator_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 3, "TortureMeNot_EN");
            med.AddRandomEncounter("Celebration_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Yang_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Insider_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Sundowner_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 1, "Panopticon_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 1, Ecstasy.Gray);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Celebration.Med, 8 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Celebration.Hard, "Salt_CelebrationEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/CelebrationTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/PumkinDie";

            hard.AddRandomEncounter("Celebration_EN", "InHerImage_EN", "InHerImage_EN", "Celebration_EN");
            hard.SimpleAddEncounter(3, "Celebration_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", Spoggle.Gray);
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "WindSong_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "MiniReaper_EN", "Merced_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Shua_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "BlackStar_EN", "Indicator_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Yang_EN", "PawnA_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Insider_EN", "Insider_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Sundowner_EN", "Sundowner_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Panopticon_EN", "Panopticon_EN");
            hard.AddRandomEncounter("Celebration_EN", "Celebration_EN", Ecstasy.Gray, Ecstasy.Gray);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Celebration.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Celebration_EN", Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Celebration_EN", "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Celebration_EN", "Celebration_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Celebration_EN");

            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, "Celebration_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Celebration_EN");
            hard.SimpleAddGroup(1, Enemies.Foundling, 3, "Celebration_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Celebration_EN", "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, "Celebration_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Celebration_EN", Flower.Red);

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "Celebration_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Celebration_EN", "InHisImage_EN", "InHerImage_EN");
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, "Celebration_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Celebration_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Celebration_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Celebration_EN", "Damocles_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Celebration_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.AddRandomGroup("GlassedSun_EN", "GlassedSun_EN", "GlassedSun_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Celebration_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Celebration_EN", "Celebration_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Celebration_EN", "Yang_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Celebration_EN", Jumble.Gray);

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(1, "InTheDark_EN", 2, "Celebration_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Celebration_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, "Celebration_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "Celebration_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "Celebration_EN", Enemies.Shivering);

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Celebration_EN");
            hard.SimpleAddGroup(1, Enemies.Eclipse, 2, "Celebration_EN");
        }
    }
}
