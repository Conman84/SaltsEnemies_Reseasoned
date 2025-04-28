using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned.Chapter1.LostSheep
{
    public static class LostSheepEncounters
    {
        public static void Add()
        {
            //Secondary
            //Far Shore
            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "Mung_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle"))._enemyBundles = list1;
            }

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_MudLung_Easy_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "MudLung_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_MudLung_Easy_EnemyBundle"))._enemyBundles = list2;

            List<RandomEnemyGroup> hlist2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Easy_EnemyBundle"))._enemyBundles);
            hlist2.Add(new RandomEnemyGroup(new string[]
            {
                "MudLung_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Easy_EnemyBundle"))._enemyBundles = hlist2;

            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup(new string[]
            {
                "MudLung_EN",
                "JumbleGuts_Waning_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list3;

            List<RandomEnemyGroup> hlist3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
            hlist3.Add(new RandomEnemyGroup(new string[]
            {
                "MudLung_EN",
                "JumbleGuts_Waning_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = hlist3;

            if (SaltsReseasoned.rando == 62)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_JumbleGuts_Waning_Easy_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Waning_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_JumbleGuts_Waning_Easy_EnemyBundle"))._enemyBundles = list4;
            }

            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "JumbleGuts_Waning_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = list5;

                List<RandomEnemyGroup> hlist5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
                hlist5.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "JumbleGuts_Waning_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = hlist5;
            }

            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Waning_EN",
                    "JumbleGuts_Clotted_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = list6;

                List<RandomEnemyGroup> hlist6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
                hlist6.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Waning_EN",
                    "JumbleGuts_Clotted_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = hlist6;
            }
            
            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Spitfire_EN",
                    "Spoggle_Ruminating_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list7;

                List<RandomEnemyGroup> hlist7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
                hlist7.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Spitfire_EN",
                    "Spoggle_Ruminating_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = hlist7;
            }
            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles = list8;

                List<RandomEnemyGroup> hlist8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles);
                hlist8.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles = hlist8;
            }

            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "MunglingMudLung_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles = list9;

            List<RandomEnemyGroup> hlist9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles);
            hlist9.Add(new RandomEnemyGroup(new string[]
            {
                "FlaMinGoa_EN",
                "MunglingMudLung_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles = hlist9;

            List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Keko_Medium_EnemyBundle"))._enemyBundles);
            list10.Add(new RandomEnemyGroup(new string[]
            {
                "Keko_EN",
                "Keko_EN",
                "Keko_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Keko_Medium_EnemyBundle"))._enemyBundles = list10;

            List<RandomEnemyGroup> hlist10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles);
            hlist10.Add(new RandomEnemyGroup(new string[]
            {
                "Keko_EN",
                "Keko_EN",
                "Keko_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles = hlist10;

            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup(new string[]
            {
                "Flarb_EN",
                "MunglingMudLung_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list11;

            List<RandomEnemyGroup> hlist11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            hlist11.Add(new RandomEnemyGroup(new string[]
            {
                "Flarb_EN",
                "MunglingMudLung_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = hlist11;

            List<RandomEnemyGroup> hlist12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            hlist12.Add(new RandomEnemyGroup(new string[]
            {
                "Voboola_EN",
                "JumbleGuts_Waning_EN",
                "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = hlist12;

            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> hlist13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles);
                hlist13.Add(new RandomEnemyGroup(new string[]
                {
                    "Kekastle_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles = hlist13;
            }
            
            //Orpheum
            if (SaltsReseasoned.trolling < 50)
            {
                List<RandomEnemyGroup> list14 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);
                list14.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles = list14;

                List<RandomEnemyGroup> hlist14 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);
                hlist14.Add(new RandomEnemyGroup(new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles = hlist14;  
            }

            List<RandomEnemyGroup> hlist15 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
            hlist15.Add(new RandomEnemyGroup(new string[]
            {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = hlist15;

            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list16.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list16;

                List<RandomEnemyGroup> hlist16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                hlist16.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = hlist16;
            }
            
            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list17 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list17.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list17;

                List<RandomEnemyGroup> hlist17 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                hlist17.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN",
                    "LostSheep_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = hlist17;
            }

            List<RandomEnemyGroup> hlist18 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
            hlist18.Add(new RandomEnemyGroup(new string[]
            {
                    "Conductor_EN",
                    "LostSheep_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = hlist18;
        }
    }
}