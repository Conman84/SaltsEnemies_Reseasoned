using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class LightbulbkinEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Med();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_LightbulbkinEncounter_Sign", ResourceLoader.LoadSprite("LightbulbkinWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Lightbulbkin.Easy, "Salt_LightbulbkinEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/LightbulbkinTheme";
            easy.RoarEvent = "event:/Hawthorne/Nois2/RusticDeath";

            easy.AddRandomEncounter("Lightbulbkin_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN");
            easy.SimpleAddEncounter(2, "Lightbulbkin_EN");
            easy.AddRandomEncounter("Lightbulbkin_EN", "BlackStar_EN", "BlackStar_EN");
            easy.AddRandomEncounter("Lightbulbkin_EN", "GlassFigurine_EN", "Damocles_EN");
            easy.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, "Children6_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lightbulbkin.Easy, 15, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Lightbulbkin.Med, "Salt_LightbulbkinEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LightbulbkinTheme";
            med.RoarEvent = "event:/Hawthorne/Nois2/RusticDeath";

            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 2, "NextOfKin_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "InHisImage_EN", "InHerImage_EN", "NextOfKin_EN");
            med.SimpleAddEncounter(3, "Lightbulbkin_EN");
            

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lightbulbkin.Med, 10 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {

        }
    }
}
