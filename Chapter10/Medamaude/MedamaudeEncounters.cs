using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MedamaudeEncounters
    {
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_MedamaudeEncounter_Sign", ResourceLoader.LoadSprite("EyePalmWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.EyePalm.Easy, "Salt_MedamaudeEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/EyePalmSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", Enemies.Shivering, Enemies.Shivering);
            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "NextOfKin_EN");
            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.EyePalm.Easy, 15, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
    }
}
