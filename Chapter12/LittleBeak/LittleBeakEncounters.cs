using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class LittleBeakEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_LittleBeakEncounter_Sign", ResourceLoader.LoadSprite("BeakWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.LittleBeak.Med, "Salt_LittleBeakEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LittleBeakSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Kekastle_EN").deathSound;

            med.AddRandomEncounter("LittleBeak_EN", "LittleBeak_EN", "LostSheep_EN");
            med.AddRandomEncounter("LittleBeak_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("LittleBeak_EN", "MudLung_EN", Jumble.Yellow);
            med.AddRandomEncounter("LittleBeak_EN", Spoggle.Blue, Spoggle.Yellow);
            med.AddRandomEncounter("LittleBeak_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomEncounter("LittleBeak_EN", Enemies.Mungling, "MudLung_EN");
            med.AddRandomEncounter("LittleBeak_EN", Enemies.Mungling, "Skyloft_EN");
            med.AddRandomEncounter("LittleBeak_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomEncounter("LittleBeak_EN", "LittleBeak_EN", "Wringle_EN");
            med.AddRandomEncounter("LittleBeak_EN", Spoggle.Yellow, "MudLung_EN", "LostSheep_EN");
            med.AddRandomEncounter("LittleBeak_EN", Spoggle.Blue, "MudLung_EN", "LostSheep_EN");
            med.AddRandomEncounter("LittleBeak_EN", "MudLung_EN", "MudLung_EN", "Flarblet_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.LittleBeak.Med, 25, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "LittleBeak_EN", Jumble.Yellow);
            med.AddRandomGroup("AFlower_EN", "LittleBeak_EN", Jumble.Red);
            med.AddRandomGroup("AFlower_EN", "LittleBeak_EN", "LostSheep_EN");
            med.AddRandomGroup("AFlower_EN", "LittleBeak_EN", "MudLung_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", Spoggle.Yellow);
            hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", Spoggle.Blue);
            hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", Enemies.Mungling);

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "LittleBeak_EN", "LittleBeak_EN", "Skyloft_EN");
            hard.AddRandomGroup(Enemies.Camera, "LittleBeak_EN", "FlaMinGoa_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "LittleBeak_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Tripod_EN", "LittleBeak_EN", "FlaMinGoa_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", Jumble.Yellow);
            med.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", "Wringle_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", Spoggle.Yellow);
            hard.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", Spoggle.Blue);
            hard.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", Enemies.Mungling);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Flarb_EN", "Flarblet_EN", "LittleBeak_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "LittleBeak_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "LittleBeak_EN");
        }
    }
}
