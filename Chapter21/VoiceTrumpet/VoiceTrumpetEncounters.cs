using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class VoiceTrumpetEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Med();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_VoiceTrumpetEncounter_Sign", ResourceLoader.LoadSprite("TrumpetWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Trumpet.Easy, "Salt_VoiceTrumpetEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/TrumpetTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemy("VoiceTrumpet_EN").deathSound;

            easy.SimpleAddEncounter(2, "VoiceTrumpet_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "Keko_EN", "Keko_EN");
            easy.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "LostSheep_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "MudLung_EN", "Arceles_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", Jumble.Yellow, "NobodyGrave_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", Jumble.Red, "Wall_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "VoiceTrumpet_EN", "Skyloft_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "Wall_EN", "MudLung_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "Keko_EN", "Arceles_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "Waltz_EN", "Waltz_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "MudLung_EN", "MudLung_EN");
            easy.AddRandomEncounter("VoiceTrumpet_EN", "Wall_EN", "LostSheep_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Trumpet.Easy, 8, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Trumpet.Med, "Salt_VoiceTrumpetEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/TrumpetTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("VoiceTrumpet_EN").deathSound;

            med.SimpleAddEncounter(3, "VoiceTrumpet_EN");
            med.SimpleAddEncounter(3, "VoiceTrumpet_EN", 1, "Minana_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 2, "Keko_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 2, "DeadPixel_EN");
            med.SimpleAddEncounter(3, "VoiceTrumpet_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 2, "Wall_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "MudLung_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, Jumble.Yellow);
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, Jumble.Red);
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "Pinano_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 2, "MudLung_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "MudLung_EN", 1, "Wall_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "MudLung_EN", 1, "NobodyGrave_EN");
            med.SimpleAddEncounter(1, "VoiceTrumpet_EN", 3, "Keko_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "Arceles_EN", 1, "Wall_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "2009_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 1, "Wringle_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(2, "VoiceTrumpet_EN", 2, "Waltz_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Trumpet.Med, 12, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.SimpleAddGroup(2, "DeadPixel_EN", 1, "VoiceTrumpet_EN");

            easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN");
            easy.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", "LostSheep_EN");
            easy.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", "Minana_EN");
            easy.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", "MudLung_EN");

            AddTo med = new AddTo(Shore.H.DeadPixel.Med);
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, "VoiceTrumpet_EN", 1, "MudLung_EN");
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, "VoiceTrumpet_EN", 1, "Windle_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.SimpleAddGroup(2, "Pinano_EN", 1, "VoiceTrumpet_EN");
            med.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", Jumble.Yellow);
            med.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", Jumble.Red, "LostSheep_EN");
            med.AddRandomGroup("Pinano_EN", "MudLung_EN", "VoiceTrumpet_EN", "Skyloft_EN");
            med.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", Spoggle.Blue);
            med.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", Spoggle.Yellow);
            med.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", "Keko_EN", "Keko_EN");
            med.AddRandomGroup("Pinano_EN", "VoiceTrumpet_EN", "Wall_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Wall.Med);
            med.SimpleAddGroup(3, "Wall_EN", 1, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", "Pinano_EN");
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", Jumble.Yellow);
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", Jumble.Red);
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", "MudLung_EN", "Arceles_EN");
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", Spoggle.Yellow);
            med.AddRandomGroup("ToyUfo_EN", "VoiceTrumpet_EN", Spoggle.Blue);

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("2009_EN", "2009_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("2009_EN", "DeadPixel_EN", "DeadPixel_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("2009_EN", "VoiceTrumpet_EN", "Keko_EN", "Keko_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "VoiceTrumpet_EN", "Chiito_EN");
            med.AddRandomGroup("LittleBeak_EN", "VoiceTrumpet_EN", "Pinano_EN");
            med.AddRandomGroup("LittleBeak_EN", "VoiceTrumpet_EN", Spoggle.Blue);
            med.AddRandomGroup("LittleBeak_EN", "VoiceTrumpet_EN", Spoggle.Yellow);
            med.AddRandomGroup("LittleBeak_EN", "VoiceTrumpet_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("LittleBeak_EN", "VoiceTrumpet_EN", "ToyUfo_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.SimpleAddGroup(1, "Chiito_EN", 3, "VoiceTrumpet_EN");
            med.AddRandomGroup("Chiito_EN", "VoiceTrumpet_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomGroup("Chiito_EN", "VoiceTrumpet_EN", "Pinano_EN", "LostSheep_EN");
            med.AddRandomGroup("Chiito_EN", "VoiceTrumpet_EN", "ToyUfo_EN");
            med.AddRandomGroup("Chiito_EN", "VoiceTrumpet_EN", Jumble.Red, Jumble.Yellow);

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", "Wall_EN");
            med.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", Enemies.Mungling);
            med.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", "Keko_EN", "Keko_EN");
            med.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", "MudLung_EN", "Windle_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("Sinker_EN", "VoiceTrumpet_EN", "Windle_EN", "MudLung_EN");
            med.AddRandomGroup("Sinker_EN", "VoiceTrumpet_EN", "ToyUfo_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", "Wall_EN");
            med.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", Jumble.Red, "NobodyGrave_EN");
            med.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", Jumble.Yellow);
            med.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", "2009_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.SimpleAddGroup(1, "AFlower_EN", 3, "VoiceTrumpet_EN");
            hard.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", "Sinker_EN");
            hard.AddRandomGroup("AFlower_EN", "VoiceTrumpet_EN", Jumble.Red, Jumble.Yellow);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "VoiceTrumpet_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Sinker_EN", "VoiceTrumpet_EN", Spoggle.Yellow, Spoggle.Blue);
            hard.AddRandomGroup("Sinker_EN", "VoiceTrumpet_EN", "Pinano_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", "Sinker_EN");
            hard.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", "ToyUfo_EN", "2009_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN", "LostSheep_EN");
            hard.AddRandomGroup("Warbird_EN", "VoiceTrumpet_EN", Enemies.Camera, "Skyloft_EN");
            hard.AddRandomGroup("Warbird_EN", "VoiceTrumpet_EN", "FlaMinGoa_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Camera, "VoiceTrumpet_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup(Enemies.Camera, "VoiceTrumpet_EN", "Pinano_EN", "Sinker_EN");
            hard.AddRandomGroup(Enemies.Camera, "VoiceTrumpet_EN", "Wall_EN", Jumble.Yellow);

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "VoiceTrumpet_EN", "Sinker_EN");
            hard.AddRandomGroup("Tripod_EN", "VoiceTrumpet_EN", Enemies.Camera);
            hard.AddRandomGroup("Tripod_EN", "VoiceTrumpet_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", Enemies.Camera, "VoiceTrumpet_EN");
            hard.AddRandomGroup("33_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN", "Arceles_EN");
            hard.AddRandomGroup("33_EN", "VoiceTrumpet_EN", "FlaMinGoa_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "VoiceTrumpet_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "VoiceTrumpet_EN", "LostSheep_EN");
            easy.AddRandomGroup(Enemies.Mungling, "VoiceTrumpet_EN", "Windle_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "MudLung_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup(Enemies.Mungling, "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup(Enemies.Mungling, "VoiceTrumpet_EN", "Pinano_EN");
            med.AddRandomGroup(Enemies.Mungling, "VoiceTrumpet_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup(Enemies.Mungling, "VoiceTrumpet_EN", Spoggle.Blue);

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "VoiceTrumpet_EN");
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "VoiceTrumpet_EN", "LostSheep_EN");
            med.AddRandomGroup(Jumble.Yellow, "VoiceTrumpet_EN", "Pinano_EN");
            med.AddRandomGroup(Jumble.Yellow, "VoiceTrumpet_EN", "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "VoiceTrumpet_EN");
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "VoiceTrumpet_EN", "TortureMeNot_EN");
            med.AddRandomGroup(Jumble.Red, "VoiceTrumpet_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomGroup(Jumble.Red, "VoiceTrumpet_EN", "Pinano_EN", "TortureMeNot_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "VoiceTrumpet_EN");
            med.AddRandomGroup(Spoggle.Yellow, "VoiceTrumpet_EN", "Pinano_EN");
            med.AddRandomGroup(Spoggle.Yellow, "VoiceTrumpet_EN", "ToyUfo_EN");
            med.AddRandomGroup(Spoggle.Yellow, "VoiceTrumpet_EN", "2009_EN");
            med.AddRandomGroup(Spoggle.Yellow, "VoiceTrumpet_EN", "Chiito_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "VoiceTrumpet_EN");
            med.AddRandomGroup(Spoggle.Blue, "VoiceTrumpet_EN", "Pinano_EN");
            med.AddRandomGroup(Spoggle.Blue, "VoiceTrumpet_EN", "ToyUfo_EN");
            med.AddRandomGroup(Spoggle.Blue, "VoiceTrumpet_EN", "2009_EN");
            med.AddRandomGroup(Spoggle.Blue, "VoiceTrumpet_EN", "Chiito_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", Enemies.Mungling);
            med.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "Arceles_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "ToyUfo_EN");

            med = new AddTo(Shore.H.Keko.Med);
            med.SimpleAddGroup(3, "Keko_EN", 1, "VoiceTrumpet_EN");
            med.SimpleAddGroup(3, "Keko_EN", 1, "VoiceTrumpet_EN", 1, "LostSheep_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "LittleBeak_EN");
            hard.AddRandomGroup("FlaminGoa_EN", "VoiceTrumpet_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "AFlower_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN", "Windle_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "VoiceTrumpet_EN", "Wringle_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            hard.AddRandomGroup("Flarb_EN", "VoiceTrumpet_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "VoiceTrumpet_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "VoiceTrumpet_EN");
            hard.AddRandomGroup("Voboola_EN", "VoiceTrumpet_EN", "LostSheep_EN");
            hard.AddRandomGroup("Voboola_EN", "VoiceTrumpet_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "VoiceTrumpet_EN");
        }
    }
}
