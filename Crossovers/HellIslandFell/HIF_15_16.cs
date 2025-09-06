using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class HIF_15_16
    {
        public static void CrossoversShore()
        {
            AddTo easy = new AddTo(Shore.H.Draugr.Easy);
            easy.AddRandomGroup("Draugr_EN", "TortureMeNot_EN", "TortureMeNot_EN");
        }
        public static void CrossoversOrph()
        {
            AddTo med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Moone_EN", "Moone_EN");
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Moone_EN", "Moone_EN");
            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Moone_EN", "Moone_EN");
            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Moone_EN", "Moone_EN");

            AddTo easy = new AddTo(Orph.H.Moone.Easy);
            easy.AddRandomGroup("Moone_EN", "Moone_EN", Bots.Yellow);
            easy.AddRandomGroup("Moone_EN", "Moone_EN", Bots.Red);

            med = new AddTo(Orph.H.Moone.Med);
            med.AddRandomGroup("Moone_EN", "Moone_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Moone_EN", "Moone_EN", Bots.Blue);
            med.AddRandomGroup("Moone_EN", "Moone_EN", Bots.Purple);

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Thunderdome_EN", "Thunderdome_EN", Bots.Red);

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Moone_EN", "Moone_EN");
            med.AddRandomGroup("Crystal_EN", "Thunderdome_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Heehoo_EN", Bots.Blue, Bots.Purple);

            AddTo hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", Bots.Red);
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", Bots.Yellow);
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", Bots.Blue);
            hard.AddRandomGroup("Heehoo_EN", "Heehoo_EN", Bots.Purple);
            hard.AddRandomGroup("Heehoo_EN", "Crystal_EN", "Scrungie_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Thunderdome_EN", "Thunderdome_EN");
            hard.AddRandomGroup("TheDragon_EN", "Moone_EN", "Moone_EN", "LostSheep_EN");
            hard.AddRandomGroup("TheDragon_EN", "Moone_EN", "Moone_EN", Jumble.Unstable);
            hard.AddRandomGroup("TheDragon_EN", "Heehoo_EN", "Enigma_EN", "Enigma_EN");
            hard.AddRandomGroup("TheDragon_EN", "Heehoo_EN", "MusicMan_EN");


        }
        public static void CrossoversGarden()
        {
            AddTo med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", Noses.Red, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Noses.Yellow, "Damocles_EN", "Damocles_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Noses.Purple, "ChoirBoy_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Noses.Blue, "Hunter_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Noses.Grey, "MiniReaper_EN", "NextOfKin_EN", "NextOfKin_EN");
        }
    }
}
