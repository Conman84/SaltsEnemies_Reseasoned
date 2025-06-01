using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class YangEncounters
    {
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_YangEncounter_Sign", ResourceLoader.LoadSprite("YangWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Yang.Med, "Salt_YangEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/BishopSong";
            med.RoarEvent = "event:/Hawthorne/Noi3e/PawnRoar";

            med.SimpleAddEncounter(2, "Yang_EN");
            med.SimpleAddEncounter(1, "Yang_EN", 4, "PawnA_EN");
            med.SimpleAddEncounter(1, "Yang_EN", 2, "InHerImage_EN");
            med.SimpleAddEncounter(1, "Yang_EN", 2, "InHisImage_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, Spoggle.Grey);
            med.SimpleAddEncounter(2, "Yang_EN", 1, "BlackStar_EN");
            med.AddRandomEncounter("Yang_EN", "PawnA_EN", "Starless_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "Hunter_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 2, "EyePalm_EN");
            med.SimpleAddEncounter(2, "Yang_EN", 1, "MiniReaper_EN");


            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Yang.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
