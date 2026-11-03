using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossover26
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Melder.Med);
            med.AddRandomGroup("Melder_EN", "Melder_EN", Jumble.Red, Jumble.Unstable);
            med.AddRandomGroup("Melder_EN", "Melder_EN", Spoggle.Red, Spoggle.Unstable);
            med.SimpleAddGroup(3, "Melder_EN", 2, "Surrogate_EN");
            med.SimpleAddGroup(2, "Melder_EN", 2, "Gungrot_EN");
            med.SimpleAddGroup(1, "Melder_EN", 3, "Gungrot_EN");

            med = new AddTo(Orph.H.MusicMan.Med);
            med.AddRandomGroup("Melder_EN", "MusicMan_EN", "MusicMan_EN", Jumble.Unstable);
            med.AddRandomGroup("Melder_EN", "MusicMan_EN", "MusicMan_EN", Spoggle.Unstable);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Melder_EN", "Gungrot_EN", "Gungrot_EN");
            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Melder_EN", "Gungrot_EN", "Gungrot_EN");
            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Melder_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "Melder_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Errant_EN", "ILoveYou_EN", "Romantic_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", Spoggle.Unstable, Spoggle.Yellow, Spoggle.Blue);
            med.AddRandomGroup("ILoveYou_EN", Jumble.Unstable, Jumble.Yellow, Jumble.Red);
            med.AddRandomGroup("ILoveYou_EN", "Scrungie_EN", "Scrungie_EN", "Romantic_EN");
            med.AddRandomGroup("ILoveYou_EN", "Gungrot_EN", "Gungrot_EN", "Gungrot_EN", "Surrogate_EN");

            AddTo hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", "Gungrot_EN", "Gungrot_EN");
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", Spoggle.Unstable);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", Jumble.Unstable);

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "Melder_EN", Jumble.Unstable);
            hard.AddRandomGroup("Errant_EN", "ILoveYou_EN", Flower.Yellow);
            hard.AddRandomGroup("Errant_EN", "ILoveYou_EN", Flower.Purple);

            //garden
            med = new AddTo(Garden.H.Eclipse.Med);
            med.SimpleAddGroup(1, Enemies.Eclipse, 3, "Git_EN");
            med.SimpleAddGroup(1, Enemies.Eclipse, 2, "Attrition_EN");
            med.SimpleAddGroup(1, Enemies.Eclipse, 2, "Bonsai_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 2, "Git_EN");
            hard.SimpleAddGroup(2, Enemies.Eclipse, 2, "Bonsai_EN");
            med.SimpleAddGroup(1, Enemies.Eclipse, 3, "Attrition_EN");
            hard.SimpleAddGroup(2, Enemies.Eclipse, 3, "Surrogate_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(1, "Celebration_EN", 2, "Git_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "Celebration_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(2, "Celebration_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, "Celebration_EN", 1, "Bonsai_EN");

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 2, "Git_EN");
            hard.SimpleAddGroup(2, "Celebration_EN", 2, "Attrition_EN");
            hard.SimpleAddGroup(2, "Celebration_EN", 2, "Bonsai_EN");
            hard.SimpleAddGroup(2, "Celebration_EN", 1, "Git_EN", 1, "Romantic_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, "Bonsai_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(3, "Git_EN", 1, "Lightbulbkin_EN");
            med.SimpleAddGroup(3, "Git_EN", 1, "Celebration_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 1, "Lightbulbkin_EN");
            med.SimpleAddGroup(2, "Attrition_EN", 1, "Celebration_EN", 1, "Surrogate_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Lightbulbkin_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Celebration_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(3, "Bonsai_EN", 1, "Lightbulbkin_EN");
        }
    }
}
