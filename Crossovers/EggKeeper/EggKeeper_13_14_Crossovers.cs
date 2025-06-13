using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EggKeeper_13_14_Crossovers
    {
        public static void Add()
        {
            Add_13();
            Add_14();
        }
        public static void Add_13()
        {
            AddTo easy = new AddTo(Garden.H.BlackStar.Easy);
            easy.AddRandomGroup("BlackStar_EN", "EggKeeper_EN", "NextOfKin_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("BlackStar_EN", "EggKeeper_EN", "ChoirBoy_EN");

            AddTo med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("EggKeeper_EN", "ChoirBoy_EN", "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "EggKeeper_EN");
            med.SimpleAddGroup(1, "Indicator_EN", 2, "EyePalm_EN", 1, "EggKeeper_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(2, "InHisImage_EN", 1, "EggKeeper_EN", 1, "Indicator_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "EggKeeper_EN", "BlackStar_EN", "WindSong_EN");

            easy = new AddTo(Garden.H.WindSong.Easy);
            easy.AddRandomGroup("WindSong_EN", "BlackStar_EN", "EggKeeper_EN");
        }
        public static void Add_14()
        {
            AddTo med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "EggKeeper_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("YNL_EN", "Firebird_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup("YNL_EN", Enemies.Minister, "EggKeeper_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup("YNL_EN", "EggKeeper_EN", Flower.Red);

            med = new AddTo(Garden.H.Tank.Hard);
            med.AddRandomGroup(Enemies.Tank, "YNL_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "YNL_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "BlackStar_EN");
            med.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "WindSong_EN");
            med.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "MiniReaper_EN");
            med.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "Hunter_EN");

            AddTo hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "InHisImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", Enemies.Minister);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Stoplight_EN", "EggKeeper_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", "EggKeeper_EN");

            AddTo easy = new AddTo(Garden.H.ChoirBoy.Easy);
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup("ChoirBoy_EN", "EggKeeper_EN", "Children6_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "EggKeeper_EN", Enemies.Shivering, "Children6_EN");

            med = new AddTo(Garden.H.Minister.Easy);
            easy.AddRandomGroup(Enemies.Minister, "EggKeeper_EN", "Children6_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "EggKeeper_EN", "Children6_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, "EggKeeper_EN", "Children6_EN");
        }
    }
}
