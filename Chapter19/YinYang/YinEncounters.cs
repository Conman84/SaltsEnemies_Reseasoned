using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class YinEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_YinEncounter_Sign", ResourceLoader.LoadSprite("YinWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Yin.Hard, "Salt_YinEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/BishopSong";
            hard.RoarEvent = "event:/Hawthorne/Noi3e/PawnRoar";

            hard.SimpleAddEncounter(2, "Yang_EN", 1, "Yin_EN");
            hard.SimpleAddEncounter(1, "Yin_EN", 1, "Yang_EN", 2, "PawnA_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "Yang_EN");
            hard.SimpleAddEncounter(1, "Yang_EN", 1, "Yin_EN", 2, "InHisImage_EN");
            hard.SimpleAddEncounter(1, "Yang_EN", 1, "Yin_EN", 2, "InHerImage_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "BlackStar_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "PawnA_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", Flower.Red, Flower.Blue);
            hard.SimpleAddEncounter(1, "Yin_EN", 1, Flower.Grey, 2, "PawnA_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "Starless_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "WindSong_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "Hunter_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "MiniReaper_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", Bots.Grey);
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "Firebird_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", Enemies.Minister);
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "Grandfather_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "Shua_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 2, "Damocles_EN");
            hard.AddRandomEncounter("Yin_EN", "Yang_EN", "GlassFigurine_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "Yang_EN", 1, "Skyloft_EN");
            hard.SimpleAddEncounter(2, "Yin_EN", 1, "Indicator_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "YNL_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "PersonalAngel_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "Eyeless_EN");
            hard.AddRandomEncounter("Yang_EN", "Yin_EN", "OdeToHumanity_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Yin.Hard, 5 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
