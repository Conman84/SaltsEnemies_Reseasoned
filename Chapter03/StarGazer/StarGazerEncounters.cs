using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class StarGazerEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_StarGazerEncounters_Sign", ResourceLoader.LoadSprite("IconStars.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_StarGazer_Easy_EnemyBundle", "Salt_StarGazerEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/StarSong";
            mainEncounters.RoarEvent = "event:/Hawthorne/Nois2/StarsRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "StarGazer_EN",
                "StarGazer_EN",
                "StarGazer_EN",
                "StarGazer_EN",
                "StarGazer_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_StarGazer_Easy_EnemyBundle", 1 * April.MoreMod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
    }
}
