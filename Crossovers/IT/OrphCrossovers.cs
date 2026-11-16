using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class OrphCrossovers
    {
        public static void Gizo()
        {
            AddTo med = new AddTo(Orph.H.Gizo.Med);
            med.AddRandomGroup("Gizo_EN", "NakedGizo_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Gizo_EN", "NakedGizo_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Gizo_EN", "NakedGizo_EN", Enemies.Shooter);
            med.AddRandomGroup("Gizo_EN", "NakedGizo_EN", Enemies.Solvent);

            AddTo hard = new AddTo(Orph.H.Gizo.Hard);
            hard.AddRandomGroup("Gizo_EN", "Something_EN", "NakedGizo_EN");
            hard.AddRandomGroup("Gizo_EN", "NakedGizo_EN", "Nume_EN", "NakedGizo_EN");
            hard.AddRandomGroup("Gizo_EN", "NakedGizo_EN", "Author_EN", "Author_EN");

            med = new AddTo(Orph.H.Enigma.Easy);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "NakedGizo_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "NakedGizo_EN", "NakedGizo_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.SimpleAddGroup(2, Enemies.Camera, 2, "NakedGizo_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "NakedGizo_EN");
            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "NakedGizo_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.SimpleAddGroup(1, "WindSong_EN", 3, "NakedGizo_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.SimpleAddGroup(1, "Maw_EN", 2, "NakedGizo_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.SimpleAddGroup(1, "Nameless_EN", 4, "NakedGizo_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "NakedGizo_EN", "NakedGizo_EN", "NakedGizo_EN");

            med = new AddTo(Orph.H.Foxtrot.Easy);
            med.SimpleAddGroup(2, "Foxtrot_EN", 2, "NakedGizo_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, "NakedGizo_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.SimpleAddGroup(3, "Author_EN", 1, "NakedGizo_EN");

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "Nume_EN", "NakedGizo_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.SimpleAddGroup(2, Enemies.Shooter, 1, "NakedGizo_EN");
        }

        public static void Ophanim()
        {
            AddTo hard = new AddTo(Orph.H.Ophanim.Hard);
            hard.AddRandomGroup("Ophanim_EN", "Something_EN");
            hard.AddRandomGroup("Ophanim_EN", "Freud_EN");
            hard.AddRandomGroup("Ophanim_EN", "Delusion_EN", "FakeAngel_EN");
            hard.AddRandomGroup("Ophanim_EN", "Evileye_EN");
            hard.AddRandomGroup("Ophanim_EN", "Rabies_EN");
            hard.AddRandomGroup("Ophanim_EN", "TheWhale_EN");
            hard.AddRandomGroup("Ophanim_EN", "ILoveYou_EN");
        }
    }
}
