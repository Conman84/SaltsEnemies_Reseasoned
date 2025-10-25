using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CorpseChanEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_CorpseChanEncounter_Sign", ResourceLoader.LoadSprite("CorpseChanWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.CorpseChan.Med, "Salt_CorpseChanEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CorpseChanSong";
            med.RoarEvent = "event:/Hawthorne/Sosn2/RotDie";

            med.SimpleAddEncounter(3, "CorpseChan_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.CorpseChan.Med, April.LessMod * 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {

        }
    }
}
