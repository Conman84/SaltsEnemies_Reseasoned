using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WindleEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WindleEncounter_Sign", ResourceLoader.LoadSprite("WindleWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Windle.Easy, "Salt_WindleEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/WindleSong";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound;

            easy.AddRandomEncounter("Windle_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "Mung_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "LostSheep_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "Skyloft_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "MudLung_EN");
            easy.AddRandomEncounter("Windle_EN", "Mung_EN", "Mung_EN");
            easy.AddRandomEncounter("Windle_EN", "Wringle_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Windle.Easy, 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
        }
    }
}
