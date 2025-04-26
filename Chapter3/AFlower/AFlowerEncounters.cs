using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SaltsEnemies_Reseasoned
{
    public static class AFlowerEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_AFlower_Sign", ResourceLoader.LoadSprite("AnglerIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Far Shore
            //Medium
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone01_AFlower_Medium_EnemyBundle", "Salt_AFlower_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/AnglerTheme";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MudLung_EN",
                "MudLung_EN"
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MunglingMudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "FlaMinGoa_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "JumbleGuts_Waning_EN",
                "JumbleGuts_Clotted_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "Spoggle_Spitfire_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "Spoggle_Ruminating_EN",
                "MudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "Spoggle_Spitfire_EN",
                "MudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "Keko_EN",
                "Keko_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MudLung_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone01_AFlower_Medium_EnemyBundle", 20, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);

            //Hard
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone01_AFlower_Hard_EnemyBundle", "Salt_AFlower_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/AnglerTheme";
            mainEncounters2.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle")._roarReference.roarEvent;

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "FlaMinGoa_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MunglingMudLung_EN",
                "MudLung_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MunglingMudLung_EN",
                "Wringle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MunglingMudLung_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "FlaMinGoa_EN",
                "MunglingMudLung_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "Keko_EN",
                "Keko_EN",
                "Keko_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MunglingMudLung_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "FlaMinGoa_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MudLung_EN",
                "MudLung_EN",
                "MudLung_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "AFlower_EN",
                "MudLung_EN",
                "MudLung_EN",
                "Wringle_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone01_AFlower_Hard_EnemyBundle", 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);

            //Secondary
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "AFlower_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "AFlower_EN",
                "MudLung_EN",
            }));
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "AFlower_EN",
                "MunglingMudLung_EN",
            }));
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "AFlower_EN",
                "Wringle_EN",
            }));
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "AFlower_EN",
                "JumbleGuts_Waning_EN",
            }));
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "AFlower_EN",
                "Spoggle_Ruminating_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = list2;

            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup(new string[]
            {
                "MunglingMudLung_EN",
                "AFlower_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles = list3;

            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            list4.Add(new RandomEnemyGroup(new string[]
            {
                "Flarb_EN",
                "AFlower_EN"
            }));
            list4.Add(new RandomEnemyGroup(new string[]
            {
                "Flarb_EN",
                "AFlower_EN",
                "Flarblet_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list4;

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup(new string[]
            {
                "Voboola_EN",
                "AFlower_EN"
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list5;
        }
    }
}
