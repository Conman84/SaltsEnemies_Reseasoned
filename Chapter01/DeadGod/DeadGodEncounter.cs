using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DeadGodEncounter
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_DeadGodEncounters_Sign", ResourceLoader.LoadSprite("DeadGodIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(EncounterType.Specific, "Salt_DeadGod_Orpheum_Bundle", "Salt_DeadGodEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/DeadGodSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "EmbersofaDeadGod_EN",
            }, new int[]
            {
                2
            });
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("Salt_DeadGod_Orpheum_Bundle", 3, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
