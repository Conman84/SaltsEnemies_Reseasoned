using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DamoclesEncounters
    {
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.SimpleAddGroup(1, Jumble.Grey, 3, Enemies.Shivering, 1, "Damocles_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.SimpleAddGroup(1, Spoggle.Grey, 2, "InHisImage_EN", 1, "Damocles_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Minister, "Damocles_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Skinning, "Damocles_EN", "Damocles_EN");

            AddTo easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, Flower.Red, "Damocles_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Flower.Purple, "Damocles_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, "Damocles_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Flower.Yellow, "Damocles_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Shua_EN", "InHerImage_EN", "InHerImage_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.SimpleAddGroup(1, Flower.Grey, 3, "InHisImage_EN", 1, "Damocles_EN");

            med = new AddTo(Garden.H.Camera.Med);
            med.SimpleAddGroup(4, Enemies.Camera, 1, "Damocles_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Skinning, "Damocles_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "Damocles_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "Damocles_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.SimpleAddGroup(3, "EyePalm_EN", 1, "Damocles_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "WindSong_EN", 1, "Damocles_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 3, "Damocles_EN");

            easy = new AddTo(Garden.H.Merced.Easy);
            easy.SimpleAddGroup(1, "Merced_EN", 3, "Damocles_EN");

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "EyePalm_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", Flower.Red, Flower.Blue, "Damocles_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "Damocles_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(3, "InHerImage_EN", 1, "Damocles_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.SimpleAddGroup(2, "InHisImage_EN", 1, "Damocles_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHerImage_EN", "Damocles_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.SimpleAddGroup(1, "ChoirBoy_EN", 3, "Damocles_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", "EyePalm_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "MiniReaper_EN", "Damocles_EN");

            easy = new AddTo(Garden.H.Minister.Easy);
            easy.AddRandomGroup(Enemies.Minister, "Damocles_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Damocles_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "WindSong_EN", "Damocles_EN");
        }
    }
}
