using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WallEncounters
    {
        public static void Add()
        {
            Add_Med_Normal();
            Add_Easy_Hardmode();
            Add_Med_Hardmode();
        }
        public static void Add_Med_Normal()
        {
            Portals.AddPortalSign("Salt_WallEncounter_Sign", ResourceLoader.LoadSprite("WallWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.Wall.Med, "Salt_WallEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/WallTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            med.SimpleAddEncounter(2, "Wall_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "Flarblet_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "NobodyGrave_EN");
            med.AddRandomEncounter("Wall_EN", "Keko_EN", "Keko_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "Keko_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(1, "Wall_EN", 4, "Mung_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Wall.Med, 10, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Easy_Hardmode()
        {
            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Wall.Easy, "Salt_WallEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/WallTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            easy.SimpleAddEncounter(2, "Wall_EN");
            easy.SimpleAddEncounter(2, "Wall_EN", 1, "Flarblet_EN");
            easy.SimpleAddEncounter(2, "Wall_EN", 1, "NobodyGrave_EN");
            easy.AddRandomEncounter("Wall_EN", "Keko_EN", "Keko_EN");
            easy.SimpleAddEncounter(2, "Wall_EN", 1, "Keko_EN");
            easy.SimpleAddEncounter(2, "Wall_EN", 1, "LostSheep_EN");
            if (SaltsReseasoned.trolling < 50) easy.SimpleAddEncounter(1, "Wall_EN", 4, "Mung_EN");
            easy.SimpleAddEncounter(2, "Wall_EN", 1, "Skyloft_EN");
            easy.SimpleAddEncounter(2, "Wall_EN", 1, "Arceles_EN");
            easy.AddRandomEncounter("Wall_EN", "Windle_EN");
            easy.AddRandomEncounter("Wall_EN", "Wall_EN", "TortureMeNot_EN");
            if (SaltsReseasoned.trolling > 50) easy.SimpleAddEncounter(1, "Wall_EN", 3, "Minana_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Wall.Easy, 7, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med_Hardmode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Wall.Med, "Salt_WallEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/WallTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            med.SimpleAddEncounter(3, "Wall_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 2, "Keko_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 2, "DeadPixel_EN");
            med.SimpleAddEncounter(3, "Wall_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "Arceles_EN");
            med.SimpleAddEncounter(3, "Wall_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(3, "Wall_EN", 1, "NobodyGrave_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 3, "TortureMeNot_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "Wringle_EN");
            med.AddRandomEncounter("Wall_EN", "Wall_EN", "Chiito_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Wall.Med, 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Wall_EN");

            AddTo med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Wall_EN", "MudLung_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Wall_EN", Jumble.Yellow);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Wall_EN", Jumble.Red);

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("AFlower_EN", "Wall_EN", "Pinano_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.SimpleAddGroup(1, "AFlower_EN", 3, "Wall_EN");
            hard.AddRandomGroup("AFlower_EN", "Wall_EN", "Wall_EN", "LostSheep_EN");
            hard.AddRandomGroup("AFlower_EN", "Wall_EN", Enemies.Mungling);
            hard.AddRandomGroup("AFlower_EN", "Wall_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("AFlower_EN", "Wall_EN", "Wall_EN", "Chiito_EN");

            easy = new AddTo(Shore.H.Skyloft.Easy);
            easy.AddRandomGroup("Skyloft_EN", "Wall_EN", "Wall_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.SimpleAddGroup(2, Enemies.Camera, 3, "Wall_EN");
            hard.AddRandomGroup(Enemies.Camera, "Wall_EN", "Sinker_EN", "ToyUfo_EN");
            hard.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Wall_EN", "Chiito_EN");

            hard = new AddTo(Shore.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Wall_EN", "Wall_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Wall_EN", "Wall_EN", "LostSheep_EN");
            hard.AddRandomGroup("Tripod_EN", "Wall_EN", "Clione_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Wall_EN", "Wall_EN", "Minana_EN");
            med.AddRandomGroup("LittleBeak_EN", "Wall_EN", "Pinano_EN");
            med.AddRandomGroup("LittleBeak_EN", "Wall_EN", Spoggle.Blue);
            med.AddRandomGroup("LittleBeak_EN", "Wall_EN", Spoggle.Yellow);
            med.SimpleAddGroup(1, "LittleBeak_EN", 3, "Wall_EN");
            med.AddRandomGroup("LittleBeak_EN", "Wall_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomGroup("LittleBeak_EN", "Wall_EN", "2009_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.SimpleAddGroup(1, "Warbird_EN", 3, "Wall_EN");
            hard.AddRandomGroup("Warbird_EN", "Wall_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Warbird_EN", "Wall_EN", "Wall_EN", "ToyUfo_EN");

            easy = new AddTo(Shore.H.Windle.Easy);
            easy.AddRandomGroup("Windle_EN", "Wall_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("Clione_EN", "Wall_EN", Jumble.Red);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Wall_EN", "Wall_EN", "Arceles_EN");
            hard.AddRandomGroup("Clione_EN", "Wall_EN", "Sinker_EN");
            hard.AddRandomGroup("Clione_EN", "Wall_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Clione_EN", "Wall_EN", "Wall_EN", Enemies.Mungling);

            easy = new AddTo(Shore.H.Arceles.Easy);
            easy.AddRandomGroup("Arceles_EN", "Wall_EN", "Wall_EN");

            med = new AddTo(Shore.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Wall_EN");
            med.AddRandomGroup("Pinano_EN", "Wall_EN", "LostSheep_EN");
            med.AddRandomGroup("Pinano_EN", "Wall_EN", Jumble.Yellow);

            easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Pinano_EN", "Wall_EN", "Wall_EN");
            easy.AddRandomGroup("Pinano_EN", "Wall_EN", "Pinano_EN");
            easy.AddRandomGroup("Pinano_EN", "Wall_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Wall_EN", Jumble.Yellow);
            med.SimpleAddGroup(2, "Pinano_EN", 2, "Wall_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Wall_EN", "LostSheep_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Wall_EN", "Windle_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Wall_EN", "NobodyGrave_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Wall_EN", "Chiito_EN");

            easy = new AddTo(Shore.Grave.Easy);
            easy.AddRandomGroup("NobodyGrave_EN", "Wall_EN", "Wall_EN");

            easy = new AddTo(Shore.H.Grave.Easy);
            easy.AddRandomGroup("NobodyGrave_EN", "Wall_EN", "Wall_EN");
            easy.AddRandomGroup("NobodyGrave_EN", "Wall_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            med = new AddTo(Shore.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", Jumble.Yellow);
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.SimpleAddGroup(1, "ToyUfo_EN", 3, "Wall_EN");
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "Wall_EN", "LostSheep_EN");
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "Wall_EN", Jumble.Yellow);
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "Pinano_EN", "LostSheep_EN");
            med.AddRandomGroup("ToyUfo_EN", "Wall_EN", "Wall_EN", Jumble.Red);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "ToyUfo_EN", "Wall_EN");
            med.AddRandomGroup("Sinker_EN", "2009_EN", "Wall_EN");
            med.AddRandomGroup("Sinker_EN", "Pinano_EN", "Wall_EN");
            med.AddRandomGroup("Sinker_EN", Jumble.Yellow, "Wall_EN");
            med.AddRandomGroup("Sinker_EN", Spoggle.Yellow, "Wall_EN");
            med.AddRandomGroup("Sinker_EN", "Chiito_EN", "Wall_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "LittleBeak_EN", "Wall_EN");
            hard.AddRandomGroup("Sinker_EN", "FlaMinGoa_EN", "Wall_EN");
            hard.AddRandomGroup("Sinker_EN", "AFlower_EN", "Wall_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("2009_EN", "Wall_EN", Jumble.Yellow);
            med.AddRandomGroup("2009_EN", "Wall_EN", Jumble.Red);
            med.AddRandomGroup("2009_EN", "Wall_EN", "MudLung_EN", "Flarblet_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.SimpleAddGroup(1, "Chiito_EN", 3, "Wall_EN");
            med.AddRandomGroup("Chiito_EN", "Wall_EN", "Wall_EN", "Pinano_EN");
            med.AddRandomGroup("Chiito_EN", "Wall_EN", "ToyUfo_EN", "Flarblet_EN");
            med.AddRandomGroup("Chiito_EN", "Wall_EN", "2009_EN", "LostSheep_EN");
            med.AddRandomGroup("Chiito_EN", "Wall_EN", "Wall_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup("Unmung_EN", "Wall_EN");

            easy = new AddTo(Shore.MudLung.Easy);
            easy.AddRandomGroup("MudLung_EN", "Wall_EN");

            med = new AddTo(Shore.MudLung.Med);
            med.AddRandomGroup("MudLung_EN", "MudLung_EN", "Wall_EN");
            med.AddRandomGroup("MudLung_EN", "Wall_EN", "LostSheep_EN");

            easy = new AddTo(Shore.H.MudLung.Easy);
            easy.AddRandomGroup("MudLung_EN", "MudLung_EN", "Wall_EN");
            easy.AddRandomGroup("MudLung_EN", "Wall_EN");
            easy.AddRandomGroup("MudLung_EN", "Wall_EN", "LostSheep_EN");
            easy.AddRandomGroup("MudLung_EN", "Wall_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.MudLung.Med);
            med.SimpleAddGroup(2, "MudLung_EN", 2, "Wall_EN");
            med.AddRandomGroup("MudLung_EN", "MudLung_EN", "Wall_EN", "NobodyGrave_EN");
            med.AddRandomGroup("MudLung_EN", "MudLung_EN", "Wall_EN", Jumble.Yellow);
            med.AddRandomGroup("MudLung_EN", "MudLung_EN", "Wall_EN", Jumble.Red);

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "Wall_EN");
            easy.AddRandomGroup(Enemies.Mungling, "Wall_EN", "Flarblet_EN");
            easy.AddRandomGroup(Enemies.Mungling, "Wall_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "Wall_EN", "Wall_EN");
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "Wall_EN");
            med.AddRandomGroup(Enemies.Mungling, "Pinano_EN", "Wall_EN");
            med.SimpleAddGroup(1, Enemies.Mungling, 3, "Wall_EN");

            easy = new AddTo(Shore.Jumble.Red.Easy);
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup(Jumble.Red, "Wall_EN");

            med = new AddTo(Shore.Jumble.Red.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Wall_EN");

            easy = new AddTo(Shore.Jumble.Yellow.Easy);
            if (SaltsReseasoned.silly < 50) easy.AddRandomGroup(Jumble.Yellow, "Wall_EN");

            med = new AddTo(Shore.Jumble.Yellow.Med);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Wall_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Wall_EN");
            med.AddRandomGroup(Jumble.Red, "Wall_EN", "Wall_EN", "MudLung_EN");
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Wall_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Wall_EN");
            med.AddRandomGroup(Jumble.Yellow, "Wall_EN", "Wall_EN", "MudLung_EN");
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Wall_EN", "Skyloft_EN");

            med = new AddTo(Shore.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "Wall_EN", "Wall_EN");

            med = new AddTo(Shore.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "Wall_EN", "Wall_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "Wall_EN");
            med.AddRandomGroup(Spoggle.Yellow, "Wall_EN", "Wall_EN");
            med.AddRandomGroup(Spoggle.Yellow, "Wall_EN", "Wall_EN", "Flarblet_EN");
            med.AddRandomGroup(Spoggle.Yellow, "2009_EN", "Wall_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "Wall_EN");
            med.AddRandomGroup(Spoggle.Blue, "Wall_EN", "Wall_EN");
            med.AddRandomGroup(Spoggle.Blue, "Wall_EN", "Wall_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Spoggle.Blue, "ToyUfo_EN", "Wall_EN");

            med = new AddTo(Shore.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Wall_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.SimpleAddGroup(1, "FlaMinGoa_EN", 3, "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "MudLung_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Wall_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Wall_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "2009_EN", "Wall_EN", "LostSheep_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Wringle_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Wall_EN", "Wall_EN", "Skyloft_EN", "TortureMeNot_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", "Wall_EN", "Skyloft_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", "Wall_EN", "Arceles_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", Enemies.Mungling, "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "Wall_EN", Spoggle.Blue, Spoggle.Yellow);
            hard.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Pinano_EN", "Wall_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "2009_EN", "Wall_EN", "Wall_EN");

            hard = new AddTo(Shore.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "LostSheep_EN");
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "LostSheep_EN");
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "Wall_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("Voboola_EN", "Pinano_EN", "Wall_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("Kekastle_EN", "Wall_EN");
        }
    }
}
