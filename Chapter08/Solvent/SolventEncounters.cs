using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SolventEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_SolventEncounters_Sign", ResourceLoader.LoadSprite("SolventPortal.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            //Easy
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_Solvent_Easy_EnemyBundle", "Salt_SolventEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/SolventTheme";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").damageSound;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "MusicMan_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "Delusion_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                Spoggle.Blue,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                Jumble.Yellow,
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LivingSolvent_EN",
                Spoggle.Yellow,
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Solvent_Easy_EnemyBundle", 4, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            //Secondary
            AddTo bundle1 = new AddTo("H_Zone02_MusicMan_Easy_EnemyBundle");
            bundle1.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "LivingSolvent_EN");
            bundle1.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "LivingSolvent_EN", "SilverSuckle_EN", "SilverSuckle_EN");

            AddTo bundle2 = new AddTo("H_Zone02_MusicMan_Medium_EnemyBundle");
            bundle2.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "MusicMan_EN", "LivingSolvent_EN");

            AddTo bundle3 = new AddTo("H_Zone02_Scrungie_Medium_EnemyBundle");
            bundle3.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "LivingSolvent_EN", "Enigma_EN");

            AddTo bundle4 = new AddTo("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle");
            bundle4.AddRandomGroup(Jumble.Blue, Jumble.Purple, "LivingSolvent_EN");

            AddTo bundle5 = new AddTo("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle");
            bundle5.AddRandomGroup(Jumble.Purple, Jumble.Blue, "LivingSolvent_EN");

            AddTo bundle6 = new AddTo("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle");
            bundle6.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "LivingSolvent_EN");

            AddTo bundle7 = new AddTo("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle");
            bundle7.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "LivingSolvent_EN");

            AddTo bundle8 = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            bundle8.AddRandomGroup("Conductor_EN", "LivingSolvent_EN");

            AddTo bundle9 = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            bundle9.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", "LivingSolvent_EN");

            AddTo bundle10 = new AddTo("H_Zone02_Something_Easy_EnemyBundle");
            bundle10.AddRandomGroup("Something_EN", "LivingSolvent_EN");

            AddTo bundle11 = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            bundle11.AddRandomGroup("Something_EN", "MusicMan_EN", "LivingSolvent_EN");

            AddTo bundle12 = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            bundle12.AddRandomGroup("TheCrow_EN", "LivingSolvent_EN", "LivingSolvent_EN");
            bundle12.AddRandomGroup("TheCrow_EN", "Delusion_EN", "LivingSolvent_EN");

            AddTo bundle13 = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            bundle13.AddRandomGroup("Freud_EN", "Delusion_EN", "Delusion_EN", "LivingSolvent_EN");
            bundle13.AddRandomGroup("Freud_EN", Jumble.Blue, "LivingSolvent_EN");
            bundle13.AddRandomGroup("Freud_EN", Flower.Yellow, "LivingSolvent_EN");
            bundle13.AddRandomGroup("Freud_EN", "MusicMan_EN", "MusicMan_EN", "LivingSolvent_EN");
            bundle13.AddRandomGroup("Freud_EN", "Something_EN", "LivingSolvent_EN");

            AddTo bundle14 = new AddTo("H_Zone02_Delusion_Easy_EnemyBundle");
            bundle14.AddRandomGroup("Delusion_EN", "LivingSolvent_EN");
            bundle14.AddRandomGroup("Delusion_EN", "Delusion_EN", "LivingSolvent_EN");

            AddTo bundle15 = new AddTo("H_Zone02_Delusion_Medium_EnemyBundle");
            bundle15.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", "LivingSolvent_EN");
            bundle15.AddRandomGroup("Delusion_EN", "Delusion_EN", "LivingSolvent_EN", "Enigma_EN");

            AddTo bundle16 = new AddTo("H_Zone02_YellowFlower_Medium_EnemyBundle");
            bundle16.AddRandomGroup(Flower.Yellow, Flower.Purple, "LivingSolvent_EN");

            AddTo bundle17 = new AddTo("H_Zone02_PurpleFlower_Medium_EnemyBundle");
            bundle17.AddRandomGroup(Flower.Purple, Flower.Yellow, "LivingSolvent_EN");

            AddTo bundle18 = new AddTo("H_Zone02_Sigil_Medium_EnemyBundle");
            bundle18.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", "LivingSolvent_EN");
            bundle18.AddRandomGroup("Sigil_EN", "Delusion_EN", "Delusion_EN", "LivingSolvent_EN");

            AddTo bundle19 = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            bundle19.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN", "LivingSolvent_EN");
        }
    }
}
