using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GlassedSunEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_GlassedSunEncounter_Sign", ResourceLoader.LoadSprite("SunWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.GlassedSun.Hard, "Salt_GlassedSunEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/SunSong";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent;

            hard.SimpleAddEncounter(4, "GlassedSun_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, Enemies.Minister);
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "ChoirBoy_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 2, "Damocles_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "GlassFigurine_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "Merced_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "LittleAngel_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "Skyloft_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "Hunter_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "MiniReaper_EN");
            hard.SimpleAddEncounter(3, "GlassedSun_EN", 1, "WindSong_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.GlassedSun.Hard, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "GlassedSun_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup("Miriam_EN", "GlassedSun_EN", "Shua_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "GlassedSun_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "GlassedSun_EN", Enemies.Shivering, Enemies.Shivering);

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "GlassedSun_EN", "LittleAngel_EN");
        }
    }
}
