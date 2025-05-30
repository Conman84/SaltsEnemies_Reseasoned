using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class YourNewLifeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_YourNewLifeEncounter_Sign", ResourceLoader.LoadSprite("LobotomyPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.YNL.Med, "Salt_YourNewLifeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LobotomyTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.YNL.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
