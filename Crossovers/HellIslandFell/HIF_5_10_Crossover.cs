using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class HIF_5_10_Crossover
    {
        public static void FarShore()
        {
            AddTo easy = new AddTo(Shore.H.Draugr.Easy);
            easy.AddRandomGroup("Draugr_EN", "Skyloft_EN");
        }
        public static void Orpheum()
        {
            //moone, heehoo, thunderdome
            AddTo med = new AddTo(Orph.H.Moone.Med);
            med.SimpleAddGroup(3, "Moone_EN", 1, Flower.Yellow);
            med.SimpleAddGroup(3, "Moone_EN", 1, Flower.Purple);
            med.SimpleAddGroup(3, "Moone_EN", 1, Enemies.Solvent);
            med.AddRandomGroup("Moone_EN", "Moone_EN", "WindSong_EN", Spoggle.Yellow);

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Moone_EN", "Moone_EN");
            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Moone_EN", "Moone_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.SimpleAddGroup(1, "WindSong_EN", 3, "Moone_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Delusion_EN", "Delusion_EN");
            if (SaltsReseasoned.trolling < 50) med.SimpleAddGroup(1, "Heehoo_EN", 3, "Spectre_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            med.SimpleAddGroup(2, "Thunderdome_EN", 1, Enemies.Solvent);
            if (SaltsReseasoned.trolling > 50) med.SimpleAddGroup(2, "Thunderdome_EN", 2, "Spectre_EN");

            AddTo hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", Flower.Purple, Flower.Yellow);
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", "WindSong_EN");

            hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Heehoo_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", "Moone_EN", "Moone_EN");
        }
        public static void TheGarden()
        {
            AddTo hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Noses.Red, Noses.Blue, Noses.Yellow);
            hard.AddRandomGroup("ClockTower_EN", Noses.Red, Noses.Yellow, Noses.Purple);
            hard.AddRandomGroup("ClockTower_EN", Noses.Red, Noses.Gray, Noses.Blue);
            hard.AddRandomGroup("ClockTower_EN", Noses.Red, Noses.Blue, Noses.Purple);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Noses.Purple);
            hard.AddRandomGroup(Enemies.Tank, Noses.Blue);
            hard.AddRandomGroup(Enemies.Tank, Noses.Red, Noses.Yellow);
            hard.AddRandomGroup(Enemies.Tank, Noses.Grey, Noses.Grey);

            AddTo med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "EyePalm_EN", "EyePalm_EN", Noses.Blue);
            med.AddRandomGroup("Grandfather_EN", "EyePalm_EN", "EyePalm_EN", Noses.Purple);

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Noses.Blue);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Noses.Red);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Noses.Grey);

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Noses.Yellow);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Noses.Purple);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Noses.Red);

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "InHerImage_EN", "InHerImage_EN", Noses.Yellow);
            med.AddRandomGroup("Shua_EN", "InHerImage_EN", "InHerImage_EN", Noses.Red);
            med.AddRandomGroup("Shua_EN", "ChoirBoy_EN", Noses.Blue);
            med.AddRandomGroup("Shua_EN", Enemies.Minister, Noses.Red);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", Noses.Blue, Noses.Red);
            hard.AddRandomGroup("Miriam_EN", Noses.Yellow, Noses.Purple);
            hard.AddRandomGroup("Miriam_EN", Noses.Blue, Noses.Yellow);

            med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.AddRandomGroup(Noses.Red, Noses.Grey, "Grandfather_EN");
            med.AddRandomGroup(Noses.Red, Noses.Yellow, "Grandfather_EN");
            med.SimpleAddGroup(1, Noses.Red, 3, "EyePalm_EN");

            hard = new AddTo(Garden.H.Nosestone.Red.Hard);
            hard.AddRandomGroup(Noses.Red, "InHisImage_EN", "InHerImage_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Blue, Noses.Yellow, "Skyloft_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Purple, "Shua_EN", "LittleAngel_EN");

            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.AddRandomGroup(Noses.Blue, Noses.Yellow, "Grandfather_EN");
            med.SimpleAddGroup(1, Noses.Blue, 3, "EyePalm_EN");
            med.AddRandomGroup(Noses.Blue, Noses.Red, "MiniReaper_EN");

            hard = new AddTo(Garden.H.Nosestone.Blue.Hard);
            hard.AddRandomGroup(Noses.Blue, "Shua_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Noses.Blue, Noses.Purple, "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup(Noses.Blue, "InHerImage_EN", "InHisImage_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.SimpleAddGroup(1, Noses.Yellow, 3, "EyePalm_EN");
            med.AddRandomGroup(Noses.Yellow, Noses.Red, "Shua_EN");
            med.AddRandomGroup(Noses.Yellow, Noses.Blue, "Grandfather_EN");

            hard = new AddTo(Garden.H.Nosestone.Yellow.Hard);
            hard.AddRandomGroup(Noses.Yellow, Noses.Purple, "Grandfather_EN");
            hard.AddRandomGroup(Noses.Yellow, Noses.Red, "ChoirBoy_EN", "LittleAngel_EN");
            hard.AddRandomGroup(Noses.Yellow, "InHisImage_EN", "InHisImage_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.AddRandomGroup(Noses.Purple, "Shua_EN", "EyePalm_EN", "EyePalm_EN");
            med.SimpleAddGroup(1, Noses.Purple, 3, "EyePalm_EN");
            med.AddRandomGroup(Noses.Purple, Noses.Red, "MiniReaper_EN");

            hard = new AddTo(Garden.H.Nosestone.Purple.Hard);
            hard.AddRandomGroup(Noses.Purple, Noses.Yellow, "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup(Noses.Purple, "Shua_EN", "ChoirBoy_EN", "Skyloft_EN");
            hard.AddRandomGroup(Noses.Purple, Noses.Red, Noses.Blue, "Merced_EN");

            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.AddRandomGroup(Noses.Grey, Noses.Red, "Grandfather_EN", "Skyloft_EN");
            med.AddRandomGroup(Noses.Grey, "EyePalm_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Noses.Grey, "Grandfather_EN", "LittleAngel_EN");

            hard = new AddTo(Garden.H.Nosestone.Grey.Hard);
            hard.AddRandomGroup(Noses.Grey, "InHisImage_EN", "InHisImage_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Noses.Grey, "Shua_EN", "ChoirBoy_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Noses.Grey, "MiniReaper_EN", "Shua_EN", Noses.Red);
        }
    }
}
