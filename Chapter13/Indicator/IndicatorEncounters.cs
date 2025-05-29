using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class IndicatorEncounters
    {
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_IndicatorEncounter_Sign", ResourceLoader.LoadSprite("IndicatorWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Indicator.Easy, "Salt_IndicatorEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/IndicatorSong";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;

            easy.AddRandomEncounter("Indicator_EN", "Grandfather_EN");
            easy.AddRandomEncounter("Indicator_EN", "GlassFigurine_EN");
            easy.AddRandomEncounter("Indicator_EN", "BlackStar_EN", "BlackStar_EN");
            easy.AddRandomEncounter("Indicator_EN", "EyePalm_EN", "EyePalm_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 4, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering);
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "Skyloft_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "Damocles_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "BlackStar_EN");
            easy.AddRandomEncounter("Indicator_EN", Enemies.Camera, Enemies.Camera);
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "Damocles_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "BlackStar_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "GlassFigurine_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Indicator.Easy, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_IndicatorEncounter_Sign", ResourceLoader.LoadSprite("IndicatorWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Indicator.Med, "Salt_IndicatorEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/IndicatorSong";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;

            easy.AddRandomEncounter("Indicator_EN", "Grandfather_EN");
            easy.AddRandomEncounter("Indicator_EN", "GlassFigurine_EN");
            easy.AddRandomEncounter("Indicator_EN", "BlackStar_EN", "BlackStar_EN");
            easy.AddRandomEncounter("Indicator_EN", "EyePalm_EN", "EyePalm_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 4, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering);
            easy.SimpleAddEncounter(1, "Indicator_EN", 3, Enemies.Shivering);
            easy.SimpleAddEncounter(1, "Indicator_EN", 3, "EyePalm_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "Skyloft_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "Damocles_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "BlackStar_EN");
            easy.AddRandomEncounter("Indicator_EN", Enemies.Camera, Enemies.Camera);
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "Damocles_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "BlackStar_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "GlassFigurine_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Indicator.Med, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
