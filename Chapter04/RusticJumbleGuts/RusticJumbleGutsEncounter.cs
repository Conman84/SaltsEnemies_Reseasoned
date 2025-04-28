using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class RusticJumbleGutsEncounter
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_RusticJumbleGutsEncounters_Sign", ResourceLoader.LoadSprite("GJumbIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_RusticJumbleGuts_Medium_EnemyBundle", "Salt_RusticJumbleGutsEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/GreyJumbleSong";
            mainEncounters.RoarEvent = "event:/Hawthorne/Nois2/RusticRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RusticJumbleguts_EN",
                "SkinningHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RusticJumbleguts_EN",
                "InHerImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "RusticJumbleguts_EN",
                "InHisImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_RusticJumbleGuts_Medium_EnemyBundle", 4, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);

            //Secondary
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "RusticJumbleguts_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "RusticJumbleguts_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list2;

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "RusticJumbleguts_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = list3;
            }

            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list4.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                "RusticJumbleguts_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list4;

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup(new string[]
            {
                "GigglingMinister_EN",
                "SkinningHomunculus_EN",
                "RusticJumbleguts_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list5;
        }
    }

    public static class SaltRusticJumbleGutsEncounters
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "Satyr_EN",
                "InHisImage_EN",
                "InHerImage_EN",
                "RusticJumbleguts_EN",
            }));
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "Satyr_EN",
                "SkinningHomunculus_EN",
                "RusticJumbleguts_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list1;
        }
    }
}
