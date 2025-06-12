using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AbyssAngelEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_AbyssAngelEncounter_Sign", ResourceLoader.LoadSprite("ClioneWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Clione.Med, "Salt_AbyssAngelEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ClioneSong";
            med.RoarEvent = "event:/Hawthorne/Misc/Water";

            med.AddRandomEncounter("Clione_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("Clione_EN", Enemies.Mungling);
            med.AddRandomEncounter("Clione_EN", "Flarblet_EN", "Flarblet_EN", "LostSheep_EN");
            med.SimpleAddEncounter(1, "Clione_EN", 3, "Keko_EN");
            med.AddRandomEncounter("Clione_EN", Jumble.Red, "MudLung_EN");
            med.AddRandomEncounter("Clione_EN", "Windle_EN", "LostSheep_EN");
            med.AddRandomEncounter("Clione_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomEncounter("Clione_EN", "Skyloft_EN", Enemies.Mungling);
            med.SimpleAddEncounter(1, "Clione_EN", 3, "Mung_EN");
            med.AddRandomEncounter("Clione_EN", "DeadPixel_EN", "DeadPixel_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Clione.Med, 10 * April.Mod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Clione.Hard, "Salt_AbyssAngelEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/ClioneSong";
            hard.RoarEvent = "event:/Hawthorne/Misc/Water";

            hard.AddRandomEncounter("Clione_EN", "FlaMinGoa_EN", "MudLung_EN");
            hard.AddRandomEncounter("Clione_EN", "AFlower_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomEncounter("Clione_EN", "LittleBeak_EN", Jumble.Yellow);
            hard.AddRandomEncounter("Clione_EN", Jumble.Red, Jumble.Yellow, "Flarblet_EN");
            hard.AddRandomEncounter("Clione_EN", "FlaMinGoa_EN", Enemies.Mungling);
            hard.AddRandomEncounter("Clione_EN", "LittleBeak_EN", Enemies.Mungling);
            hard.AddRandomEncounter("Clione_EN", "Windle_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("Clione_EN", Spoggle.Blue, "AFlower_EN");
            hard.AddRandomEncounter("Clione_EN", Spoggle.Yellow, "LittleBeak_EN");
            hard.AddRandomEncounter("Clione_EN", Enemies.Mungling, Enemies.Mungling, "LostSheep_EN");
            hard.AddRandomEncounter("Clione_EN", "LittleBeak_EN", "LittleBeak_EN", "Skyloft_EN");
            hard.AddRandomEncounter("Clione_EN", "AFlower_EN", Jumble.Yellow);
            hard.AddRandomEncounter("Clione_EN", "AFlower_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Clione.Hard, 18, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Clione_EN", Jumble.Red);
            hard.AddRandomGroup("Tripod_EN", "Clione_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Clione_EN", "MudLung_EN");
            hard.AddRandomGroup(Enemies.Camera, "Clione_EN", "FlaMinGoa_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Clione_EN", Enemies.Mungling);
            hard.AddRandomGroup("Warbird_EN", "Clione_EN", Jumble.Red);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Clione_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Clione_EN");
        }
    }
}
