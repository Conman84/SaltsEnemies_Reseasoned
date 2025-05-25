using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class GrandfatherEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_GrandfatherEncounter_Sign", ResourceLoader.LoadSprite("CoffinWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, "H_Zone03_Grandfather_Hard_EnemyBundle", "Salt_GrandfatherEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewCoffinTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
        }
    }
}
