using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Teratoma_Cross
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Teratoma.Med);
            med.SimpleAddGroup(2, "Teratoma_EN", 2, "LostSheep_EN");
            med.AddRandomGroup("Teratoma_EN", "Teratoma_EN", "Enigma_EN", "Enigma_EN");
            med.SimpleAddGroup(2, "Teratoma_EN", 1, "Wednesday_EN", 2, "SingingStone_EN");
            med.SimpleAddGroup(2, "Teratoma_EN", 3, "TortureMeNot_EN");

            med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "Teratoma_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", "Teratoma_EN");
            med.AddRandomGroup("Sigil_EN", "Solitaire_EN", "Solitaire_EN", "Teratoma_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Teratoma_EN");
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Teratoma_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Teratoma_EN");
            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Teratoma_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Teratoma_EN", "Nameless_EN");
            med.AddRandomGroup("Evileye_EN", "Teratoma_EN", Flower.Yellow);
            med.AddRandomGroup("Evileye_EN", "Teratoma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.SimpleAddGroup(2, Enemies.Shooter, 1, "Teratoma_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Teratoma_EN", Flower.Purple);
            med.AddRandomGroup("Something_EN", "Teratoma_EN", "TheWhale_EN");
            med.AddRandomGroup("Something_EN", "Teratoma_EN", Bots.Blue);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Teratoma_EN", "Solitaire_EN");
            med.AddRandomGroup("TheCrow_EN", "Teratoma_EN", Enemies.Feaster, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Teratoma_EN", "Nume_EN");
            med.AddRandomGroup("Freud_EN", "Teratoma_EN", Enemies.Camera);

            med = new AddTo(Orph.H.Camera.Med);
            med.SimpleAddGroup(3, Enemies.Camera, 1, "Teratoma_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Teratoma_EN");
            med.AddRandomGroup(Flower.Yellow, "Teratoma_EN", "Scrungie_EN");
            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Teratoma_EN");
            med.AddRandomGroup(Flower.Purple, "Teratoma_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Teratoma_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("WindSong_EN", "Teratoma_EN", "Foxtrot_EN", "Foxtrot_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Teratoma_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.SimpleAddGroup(2, "Nameless_EN", 2, "Teratoma_EN");
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", "Teratoma_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Teratoma_EN", "Teratoma_EN");
            med.AddRandomGroup("Maw_EN", "Teratoma_EN", Bots.Purple);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Teratoma_EN", "Solitaire_EN", "Solitaire_EN");
            hard.AddRandomGroup("Maw_EN", "Teratoma_EN", "TheWhale_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Teratoma_EN", "Teratoma_EN");
            med.AddRandomGroup("Crystal_EN", "Teratoma_EN", "Melder_EN");
            med.AddRandomGroup("Crystal_EN", "Teratoma_EN", "Something_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Teratoma_EN", "Teratoma_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Teratoma_EN", "Teratoma_EN");
            med.AddRandomGroup("YellowAngel_EN", "Teratoma_EN", 'Scrungie_EN');
            med.AddRandomGroup("YellowAngel_EN", "Teratoma_EN", "TheCrow_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Teratoma_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, "Teratoma_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.SimpleAddGroup(3, "Author_EN", 1, "Teratoma_EN");
            med.AddRandomGroup("Author_EN", "Author_EN", "Teratoma_EN", "Surrogate_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Insider.Med);
            med.SimpleAddGroup(2, "Insider_EN", 1, "Teratoma_EN");

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "Teratoma_EN", "Teratoma_EN");
            med.AddRandomGroup("Nume_EN", "Teratoma_EN", "Evileye_EN");
            med.AddRandomGroup("Nume_EN", "Teratoma_EN", Enemies.Camera);

            med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(3, "TheWhale_EN", 1, "Teratoma_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", "Teratoma_EN", Jumble.Blue);
            med.AddRandomGroup("ILoveYou_EN", "Teratoma_EN", "Nameless_EN");

            hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.AddRandomGroup("ILoveYou_EN", "ILoveYou_EN", "Teratoma_EN");
            hard.AddRandomGroup("ILoveYou_EN", "Teratoma_EN", Enemies.Camera, Enemies.Camera);
        }
    }
}
