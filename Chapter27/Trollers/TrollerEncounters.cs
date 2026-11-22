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

        public static string Troller => UnityEngine.Random.Range(0, 100) < 50 ? Enemies.Help : Enemies.Reckoner;

        public static void Troller_Easy(AddTo easy, string main)
        {
            easy.SimpleAddGroup(2, main, 1, "LittleAngel_EN");
            easy.SimpleAddGroup(2, main, 1, Enemies.Camera);
            easy.SimpleAddGroup(2, main, 1, "Damocles_EN");
            easy.SimpleAddGroup(2, main, 1, "EyePalm_EN");
            easy.SimpleAddGroup(2, main, 1, "Merced_EN");
            easy.SimpleAddGroup(2, main, 1, "GlassFigurine_EN");
            easy.SimpleAddGroup(2, main, 1, "Children6_EN");
            easy.SimpleAddGroup(2, main, 2, "TortureMeNot_EN");
            easy.SimpleAddGroup(2, main, 2, "Hauntling_EN");
            easy.SimpleAddGroup(2, main, 1, "Hauntling_EN");
            easy.SimpleAddGroup(2, main, 1, "Insider_EN");
            easy.SimpleAddGroup(2, main, 1, "Vivarium_EN");
            easy.SimpleAddGroup(2, main, 3, "Vivarium_EN");
            easy.SimpleAddGroup(1, main, 4, "NextOfKin_EN");
            easy.SimpleAddGroup(2, main, 1, "Lightbulbkin_EN");

        }
        public static void Troller_Med(AddTo med, string main)
        {
            med.SimpleAddGroup(3, main, 1, Jumble.Gray);
            med.SimpleAddGroup(3, main, 1, Flower.Red);
            med.SimpleAddGroup(3, main, 1, Flower.Blue);
            med.SimpleAddGroup(3, main, 1, Flower.Yellow);
            med.SimpleAddGroup(3, main, 1, Flower.Purple);
            med.SimpleAddGroup(3, main, 1, Enemies.Camera);
            med.SimpleAddGroup(2, main, 1, "Grandfather_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(3, main, 1, "BlackStar_EN");
            med.SimpleAddGroup(3, main, 1, "Merced_EN");
            med.SimpleAddGroup(3, main, 1, "Damocles_EN");
            med.SimpleAddGroup(3, main, 1, "Children6_EN");
            med.SimpleAddGroup(3, main, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(3, main, 1, "Indicator_EN");
            med.SimpleAddGroup(3, main, 1, "EvilDog_EN");
            med.SimpleAddGroup(2, main, 2, "EvilDog_EN");
            med.SimpleAddGroup(3, main, 1, "PawnA_EN");
            med.SimpleAddGroup(2, main, 3, "PawnA_EN");
            med.SimpleAddGroup(3, main, 1, "Insider_EN");
            med.SimpleAddGroup(3, main, 1, "Panopticon_EN");
            med.SimpleAddGroup(2, main, 2, "Panopticon_EN");
            med.SimpleAddGroup(3, main, 1, Ecstasy.Gray);
            med.SimpleAddGroup(2, main, 2, Ecstasy.Gray);
            med.SimpleAddGroup(3, main, 1, "Vivarium_EN");
            med.SimpleAddGroup(3, main, 2, "Vivarium_EN");
            med.SimpleAddGroup(2, main, 3, "TortureMeNot_EN");
            med.SimpleAddGroup(3, main, 1, Enemies.Shivering);
            med.SimpleAddGroup(3, main, 2, "NextOfKin_EN");
            med.SimpleAddGroup(2, main, 2, "InHisImage_EN");
            med.SimpleAddGroup(2, main, 2, "InHerImage_EN");
            med.SimpleAddGroup(3, main, 1, "ChoirBoy_EN");
            med.SimpleAddGroup(3, main, 1, "EyePalm_EN");
            med.SimpleAddGroup(2, main, 2, "EyePalm_EN");

            med.SimpleAddGroup(2, main, 1, "BlackStar_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(2, main, 1, "Vivarium_EN", 1, Ecstasy.Gray);
            med.SimpleAddGroup(2, main, 1, "Indicator_EN", 1, "MiniReaper_EN");
            med.SimpleAddGroup(2, main, 1, "Panopticon_EN", 1, Enemies.Shivering);
            med.SimpleAddGroup(2, main, 1, Flower.Yellow, 1, Flower.Purple);
            med.SimpleAddGroup(2, main, 1, "Insider_EN", 1, "Children6_EN");
            med.SimpleAddGroup(2, main, 1, Enemies.Camera, 2, "TortureMeNot_EN");
            med.SimpleAddGroup(2, main, 1, "Damocles_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(2, main, 1, "EvilDog_EN", 1, "Vivarium_EN");
            med.SimpleAddGroup(2, main, 1, "Lightbulbkin_EN", 1, "EyePalm_EN");
            med.SimpleAddGroup(2, main, 1, "Lightbulbkin_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(2, main, 1, "Grandfather_EN", 1, "Vivarium_EN");
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

            Troller_Easy(new AddTo(Garden.H.Troller.Help.Easy), Enemies.Help);
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

            Troller_Med(new AddTo(Garden.H.Troller.Help.Med), Enemies.Help);
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

            Troller_Easy(new AddTo(Garden.H.Troller.Reckoner.Easy), Enemies.Reckoner);

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

            Troller_Med(new AddTo(Garden.H.Troller.Reckoner.Med), Enemies.Reckoner);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.SimpleAddGroup(1, "Satyr_EN", 2, Troller);
            med.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, Enemies.Shivering);
            med.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, "Merced_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 3, Troller);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, "ChoirBoy_EN");
            hard.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, "GlassFigurine_EN");
            hard.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, "EyePalm_EN");
            hard.SimpleAddGroup(1, "Satyr_EN", 2, Troller, 1, "Shua_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.SimpleAddGroup(1, Spoggle.Grey, 3, Troller);
            med.SimpleAddGroup(1, Spoggle.Grey, 2, Troller, 1, "PawnA_EN");
            med.SimpleAddGroup(1, Spoggle.Grey, 1, Troller, 2, "PawnA_EN");
            med.SimpleAddGroup(1, Spoggle.Grey, 2, Troller, 1, "Indicator_EN");

            AddTo easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, Troller, Flower.Yellow);
            easy.AddRandomGroup(Flower.Red, Troller, Flower.Purple);
            easy.AddRandomGroup(Flower.Red, Troller, Enemies.Shivering);
            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Troller, Troller);
            med.AddRandomGroup(Flower.Red, Flower.Yellow, Troller, Troller);
            med.AddRandomGroup(Flower.Red, Flower.Purple, Troller, Troller);
            AddTo easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, Troller, Flower.Yellow);
            easy.AddRandomGroup(Flower.Blue, Troller, Flower.Purple);
            easy.AddRandomGroup(Flower.Blue, Troller, Enemies.Shivering);
            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Troller, Troller);
            med.AddRandomGroup(Flower.Blue, Flower.Yellow, Troller, Troller);
            med.AddRandomGroup(Flower.Blue, Flower.Purple, Troller, Troller);



        }
    }
}
