using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MawEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_TemplateEncounter_Sign", ResourceLoader.LoadSprite("TemplateWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Maw.Med, "Salt_TemplateEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewCoffinTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Maw.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
