using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class InTheDarkEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_DarkEncounter_Sign", ResourceLoader.LoadSprite("DarkWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Dark.Med, "Salt_DarkEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/InTheDarkPlaceholder";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("InTheDark_EN").deathSound;

            med.SimpleAddEncounter(2, "InTheDark_EN");
            med.AddRandomEncounter("InTheDark_EN", "InHisImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "InTheDark_EN", 3, "NextOfKin_EN", 1, "LittleAngel_EN");
            med.SimpleAddEncounter(1, "InTheDark_EN", 2, "BlackStar_EN");
            med.AddRandomEncounter("InTheDark_EN", "ChoirBoy_EN", "Indicator_EN");
            med.SimpleAddEncounter(1, "InTheDark_EN", 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, "InTheDark_EN", 3, "PawnA_EN");
            med.AddRandomEncounter("InTheDark_EN", Jumble.Grey, Enemies.Minister);
            med.AddRandomEncounter("InTheDark_EN", Spoggle.Grey, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("InTheDark_EN", Flower.Red, Flower.Purple);
            med.AddRandomEncounter("InTheDark_EN", Flower.Blue, Flower.Yellow);
            med.AddRandomEncounter("InTheDark_EN", "WindSong_EN", "EyePalm_EN");
            med.AddRandomEncounter("InTheDark_EN", "MiniReaper_EN", "MiniReaper_EN");
            med.AddRandomEncounter("InTheDark_EN", "Shua_EN", "Damocles_EN", "Damocles_EN");
            med.SimpleAddEncounter(1, "InTheDark_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("InTheDark_EN", "Hunter_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("InTheDark_EN", "Firebird_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("InTheDark_EN", "YNL_EN", "Hauntling_EN");
            med.AddRandomEncounter("InTheDark_EN", Bots.Grey, Enemies.Shivering);
            med.AddRandomEncounter("InTheDark_EN", "Satyr_EN", "GlassFigurine_EN");
            med.SimpleAddEncounter(2, "EvilDog_EN", 1, "InTheDark_EN");
            med.AddRandomEncounter("InTheDark_EN", "Starless_EN", "Skyloft_EN");
            med.AddRandomEncounter("InTheDark_EN", "Yang_EN", "PawnA_EN");
            med.AddRandomEncounter("InTheDark_EN", "PersonalAngel_EN", "Romantic_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, "InTheDark_EN");
            med.SimpleAddEncounter(3, "Hauntling_EN", 1, "InTheDark_EN");
            med.AddRandomEncounter("InTheDark_EN", "CorpseChan_EN", Enemies.Shivering);
            med.SimpleAddEncounter(2, "Sundowner_EN", 1, "InTheDark_EN");
            med.AddRandomEncounter("InTheDark_EN", "Stoplight_EN", "BlackStar_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Dark.Med, April.Me && !April.Birthday ? 8 : April.LessMod * 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Dark.Hard, "Salt_DarkEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/InTheDarkPlaceholder";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemy("InTheDark_EN").deathSound;

            hard.SimpleAddEncounter(3, "InTheDark_EN");
            hard.SimpleAddEncounter(1, "InTheDark_EN", 3, "InHisImage_EN");
            hard.SimpleAddEncounter(1, "InTheDark_EN", 3, "EvilDog_EN");
            hard.SimpleAddEncounter(1, "InTheDark_EN", 3, "Sundowner_EN");
            hard.AddRandomEncounter("InTheDark_EN", "InTheDark_EN", "Stoplight_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "Satyr_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "CorpseChan_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "ClockTower_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, Flower.Grey);
            hard.AddRandomEncounter("InTheDark_EN", Enemies.Minister, "ChoirBoy_EN");
            hard.AddRandomEncounter("InTheDark_EN", Spoggle.Grey, "PawnA_EN", "PawnA_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "Starless_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "Yang_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "Complimentary_EN");
            hard.SimpleAddEncounter(2, "InTheDark_EN", 1, "Eyeless_EN");
            hard.SimpleAddEncounter(1, "InTheDark_EN", 3, "Insider_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Dark.Hard, April.Me && !April.Birthday ? 8 : April.LessMod * 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "InTheDark_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(1, Enemies.Skinning, 2, "InTheDark_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "InTheDark_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "InTheDark_EN", Enemies.Shivering, Enemies.Shivering);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "InTheDark_EN", "EvilDog_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "InTheDark_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "InTheDark_EN");
        }
    }
}
