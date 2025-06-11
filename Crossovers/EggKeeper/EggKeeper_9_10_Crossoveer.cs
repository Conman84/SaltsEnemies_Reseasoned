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
        }
    }
}
