using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MidnightTrafficLightEncounters
    {
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_MidnightTrafficLightEncounter_Sign", ResourceLoader.LoadSprite("TrainWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Stoplight.Med, "Salt_MidnightTrafficLightEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewTrainSong";
            med.RoarEvent = "event:/Hawthorne/Noise/TrainRoar";

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Stoplight.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
