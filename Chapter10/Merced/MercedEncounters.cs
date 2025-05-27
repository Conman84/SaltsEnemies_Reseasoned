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
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Merced.Hard, "Salt_MercedEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/MercedSong";
            hard.RoarEvent = "event:/Hawthorne/Attack2/Rainy";

            hard.AddRandomEncounter("Merced_EN", Flower.Red, Flower.Blue, Flower.Yellow, Flower.Purple);
            hard.AddRandomEncounter("Merced_EN", Enemies.Skinning, Enemies.Skinning, Enemies.Skinning);
            hard.AddRandomEncounter("Merced_EN", "ChoirBoy_EN", "Grandfather_EN");
            hard.AddRandomEncounter("Merced_EN", Enemies.Minister, Enemies.Minister, Enemies.Minister);
            hard.AddRandomEncounter("Merced_EN", "Satyr_EN", "Satyr_EN", Enemies.Camera);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Merced.Hard, 1, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
