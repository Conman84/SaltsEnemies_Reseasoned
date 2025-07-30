using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colophon21Crossover
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Something_EN", Colophon.Yellow);
            med.AddRandomGroup("Author_EN", "Scrungie_EN", Colophon.Purple);
            med.AddRandomGroup("Author_EN", "Author_EN", Colophon.Red, Colophon.Blue);

            //shore

            AddTo easy = new AddTo(Shore.H.Colophon.Red.Easy);
            easy.AddRandomGroup(Colophon.Red, "Wall_EN", "Wall_EN");
            easy.SimpleAddGroup(1, Colophon.Red, 2, "Waltz_EN");

            easy = new AddTo(Shore.H.Colophon.Blue.Easy);
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup(Colophon.Blue, "Wall_EN", "Wall_EN");
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup(Colophon.Blue, "Wall_EN");
            easy.SimpleAddGroup(1, Colophon.Red, 2, "Waltz_EN");

            med = new AddTo(Shore.H.Colophon.Red.Med);
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "Wall_EN");
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "VoiceTrumpet_EN");
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "Wall_EN", "Flarblet_EN");

            med = new AddTo(Shore.H.Colophon.Blue.Med);
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "Wall_EN");
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "VoiceTrumpet_EN");
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "Wall_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.SimpleAddGroup(2, "VoiceTrumpet_EN", 1, Colophon.Blue);
            med.SimpleAddGroup(2, "VoiceTrumpet_EN", 1, Colophon.Red, 1, Colophon.Blue);
            med.AddRandomGroup("VoiceTrumpet_EN", Colophon.Blue, "MudLung_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, Colophon.Blue, "Wall_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", Colophon.Red, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Colophon.Red, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Colophon.Blue, "Wall_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Colophon.Red, "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", Colophon.Blue, "Wall_EN");

            AddTo hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", Colophon.Blue, "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Colophon.Red, "Waltz_EN", "Waltz_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", Colophon.Red, Colophon.Blue);
            hard.AddRandomGroup("Clown_EN", Colophon.Red, "VoiceTrumpet_EN", "VoiceTrumpet_EN");
            hard.AddRandomGroup("Clown_EN", Colophon.Blue, "Wall_EN");
            hard.AddRandomGroup("Clown_EN", Colophon.Blue, "Pinano_EN");
            hard.AddRandomGroup("Clown_EN", Colophon.Red, "Sinker_EN");
            hard.AddRandomGroup("Clown_EN", Colophon.Blue, "Waltz_EN", "Waltz_EN");
        }
    }
}
