using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MortalSpoggleEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_MortalSpoggleEncounters_Sign", ResourceLoader.LoadSprite("GSpogIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_MortalSpoggle_Medium_EnemyBundle", "Salt_MortalSpoggleEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/GreySpoggleSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle")._roarReference.roarEvent;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MortalSpoggle_EN",
                "SkinningHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MortalSpoggle_EN",
                "GigglingMinister_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MortalSpoggle_EN",
                "InHisImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MortalSpoggle_EN",
                "InHisImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_MortalSpoggle_Medium_EnemyBundle", 4, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);

            //Secondary
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                    "InHisImage_EN",
                    "InHisImage_EN",
                    "MortalSpoggle_EN",
            }));
            if (SaltsReseasoned.silly < 50)
            {
                list1.Add(new RandomEnemyGroup(new string[]
                {
                        "InHisImage_EN",
                        "InHisImage_EN",
                        "InHerImage_EN",
                        "MortalSpoggle_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                    "InHerImage_EN",
                    "InHisImage_EN",
                    "MortalSpoggle_EN",
            }));
            if (SaltsReseasoned.silly > 50)
            {
                list2.Add(new RandomEnemyGroup(new string[]
                {
                        "InHerImage_EN",
                        "InHerImage_EN",
                        "InHisImage_EN",
                        "MortalSpoggle_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list2;

            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup(new string[]
            {
                    "SkinningHomunculus_EN",
                    "ShiveringHomunculus_EN",
                    "MortalSpoggle_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = list3;

            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list4.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                "MortalSpoggle_EN",
            }));
            if (SaltsReseasoned.silly > 50)
            {
                list2.Add(new RandomEnemyGroup(new string[]
                {
                        "SkinningHomunculus_EN",
                        "GigglingMinister_EN",
                        "MortalSpoggle_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list4;

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup(new string[]
            {
                "GigglingMinister_EN",
                "GigglingMinister_EN",
                "MortalSpoggle_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list5;
        }
    }

    public static class SaltMortalSpoggleEncounters
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "Satyr_EN",
                "ChoirBoy_EN",
                "MortalSpoggle_EN",
            }));
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "Satyr_EN",
                "SkinningHomunculus_EN",
                "MortalSpoggle_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list1;
        }
    }
}
