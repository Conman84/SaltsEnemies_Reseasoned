using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class KyotlokutlaEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_KyotlokutlaEncounter_Sign", ResourceLoader.LoadSprite("SnakeGodWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.SnakeGod.Hard, "Salt_KyotlokutlaEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/SnakeGodTheme";
            hard.RoarEvent = "event:/Hawthorne/Die/XylophoneDie";

            hard.SimpleAddEncounter(1, "SnakeGod_EN", 3, "NextOfKin_EN");
            hard.AddRandomEncounter("SnakeGod_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("SnakeGod_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomEncounter("SnakeGod_EN", Enemies.Camera, Enemies.Camera);
            hard.AddRandomEncounter("SnakeGod_EN", Flower.Red);
            hard.AddRandomEncounter("SnakeGod_EN", Flower.Blue);
            hard.AddRandomEncounter("SnakeGod_EN", Enemies.Minister);
            hard.AddRandomEncounter("SnakeGod_EN", "WindSong_EN", "MiniReaper_EN");
            hard.AddRandomEncounter("SnakeGod_EN", "Skyloft_EN", "Merced_EN");
            hard.AddRandomEncounter("SnakeGod_EN", "Grandfather_EN", Jumble.Grey);
            hard.AddRandomEncounter("SnakeGod_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomEncounter("SnakeGod_EN", "Shua_EN");
            hard.SimpleAddEncounter(1, "SnakeGod_EN", 3, "Damocles_EN");
            hard.AddRandomEncounter("SnakeGod_EN", "ClockTower_EN");
            hard.AddRandomEncounter("SnakeGod_EN", Enemies.Skinning);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.SnakeGod.Hard, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
