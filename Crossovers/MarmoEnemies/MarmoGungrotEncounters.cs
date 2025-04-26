using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoGungrotEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Gungrot_EN"))
            {
                //Marmo
                if (Check.BundleExist("Marmo_Errant_Hard_Bundle"))
                {
                    List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Errant_Hard_Bundle"))._enemyBundles);
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Errant_EN",
                        "Gungrot_EN",
                        "Gungrot_EN",
                        "LostSheep_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Errant_Hard_Bundle"))._enemyBundles = list1;
                }

                //Salt
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Easy_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "Something_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Easy_EnemyBundle"))._enemyBundles = list2;

                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                if (SaltsReseasoned.trolling > 50)
                {
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "TheCrow_EN",
                        "JumbleGuts_Flummoxing_EN",
                        "Gungrot_EN",
                        "Gungrot_EN",
                    }));
                }
                if (SaltsReseasoned.trolling < 50)
                {
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "TheCrow_EN",
                        "JumbleGuts_Hollowing_EN",
                        "Gungrot_EN",
                        "Gungrot_EN",
                    }));
                }
                if (SaltsReseasoned.trolling < 50)
                {
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "TheCrow_EN",
                        "Spoggle_Writhing_EN",
                        "Gungrot_EN",
                        "Gungrot_EN",
                    }));
                }
                if (SaltsReseasoned.trolling > 50)
                {
                    list3.Add(new RandomEnemyGroup(new string[]
                    {
                        "TheCrow_EN",
                        "Spoggle_Resonant_EN",
                        "Gungrot_EN",
                        "Gungrot_EN",
                    }));
                }
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "MusicMan_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles = list3;

                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Freud_Easy_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Freud_EN",
                    "Surrogate_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Freud_Easy_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MechanicalLens_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MechanicalLens_Medium_EnemyBundle"))._enemyBundles = list5;

                //Base Game
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "WrigglingSacrifice_EN",
                    "TheCrow_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list6;

                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Enigma_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list7;

                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "TheCrow_EN",
                    "Gungrot_EN",
                    "Gungrot_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list8;
            }
        }
    }
}
