using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SinkerEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_SinkerEncounter_Sign", ResourceLoader.LoadSprite("SinkerWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Sinker.Med, "Salt_SinkerEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SinkerTheme";
            med.RoarEvent = "event:/Hawthorne/Attack3/Nailing";

            med.AddRandomEncounter("Sinker_EN", "FlaMinGoa_EN");
            med.AddRandomEncounter("Sinker_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("Sinker_EN", "Pinano_EN", "MudLung_EN");
            med.AddRandomEncounter("Sinker_EN", "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomEncounter("Sinker_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomEncounter("Sinker_EN", "Skyloft_EN", "LittleBeak_EN");
            med.SimpleAddEncounter(1, "Sinker_EN", 3, "Keko_EN");
            med.AddRandomEncounter("Sinker_EN", "Wringle_EN", "MudLung_EN");
            med.AddRandomEncounter("Sinker_EN", "Pinano_EN", "NobodyGrave_EN");
            med.AddRandomEncounter("Sinker_EN", "ToyUfo_EN", "Flarblet_EN", "Flarblet_EN");
            med.AddRandomEncounter("Sinker_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomEncounter("Sinker_EN", "MudLung_EN", "Arceles_EN");
            med.AddRandomEncounter("Sinker_EN", "ToyUfo_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Sinker.Med, 15, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Sinker.Hard, "Salt_SinkerEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/SinkerTheme";
            hard.RoarEvent = "event:/Hawthorne/Attack3/Nailing";

            hard.AddRandomEncounter("Sinker_EN", Spoggle.Blue, Spoggle.Yellow);
            hard.AddRandomEncounter("Sinker_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomEncounter("Sinker_EN", "FlaMinGoa_EN", Enemies.Mungling);
            hard.AddRandomEncounter("Sinker_EN", "Pinano_EN", Jumble.Yellow);
            hard.AddRandomEncounter("Sinker_EN", "ToyUfo_EN", Jumble.Red);
            hard.AddRandomEncounter("Sinker_EN", "Pinano_EN", Spoggle.Blue);
            hard.AddRandomEncounter("Sinker_EN", "ToyUfo_EN", Spoggle.Yellow);
            hard.AddRandomEncounter("Sinker_EN", "FlaMinGoa_EN", "Windle_EN");
            hard.AddRandomEncounter("Sinker_EN", "FlaMinGoa_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("Sinker_EN", "AFlower_EN", "Pinano_EN");
            hard.AddRandomEncounter("Sinker_EN", "FlaMinGoa_EN", "Arceles_EN");
            hard.AddRandomEncounter("Sinker_EN", "Pinano_EN", "Pinano_EN", "Arceles_EN");
            hard.AddRandomEncounter("Sinker_EN", "LittleBeak_EN", "Arceles_EN");
            hard.AddRandomEncounter("Sinker_EN", "AFlower_EN", "Arceles_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Sinker.Hard, 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Sinker_EN", "ToyUfo_EN");
            hard.AddRandomGroup("AFlower_EN", "Sinker_EN", Jumble.Yellow);

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Sinker_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup(Enemies.Camera, "Sinker_EN", "ToyUfo_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Sinker_EN", "ToyUfo_EN");
            hard.AddRandomGroup("Warbird_EN", "Sinker_EN", Jumble.Yellow);

            AddTo med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Sinker_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Sinker_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("Flarb_EN", "Sinker_EN", "Flarblet_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Sinker_EN", "NobodyGrave_EN");
        }
    }
}
