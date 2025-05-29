using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class HunterEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_HunterEncounter_Sign", ResourceLoader.LoadSprite("HunterWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Hunter.Med, "Salt_HunterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/HunterSong";
            med.RoarEvent = "event:/Hawthorne/Roar/HunterRoar";

            med.AddRandomEncounter("Hunter_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 3, "InHisImage_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 3, Enemies.Shivering);
            med.AddRandomEncounter("Hunter_EN", "ChoirBoy_EN", Flower.Red);
            med.AddRandomEncounter("Hunter_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "WindSong_EN", "Grandfather_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "WindSong_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "Grandfather_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "WindSong_EN", "Shua_EN");
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", "Shua_EN", "GlassFigurine_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 1, "Skyloft_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", "Shua_EN", "WindSong_EN");
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Hunter_EN", "EyePalm_EN", "EyePalm_EN", "Shua_EN");
            med.AddRandomEncounter("Hunter_EN", "EyePalm_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "InHisImage_EN", "InHisImage_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Hunter_EN", "InHerImage_EN", "InHerImage_EN", "NextOfkin_EN");
            med.AddRandomEncounter("Hunter_EN", "InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("Hunter_EN", Flower.Grey, "GlassFigurine_EN");
            med.AddRandomEncounter("Hunter_EN", Flower.Grey, "Shua_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Hunter.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
