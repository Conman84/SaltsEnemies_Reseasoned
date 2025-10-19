using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PostmodernEncounter
    {
        public static void Add()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Specific, "H_Zone03_Postmodern_Hard_EnemyBundle", "Postmodern_1999");
            hard.MusicEvent = "event:/Hawthorne/PostmodernTheme";
            hard.RoarEvent = "event:/Hawthorne/HissingNoise";
            hard.AddCustomOverworldRoom("PostmodernRoom");

            hard.CreateNewEnemyEncounterData(["Postmodern_EN", "War_EN"], [1, 3]);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_Postmodern_Hard_EnemyBundle", 9999 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
