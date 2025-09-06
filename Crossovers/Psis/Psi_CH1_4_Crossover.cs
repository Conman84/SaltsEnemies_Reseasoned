using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Psi_CH1_4_Crossover
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Shore.H.Mungman.Easy);
            easy.AddRandomGroup("Mungman_EN", "MudLung_EN", "LostSheep_EN");

            AddTo med = new AddTo(Shore.H.Mungman.Med);
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "MudLung_EN", "LostSheep_EN");
            med.AddRandomGroup("Mungman_EN", "DeadPixel_EN", "DeadPixel_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "MudLung_EN", "MudLung_EN", "LostSheep_EN");
            med.AddRandomGroup("Digger_EN", "DeadPixel_EN", "DeadPixel_EN");

            easy = new AddTo(Shore.H.Squirmer.Easy);
            easy.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Squirmer.Med);
            med.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "DeadPixel_EN", "DeadPixel_EN", "ShoreRock_EN");
            med.AddRandomGroup("Wailer_EN", Jumble.Red, Jumble.Yellow, "LostSheep_EN");
            med.AddRandomGroup("Wailer_EN", "AFlower_EN", "ShoreRock_EN");

            AddTo hard = new AddTo(Shore.H.Wailer.Hard);
            hard.AddRandomGroup("Wailer_EN", "AFlower_EN", Jumble.Yellow);
            hard.AddRandomGroup("Wailer_EN", "AFlower_EN", Jumble.Red);

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Mungman_EN", "MudLung_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Squirmer_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Mungman_EN", "Mungman_EN");
            med.AddRandomGroup("AFlower_EN", "Squirmer_EN", "Squirmer_EN");
            med.AddRandomGroup("AFlower_EN", "Digger_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Digger_EN", "Digger_EN");
            hard.AddRandomGroup("AFlower_EN", "Mungman_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("AFlower_EN", "Squirmer_EN", Jumble.Yellow, Jumble.Red);

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup("TeachaMantoFish_EN", "Mungman_EN");
            hard.AddRandomGroup("TeachaMantoFish_EN", "Squirmer_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Mungman_EN", "Mungman_EN", "Mungman_EN");
            hard.AddRandomGroup(Enemies.Camera, "Digger_EN", Enemies.Mungling);

            easy = new AddTo(Orph.H.Suckler.Easy);
            easy.AddRandomGroup("Suckler_EN", "Enigma_EN", "Enigma_EN");
            easy.AddRandomGroup("Suckler_EN", "Suckler_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Suckler.Med);
            med.SimpleAddGroup(1, "Suckler_EN", 3, "Enigma_EN");
            med.SimpleAddGroup(2, "Suckler_EN", 2, "Enigma_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Suckler_EN", "Suckler_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "InHisImage_EN", "InHisImage_EN", "LittleAngel_EN");
            med.AddRandomGroup("Beakart_EN", Enemies.Minister, Spoggle.Grey);
            med.AddRandomGroup("Beakart_EN", "InHerImage_EN", "InHisImage_EN", Jumble.Grey);

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Beakart_EN", Enemies.Shivering, Enemies.Shivering);

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Beakart_EN", "InHerImage_EN", "InHerImage_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Satyr_EN", "Beakart_EN");
        }
    }
}
