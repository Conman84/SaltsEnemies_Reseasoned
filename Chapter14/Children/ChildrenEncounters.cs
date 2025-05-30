using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ChildrenEncounters
    {
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "InHisImage_EN", "InHisImage_EN", "Children6_EN");
            med.AddRandomGroup(Jumble.Grey, Enemies.Minister, Enemies.Minister, "Children6_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHisImage_EN", "Children6_EN");
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHerImage_EN", "NextOfKin_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "InHerImage_EN", "InHerImage_EN", "Children6_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Skinning, "ChoirBoy_EN", "Children6_EN");

            AddTo easy = new AddTo(Garden.H.Flower.Blue.Easy);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup(Flower.Blue, Flower.Red, "Children6_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "InHisImage_EN", "InHisImage_EN", "Children6_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Flower.Red, Flower.Blue, "Children6_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "InHerImage_EN", "InHerImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "InHisImage_EN", "InHerImage_EN", "Children6_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Enemies.Minister, "WindSong_EN", "Children6_EN");

            med = new AddTo(Garden.H.Camera.Med);
            med.SimpleAddGroup(4, Enemies.Camera, 1, "Children6_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Skinning, "Children6_EN");

            easy = new AddTo(Garden.H.WindSong.Easy);
            easy.AddRandomGroup("WindSong_EN", "EyePalm_EN", "EyePalm_EN", "Children6_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "Children6_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.SimpleAddGroup(3, "EyePalm_EN", 1, "Children6_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(4, "EyePalm_EN", 1, "Children6_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "WindSong_EN", "Children6_EN");

            easy = new AddTo(Garden.H.Merced.Easy);
            easy.SimpleAddGroup(1, "Merced_EN", 4, "Children6_EN");

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "EyePalm_EN", "EyePalm_EN", "Children6_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "InHerImage_EN", "InHerImage_EN", "Children6_EN");

            easy = new AddTo(Garden.H.GlassFigurine.Easy);
            easy.AddRandomGroup("GlassFigurine_EN", "InHerImage_EN", "InHerImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "InHisImage_EN", "InHisImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Enemies.Minister, Enemies.Minister, "Children6_EN");

            easy = new AddTo(Garden.H.BlackStar.Easy);
            easy.AddRandomGroup("BlackStar_EN", "BlackStar_EN", "NextOfKin_EN", "Children6_EN");

            easy = new AddTo(Garden.H.Indicator.Easy);
            easy.AddRandomGroup("Indicator_EN", Enemies.Shivering, Enemies.Shivering, "Children6_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "ChoirBoy_EN", "Children6_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.SimpleAddGroup(1, "Stoplight_EN", 3, "InHerImage_EN", 1, "Children6_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "WindSong_EN", Enemies.Minister, "Children6_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "Children6_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "Children6_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(3, "InHerImage_EN", 1, "Children6_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 1, "Children6_EN");

            med = new AddTo(Garden.H.Shivering.Med);
            if (SaltsReseasoned.trolling == 1) med.SimpleAddGroup(4, Enemies.Shivering, 1, "Children6_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Shua_EN", "Children6_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "EyePalm_EN", "Children6_EN");

            easy = new AddTo(Garden.H.Minister.Easy);
            easy.AddRandomGroup(Enemies.Minister, "BlackStar_EN", "Children6_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Children6_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "LittleAngel_EN", "Firebird_EN", "Children6_EN");


        }
    }
}
