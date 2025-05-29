using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class YellowFlowerEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_YellowFlowerEncounters_Sign", ResourceLoader.LoadSprite("YellowFlowerWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_YellowFlower_Easy_EnemyBundle", "Salt_YellowFlowerEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/FlowerSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                "LostSheep_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_YellowFlower_Easy_EnemyBundle", 2, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            //Medium
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_YellowFlower_Medium_EnemyBundle", "Salt_YellowFlowerEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/FlowerSong";
            mainEncounters2.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle")._roarReference.roarEvent;

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                Flower.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                Flower.Purple,
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                Flower.Purple,
                "MechanicalLens_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                Flower.Purple,
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                Flower.Yellow,
                "Delusion_EN",
                "Delusion_EN",
                "LostSheep_EN",
            }, null);

            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_YellowFlower_Medium_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            AddTo bundle1 = new AddTo("H_Zone02_MusicMan_Medium_EnemyBundle");
            bundle1.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "MusicMan_EN", Flower.Yellow);

            AddTo bundle2 = new AddTo("H_Zone02_Scrungie_Medium_EnemyBundle");
            bundle2.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Flower.Yellow);
            bundle2.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Scrungie_EN", Flower.Yellow);

            AddTo bundle3 = new AddTo("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle");
            bundle3.AddRandomGroup("WrigglingSacrifice_EN", Flower.Yellow, Flower.Purple);

            AddTo bundle4 = new AddTo("H_Zone02_Revola_Hard_EnemyBundle");
            bundle4.AddRandomGroup("Revola_EN", Flower.Yellow);

            AddTo bundle5 = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            bundle5.AddRandomGroup("Conductor_EN", "MusicMan_EN", Flower.Yellow);

            AddTo bundle6 = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            bundle6.AddRandomGroup("Conductor_EN", Flower.Yellow, Flower.Purple);

            AddTo bundle7 = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            bundle7.AddRandomGroup("Something_EN", Flower.Yellow, "Scrungie_EN");

            AddTo bundle8 = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            bundle8.AddRandomGroup("TheCrow_EN", Flower.Yellow, "Enigma_EN");

            AddTo bundle9 = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            bundle9.AddRandomGroup("Freud_EN", Flower.Yellow, "Enigma_EN");

            AddTo bundle10 = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            bundle10.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "MusicMan_EN", Flower.Yellow);
            bundle10.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "FakeAngel_EN", Flower.Yellow);

            AddTo bundle11 = new AddTo("H_Zone02_Delusion_Medium_EnemyBundle");
            bundle11.AddRandomGroup("Delusion_EN", "Delusion_EN", Flower.Yellow, "FakeAngel_EN");
            bundle11.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", Flower.Yellow, "FakeAngel_EN");
            bundle11.AddRandomGroup("Delusion_EN", "Delusion_EN", Flower.Yellow, "Enigma_EN");
        }
    }
}
