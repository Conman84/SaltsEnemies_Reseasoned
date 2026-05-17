using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    //ClayChild_EN
    //ClayChildSleep_EN

    //Clergy_EN (pretty strong)
    //Sonoduct_EN (70 red, 2 size)
    public static class UndivineCrossovers
    {
        public static void Add1_4()
        {
            AddTo easy = new AddTo(Orph.H.ClayChild.Easy);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup("ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN", "LostSheep_EN");
            if (SaltsReseasoned.trolling < 50) easy.AddRandomGroup("ClayChild_EN", "ClayChildSleep_EN", "Enigma_EN");

            AddTo med = new AddTo(Orph.H.ClayChild.Med);
            if (SaltsReseasoned.trolling > 50) easy.AddRandomGroup("ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN", "Enigma_EN");

            easy = new AddTo(Orph.H.Something.Easy);
            easy.AddRandomGroup("Something_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "ClayChildSleep_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "ClayChild_EN", "ClayChild_EN");
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Enemies.Camera, "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");
        }

        public static void Add6_8()
        {
            AddTo easy = new AddTo(Orph.H.Delusion.Easy);
            easy.AddRandomGroup("Delusion_EN", "ClayChild_EN", "ClayChildSleep_EN");

            AddTo med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "ClayChild_EN", "ClayChildSleep_EN");

            easy = new AddTo(Orph.H.Flower.Yellow.Easy);
            easy.AddRandomGroup(Flower.Yellow, "ClayChild_EN", "ClayChild_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            easy = new AddTo(Orph.H.ClayChild.Easy);
            if (SaltsReseasoned.silly < 50) easy.AddRandomGroup("ClayChild_EN", "ClayChild_EN", Enemies.Solvent);
        }

        public static void Add9_12()
        {
            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "ClayChild_EN", "ClayChildSleep_EN");

            AddTo med = new AddTo(Orph.H.ClayChild.Med);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN", "Spectre_EN");

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");
        }
        
        public static void Add13_16()
        {
            AddTo med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, "ClayChild_EN", "ClayChild_EN", "ClayChild_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Yellow, "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Purple, "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            AddTo hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.ClayChild.Med);
            if (SaltsReseasoned.rando < 75) med.AddRandomGroup("ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN", "TortureMeNot_EN");
        }

        public static void Add17_18()
        {
            AddTo med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "ClayChildSleep_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            AddTo easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, "ClayChild_EN", "ClayChild_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");
        }

        public static void Add19_21()
        {
            AddTo med = new AddTo(Orph.H.ClayChild.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Wednesday_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Wednesday_EN", "ClayChild_EN", "ClayChild_EN", "ClayChild_EN", "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "ClayChild_EN", "ClayChild_EN");

            AddTo easy = new AddTo(Orph.H.ClayChild.Easy);
            if (SaltsReseasoned.rando < 75) easy.AddRandomGroup("Foxtrot_EN", "ClayChild_EN", "ClayChild_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "ClayChild_EN", "ClayChildSleep_EN", "ClayChildSleep_EN");

            EcstasyPool.Add("ClayChild_EN");
            EcstasyPool.Add("ClayChildSleep_EN");
            EcstasyPool.Add("Clergy_EN");
            EcstasyPool.Add("Sonoduct_EN");
        }
    }
}
