using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CrowEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_CrowEncounters_Sign", ResourceLoader.LoadSprite("CrowIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_Crow_Easy_EnemyBundle", "Salt_CrowEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/CrowSong";
            mainEncounters.RoarEvent = "event:/Hawthorne/Nois2/CrowRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "SingingStone_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "SingingStone_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            //EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Crow_Easy_EnemyBundle", 3, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_Crow_Medium_EnemyBundle", "Salt_CrowEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/CrowSong";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Nois2/CrowRoar";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Scrungie_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Scrungie_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Scrungie_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Scrungie_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "JumbleGuts_Hollowing_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "JumbleGuts_Flummoxing_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "Spoggle_Writhing_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "Spoggle_Resonant_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "MusicMan_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "Enigma_EN",
                "Enigma_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "TheCrow_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "TheCrow_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "TheCrow_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "TheCrow_EN",
                "TheCrow_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Crow_Medium_EnemyBundle", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "TheCrow_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list1;
            }

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "WrigglingSacrifice_EN",
                "TheCrow_EN",
                "MusicMan_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list2;

            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup(new string[]
            {
                "Revola_EN",
                "TheCrow_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list3;

            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
            list4.Add(new RandomEnemyGroup(new string[]
            {
                "Conductor_EN",
                "TheCrow_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list4;

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Something_EN",
                    "TheCrow_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list5;
            }
        }
    }
    public static class SaltCrowEncounters
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Medium_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                    "Something_EN",
                    "TheCrow_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Medium_EnemyBundle"))._enemyBundles = list1;
        }
    }
}
