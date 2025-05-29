using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_Crossovers
    {
        public static void Add_1_4()
        {
            Moone();
            Heehoo();
            NoseStones();
            Draugr();
            Thunderdome();
        }
        public static void Moone()
        {
            AddTo easy = new AddTo("H_Zone02_Moone_Easy_EnemyBundle");
            easy.AddRandomGroup("Moone_EN", "Moone_EN", "Enigma_EN");

            AddTo med = new AddTo("H_Zone02_Moone_Medium_EnemyBundle");
            med.AddRandomGroup("Moone_EN", "Moone_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Moone_EN", "Moone_EN", "MusicMan_EN", "LostSheep_EN");
            med.AddRandomGroup("Moone_EN", "Moone_EN", "Moone_EN", "MechanicalLens_EN");

            easy = new AddTo("H_Zone02_Something_Easy_EnemyBundle");
            easy.AddRandomGroup("Something_EN", "Moone_EN");
            easy.AddRandomGroup("Something_EN", "Moone_EN", "LostSheep_EN");

            med = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            med.AddRandomGroup("Something_EN", "Moone_EN", "Moone_EN");
            med.AddRandomGroup("Something_EN", "Moone_EN", "Moone_EN", "Enigma_EN");
            med.AddRandomGroup("Something_EN", "Moone_EN", Jumble.Blue);

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", "Moone_EN", "Moone_EN", "Moone_EN");
            med.AddRandomGroup("TheCrow_EN", "Moone_EN", "Moone_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            med.AddRandomGroup("TheCrow_EN", "Moone_EN", Jumble.Purple);

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", "Moone_EN", "Moone_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            med.AddRandomGroup("Freud_EN", "Moone_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "Moone_EN", "Moone_EN");

            AddTo hard = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            hard.AddRandomGroup("Conductor_EN", "TheCrow_EN", "Moone_EN");

            med = new AddTo("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle");
            med.AddRandomGroup(Jumble.Blue, "Moone_EN", "Enigma_EN");
        }
        public static void Heehoo()
        {
            AddTo med = new AddTo("H_Zone02_Heehoo_Medium_EnemyBundle");
            med.AddRandomGroup("Heehoo_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Heehoo_EN", "Scrungie_EN", "Enigma_EN");

            AddTo hard = new AddTo("H_Zone02_Heehoo_Hard_EnemyBundle");
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", "TheCrow_EN", "SingingStone_EN");
            hard.AddRandomGroup("Heehoo_EN", "Something_EN", "Something_EN");
            hard.AddRandomGroup("Heehoo_EN", "MechanicalLens_EN", "Freud_EN");

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", "Heehoo_EN", "SIngingStone_EN", "SingingStone_EN");
        }
        public static void NoseStones()
        {
            AddTo med = new AddTo("H_Zone03_Satyr_Medium_EnemyBundle");
            med.AddRandomGroup("Satyr_EN", Noses.Red, "NextOfKin_EN");
            med.AddRandomGroup("Satyr_EN", Noses.Red, "Romantic_EN");

            med.AddRandomGroup("Satyr_EN", Noses.Blue);

            AddTo hard = new AddTo("H_Zone03_Satyr_Hard_EnemyBundle");
            hard.AddRandomGroup("Satyr_EN", Noses.Red, "ChoirBoy_EN");

            hard.AddRandomGroup("Satyr_EN", Noses.Blue, "ChoirBoy_EN");

            hard.AddRandomGroup("Satyr_EN", Noses.Yellow, "ChoirBoy_EN");

            hard.AddRandomGroup("Satyr_EN", Noses.Purple, Noses.Blue);
            hard.AddRandomGroup("Satyr_EN", Noses.Purple, Noses.Yellow);

            hard.AddRandomGroup("Satyr_EN", Noses.Grey, "LittleAngel_EN");

            hard = new AddTo("H_Zone03_SkinningHomunculus_Hard_EnemyBundle");
            hard.AddRandomGroup("SkinningHomunculus_EN", Noses.Red, "Satyr_EN");

            hard = new AddTo("H_Zone03_ScatterbrainedNosestone_Hard_EnemyBundle");
            hard.AddRandomGroup(Noses.Blue, Noses.Red, "LittleAngel_EN");

            hard = new AddTo("H_Zone03_GigglingMinister_Hard_EnemyBundle");
            hard.AddRandomGroup("GigglingMinister_EN", Noses.Blue, "LittleAngel_EN");

            med = new AddTo("H_Zone03_SweatingNosestone_Medium_EnemyBundle");
            med.AddRandomGroup(Noses.Yellow, "GigglingMinister_EN", "LittleAngel_EN");

            hard = new AddTo("H_Zone03_SweatingNosestone_Hard_EnemyBundle");
            hard.AddRandomGroup(Noses.Yellow, Noses.Red, "LittleAngel_EN");

            hard = new AddTo("H_Zone03_UninspiredNosestone_Hard_EnemyBundle");
            hard.AddRandomGroup(Noses.Grey, Noses.Red, "LittleAngel_EN");
            hard.AddRandomGroup(Noses.Grey, "InHisImage_EN", "InHisImage_EN", "LittleAngel_EN");
        }
        public static void Draugr()
        {
            AddTo med = new AddTo("H_Zone01_DeadPixel_Medium_EnemyBundle");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Draugr_EN");

            med = new AddTo("H_Zone01_AFlower_Medium_EnemyBundle");
            med.AddRandomGroup("AFlower_EN", "Draugr_EN");

            AddTo hard = new AddTo("H_Zone01_MechanicalLens_Hard_EnemyBundle");
            hard.AddRandomGroup("MechanicalLens_EN", "Draugr_EN", "FlaMinGoa_EN");

            hard = new AddTo("H_Zone01_Flarb_Hard_EnemyBundle");
            hard.AddRandomGroup("Flarb_EN", "Draugr_EN", "LostSheep_EN");
        }
        public static void Thunderdome()
        {
            AddTo med = new AddTo("H_Zone02_Thunderdome_Medium_EnemyBundle");
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", "Something_EN");
            med.AddRandomGroup("Thunderdome_EN", "Enigma_EN", "Scrungie_EN");
            med.AddRandomGroup("Thunderdome_EN", "Enigma_EN", "MusicMan_EN");
            med.AddRandomGroup("Thunderdome_EN", "Enigma_EN", "Something_EN");
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", "LostSheep_EN");

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", "Thunderdome_EN", "SilverSuckle_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            med.AddRandomGroup("Freud_EN", "Thunderdome_EN", "Enigma_EN");
            med.AddRandomGroup("Freud_EN", "Thunderdome_EN", Jumble.Purple);

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", "Thunderdome_EN", "LostSheep_EN");

            AddTo hard = new AddTo("Zone02_Revola_Hard_EnemyBundle");
            hard.AddRandomGroup("Revola_EN", "Thunderdome_EN", "LostSheep_EN");

            hard = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            hard.AddRandomGroup("Conductor_EN", "Thunderdome_EN", "Freud_EN");


        }
    }
}
