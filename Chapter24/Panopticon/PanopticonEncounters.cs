using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PanopticonEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_PanopticonEncounter_Sign", ResourceLoader.LoadSprite("PanopticonWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Panopticon.Med, "Salt_PanopticonEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PanopticonPlaceholder";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.SimpleAddEncounter(4, "Panopticon_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Panopticon.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
