using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MinanaEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_MinanaEncounter_Sign", ResourceLoader.LoadSprite("MinanaWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.Minana.Easy, "Salt_MinanaEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/MinanaTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.AddRandomEncounter("Minana_EN");
            easy.AddRandomEncounter("Minana_EN", "Mung_EN");
            easy.AddRandomEncounter("Minana_EN", "Minana_EN");
            easy.AddRandomEncounter("Minana_EN", "Minana_EN", "LostSheep_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Minana.Easy, 7, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Easy);
        }
        public static void Add_Hardmode()
        {
            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Minana.Easy, "Salt_MinanaEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/MinanaTheme";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.AddRandomEncounter("Minana_EN");
            easy.AddRandomEncounter("Minana_EN", "Mung_EN");
            easy.AddRandomEncounter("Minana_EN", "Minana_EN");
            easy.AddRandomEncounter("Minana_EN", "Minana_EN", "LostSheep_EN");
            easy.AddRandomEncounter("Minana_EN", "Minana_EN", "Skyloft_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Minana.Easy, 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
    }
}
