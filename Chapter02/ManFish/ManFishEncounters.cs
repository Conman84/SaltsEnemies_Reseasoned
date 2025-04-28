using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ManFishEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_ManFishEncounters_Sign", ResourceLoader.LoadSprite("ManFishIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Far Shore
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone01_TeachaMantoFish_Hard_EnemyBundle", "Salt_ManFishEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/TeachFishTheme";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "MudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "FlaMinGoa_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "MunglingMudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "Mung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "JumbleGuts_Waning_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "JumbleGuts_Clotted_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "Spoggle_Spitfire_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "Wringle_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "Flarblet_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TeachaMantoFish_EN",
                "Keko_EN",
                "Keko_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone01_TeachaMantoFish_Hard_EnemyBundle", 3, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
