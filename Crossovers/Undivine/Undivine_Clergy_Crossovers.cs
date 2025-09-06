using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Undivine_Clergy_Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Orph.H.Clergy.Med);
            med.SimpleAddGroup(1, "Clergy_EN", 3, "Enigma_EN");
            med.AddRandomGroup("Clergy_EN", "Something_EN", Jumble.Blue);
            med.AddRandomGroup("Clergy_EN", "TheCrow_EN", "Freud_EN");
            med.AddRandomGroup("Clergy_EN", Enemies.Camera, Enemies.Camera, "LostSheep_EN");

            AddTo hard = new AddTo(Orph.H.Clergy.Hard);
            hard.AddRandomGroup("Clergy_EN", "Clergy_EN", "TheCrow_EN", "MusicMan_EN");
            hard.AddRandomGroup("Clergy_EN", "Freud_EN", Jumble.Purple, Jumble.Blue);

            med.AddRandomGroup("Clergy_EN", "Delusion_EN", "Delusion_EN");
            med.AddRandomGroup("Clergy_EN", Flower.Yellow, Flower.Purple);
            med.AddRandomGroup("Clergy_EN", "WindSong_EN", "Scrungie_EN");
            med.AddRandomGroup("Clergy_EN", Enemies.Solvent, "MusicMan_EN", "MusicMan_EN");

            hard.AddRandomGroup("Clergy_EN", Spoggle.Red, Spoggle.Purple, "Sigil_EN");

            med.AddRandomGroup("Clergy_EN", "Spectre_EN", "Spectre_EN", "Spectre_EN", "Spectre_EN");

            med.AddRandomGroup("Clergy_EN", "Rabies_EN", "Rabies_EN");

            med.AddRandomGroup("Clergy_EN", Bots.Red, Bots.Yellow);
            med.AddRandomGroup("Clergy_EN", Bots.Blue, Bots.Purple);

            hard.AddRandomGroup("Clergy_EN", "Crystal_EN", "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomGroup("Clergy_EN", "Evileye_EN", "Clergy_EN");
            hard.AddRandomGroup("Clergy_EN", "YellowAngel_EN", "Enigma_EN", "Enigma_EN");

            med.AddRandomGroup("Clergy_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomGroup("Clergy_EN", "MusicMan_EN", "WindSong_EN");
            med.AddRandomGroup("Clergy_EN", "Solitaire_EN", "Solitaire_EN");

            hard.AddRandomGroup("Clergy_EN", "Wednesday_EN", "Scrungie_EN", "Scrungie_EN");
            hard.AddRandomGroup("Clergy_EN", "Solitaire_EN", "Solitaire_EN", "Solitaire_EN");
            hard.AddRandomGroup("Clergy_EN", "Clergy_EN", "Author_EN");

            med.AddRandomGroup("Clergy_EN", Jumble.Blue, "Foxtrot_EN", "Foxtrot_EN");

            hard.AddRandomGroup("Clergy_EN", Enemies.Shooter, "Clergy_EN", Spoggle.Red);
            hard.AddRandomGroup("Clergy_EN", Bots.Yellow, "Freud_EN", "LostSheep_EN");
            hard.AddRandomGroup("Clergy_EN", "TheCrow_EN", "Author_EN", "Author_EN");


            //other
            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Clergy_EN", Jumble.Blue, Enemies.Suckle, Enemies.Suckle);

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Clergy_EN", "Clergy_EN");
        }
    }
}
