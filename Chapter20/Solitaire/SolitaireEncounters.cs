using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SolitaireEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_SolitaireEncounter_Sign", ResourceLoader.LoadSprite("SolitaireWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Solitaire.Med, "Salt_SolitaireEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SolitairePlaceholder";
            med.RoarEvent = "event:/Hawthorne/Sund/SolitaireDie";

            med.SimpleAddEncounter(3, "Solitaire_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Solitaire.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
    }
}
