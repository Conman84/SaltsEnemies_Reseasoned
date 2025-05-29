using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class FreudEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_FreudEncounters_Sign", ResourceLoader.LoadSprite("TouchIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_Freud_Easy_EnemyBundle", "Salt_FreudEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/DontTouchMeTheme";
            mainEncounters.RoarEvent = "event:/Hawthorne/Sound/FreudRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "JumbleGuts_Waning_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Spoggle_Spitfire_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            //EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Freud_Easy_EnemyBundle", 2, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);

            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_Freud_Medium_EnemyBundle", "Salt_FreudEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/DontTouchMeTheme";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Sound/FreudRoar";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "JumbleGuts_Hollowing_EN",
                "JumbleGuts_Flummoxing_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Spoggle_Writhing_EN",
                "Spoggle_Resonant_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "JumbleGuts_Hollowing_EN",
                "JumbleGuts_Flummoxing_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Spoggle_Writhing_EN",
                "Spoggle_Resonant_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Enigma_EN",
                "Enigma_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Enigma_EN",
                "Enigma_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "Scrungie_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Freud_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Freud_Medium_EnemyBundle", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            if (SaltsReseasoned.silly < 25)
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list1;
            }

            if (SaltsReseasoned.silly > 25 && SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list2;
            }

            if (SaltsReseasoned.silly > 50 && SaltsReseasoned.silly < 75)
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Resonant_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list3;
            }

            if (SaltsReseasoned.silly > 75)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Resonant_EN",
                    "Spoggle_Writhing_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list4;
            }

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list5;
            }

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list6;
            }

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "Revola_EN",
                    "Freud_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list7;
            }

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Freud_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list8;
            }
        }
    }
    public static class SaltFreudEncounters
    {
        public static void Add()
        {
            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Freud_EN",
                    "SilverSuckle_EN",
                    "SilverSuckle_EN",
                    "SilverSuckle_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles = list1;
            }

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "Something_EN",
                    "Freud_EN",
                    "Enigma_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Medium_EnemyBundle"))._enemyBundles = list2;
            }
        }
    }
}
