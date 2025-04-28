using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class SomethingEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_Something_Sign", ResourceLoader.LoadSprite("SomethingIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum

            //Medium
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_Something_Easy_EnemyBundle", "Salt_Something_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/SomethingTheme";
            mainEncounters.RoarEvent = "event:/Hawthorne/Oisenay/SomethingRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "SingingStone_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Spoggle_Spitfire_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Something_Easy_EnemyBundle", 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            //Hard
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_Something_Medium_EnemyBundle", "Salt_Something_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/SomethingTheme";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Oisenay/SomethingRoar";
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Scrungie_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Scrungie_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "JumbleGuts_Hollowing_EN",
                "JumbleGuts_Flummoxing_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Spoggle_Writhing_EN",
                "Spoggle_Resonant_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Something_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            if(SaltsReseasoned.rando == 1)
            {
                mainEncounters2.CreateNewEnemyEncounterData(new string[]
                {
                    "Something_EN",
                    "ManicMan_EN",
                    "ManicMan_EN",
                    "ManicMan_EN",
                }, null);
            }
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Something_Medium_EnemyBundle", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            //Orpheum
            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Something_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list1;
            }

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Something_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list2;
            }

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Resonant_EN",
                    "Something_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list3;
            }

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Resonant_EN",
                    "Spoggle_Writhing_EN",
                    "Something_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list4;
            }

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup(new string[]
            {
                "WrigglingSacrifice_EN",
                "Something_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list5;

            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
            list6.Add(new RandomEnemyGroup(new string[]
            {
                "Revola_EN",
                "Something_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list6;

            List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
            list7.Add(new RandomEnemyGroup(new string[]
            {
                "Conductor_EN",
                "Something_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list7;

            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
            list8.Add(new RandomEnemyGroup(new string[]
            {
                "Conductor_EN",
                "MusicMan_EN",
                "Something_EN",
            }));
            list8.Add(new RandomEnemyGroup(new string[]
            {
                "Conductor_EN",
                "Scrungie_EN",
                "Something_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list8;
        }
    }
}
