using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SemiRealisticTankEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_SemiRealisticTankEncounters_Sign", ResourceLoader.LoadSprite("TankWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_SemiRealisticTank_Hard_EnemyBundle", "Salt_SemiRealisticTankEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/TankTheme";
            mainEncounters.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "InHisImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "InHerImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "InHisImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "SkinningHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "GigglingMinister_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                Flower.Red,
                Flower.Blue,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                Flower.Red,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                Flower.Blue,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "MechanicalLens_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "ClockTower_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "LittleAngel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "LittleAngel_EN",
                Flower.Blue,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "Satyr_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RealisticTank_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_SemiRealisticTank_Hard_EnemyBundle", 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
