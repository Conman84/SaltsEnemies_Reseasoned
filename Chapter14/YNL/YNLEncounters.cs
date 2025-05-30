using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;

namespace SaltsEnemies_Reseasoned
{
    public static class YourNewLifeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_YourNewLifeEncounter_Sign", ResourceLoader.LoadSprite("LobotomyPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.YNL.Med, "Salt_YourNewLifeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LobotomyTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;

            med.AddRandomEncounter("YNL_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", "InHisImage-EN");
            med.SimpleAddEncounter(1, "YNL_EN", 4, "NextOfKin_EN");
            med.AddRandomEncounter("YNL_EN", "ChoirBoy_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "InHerImage_EN", "InHerImage_EN", "LittleAngel_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", Jumble.Grey);
            med.AddRandomEncounter("YNL_EN", Flower.Red, Flower.Blue, "LittleAngel_EN");
            med.AddRandomEncounter("YNL_EN", "Grandfather_EN", Flower.Red);
            med.AddRandomEncounter("YNL_EN", "Grandfather_EN", Flower.Blue);
            med.AddRandomEncounter("YNL_EN", "WindSong_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", Flower.Grey, "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "MiniReaper_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "WindSong_EN");
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", Flower.Red, "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", Flower.Blue, "GlassFigurine_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "BlackStar_EN", "BlackStar_EN");
            med.AddRandomEncounter("YNL_EN", "Hunter_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("YNL_EN", "Firebird_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("YNL_EN", "Indicator_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "ChoirBoy_EN", "Grandfather_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Minister);
            med.AddRandomEncounter("YNL_EN", "Grandfather_EN", Enemies.Minister);
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "WindSong_EN");
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "LittleAngel_EN");
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "ChoirBoy_EN");
            med.SimpleAddEncounter(1, "YNL_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("YNL_EN", "EyePalm_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "EyePalm_EN", "EyePalm_EN", "MiniReaper_EN");
            med.AddRandomEncounter("YNL_EN", "EyePalm_EN", "EyePalm_EN", "Hunter_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.YNL.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
