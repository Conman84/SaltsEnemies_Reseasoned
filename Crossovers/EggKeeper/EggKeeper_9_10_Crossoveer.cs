using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class EggKeeper_9_10_Crossover
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "EyePalm_EN", "EyePalm_EN", "EggKeeper_EN");
            med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Grandfather_EN", Flower.Red, "EggKeeper_EN", Enemies.Shivering);
            med.AddRandomGroup("Grandfather_EN", "Shua_EN", "EggKeeper_EN", Enemies.Shivering);
            med.AddRandomGroup("Grandfather_EN", "ChoirBoy_EN", "EggKeeper_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "InHisImage_EN", "InHerImage_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHisImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("MiniReaper_EN", Enemies.Shivering, "EyePalm_EN", "EggKeeper_EN");
            med.AddRandomGroup("MiniReaper_EN", "Grandfather_EN", "EggKeeper_EN", Flower.Blue);

            AddTo easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.AddRandomGroup("EyePalm_EN", "EyePalm_EN", "EggKeeper_EN", "EyePalm_EN");
        }
    }
}
