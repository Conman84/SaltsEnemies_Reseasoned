using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoGitEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Git_EN"))
            {
                //Marmo
                if (Check.BundleExist("Marmo_Git_Easy_Bundle"))
                {
                    List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Git_Easy_Bundle"))._enemyBundles);
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Git_EN",
                        "LittleAngel_EN",
                        "Romantic_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Git_Easy_Bundle"))._enemyBundles = list1;
                }

                if (Check.BundleExist("Marmo_Git_Easy_Bundle"))
                {
                    List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Git_Medium_Bundle"))._enemyBundles);
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Git_EN",
                        "Git_EN",
                        "LittleAngel_EN",
                        "Romantic_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Git_Medium_Bundle"))._enemyBundles = list2;
                }

                //Salt
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "MortalSpoggle_EN",
                    "Git_EN",
                    "Git_EN",
                    "Git_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))._enemyBundles = list3;

                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "ChoirBoy_EN",
                    "Git_EN",
                }));
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Git_EN",
                    "Git_EN",
                }));
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "Git_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "Git_EN",
                }));
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "GigglingMinister_EN",
                    "Git_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list5;

                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MechanicalLens_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "Git_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MechanicalLens_Medium_EnemyBundle"))._enemyBundles = list6;

                //Base Game
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "ChoirBoy_EN",
                    "LittleAngel_EN",
                    "Git_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles = list7;

                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "Git_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list8;
            }
        }
    }
}
