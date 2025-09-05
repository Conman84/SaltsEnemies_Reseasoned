using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Nosestone_CH19_Crossover
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.SimpleAddGroup(1, Noses.Red, 3, "PawnA_EN");
            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.SimpleAddGroup(1, Noses.Blue, 3, "PawnA_EN");
            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.SimpleAddGroup(1, Noses.Yellow, 3, "PawnA_EN");
            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.SimpleAddGroup(1, Noses.Purple, 3, "PawnA_EN");
            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.SimpleAddGroup(1, Noses.Grey, 3, "PawnA_EN");

            AddTo hard = new AddTo(Garden.H.Nosestone.Red.Hard);
            hard.AddRandomGroup(Noses.Red, Noses.Yellow, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Purple, "PawnA_EN", "PawnA_EN");
            hard = new AddTo(Garden.H.Nosestone.Blue.Hard);
            hard.AddRandomGroup(Noses.Red, Noses.Blue, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Noses.Yellow, Noses.Blue, "PawnA_EN", "PawnA_EN");
            hard = new AddTo(Garden.H.Nosestone.Yellow.Hard);
            hard.AddRandomGroup(Noses.Purple, Noses.Yellow, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Noses.Yellow, Noses.Blue, "PawnA_EN", "PawnA_EN");
            hard = new AddTo(Garden.H.Nosestone.Purple.Hard);
            hard.AddRandomGroup(Noses.Purple, Noses.Red, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Noses.Purple, Noses.Blue, "PawnA_EN", "PawnA_EN");
            hard = new AddTo(Garden.H.Nosestone.Grey.Hard);
            hard.AddRandomGroup(Noses.Grey, Noses.Red, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Noses.Grey, Noses.Blue, "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", Noses.Blue, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Starless_EN", Noses.Red, "Firebird_EN");
            med.AddRandomGroup("Starless_EN", Noses.Red, "Shua_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", Noses.Red);
            hard.AddRandomGroup("Eyeless_EN", Noses.Red, Noses.Blue);
            hard.AddRandomGroup("Eyeless_EN", "EyePalm_EN", "EyePalm_EN", Noses.Grey);

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Noses.Red);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Noses.Purple);
            med.AddRandomGroup("Yang_EN", Noses.Blue, "EyePalm_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", Noses.Blue, Noses.Red, "PawnA_EN");
            hard.AddRandomGroup("Yang_EN", "Yang_EN", Noses.Red, Noses.Red);

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Noses.Grey);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Noses.Yellow);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Noses.Red);
        }
    }
}
