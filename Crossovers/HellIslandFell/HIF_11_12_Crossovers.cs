using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_11_12_Crossovers
    {
        public static void FarShore()
        {
            AddTo hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Draugr_EN", "FlaMinGoa_EN");

            AddTo med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Draugr_EN", Jumble.Yellow);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Draugr_EN", "Sinker_EN");
        }
        public static void Orpheum()
        {
            AddTo med = new AddTo(Orph.H.Moone.Med);
            med.AddRandomGroup("Moone_EN", "Moone_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Moone_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Heehoo_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", "Rabies_EN");
        }
        public static void TheGarden()
        {
            AddTo hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Noses.Red);
            hard.AddRandomGroup("SnakeGod_EN", Noses.Blue);
            hard.AddRandomGroup("SnakeGod_EN", Noses.Yellow);
            hard.AddRandomGroup("SnakeGod_EN", Noses.Purple);
            hard.AddRandomGroup("SnakeGod_EN", Noses.Grey);

            AddTo med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", Noses.Red, "Shua_EN");
            med.AddRandomGroup("Hunter_EN", Noses.Red, "Damocles_EN", "Damocles_EN");
            med.AddRandomGroup("Hunter_EN", Noses.Blue, "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Noses.Red, "ChoirBoy_EN");
            med.AddRandomGroup("Firebird_EN", Noses.Yellow, "EggKeeper_EN");
            med.AddRandomGroup("Firebird_EN", Noses.Blue, "EyePalm_EN", "EyePalm_EN");


            med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.AddRandomGroup(Noses.Red, "InHisImage_EN", "InHisImage_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.AddRandomGroup(Noses.Blue, "InHerImage_EN", "InHerImage_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.AddRandomGroup(Noses.Yellow, "InHisImage_EN", "InHisImage_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.AddRandomGroup(Noses.Purple, "InHisImage_EN", "InHisImage_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.AddRandomGroup(Noses.Grey, "InHisImage_EN", "InHisImage_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Nosestone.Red.Hard);
            hard.AddRandomGroup(Noses.Red, "Hunter_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Noses.Red, "Hunter_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Nosestone.Blue.Hard);
            hard.AddRandomGroup(Noses.Blue, "Firebird_EN", "Hunter_EN");

            hard = new AddTo(Garden.H.Nosestone.Yellow.Hard);
            hard.AddRandomGroup(Noses.Yellow, "InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Nosestone.Purple.Hard);
            hard.AddRandomGroup(Noses.Purple, Noses.Red, "Hunter_EN");

            hard = new AddTo(Garden.H.Nosestone.Grey.Hard);
            hard.AddRandomGroup(Noses.Grey, "InHisImage_EN", "InHerImage_EN", "GlassFigurine_EN");


            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Noses.Purple, "Hunter_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Noses.Red, Noses.Blue, "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Noses.Red, "Firebird_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Noses.Yellow, "Damocles_EN");
        }
    }
}
