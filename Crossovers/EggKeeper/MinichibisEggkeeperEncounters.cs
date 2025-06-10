using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class MinichibisEggkeeperEncounters
    {
        public static void Add()
        {
            try
            {
                if (Check.EnemyExist("EggKeeper_EN"))
                {
                    //Minichibis
                    if (Check.BundleExist("ChoirBoy_Medium_Eggkeeper"))
                    {
                        List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ChoirBoy_Medium_Eggkeeper"))._enemyBundles);
                        list1.Add(new RandomEnemyGroup(new string[]
                        {
                            "ChoirBoy_EN",
                            "EggKeeper_EN",
                            "LittleAngel_EN",
                        }));
                        ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ChoirBoy_Medium_Eggkeeper"))._enemyBundles = list1;
                    }

                    //Salt
                    List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles);
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Satyr_EN",
                        "EggKeeper_EN",
                        "ChoirBoy_EN",
                    }));
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Satyr_EN",
                        "EggKeeper_EN",
                        "GigglingMinister_EN",
                    }));
                    if (Check.EnemyExist("Git_EN"))
                    {
                        list2.Add(new RandomEnemyGroup(new string[]
                        {
                            "Satyr_EN",
                            "EggKeeper_EN",
                            "Git_EN",
                        }));
                    }
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles = list2;

                    List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "Satyr_EN",
                        "EggKeeper_EN",
                        "SkinningHomunculus_EN",
                    }));
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "Satyr_EN",
                        "EggKeeper_EN",
                        "MechanicalLens_EN",
                        "MechanicalLens_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list3;

                    if (Check.BundleExist("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))
                    {
                        List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))._enemyBundles);
                        list4.Add(new RandomEnemyGroup(new string[]
                        {
                            "MortalSpoggle_EN",
                            "InHisImage_EN",
                            "InHisImage_EN",
                            "EggKeeper_EN",
                        }));
                        ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_MortalSpoggle_Medium_EnemyBundle"))._enemyBundles = list4;
                    }

                    if (Check.BundleExist("H_Zone03_RusticJumbleGuts_Medium_EnemyBundle") && Check.EnemyExist("RusticJumbleguts_EN"))
                    {
                        List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_RusticJumbleGuts_Medium_EnemyBundle"))._enemyBundles);
                        list5.Add(new RandomEnemyGroup(new string[]
                        {
                            "RusticJumbleguts_EN",
                            "SkinningHomunculus_EN",
                            "EggKeeper_EN",
                        }));
                        ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_RusticJumbleGuts_Medium_EnemyBundle"))._enemyBundles = list5;
                    }

                    //Misc
                    if (Check.BundleExist("Marmo_Attrition_Medium_Bundle"))
                    {
                        List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Attrition_Medium_Bundle"))._enemyBundles);
                        //I also call RusticJumbleGuts_EN here but im not too sure this is actually its ID
                        if (Check.EnemyExist("RusticJumbleGuts_EN"))
                        {
                            list6.Add(new RandomEnemyGroup(new string[]
                            {
                                "Attrition_EN",
                                "Attrition_EN",
                                "RusticJumbleguts_EN",
                                "EggKeeper_EN",
                            }));
                        }
                        ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Attrition_Medium_Bundle"))._enemyBundles = list6;
                    }

                    //BASEGAME
                    List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle"))._enemyBundles);
                    list7.Add(new RandomEnemyGroup(new string[]
                    {
                        "GigglingMinister_EN",
                        "EggKeeper_EN",
                        "MechanicalLens_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle"))._enemyBundles = list7;

                    List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);
                    list8.Add(new RandomEnemyGroup(new string[]
                    {
                        "SkinningHomunculus_EN",
                        "EggKeeper_EN",
                        "Satyr_EN",
                    }));
                    if (Check.EnemyExist("Romantic_EN"))
                    {
                        list8.Add(new RandomEnemyGroup(new string[]
                        {
                            "SkinningHomunculus_EN",
                            "EggKeeper_EN",
                            "Satyr_EN",
                            "Romantic_EN",
                        }));
                    }
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = list8;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Minichibis EggKeeper SaltEnemies Crossover Failure");
                Debug.LogError(ex.ToString());
            }
        }
    }
}
