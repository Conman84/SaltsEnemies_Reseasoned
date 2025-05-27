using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ShuaEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Med();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_ShuaEncounter_Sign", ResourceLoader.LoadSprite("ShuaWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Shua.Easy, "Salt_ShuaEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/NewerShuaTheme";
            easy.RoarEvent = "event:/Hawthorne/Attack3/Censored";

            easy.SimpleAddEncounter(1, "Shua_EN", 4, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "Shua_EN", 2, "InHerImage_EN");
            easy.SimpleAddEncounter(1, "Shua_EN", 2, "InHisImage_EN");
            easy.SimpleAddEncounter(1, "Shua_EN", 3, "NextOfKin_EN");
            easy.AddRandomEncounter("Shua_EN", "WindSong_EN", "Skyloft_EN");
            easy.AddRandomEncounter("Shua_EN", "WindSong_EN", "NextOfKin_EN", "NextOfKin_EN");
            easy.AddRandomEncounter("Shua_EN", "LittleAngel_EN");
            easy.AddRandomEncounter("Shua_EN", Flower.Red);
            easy.AddRandomEncounter("Shua_EN", Flower.Blue);
            easy.AddRandomEncounter("Shua_EN", "EyePalm_EN", "EyePalm_EN");
            easy.AddRandomEncounter("Shua_EN", "ChoirBoy_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Shua.Easy, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Shua.Med, "Salt_ShuaEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewerShuaTheme";
            med.RoarEvent = "event:/Hawthorne/Attack3/Censored";

            med.SimpleAddEncounter(1, "Shua_EN", 3, "InHerImage_EN");
            med.SimpleAddEncounter(1, "Shua_EN", 2, "InHerImage_EN", 1, "InHisImage_EN");
            med.AddRandomEncounter("Shua_EN", "InHerImage_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Shua_EN", "InHerImage_EN", "InHerImage_EN", "EyePalm_EN");
            med.AddRandomEncounter("Shua_EN", "InHerImage_EN", "InHisImage_EN", "EyePalm_EN");
            med.SimpleAddEncounter(1, "Shua_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Shua_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Shua_EN", Flower.Red, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Shua_EN", Flower.Blue, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Shua_EN", "InHerImage_EN", "InHerImage_EN", "WindSong_EN");
            med.SimpleAddEncounter(1, "Shua_EN", 3, Enemies.Camera);
            med.AddRandomEncounter("Shua_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Shua_EN", "Grandfather_EN", "InHisImage_EN", "InHisImage_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Shua.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "Shua_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Shua_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "ChoirBoy_EN", "Shua_EN");
            med.AddRandomGroup(Enemies.Minister, Jumble.Grey, "Shua_EN");
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "Shua_EN");

            AddTo easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "Shua_EN", "LittleAngel_EN");
        }
    }
}
