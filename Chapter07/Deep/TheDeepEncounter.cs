using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TheDeepEncounter
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_TheDeepEncounter_Sign", ResourceLoader.LoadSprite("DeepWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_TheDeep_Hard_EnemyBundle", "Salt_TheDeepEncounter_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/DeepSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("BOSS_Zone02_Ouroboros_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheDeep_EN"
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_TheDeep_Hard_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
