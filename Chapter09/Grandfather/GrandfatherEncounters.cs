using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class GrandfatherEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_GrandfatherEncounter_Sign", ResourceLoader.LoadSprite("CoffinWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Grandfather.Med, "Salt_GrandfatherEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewCoffinTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.AddRandomEncounter("Grandfather_EN", "InHisImage_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Grandfather_EN", "InHisImage_EN", "InHisImage_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Grandfather_EN", "ChoirBoy_EN", "LittleAngel_EN");
            med.AddRandomEncounter("Grandfather_EN", "InHisImage_EN", "InHisImage_EN", "LittleAngel_EN");
            med.AddRandomEncounter("Grandfather_EN", Flower.Red, Flower.Blue, "LittleAngel_EN");
            med.AddRandomEncounter("Grandfather_EN", "MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN");
            med.AddRandomEncounter("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "WindSong_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Grandfather.Med, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHerImage_EN", "Grandfather_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHisImage_EN", "Grandfather_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "LittleAngel_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHisImage_EN", "Grandfather_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHerImage_EN", "Grandfather_EN");
            med.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "LittleAngel_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, Enemies.Shivering, "Grandfather_EN");
            med.AddRandomGroup(Enemies.Skinning, "ChoirBoy_EN", "Grandfather_EN");
            med.AddRandomGroup(Enemies.Skinning, "LittleAngel_EN", "Grandfather_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "Grandfather_EN");
            hard.AddRandomGroup(Enemies.Skinning, "InHerImage_EN", "InHerImage_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "Grandfather_EN");
            med.AddRandomGroup(Enemies.Minister, "LittleAngel_EN", "Grandfather_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Satyr_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Grandfather_EN", "LittleAngel_EN");
            med.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "Grandfather_EN");
            med.AddRandomGroup("Satyr_EN", "Grandfather_EN", "WindSong_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "InHerImage_EN", "InHerImage_EN", "Grandfather_EN");
            hard.AddRandomGroup("Satyr_EN", "InHisImage_EN", "InHisImage_EN", "Grandfather_EN");
            hard.AddRandomGroup("Satyr_EN", "Grandfather_EN", Enemies.Skinning);

            AddTo easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, "Grandfather_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Blue, Flower.Red, "Grandfather_EN");

            med = new AddTo(Garden.H.Camera.Med);
            med.AddRandomGroup("Grandfather_EN", "MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "InHerImage_EN", "InHerImage_EN", "Grandfather_EN");
            hard.AddRandomGroup("ClockTower_EN", "Satyr_EN", "LittleAngel_EN", "Grandfather_EN");
            hard.AddRandomGroup("ClockTower_EN", "Satyr_EN", "ChoirBoy_EN", "Grandfather_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Grandfather_EN");
            hard.AddRandomGroup(Enemies.Tank, "LittleAngel_EN", "Grandfather_EN");
            hard.AddRandomGroup(Enemies.Tank, "WindSong_EN", "Grandfather_EN");
        }
    }
}
