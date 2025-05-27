using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ShuaEncounters
    {
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_ShuaEncounter_Sign", ResourceLoader.LoadSprite("ShuaWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Shua.Easy, "Salt_ShuaEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/NewerShuaTheme";
            easy.RoarEvent = "event:/Hawthorne/Attack3/Censored";

            easy.SimpleAddEncounter(1, "Shua_EN", 4, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "Shua_EN", 2, "InHerImage_EN");
            easy.SimpleAddEncounter(1, "Shua_EN", 2, "InHisImage_EN");
            easy.SimpleAddEncounter(1, "Shua_EN", 3, "NextOfKin_EN");
            easy.AddRandomEncounter("Shua_EN", "WindSong_EN", "Skyloft_EN");
            easy.AddRandomEncounter("Shua_EN", "WindSong_EN", "NextOfKin_EN", "NextOfKin_EN");
            easy.AddRandomEncounter("Shua_EN", "LittleAngel_EN");
            easy.AddRandomEncounter("Shua_EN", Flower.Red);
            easy.AddRandomEncounter("Shua_EN", Flower.Blue);
            easy.AddRandomEncounter("Shua_EN", "EyePalm_EN", "EyePalm_EN");
            easy.AddRandomEncounter("Shua_EN", "ChoirBoy_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Shua.Easy, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
    }
}
