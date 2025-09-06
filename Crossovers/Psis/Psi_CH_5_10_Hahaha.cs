using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Psi_CH_5_10_Hahaha
    {
        public static void Add()
        {
            //HSORE
            AddTo easy = new AddTo(Shore.H.Mungman.Easy);
            easy.AddRandomGroup("Mungman_EN", "Mungman_EN", "Skyloft_EN");

            easy = new AddTo(Shore.H.Squirmer.Easy);
            easy.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "Skyloft_EN");

            AddTo med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "FlaMinGoa_EN", "Skyloft_EN");

            //orpheum
            med = new AddTo(Orph.H.Suckler.Med);
            med.AddRandomGroup("Suckler_EN", "Suckler_EN", "Delusion_EN", "Delusion_EN");
            med.AddRandomGroup("Suckler_EN", "Suckler_EN", "Spectre_EN", "Spectre_EN", "Spectre_EN");
            med.AddRandomGroup("Suckler_EN", "Suckler_EN", "Sigil_EN", "Delusion_EN");

            easy = new AddTo(Orph.H.Suckler.Easy);
            easy.AddRandomGroup("Suckler_EN", "Delusion_EN", "FakeAngel_EN");

            //GARDEN
            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", Flower.Red, Flower.Blue);
            med.SimpleAddGroup(1, "Beakart_EN", 3, "EyePalm_EN");
            med.AddRandomGroup("Beakart_EN", "Shua_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Beakart_EN", "MiniReaper_EN", Enemies.Shivering, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Beakart_EN", "MiniReaper_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("Beakart_EN", "Grandfather_EN", "ChoirBoy_EN");

            AddTo hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Beakart_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup("ClockTower_EN", "Beakart_EN", "Attrition_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Beakart_EN");
            hard.AddRandomGroup(Enemies.Tank, "Beakart_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "Beakart_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Beakart_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Beakart_EN", Flower.Purple, Flower.Blue);
            hard.AddRandomGroup("Miriam_EN", "Beakart_EN", "EyePalm_EN", "EyePalm_EN");
        }
    }
}
