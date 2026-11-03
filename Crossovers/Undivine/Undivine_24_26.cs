using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    //ClayChild_EN
    //ClayChildSleep_EN

    //Clergy_EN (pretty strong)
    //Sonoduct_EN (70 red, 2 size)
    public static class Undivine_24_26
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Melder.Med);
            med.SimpleAddGroup(2, "Melder_EN", 2, "ClayChildSleep_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.SimpleAddGroup(1, "ILoveYou_EN", 2, "ClayChildSleep_EN");

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.SimpleAddGroup(1, "ILoveYou_EN", 3, "ClayChildSleep_EN");
            hard.SimpleAddGroup(2, "ILoveYou_EN", 2, "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Clergy.Med);
            med.AddRandomGroup("Clergy_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup("Clergy_EN", "Melder_EN", "MusicMan_EN");

            hard = new AddTo(Orph.H.Clergy.Hard);
            hard.AddRandomGroup("Clergy_EN", "Clergy_EN", "ILoveYou_EN");
            hard.AddRandomGroup("Clergy_EN", "Clergy_EN", "Nume_EN");

            hard = new AddTo(Orph.H.Sonoduct.Hard);
            hard.AddRandomGroup("Sonoduct_EN", "Nume_EN", Enemies.Suckle, Enemies.Suckle);
            hard.AddRandomGroup("Sonoduct_EN", "Melder_EN", Enemies.Suckle, Enemies.Suckle);
            hard.AddRandomGroup("Sonoduct_EN", "TheWhale_EN", Enemies.Suckle, Enemies.Suckle);
            hard.AddRandomGroup("Sonoduct_EN", "ILoveYou_EN");
        }
    }
}
