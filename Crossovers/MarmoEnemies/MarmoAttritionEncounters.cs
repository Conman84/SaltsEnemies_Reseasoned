using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoAttritionEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Attrition_EN"))
            {
                //Marmo
                if (Check.BundleExist("Marmo_Attrition_Easy_Bundle"))
                {
                    List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Attrition_Easy_Bundle"))._enemyBundles);
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Attrition_EN",
                        "Attrition_EN",
                        "RusticJumbleguts_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Attrition_Easy_Bundle"))._enemyBundles = list1;
                }

                if (Check.BundleExist("Marmo_Attrition_Easy_Bundle"))
                {
                    List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Attrition_Medium_Bundle"))._enemyBundles);
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Attrition_EN",
                        "Attrition_EN",
                        "Attrition_EN",
                        "RusticJumbleguts_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Attrition_Medium_Bundle"))._enemyBundles = list2;
                }

                //Salt
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                }));
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles = list3;

                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                }));
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                    "RusticJumbleguts_EN",
                }));
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                    "Surrogate_EN",
                }));
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                    "Git_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "MortalSpoggle_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                }));
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "MortalSpoggle_EN",
                    "Attrition_EN",
                    "Attrition_EN",
                    "Git_EN",
                }));
                if (SaltsReseasoned.silly > 60)
                {
                    list5.Add(new RandomEnemyGroup(new string[]
                    {
                        "MortalSpoggle_EN",
                        "Attrition_EN",
                        "Attrition_EN",
                        "Attrition_EN",
                    }));
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))._enemyBundles = list5;
            }
        }
    }
}
