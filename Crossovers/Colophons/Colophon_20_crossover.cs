using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colophon_20_crossover
    {
        public static void Add()
        {
            AddTo med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("2009_EN", Colophon.Red, "Pinano_EN");
            med.AddRandomGroup("2009_EN", Colophon.Blue, "MudLung_EN");
            med.AddRandomGroup("2009_EN", "Snaurce_EN", Colophon.Blue);

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", Colophon.Red, Colophon.Blue, "MudLung_EN");
            med.AddRandomGroup("Chiito_EN", Colophon.Blue, "Flarblet_EN", Colophon.Red);
            med.AddRandomGroup("Chiito_EN", "Pinano_EN", "Pinano_EN", Colophon.Blue);
            med.AddRandomGroup("Chiito_EN", Enemies.Mungling, "MudLung_EN", Colophon.Red);

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "2009_EN", Colophon.Blue);

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Colophon.Red, "2009_EN");

            AddTo hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Colophon.Red, Colophon.Blue, "Chiito_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Chiito_EN", Colophon.Blue);

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(2, "Solitaire_EN", 1, Colophon.Red, 1, Colophon.Yellow);
            med.SimpleAddGroup(2, "Solitaire_EN", 1, Colophon.Red, 1, Colophon.Purple);
            med.AddRandomGroup("Solitaire_EN", "Enigma_EN", "Enigma_EN", Colophon.Yellow);
            med.AddRandomGroup("Solitaire_EN", "Enigma_EN", "Sigil_EN", Colophon.Purple);
            med.AddRandomGroup("Solitaire_EN", "WindSong_EN", "LostSheep_EN", Colophon.Yellow);
            med.AddRandomGroup("Solitaire_EN", Enemies.Solvent, Colophon.Purple, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Solitaire_EN", "Foxtrot_EN", "Foxtrot_EN", Colophon.Yellow);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", Colophon.Purple, Colophon.Blue);
        }
    }
}
