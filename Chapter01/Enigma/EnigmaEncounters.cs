using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EnigmaEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_EnigmaEncounters_Sign", ResourceLoader.LoadSprite("enigma_icon.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "Zone02_Enigma_Easy_EnemyBundle", "Salt_EnigmaEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/EnigmaTheme";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Spoggle_Spitfire_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("Zone02_Enigma_Easy_EnemyBundle", 3, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Easy);

            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_Enigma_Easy_EnemyBundle", "Salt_EnigmaEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/EnigmaTheme";
            mainEncounters2.RoarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Spoggle_Spitfire_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Enigma_Easy_EnemyBundle", 2, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            EnemyEncounter_API mainEncounters3 = new EnemyEncounter_API(0, "H_Zone02_Enigma_Medium_EnemyBundle", "Salt_EnigmaEncounters_Sign");
            mainEncounters3.MusicEvent = "event:/Hawthorne/EnigmaTheme";
            mainEncounters3.RoarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;

            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "JumbleGuts_Hollowing_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "JumbleGuts_Flummoxing_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "Spoggle_Writhing_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "Spoggle_Resonant_EN",
            }, null);
            mainEncounters3.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Enigma_Medium_EnemyBundle", 12, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.silly < 33)
            {
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                }));
            }
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "MusicMan_EN",
                "MusicMan_EN",
                "Enigma_EN",
                "Enigma_EN",
            }));
            if (SaltsReseasoned.silly > 66)
            {
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> oopslist1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.silly < 33)
            {
                oopslist1.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                }));
            }
            oopslist1.Add(new RandomEnemyGroup(new string[]
            {
                "MusicMan_EN",
                "MusicMan_EN",
                "Enigma_EN",
                "Enigma_EN",
            }));
            if (SaltsReseasoned.silly > 66)
            {
                oopslist1.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = oopslist1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "Scrungie_EN",
                "Scrungie_EN",
                "Enigma_EN",
            }));
            if (SaltsReseasoned.rando == 22)
            {
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list2;

            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Scrungie_Hard_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup(new string[]
            {
                "Scrungie_EN",
                "Scrungie_EN",
                "Enigma_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Scrungie_Hard_EnemyBundle"))._enemyBundles = list3;

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list5;
            }

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list6;

                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list7;
            }

            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
            list8.Add(new RandomEnemyGroup(new string[]
            {
                "Spoggle_Writhing_EN",
                "Spoggle_Resonant_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list8;

            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup(new string[]
            {
                "Spoggle_Resonant_EN",
                "Spoggle_Writhing_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list9;

            List<RandomEnemyGroup> oopslist8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
            oopslist8.Add(new RandomEnemyGroup(new string[]
            {
                "Spoggle_Writhing_EN",
                "Spoggle_Resonant_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = oopslist8;

            List<RandomEnemyGroup> oopslist9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup(new string[]
            {
                "Spoggle_Resonant_EN",
                "Spoggle_Writhing_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list9;

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
                list10.Add(new RandomEnemyGroup(new string[]
                {
                    "WrigglingSacrifice_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list10;

            }

            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup(new string[]
            {
                "Conductor_EN",
                "Enigma_EN",
                "Enigma_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list11;

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list12.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list12;

            }
        }
    }
}
