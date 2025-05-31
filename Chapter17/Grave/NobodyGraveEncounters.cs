using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NobodyGraveEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_NobodyGraveEncounter_Sign", ResourceLoader.LoadSprite("GraveWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.Grave.Easy, "Salt_NobodyGraveEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/GraveTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            easy.AddRandomEncounter("NobodyGrave_EN", "Mung_EN", "Mung_EN", "Mung_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "MudLung_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", Jumble.Yellow);
            easy.AddRandomEncounter("NobodyGrave_EN", "MudLung_EN", "MudLung_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "Keko_EN", "Keko_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", Jumble.Red, "LostSheep_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "Flarblet_EN", "Flarblet_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Grave.Easy, 3, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Easy);
        }
        public static void Add_Hardmode()
        {
            Portals.AddPortalSign("Salt_NobodyGraveEncounter_Sign", ResourceLoader.LoadSprite("GraveWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Grave.Easy, "Salt_NobodyGraveEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/GraveTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            easy.AddRandomEncounter("NobodyGrave_EN", "Mung_EN", "Mung_EN", "Mung_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "MudLung_EN", Jumble.Yellow);
            easy.AddRandomEncounter("NobodyGrave_EN", "MudLung_EN", Jumble.Red);
            easy.AddRandomEncounter("NobodyGrave_EN", "MudLung_EN", "MudLung_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "DeadPixel_EN", "DeadPixel_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "Keko_EN", "Keko_EN", "Keko_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "Keko_EN", "Keko_EN", "LostSheep_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", Jumble.Red, Jumble.Yellow);
            easy.AddRandomEncounter("NobodyGrave_EN", "Windle_EN", "Wringle_EN");
            easy.AddRandomEncounter("NobodyGrave_EN", "Arceles_EN", "MudLung_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Grave.Easy, 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Shore.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "NobodyGrave_EN");
            med.AddRandomGroup("Pinano_EN", "MudLung_EN", "NobodyGrave_EN");

            AddTo easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Pinano_EN", "Pinano_EN", "NobodyGrave_EN");
            easy.AddRandomGroup("Pinano_EN", "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", Jumble.Yellow, "NobodyGrave_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", Jumble.Red, "NobodyGrave_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Flarblet_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Enemies.Mungling, "NobodyGrave_EN");
            med.AddRandomGroup("AFlower_EN", Spoggle.Yellow, "NobodyGrave_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Pinano_EN", "Pinano_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("AFlower_EN", Spoggle.Blue, "MudLung_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Camera, "AFlower_EN", "NobodyGrave_EN");
            hard.AddRandomGroup(Enemies.Camera, "FlaMinGoa_EN", "Pinano_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "FlaMinGoa_EN", "Flarblet_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "FlaMinGoa_EN", "MudLung_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("Tripod_EN", "AFlower_EN", "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Pinano_EN", "NobodyGrave_EN");
            med.AddRandomGroup("LittleBeak_EN", "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup("LittleBeak_EN", Jumble.Yellow, Jumble.Red, "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.SimpleAddGroup(1, "Warbird_EN", 3, "MudLung_EN", 1, "NobodyGrave_EN");
            hard.AddRandomGroup("Warbird_EN", "FlaMinGoa_EN", "Pinano_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup("Clione_EN", Enemies.Mungling, "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup("Clione_EN", Spoggle.Yellow, "MudLung_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Pinano_EN", Spoggle.Blue, "NobodyGrave_EN");
            hard.AddRandomGroup("Clione_EN", "FlaMinGoa_EN", "MudLung_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "NobodyGrave_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Enemies.Mungling, "Pinano_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "NobodyGrave_EN");
            med.AddRandomGroup("FlaMinGoa_EN", Jumble.Yellow, "NobodyGrave_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", Enemies.Mungling, "NobodyGrave_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "Pinano_EN", "NobodyGrave_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "DeadPixel_EN", "DeadPixel_EN", "NobodyGrave_EN");
            med.AddRandomGroup("FlaMinGoa_EN", Jumble.Yellow, Jumble.Red, "NobodyGrave_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "AFlower_EN", "MudLung_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "Pinano_EN", "LittleBeak_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", Enemies.Mungling, "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Blue, "NobodyGrave_EN");
            med.AddRandomGroup(Spoggle.Yellow, "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "Pinano_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Yellow, "NobodyGrave_EN");
            med.AddRandomGroup(Spoggle.Blue, "Pinano_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "MudLung_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("Flarb_EN", "Flarblet_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "MudLung_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("Flarb_EN", Enemies.Mungling, "NobodyGrave_EN");
            hard.AddRandomGroup("Flarb_EN", "Pinano_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "MudLung_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("Voboola_EN", Jumble.Yellow, "NobodyGrave_EN");
            hard.AddRandomGroup("Voboola_EN", Jumble.Red, "NobodyGrave_EN");
        }
    }
}
