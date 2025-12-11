using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class PapereaterEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_PapereaterEncounter_Sign", ResourceLoader.LoadSprite("PapereaterWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Papereater.Med, "Salt_PapereaterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PapereaterPlaceholder";
            med.RoarEvent = "event:/Hawthorne/Sound2/EaterRoar";

            med.SimpleAddEncounter(2, "Papereater_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Papereater.Med, 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
    }
}
