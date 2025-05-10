using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TheEndOfTimeEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_TheEndOfTimeEncounter_Sign", ResourceLoader.LoadSprite("ClockTowerPortal.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_TheEndOfTime_Hard_EnemyBundle", "Salt_TheEndOfTimeEncounter_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/ClockTheme";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                "InHisImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "GigglingMinister_EN",
                "GigglingMinister_EN",
                "GigglingMinister_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "SkinningHomunculus_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "SkinningHomunculus_EN",
                "GigglingMinister_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                Spoggle.Grey,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                Jumble.Grey,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                Flower.Red,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                Flower.Blue,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                Spoggle.Grey,
                "NextOfKin_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                Flower.Red,
                "NextOfKin_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                Flower.Blue,
                "NextOfKin_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "Satyr_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "Satyr_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "Satyr_EN",
                "InHerImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                Flower.Red,
                Flower.Blue,
                Flower.Yellow,
                Flower.Purple,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "LittleAngel_EN",
                "InHerImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "LittleAngel_EN",
                "InHerImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "LittleAngel_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "ClockTower_EN",
                "LittleAngel_EN",
                "SkinningHomunculus_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_TheEndOfTime_Hard_EnemyBundle", 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);

            //Secondary
            AddTo bundle1 = new AddTo("H_Zone03_SkinningHomunculus_Hard_EnemyBundle");
            bundle1.AddRandomGroup("SkinningHomunculus_EN", "SkinningHomunculus_EN", "ClockTower_EN");

            AddTo bundle2 = new AddTo("H_Zone03_GigglingMinister_Hard_EnemyBundle");
            bundle2.AddRandomGroup("GigglingMinister_EN", "GigglingMinister_EN", "ClockTower_EN");

            AddTo bundle3 = new AddTo("H_Zone03_Satyr_Hard_EnemyBundle");
            bundle3.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "ClockTower_EN");
        }
    }
}
