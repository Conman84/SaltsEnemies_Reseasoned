using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EggKeeper_17_18Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "EggKeeper_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "EggKeeper_EN", Flower.Red, Flower.Yellow);
            med.AddRandomGroup("PersonalAngel_EN", "EggKeeper_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("PersonalAngel_EN", "EggKeeper_EN", Enemies.Minister);
            med.AddRandomGroup("PersonalAngel_EN", "EggKeeper_EN", "BlackStar_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "EggKeeper_EN", "EggKeeper_EN");
            med.AddRandomGroup("Complimentary_EN", "EggKeeper_EN", "Firebird_EN");
            med.AddRandomGroup("Complimentary_EN", "EggKeeper_EN", Spoggle.Grey);

            AddTo hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "EggKeeper_EN", "EvilDog_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "EggKeeper_EN", "EvilDog_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "EggKeeper_EN", "PersonalAngel_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "EggKeeper_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "EggKeeper_EN", "Complimentary_EN");
        }
    }
}
