using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class DeadPixelEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_DeadPixelEncounters_Sign", ResourceLoader.LoadSprite("deadPixel_icon.png", null, 32, null), Portals.EnemyIDColor);

            //Far Shore
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone01_DeadPixel_Easy_EnemyBundle", "Salt_DeadPixelEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/DeadPixelTheme";
            mainEncounters.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "MudLung_EN"
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "JumbleGuts_Waning_EN"
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "JumbleGuts_Clotted_EN"
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "Wringle_EN"
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone01_DeadPixel_Easy_EnemyBundle", 7, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
            
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone01_DeadPixel_Medium_EnemyBundle", "Salt_DeadPixelEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/DeadPixelTheme";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "MudLung_EN",
                "MudLung_EN"
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "Spoggle_Spitfire_EN"
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "Spoggle_Ruminating_EN"
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "Keko_EN",
                "Keko_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone01_DeadPixel_Medium_EnemyBundle", 15, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
            
            //Orpheum
            EnemyEncounter_API mainEncounters3 = new EnemyEncounter_API(0, "H_Zone02_DeadPixel_Easy_EnemyBundle", "Salt_DeadPixelEncounters_Sign");
            mainEncounters3.MusicEvent = "event:/Hawthorne/DeadPixelTheme";
            mainEncounters3.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "Enigma_EN"
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "DeadPixel_EN",
                "DeadPixel_EN",
                "MusicMan_EN"
            }, null);
            mainEncounters3.AddEncounterToDataBases();
            //EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_DeadPixel_Easy_EnemyBundle", 3, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);
            
            //Secondary
            //Far Shore
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
            list.Add(new RandomEnemyGroup(new string[]
            {
                "MudLung_EN",
                "MudLung_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list;

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Waning_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = list2;
            }

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = list3;
            }

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Spitfire_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list4;
            }

            if (SaltsReseasoned.trolling > 50)
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles = list5;
            }

            if (SaltsReseasoned.rando == 1)
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Hollowing_Hard_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Hollowing_Hard_EnemyBundle"))._enemyBundles = list6;
            }

            if (SaltsReseasoned.rando == 2)
            {
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Flummoxing_Hard_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Flummoxing_Hard_EnemyBundle"))._enemyBundles = list7;
            }

            if (SaltsReseasoned.rando == 3)
            {
                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Writhing_Hard_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Writhing_Hard_EnemyBundle"))._enemyBundles = list8;
            }

            if (SaltsReseasoned.rando == 4)
            {
                List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Resonant_Hard_EnemyBundle"))._enemyBundles);
                list9.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Resonant_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Resonant_Hard_EnemyBundle"))._enemyBundles = list9;
            }

            List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles);
            list10.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles = list10;

            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "MudLung_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            if (SaltsReseasoned.silly < 33)
            {
                list11.Add(new RandomEnemyGroup(new string[]
                {
                    "FlaMinGoa_EN",
                    "Spoggle_Spitfire_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }));
            }
            if (SaltsReseasoned.silly > 66)
            {
                list11.Add(new RandomEnemyGroup(new string[]
                {
                    "FlaMinGoa_EN",
                    "Spoggle_Ruminating_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = list11;

            List<RandomEnemyGroup> list12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles);
            list12.Add(new RandomEnemyGroup(new string[]
            {
                "Keko_EN",
                "Keko_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles = list12;

            List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            list13.Add(new RandomEnemyGroup(new string[]
            {
                "Flarb_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list13;

            List<RandomEnemyGroup> list14 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            list14.Add(new RandomEnemyGroup(new string[]
            {
                "Voboola_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list14;

            List<RandomEnemyGroup> list15 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles);
            list15.Add(new RandomEnemyGroup(new string[]
            {
                "Kekastle_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles = list15;

            return;
            //Orpheum
            List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
            list16.Add(new RandomEnemyGroup(new string[]
            {
                "MusicMan_EN",
                "MusicMan_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list16;
            
            List<RandomEnemyGroup> list17 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
            list17.Add(new RandomEnemyGroup(new string[]
            {
                "Scrungie_EN",
                "Scrungie_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list17;
            
            List<RandomEnemyGroup> list18 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
            list18.Add(new RandomEnemyGroup(new string[]
            {
                "JumbleGuts_Hollowing_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list18;
            
            List<RandomEnemyGroup> list19 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
            list19.Add(new RandomEnemyGroup(new string[]
            {
                "JumbleGuts_Flummoxing_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list19;
            
            List<RandomEnemyGroup> list20 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
            list20.Add(new RandomEnemyGroup(new string[]
            {
                "Spoggle_Writhing_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list20;
            
            List<RandomEnemyGroup> list21 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
            list21.Add(new RandomEnemyGroup(new string[]
            {
                "Spoggle_Resonant_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list21;
            
            List<RandomEnemyGroup> list22 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
            list22.Add(new RandomEnemyGroup(new string[]
            {
                "Revola_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list22;
            
            List<RandomEnemyGroup> list23 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
            list23.Add(new RandomEnemyGroup(new string[]
            {
                "Conductor_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list23;
        }
    }

    public static class SaltDeadPixelEncounters
    {
        public static void Add()
        {
            return;
            //Secondary
            //Far Shore
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Enigma_Easy_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "Enigma_EN",
                "Enigma_EN",
                "DeadPixel_EN",
                "DeadPixel_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Enigma_Easy_EnemyBundle"))._enemyBundles = list1;
        }
    }
}
