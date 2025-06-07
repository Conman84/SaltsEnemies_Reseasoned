using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WaltzEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WaltzEncounter_Sign", ResourceLoader.LoadSprite("WaltzWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Clown.Easy, "Salt_WaltzEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/ClownSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound;

            easy.SimpleAddEncounter(3, "Waltz_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "Flarblet_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "Keko_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "LostSheep_EN");
            easy.SimpleAddEncounter(3, "Waltz_EN", 1, "Skyloft_EN");
            easy.SimpleAddEncounter(3, "Waltz_EN", 1, "NobodyGrave_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "Minana_EN");
            easy.SimpleAddEncounter(3, "Waltz_EN", 1, "TortureMeNot_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "Arceles_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "Wall_EN");
            easy.SimpleAddEncounter(2, "Waltz_EN", 1, "MudLung_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Clown.Easy, 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.Skyloft.Easy);
            easy.SimpleAddGroup(1, "Skyloft_EN", 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Windle.Easy);
            easy.SimpleAddGroup(1, "Windle_EN", 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Grave.Easy);
            easy.SimpleAddGroup(1, "NobodyGrave_EN", 2, "Waltz_EN");
            easy.SimpleAddGroup(1, "NobodyGrave_EN", 3, "Waltz_EN");

            easy = new AddTo(Shore.H.Arceles.Easy);
            easy.SimpleAddGroup(1, "Arceles_EN", 2, "Waltz_EN");

            easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.SimpleAddGroup(2, "DeadPixel_EN", 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Wall.Easy);
            easy.SimpleAddGroup(1, "Wall_EN", 2, "Waltz_EN");
            easy.SimpleAddGroup(1, "Wall_EN", 3, "Waltz_EN");
            easy.SimpleAddGroup(2, "Wall_EN", 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Trumpet.Easy);
            easy.SimpleAddGroup(1, "VoiceTrumpet_EN", 3, "Waltz_EN");

            easy = new AddTo(Shore.H.Pinano.Easy);
            easy.SimpleAddGroup(1, "Pinano_EN", 2, "Waltz_EN");
            easy.SimpleAddGroup(2, "Pinano_EN", 1, "Waltz_EN");

            easy = new AddTo(Shore.H.MudLung.Easy);
            easy.SimpleAddGroup(1, "MudLung_EN", 2, "Waltz_EN");
            easy.SimpleAddGroup(1, "MudLung_EN", 3, "Waltz_EN");
            easy.SimpleAddGroup(2, "MudLung_EN", 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.SimpleAddGroup(1, Enemies.Mungling, 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Keko.Easy);
            easy.SimpleAddGroup(2, "Keko_EN", 2, "Waltz_EN");

            AddTo med = new AddTo(Shore.H.Wall.Med);
            med.SimpleAddGroup(2, "Wall_EN", 3, "Waltz_EN");
            med.AddRandomGroup("Wall_EN", "VoiceTrumpet_EN", "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.SimpleAddGroup(2, "DeadPixel_EN", 3, "Waltz_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.SimpleAddGroup(2, "Pinano_EN", 2, "Waltz_EN");
            med.SimpleAddGroup(2, "Pinano_EN", 3, "Waltz_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.SimpleAddGroup(1, "ToyUfo_EN", 3, "Waltz_EN");
            med.AddRandomGroup("ToyUfo_EN", "Pinano_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("ToyUfo_EN", "MudLung_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("ToyUfo_EN", Jumble.Red, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("ToyUfo_EN", Jumble.Yellow, "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.SimpleAddGroup(1, "2009_EN", 3, "Waltz_EN");
            med.AddRandomGroup("2009_EN", "Wall_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("2009_EN", Spoggle.Yellow, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("2009_EN", Spoggle.Blue, "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.SimpleAddGroup(1, "LittleBeak_EN", 3, "Waltz_EN");
            med.SimpleAddGroup(1, "LittleBeak_EN", 2, "Waltz_EN", 1, "LostSheep_EN");
            med.SimpleAddGroup(1, "LittleBeak_EN", 2, "Waltz_EN", 1, "Skyloft_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.SimpleAddGroup(1, "Chiito_EN", 3, "Waltz_EN");
            med.SimpleAddGroup(1, "Chiito_EN", 1, "MudLung_EN", 2, "Waltz_EN");
            med.SimpleAddGroup(1, "Chiito_EN", 1, "Wall_EN", 2, "Waltz_EN");
            med.SimpleAddGroup(1, "Chiito_EN", 1, "VoiceTrumpet_EN", 2, "Waltz_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.SimpleAddGroup(1, "AFlower_EN", 3, "Waltz_EN");
            med.SimpleAddGroup(1, "AFlower_EN", 2, "Waltz_EN", 1, "NobodyGrave_EN");
            med.SimpleAddGroup(1, "AFlower_EN", 2, "Waltz_EN", 1, "LostSheep_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.SimpleAddGroup(1, "Sinker_EN", 3, "Waltz_EN");
            med.SimpleAddGroup(1, "Sinker_EN", 2, "Waltz_EN", 1, "TortureMeNot_EN");
            med.SimpleAddGroup(1, "Sinker_EN", 2, "Waltz_EN", 1, "Flarblet_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.SimpleAddGroup(1, "Clione_EN", 3, "Waltz_EN");
            med.AddRandomGroup("Clione_EN", "Waltz_EN", "Waltz_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.MudLung.Med);
            med.SimpleAddGroup(2, "MudLung_EN", 3, "Waltz_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.SimpleAddGroup(1, Enemies.Mungling, 3, "Waltz_EN");
            med.SimpleAddGroup(1, Enemies.Mungling, 1, "MudLung_EN", 2, "Waltz_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Waltz_EN", "Waltz_EN");
            med.SimpleAddGroup(1, Jumble.Red, 3, "Waltz_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Waltz_EN", "Waltz_EN");
            med.SimpleAddGroup(1, Jumble.Yellow, 3, "Waltz_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "Waltz_EN", "Waltz_EN");
            med.SimpleAddGroup(1, Spoggle.Yellow, 3, "Waltz_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "Waltz_EN", "Waltz_EN");
            med.SimpleAddGroup(1, Spoggle.Blue, 3, "Waltz_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.SimpleAddGroup(1, "FlaMinGoa_EN", 3, "Waltz_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Waltz_EN", "Waltz_EN", "LostSheep_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Waltz_EN", "Waltz_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Keko.Med);
            med.SimpleAddGroup(3, "Keko_EN", 2, "Waltz_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("AFlower_EN", Jumble.Yellow, "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("AFlower_EN", Spoggle.Blue, "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "2009_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("Sinker_EN", "Chiito_EN", "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "VoiceTrumpet_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Waltz_EN", "Waltz_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("Warbird_EN", "LittleBeak_EN", "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.SimpleAddGroup(2, Enemies.Camera, 3, "Waltz_EN");
            hard.AddRandomGroup(Enemies.Camera, "FlaMinGoa_EN", "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.SimpleAddGroup(1, "Tripod_EN", 4, "Waltz_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.SimpleAddGroup(1, "33_EN", 4, "Waltz_EN");
            hard.AddRandomGroup("33_EN", "Wall_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("33_EN", "VoiceTrumpet_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("33_EN", "Clown_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.SimpleAddGroup(1, Enemies.Unmung, 2, "Waltz_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", Jumble.Red, "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", Spoggle.Yellow, "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", Enemies.Mungling, "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Waltz_EN");
            hard.AddRandomGroup("Flarb_EN", "Waltz_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "Waltz_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Waltz_EN", "Waltz_EN");
        }
    }
}
