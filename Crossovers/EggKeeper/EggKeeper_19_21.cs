using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EggKeeper_19_21
    {
        public static void Crossover()
        {
            AddTo easy = new AddTo(Garden.H.Pawn.Easy);
            easy.SimpleAddGroup(2, "PawnA_EN", 1, "EggKeeper_EN");

            AddTo med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, "EggKeeper_EN");
            med.AddRandomGroup("PawnA_EN", "PawnA_EN", "EggKeeper_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "InHisImage_EN", "InHerImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Starless_EN", "InHerImage_EN", "InHerImage_EN", "EggKeeper_EN");
            med.AddRandomGroup("Starless_EN", Bots.Grey, "EggKeeper_EN", "EggKeeper_EN");
            med.AddRandomGroup("Starless_EN", "Firebird_EN", "MiniReaper_EN", "EggKeeper_EN");
            med.AddRandomGroup("Starless_EN", "Shua_EN", "EggKeeper_EN", "EggKeeper_EN");
            med.AddRandomGroup("Starless_EN", Flower.Red, Flower.Blue, "EggKeeper_EN");
            med.AddRandomGroup("Starless_EN", "EyePalm_EN", "EyePalm_EN", "EggKeeper_EN");

            AddTo hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "InHisImage_EN", "InHerImage_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Eyeless_EN", "ChoirBoy_EN", "ChoirBoy_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "LittleAngel_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Eyeless_EN", "Yang_EN", "Yang_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Eyeless_EN", "Shua_EN", "MiniReaper_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", "EggKeeper_EN");
            med.AddRandomGroup("Yang_EN", "ChoirBoy_EN", "EggKeeper_EN");
            med.AddRandomGroup("Yang_EN", "EyePalm_EN", "EyePalm_EN", "EggKeeper_EN");
            med.AddRandomGroup("Yang_EN", "PawnA_EN", "PawnA_EN", "EggKeeper_EN");
            med.AddRandomGroup("Yang_EN", "Yang_EN", "EggKeeper_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, "EggKeeper_EN");
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "ChoirBoy_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "Starless_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "PawnA_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Yang_EN", "InHisImage_EN", "InHisImage_EN", "EggKeeper_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Hunter_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Yang_EN", "Yin_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Yin_EN", "Eyeless_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Yin_EN", "ChoirBoy_EN", "EggKeeper_EN");


            med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("EggKeeper_EN", "ChoirBoy_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("EggKeeper_EN", "ChoirBoy_EN", "ChoirBoy_EN", "PawnA_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("EggKeeper_EN", "ChoirBoy_EN", "PawnA_EN");


            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "PawnA_EN", "PawnA_EN", "EggKeeper_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Yang_EN", "EggKeeper_EN");
            hard.AddRandomGroup("Satyr_EN", "Starless_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "EggKeeper_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "EggKeeper_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "EggKeeper_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("Starless_EN", "Eyeless_EN", "ClockTower_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "EggKeeper_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "Yang_EN", "EggKeeper_EN");
            hard.AddRandomGroup(Flower.Grey, "Eyeless_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "EggKeeper_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "EggKeeper_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "Yang_EN", "PawnA_EN");
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "Starless_EN");
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "Eyeless_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "EggKeeper_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "EggKeeper_EN", "Yang_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "EggKeeper_EN", "Yang_EN");
            med.AddRandomGroup("PersonalAngel_EN", "PawnA_EN", "PawnA_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "PawnA_EN", "EggKeeper_EN");
            med.AddRandomGroup("Complimentary_EN", "Yang_EN", "EggKeeper_EN");
        }
    }
}
