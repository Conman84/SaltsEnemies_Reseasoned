using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GlitchCrossovers_1_4
    {
        public static void Add()
        {
            Bait();
            Flakkid();
            Swine();
            Pipe();
            Dancer();
            Frostbite();
        }
        public static void Bait()
        {
            AddTo med = new AddTo("BaitMed");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("DryBait_EN", "DeadPixel_EN", "DeadPixel_EN", Jumble.Red);
            med.AddRandomGroup("DryBait_EN", "DeadPixel_EN", "DeadPixel_EN", "MudLung_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("DryBait_EN", "DeadPixel_EN", "DeadPixel_EN", "MunglingMudLung_EN");

            med = new AddTo("H_Zone01_AFlower_Medium_EnemyBundle");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("AFlower_EN", "DryBait_EN", Spoggle.Blue);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("AFlower_EN", "DryBait_EN", Spoggle.Yellow);
            med.AddRandomGroup("AFlower_EN", "DryBait_EN", "MunglingMudLung_EN");

            AddTo hard = new AddTo("H_Zone01_AFlower_Hard_EnemyBundle");
            hard.AddRandomGroup("AFlower_EN", "DryBait_EN", "FlaMinGoa_EN");

            hard = new AddTo("H_Zone01_Flarb_Hard_EnemyBundle");
            hard.AddRandomGroup("Flarb_EN", "DryBait_EN", "MechanicalLens_EN");

            hard = new AddTo("H_Zone01_FlaMingGoa_Hard_EnemyBundle");
            hard.AddRandomGroup("FlaMinGoa_EN", "DryBait_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("FlaMinGoa_EN", "DryBait_EN", "AFlower_EN");
        }
        public static void Flakkid()
        {
            AddTo easy = new AddTo("FlakkidEasy");
            easy.AddRandomGroup("Flakkid_EN", "MudLung_EN", "LostSheep_EN");

            AddTo med = new AddTo("FlakkidMed");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Flakkid_EN", Jumble.Yellow, "LostSheep_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Flakkid_EN", Jumble.Red, "LostSheep_EN");

            med = new AddTo("H_Zone01_DeadPixel_Medium_EnemyBundle");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Flakkid_EN");

            med = new AddTo("H_Zone01_AFlower_Medium_EnemyBundle");
            med.AddRandomGroup("AFlower_EN", "Flakkid_EN", "LostSheep_EN");

            AddTo hard = new AddTo("H_Zone01_AFlower_Hard_EnemyBundle");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("AFlower_EN", "Flakkid_EN", Spoggle.Yellow);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("AFlower_EN", "Flakkid_EN", Spoggle.Blue);
        }
        public static void Swine()
        {
            AddTo easy = new AddTo("SwineEasy");
            easy.AddRandomGroup("UnculturedSwine_EN", "UnculturedSwine_EN", "LostSheep_EN");
            easy.AddRandomGroup("UnculturedSwine_EN", "MudLung_EN", "LostSheep_EN");

            AddTo med = new AddTo("SwineMed");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("UnculturedSwine_EN", Spoggle.Blue, "LostSheep_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("UnculturedSwine_EN", Spoggle.Yellow, "LostSheep_EN");

            med = new AddTo("H_Zone01_DeadPixel_Medium_EnemyBundle");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "UnculturedSwine_EN");

            med = new AddTo("H_Zone01_AFlower_Medium_EnemyBundle");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("AFlower_EN", "UnculturedSwine_EN", Jumble.Yellow);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("AFlower_EN", "UnculturedSwine_EN", Jumble.Red);
        }
        public static void Pipe()
        {
            AddTo med = new AddTo("PipeMed");
            med.AddRandomGroup("NotAn_EN", "MunglingMudLung_EN", "LostSheep_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("NotAn_EN", Jumble.Red, "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("NotAn_EN", "AFlower_EN", "MudLung_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("NotAn_EN", "AFlower_EN", Jumble.Yellow);

            med = new AddTo("H_Zone01_AFlower_Medium_EnemyBundle");
            med.AddRandomGroup("AFlower_EN", "NotAn_EN", "MudLung_EN");
            med.AddRandomGroup("AFlower_EN", "NotAn_EN", "LostSheep_EN");

            AddTo hard = new AddTo("H_Zone01_AFlower_Hard_EnemyBundle");
            hard.AddRandomGroup("AFlower_EN", "NotAn_EN", "MunglingMudLung_EN");

            hard = new AddTo("H_Zone01_MechanicalLens_Hard_EnemyBundle");
            hard.AddRandomGroup("MechanicalLens_EN", "NotAn_EN", "MudLung_EN", "LostSheep_EN");

            med = new AddTo("H_Zone01_FlaMingGoa_Medium_EnemyBundle");
            med.AddRandomGroup("FlaMinGoa_EN", "NotAn_EN", "LostSheep_EN");

            hard = new AddTo("H_Zone01_FlaMingGoa_Hard_EnemyBundle");
            hard.AddRandomGroup("FlaMinGoa_EN", "NotAn_EN", "AFlower_EN");
        }
        public static void Dancer()
        {
            AddTo easy = new AddTo("BDancerEasy");
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup("MusicMan_EN", "BackupDancer_EN", "LostSheep_EN");
            if (SaltsReseasoned.silly < 50) easy.AddRandomGroup("MusicMan_EN", "BackupDancer_EN", "Enigma_EN");
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "Enigma_EN");
            if (SaltsReseasoned.silly < 50) easy.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "LostSheep_EN");

            AddTo med = new AddTo("BDancerMed");
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("BackupDancer_EN", "MusicMan_EN", "MusicMan_EN", "LostSheep_EN");
            med.AddRandomGroup("BackupDancer_EN", "MusicMan_EN", "MusicMan_EN", "Enigma_EN");

            med = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            med.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", "BackupDancer_EN");

            easy = new AddTo("H_Zone02_Something_Easy_EnemyBundle");
            easy.AddRandomGroup("Something_EN", "BackupDancer_EN", "LostSheep_EN");

            med = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Something_EN", "BackupDancer_EN", Jumble.Blue);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Something_EN", "BackupDancer_EN", Jumble.Purple);

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", "Scrungie_EN", "BackupDancer_EN");
            med.AddRandomGroup("TheCrow_EN", "BackupDancer_EN", "Enigma_EN");

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", "MusicMan_EN", "BackupDancer_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Freud_EN", "BackupDancer_EN", Spoggle.Purple);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Freud_EN", "BackupDancer_EN", Spoggle.Red);
            med.AddRandomGroup("Freud_EN", "BackupDancer_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "BackupDancer_EN", "BackupDancer_EN");

            med = new AddTo("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup(Jumble.Blue, "BackupDancer_EN", "Enigma_EN");

            med = new AddTo("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup(Jumble.Purple, "BackupDancer_EN", "Enigma_EN");

            med = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            med.AddRandomGroup("Conductor_EN", "BackupDancer_EN", "LostSheep_EN");

            AddTo hard = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Conductor_EN", "TheCrow_EN", "BackupDancer_EN");
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Conductor_EN", "Freud_EN", "BackupDancer_EN");
        }
        public static void Frostbite()
        {
            AddTo easy = new AddTo("FrostbiteEasy");
            easy.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "Enigma_EN");
            easy.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "LostSheep_EN");

            AddTo med = new AddTo("FrostbiteMed");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "Frostbite_EN", "LostSheep_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "Frostbite_EN", "Enigma_EN");

            easy = new AddTo("H_Zone02_Enigma_Easy_EnemyBundle");
            easy.AddRandomGroup("Enigma_EN", "Enigma_EN", "Frostbite_EN");

            easy = new AddTo("H_Zone02_DeadPixel_Easy_EnemyBundle");
            easy.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Frostbite_EN");

            med = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            med.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", "Frostbite_EN");
            med.AddRandomGroup("Enigma_EN", "Enigma_EN", "Frostbite_EN", "Frostbite_EN");

            easy = new AddTo("H_Zone02_Something_Easy_EnemyBundle");
            easy.AddRandomGroup("Something_EN", "Frostbite_EN");
            easy.AddRandomGroup("Something_EN", "Frostbite_EN", "LostSheep_EN");

            med = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            med.AddRandomGroup("Something_EN", "Frostbite_EN", "Frostbite_EN");
            med.AddRandomGroup("Something_EN", "Frostbite_EN", "MusicMan_EN");

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", "Frostbite_EN", "Frostbite_EN");
            med.AddRandomGroup("TheCrow_EN", "Frostbite_EN", "Frostbite_EN", "Frostbite_EN");
            med.AddRandomGroup("TheCrow_EN", "Frostbite_EN", "Enigma_EN", "SilverSuckle_EN", "SilverSuckle_EN");

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", "Frostbite_EN", "Frostbite_EN");
            med.AddRandomGroup("Freud_EN", "Frostbite_EN", Jumble.Blue);
            med.AddRandomGroup("Freud_EN", "Frostbite_EN", "Scrungie_EN");

            med = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "Frostbite_EN", "Frostbite_EN");
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", "Frostbite_EN", Jumble.Purple);

            AddTo hard = new AddTo("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle");
            hard.AddRandomGroup("WrigglingSacrifice_EN", "Frostbite_EN", "Enigma_EN", "Enigma_EN");

            hard = new AddTo("H_Zone02_Revola_Hard_EnemyBundle");
            hard.AddRandomGroup("Revola_EN", "Frostbite_EN", "LostSheep_EN");

            med = new AddTo("H_Zone02_Scrungie_Medium_EnemyBundle");
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Frostbite_EN", "LostSheep_EN");
        }
    }
}
