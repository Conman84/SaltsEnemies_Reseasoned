using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DelusionEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_DelusionEncounters_Sign", ResourceLoader.LoadSprite("IllusionWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_Delusion_Easy_EnemyBundle", "Salt_DelusionEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/GreyScaleTheme";
            mainEncounters.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "LostSheep_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Delusion_Easy_EnemyBundle", 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            //Medium
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_Delusion_Medium_EnemyBundle", "Salt_DelusionEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/GreyScaleTheme";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
                Spoggle.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
                Jumble.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);

            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Delusion_Medium_EnemyBundle", 20, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            AddTo bundle1 = new AddTo("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle");
            bundle1.AddRandomGroup(Jumble.Purple, "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            bundle1.AddRandomGroup(Jumble.Purple, "Delusion_EN", "Enigma_EN");

            AddTo bundle2 = new AddTo("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle");
            bundle2.AddRandomGroup(Spoggle.Purple, "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            bundle2.AddRandomGroup(Spoggle.Purple, "Delusion_EN", "Enigma_EN");

            AddTo bundle3 = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            bundle3.AddRandomGroup("Enigma_EN", "Enigma_EN", "Delusion_EN", "Delusion_EN");
            bundle3.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", "Delusion_EN");

            AddTo bundle4 = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            bundle4.AddRandomGroup("TheCrow_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN");

            AddTo bundle5 = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            bundle5.AddRandomGroup("Freud_EN", "Delusion_EN", "Delusion_EN", "Delusion_EN");
        }
    }
}
