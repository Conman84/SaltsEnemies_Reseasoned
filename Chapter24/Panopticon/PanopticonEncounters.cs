using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PanopticonEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_PanopticonEncounter_Sign", ResourceLoader.LoadSprite("PanopticonWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Panopticon.Med, "Salt_PanopticonEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PanopticonPlaceholder";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.SimpleAddEncounter(4, "Panopticon_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "InHisImage_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 1, "InHisImage_EN", 1, "InHerImage_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, Enemies.Shivering);
            med.SimpleAddEncounter(2, "Panopticon_EN", 1, Enemies.Minister);
            med.SimpleAddEncounter(2, "Panopticon_EN", 1, Flower.Blue, 1, Flower.Red);
            med.SimpleAddEncounter(2, "Panopticon_EN", 3, "TortureMeNot_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "Insider_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "Sundowner_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "EvilDog_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "InHerImage_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, "BlackStar_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, "Grandfather_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Panopticon.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
