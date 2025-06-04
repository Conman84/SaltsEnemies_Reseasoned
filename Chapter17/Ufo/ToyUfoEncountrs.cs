using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ToyUfoEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_ToyUFOEncounter_Sign", ResourceLoader.LoadSprite("UFOWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.Ufo.Med, "Salt_ToyUFOEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/UFOTheme";
            med.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            med.AddRandomEncounter("ToyUfo_EN", "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", Jumble.Yellow);
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", "Skyloft_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "Mung_EN");
            med.AddRandomEncounter("ToyUfo_EN", Spoggle.Yellow, "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", Spoggle.Blue, "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Flarblet_EN", "Flarblet_EN", "NobodyGrave_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Ufo.Med, 25, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Hardmode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Ufo.Med, "Salt_ToyUFOEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/UFOTheme";
            med.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            med.AddRandomEncounter("ToyUfo_EN", "ToyUfo_EN", "Wringle_EN");
            med.SimpleAddEncounter(2, "ToyUfo_EN", 2, "MudLung_EN");
            med.SimpleAddEncounter(3, "ToyUfo_EN", 1, "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", "Pinano_EN");
            med.SimpleAddEncounter(1, "ToyUfo_EN", 3, "MudLung_EN");
            med.AddRandomEncounter("ToyUfo_EN", Jumble.Red, Jumble.Yellow);
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", Jumble.Yellow);
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", Jumble.Red);
            med.AddRandomEncounter("ToyUfo_EN", Spoggle.Blue, Spoggle.Yellow);
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN", Spoggle.Blue);
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN", Spoggle.Yellow);
            med.AddRandomEncounter("ToyUfo_EN", "DeadPixel_EN", "DeadPixel_EN", "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", "DeadPixel_EN", "DeadPixel_EN", "NobodyGrave_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN", "Windle_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", "Pinano_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN", "Flarblet_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Pinano_EN", "MudLung_EN", "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Arceles_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomEncounter("ToyUfo_EN", "Arceles_EN", "Pinano_EN", "MudLung_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Ufo.Med, 25 * April.Mod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "MudLung_EN");
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Pinano_EN");
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Enemies.Mungling);
            if (SaltsReseasoned.trolling < 25) med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Jumble.Yellow);
            if (SaltsReseasoned.trolling > 25 && SaltsReseasoned.trolling < 50) med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Jumble.Red);
            if (SaltsReseasoned.trolling > 50 && SaltsReseasoned.trolling < 75) med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Spoggle.Blue);
            if (SaltsReseasoned.trolling > 75) med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Spoggle.Yellow);
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Flarblet_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Enemies.Mungling, "NobodyGrave_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "LittleBeak_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "ToyUfo_EN", Enemies.Mungling, "MudLung_EN");
            hard.AddRandomGroup(Enemies.Camera, Enemies.Camera, "ToyUfo_EN", "Skyloft_EN");

            hard = new AddTo(Shore.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "ToyUfo_EN", "LostSheep_EN");
            hard.AddRandomGroup("Tripod_EN", "ToyUfo_EN", "Flarblet_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "ToyUfo_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomGroup("Tripod_EN", "ToyUfo_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Tripod_EN", "ToyUfo_EN", Enemies.Mungling);
            hard.AddRandomGroup("Tripod_EN", "ToyUfo_EN", Jumble.Yellow, Jumble.Red);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", "MudLung_EN", "LostSheep_EN");
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", "Pinano_EN");
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Enemies.Mungling);
            if (SaltsReseasoned.silly < 25) med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Jumble.Yellow);
            if (SaltsReseasoned.silly > 25 && SaltsReseasoned.silly < 50) med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Jumble.Red);
            if (SaltsReseasoned.silly > 50 && SaltsReseasoned.silly < 75) med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Spoggle.Blue);
            if (SaltsReseasoned.silly > 75) med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Spoggle.Yellow);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", Enemies.Mungling, "NobodyGrave_EN");
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "LittleBeak_EN", "Skyloft_EN");
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "Clione_EN");
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "Pinano_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Pinano_EN");
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", Enemies.Mungling);
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", "MudLung_EN", "MudLung_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Clione_EN", "ToyUfo_EN", Jumble.Yellow);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Clione_EN", "ToyUfo_EN", Jumble.Red);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Clione_EN", "ToyUfo_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Clione_EN", "ToyUfo_EN", Enemies.Mungling, "NobodyGrave_EN");
            hard.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Pinano_EN", "Skyloft_EN");
            hard.AddRandomGroup("Clione_EN", "ToyUfo_EN", Spoggle.Blue, Spoggle.Yellow);

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "ToyUfo_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "ToyUfo_EN");
            med.AddRandomGroup(Enemies.Mungling, "ToyUfo_EN", Jumble.Yellow);

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "ToyUfo_EN");
            med.AddRandomGroup(Spoggle.Yellow, "ToyUfo_EN", "Arceles_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "ToyUfo_EN");
            med.AddRandomGroup(Spoggle.Blue, "ToyUfo_EN", "Skyloft_EN");

            med = new AddTo(Shore.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "MudLung_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Keko_EN", "Keko_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", Enemies.Mungling);
            hard.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "LittleBeak_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Pinano_EN", "Pinano_EN");

            hard = new AddTo(Shore.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "ToyUfo_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "ToyUfo_EN", "Flarblet_EN");
            hard.AddRandomGroup("Flarb_EN", "ToyUfo_EN", "LostSheep_EN");
            hard.AddRandomGroup("Flarb_EN", "ToyUfo_EN", "Pinano_EN");
            hard.AddRandomGroup("Flarb_EN", "ToyUfo_EN", "Arceles_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "ToyUfo_EN", Jumble.Yellow);
            hard.AddRandomGroup("Voboola_EN", "ToyUfo_EN", "Arceles_EN");
        }
    }
}
