using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.AI;

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
            easy.AddRandomEncounter("Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);
            easy.AddRandomEncounter("Lightbulbkin_EN", "ChoirBoy_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lightbulbkin.Easy, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Lightbulbkin.Med, "Salt_LightbulbkinEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LightbulbkinTheme";
            med.RoarEvent = "event:/Hawthorne/Nois2/RusticDeath";

            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 2, "NextOfKin_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "InHisImage_EN", "InHerImage_EN", "NextOfKin_EN");
            med.SimpleAddEncounter(3, "Lightbulbkin_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, Flower.Red, 1, "Merced_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, Flower.Blue, 1, "Skyloft_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "WindSong_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("Lightbulbkin_EN", "Lightbulbkin_EN", "Grandfather_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "Lightbulbkin_EN", "MiniReaper_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 2, "EyePalm_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "Lightbulbkin_EN", "Shua_EN", "Damocles_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "Lightbulbkin_EN", "Indicator_EN", "LittleAngel_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 2, "EvilDog_EN");
            med.AddRandomEncounter("Lightbulbkin_EN", "BlackStar_EN", Enemies.Shivering, Enemies.Shivering, Enemies.Shivering);
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, "Yang_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, Spoggle.Gray);
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, Jumble.Gray, 1, "GlassFigurine_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, "Panopticon_EN", 1, "Damocles_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, "Celebration_EN");
            med.SimpleAddEncounter(2, "Lightbulbkin_EN", 1, "ChoirBoy_EN");
            med.SimpleAddEncounter(1, "Lightbulbkin_EN", 3, "Insider_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Lightbulbkin.Med, 10 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 1, "Lightbulbkin_EN");
            med.SimpleAddGroup(2, "InHisImage_EN", 1, "Lightbulbkin_EN", 1, Enemies.Shivering);

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(3, "InHerImage_EN", 1, "Lightbulbkin_EN");
            med.SimpleAddGroup(2, "InHerImage_EN", 1, "Lightbulbkin_EN", 1, Enemies.Shivering);

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Lightbulbkin_EN", Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Lightbulbkin_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Lightbulbkin_EN", "Lightbulbkin_EN");
            med.AddRandomGroup(Enemies.Minister, "Lightbulbkin_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.SimpleAddGroup(2, Enemies.Minister, 1, "Lightbulbkin_EN");
            hard.AddRandomGroup(Enemies.Minister, "Lightbulbkin_EN", "InHerImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.Foundling.Med);
            med.SimpleAddGroup(2, Enemies.Foundling, 1, "Lightbulbkin_EN");
            med.SimpleAddGroup(1, Enemies.Foundling, 2, "Lightbulbkin_EN");
            med.AddRandomGroup(Enemies.Foundling, "Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN");

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.AddRandomGroup(Enemies.Foundling, "Lightbulbkin_EN", "Lightbulbkin_EN", Enemies.Foundling);
            hard.SimpleAddGroup(3, Enemies.Foundling, 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Lightbulbkin_EN", "InHisImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Gray, "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, Flower.Blue, "Lightbulbkin_EN");
            med.AddRandomGroup(Flower.Red, Flower.Grey, "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Gray, Flower.Red, Flower.Yellow, "Lightbulbkin_EN");
            hard.AddRandomGroup(Flower.Gray, Flower.Red, Flower.Purple, "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Lightbulbkin_EN", "InHerImage_EN", "InHerImage_EN", "NextOfKin_EN");
            hard.AddRandomGroup("ClockTower_EN", "Lightbulbkin_EN", "Lightbulbkin_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.SimpleAddGroup(1, "MiniReaper_EN", 1, "Lightbulbkin_EN", 2, "InHisImage_EN");
            med.SimpleAddGroup(1, "MiniReaper_EN", 1, "Lightbulbkin_EN", 2, "InHerImage_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Lightbulbkin_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Lightbulbkin_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Lightbulbkin_EN", "BlackStar_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Lightbulbkin_EN", "InHerImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Lightbulbkin_EN", "Lightbulbkin_EN");
            med.AddRandomGroup(Bots.Grey, "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Lightbulbkin_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(1, "Lightbulbkin_EN", 3, "EvilDog_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("PersonalAngel_EN", "Lightbulbkin_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Lightbulbkin_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup("Eyeless_EN", "Lightbulbkin_EN", "Starless_EN");

            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 1, "Lightbulbkin_EN");
            med.AddRandomGroup("Yang_EN", "Lightbulbkin_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Lightbulbkin_EN");
            hard.AddRandomGroup("Yang_EN", "Lightbulbkin_EN", "InHisImage_EN", "InHerImage_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");
            med.AddRandomGroup("CorpseChan_EN", "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Dark.Med);
            //med.AddRandomGroup("InTheDark_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            //hard.AddRandomGroup("InTheDark_EN", "Lightbulbkin_EN", "InHerImage_EN", "InHerImage_EN");
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Sundowner.Med);
            med.SimpleAddGroup(3, "Sundowner_EN", 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(2, Ecstasy.Gray, 2, "Lightbulbkin_EN");
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "Lightbulbkin_EN", "EyePalm_EN", "EyePalm_EN");
            med.SimpleAddGroup(1, Enemies.Eclipse, 2, "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.AddRandomGroup("Celebration_EN", "Celebration_EN", "Lightbulbkin_EN");
            med.AddRandomGroup("Celebration_EN", "Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN");

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 2, "Lightbulbkin_EN");
            hard.AddRandomGroup("Celebration_EN", "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering, Enemies.Shivering);
        }
    }
}
