
using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ChiitoEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ChiitoEncounter_Sign", ResourceLoader.LoadSprite("ChiitoWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Chiito.Med, "Salt_ChiitoEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ChiitoTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle")._roarReference.roarEvent;

            med.AddRandomEncounter("Chiito_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomEncounter("Chiito_EN", "ToyUfo_EN", "MudLung_EN");
            med.AddRandomEncounter("Chiito_EN", "2009_EN", "Pinano_EN");
            med.AddRandomEncounter("Chiito_EN", "MudLung_EN", "MudLung_EN", "Mung_EN");
            med.AddRandomEncounter("Chiito_EN", Jumble.Yellow, Jumble.Red, "Skyloft_EN");
            med.AddRandomEncounter("Chiito_EN", Spoggle.Blue, "Pinano_EN");
            med.AddRandomEncounter("Chiito_EN", Spoggle.Yellow, "ToyUfo_EN");
            med.AddRandomEncounter("Chiito_EN", Enemies.Mungling, "NobodyGrave_EN");
            med.AddRandomEncounter("Chiito_EN", "DeadPixel_EN", "DeadPixel_EN", "MudLung_EN");
            med.AddRandomEncounter("Chiito_EN", Jumble.Yellow, "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomEncounter("Chiito_EN", Jumble.Red, "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomEncounter("Chiito_EN", "Wringle_EN", "2009_EN", "Wringle_EN");
            med.AddRandomEncounter("Chiito_EN", "LittleBeak_EN", "Arceles_EN");
            med.AddRandomEncounter("Chiito_EN", "Flarblet_EN", "Flarblet_EN", "Flarblet_EN");
            med.AddRandomEncounter("Chiito_EN", "FlaMinGoa_EN", "LostSheep_EN");
            med.AddRandomEncounter("Chiito_EN", Jumble.Yellow, "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("Chiito_EN", Jumble.Red, "Pinano_EN", "Minana_EN");
            med.AddRandomEncounter("Chiito_EN", "ToyUfo_EN", "Skyloft_EN", "Pinano_EN");
            med.AddRandomEncounter("Chiito_EN", "Windle_EN", "Wringle_EN", "MudLung_EN");
            med.AddRandomEncounter("Chiito_EN", Enemies.Mungling, "Arceles_EN");
            med.AddRandomEncounter("Chiito_EN", "Pinano_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomEncounter("Chiito_EN", "Flarblet_EN", "LittleBeak_EN", "LostSheep_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Chiito.Med, 25, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "MudLung_EN", "Chiito_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Sinker_EN", "Chiito_EN");

            AddTo easy = new AddTo(Shore.H.Skyloft.Easy);
            easy.AddRandomGroup("Skyloft_EN", "Chiito_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Chiito_EN", "ToyUfo_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Keko_EN", "Keko_EN", "Chiito_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Chiito_EN", "NobodyGrave_EN");
            med.AddRandomGroup("LittleBeak_EN", "Chiito_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Chiito_EN", "AFlower_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Chiito_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "2009_EN", "Chiito_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Chiito_EN", "Flarblet_EN");
            med.AddRandomGroup("Sinker_EN", "Chiito_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", Enemies.Mungling, "Chiito_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "Chiito_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "Chiito_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "Chiito_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Chiito_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "Chiito_EN", "LittleBeak_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Chiito_EN");
            hard.AddRandomGroup("Flarb_EN", "Chiito_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Chiito_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "Chiito_EN");
        }
    }
}
