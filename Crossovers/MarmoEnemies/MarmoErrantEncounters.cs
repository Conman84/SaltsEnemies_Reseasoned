using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoErrantEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Errant_EN"))
            {
                //Marmo
                if (Check.BundleExist("Marmo_Errant_Medium_Bundle"))
                {
                    List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Errant_Medium_Bundle"))._enemyBundles);
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Errant_EN",
                        "Enigma_EN",
                    }));
                    list1.Add(new RandomEnemyGroup(new string[]
                    {
                        "Errant_EN",
                        "SilverSuckle_EN",
                        "SilverSuckle_EN",
                        "LostSheep_EN",
                    }));
                    if (SaltsReseasoned.trolling < 50)
                    {
                        list1.Add(new RandomEnemyGroup(new string[]
                        {
                            "Errant_EN",
                            "Something_EN",
                        }));
                    }
                    if (SaltsReseasoned.trolling > 50)
                    {
                        list1.Add(new RandomEnemyGroup(new string[]
                        {
                            "Errant_EN",
                            "MechanicalLens_EN",
                            "SilverSuckle_EN",
                            "SilverSuckle_EN",
                        }));
                    }
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Errant_Medium_Bundle"))._enemyBundles = list1;
                }

                if (Check.BundleExist("Marmo_Errant_Hard_Bundle"))
                {
                    List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Errant_Hard_Bundle"))._enemyBundles);
                    if (SaltsReseasoned.trolling > 50)
                    {
                        list2.Add(new RandomEnemyGroup(new string[]
                        {
                            "Errant_EN",
                            "MusicMan_EN",
                            "MusicMan_EN",
                            "LostSheep_EN",
                        }));
                    }
                    if (SaltsReseasoned.trolling < 50)
                    {
                        list2.Add(new RandomEnemyGroup(new string[]
                        {
                            "Errant_EN",
                            "JumbleGuts_Flummoxing_EN",
                            "LostSheep_EN",
                        }));
                    }
                    list2.Add(new RandomEnemyGroup(new string[]
                    {
                        "Errant_EN",
                        "TheCrow_EN",
                    }));
                    ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Marmo_Errant_Hard_Bundle"))._enemyBundles = list2;
                }
            }
        }
    }
}
