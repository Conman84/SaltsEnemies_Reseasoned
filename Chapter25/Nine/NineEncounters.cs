using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NineEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_NineEncounter_Sign", ResourceLoader.LoadSprite("NineWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Abyss.H.Nine.Easy, "Salt_NineEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/NineSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemy("War_EN").deathSound;

            easy.AddRandomEncounter("Nine_EN", "AbandonedPuppet_EN", "AbandonedPuppet_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Abyss.H.Nine.Easy, 5, "TheAbyss_Zone3", BundleDifficulty.Easy);
        }
    }
}
