using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ShinyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ShinyEncounter_Sign", ResourceLoader.LoadSprite("ShinyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Shiny.Hard, "Salt_ShinyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewCoffinTheme";
            med.RoarEvent = "event:/Hawthorne/Nois2/CrowRoar";

            med.SimpleAddEncounter(1, "CoinHunter_EN", 4, "Bronzo_MoneyPile_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Shiny.Hard, 0, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
