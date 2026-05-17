using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DevoutCrossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Devout.Med);
            med.AddRandomGroup("Devout_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Devout_EN", "MusicMan_EN", "MusicMan_EN", "LostSheep_EN");
            med.AddRandomGroup("Devout_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Devout_EN", Flower.Yellow, "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Devout_EN", Flower.Purple, "Something_EN");
            med.AddRandomGroup("Devout_EN", Enemies.Shooter, Enemies.Solvent);
            med.AddRandomGroup("Devout_EN", "Devout_EN", "LostSheep_EN");
            med.AddRandomGroup("Devout_EN", "TheWhale_EN", Spoggle.Yellow);
            med.AddRandomGroup("Devout_EN", "Solitaire_EN", "Scrungie_EN");
            med.AddRandomGroup("Devout_EN", "Nameless_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomGroup("Devout_EN", "WindSong_EN", "MusicMan_EN", Enemies.Suckle);
            med.AddRandomGroup("Devout_EN", Enemies.Feaster, "Enigma_EN");
            med.AddRandomGroup("Devout_EN", "Sigil_EN", "Scrungie_EN", "Scrungie_EN");
            med.AddRandomGroup("Devout_EN", "Rabies_EN", "Romantic_EN");
            med.AddRandomGroup("Devout_EN", Jumble.Red, Enemies.Camera, Enemies.Camera);
            med.AddRandomGroup("Devout_EN", "Nume_EN", "Scrungie_EN");
            med.AddRandomGroup("Devout_EN", "Author_EN", Jumble.Red);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Devout_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomGroup("Evileye_EN", "Devout_EN", Enemies.Suckle);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Devout_EN", "Enigma_EN");
            med.AddRandomGroup("TheCrow_EN", "Devout_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Devout_EN", "Solitaire_EN");
            med.AddRandomGroup("Freud_EN", "Devout_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Devout_EN");
            med.AddRandomGroup("Maw_EN", "Devout_EN");

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Devout_EN", "Foxtrot_EN");
            hard.AddRandomGroup("Maw_EN", "Devout_EN", Flower.Yellow);
            hard.AddRandomGroup("Maw_EN", "Devout_EN", "Wednesday_EN");
            hard.AddRandomGroup("Maw_EN", "Devout_EN", "TheWhale_EN");
            hard.AddRandomGroup("Maw_EN", "Devout_EN", "Scrungie_EN");
            hard.AddRandomGroup("Maw_EN", "Devout_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Devout_EN", "LostSheep_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Devout_EN", "Devout_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Devout_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("YellowAngel_EN", "Devout_EN", Bots.Red);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "Devout_EN");

            EcstasyPool.Add("Devout_EN");


            
        }
    }
}
