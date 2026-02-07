using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_19_21
    {
        public static void Add()
        {
            //SHORE
            AddTo easy = new AddTo(Shore.H.Draugr.Easy);
            easy.AddRandomGroup("Draugr_EN", "Waltz_EN", "Waltz_EN");
            //easy.AddRandomGroup("Draugr_EN", "Wall_EN");

            AddTo med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Draugr_EN", "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", "Draugr_EN", "Pinano_EN");

            AddTo hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Draugr_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "Draugr_EN", "Draugr_EN");

            //ORPH
            easy = new AddTo(Orph.H.Moone.Easy);
            easy.AddRandomGroup("Moone_EN", "Moone_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Moone.Med);
            med.AddRandomGroup("Moone_EN", "Moone_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Moone_EN", "Moone_EN", "Moone_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Moone_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Moone_EN", "Moone_EN", "Author_EN");
            med.AddRandomGroup("Author_EN", "Thunderdome_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", "Author_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Heehoo_EN", "Author_EN", Jumble.Purple);
            med.SimpleAddGroup(1, "Heehoo_EN", 3, "Foxtrot_EN");

            hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", "Wednesday_EN");

            //I ALREADY DID THE GARDENS
        }
    }
}
