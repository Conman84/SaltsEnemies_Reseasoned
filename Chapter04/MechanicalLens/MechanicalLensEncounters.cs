using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MechanicalLensEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_MechanicalLensEncounters_Sign", ResourceLoader.LoadSprite("DroneIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Far Shore
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone01_MechanicalLens_Hard_EnemyBundle", "Salt_MechanicalLensEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/CameraSong";
            mainEncounters.RoarEvent = "event:/Hawthorne/Nois2/CameraRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "FlaMinGoa_EN",
                "MunglingMudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "FlaMinGoa_EN",
                "AFlower_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "AFlower_EN",
                "MunglingMudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MunglingMudLung_EN",
                "Spoggle_Spitfire_EN",
                "Spoggle_Ruminating_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "FlaMinGoa_EN",
                "JumbleGuts_Waning_EN",
                "JumbleGuts_Hollowing_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MunglingMudLung_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "AFlower_EN",
                "DeadPixel_EN",
                "DeadPixel_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "FlaMinGoa_EN",
                "MudLung_EN",
                "Flarb_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MudLung_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "FlaMinGoa_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "FlaMinGoa_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "AFlower_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "AFlower_EN",
                "MudLung_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MudLung_EN",
                "MudLung_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone01_MechanicalLens_Hard_EnemyBundle", 10 * April.Mod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);

            //Orpheum
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_MechanicalLens_Medium_EnemyBundle", "Salt_MechanicalLensEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/CameraSong";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Nois2/CameraRoar";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MusicMan_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Scrungie_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Something_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Something_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "Something_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Freud_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "Freud_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "Freud_EN",
                "Something_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "TheCrow_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "TheCrow_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "TheCrow_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_MechanicalLens_Medium_EnemyBundle", 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Garden
            EnemyEncounter_API mainEncounters3 = new EnemyEncounter_API(0, "H_Zone03_MechanicalLens_Medium_EnemyBundle", "Salt_MechanicalLensEncounters_Sign");
            mainEncounters3.MusicEvent = "event:/Hawthorne/CameraSong";
            mainEncounters3.RoarEvent = "event:/Hawthorne/Nois2/CameraRoar";

            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "LittleAngel_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "RusticJumbleguts_EN",
            }, null);
            mainEncounters3.CreateNewEnemyEncounterData(new string[]
            {
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters3.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_MechanicalLens_Medium_EnemyBundle", 1, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);

            //Secondary
            //Far Shore
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling < 50)
            {
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "Flarb_EN",
                    "MechanicalLens_EN",
                }));
            }
            if (SaltsReseasoned.trolling > 50)
            {
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "Flarb_EN",
                    "MechanicalLens_EN",
                    "Flarblet_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "Voboola_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list2;

            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Hollowing_Hard_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Hollowing_Hard_EnemyBundle"))._enemyBundles = list3;
            }

            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Flummoxing_Hard_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Flummoxing_Hard_EnemyBundle"))._enemyBundles = list4;
            }

            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Writhing_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Resonant_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Writhing_Hard_EnemyBundle"))._enemyBundles = list5;
            }

            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Resonant_Hard_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Resonant_EN",
                    "Spoggle_Writhing_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Resonant_Hard_EnemyBundle"))._enemyBundles = list6;
            }

            //Orpheum
            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list7;
            }

            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup(new string[]
                {
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list8;
            }

            if (SaltsReseasoned.silly < 50)
            {
                List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
                list9.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Resonant_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list9;
            }

            if (SaltsReseasoned.silly > 50)
            {
                List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
                list10.Add(new RandomEnemyGroup(new string[]
                {
                    "Spoggle_Resonant_EN",
                    "Spoggle_Writhing_EN",
                    "MechanicalLens_EN",
                }));
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list10;
            }

            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup(new string[]
            {
                "Scrungie_EN",
                "Scrungie_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list11;

            List<RandomEnemyGroup> list12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling > 50)
            {
                list12.Add(new RandomEnemyGroup(new string[]
                {
                    "WrigglingSacrifice_EN",
                    "WrigglingSacrifice_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                }));
            }
            if (SaltsReseasoned.trolling < 50)
            {
                list12.Add(new RandomEnemyGroup(new string[]
                {
                    "WrigglingSacrifice_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list12;

            List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling < 50)
            {
                list13.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "MechanicalLens_EN",
                    "MechanicalLens_EN",
                }));
            }
            if (SaltsReseasoned.trolling > 50)
            {
                list13.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "MechanicalLens_EN",
                    "LostSheep_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = list13;

            List<RandomEnemyGroup> list14 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling < 50)
            {
                list14.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "Scrungie_EN",
                    "MechanicalLens_EN",
                    "SingingStone_EN",
                }));
            }
            if (SaltsReseasoned.trolling > 50)
            {
                list14.Add(new RandomEnemyGroup(new string[]
                {
                    "Conductor_EN",
                    "MechanicalLens_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list14;

            //Garden
            List<RandomEnemyGroup> list15 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling > 50)
            {
                list15.Add(new RandomEnemyGroup(new string[]
                {
                    "ChoirBoy_EN",
                    "MechanicalLens_EN",
                    "NextOfKin_EN",
                }));
            }
            if (SaltsReseasoned.trolling < 50)
            {
                list15.Add(new RandomEnemyGroup(new string[]
                {
                    "ChoirBoy_EN",
                    "ChoirBoy_EN",
                    "MechanicalLens_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles = list15;

            List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);
            list16.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }));
            list16.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "MechanicalLens_EN",
                "ShiveringHomunculus_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = list16;

            List<RandomEnemyGroup> list17 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list17.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list17;

            List<RandomEnemyGroup> list18 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle"))._enemyBundles);
            list18.Add(new RandomEnemyGroup(new string[]
            {
                "GigglingMinister_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle"))._enemyBundles = list18;

            List<RandomEnemyGroup> list19 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);
            list19.Add(new RandomEnemyGroup(new string[]
            {
                "GigglingMinister_EN",
                "GigglingMinister_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list19;

        }
    }

    public static class SaltMechanicalLensEncounters
    {
        public static void Add()
        {
            //Orpheum
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Freud_Medium_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "Freud_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Freud_Medium_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling < 50)
            {
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "MechanicalLens_EN",
                    "Enigma_EN",
                }));
            }
            if (SaltsReseasoned.trolling > 50)
            {
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "TheCrow_EN",
                    "MechanicalLens_EN",
                    "MusicMan_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Crow_Medium_EnemyBundle"))._enemyBundles = list2;

            //Garden
            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup(new string[]
            {
                "Satyr_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
                "MechanicalLens_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Medium_EnemyBundle"))._enemyBundles = list3;

            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling < 50)
            {
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "MechanicalLens_EN",
                }));
            }
            if (SaltsReseasoned.trolling > 50)
            {
                list4.Add(new RandomEnemyGroup(new string[]
                {
                    "Satyr_EN",
                    "ChoirBoy_EN",
                    "MechanicalLens_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Satyr_Hard_EnemyBundle"))._enemyBundles = list4;
        }
    }
}
