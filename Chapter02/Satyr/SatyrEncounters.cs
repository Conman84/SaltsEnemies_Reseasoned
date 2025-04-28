using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SatyrEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_Satyr_Sign", ResourceLoader.LoadSprite("SatyrIcon.png", null, 32, null), Portals.EnemyIDColor);

            //Garden
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone03_Satyr_Medium_EnemyBundle", "Salt_Satyr_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/NewerSatyrTheme";
            mainEncounters.RoarEvent = "event:/Hawthorne/Oisenay/SatyrRoar";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "InHisImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "InHerImage_EN",
                "InHerImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "InHisImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_Satyr_Medium_EnemyBundle", 7, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);

            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone03_Satyr_Hard_EnemyBundle", "Salt_Satyr_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/NewerSatyrTheme";
            mainEncounters2.RoarEvent = "event:/Hawthorne/Oisenay/SatyrRoar";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "GigglingMinister_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "GigglingMinister_EN",
                "InHisImage_EN",
                "InHisImage_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "GigglingMinister_EN",
                "GigglingMinister_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "SkinningHomunculus_EN",
                "LittleAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "ChoirBoy_EN",
                "LittleAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "Satyr_EN",
                "SkinningHomunculus_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Satyr_EN",
                "Satyr_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_Satyr_Hard_EnemyBundle", 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);

            //Secondary
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup(new string[]
            {
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",
                "Satyr_EN",
            }));
            if(SaltsReseasoned.trolling > 50)
            {
                list1.Add(new RandomEnemyGroup(new string[]
                {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "ChoirBoy_EN",
                }));
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list1;

            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            if (SaltsReseasoned.trolling < 50)
            {
                list2.Add(new RandomEnemyGroup(new string[]
                {
                    "GigglingMinister_EN",
                    "GigglingMinister_EN",
                    "Satyr_EN",
                }));
            }
            list2.Add(new RandomEnemyGroup(new string[]
            {
                "GigglingMinister_EN",
                "SkinningHomunculus_EN",
                "Satyr_EN",
            }));
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list2;
        }
    }
}
