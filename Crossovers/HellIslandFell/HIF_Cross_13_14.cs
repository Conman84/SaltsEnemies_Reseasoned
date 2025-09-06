using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_Cross_13_14
    {
        public static void NoseStoneStuff()
        {
            AddTo med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Noses.Red);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Noses.Blue);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Noses.Yellow);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Noses.Purple);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Noses.Grey);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "EyePalm_EN", "EyePalm_EN", Noses.Red);
            med.AddRandomGroup("YNL_EN", "EyePalm_EN", "EyePalm_EN", Noses.Blue);
            med.AddRandomGroup("YNL_EN", "EyePalm_EN", "EyePalm_EN", Noses.Yellow);
            med.AddRandomGroup("YNL_EN", "EyePalm_EN", "EyePalm_EN", Noses.Purple);
            med.AddRandomGroup("YNL_EN", "EyePalm_EN", "EyePalm_EN", Noses.Gray);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", Noses.Red);
            med.AddRandomGroup("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", Noses.Blue);
            med.AddRandomGroup("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", Noses.Yellow);
            med.AddRandomGroup("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", Noses.Purple);
            med.AddRandomGroup("Stoplight_EN", "EyePalm_EN", "EyePalm_EN", Noses.Gray);
            med.AddRandomGroup("Stoplight_EN", "Shua_EN", Noses.Red);
            med.AddRandomGroup("Stoplight_EN", "EvilDog_EN", "EvilDog_EN", Noses.Blue);
            med.AddRandomGroup("Stoplight_EN", "Firebird_EN", Noses.Yellow);
            med.AddRandomGroup("Stoplight_EN", "MiniReaper_EN", Noses.Purple);
            med.AddRandomGroup("Stoplight_EN", "Hunter_EN", Noses.Grey);

            AddTo hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Noses.Red, Noses.Yellow);
            hard.AddRandomGroup("Stoplight_EN", Noses.Blue, Noses.Grey);
            hard.AddRandomGroup("Stoplight_EN", Noses.Purple, Noses.Red);
            hard.AddRandomGroup("Stoplight_EN", "ChoirBoy_EN", Noses.Red);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Minister, Noses.Blue);
            hard.AddRandomGroup("Stoplight_EN", "InHisImage_EN", "InHisImage_EN", Noses.Yellow);
            hard.AddRandomGroup("Stoplight_EN", "BlackStar_EN", "BlackStar_EN", Noses.Purple);
            hard.AddRandomGroup("Stoplight_EN", Noses.Grey, "MiniReaper_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.AddRandomGroup(Noses.Red, "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.AddRandomGroup(Noses.Blue, "EyePalm_EN", "EyePalm_EN", "Indicator_EN");

            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.AddRandomGroup(Noses.Yellow, "InHisImage_EN", "InHerImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.AddRandomGroup(Noses.Purple, "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.AddRandomGroup(Noses.Grey, "Indicator_EN", Enemies.Shivering, Enemies.Shivering);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", Noses.Yellow);
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", Noses.Red);
        }

        public static void EverythingElse()
        {
            //SHORE!!s
            AddTo easy = new AddTo(Shore.H.Draugr.Easy);
            easy.AddRandomGroup("Draugr_EN", "Pinano_EN");

            easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Draugr_EN", "Pinano_EN", "Minana_EN");

            AddTo med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Draugr_EN");

            AddTo hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Draugr_EN", Jumble.Red, Jumble.Yellow);
            hard.AddRandomGroup("Clione_EN", "Draugr_EN", "DeadPixel_EN", "DeadPixel_EN");

            //orpheum
            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Moone_EN", "Moone_EN");
            med.AddRandomGroup("Maw_EN", "Moone_EN", Jumble.Purple);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Thunderdome_EN", "Thunderdome_EN");
            hard.AddRandomGroup("Maw_EN", "Heehoo_EN", Flower.Yellow);
        }
    }
}
