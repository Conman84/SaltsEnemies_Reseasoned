using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Marmo_Chapter_19
    {
        public static void OrpheumCrossovers()
        {
            AddTo med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "Wednesday_EN", "Scrungie_EN");
            med.AddRandomGroup("Errant_EN", "Wednesday_EN", Bots.Blue);
            med.AddRandomGroup("Errant_EN", "Wednesday_EN", "Gungrot_EN", "Gungrot_EN");

            AddTo hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "Errant_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", Jumble.Unstable, "Gungrot_EN", "Gungrot_EN", "Gungrot_EN");
            med.AddRandomGroup("Wednesday_EN", Spoggle.Unstable, "Gungrot_EN", "Gungrot_EN");
        }
        public static void Garden()
        {

        }
    }
}
