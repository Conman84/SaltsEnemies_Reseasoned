using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoSnaurceEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Snaurce_EN"))
            {
                //Marmo
                if (Check.BundleExist("Marmo_Snaurce_Medium_Bundle"))
                {
                    List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Snaurce_Medium_Bundle"))._enemyBundles);
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Snaurce_EN",
                        "Snaurce_EN",
                        "DeadPixel_EN",
                        "DeadPixel_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Snaurce_Medium_Bundle"))._enemyBundles = list1;
                }

                //Salt
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_DeadPixel_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "Snaurce_EN",
                    "Snaurce_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_DeadPixel_Medium_EnemyBundle"))._enemyBundles = list2;

                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "AFlower_EN",
                    "MudLung_EN",
                    "Snaurce_EN",
                }));
                if(SaltsReseasoned.trolling > 50)
                {
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "AFlower_EN",
                        "JumbleGuts_Waning_EN",
                        "Snaurce_EN",
                    }));
                }
                if (SaltsReseasoned.trolling < 50)
                {
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "AFlower_EN",
                        "Spoggle_Ruminating_EN",
                        "Snaurce_EN",
                    }));
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Medium_EnemyBundle"))._enemyBundles = list3;

                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Hard_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "AFlower_EN",
                    "FlaMinGoa_EN",
                    "Snaurce_EN",
                }));
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "AFlower_EN",
                    "Keko_EN",
                    "Keko_EN",
                    "Snaurce_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_AFlower_Hard_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MechanicalLens_Hard_EnemyBundle"))._enemyBundles);
                if (SaltsReseasoned.trolling < 50)
                {
                    list5.Add(new RandomEnemyGroup(new string[]
                    {
                        "MechanicalLens_EN",
                        "Snaurce_EN",
                        "JumbleGuts_Waning_EN",
                        "JumbleGuts_Clotted_EN",
                    }));
                }
                if (SaltsReseasoned.trolling > 50)
                {
                    list5.Add(new RandomEnemyGroup(new string[]
                    {
                        "MechanicalLens_EN",
                        "Snaurce_EN",
                        "Spoggle_Spitfire_EN",
                        "Spoggle_Ruminating_EN",
                    }));
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MechanicalLens_Hard_EnemyBundle"))._enemyBundles = list5;

                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TeachaMantoFish_Hard_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "TeachaMantoFish_EN",
                    "Snaurce_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TeachaMantoFish_Hard_EnemyBundle"))._enemyBundles = list6;

                //Base Game
                if (SaltsReseasoned.silly < 50)
                {
                    List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
                    list7.Add(new RandomEnemyGroup(new string[]
                    {
                        "JumbleGuts_Waning_EN",
                        "Snaurce_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = list7;
                }
                if (SaltsReseasoned.silly > 50)
                {
                    List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
                    list8.Add(new RandomEnemyGroup(new string[]
                    {
                        "JumbleGuts_Clotted_EN",
                        "Snaurce_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = list8;
                }

                List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
                list9.Add(new RandomEnemyGroup(new string[]
                {
                    "Flarb_EN",
                    "MechanicalLens_EN",
                    "Snaurce_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list9;
            }
        }
    }
}
