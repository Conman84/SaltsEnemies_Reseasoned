using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AuthorEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_TemplateEncounter_Sign", ResourceLoader.LoadSprite("TemplateWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Author.Med, "Salt_TemplateEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/AuthorSong";
            med.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Author.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
