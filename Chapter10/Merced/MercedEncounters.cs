using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MercedEncounters
    {
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_MercedEncounter_Sign", ResourceLoader.LoadSprite("MercedWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Merced.Easy, "Salt_MercedEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/MercedSong";
            easy.RoarEvent = "event:/Hawthorne/Attack2/Rainy";

            easy.AddRandomEncounter("Merced_EN");
            easy.AddRandomEncounter("Merced_EN", "Merced_EN", "Merced_EN", "Merced_EN", "Merced_EN");
            easy.AddRandomEncounter("Merced_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN");
            easy.AddRandomEncounter("Merced_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Merced.Easy, 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
    }
}
