using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NumeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_NumeEncounter_Sign", ResourceLoader.LoadSprite("NumeWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Nume.Med, "Salt_NumeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NumePlaceholder";
            med.RoarEvent = "event:/Hawthorne/Surround/EnigmaRoar";

            med.AddRandomEncounter("Nume_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Nume.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
    }
}
