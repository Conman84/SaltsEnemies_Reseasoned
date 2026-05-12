using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AApocrypha_Set3Crossovers
    {
        public static void Add()
        {
            Aggregates_Shore();
        }
        public static void Aggregates_Shore()
        {
            AddTo easy = new AddTo(Shore.H.Aggregates.Red.Easy);
            easy.AddRandomGroup(Aggregates.Red, "Minana_EN", "Minana_EN");

            easy = new AddTo(Shore.H.Aggregates.Purple.Easy);
            easy.AddRandomGroup(Aggregates.Purple, "Wall_EN");

            AddTo med = new AddTo(Shore.H.Aggregates.Red.Med);
            med.AddRandomGroup(Aggregates.Red, "Waltz_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Aggregates.Red, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Aggregates.Red, "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomGroup(Aggregates.Red, "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup(Aggregates.Red, "Papereater_EN", Enemies.Mungling);
            med.AddRandomGroup(Aggregates.Red, "Jabberwocky_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Aggregates.Red, "MudLung_EN", "2009_EN");

            med = new AddTo(Shore.H.Aggregates.Purple.Med);
            med.AddRandomGroup(Aggregates.Purple, "VoiceTrumpet_EN", "MudLung_EN");
            med.AddRandomGroup(Aggregates.Purple, "Waltz_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Aggregates.Purple, "Pinano_EN", "MudLung_EN");
            med.AddRandomGroup(Aggregates.Purple, "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomGroup(Aggregates.Purple, "Papereater_EN", Enemies.Mungling);
            med.AddRandomGroup(Aggregates.Purple, "Jabberwocky_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Aggregates.Purple, "MudLung_EN", "2009_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", Aggregates.Red, "Skyloft_EN");
            med.AddRandomGroup("ToyUfo_EN", Aggregates.Purple, "NobodyGrave_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup(Aggregates.Red, "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup(Aggregates.Purple, "Pinano_EN", "Pinano_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", Aggregates.Red, "Wall_EN");
            med.AddRandomGroup("2009_EN", Aggregates.Purple, "MudLung_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", Aggregates.Red, "Arceles_EN");
            med.AddRandomGroup("Jabberwocky_EN", Aggregates.Purple, "Skyloft_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Aggregates.Red, "Snaurce_EN");
            med.AddRandomGroup("AFlower_EN", Aggregates.Purple, "LostSheep_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Aggregates.Red, "Windle_EN");
            med.AddRandomGroup("LittleBeak_EN", Aggregates.Purple, "Flarblet_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Aggregates.Red, "Surimi_EN");
            med.AddRandomGroup("Clione_EN", Aggregates.Purple, "MudLung_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", Aggregates.Red, "Arceles_EN");
            med.AddRandomGroup("Sinker_EN", Aggregates.Purple);

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", Aggregates.Red, "Pinano_EN");
            hard.AddRandomGroup("AFlower_EN", Aggregates.Purple, "Pinano_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", Aggregates.Red, "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Tripod_EN", Aggregates.Purple, "ToyUfo_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup("Unmung_EN", Aggregates.Red);

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Aggregates.Red, "Papereater_EN");
            hard.AddRandomGroup("Warbird_EN", Aggregates.Purple, "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", Aggregates.Red, "Papereater_EN");
            hard.AddRandomGroup("Clione_EN", Aggregates.Purple, "2009_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", Aggregates.Red, "2009_EN");
            hard.AddRandomGroup("Sinker_EN", Aggregates.Purple, "2009_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", Aggregates.Red, "Waltz_EN");
            hard.AddRandomGroup("Clown_EN", Aggregates.Purple, "Waltz_EN");
        }
    }
}
