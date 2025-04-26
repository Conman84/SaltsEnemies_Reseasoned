using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Marmo_Grey_Crossovers
    {
        public static void Add()
        {
            Unstable();
        }
        public static void Unstable()
        {
            AddTo easy = new AddTo("Marmo_Zone02_Digital_JumbleGuts_Easy");
            easy.AddRandomGroup(Jumble.Unstable, Jumble.Yellow, "LostSheep_EN");

            easy = new AddTo("Marmo_Zone02_Mechanical_Spoggle_Easy");
            if (SaltsReseasoned.silly < 50) easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Blue, "LostSheep_EN");
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Yellow, "LostSheep_EN");

            AddTo med = new AddTo("H_Zone01_DeadPixel_Medium_EnemyBundle");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", Jumble.Unstable, "LostSheep_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", Spoggle.Unstable, "LostSheep_EN");

            AddTo hard = new AddTo("H_Zone01_AFlower_Hard_EnemyBundle");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("AFlower_EN", Jumble.Unstable, Jumble.Yellow);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("AFlower_EN", Jumble.Unstable, "MunglingMudLung_EN");
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("AFlower_EN", Spoggle.Blue, Spoggle.Unstable);
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("AFlower_EN", Spoggle.Yellow, Spoggle.Unstable);

            hard = new AddTo("H_Zone01_MechanicalLens_Hard_EnemyBundle");
            hard.AddRandomGroup("MechanicalLens_EN", Jumble.Yellow, Jumble.Red, Jumble.Unstable);

            easy = new AddTo("H_Zone02_Something_Easy_EnemyBundle");
            easy.AddRandomGroup("Something_EN", Jumble.Unstable, Jumble.Yellow);

            med = new AddTo("H_Zone02_Enigma_Medium_EnemyBundle");
            med.AddRandomGroup("Enigma_EN", "Enigma_EN", "Enigma_EN", Jumble.Unstable);
            med.AddRandomGroup("Enigma_EN", "Enigma_EN", "LostSheep_EN", Spoggle.Unstable);

            med = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            med.AddRandomGroup("Something_EN", Spoggle.Unstable, Spoggle.Purple);

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", Jumble.Unstable, Jumble.Purple);
            med.AddRandomGroup("TheCrow_EN", Spoggle.Unstable, "Surrogate_EN");

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", Jumble.Unstable, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Freud_EN", Spoggle.Unstable, Spoggle.Red);

            med = new AddTo("H_Zone02_MechanicalLens_Medium_EnemyBundle");
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", Jumble.Unstable, "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("MechanicalLens_EN", "MechanicalLens_EN", Spoggle.Unstable, Spoggle.Red);

            med = new AddTo("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle");
            med.AddRandomGroup(Jumble.Yellow, Jumble.Unstable, Jumble.Red, "LostSheep_EN");

            hard = new AddTo("H_Zone01_FlaMingGoa_Hard_EnemyBundle");
            hard.AddRandomGroup("FlaMinGoa_EN", Jumble.Unstable, "AFlower_EN");

            easy = new AddTo("H_Zone01_MunglingMudLung_Easy_EnemyBundle");
            easy.AddRandomGroup("MunglingMudLung_EN", Jumble.Unstable, "LostSheep_EN");

            med = new AddTo("H_Zone02_Scrungie_Medium_EnemyBundle");
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Jumble.Unstable, "LostSheep_EN");

            med = new AddTo("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle");
            med.AddRandomGroup(Jumble.Blue, Jumble.Unstable, "LostSheep_EN");

            med = new AddTo("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle");
            med.AddRandomGroup(Jumble.Purple, Jumble.Unstable, "LostSheep_EN");

            med = new AddTo("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle");
            med.AddRandomGroup(Spoggle.Purple, Spoggle.Unstable, "LostSheep_EN");

            med = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            med.AddRandomGroup("Conductor_EN", Spoggle.Unstable, "LostSheep_EN");

            hard = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            hard.AddRandomGroup("Conductor_EN", "Freud_EN", Jumble.Unstable);
            hard.AddRandomGroup("Conductor_EN", "TheCrow_EN", Spoggle.Unstable);
            hard.AddRandomGroup("Conductor_EN", "Something_EN", Spoggle.Unstable);

            hard = new AddTo("H_Zone02_Revola_Hard_EnemyBundle");
            hard.AddRandomGroup("Revola_EN", Spoggle.Unstable, "LostSheep_EN");
        }
    }
}
