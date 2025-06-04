using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PinanoEncounters
    {
        public static void Add()
        {
            Add_Med_Normal();
            Add_Easy_Hardmode();
            Add_Med_Hardmode();
        }
        public static void Add_Med_Normal()
        {
            Portals.AddPortalSign("Salt_PinanoEncounter_Sign", ResourceLoader.LoadSprite("PinanoWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.Pinano.Med, "Salt_PinanoEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PinanoThemeNew";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent;

            med.SimpleAddEncounter(2, "Pinano_EN");
            med.AddRandomEncounter("Pinano_EN", "MudLung_EN");
            med.AddRandomEncounter("MudLung_EN", "MudLung_EN", "Pinano_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Mung_EN");
            med.AddRandomEncounter("Pinano_EN", Jumble.Red);
            med.AddRandomEncounter("Pinano_EN", Jumble.Yellow);
            med.AddRandomEncounter("Pinano_EN", "MudLung_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "LostSheep_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Flarblet_EN");
            med.AddRandomEncounter("Pinano_EN", "MudLung_EN", "LostSheep_EN");
            med.AddRandomEncounter("Pinano_EN", "MudLung_EN", "Minana_EN");
            med.SimpleAddEncounter(1, "Pinano_EN", 3, "Minana_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Pinano.Med, 20, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Easy_Hardmode()
        {
            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Pinano.Easy, "Salt_PinanoEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/PinanoThemeNew";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.SimpleAddEncounter(2, "Pinano_EN");
            easy.AddRandomEncounter("Pinano_EN", "MudLung_EN");
            easy.AddRandomEncounter("MudLung_EN", "MudLung_EN", "Pinano_EN");
            easy.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Mung_EN");
            easy.AddRandomEncounter("Pinano_EN", Jumble.Red);
            easy.AddRandomEncounter("Pinano_EN", Jumble.Yellow);
            easy.AddRandomEncounter("Pinano_EN", "MudLung_EN");
            easy.AddRandomEncounter("Pinano_EN", "Pinano_EN", "LostSheep_EN");
            easy.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Flarblet_EN");
            easy.AddRandomEncounter("Pinano_EN", "MudLung_EN", "LostSheep_EN");
            easy.AddRandomEncounter("Pinano_EN", "MudLung_EN", "Minana_EN");
            easy.SimpleAddEncounter(1, "Pinano_EN", 3, "Minana_EN");
            easy.AddRandomEncounter("Pinano_EN", "Keko_EN", "Keko_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Pinano.Easy, 8, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med_Hardmode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Pinano.Med, "Salt_PinanoEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PinanoThemeNew";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent;

            med.SimpleAddEncounter(3, "Pinano_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "MudLung_EN");
            med.SimpleAddEncounter(3, "Pinano_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(3, "Pinano_EN", 1, "Flarblet_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Minana_EN", "Minana_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", Jumble.Red);
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", Jumble.Yellow);
            med.SimpleAddEncounter(2, "Pinano_EN", 2, "DeadPixel_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", Enemies.Mungling);
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", Spoggle.Yellow);
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", Spoggle.Blue);
            med.SimpleAddEncounter(2, "Pinano_EN", 2, "Keko_EN");
            med.SimpleAddEncounter(3, "Pinano_EN", 1, "Skyloft_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Windle_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "MudLung_EN", "MudLung_EN");
            med.SimpleAddEncounter(1, "Pinano_EN", 3, "Minana_EN");
            med.AddRandomEncounter("Pinano_EN", "Pinano_EN", "Arceles_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Pinano.Med, 20, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN");

            AddTo med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", "Minana_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", Jumble.Yellow);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", Jumble.Red);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", "Flarblet_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", "LostSheep_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Pinano_EN", "Arceles_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup("AFlower_EN", "Pinano_EN", "Minana_EN");
            med.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup("AFlower_EN", "Pinano_EN", "LostSheep_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("AFlower_EN", "Pinano_EN", Jumble.Yellow);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("AFlower_EN", "Pinano_EN", Jumble.Red);

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Keko_EN", "Keko_EN");
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN", "Minana_EN");
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN", "Skyloft_EN");
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN", "LostSheep_EN");
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN", "Flarblet_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("AFlower_EN", "Pinano_EN", Spoggle.Yellow);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("AFlower_EN", "Pinano_EN", Spoggle.Blue);
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", Enemies.Mungling);
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "LittleBeak_EN");
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN", "Arceles_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.SimpleAddGroup(1, Enemies.Camera, 3, "Pinano_EN");
            hard.SimpleAddGroup(2, Enemies.Camera, 2, "Pinano_EN");
            hard.AddRandomGroup(Enemies.Camera, "Pinano_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup(Enemies.Camera, "Pinano_EN", "Pinano_EN", Enemies.Mungling);
            hard.AddRandomGroup(Enemies.Camera, "Pinano_EN", "Pinano_EN", "MudLung_EN");
            hard.AddRandomGroup(Enemies.Camera, "Pinano_EN", Enemies.Mungling, "MudLung_EN");
            hard.AddRandomGroup(Enemies.Camera, "Pinano_EN", "Clione_EN");

            hard = new AddTo(Shore.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Pinano_EN", "MudLung_EN");
            hard.AddRandomGroup("Tripod_EN", "Pinano_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Tripod_EN", "Pinano_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomGroup("Tripod_EN", "Pinano_EN", Enemies.Mungling);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Tripod_EN", "Pinano_EN", Spoggle.Blue);
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Tripod_EN", "Pinano_EN", Spoggle.Yellow);
            hard.AddRandomGroup("Tripod_EN", "Pinano_EN", "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "Pinano_EN", "Minana_EN");
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "Pinano_EN", "Skyloft_EN");
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "Pinano_EN", "LostSheep_EN");
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "Pinano_EN", "Flarblet_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", Spoggle.Yellow);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", Spoggle.Blue);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", Jumble.Yellow);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", Jumble.Red);
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", Enemies.Mungling);
            med.AddRandomGroup("LittleBeak_EN", "LittleBeak_EN", "Pinano_EN");
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "Windle_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Keko_EN", "Keko_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Pinano_EN", "Minana_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Pinano_EN", "Skyloft_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Pinano_EN", "LostSheep_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Pinano_EN", "Flarblet_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Warbird_EN", "Pinano_EN", Spoggle.Yellow);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Warbird_EN", "Pinano_EN", Spoggle.Blue);
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", Enemies.Mungling);
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "AFlower_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", "Clione_EN");
            hard.AddRandomGroup("Warbird_EN", "Pinano_EN", Enemies.Camera, "LostSheep_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup("Clione_EN", "Pinano_EN", Enemies.Mungling);
            med.AddRandomGroup("Clione_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup("Clione_EN", "Pinano_EN", "Flarblet_EN");
            med.AddRandomGroup("Clione_EN", "Pinano_EN", Jumble.Red);
            med.AddRandomGroup("Clione_EN", "Pinano_EN", Jumble.Yellow);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Pinano_EN", "Minana_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Pinano_EN", "Skyloft_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Pinano_EN", "LostSheep_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Pinano_EN", "Flarblet_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Clione_EN", "Pinano_EN", Spoggle.Yellow);
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Clione_EN", "Pinano_EN", Spoggle.Blue);
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", Enemies.Mungling);
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "AFlower_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Windle_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Pinano_EN", "Arceles_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "Pinano_EN");
            easy.AddRandomGroup(Enemies.Mungling, "Minana_EN", "Minana_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Enemies.Mungling, "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup(Enemies.Mungling, "Pinano_EN", Jumble.Yellow);
            med.AddRandomGroup(Enemies.Mungling, "Pinano_EN", Jumble.Red);

            med = new AddTo(Shore.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "Pinano_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "Pinano_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Spoggle.Yellow, "Pinano_EN", "Arceles_EN");

            med = new AddTo(Shore.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "Pinano_EN", "MudLung_EN");
            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "Pinano_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Spoggle.Blue, "Pinano_EN", "Arceles_EN");

            med = new AddTo(Shore.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", Jumble.Yellow);
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "MudLung_EN");
            med.SimpleAddGroup(1, "FlaMinGoa_EN", 3, "Minana_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", Jumble.Yellow);
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Keko_EN", "Keko_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", Enemies.Mungling);
            hard.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "LittleBeak_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Pinano_EN", "Arceles_EN");

            hard = new AddTo(Shore.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN");
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "Arceles_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Pinano_EN", "Minana_EN");
            hard.AddRandomGroup("Voboola_EN", "Pinano_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "Pinano_EN");
            hard.AddRandomGroup("Kekastle_EN", "Pinano_EN", "Pinano_EN");
        }
    }
}
