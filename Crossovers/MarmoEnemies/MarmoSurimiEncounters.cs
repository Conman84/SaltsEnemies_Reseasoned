using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoSurimiEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Surimi_EN"))
            {
                //Marmo
                if (Check.BundleExist("Marmo_Surimi_Easy_Bundle"))
                {
                    List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Surimi_Easy_Bundle"))._enemyBundles);
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Surimi_EN",
                        "Surimi_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Surimi_Easy_Bundle"))._enemyBundles = list1;
                }
                if (Check.BundleExist("Marmo_Surimi_Medium_Bundle"))
                {
                    List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Surimi_Medium_Bundle"))._enemyBundles);
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Surimi_EN",
                        "Surimi_EN",
                        "DeadPixel_EN",
                        "DeadPixel_EN",
                    }));
                    if (SaltsReseasoned.trolling < 50)
                    {
                        list2.Add(new RandomEnemyGroup(new string[]
                        {
                            "Surimi_EN",
                            "Surimi_EN",
                            "Spoggle_Spitfire_EN",
                            "LostSheep_EN",
                        }));
                    }
                    if (SaltsReseasoned.trolling > 50)
                    {
                        list2.Add(new RandomEnemyGroup(new string[]
                        {
                            "Surimi_EN",
                            "Surimi_EN",
                            "Spoggle_Ruminating_EN",
                            "LostSheep_EN",
                        }));
                    }
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Surimi_EN",
                        "Surimi_EN",
                        "Surimi_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Surimi_Medium_Bundle"))._enemyBundles = list2;
                }

                //Salt
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_DeadPixel_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "Surimi_EN",
                    "MudLung_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_DeadPixel_Medium_EnemyBundle"))._enemyBundles = list3;

                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Medium_EnemyBundle"))._enemyBundles);
                if (SaltsReseasoned.trolling > 50)
                {
                    list4.Add(new RandomEnemyGroup(new string[]
                    {
                        "AFlower_EN",
                        "Surimi_EN",
                        "JumbleGuts_Waning_EN",
                    }));
                }
                if (SaltsReseasoned.trolling < 50)
                {
                    list4.Add(new RandomEnemyGroup(new string[]
                    {
                        "AFlower_EN",
                        "Surimi_EN",
                        "JumbleGuts_Clotted_EN",
                    }));
                }
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "AFlower_EN",
                    "Surimi_EN",
                    "Wringle_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Medium_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "AFlower_EN",
                    "Surimi_EN",
                    "Surimi_EN",
                    "Snaurce_EN",
                }));
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "AFlower_EN",
                    "Surimi_EN",
                    "MunglingMudLung_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Hard_EnemyBundle"))._enemyBundles = list5;

                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MechanicalLens_Hard_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "MechanicalLens_EN",
                    "Surimi_EN",
                    "Snaurce_EN",
                }));
                if (SaltsReseasoned.rando == 86)
                {
                    list6.Add(new RandomEnemyGroup(new string[]
                    {
                        "MechanicalLens_EN",
                        "Surimi_EN",
                        "Wringle_EN",
                    }));
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MechanicalLens_Hard_EnemyBundle"))._enemyBundles = list6;

                //Base Game
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Spitfire_EN",
                    "Surimi_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list7;

                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "Surimi_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles = list8;

                if (SaltsReseasoned.silly > 50)
                {
                    List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
                    list9.Add(new RandomEnemyGroup(new string[]
                    {
                        "JumbleGuts_Waning_EN",
                        "Surimi_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = list9;
                }

                if (SaltsReseasoned.silly < 50)
                {
                    List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
                    list10.Add(new RandomEnemyGroup(new string[]
                    {
                        "JumbleGuts_Clotted_EN",
                        "Surimi_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = list10;
                }

                List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
                list11.Add(new RandomEnemyGroup(new string[]
                {
                    "Voboola_EN",
                    "Surimi_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list11;
            }
        }
    }
}
