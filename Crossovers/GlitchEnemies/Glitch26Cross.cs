using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Glitch26Cross
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Dancer.Med);
            med.SimpleAddGroup(3, "BackupDancer_EN", 1, "Melder_EN");

            med = new AddTo(Orph.H.Frostbite.Med);
            med.SimpleAddGroup(3, "Frostbite_EN", 1, "Melder_EN");

            med = new AddTo(Orph.H.Melder.Med);
            med.SimpleAddGroup(2, "Melder_EN", 1, "BackupDancer_EN");
            med.SimpleAddGroup(2, "Melder_EN", 2, "Frostbite_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.SimpleAddGroup(1, "ILoveYou_EN", 3, "Frostbite_EN");
            med.AddRandomGroup("ILoveYou_EN", "BackupDancer_EN", "MusicMan_EN", "SingingStone_EN");

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 2, "Frostbite_EN");
            hard.SimpleAddGroup(2, "ILoveYou_EN", 2, "BackupDancer_EN");
        }
    }
}
