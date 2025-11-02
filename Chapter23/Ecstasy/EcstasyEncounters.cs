using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EcstasyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_RedEcstasyEncounter_Sign", ResourceLoader.LoadSprite("RedEcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Ecstasy.Red.Med, "Salt_RedEcstasyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Foxtrot_EN").deathSound;

            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Blue, Ecstasy.Yellow, Ecstasy.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Ecstasy.Red.Med, 3, "TheSiren_Zone1", BundleDifficulty.Medium);
        }
    }
}
