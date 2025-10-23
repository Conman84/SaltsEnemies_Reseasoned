using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_17_18_Crossover
    {
        public static void AddShore()
        {
            AddTo med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Draugr_EN", Jumble.Yellow);
            med.AddRandomGroup("ToyUfo_EN", "Draugr_EN", "Mungman_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Draugr_EN", "Pinano_EN");
            med.AddRandomGroup("Sinker_EN", "Draugr_EN", "NobodyGrave_EN");
        }
        public static void AddOrph()
        {
            //moone, heehoo, thunderdome
            AddTo med = new AddTo(Orph.H.Moone.Med);
            med.AddRandomGroup("Moone_EN", "Moone_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Moone_EN", "Moone_EN");
            med.AddRandomGroup("Evileye_EN", "Thunderdome_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "Moone_EN");

            AddTo easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, "Moone_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Moone_EN", "Moone_EN", Enemies.Suckle);
            med.AddRandomGroup("YellowAngel_EN", "Thunderdome_EN", "Something_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Evileye_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Heehoo_EN", "YellowAngel_EN", "SingingStone_EN", "SingingStone_EN", "SingingStone_EN");
            if (Winter.Chance) med.AddRandomGroup("Heehoo_EN", "Crystal_EN", "SingingStone_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomGroup("Heehoo_EN", Enemies.Shooter, Enemies.Shooter);

            AddTo hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "Evileye_EN", Bots.Yellow);
            hard.AddRandomGroup("Heehoo_EN", "YellowAngel_EN", "Scrungie_EN");
        }
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
            med.AddRandomGroup("Complimentary_EN", Noses.Blue, "Merced_EN");
            med.AddRandomGroup("Complimentary_EN", Noses.Yellow, "PawnA_EN");
            med.AddRandomGroup("Complimentary_EN", Noses.Purple, "EyePalm_EN");
            med.AddRandomGroup("Complimentary_EN", Noses.Grey, "BlackStar_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "EvilDog_EN", "EvilDog_EN", Noses.Blue);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "PersonalAngel_EN", Noses.Purple);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Complimentary_EN", Noses.Red);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "EvilDog_EN", "EvilDog_EN", Noses.Red);
        }
    }
}
