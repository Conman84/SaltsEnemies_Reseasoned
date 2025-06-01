using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WindSongEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_WindSongEncounters_Sign", ResourceLoader.LoadSprite("WindSongWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            //Medium
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "H_Zone02_WindSong_Medium_EnemyBundle", "Salt_WindSongEncounters_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/WindSongSong";
            mainEncounters.RoarEvent = "event:/Hawthorne/HissingNoise";

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "Scrungie_EN",
                "Scrungie_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "Scrungie_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                Spoggle.Red,
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                Spoggle.Red,
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_WindSong_Medium_EnemyBundle", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Garden
            //Easy
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone03_WindSong_Easy_EnemyBundle", "Salt_WindSongEncounters_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/WindSongSong";
            mainEncounters2.RoarEvent = "event:/Hawthorne/HissingNoise";

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "ChoirBoy_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                Flower.Red,
                Flower.Blue,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                Flower.Red,
                Flower.Yellow,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "WindSong_EN",
                Flower.Red,
                Flower.Purple,
            }, null);

            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone03_WindSong_Easy_EnemyBundle", 3, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);

            //Secondary
            //Orpheum
            AddTo bundle1 = new AddTo("H_Zone02_MusicMan_Easy_EnemyBundle");
            bundle1.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "WindSong_EN");

            AddTo bundle2 = new AddTo("H_Zone02_MusicMan_Medium_EnemyBundle");
            bundle2.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "WindSong_EN", "SingingStone_EN");
            bundle2.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "MusicMan_EN", "WindSong_EN");

            AddTo bundle3 = new AddTo("H_Zone02_Scrungie_Medium_EnemyBundle");
            bundle3.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "WindSong_EN");
            bundle3.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "WindSong_EN", "Enigma_EN");

            AddTo bundle4 = new AddTo("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle");
            bundle4.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "WindSong_EN");

            AddTo bundle5 = new AddTo("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle");
            bundle5.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "WindSong_EN");

            if(SaltsReseasoned.silly < 50)
            {
                AddTo bundle6 = new AddTo("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle");
                bundle6.AddRandomGroup(Jumble.Blue, "LivingSolvent_EN", "WindSong_EN");
            }
            if (SaltsReseasoned.silly > 50)
            {
                AddTo bundle7 = new AddTo("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle");
                bundle7.AddRandomGroup(Jumble.Purple, "LivingSolvent_EN", "WindSong_EN");
            }

            if (SaltsReseasoned.rando == 66)
            {
                AddTo bundle8 = new AddTo("H_Zone02_InnerChild_Hard_EnemyBundle");
                bundle8.AddRandomGroup("ManicMan_EN", "ManicMan_EN", "ManicMan_EN", "ManicMan_EN", "WindSong_EN");
            }

            AddTo bundle9 = new AddTo("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle");
            if (SaltsReseasoned.trolling < 25)
            {
                bundle9.AddRandomGroup("WrigglingSacrifice_EN", "WindSong_EN", Jumble.Blue);
            }
            if (SaltsReseasoned.trolling > 25 && SaltsReseasoned.trolling < 50)
            {
                bundle9.AddRandomGroup("WrigglingSacrifice_EN", "WindSong_EN", Jumble.Purple);
            }
            if (SaltsReseasoned.trolling > 50 && SaltsReseasoned.trolling < 75)
            {
                bundle9.AddRandomGroup("WrigglingSacrifice_EN", "WindSong_EN", Flower.Yellow);
            }
            if (SaltsReseasoned.trolling > 75)
            {
                bundle9.AddRandomGroup("WrigglingSacrifice_EN", "WindSong_EN", Flower.Purple);
            }

            AddTo bundle10 = new AddTo("H_Zone02_Revola_Hard_EnemyBundle");
            bundle10.AddRandomGroup("WindSong_EN", "Revola_EN");
            bundle10.AddRandomGroup("WindSong_EN", "Enigma_EN", "Revola_EN");

            AddTo bundle11 = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            bundle11.AddRandomGroup("Conductor_EN", "WindSong_EN");

            AddTo bundle12 = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            bundle12.AddRandomGroup("Conductor_EN", "MusicMan_EN", "WindSong_EN");
            bundle12.AddRandomGroup("Conductor_EN", "LivingSolvent_EN", "WindSong_EN");
            bundle12.AddRandomGroup("Conductor_EN", "LivingSolvent_EN", "Enigma_EN", "WindSong_EN");

            AddTo bundle13 = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            bundle13.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", "WindSong_EN");
            bundle13.AddRandomGroup("Enigma_EN", "Enigma_EN", "LivingSolvent_EN", "WindSong_EN");

            AddTo bundle14 = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            bundle14.AddRandomGroup("Something_EN", "MusicMan_EN", "WindSong_EN");
            bundle14.AddRandomGroup("Something_EN", "Scrungie_EN", "WindSong_EN");

            AddTo bundle15 = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            bundle15.AddRandomGroup("TheCrow_EN", "WindSong_EN");
            bundle15.AddRandomGroup("TheCrow_EN", "LivingSolvent_EN", "WindSong_EN");
            bundle15.AddRandomGroup("TheCrow_EN", "FakeAngel_EN", "WindSong_EN");
            bundle15.AddRandomGroup("TheCrow_EN", "MusicMan_EN", "WindSong_EN");
            bundle15.AddRandomGroup("TheCrow_EN", "Enigma_EN", "WindSong_EN");

            AddTo bundle16 = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            bundle16.AddRandomGroup("Freud_EN", "WindSong_EN", "MusicMan_EN");
            bundle16.AddRandomGroup("Freud_EN", "WindSong_EN", "Delusion_EN");

            AddTo bundle17 = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            bundle17.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "LostSheep_EN", "WindSong_EN");
            bundle17.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "FakeAngel_EN", "WindSong_EN");

            AddTo bundle18 = new AddTo("H_Zone02_Delusion_Easy_EnemyBundle");
            bundle18.AddRandomGroup("Delusion_EN", "FakeAngel_EN", "WindSong_EN");

            AddTo bundle19 = new AddTo("H_Zone02_Delusion_Medium_EnemyBundle");
            bundle19.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", "WindSong_EN");
            bundle19.AddRandomGroup("Delusion_EN", "Delusion_EN", "LivingSolvent_EN", "WindSong_EN");
            bundle19.AddRandomGroup("Delusion_EN", "Delusion_EN", "Enigma_EN", "WindSong_EN");
            bundle19.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN", "WindSong_EN");

            if(SaltsReseasoned.silly > 50)
            {
                AddTo bundle20 = new AddTo("H_Zone02_YellowFlower_Medium_EnemyBundle");
                bundle20.AddRandomGroup(Flower.Yellow, "LivingSolvent_EN", "WindSong_EN");
            }
            if (SaltsReseasoned.silly < 50)
            {
                AddTo bundle21 = new AddTo("H_Zone02_PurpleFlower_Medium_EnemyBundle");
                bundle21.AddRandomGroup(Flower.Purple, "LivingSolvent_EN", "WindSong_EN");
            }

            //Garden
            AddTo bundle22 = new AddTo("H_Zone03_InHerImage_Easy_EnemyBundle");
            bundle22.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "WindSong_EN");

            AddTo bundle23 = new AddTo("H_Zone03_InHisImage_Easy_EnemyBundle");
            bundle23.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "WindSong_EN");

            AddTo bundle24 = new AddTo("H_Zone03_InHerImage_Medium_EnemyBundle");
            bundle24.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "WindSong_EN");
            bundle24.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "WindSong_EN");
            bundle24.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "InHisImage_EN", "WindSong_EN");
            bundle24.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "NextOfKin_EN", "WindSong_EN");

            AddTo bundle25 = new AddTo("H_Zone03_InHisImage_Medium_EnemyBundle");
            bundle25.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "WindSong_EN");
            bundle25.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHerImage_EN", "WindSong_EN");
            bundle25.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "NextOfKin_EN", "WindSong_EN");

            AddTo bundle26 = new AddTo("H_Zone03_ChoirBoy_Easy_EnemyBundle");
            bundle26.AddRandomGroup("ChoirBoy_EN", "WindSong_EN");

            if (SaltsReseasoned.rando == 36)
            {
                AddTo bundle27 = new AddTo("H_Zone03_ShiveringHomunculus_Medium_EnemyBundle");
                bundle27.AddRandomGroup("ShiveringHomunculus_EN", "ShiveringHomunculus_EN", "ShiveringHomunculus_EN", "WindSong_EN");
            }

            AddTo bundle28 = new AddTo("H_Zone03_SkinningHomunculus_Medium_EnemyBundle");
            bundle28.AddRandomGroup("SkinningHomunculus_EN", "ShiveringHomunculus_EN", "WindSong_EN");
            bundle28.AddRandomGroup("SkinningHomunculus_EN", Jumble.Grey, "WindSong_EN");

            AddTo bundle29 = new AddTo("H_Zone03_SkinningHomunculus_Hard_EnemyBundle");
            bundle29.AddRandomGroup("SkinningHomunculus_EN", "SkinningHomunculus_EN", "WindSong_EN");
            bundle29.AddRandomGroup("SkinningHomunculus_EN", "GigglingMinister_EN", "WindSong_EN");
            bundle29.AddRandomGroup("SkinningHomunculus_EN", "ChoirBoy_EN", "WindSong_EN");
            bundle29.AddRandomGroup("SkinningHomunculus_EN", Spoggle.Grey, "WindSong_EN");

            AddTo bundle30 = new AddTo("H_Zone03_GigglingMinister_Easy_EnemyBundle");
            bundle30.AddRandomGroup("GigglingMinister_EN", "LittleAngel_EN", "WindSong_EN");

            AddTo bundle31 = new AddTo("H_Zone03_GigglingMinister_Medium_EnemyBundle");
            bundle31.AddRandomGroup("GigglingMinister_EN", "ChoirBoy_EN", "WindSong_EN");

            AddTo bundle32 = new AddTo("H_Zone03_GigglingMinister_Hard_EnemyBundle");
            bundle32.AddRandomGroup("GigglingMinister_EN", "ChoirBoy_EN", "LittleAngel_EN", "WindSong_EN");
            bundle32.AddRandomGroup("GigglingMinister_EN", "GigglingMinister_EN", "NextOfKin_EN", "WindSong_EN");

            AddTo bundle33 = new AddTo("H_Zone03_RusticJumbleGuts_Medium_EnemyBundle");
            bundle33.AddRandomGroup(Jumble.Grey, "InHisImage_EN", "InHerImage_EN", "WindSong_EN");

            AddTo bundle34 = new AddTo("H_Zone03_MortalSpoggle_Medium_EnemyBundle");
            bundle34.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHerImage_EN", "WindSong_EN");

            AddTo bundle35 = new AddTo("H_Zone03_Satyr_Medium_EnemyBundle");
            bundle35.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "WindSong_EN");

            AddTo bundle36 = new AddTo("H_Zone03_Satyr_Hard_EnemyBundle");
            bundle36.AddRandomGroup("Satyr_EN", "InHerImage_EN", "InHerImage_EN", "WindSong_EN");
            bundle36.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "LittleAngel_EN", "WindSong_EN");
            bundle36.AddRandomGroup("Satyr_EN", "SkinningHomunculus_EN", "WindSong_EN");

            AddTo bundle37 = new AddTo("H_Zone03_BlueFlower_Easy_EnemyBundle");
            bundle37.AddRandomGroup(Flower.Blue, Flower.Red, "WindSong_EN");

            AddTo bundle38 = new AddTo("H_Zone03_RedFlower_Easy_EnemyBundle");
            bundle38.AddRandomGroup(Flower.Red, Flower.Blue, "WindSong_EN");

            AddTo bundle39 = new AddTo("H_Zone03_MechanicalLens_Medium_EnemyBundle");
            bundle39.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN", "WindSong_EN");

            AddTo bundle40 = new AddTo("H_Zone03_TheEndOfTime_Hard_EnemyBundle");
            bundle40.AddRandomGroup("ClockTower_EN", "SkinningHomunculus_EN", "SkinningHomunculus_EN", "WindSong_EN");
            bundle40.AddRandomGroup("ClockTower_EN", "LittleAngel_EN", "ChoirBoy_EN", "WindSong_EN");

            AddTo bundle41 = new AddTo("H_Zone03_SemiRealisticTank_Hard_EnemyBundle");
            bundle41.AddRandomGroup("RealisticTank_EN", "WindSong_EN");
        }
    }
}
