
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
    }
}
