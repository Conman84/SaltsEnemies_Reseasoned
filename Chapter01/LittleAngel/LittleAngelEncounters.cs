using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class LittleAngelEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_LittleAngelEncounters_Sign", ResourceLoader.LoadSprite("littleAngel_Icon.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_LittleAngel_Easy_EnemyBundle", "Salt_LittleAngelEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/PaleSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").dxSound;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LittleAngel_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "LittleAngel_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_LittleAngel_Easy_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);

            //Secondary
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Easy_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "InHerImage_EN",
                "InHisImage_EN",
                "LittleAngel_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Easy_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Easy_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "InHisImage_EN",
                "InHerImage_EN",
                "LittleAngel_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Easy_EnemyBundle"))._enemyBundles = list2;

            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "InHisImage_EN",
                    "LittleAngel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list3;
            }
            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "InHisImage_EN",
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list4;
            }

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup(new string[]
            {
                "ChoirBoy_EN",
                "LittleAngel_EN",
            }));
            list5.Add(new RandomEnemyGroup(new string[]
            {
                "ChoirBoy_EN",
                "ChoirBoy_EN",
                "LittleAngel_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles = list5;

            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list6.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                "LittleAngel_EN",
            }));
            if (SaltsReseasoned.silly < 50)
            {
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "ChoirBoy_EN",
                    "LittleAngel_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list6;

            List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle"))._enemyBundles);
            list7.Add(new RandomEnemyGroup(new string[]
            {
                "GigglingMinister_EN",
                "LittleAngel_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle"))._enemyBundles = list7;

            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.silly > 50)
            {
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "GigglingMinister_EN",
                    "ChoirBoy_EN",
                    "LittleAngel_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle"))._enemyBundles = list8;
        }
    }
}
