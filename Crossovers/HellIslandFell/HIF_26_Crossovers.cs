using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_26_Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Moone.Med);
            med.SimpleAddGroup(3, "Moone_EN", 1, "Melder_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.SimpleAddGroup(1, "Heehoo_EN", 2, "Melder_EN");

            AddTo hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "Moone_EN", "ILoveYou_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "MusicMan_EN", "MusicMan_EN", "Melder_EN");

            med = new AddTo(Orph.H.Melder.Med);
            med.AddRandomGroup("Melder_EN", "Thunderdome_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", "Moone_EN", "Moone_EN", "Moone_EN");
            med.AddRandomGroup("ILoveYou_EN", "Thunderdome_EN", "MusicMan_EN");

            hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", "VanishingHands_EN");

            med = new(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, Noses.Red, Noses.Purple);
            med.AddRandomGroup(Enemies.Eclipse, Noses.Blue, Noses.Yellow);

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Noses.Gray);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Noses.Red);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Noses.Purple);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Noses.Blue);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Noses.Yellow);

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, Noses.Purple);
            med.SimpleAddGroup(2, "Celebration_EN", 1, Noses.Red);

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 1, Noses.Yellow, 1, Noses.Blue);

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, Noses.Blue);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, Noses.Red);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, Noses.Yellow);

            med = new AddTo(Garden.H.Nosestone.Red.Med);
            med.AddRandomGroup(Noses.Red, Noses.Yellow, "Celebration_EN");
            med.AddRandomGroup(Noses.Red, Noses.Blue, "Lightbulbkin_EN");
            med = new AddTo(Garden.H.Nosestone.Blue.Med);
            med.AddRandomGroup(Noses.Blue, Noses.Yellow, "Celebration_EN");
            med.AddRandomGroup(Noses.Purple, Noses.Blue, "Lightbulbkin_EN");
            med = new AddTo(Garden.H.Nosestone.Purple.Med);
            med.AddRandomGroup(Noses.Red, Noses.Purple, "Celebration_EN");
            med.AddRandomGroup(Noses.Gray, Noses.Purple, "Lightbulbkin_EN");
            med = new AddTo(Garden.H.Nosestone.Yellow.Med);
            med.AddRandomGroup(Noses.Purple, Noses.Yellow, "Celebration_EN");
            med.AddRandomGroup(Noses.Red, Noses.Yellow, "Lightbulbkin_EN");
            med = new AddTo(Garden.H.Nosestone.Grey.Med);
            med.AddRandomGroup(Noses.Red, Noses.Grey, "Celebration_EN");
            med.AddRandomGroup(Noses.Gray, Noses.Blue, "Lightbulbkin_EN");

            hard = new AddTo(Garden.H.Nosestone.Red.Hard);
            hard.AddRandomGroup(Noses.Red, "InHisImage_EN", "InHisImage_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Blue, Noses.Yellow, "Celebration_EN");
            hard = new AddTo(Garden.H.Nosestone.Blue.Hard);
            hard.AddRandomGroup(Noses.Blue, "InHisImage_EN", "InHisImage_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Blue, Noses.Purple, "Celebration_EN");
            hard = new AddTo(Garden.H.Nosestone.Yellow.Hard);
            hard.AddRandomGroup(Noses.Yellow, "InHisImage_EN", "InHisImage_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Purple, Noses.Yellow, "Celebration_EN");
            hard = new AddTo(Garden.H.Nosestone.Purple.Hard);
            hard.AddRandomGroup(Noses.Purple, "InHisImage_EN", "InHisImage_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Purple, Noses.Yellow, "Celebration_EN");
            hard = new AddTo(Garden.H.Nosestone.Grey.Hard);
            hard.AddRandomGroup(Noses.Gray, "InHisImage_EN", "InHisImage_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(Noses.Red, Noses.Blue, Noses.Gray, "Celebration_EN");
        }
    }
}
