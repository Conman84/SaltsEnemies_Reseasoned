using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossovers13_14
    {
        public static void Add()
        {
            FarShore();
            Orpheum();
            TheGarden();
        }
        public static void FarShore()
        {
            AddTo med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Surimi_EN", "Surimi_EN");
            med.AddRandomGroup("Clione_EN", "Snaurce_EN", "Snaurce_EN");
            med.AddRandomGroup("Clione_EN", "Pinano_EN", "Surimi_EN");
            med.AddRandomGroup("Clione_EN", "Snaurce_EN", "Wall_EN");
            med.AddRandomGroup("Clione_EN", "Snaurce_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("Clione_EN", "Surimi_EN", Jumble.Unstable);

            AddTo hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", Jumble.Red, Jumble.Yellow, Jumble.Unstable);
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Clione_EN", Spoggle.Blue, Spoggle.Unstable, "MudLung_EN");
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Clione_EN", Spoggle.Yellow, Spoggle.Unstable, "MudLung_EN");

            AddTo easy = new AddTo(Shore.H.Snaurce.Easy);
            easy.SimpleAddGroup(2, "Snaurce_EN", 1, "Windle_EN");
            if (SaltsReseasoned.silly > 50) easy.SimpleAddGroup(2, "Snaurce_EN", 1, "Arceles_EN");

            easy = new AddTo(Shore.H.Surimi.Easy);
            if (SaltsReseasoned.trolling > 50) easy.SimpleAddGroup(2, "Surimi_EN", 1, "Windle_EN");
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup("Surimi_EN", "MudLung_EN", "Windle_EN");
            if (SaltsReseasoned.silly < 50) easy.SimpleAddGroup(2, "Surimi_EN", 1, "Arceles_EN");

            med = new AddTo(Shore.H.Snaurce.Med);
            if (SaltsReseasoned.trolling < 33) med.AddRandomGroup("Snaurce_EN", "Pinano_EN", Jumble.Yellow);
            if (SaltsReseasoned.trolling > 33 && SaltsReseasoned.trolling < 66) med.AddRandomGroup("Snaurce_EN", "Pinano_EN", Jumble.Red);
            if (SaltsReseasoned.trolling > 66) med.AddRandomGroup("Snaurce_EN", "Pinano_EN", Jumble.Unstable);
            med.SimpleAddGroup(2, "Snaurce_EN", 1, "Pinano_EN");

            med = new AddTo(Shore.H.Surimi.Med);
            if (SaltsReseasoned.silly < 33) med.AddRandomGroup("Surimi_EN", "Pinano_EN", Spoggle.Yellow);
            if (SaltsReseasoned.silly > 33 && SaltsReseasoned.silly < 66) med.AddRandomGroup("Surimi_EN", "Pinano_EN", Spoggle.Blue);
            if (SaltsReseasoned.silly > 66) med.AddRandomGroup("Surimi_EN", "Pinano_EN", Spoggle.Unstable);

            easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Pinano_EN", Jumble.Unstable, "Minana_EN");
            easy.AddRandomGroup("Pinano_EN", "Snaurce_EN", "Skyloft_EN");
            easy.AddRandomGroup("Pinano_EN", "Surimi_EN", "Minana_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.SimpleAddGroup(2, "Pinano_EN", 1, "Surimi_EN");
            med.SimpleAddGroup(2, "Pinano_EN", 1, "Snaurce_EN");
            med.SimpleAddGroup(2, "Pinano_EN", 1, Spoggle.Unstable);
            med.SimpleAddGroup(2, "Pinano_EN", 1, Jumble.Unstable);
        }
        public static void Orpheum()
        {
            AddTo med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Jumble.Yellow, Jumble.Red, Jumble.Unstable);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Maw_EN", Spoggle.Red, Spoggle.Unstable);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Maw_EN", Spoggle.Purple, Spoggle.Unstable);
            med.SimpleAddGroup(1, "Maw_EN", 4, "Gungrot_EN");
            med.AddRandomGroup("Maw_EN", "Gungrot_EN", "Gungrot_EN", "TheCrow_EN");
            med.AddRandomGroup("Maw_EN", "Gungrot_EN", "Gungrot_EN", "Freud_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Maw_EN", "Gungrot_EN", "Gungrot_EN", Flower.Yellow);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Maw_EN", "Gungrot_EN", "Gungrot_EN", Flower.Purple);

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Spoggle.Yellow, Spoggle.Blue, Spoggle.Unstable);
            hard.AddRandomGroup("Maw_EN", Flower.Yellow, Flower.Purple, "Romantic_EN");
            hard.SimpleAddGroup(1, "Maw_EN", 4, "Romantic_EN");

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "Maw_EN", "LostSheep_EN");
            hard.AddRandomGroup("Errant_EN", "Maw_EN", "Romantic_EN");
        }
        public static void TheGarden()
        {
            //THIRTEEN
            AddTo easy = new AddTo(Garden.H.Attrition.Easy);
            easy.SimpleAddGroup(2, "Attrition_EN", 1, "BlackStar_EN");
            easy.SimpleAddGroup(2, "Attrition_EN", 1, "Indicator_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.AddRandomGroup("Git_EN", Enemies.Shivering, "BlackStar_EN", "BlackStar_EN");

            AddTo med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(3, "Attrition_EN", 1, "Indicator_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.AddRandomGroup("Git_EN", "Git_EN", "Indicator_EN", "Damocles_EN", "Damocles_EN");
            med.SimpleAddGroup(3, "Git_EN", 1, "BlackStar_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHerImage_EN", "Romantic_EN");
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "Surrogate_EN");

            easy = new AddTo(Garden.H.BlackStar.Easy);
            easy.AddRandomGroup("BlackStar_EN", "Surrogate_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Git_EN", "BlackStar_EN");
            med.AddRandomGroup(Enemies.Skinning, "Attrition_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "Git_EN", "Indicator_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "Git_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Git_EN", "Git_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "Attrition_EN", "Attrition_EN", "BlackStar_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Indicator_EN", "Git_EN", "Git_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Git_EN", "Git_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "Attrition_EN", "Attrition_EN", "BlackStar_EN");

            //ch14
            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "Git_EN", "Children6_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "Git_EN", "Children6_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Attrition_EN", "Attrition_EN", "Children6_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Git_EN", "Git_EN", "Children6_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 1, "Children6_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(3, "Git_EN", 1, "Children6_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.SimpleAddGroup(2, "Git_EN", 1, "Children6_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Git_EN", "Git_EN");
            med.AddRandomGroup("YNL_EN", "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", "Romantic_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "YNL_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "YNL_EN", "Git_EN", "Git_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Git_EN", "Git_EN");
            med.AddRandomGroup("Stoplight_EN", "Romantic_EN", "BlackStar_EN", "Romantic_EN");
            med.AddRandomGroup("Stoplight_EN", "Surrogate_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("Stoplight_EN", "YNL_EN", "Git_EN");
            med.AddRandomGroup("Stoplight_EN", "Romantic_EN", "ChoirBoy_EN");
            med.SimpleAddGroup(1, "Stoplight_EN", 3, "Romantic_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.SimpleAddGroup(1, "Stoplight_EN", 3, "Attrition_EN");
            hard.SimpleAddGroup(1, "Stoplight_EN", 3, "Git_EN");
            hard.AddRandomGroup("Stoplight_EN", "ChoirBoy_EN", "ChoirBoy_EN", "Romantic_EN");
            hard.AddRandomGroup("Stoplight_EN", "Firebird_EN", "Hunter_EN", "Surrogate_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Stoplight_EN", "Satyr_EN", "Romantic_EN");
            med.AddRandomGroup("Stoplight_EN", "Satyr_EN", "Surrogate_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Satyr_EN", "Attrition_EN");
            hard.AddRandomGroup("Stoplight_EN", "Satyr_EN", "Git_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Skinning, "Romantic_EN");
            med.AddRandomGroup("Stoplight_EN", Enemies.Skinning, "Surrogate_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Skinning, "Attrition_EN");
            hard.AddRandomGroup("Stoplight_EN", Enemies.Skinning, "Git_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Stoplight_EN", "Git_EN", "Git_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Stoplight_EN", "Romantic_EN");
        }
    }
}
