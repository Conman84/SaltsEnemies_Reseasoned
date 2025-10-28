using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class UntitledEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_UntitledEncounter_Sign", ResourceLoader.LoadSprite("UntitledWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Specific, Orph.H.Untitled.Hard, "Salt_UntitledEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/UntitledSong";
            hard.RoarEvent = "";

            hard.CreateNewEnemyEncounterData(["Untitled_EN"], [2]);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Untitled.Hard, 0, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
