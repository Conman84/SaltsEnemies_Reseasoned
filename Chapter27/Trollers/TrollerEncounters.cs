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
            med.SimpleAddGroup(2, main, 1, "WindSong_EN", 1, "EyePalm_EN");
            med.SimpleAddGroup(2, main, 1, "WindSong_EN", 1, "Children6_EN");
            med.SimpleAddGroup(2, main, 1, "WindSong_EN", 1, "Merced_EN");
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
            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, Troller, Flower.Yellow);
            easy.AddRandomGroup(Flower.Blue, Troller, Flower.Purple);
            easy.AddRandomGroup(Flower.Blue, Troller, Enemies.Shivering);
            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Troller, Troller);
            med.AddRandomGroup(Flower.Blue, Flower.Yellow, Troller, Troller);
            med.AddRandomGroup(Flower.Blue, Flower.Purple, Troller, Troller);

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.SimpleAddGroup(1, Flower.Grey, 2, Troller);
            med.SimpleAddGroup(1, Flower.Grey, 3, Troller);
            med.SimpleAddGroup(1, Flower.Grey, 2, Troller, 1, "LittleAngel_EN");
            med.SimpleAddGroup(1, Flower.Grey, 2, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(1, Flower.Grey, 2, Troller, 1, "Damocles_EN");
            med.SimpleAddGroup(1, Flower.Grey, 2, Troller, 1, "Vivarium_EN");
            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Troller, Troller);
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Troller, Troller);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, Troller);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Troller, Troller);
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, Troller);
            hard.SimpleAddGroup(1, "ClockTower_EN", 4, Troller);
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, Troller, 2, "PawnA_EN");
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, Troller, 1, "Grandfather_EN");

            easy = new AddTo(Garden.H.WindSong.Easy);
            easy.SimpleAddGroup(1, "WindSong_EN", 2, Troller);
            easy.SimpleAddGroup(1, "WindSong_EN", 1, Troller, 3, "NextOfKin_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.SimpleAddGroup(1, "Grandfather_EN", 3, Troller);
            med.SimpleAddGroup(1, "Grandfather_EN", 2, Troller, 1, "Children6_EN");
            med.SimpleAddGroup(1, "Grandfather_EN", 2, Troller, 1, "WindSong_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, Troller);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, Troller);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, Troller);

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Troller);
            hard.AddRandomGroup("SnakeGod_EN", Troller, Troller);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, Troller);
            hard.SimpleAddGroup(1, "Miriam_EN", 3, Troller);

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.SimpleAddGroup(1, "MiniReaper_EN", 3, Troller);
            med.SimpleAddGroup(1, "MiniReaper_EN", 1, Troller, 2, "InHerImage_EN");
            med.SimpleAddGroup(1, "MiniReaper_EN", 2, Troller, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(1, "MiniReaper_EN", 2, Troller, 1, "Indicator_EN");

            hard = new AddTo(Garden.H.Merced.Hard);
            hard.SimpleAddGroup(1, "Merced_EN", 4, Troller);

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Troller);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Troller);
            med.SimpleAddGroup(2, "EyePalm_EN", 1, Troller, 1, Enemies.Shivering);
            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.SimpleAddGroup(2, "EyePalm_EN", 1, Troller);
            easy.SimpleAddGroup(2, "EyePalm_EN", 1, Troller);

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.SimpleAddGroup(1, "Shua_EN", 2, Troller);
            easy.AddRandomGroup("Shua_EN", Troller, Enemies.Shivering);
            easy.AddRandomGroup("Shua_EN", Troller, "EyePalm_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.SimpleAddGroup(1, "Shua_EN", 3, Troller);
            med.SimpleAddGroup(1, "Shua_EN", 2, "EyePalm_EN", 1, Troller);
            med.SimpleAddGroup(1, "Shua_EN", 2, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(1, "Shua_EN", 2, Troller, 1, "GlassFigurine_EN");

            easy = new AddTo(Garden.H.GlassFigurine.Easy);
            easy.SimpleAddGroup(1, "GlassFigurine_EN", 2, Troller);
            easy.SimpleAddGroup(1, "GlassFigurine_EN", 1, Troller, 3, "NextOfKin_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.SimpleAddGroup(1, "Hunter_EN", 3, Troller);
            med.SimpleAddGroup(1, "Hunter_EN", 2, Troller);
            med.SimpleAddGroup(1, "Hunter_EN", 2, Troller, 1, "EyePalm_EN");
            med.SimpleAddGroup(1, "Hunter_EN", 2, Troller, 1, "Indicator_EN");
            med.SimpleAddGroup(1, "Hunter_EN", 2, Troller, 1, "BlackStar_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.SimpleAddGroup(1, "Firebird_EN", 3, Troller);
            med.SimpleAddGroup(1, "Firebird_EN", 2, Troller);
            med.SimpleAddGroup(1, "Firebird_EN", 2, Troller, 1, "Damocles_EN");
            med.SimpleAddGroup(1, "Firebird_EN", 2, Troller, 1, "LittleAngel_EN");
            med.SimpleAddGroup(1, "Firebird_EN", 2, Troller, 1, "BlackStar_EN");

            easy = new AddTo(Garden.H.Indicator.Easy);
            easy.SimpleAddGroup(1, "Indicator_EN", 2, Troller);

            med = new AddTo(Garden.H.Indicator.Med);
            med.SimpleAddGroup(2, "Indicator_EN", 2, Troller);
            med.SimpleAddGroup(1, "Indicator_EN", 2, Troller, 1, "GlassFigurine_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.SimpleAddGroup(1, "YNL_EN", 3, Troller);
            med.SimpleAddGroup(1, "YNL_EN", 2, Troller, 1, "Damocles_EN");
            med.SimpleAddGroup(1, "YNL_EN", 2, Troller, 1, "Grandfather_EN");
            med.SimpleAddGroup(1, "YNL_EN", 2, Troller, 1, Enemies.Camera);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.SimpleAddGroup(1, "Stoplight_EN", 2, Troller);
            med.SimpleAddGroup(1, "Stoplight_EN", 1, Troller, 1, Ecstasy.Gray);
            med.SimpleAddGroup(1, "Stoplight_EN", 2, Troller, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(1, "Stoplight_EN", 2, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(1, "Stoplight_EN", 2, Troller, 1, "Merced_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.SimpleAddGroup(1, "Stoplight_EN", 3, Troller);
            hard.SimpleAddGroup(1, "Stoplight_EN", 1, Troller, 3, "PawnA_EN");
            hard.SimpleAddGroup(1, "Stoplight_EN", 2, Troller, 1, "YNL_EN");
            hard.SimpleAddGroup(1, "Stoplight_EN", 2, Troller, 1, "Starless_EN");
            hard.SimpleAddGroup(1, "Stoplight_EN", 2, Troller, 1, "Yang_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.SimpleAddGroup(1, Bots.Grey, 3, Troller);
            med.SimpleAddGroup(1, Bots.Grey, 2, Troller, 1, "Vivarium_EN");
            med.SimpleAddGroup(1, Bots.Grey, 2, Troller, 1, "Grandfather_EN");
            med.SimpleAddGroup(1, Bots.Grey, 2, Troller, 1, "WindSong_EN");
            med.SimpleAddGroup(1, Bots.Grey, 2, Troller, 1, "LittleAngel_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, Troller);

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, Troller);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, Troller);
            med.SimpleAddGroup(2, "EvilDog_EN", 2, Troller);

            med = new AddTo(Garden.H.Complimentary.Med);
            med.SimpleAddGroup(1, "Complimentary_EN", 2, Troller);
            med.SimpleAddGroup(1, "Complimentary_EN", 1, Troller, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(1, "Complimentary_EN", 1, Troller, 1, Bots.Grey);
            med.SimpleAddGroup(1, "Complimentary_EN", 1, Troller, 1, "Yang_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", Troller, Troller);
            med.AddRandomGroup("PersonalAngel_EN", Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("PersonalAngel_EN", Troller, "Children6_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.SimpleAddGroup(1, "Starless_EN", 3, Troller);
            med.AddRandomGroup("Starless_EN", Troller, Troller);
            med.AddRandomGroup("Starless_EN", Troller, Troller, "Vivarium_EN");
            med.SimpleAddGroup(1, "Starless_EN", 2, Troller, 1, "GlassFigurine_EN");
            med.AddRandomGroup("Starless_EN", Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Starless_EN", Troller, "EvilDog_EN");
            med.AddRandomGroup("Starless_EN", Troller, "Insider_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Troller, Troller, Troller);
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, Troller);
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, Troller, 1, "BlackStar_EN");
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, Troller, 1, "Grandfather_EN");
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, Troller, 1, "PawnA_EN");
            hard.AddRandomGroup("Eyeless_EN", Troller, "ChoirBoy_EN");
            hard.AddRandomGroup("Eyeless_EN", Troller, Enemies.Foundling);

            easy = new AddTo(Garden.H.Pawn.Easy);
            easy.SimpleAddGroup(2, "PawnA_EN", 1, Troller);
            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, Troller);

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(1, "Yang_EN", 2, Troller, 1, "PawnA_EN");
           // med.SimpleAddGroup(2, "Yang_EN", 2, Troller);
            med.SimpleAddGroup(2, "Yang_EN", 1, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(2, "Yang_EN", 1, Troller, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(1, "Yang_EN", 2, Troller, 1, "Vivarium_EN");
            med.SimpleAddGroup(1, "Yang_EN", 2, Troller, 1, Jumble.Gray);

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, Troller);
            hard.SimpleAddGroup(2, "Yang_EN", 2, Troller);
            hard.SimpleAddGroup(2, "Yang_EN", 1, Troller, 2, "PawnA_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", Troller);
            hard.AddRandomGroup("Yin_EN", "Yin_EN", Troller);
            hard.AddRandomGroup("Yin_EN", Troller, Troller);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", Troller, Troller);
            med.AddRandomGroup("CorpseChan_EN", Troller, "LittleAngel_EN");
            med.AddRandomGroup("CorpseChan_EN", Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("CorpseChan_EN", Troller, Flower.Blue);
            med.AddRandomGroup("CorpseChan_EN", Troller, Flower.Red);

            med = new AddTo(Garden.H.Dark.Med);
            med.SimpleAddGroup(1, "InTheDark_EN", 2, Troller);
            med.AddRandomGroup("InTheDark_EN", Troller, "ChoirBoy_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", Troller, Troller);
            med.AddRandomGroup("Lunoscope_EN", Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Lunoscope_EN", Troller, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Lunoscope_EN", Troller, Troller, "Damocles_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.SimpleAddGroup(1, "Lunoscope_EN", 3, Troller);
            hard.AddRandomGroup("Lunoscope_EN", Troller, Troller, Ecstasy.Gray);
            hard.AddRandomGroup("Lunoscope_EN", Troller, Troller, "Vivarium_EN", "Vivarium_EN");
            hard.AddRandomGroup("Lunoscope_EN", Troller, "OdeToHumanity_EN");
            hard.AddRandomGroup("Lunoscope_EN", Troller, "Starless_EN");
            hard.AddRandomGroup("Lunoscope_EN", Troller, Bots.Grey);

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, Troller);
            med.SimpleAddGroup(2, "Panopticon_EN", 2, Troller);
            med.SimpleAddGroup(2, "Panpoticon_EN", 1, Troller, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(2, "Panpoticon_EN", 1, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(2, "Panpoticon_EN", 1, Troller, 1, "Vivarium_EN");
            med.SimpleAddGroup(2, "Panpoticon_EN", 1, Troller, 1, "Damocles_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, Troller);
            med.SimpleAddGroup(2, Ecstasy.Gray, 2, Troller);
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, Troller, 1, "PawnA_EN");
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, Troller, 1, Enemies.Shivering);
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, Troller, 1, "Indicator_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.SimpleAddGroup(1, Enemies.Eclipse, 2, Troller);
            med.AddRandomGroup(Enemies.Eclipse, Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Eclipse, Troller, "Panopticon_EN");
            med.AddRandomGroup(Enemies.Eclipse, Troller, "Yang_EN");
            med.AddRandomGroup(Enemies.Eclipse, Troller, "Celebration_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.AddRandomGroup(Enemies.Eclipse, Enemies.Eclipse, Troller);
            hard.SimpleAddGroup(1, Enemies.Eclipse, 3, Troller);
            hard.AddRandomGroup(Enemies.Eclipse, Troller, "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Eclipse, Troller, Troller, "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(1, "Celebration_EN", 2, Troller);
            med.AddRandomGroup("Celebration_EN", Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Celebration_EN", Troller, "Panopticon_EN");
            med.AddRandomGroup("Celebration_EN", Troller, "EvilDog_EN");
            med.AddRandomGroup("Celebration_EN", Troller, Bots.Grey);

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 1, Troller);
            hard.SimpleAddGroup(1, "Celebration_EN", 3, Troller);
            hard.AddRandomGroup("Celebration_EN", Troller, Troller, "BlackStar_EN");
            hard.AddRandomGroup("Celebration_EN", Troller, Troller, "PawnA_EN");
            hard.AddRandomGroup("Celebration_EN", Troller, Troller, "WindSong_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, Troller, 1, "BlackStar_EN");

            //basegame!???
            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.SimpleAddGroup(2, "InHerImage_EN", 1, Troller);
            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.SimpleAddGroup(2, "InHisImage_EN", 1, Troller);

            Image_Med(new AddTo(Garden.H.InHisImage.Med), "InHisImage_EN");
            Image_Med(new AddTo(Garden.H.InHerImage.Med), "InHerImage_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Troller, Troller);
            med.AddRandomGroup(Enemies.Skinning, Troller, Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, Troller,  "PawnA_EN");
            med.AddRandomGroup(Enemies.Skinning, Troller, Troller, "BlackStar_EN");
            med.AddRandomGroup(Enemies.Skinning, Troller, Troller, "Vivarium_EN");
            med.AddRandomGroup(Enemies.Skinning, Troller, "Panopticon_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Troller, Troller, Troller);
            hard.SimpleAddGroup(1, Enemies.Skinning, 1, Troller, 2, Enemies.Shivering);
            hard.SimpleAddGroup(1, Enemies.Skinning, 1, Troller, 2, "PawnA_EN");
            hard.AddRandomGroup(Enemies.Skinning, Troller, "Lunoscope_EN");
            hard.AddRandomGroup(Enemies.Skinning, Troller, "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Satyr_EN", Troller);

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.SimpleAddGroup(1, "ChoirBoy_EN", 2, Troller);

            easy = new AddTo(Garden.H.Minister.Easy);
            easy.AddRandomGroup(Enemies.Minister, Troller, Enemies.Shivering);
            easy.AddRandomGroup(Enemies.Minister, Troller, "PawnA_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.SimpleAddGroup(1, Enemies.Minister, 2, Troller);
            med.SimpleAddGroup(1, Enemies.Minister, 1, Troller, 1, "Indicator_EN");
            med.SimpleAddGroup(1, Enemies.Minister, 2, Troller, 1, "Vivarium_EN");
            med.AddRandomGroup(Enemies.Minister, Enemies.Troller, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Minister, Enemies.Troller, "BlackStar_EN", "BlackStar_EN");
            med.AddRandomGroup(Enemies.Minister, Enemies.Troller, "Damocles_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.SimpleAddGroup(1, Enemies.Minister, 3, Troller);
            hard.SimpleAddGroup(2, Enemies.Minister, 1, Troller);
            hard.AddRandomGroup(Enemies.Minister, Troller, Troller, "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Minister, Troller, Troller, "Yang_EN");
            hard.AddRandomGroup(Enemies.Minister, Troller, Troller, "Indicator_EN");
            hard.AddRandomGroup(Enemies.Minister, Troller, Troller, "Shua_EN");

            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, Troller, Troller);
            med.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, Troller);
            med.AddRandomGroup(Enemies.Foundling, Troller, Flower.Red);
            med.AddRandomGroup(Enemies.Foundling, Troller, Flower.Blue);
            med.AddRandomGroup(Enemies.Foundling, Troller, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Foundling, Troller, "CorpseChan_EN");

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.SimpleAddGroup(1, Enemies.Foundling, 3, Troller);
            hard.SimpleAddGroup(3, Enemies.Foundling, 1, Troller);
            hard.SimpleAddGroup(2, Enemies.Foundling, 2, Troller);
            hard.AddRandomGroup(Enemies.Foundling, Troller, Troller, "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Foundling, Troller, "Sundowner_EN", "Sundowner_EN");
            hard.AddRandomGroup(Enemies.Foundling, Troller, Troller, "Celebration_EN");
            hard.AddRandomGroup(Enemies.Foundling, Troller, "Starless_EN");
        }

        public static void Image_Med(AddTo med, string main)
        {
            med.SimpleAddGroup(2, main, 2, Troller);
            med.SimpleAddGroup(3, main, 1, Troller);
            med.SimpleAddGroup(2, main, 1, Troller, 2, "NextOfKin_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Panopticon_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, Ecstasy.Gray);
            med.SimpleAddGroup(2, main, 1, Troller, 1, Flower.Red);
            med.SimpleAddGroup(2, main, 1, Troller, 1, Flower.Blue);
            med.SimpleAddGroup(2, main, 1, Troller, 1, "WindSong_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "EvilDog_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "MiniReaper_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Damocles_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, Jumble.Gray);
            med.SimpleAddGroup(2, main, 1, Troller, 1, Enemies.Camera);
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Indicator_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Children6_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "BlackStar_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 2, "TortureMeNot_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "PawnA_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "EyePalm_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Vivarium_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Lightbulbkin_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "Insider_EN");
            med.SimpleAddGroup(2, main, 1, Troller, 1, "LittleAngel_EN");
        }
    }
}
