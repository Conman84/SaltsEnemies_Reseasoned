using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class EggKeeperCrossover_11_12
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Firebird_EN", "Hunter_EN", "EggKeeper_EN");
            med.AddRandomGroup("Hunter_EN", "InHerImage_EN", "InHerImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Hunter_EN", "InHisImage_EN", "InHisImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Hunter_EN", "EggKeeper_EN", "Grandfather_EN", Flower.Blue);
            med.AddRandomGroup("Hunter_EN", "EggKeeper_EN", "EyePalm_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Hunter_EN", "EggKeeper_EN");
            med.AddRandomGroup("Firebird_EN", "InHerImage_EN", "InHerImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Firebird_EN", "Shua_EN", "EggKeeper_EN");
            med.AddRandomGroup("Firebird_EN", "ChoirBoy_EN", "EggKeeper_EN");

            AddTo hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "EggKeeper_EN");

            AddTo easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "EggKeeper_EN", "Damocles_EN");

            med = new AddTo(Garden.H.EggKeeper.Med);
            if (SaltsReseasoned.trolling < 25 || SaltsReseasoned.trolling > 75) med.AddRandomGroup("ChoirBoy_EN", "EggKeeper_EN", "GlassFigurine_EN");

        }
    }
}
