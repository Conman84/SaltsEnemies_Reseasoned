using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class FirebirdEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_FirebirdEncounter_Sign", ResourceLoader.LoadSprite("FirebirdWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Firebird.Med, "Salt_FirebirdEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/FirebirdTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent;

            med.AddRandomEncounter("Firebird_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Firebird_EN", "InHerImage_EN", "InHerImage_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Firebird.Med, 6, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
