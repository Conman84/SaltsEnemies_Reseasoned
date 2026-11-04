using System;
using System.Collections.Generic;
using System.Text;

//Byakhee (30 red)
//StarVampire (25 colors)
//Lloigor_EN (grey withering)

//Polyp (35 red)

namespace SaltsEnemies_Reseasoned
{
    public static class MythosCrossover_26_UpToDate
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Melder.Med);
            med.AddRandomGroup("Melder_EN", "Melder_EN", "Byakhee_EN");

            med = new AddTo(Orph.H.Byakhee.Med);
            med.AddRandomGroup("Byakhee_EN", "Byakhee_EN", "Melder_EN");

            med = new AddTo(Orph.H.Vampire.Med);

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", "StarVampire_EN", "StarVampire_EN");
            med.AddRandomGroup("ILoveYou_EN", "MusicMan_EN", "MusicMan_EN", "Lloigor_EN");

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, "Byakhee_EN");
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, "StarVampire_EN");
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, "Lloigor_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "ChoirBoy_EN", Enemies.Polyp);

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Enemies.Polyp);

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, Enemies.Polyp);
            med.AddRandomGroup("Celebration_EN", Enemies.Polyp, "ChoirBoy_EN");
            med.AddRandomGroup("Celebration_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Polyp);

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", Enemies.Polyp, "Damocles_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "Lightbulbkin_EN", Enemies.Polyp, "BlackStar_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "Lightbulbkin_EN", Enemies.Polyp);
            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "Lightbulbkin_EN", Enemies.Polyp);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Eclipse, Enemies.Polyp);
        }
    }
}
