using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TwoThousandNineEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_2009Encounter_Sign", ResourceLoader.LoadSprite("2009World.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.TwoThousandNine.Med, "Salt_2009Encounter_Sign");
            med.MusicEvent = "event:/Hawthorne/2009Theme";
            med.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            med.AddRandomEncounter("2009_EN", "2009_EN", "Arceles_EN");
            med.AddRandomEncounter("2009_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("2009_EN", Jumble.Yellow, "Pinano_EN");
            med.AddRandomEncounter("2009_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomEncounter("2009_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomEncounter("2009_EN", Spoggle.Blue, "MudLung_EN");
            med.AddRandomEncounter("2009_EN", Spoggle.Yellow, "Windle_EN");
            med.AddRandomEncounter("2009_EN", "DeadPixel_EN", "DeadPixel_EN", "Flarblet_EN");
            med.AddRandomEncounter("2009_EN", "ToyUfo_EN", "Wringle_EN");
            med.AddRandomEncounter("2009_EN", "ToyUfo_EN", "Keko_EN", "Keko_EN");
            med.AddRandomEncounter("2009_EN", "ToyUfo_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("2009_EN", "Pinano_EN", Spoggle.Yellow);
            med.AddRandomEncounter("2009_EN", Spoggle.Blue, "Keko_EN", "Keko_EN");
            med.AddRandomEncounter("2009_EN", "DeadPixel_EN", "DeadPixel_EN", "Arceles_EN");
            med.AddRandomEncounter("2009_EN", "DeadPixel_EN", "DeadPixel_EN", "LostSheep_EN");
            med.AddRandomEncounter("2009_EN", "MudLung_EN", "MudLung_EN", "LostSheep_EN");
            med.AddRandomEncounter("2009_EN", Jumble.Yellow, Jumble.Red, "LostSheep_EN");
            med.SimpleAddEncounter(1, "2009_EN", 4, "Flarblet_EN");
            med.AddRandomEncounter("2009_EN", "2009_EN", "Skyloft_EN");
            med.SimpleAddEncounter(1, "2009_EN", 3, "Keko_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.TwoThousandNine.Med, 20, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "2009_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "2009_EN", "2009_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "2009_EN", "LittleBeak_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "FlaMinGoa_EN", "2009_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "2009_EN", "Arceles_EN");
            hard.AddRandomGroup("Tripod_EN", "2009_EN", "ToyUfo_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "2009_EN", "2009_EN");
            med.AddRandomGroup("LittleBeak_EN", "2009_EN", "ToyUfo_EN");
            med.AddRandomGroup("LittleBeak_EN", "LittleBeak_EN", "2009_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "2009_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Warbird_EN", "2009_EN", "Clione_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "2009_EN", "MudLung_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "2009_EN", "Pinano_EN", "Minana_EN");
            hard.AddRandomGroup("Clione_EN", "2009_EN", "Pinano_EN", "Pinano_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "2009_EN");
            med.AddRandomGroup("Pinano_EN", "2009_EN", Jumble.Yellow);

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "2009_EN", "NobodyGrave_EN");
            med.AddRandomGroup("ToyUfo_EN", "2009_EN", "Arceles_EN");
            med.AddRandomGroup("ToyUfo_EN", "2009_EN", "Skyloft_EN");
            med.AddRandomGroup("ToyUfo_EN", "2009_EN", "Pinano_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "2009_EN", "LostSheep_EN");
            med.AddRandomGroup("Sinker_EN", "2009_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "2009_EN", "ToyUfo_EN");
            hard.AddRandomGroup("Sinker_EN", "2009_EN", Enemies.Mungling);

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "2009_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "2009_EN", "Mung_EN");
            med.AddRandomGroup(Enemies.Mungling, "2009_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, "2009_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "2009_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "Pinano_EN", "2009_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "2009_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "2009_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", Enemies.Mungling, "2009_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", Spoggle.Blue, "2009_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", Enemies.Camera, "2009_EN");
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "2009_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "2009_EN");
            hard.AddRandomGroup("Voboola_EN", "2009_EN", "Keko_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "2009_EN");
        }
    }
}
