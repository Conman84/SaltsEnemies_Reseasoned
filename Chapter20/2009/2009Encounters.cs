using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TwoThousandNineEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_2009Encounter_Sign", ResourceLoader.LoadSprite("2009World.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.TwoThousandNine.Med, "Salt_2009Encounter_Sign");
            med.MusicEvent = "event:/Hawthorne/2009Theme";
            med.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.TwoThousandNine.Med, 25, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
    }
}
