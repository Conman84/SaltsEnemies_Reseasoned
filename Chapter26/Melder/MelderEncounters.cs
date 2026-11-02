using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MelderEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_MelderEncounter_Sign", ResourceLoader.LoadSprite("MelderWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Melder.Med, "Salt_MelderEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/MelderTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/MelderRoar";

            med.AddRandomEncounter("Melder_EN", "MusicMan_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("Melder_EN", "Melder_EN", "Freud_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Melder.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {

        }
    }
}
