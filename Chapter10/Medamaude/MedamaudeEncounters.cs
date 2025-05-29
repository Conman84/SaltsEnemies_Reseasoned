using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MedamaudeEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Med();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_MedamaudeEncounter_Sign", ResourceLoader.LoadSprite("EyePalmWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.EyePalm.Easy, "Salt_MedamaudeEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/EyePalmSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", Enemies.Shivering, Enemies.Shivering);
            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "NextOfKin_EN");
            easy.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.EyePalm.Easy, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.EyePalm.Med, "Salt_MedamaudeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EyePalmSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._roarReference.roarEvent;

            med.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "MiniReaper_EN");
            med.AddRandomEncounter("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.EyePalm.Med, 6, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHerImage_EN", "EyePalm_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHisImage_EN", "EyePalm_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "EyePalm_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHisImage_EN", "EyePalm_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHerImage_EN", "EyePalm_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", "EyePalm_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", "ChoirBoy_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "EyePalm_EN");
            hard.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup(Enemies.Skinning, "Satyr_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Minister, "InHisImage_EN", "InHisImage_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Minister, "ChoirBoy_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "EyePalm_EN", "EyePalm_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup(Enemies.Minister, "ChoirBoy_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Satyr_EN", "InHisImage_EN", "InHisImage_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup("Satyr_EN", Enemies.Skinning, "EyePalm_EN", "EyePalm_EN");

            AddTo easy = new AddTo(Garden.H.WindSong.Easy);
            easy.AddRandomGroup("WindSong_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, "EyePalm_EN", "EyePalm_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("ClockTower_EN", "ChoirBoy_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "EyePalm_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", "EyePalm_EN");
            med.AddRandomGroup("MiniReaper_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("MiniReaper_EN", "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "InHisImage_EN", "InHisImage_EN", "EyePalm_EN");
        }
    }
}
