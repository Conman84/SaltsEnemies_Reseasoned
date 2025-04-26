using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoRomanticEncounters
    {
        public static void Add()
        {
            if (Check.EnemyExist("Romantic_EN"))
            {
                //Salt
                //Orpheum
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Enigma_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "Enigma_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Enigma_Medium_EnemyBundle"))._enemyBundles = list1;

                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Easy_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "Something_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Easy_EnemyBundle"))._enemyBundles = list2;

                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Something_EN",
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Romantic_EN",
                }));
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Something_EN",
                    "Scrungie_EN",
                    "Romantic_EN",
                }));
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "Something_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Something_Medium_EnemyBundle"))._enemyBundles = list3;

                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Easy_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Romantic_EN",
                    "Romantic_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Easy_EnemyBundle"))._enemyBundles = list4;

                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "Spoggle_Writhing_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles = list5;

                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Freud_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "Freud_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Romantic_EN",
                }));
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "Freud_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Freud_Medium_EnemyBundle"))._enemyBundles = list6;

                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MechanicalLens_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "Spoggle_Writhing_EN",
                    "Spoggle_Writhing_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MechanicalLens_Medium_EnemyBundle"))._enemyBundles = list7;

                //Garden
                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_LittleAngel_Easy_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "LittleAngel_EN",
                    "NextOfKin_EN",
                    "NextOfKin_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_LittleAngel_Easy_EnemyBundle"))._enemyBundles = list8;

                List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles);
                list9.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "Romantic_EN",
                }));
                list9.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "GigglingMinister_EN",
                    "Romantic_EN",
                }));
                list9.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "ChoirBoy_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles = list9;

                List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
                list10.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "Romantic_EN",
                }));
                list10.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "ShiveringHomunculus_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list10;

                //Base Game
                //Orpheum
                List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
                list11.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list11;

                List<RandomEnemyGroup> list12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list12.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list12;

                List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list13.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "Something_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list13;

                List<RandomEnemyGroup> list14 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
                list14.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list14;

                List<RandomEnemyGroup> list15 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
                list15.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Enigma_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list15;

                List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list16.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "TheCrow_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list16;

                List<RandomEnemyGroup> list17 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
                list17.Add(new RandomEnemyGroup(new string[]
                {
                    "WrigglingSacrifice_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list17;

                //Garden
                List<RandomEnemyGroup> list18 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
                list18.Add(new RandomEnemyGroup(new string[]
                {
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list18;

                List<RandomEnemyGroup> list19 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles);
                list19.Add(new RandomEnemyGroup(new string[]
                {
                    "ChoirBoy_EN",
                    "LittleAngel_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles = list19;

                List<RandomEnemyGroup> list20 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);
                list20.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = list20;

                List<RandomEnemyGroup> list21 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list21.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "Romantic_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list21;
            }
        }
    }
}
