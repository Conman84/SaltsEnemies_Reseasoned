using System;
using System.Collections.Generic;
using System.Text;

//Call RoundCrossovers.Shufflers_1_4() in postloading

namespace SaltsEnemies_Reseasoned
{
    public static class RoundCrossovers
    {
        public static void Shufflers_1_4()
        {
            string shuffler = "Shawled_Shuffler_EN";

            AddTo easy = new AddTo("RR_Zone02_Shawled_Shuffler_Easy_EnemyBundle");
            easy.AddRandomGroup(shuffler, "Enigma_EN");
            easy.AddRandomGroup(shuffler, "Enigma_EN", "Enigma_EN");
            easy.AddRandomGroup(shuffler, "MusicMan_EN", "LostSheep_EN");

            AddTo med = new AddTo("RR_Zone02_Shawled_Shuffler_Medium_EnemyBundle");
            med.AddRandomGroup(shuffler, "Enigma_EN", "Enigma_EN", "LostSheep_EN");
            med.AddRandomGroup(shuffler, shuffler, "LostSheep_EN");
            med.AddRandomGroup(shuffler, "Something_EN", "LostSheep_EN");
            med.AddRandomGroup(shuffler, shuffler, "MechanicalLens_EN");

            med = new AddTo("H_Zone02_Something_Medium_EnemyBundle");
            med.AddRandomGroup("Something_EN", shuffler, "Enigma_EN");
            med.AddRandomGroup("Something_EN", shuffler, "LostSheep_EN");

            med = new AddTo("H_Zone02_Crow_Medium_EnemyBundle");
            med.AddRandomGroup("TheCrow_EN", shuffler, "SingingStone_EN");
            med.AddRandomGroup("TheCrow_EN", shuffler, "MusicMan_EN");
            med.AddRandomGroup("TheCrow_EN", shuffler, "Enigma_EN");

            med = new AddTo("H_Zone02_Freud_Medium_EnemyBundle");
            med.AddRandomGroup("Freud_EN", shuffler, Jumble.Yellow);

            med = new AddTo("H_Zone02_Conductor_Medium_EnemyBundle");
            med.AddRandomGroup("Conductor_EN", shuffler, "LostSheep_EN");

            AddTo hard = new AddTo("H_Zone02_Conductor_Hard_EnemyBundle");
            hard.AddRandomGroup("Conductor_EN", shuffler, "Something_EN");

            hard = new AddTo("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle");
            hard.AddRandomGroup("WrigglingSacrifice_EN", shuffler, "Enigma_EN");
        }
    }
}
