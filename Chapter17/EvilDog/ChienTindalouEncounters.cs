using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.AI;

namespace SaltsEnemies_Reseasoned
{
    public static class ChienTindalouEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ChienTindalouEncounter_Sign", ResourceLoader.LoadSprite("EvilDogWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.EvilDog.Med, "Salt_ChienTindalouEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EvilDogTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("LongLiver_CH").deathSound;

            med.SimpleAddEncounter(4, "EvilDog_EN");
            if (SaltsReseasoned.trolling > 40 && SaltsReseasoned.trolling < 60) med.SimpleAddEncounter(5, "EvilDog_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "WindSong_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "Grandfather_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "GlassFigurine_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "Indicator_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "MiniReaper_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, Flower.Blue);
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, Flower.Red);
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "ChoirBoy_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "LittleAngel_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "EyePalm_EN");
            med.SimpleAddEncounter(3, "EvilDog_EN", 1, "BlackStar_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.EvilDog.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "EvilDog_EN", "EvilDog_EN");

            AddTo hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, "EvilDog_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "EvilDog_EN", "EvilDog_EN", "TortureMeNot_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "EvilDog_EN", "EvilDog_EN", "Damocles_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "EvilDog_EN", "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "EvilDog_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "EvilDog_EN", "EvilDog_EN", "Damocles_EN");
        }
    }
}
