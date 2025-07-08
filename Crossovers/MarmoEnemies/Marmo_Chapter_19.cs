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
        public static void GardenCross()
        {
            AddTo easy = new AddTo(Garden.H.Pawn.Easy);
            easy.SimpleAddGroup(2, "PawnA_EN", 1, "Romantic_EN");
            easy.SimpleAddGroup(3, "PawnA_EN", 1, "Surrogate_EN");

            AddTo med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(4, "PawnA_EN", 1, "Surrogate_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 2, "Romantic_EN");
            med.SimpleAddGroup(2, "Yang_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "Yang_EN", 1, "Git_EN");
            med.SimpleAddGroup(2, "Yang_EN", 1, "Attrition_EN");

            AddTo hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Romantic_EN");
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Surrogate_EN");
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Git_EN");
            hard.SimpleAddGroup(2, "Yang_EN", 2, "Git_EN");
            hard.SimpleAddGroup(2, "Yang_EN", 2, "Attrition_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Hunter_EN", "Romantic_EN");
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Romantic_EN");
            hard.AddRandomGroup("Yin_EN", "Attrition_EN", "Attrition_EN");
            hard.AddRandomGroup("Yin_EN", "ChoirBoy_EN", "Surrogate_EN");
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Romantic_EN", "Romantic_EN");
            hard.AddRandomGroup("Yin_EN", "Git_EN", "Git_EN", "Git_EN");
            hard.AddRandomGroup("Yin_EN", "Yin_EN", "Git_EN");
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Git_EN");
            hard.AddRandomGroup("Yin_EN", Bots.Grey, "Attrition_EN");
            hard.AddRandomGroup("Yin_EN", "Starless_EN", "Surrogate_EN", "Surrogate_EN", "Surrogate_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Attrition_EN", "Attrition_EN");
            med.AddRandomGroup("Starless_EN", "InHisImage_EN", "InHisImage_EN", "Romantic_EN");
            med.AddRandomGroup("Starless_EN", "PawnA_EN", "PawnA_EN", "Surrogate_EN");
            med.AddRandomGroup("Starless_EN", "Attrition_EN", "Git_EN");
            med.AddRandomGroup("Starless_EN", "Git_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("Starless_EN", "Git_EN", Enemies.Minister);
            med.AddRandomGroup("Starless_EN", "EyePalm_EN", "EyePalm_EN", "Romantic_EN");
            med.AddRandomGroup("Starless_EN", "Git_EN", "Firebird_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Attrition_EN", "Attrition_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "Attrition_EN");
            hard.AddRandomGroup("Eyeless_EN", "Git_EN", "Git_EN", "Git_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "Git_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "Romantic_EN", "Romantic_EN");
            hard.AddRandomGroup("Eyeless_EN", "MiniReaper_EN", "Surrogate_EN", "Surrogate_EN");
            hard.AddRandomGroup("Eyeless_EN", "BlackStar_EN", "Git_EN", "Git_EN");
            hard.AddRandomGroup("Eyeless_EN", "EvilDog_EN", "EvilDog_EN", "Romantic_EN");
            hard.AddRandomGroup("Eyeless_EN", Bots.Grey, "Damocles_EN", "Romantic_EN");
            hard.AddRandomGroup("Eyeless_EN", "PawnA_EN", "PawnA_EN", "Romantic_EN");
            hard.AddRandomGroup("Eyeless_EN", "Indicator_EN", "Git_EN", "Git_EN");

            easy = new AddTo(Garden.H.Git.Easy);
            easy.SimpleAddGroup(2, "Git_EN", 2, "PawnA_EN");
            easy.SimpleAddGroup(2, "Git_EN", 1, "PawnA_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(2, "Git_EN", 3, "PawnA_EN");
            med.SimpleAddGroup(3, "Git_EN", 1, "PawnA_EN");

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.SimpleAddGroup(2, "Attrition_EN", 1, "PawnA_EN");
            easy.SimpleAddGroup(1, "Attrition_EN", 2, "PawnA_EN");

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(2, "Attrition_EN", 2, "PawnA_EN");
            med.SimpleAddGroup(3, "Attrition_EN", 1, "PawnA_EN");
            med.AddRandomGroup("Attrition_EN", "Attrition_EN", "Starless_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 3, "PawnA_EN", 1, "Romantic_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "PawnA_EN", "PawnA_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "PawnA_EN", "PawnA_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "Romantic_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Attrition_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "Git_EN", "PawnA_EN", "Git_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Attrition_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "PawnA_EN", "PawnA_EN", "Romantic_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Starless_EN", "Romantic_EN");
            med.AddRandomGroup("Stoplight_EN", "Yang_EN", "Attrition_EN");
            med.AddRandomGroup("Stoplight_EN", "Surrogate_EN", "PawnA_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Starless_EN", "Romantic_EN");
            hard.AddRandomGroup(Enemies.Tank, "Yang_EN", "Git_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Eyeless_EN", "Attrition_EN", "Attrition_EN");
            hard.AddRandomGroup("ClockTower_EN", "Git_EN", "Yang_EN", "Yang_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Git_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Attrition_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Yang_EN", "Git_EN");
            med.AddRandomGroup("PersonalAngel_EN", "PawnA_EN", "PawnA_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Starless_EN", "Romantic_EN");
        }
    }
}
