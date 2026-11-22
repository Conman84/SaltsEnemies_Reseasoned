using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TrollerEncounters
    {
        public static void Add()
        {
            Help_Easy();
            Help_Med();
            Reckoner_Easy();
            Reckoner_Med();
        }
        public static void Help_Easy()
        {
            Portals.AddPortalSign("Salt_HelpEncounter_Sign", ResourceLoader.LoadSprite("HelpWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Troller.Help.Easy, "Salt_HelpEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/HelpReckonerSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound;

            easy.SimpleAddEncounter(2, Enemies.Help);
            easy.SimpleAddEncounter(2, Enemies.Help, 1, "BlackStar_EN");
            easy.SimpleAddEncounter(2, Enemies.Help, 2, "Damocles_EN");
            easy.SimpleAddEncounter(2, Enemies.Help, 1, "PawnA_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Troller.Help.Easy, 25, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Help_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Troller.Help.Med, "Salt_HelpEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/HelpReckonerSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound;

            med.SimpleAddEncounter(4, Enemies.Help);
            med.SimpleAddEncounter(2, Enemies.Help, 2, Enemies.Reckoner);
            med.SimpleAddEncounter(3, Enemies.Help, 1, "MiniReaper_EN");
            med.SimpleAddEncounter(3, Enemies.Help, 1, "Lightbulbkin_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Troller.Help.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Reckoner_Easy()
        {
            Portals.AddPortalSign("Salt_ReckonerEncounter_Sign", ResourceLoader.LoadSprite("ReckonerWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Troller.Reckoner.Easy, "Salt_ReckonerEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/HelpReckonerSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound;

            easy.SimpleAddEncounter(2, Enemies.Reckoner);
            easy.SimpleAddEncounter(2, Enemies.Reckoner, 1, "BlackStar_EN");
            easy.SimpleAddEncounter(2, Enemies.Reckoner, 2, "Damocles_EN");
            easy.SimpleAddEncounter(2, Enemies.Reckoner, 1, "PawnA_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Troller.Reckoner.Easy, 25, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Reckoner_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Troller.Reckoner.Med, "Salt_ReckonerEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/HelpReckonerSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound;

            med.SimpleAddEncounter(4, Enemies.Reckoner);
            med.SimpleAddEncounter(2, Enemies.Reckoner, 2, Enemies.Help);
            med.SimpleAddEncounter(3, Enemies.Reckoner, 1, "MiniReaper_EN");
            med.SimpleAddEncounter(3, Enemies.Reckoner, 1, "Lightbulbkin_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Troller.Reckoner.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {

        }
    }
}
