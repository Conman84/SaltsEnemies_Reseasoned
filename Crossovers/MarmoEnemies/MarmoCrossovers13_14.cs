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

        }
    }
}
