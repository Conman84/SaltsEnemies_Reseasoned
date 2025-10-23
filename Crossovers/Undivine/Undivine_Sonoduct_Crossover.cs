using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Undivine_Sonoduct_Crossover
    {
        public static void Add()
        {
            AddTo hard = new AddTo(Orph.H.Sonoduct.Hard);
            if (SaltsReseasoned.rando == 1) hard.AddRandomGroup("Sonoduct_EN", "LostSheep_EN", "LostSheep_EN", "LostSheep_EN");
            
            if (SaltsReseasoned.trolling > 33 && SaltsReseasoned.trolling < 66) hard.AddRandomGroup("Sonoduct_EN", "Something_EN");
            if (SaltsReseasoned.trolling < 33) hard.AddRandomGroup("Sonoduct_EN", "TheCrow_EN");
            if (SaltsReseasoned.trolling > 66) hard.AddRandomGroup("Sonoduct_EN", "Freud_EN");

            if (SaltsReseasoned.rando == 2) hard.AddRandomGroup("Sonoduct_EN", Enemies.Camera, Enemies.Camera);

            if (SaltsReseasoned.silly < 25) hard.AddRandomGroup("Sonoduct_EN", "Delusion_EN", "Delusion_EN");
            if (SaltsReseasoned.silly > 25 && SaltsReseasoned.silly < 50) hard.AddRandomGroup("Sonoduct_EN", Flower.Yellow, Flower.Purple);
            if (SaltsReseasoned.silly > 50 && SaltsReseasoned.silly < 75) hard.AddRandomGroup("Sonoduct_EN", "Sigil_EN", "MusicMan_EN");
            if (SaltsReseasoned.silly > 75) hard.AddRandomGroup("Sonoduct_EN", "WindSong_EN", Enemies.Solvent);

            if (SaltsReseasoned.rando == 3) hard.AddRandomGroup("Sonoduct_EN", "Spectre_EN", "Spectre_EN", "Spectre_EN");

            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Sonoduct_EN", "Maw_EN");
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Sonoduct_EN", "Wednesday_EN", "Scrungie_EN");

            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Sonoduct_EN", Bots.Red, Bots.Yellow);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Sonoduct_EN", Bots.Blue, Bots.Purple);

            if (SaltsReseasoned.silly < 33 && Winter.Chance) hard.AddRandomGroup("Sonoduct_EN", "Crystal_EN", "LostSheep_EN");
            if (SaltsReseasoned.silly > 33 && SaltsReseasoned.silly < 66) hard.AddRandomGroup("Sonoduct_EN", "Evileye_EN", "LostSheep_EN");
            if (SaltsReseasoned.silly > 66) hard.AddRandomGroup("Sonoduct_EN", "YellowAngel_EN", "LostSheep_EN");

            if (SaltsReseasoned.trolling < 25) hard.AddRandomGroup("Sonoduct_EN", Enemies.Shooter, Enemies.Shooter);
            if (SaltsReseasoned.trolling > 25 && SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Sonoduct_EN", "Solitaire_EN", "Solitaire_EN");
            if (SaltsReseasoned.trolling > 50 && SaltsReseasoned.trolling < 75) hard.AddRandomGroup("Sonoduct_EN", "Author_EN", "Author_EN");
            if (SaltsReseasoned.trolling > 75) hard.AddRandomGroup("Sonoduct_EN", "Enigma_EN", "Enigma_EN");
        }
    }
}
