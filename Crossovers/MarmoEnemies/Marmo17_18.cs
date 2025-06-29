using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Marmo17_18
    {
        public static void AddShore()
        {
            AddTo easy = new AddTo(Shore.H.Snaurce.Easy);
            easy.SimpleAddGroup(2, "Snaurce_EN", 1, "NobodyGrave_EN");

            easy = new AddTo(Shore.H.Surimi.Easy);
            easy.SimpleAddGroup(2, "Surimi_EN", 1, "NobodyGrave_EN");

            AddTo med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", "Surimi_EN");
            med.SimpleAddGroup(1, "ToyUfo_EN", 2, "Snaurce_EN", 1, "TortureMeNot_EN");
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", "Pinano_EN");
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", Jumble.Yellow);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", Jumble.Red);
            med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", Jumble.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", Spoggle.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "Pinano_EN", Jumble.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "MudLung_EN", Spoggle.Unstable);
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("ToyUfo_EN", "Snaurce_EN", "Snaurce_EN", "Skyloft_EN");
            med.AddRandomGroup("ToyUfo_EN", "Surimi_EN", "MudLung_EN");
            med.SimpleAddGroup(1, "ToyUfo_EN", 3, "Snaurce_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Jumble.Unstable);

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Surimi_EN", "Sinker_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Spoggle.Unstable);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("LittleBeak_EN", "ToyUfo_EN", Jumble.Unstable);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "ToyUfo_EN", "Surimi_EN", "Surimi_EN");
            hard.AddRandomGroup("Warbird_EN", "NobodyGrave_EN", Jumble.Unstable, Jumble.Red);

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("Clione_EN", "ToyUfo_EN", Jumble.Unstable);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", "Surimi_EN");
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", "Snaurce_EN");
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", Jumble.Unstable);
            hard.AddRandomGroup("Clione_EN", "Sinker_EN", Spoggle.Unstable);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Snaurce_EN", "Arceles_EN");
            med.AddRandomGroup("Sinker_EN", "Surimi_EN", "Skyloft_EN");
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup("Sinker_EN", Spoggle.Yellow, Spoggle.Unstable);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Sinker_EN", Spoggle.Blue, Spoggle.Unstable);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.SimpleAddGroup(1, "Sinker_EN", 3, "Snaurce_EN");
            hard.SimpleAddGroup(1, "Sinker_EN", 3, "Surimi_EN");
            hard.AddRandomGroup("Sinker_EN", Jumble.Unstable, Jumble.Yellow, Jumble.Red);

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, Jumble.Unstable, "NobodyGrave_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, Jumble.Unstable, "NobodyGrave_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, Spoggle.Unstable, "ToyUfo_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, Spoggle.Unstable, "ToyUfo_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Snaurce_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", "Surimi_EN");
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", Jumble.Unstable);
            med.AddRandomGroup("FlaMinGoa_EN", "ToyUfo_EN", Spoggle.Unstable);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "NobodyGrave_EN", Spoggle.Unstable);
            hard.AddRandomGroup("Flarb_EN", "NobodyGrave_EN", Jumble.Unstable);
        }
        public static void AddOrpheum()
        {

        }
    }
}
