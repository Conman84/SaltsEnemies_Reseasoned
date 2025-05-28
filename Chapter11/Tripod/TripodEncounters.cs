using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class TripodEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_TripodEncounter_Sign", ResourceLoader.LoadSprite("TripodWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.Tripod.Hard, "Salt_TripodEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/NewTripodTheme";
            hard.RoarEvent = "event:/Hawthorne/Roar/ShuaRoar";

            hard.AddRandomEncounter("Tripod_EN", "MudLung_EN", "MudLung_EN", "LostSheep_EN");
            hard.AddRandomEncounter("Tripod_EN", Jumble.Yellow, Jumble.Red, "Flarblet_EN");
            hard.AddRandomEncounter("Tripod_EN", Jumble.Yellow, Jumble.Red);
            hard.AddRandomEncounter("Tripod_EN", Spoggle.Yellow, "FlaMinGoa_EN");
            hard.AddRandomEncounter("Tripod_EN", Spoggle.Blue, "FlaMinGoa_EN");
            hard.AddRandomEncounter("Tripod_EN", Jumble.Yellow, "Flarblet_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("Tripod_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomEncounter("Tripod_EN", "FlaMinGoa_EN", "MudLung_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Tripod.Hard, 15, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Hard);
        }
        public static void Add_Hardmode()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Tripod.Hard, "Salt_TripodEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/NewTripodTheme";
            hard.RoarEvent = "event:/Hawthorne/Roar/ShuaRoar";

            hard.AddRandomEncounter("Tripod_EN", "MudLung_EN", "MudLung_EN", "LostSheep_EN");
            hard.AddRandomEncounter("Tripod_EN", Jumble.Yellow, Jumble.Red, "MudLung_EN");
            hard.AddRandomEncounter("Tripod_EN", "FlaMinGoa_EN", Enemies.Mungling, "LostSheep_EN");
            hard.AddRandomEncounter("Tripod_EN", Spoggle.Blue, Spoggle.Yellow, "MudLung_EN");
            hard.AddRandomEncounter("Tripod_EN", Enemies.Mungling, "MudLung_EN", "MudLung_EN");
            hard.AddRandomEncounter("Tripod_EN", "FlaMinGoa_EN", "AFlower_EN");
            hard.AddRandomEncounter("Tripod_EN", "AFlower_EN", Enemies.Mungling, "Flarblet_EN");
            hard.SimpleAddEncounter(1, "Tripod_EN", 4, "Keko_EN");
            hard.AddRandomEncounter("Tripod_EN", Jumble.Yellow, "Flarblet_EN", "FlaMinGoa_EN");
            hard.SimpleAddEncounter(1, "Tripod_EN", 2, "DeadPixel_EN", 1, "FlaMinGoa_EN");
            hard.SimpleAddEncounter(1, "Tripod_EN", 2, "DeadPixel_EN", 1, Enemies.Mungling);
            hard.AddRandomEncounter("Tripod_EN", "AFlower_EN", "FlaMinGoa_EN", "Skyloft_EN");
            hard.AddRandomEncounter("Tripod_EN", Enemies.Camera, "FlaMinGoa_EN", "LostSheep_EN");
            hard.AddRandomEncounter("Tripod_EN", Enemies.Camera, "AFlower_EN", "LostSheep_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Tripod.Hard, 15, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
