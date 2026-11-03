using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Eggkeeper26
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "EggKeeper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Eclipse, "EggKeeper_EN", "ChoirBoy_EN");

            AddTo hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.AddRandomGroup(Enemies.Eclipse, Enemies.Eclipse, "EggKeeper_EN");
            hard.AddRandomGroup(Enemies.Eclipse, "EggKeeper_EN", Enemies.Minister);
            hard.AddRandomGroup(Enemies.Eclipse, "EggKeeper_EN", "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, "EggKeeper_EN");
            med.AddRandomGroup("Celebration_EN", "EggKeeper_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Celebration_EN", "Lightbulbkin_EN", "EggKeeper_EN");
            med.AddRandomGroup("Celebration_EN", "EggKeeper_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 2, "EggKeeper_EN");
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", "EggKeeper_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", "EggKeeper_EN", "ChoirBoy_EN");

            AddTo easy = new AddTo(Garden.H.Lightbulbkin.Easy);
            easy.AddRandomGroup("Lightbulbkin_EN", Enemies.Shivering, "EggKeeper_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "InHisImage_EN", "InHisImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Lightbulbkin_EN", "EggKeeper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Lightbulbkin_EN", "EggKeeper_EN", "Lightbulbkin_EN", "Damocles_EN");
        }
    }
}
