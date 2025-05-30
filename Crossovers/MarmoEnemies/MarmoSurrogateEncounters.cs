using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoSurrogateEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Surrogate_EN"))
            {
                //Salt
                //Orpheum
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Easy_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Easy_EnemyBundle"))._enemyBundles = list1;

                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Surrogate_EN",
                }));
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Spoggle_Writhing_EN",
                    "Surrogate_EN",
                }));
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Surrogate_EN",
                }));
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Something_EN",
                    "Surrogate_EN",
                }));
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "MechanicalLens_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles = list2;

                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MechanicalLens_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MechanicalLens_Medium_EnemyBundle"))._enemyBundles = list3;

                //Garden
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "InHisImage_EN",
                    "InHisImage_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "ShiveringHomunculus_EN",
                    "Surrogate_EN",
                }));
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "RusticJumbleguts_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list5;

                //Base Game
                //Orpheum
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Surrogate_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list6;

                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "Surrogate_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list7;

                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Something_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list8;

                //Garden
                List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list10.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "Surrogate_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list10;
            }
        }
    }
}
