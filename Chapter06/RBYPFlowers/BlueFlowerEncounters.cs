using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueFlowerEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_BlueFlowerEncounters_Sign", ResourceLoader.LoadSprite("BlueFlowerWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_BlueFlower_Easy_EnemyBundle", "Salt_BlueFlowerEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/FlowerSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "NextOfKin_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "LittleAngel_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_BlueFlower_Easy_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);

            //Medium
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone03_BlueFlower_Medium_EnemyBundle", "Salt_BlueFlowerEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/FlowerSong";
            mainEncounters2.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle")._roarReference.roarEvent;

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "InHisImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "InHerImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "InHisImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "InHerImage_EN",
                "InHerImage_EN",
                "NextOfKin_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                "ChoirBoy_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                Flower.Yellow,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Blue,
                Flower.Red,
                Flower.Purple,
            }, null);

            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_BlueFlower_Medium_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);

            //Secondary
            AddTo bundle1 = new AddTo("H_Zone03_InHisImage_Medium_EnemyBundle");
            bundle1.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "NextOfKin_EN", Flower.Blue);

            AddTo bundle2 = new AddTo("H_Zone03_InHerImage_Medium_EnemyBundle");
            bundle2.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "NextOfKin_EN", Flower.Blue);

            AddTo bundle3 = new AddTo("H_Zone03_SkinningHomunculus_Medium_EnemyBundle");
            bundle3.AddRandomGroup("SkinningHomunculus_EN", "ShiveringHomunculus_EN", Flower.Blue);
            bundle3.AddRandomGroup("SkinningHomunculus_EN", Flower.Blue);

            AddTo bundle4 = new AddTo("H_Zone03_SkinningHomunculus_Hard_EnemyBundle");
            bundle4.AddRandomGroup("SkinningHomunculus_EN", "SkinningHomunculus_EN", Flower.Blue);
            bundle4.AddRandomGroup("SkinningHomunculus_EN", "ChoirBoy_EN", Flower.Blue);

            AddTo bundle5 = new AddTo("H_Zone03_GigglingMinister_Easy_EnemyBundle");
            bundle5.AddRandomGroup("GigglingMinister_EN", Flower.Blue);

            AddTo bundle6 = new AddTo("H_Zone03_GigglingMinister_Hard_EnemyBundle");
            bundle6.AddRandomGroup("GigglingMinister_EN", "GigglingMinister_EN", Flower.Blue);
            bundle6.AddRandomGroup("GigglingMinister_EN", "SkinningHomunculus_EN", Flower.Blue);

            AddTo bundle7 = new AddTo("H_Zone03_Satyr_Medium_EnemyBundle");
            bundle7.AddRandomGroup("Satyr_EN", Flower.Red ,Flower.Blue);

            AddTo bundle8 = new AddTo("H_Zone03_Satyr_Hard_EnemyBundle");
            bundle8.AddRandomGroup("Satyr_EN", "InHisImage_EN", "InHerImage_EN", Flower.Blue);
            bundle8.AddRandomGroup("Satyr_EN", "SkinningHomunculus_EN", Flower.Blue);

            AddTo bundle9 = new AddTo("H_Zone03_MechanicalLens_Medium_EnemyBundle");
            bundle9.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN", Flower.Blue);
        }
    }
}
