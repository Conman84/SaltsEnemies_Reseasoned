using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WhaleEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WhaleEncounter_Sign", ResourceLoader.LoadSprite("WhalePortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Whale.Med, "Salt_WhaleEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ActuallyJustPepperSteak";
            med.RoarEvent = "event:/Hawthorne/Surround/DeepRoar";

            med.SimpleAddEncounter(3, "TheWhale_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Whale.Med, 20, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
    }
}
