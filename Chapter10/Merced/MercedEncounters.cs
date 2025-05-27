using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MercedEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Hard();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_MercedEncounter_Sign", ResourceLoader.LoadSprite("MercedWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Merced.Easy, "Salt_MercedEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/MercedSong";
            easy.RoarEvent = "event:/Hawthorne/Attack2/Rainy";

            easy.AddRandomEncounter("Merced_EN");
            easy.AddRandomEncounter("Merced_EN", "Merced_EN", "Merced_EN", "Merced_EN", "Merced_EN");
            easy.AddRandomEncounter("Merced_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN");
            easy.AddRandomEncounter("Merced_EN", "NextOfKin_EN", "NextOfKin_EN", "NextOfKin_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Merced.Easy, 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Merced.Hard, "Salt_MercedEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/MercedSong";
            hard.RoarEvent = "event:/Hawthorne/Attack2/Rainy";

            hard.AddRandomEncounter("Merced_EN", Flower.Red, Flower.Blue, Flower.Yellow, Flower.Purple);
            hard.AddRandomEncounter("Merced_EN", Enemies.Skinning, Enemies.Skinning, Enemies.Skinning);
            hard.AddRandomEncounter("Merced_EN", "ChoirBoy_EN", "Grandfather_EN");
            hard.AddRandomEncounter("Merced_EN", Enemies.Minister, Enemies.Minister, Enemies.Minister);
            hard.AddRandomEncounter("Merced_EN", "Satyr_EN", "Satyr_EN", Enemies.Camera);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Merced.Hard, 1, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Garden.H.InHerImage.Easy);
            if (SaltsReseasoned.rando == 1) easy.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "Merced_EN");

            AddTo med = new AddTo(Garden.H.InHerImage.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHerImage_EN", "Merced_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            if (SaltsReseasoned.rando == 2) easy.AddRandomGroup("ChoirBoy_EN", "ChoirBoy_EN", "Merced_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Merced_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            if (SaltsReseasoned.rando == 3) hard.AddRandomGroup(Enemies.Skinning, "ChoirBoy_EN", "Merced_EN", "LittleAngel_EN");

            easy = new AddTo(Garden.H.Minister.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Merced_EN");

            med = new AddTo(Garden.H.Minister.Med);
            if (SaltsReseasoned.rando == 4) med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "Merced_EN");

            easy = new AddTo(Garden.H.LittleAngel.Easy);
            if (SaltsReseasoned.rando == 5) easy.AddRandomGroup("LittleAngel_EN", "LittleAngel_EN", "LittleAngel_EN", "Merced_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            if (SaltsReseasoned.rando == 6) med.AddRandomGroup(Jumble.Grey, "InHisImage_EN", "InHerImage_EN", "Merced_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            if (SaltsReseasoned.rando == 7) med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHerImage_EN", "Merced_EN");

            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            if (SaltsReseasoned.rando == 8) easy.AddRandomGroup(Flower.Blue, Flower.Red, "Merced_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            if (SaltsReseasoned.rando == 9) easy.AddRandomGroup(Flower.Red, Flower.Blue, "Merced_EN");

            med = new AddTo(Garden.H.Camera.Med);
            if (SaltsReseasoned.rando == 10) med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Camera, Enemies.Camera, "Merced_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Shivering, "Merced_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, "ChoirBoy_EN", "ClockTower_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            if (SaltsReseasoned.rando == 11) med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "Merced_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            if (SaltsReseasoned.rando == 12) easy.AddRandomGroup("EyePalm_EN", "EyePalm_EN", "EyePalm_EN", "Merced_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("EyePalm_EN", "EyePalm_EN", "InHisImage_EN", "InHerImage_EN", "Merced_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Merced_EN");
        }
    }
}
