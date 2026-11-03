using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colo24_26
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Colophon.Yellow.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "TheWhale_EN");
            med.AddRandomGroup(Colophon.Yellow, "Melder_EN", "MusicMan_EN");
            med = new AddTo(Orph.H.Colophon.Purple.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "TheWhale_EN");
            med.AddRandomGroup(Colophon.Purple, "Melder_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Colophon.Yellow, 1, "Wednesday_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Colophon.Purple, 1, "Nameless_EN");

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", Colophon.Yellow, "Scrungie_EN");
            med.AddRandomGroup("Nume_EN", Colophon.Purple, "Scrungie_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", Colophon.Yellow, Colophon.Purple);

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", Colophon.Yellow);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", Colophon.Purple);
        }
    }
}
