using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossover_9_10
    {
        public static void Add()
        {
            FarShore();
            Orpheum();
            TheGarden();
        }
        public static void FarShore()
        {
            AddTo med = new AddTo(Shore.H.Jumble.Red.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Jumble.Red, "Skyloft_EN", Jumble.Unstable);
            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Jumble.Yellow, "Skyloft_EN", Jumble.Unstable);
            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Spoggle.Yellow, "Skyloft_EN", Spoggle.Unstable);
            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Spoggle.Blue, "Skyloft_EN", Spoggle.Unstable);

            AddTo easy = new AddTo(Shore.H.Snaurce.Easy);
            easy.SimpleAddGroup(2, "Snaurce_EN", 1, "Skyloft_EN");
            easy = new AddTo(Shore.H.Surimi.Easy);
            easy.SimpleAddGroup(2, "Surimi_EN", 1, "Skyloft_EN");
        }
        public static void Orpheum()
        {
            AddTo easy = new AddTo(Orph.H.Jumble.Unstable.Easy);
            if (SaltsReseasoned.silly > 50) easy.AddRandomGroup(Jumble.Unstable, Jumble.Yellow, "Spectre_EN");
            else easy.AddRandomGroup(Jumble.Unstable, Jumble.Red, "Spectre_EN");
            easy = new AddTo(Orph.H.Spoggle.Unstable.Easy);
            if (SaltsReseasoned.silly < 50) easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Yellow, "Spectre_EN");
            else easy.AddRandomGroup(Spoggle.Unstable, Spoggle.Blue, "Spectre_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Romantic_EN", "Romantic_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", Jumble.Unstable, Jumble.Yellow);
            hard.AddRandomGroup("StalwartTortoise_EN", Spoggle.Unstable, Spoggle.Blue);
            hard.AddRandomGroup("StalwartTortoise_EN", "Surrogate_EN", "Scrungie_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", "Romantic_EN", "WindSong_EN");
            hard.AddRandomGroup("StalwartTortoise_EN", "Surrogate_EN", Flower.Yellow);

            AddTo med = new AddTo(Orph.H.Errant.Med);
            if (SaltsReseasoned.trolling > 25 && SaltsReseasoned.trolling < 75) med.AddRandomGroup("Errant_EN", "Spectre_EN", "Spectre_EN", "Spectre_EN");


        }
        public static void TheGarden()
        {
            AddTo med = new AddTo(Garden.H.Grandfather.Med);
            med.SimpleAddGroup(1, "Grandfather_EN", 3, "Git_EN");
            med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHisImage_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.SimpleAddGroup(1, Flower.Grey, 3, "Git_EN");
            med.AddRandomGroup(Flower.Grey, Flower.Red, "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup(Flower.Grey, Flower.Blue, "Attrition_EN", "Attrition_EN");

            AddTo hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Yellow, "Git_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Flower.Yellow, "Git_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Purple, "Git_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Flower.Purple, "Git_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, "Surrogate_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.SimpleAddGroup(1, "MiniReaper_EN", 2, "Attrition_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(1, "MiniReaper_EN", 2, "Attrition_EN", 1, "Surrogate_EN");
            med.AddRandomGroup("MiniReaper_EN", "Git_EN", "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup("MiniReaper_EN", "Git_EN", Flower.Red, Flower.Blue);
            med.AddRandomGroup("MiniReaper_EN", "Git_EN", "InHerImage_EN", "InHisImage_EN");
            med.AddRandomGroup("MiniReaper_EN", "Git_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("MiniReaper_EN", "Attrition_EN", "Attrition_EN", "EyePalm_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHisImage_EN", "Romantic_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHisImage_EN", "Surrogate_EN");
            med.AddRandomGroup("MiniReaper_EN", "Attrition_EN", "Attrition_EN", "Romantic_EN");
            med.AddRandomGroup("MiniReaper_EN", "Attrition_EN", "Attrition_EN", "Surrogate_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "Git_EN");
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "Surrogate_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.SimpleAddGroup(1, "Shua_EN", 3, "Git_EN");
            med.AddRandomGroup("Shua_EN", "Git_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Shua_EN", "Git_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Shua_EN", "Git_EN", "Git_EN", "MiniReaper_EN");
            med.AddRandomGroup("Shua_EN", "InHerImage_EN", "InHerImage_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Shua_EN", "InHerImage_EN", "InHerImage_EN", "Surrogate_EN");
            med.AddRandomGroup("Shua_EN", "EyePalm_EN", "EyePalm_EN", "Romantic_EN");

            AddTo easy = new AddTo(Garden.H.Shua.Easy);
            easy.SimpleAddGroup(1, "Shua_EN", 2, "Attrition_EN");
            easy.AddRandomGroup("Shua_EN", "Git_EN", "EyePalm_EN");
            easy.AddRandomGroup("Shua_EN", "Romantic_EN", "Romantic_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.AddRandomGroup("Attrition_EN", "Attrition_EN", "EyePalm_EN", "MiniReaper_EN");
            med.SimpleAddGroup(3, "Attrition_EN", 1, "Shua_EN");
            med.SimpleAddGroup(3, "Attrition_EN", 1, "EyePalm_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Attrition_EN", "Attrition_EN", "Attrition_EN", "Skyloft_EN");
            med.SimpleAddGroup(3, "Attrition_EN", 1, "Grandfather_EN");
            med.AddRandomGroup("Attrition_EN", "Attrition_EN", "MiniReaper_EN");

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.AddRandomGroup("Attrition_EN", "Attrition_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(2, "Git_EN", 2, "EyePalm_EN");
            med.SimpleAddGroup(3, "Git_EN", 1, "Grandfather_EN");
            easy = new AddTo(Garden.H.Git.Easy);
            if (SaltsReseasoned.trolling < 50) easy.SimpleAddGroup(3, "Git_EN", 1, "Skyloft_EN");
            easy.AddRandomGroup("Git_EN", "Git_EN", "EyePalm_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.AddRandomGroup("EyePalm_EN", Enemies.Shivering, "EyePalm_EN", "Romantic_EN");
            easy.AddRandomGroup("EyePalm_EN", Enemies.Shivering, Enemies.Shivering, "Romantic_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "MiniReaper_EN", "Attrition_EN");
            med.AddRandomGroup(Enemies.Skinning, "MiniReaper_EN", "Git_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(2, "InHerImage_EN", 1, "EyePalm_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "InHerImage_EN", 1, "EyePalm_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(2, "InHerImage_EN", 1, "EyePalm_EN", 1, "Git_EN");
            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "EyePalm_EN", "Romantic_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "EyePalm_EN", "Surrogate_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "EyePalm_EN", "Git_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", "EyePalm_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Attrition_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "Attrition_EN", "Attrition_EN");
            hard.SimpleAddGroup(1, "Miriam_EN", 3, "Romantic_EN");
            hard.SimpleAddGroup(1, "Miriam_EN", 3, "Surrogate_EN");
        }
    }
}
