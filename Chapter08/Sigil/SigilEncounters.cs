using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SigilEncounters
    {
        public static void Add()
        {
            //Main
            Portals.AddPortalSign("Salt_SigilEncounter_Sign", ResourceLoader.LoadSprite("SigilWorld.png", null, 32, null), Portals.EnemyIDColor);

            //Orpheum
            //Medium
            //No H
            EnemyEncounter_API mainEncounters = new EnemyEncounter_API(0, "Zone02_Sigil_Medium_EnemyBundle", "Salt_SigilEncounter_Sign");
            mainEncounters.MusicEvent = "event:/Hawthorne/SigilSong";
            mainEncounters.RoarEvent = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").deathSound;

            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "Enigma_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                "Scrungie_EN",
                "LostSheep_EN",
            }, null);

            mainEncounters.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("Zone02_Sigil_Medium_EnemyBundle", 12, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Medium);

            //H
            EnemyEncounter_API mainEncounters2 = new EnemyEncounter_API(0, "H_Zone02_Sigil_Medium_EnemyBundle", "Salt_SigilEncounter_Sign");
            mainEncounters2.MusicEvent = "event:/Hawthorne/SigilSong";
            mainEncounters2.RoarEvent = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").deathSound;

            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MechanicalLens_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                "Scrungie_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                "Scrungie_EN",
                "Scrungie_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                Jumble.Blue,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                Jumble.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                Spoggle.Red,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                Spoggle.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                Flower.Yellow,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Scrungie_EN",
                Flower.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Enigma_EN",
                "Enigma_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Delusion_EN",
                "Delusion_EN",
                "Delusion_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Delusion_EN",
                "MechanicalLens_EN",
                "FakeAngel_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Delusion_EN",
                "Delusion_EN",
                "Enigma_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                "Delusion_EN",
                "Delusion_EN",
                "LostSheep_EN",
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                Flower.Yellow,
                Flower.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                Jumble.Blue,
                Jumble.Purple,
            }, null);
            mainEncounters2.CreateNewEnemyEncounterData(new string[]
            {
                "Sigil_EN",
                Spoggle.Red,
                Spoggle.Purple,
            }, null);

            mainEncounters2.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("H_Zone02_Sigil_Medium_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            //Secondary
            AddTo bundle1 = new AddTo("Zone02_MusicMan_Medium_EnemyBundle");
            bundle1.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "Sigil_EN");

            AddTo bundle2 = new AddTo("H_Zone02_MusicMan_Medium_EnemyBundle");
            bundle2.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "Sigil_EN", "SingingStone_EN");

            AddTo bundle3 = new AddTo("Zone02_Scrungie_Hard_EnemyBundle");
            bundle3.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Sigil_EN");

            AddTo bundle4 = new AddTo("H_Zone02_Scrungie_Medium_EnemyBundle");
            bundle4.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Sigil_EN");

            if(SaltsReseasoned.trolling < 50)
            {
                AddTo bundle5 = new AddTo("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle");
                bundle5.AddRandomGroup(Jumble.Purple, Jumble.Blue, "Sigil_EN");
            }

            if (SaltsReseasoned.trolling > 50)
            {
                AddTo bundle6 = new AddTo("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle");
                bundle6.AddRandomGroup(Jumble.Blue, Jumble.Purple, "Sigil_EN");
            }

            if (SaltsReseasoned.trolling < 50)
            {
                AddTo bundle7 = new AddTo("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle");
                bundle7.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Sigil_EN");
            }

            if (SaltsReseasoned.trolling > 50)
            {
                AddTo bundle8 = new AddTo("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle");
                bundle8.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "Sigil_EN");
            }

            if (SaltsReseasoned.rando == 83)
            {
                AddTo bundle9 = new AddTo("H_Zone02_InnerChild_Hard_EnemyBundle");
                bundle9.AddRandomGroup("ManicMan_EN", "ManicMan_EN", "ManicMan_EN", "ManicMan_EN", "Sigil_EN");
            }

            AddTo bundle10 = new AddTo("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle");
            if (SaltsReseasoned.silly < 50)
            {
                bundle10.AddRandomGroup("WrigglingSacrifice_EN", "WrigglingSacrifice_EN", "Sigil_EN", "MusicMan_EN");
            }

            if (SaltsReseasoned.silly > 50)
            {
                bundle10.AddRandomGroup("WrigglingSacrifice_EN", "WrigglingSacrifice_EN", "Sigil_EN", "Enigma_EN");
            }

            AddTo bundle11 = new AddTo("Zone02_Revola_Hard_EnemyBundle");
            bundle11.AddRandomGroup("Revola_EN", "Sigil_EN");

            AddTo bundle12 = new AddTo("H_Zone02_Revola_Hard_EnemyBundle");
            bundle12.AddRandomGroup("Revola_EN", "Sigil_EN");

            AddTo bundle13 = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            bundle13.AddRandomGroup("Conductor_EN", "Sigil_EN", "SilverSuckle_EN", "SilverSuckle_EN", "SilverSuckle_EN");

            AddTo bundle14 = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            if (SaltsReseasoned.silly < 33)
            {
                bundle14.AddRandomGroup("Conductor_EN", "Sigil_EN", Jumble.Blue);
            }
            if (SaltsReseasoned.silly > 33 && SaltsReseasoned.silly < 66)
            {
                bundle14.AddRandomGroup("Conductor_EN", "Sigil_EN", Spoggle.Red);
            }
            if (SaltsReseasoned.silly > 66)
            {
                bundle14.AddRandomGroup("Conductor_EN", "Sigil_EN", Flower.Purple);
            }
            bundle14.AddRandomGroup("Conductor_EN", "Sigil_EN", "MusicMan_EN", "MusicMan_EN");

            AddTo bundle15 = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            bundle15.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", "Sigil_EN");
            bundle15.AddRandomGroup("Enigma_EN", "Enigma_EN", "Sigil_EN", "Delusion_EN");

            AddTo bundle16 = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            bundle16.AddRandomGroup("Something_EN", "Sigil_EN", "MusicMan_EN");
            bundle16.AddRandomGroup("Something_EN", "Sigil_EN", Jumble.Blue);

            AddTo bundle17 = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            bundle17.AddRandomGroup("TheCrow_EN", "Sigil_EN", "Scrungie_EN", "SilverSuckle_EN", "SilverSuckle_EN");

            AddTo bundle18 = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            bundle18.AddRandomGroup("Freud_EN", "Sigil_EN", "MusicMan_EN", "MusicMan_EN");
            bundle18.AddRandomGroup("Freud_EN", "Sigil_EN", "Delusion_EN", "LostSheep_EN");

            AddTo bundle19 = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            bundle19.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "MechanicalLens_EN", "Sigil_EN");

            AddTo bundle20 = new AddTo("H_Zone02_Delusion_Medium_EnemyBundle");
            bundle20.AddRandomGroup("Delusion_EN", "Delusion_EN", "Sigil_EN", "FakeAngel_EN");
            bundle20.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", "Sigil_EN", "FakeAngel_EN");
            bundle20.AddRandomGroup("Delusion_EN", "Delusion_EN", "Sigil_EN", "Enigma_EN");

            AddTo bundle21 = new AddTo("H_Zone02_YellowFlower_Medium_EnemyBundle");
            bundle21.AddRandomGroup(Flower.Yellow, Flower.Purple, "Sigil_EN");
            bundle21.AddRandomGroup(Flower.Yellow, "Delusion_EN", "Sigil_EN", "FakeAngel_EN");

            AddTo bundle22 = new AddTo("H_Zone02_PurpleFlower_Medium_EnemyBundle");
            bundle22.AddRandomGroup(Flower.Purple, Flower.Yellow, "Sigil_EN");
            bundle22.AddRandomGroup(Flower.Purple, "Delusion_EN", "Sigil_EN", "FakeAngel_EN");
        }
    }
}
