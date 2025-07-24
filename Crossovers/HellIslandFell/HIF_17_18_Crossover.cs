using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_17_18_Crossover
    {
        public static void AddGarden()
        {
            AddTo med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.SimpleAddGroup(1, Noses.Red, 3, "EvilDog_EN");

            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.SimpleAddGroup(1, Noses.Blue, 3, "EvilDog_EN");

            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.SimpleAddGroup(1, Noses.Yellow, 3, "EvilDog_EN");

            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.SimpleAddGroup(1, Noses.Purple, 3, "EvilDog_EN");

            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.SimpleAddGroup(1, Noses.Grey, 3, "EvilDog_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(1, Noses.Red, 3, "EvilDog_EN");
            med.SimpleAddGroup(1, Noses.Blue, 3, "EvilDog_EN");
            med.SimpleAddGroup(1, Noses.Yellow, 3, "EvilDog_EN");
            med.SimpleAddGroup(1, Noses.Purple, 3, "EvilDog_EN");
            med.SimpleAddGroup(1, Noses.Grey, 3, "EvilDog_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Firebird_EN", Noses.Yellow);
            med.AddRandomGroup("PersonalAngel_EN", Noses.Red, Bots.Grey);
            med.AddRandomGroup("PersonalAngel_EN", "Shua_EN", Noses.Purple);
            med.AddRandomGroup("PersonalAngel_EN", "ChoirBoy_EN", Noses.Red);

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", Noses.Red, "Children6_EN");
        }
    }
}
