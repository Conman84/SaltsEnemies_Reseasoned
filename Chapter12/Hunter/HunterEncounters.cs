using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class HunterEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_HunterEncounter_Sign", ResourceLoader.LoadSprite("HunterWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Hunter.Med, "Salt_HunterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/HunterSong";
            med.RoarEvent = "event:/Hawthorne/Roar/HunterRoar";

            med.AddRandomEncounter("Hunter_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 3, "InHisImage_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 3, Enemies.Shivering);
            med.AddRandomEncounter("Hunter_EN", "ChoirBoy_EN", Flower.Red);
            med.AddRandomEncounter("Hunter_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "WindSong_EN", "Grandfather_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "WindSong_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "Grandfather_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "WindSong_EN", "Shua_EN");
            med.AddRandomEncounter("Hunter_EN", "MiniReaper_EN", "Shua_EN", "GlassFigurine_EN");
            med.SimpleAddEncounter(1, "Hunter_EN", 1, "Skyloft_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", "Shua_EN", "WindSong_EN");
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Hunter_EN", "Damocles_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Hunter_EN", "EyePalm_EN", "EyePalm_EN", "Shua_EN");
            med.AddRandomEncounter("Hunter_EN", "EyePalm_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Hunter_EN", "InHisImage_EN", "InHisImage_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Hunter_EN", "InHerImage_EN", "InHerImage_EN", "NextOfkin_EN");
            med.AddRandomEncounter("Hunter_EN", "InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("Hunter_EN", Flower.Grey, "GlassFigurine_EN");
            med.AddRandomEncounter("Hunter_EN", Flower.Grey, "Shua_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Hunter.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Hunter_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Satyr_EN", "Hunter_EN", Enemies.Minister);

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Hunter_EN", Enemies.Skinning);
            hard.AddRandomGroup("Satyr_EN", "Hunter_EN", "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Hunter_EN", "Damocles_EN");
            med.AddRandomGroup(Flower.Red, "Hunter_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, "Hunter_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, Flower.Red, "Hunter_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "Hunter_EN", Enemies.Minister);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Hunter_EN", Enemies.Skinning, Enemies.Shivering);
            hard.AddRandomGroup("ClockTower_EN", "Hunter_EN", "InHerImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "Hunter_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "Hunter_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Hunter_EN");
            hard.AddRandomGroup(Enemies.Tank, "Hunter_EN", "GlassFigurine_EN");
            hard.AddRandomGroup(Enemies.Tank, "Hunter_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Hunter_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Shua_EN", "Hunter_EN", "Grandfather_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Hunter_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "Hunter_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Hunter_EN");
            med.AddRandomGroup(Enemies.Skinning, "Hunter_EN", "Damocles_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Hunter_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Hunter_EN", "MiniReaper_EN");
        }
    }
}
