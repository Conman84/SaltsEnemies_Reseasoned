using System;
using System.Collections.Generic;
using System.Text;

//Bullet_EN
//HatTrick_EN
//Misnomer_EN

//Showstopper_EN
//Tableau_EN

namespace SaltsEnemies_Reseasoned
{
    public static class FreakFoes_SecondSet
    {
        public static void AddShore()
        {
            AddTo med = new AddTo(Shore.H.Bullet.Med);
            med.SimpleAddGroup(1, "Bullet_EN", 3, "Waltz_EN");
            med.AddRandomGroup("Bullet_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup("Bullet_EN", "ToyUfo_EN", Jumble.Yellow);
            med.AddRandomGroup("Bullet_EN", "DeadPixel_EN", "DeadPixel_EN", "MudLung_EN");
            med.AddRandomGroup("Bullet_EN", "2009_EN", "Papereater_EN");
            med.AddRandomGroup("Bullet_EN", "Papereater_EN", "MudLung_EN");
            med.AddRandomGroup("Bullet_EN", Jumble.Red, "Hauntling_EN");

            AddTo easy = new AddTo(Shore.H.Misnomer.Easy);
            easy.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "Windle_EN");
            easy.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "Arceles_EN");
            easy.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "LostSheep_EN");
            easy.SimpleAddGroup(1, "Misnomer_EN", 2, "TortureMeNot_EN");

            med = new AddTo(Shore.H.Misnomer.Med);
            med.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "Pinano_EN");
            med.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "ToyUfo_EN");
            med.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "2009_EN");
            med.AddRandomGroup("Misnomer_EN", "Misnomer_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Misnomer_EN", Jumble.Yellow);
            med.AddRandomGroup("AFlower_EN", "Misnomer_EN", "Papereater_EN");
            med.AddRandomGroup("AFlower_EN", "Bullet_EN", "Keko_EN", "Keko_EN");
            med.AddRandomGroup("AFlower_EN", "HatTrick_EN", "Wall_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Misnomer_EN", Jumble.Yellow, Jumble.Red);
            hard.AddRandomGroup("AFlower_EN", "Misnomer_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("AFlower_EN", "Bullet_EN", "ToyUfo_EN");
            hard.AddRandomGroup("AFlower_EN", "HatTrick_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Misnomer_EN", "Misnomer_EN");
            hard.AddRandomGroup("Tripod_EN", "Bullet_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomGroup("Tripod_EN", "HatTrick_EN", "ToyUfo_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Misnomer_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Bullet_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "Bullet_EN", "Minana_EN");
            med.AddRandomGroup("Pinano_EN", "Papereater_EN", "Misnomer_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "ToyUfo_EN", "HatTrick_EN");
            med.AddRandomGroup("ToyUfo_EN", "Misnomer_EN", "Papereater_EN");
            med.AddRandomGroup("ToyUfo_EN", "Bullet_EN", "Pinano_EN");
            med.AddRandomGroup("ToyUfo_EN", Spoggle.Yellow, "Misnomer_EN");

            med = new AddTo(Shore.H.Wall.Med);
            med.SimpleAddGroup(3, "Wall_EN", 1, "HatTrick_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Misnomer_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Misnomer_EN", "NobodyGrave_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Misnomer_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup("Unmung_EN", "Misnomer_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.SimpleAddGroup(1, Enemies.Camera, 3, "Misnomer_EN");
            hard.AddRandomGroup(Enemies.Camera, Enemies.Mungling, "HatTrick_EN");
            hard.AddRandomGroup(Enemies.Camera, "MudLung_EN", "MudLung_EN", "Bullet_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Misnomer_EN", "Misnomer_EN", "NobodyGrave_EN");
            med.AddRandomGroup("LittleBeak_EN", "Bullet_EN", Enemies.Mungling);
            med.AddRandomGroup("LittleBeak_EN", "Misnomer_EN", "2009_EN");
            med.AddRandomGroup("LittleBeak_EN", "HatTrick_EN", "Wall_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Misnomer_EN", "Misnomer_EN", Spoggle.Blue);
            hard.AddRandomGroup("Warbird_EN", "Misnomer_EN", "Misnomer_EN", "Bullet_EN");
            hard.AddRandomGroup("Warbird_EN", "Misnomer_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Warbird_EN", "HatTrick_EN", Jumble.Red, Jumble.Yellow);
            hard.AddRandomGroup("Warbird_EN", "HatTrick_EN", "Sinker_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Misnomer_EN", "Misnomer_EN");
            med.AddRandomGroup("Clione_EN", "Misnomer_EN", "Wall_EN");
            med.AddRandomGroup("Clione_EN", "Bullet_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("Clione_EN", "Bullet_EN", "ToyUfo_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Misnomer_EN", "Misnomer_EN", "Misnomer_EN");
            hard.AddRandomGroup("Clione_EN", "Misnomer_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Clione_EN", "Bullet_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Clione_EN", "HatTrick_EN", "AFlower_EN");
            hard.AddRandomGroup("Clione_EN", "HatTrick_EN", "Keko_EN", "Keko_EN", "Keko_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Misnomer_EN", "MudLung_EN");
            med.AddRandomGroup("Sinker_EN", "Misnomer_EN", "Flarblet_EN");
            med.AddRandomGroup("Sinker_EN", "Bullet_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("Sinker_EN", "HatTrick_EN", "Jabberwocky_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "Misnomer_EN", "Misnomer_EN", "Flarblet_EN");
            hard.AddRandomGroup("Sinker_EN", "Misnomer_EN", "Jabberwocky_EN");
            hard.AddRandomGroup("Sinker_EN", "Bullet_EN", "Papereater_EN", "Papereater_EN");
            hard.AddRandomGroup("Sinker_EN", "HatTrick_EN", "AFlower_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Misnomer_EN", "MudLung_EN");
            med.AddRandomGroup("2009_EN", "Misnomer_EN", Jumble.Unstable);
            med.AddRandomGroup("2009_EN", "Bullet_EN", "Keko_EN", "Keko_EN");
            med.AddRandomGroup("2009_EN", "Bullet_EN", "ToyUfo_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "Misnomer_EN", "Misnomer_EN", "Misnomer_EN");
            hard.AddRandomGroup("33_EN", "Bullet_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomGroup("33_EN", "HatTrick_EN", "HatTrick_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Bullet_EN", "Waltz_EN");
            hard.AddRandomGroup("Clown_EN", "Bullet_EN", "Flarblet_EN");
            hard.AddRandomGroup("Clown_EN", "HatTrick_EN");
            hard.AddRandomGroup("Clown_EN", "Misnomer_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.SimpleAddGroup(2, "VoiceTrumpet_EN", 1, "HatTrick_EN");

            med = new AddTo(Shore.H.Hauntling.Med);
            med.AddRandomGroup("Hauntling_EN", "Hauntling_EN", "Misnomer_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", "Misnomer_EN", "Misnomer_EN");
            med.AddRandomGroup("Jabberwocky_EN", "Bullet_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("Jabberwocky_EN", "HatTrick_EN", "Pinano_EN");

            med = new AddTo(Shore.H.Papereater.Med);
            med.AddRandomGroup("Papereater_EN", "Papereater_EN", "Misnomer_EN");
            med.AddRandomGroup("Papereater_EN", "Papereater_EN", "Misnomer_EN", "Misnomer_EN");
        }
        public static void AddOrph()
        {
            AddTo med = new AddTo(Orph.H.Showstopper.Med);
            med.AddRandomGroup("Showstopper_EN", "Showstopper_EN", "Enigma_EN", "LostSheep_EN");
            med.AddRandomGroup("Showstopper_EN", "Showstopper_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Showstopper_EN", "Showstopper_EN", "Scrungie_EN", "Sigil_EN");
            med.AddRandomGroup("Showstopper_EN", "Showstopper_EN", Bots.Red);
            med.AddRandomGroup("Showstopper_EN", "Showstopper_EN", "Rabies_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Showstopper_EN", "Showstopper_EN");
            med.AddRandomGroup("Something_EN", "Showstopper_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Something_EN", "Showstopper_EN", Bots.Blue);
            med.AddRandomGroup("Something_EN", "Showstopper_EN", "Insider_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Showstopper_EN");
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Showstopper_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Showstopper_EN", "Showstopper_EN");
            med.AddRandomGroup("Evileye_EN", "Showstopper_EN", Enemies.Shooter);
            med.AddRandomGroup("Evileye_EN", "Showstopper_EN", "TheCrow_EN");
            med.AddRandomGroup("Evileye_EN", "Showstopper_EN", "Nume_EN");
            med.AddRandomGroup("Evileye_EN", "Showstopper_EN", "Insider_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Showstopper_EN", "LostSheep_EN", "LostSheep_EN");
            med.AddRandomGroup("TheCrow_EN", "Showstopper_EN", Spoggle.Red);
            med.AddRandomGroup("TheCrow_EN", "Showstopper_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Showstopper_EN", "Showstopper_EN");
            med.AddRandomGroup("Freud_EN", "Showstopper_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Freud_EN", "Showstopper_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Showstopper_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "Showstopper_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup(Flower.Yellow, "Showstopper_EN", "Scrungie_EN");
            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "Showstopper_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup(Flower.Purple, "Showstopper_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "MusicMan_EN", "Showstopper_EN");
            med.AddRandomGroup("WindSong_EN", "Showstopper_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup("WindSong_EN", "Showstopper_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", "Showstopper_EN", Spoggle.Red);
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", "Showstopper_EN", "Scrungie_EN");
            med.AddRandomGroup("Nameless_EN", "Nameless_EN", "Showstopper_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Showstopper_EN", "Showstopper_EN");
            med.AddRandomGroup("Maw_EN", "Showstopper_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Maw_EN", "Showstopper_EN", "Something_EN");
            med.AddRandomGroup("Maw_EN", "Showstopper_EN", "Melder_EN");

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Showstopper_EN", "Showstopper_EN", Bots.Red);
            hard.AddRandomGroup("Maw_EN", 'Showstopper_EN', "Solitaire_EN", "Solitaire_EN");
            hard.AddRandomGroup("Maw_EN", "Showstopper_EN", "Showstopper_EN", "Melder_EN");
            hard.AddRandomGroup("Maw_EN", "Showstopper_EN", "Showstopper_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Showstopper_EN", "Scrungie_EN");
            med.AddRandomGroup("Crystal_EN", "Showstopper_EN", "Something_EN");
            med.AddRandomGroup("Crystal_EN", "Showstopper_EN", "Freud_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Showstopper_EN", Bots.Red);
            hard.AddRandomGroup("TheDragon_EN", "Showstopper_EN", "Evileye_EN");
            hard.AddRandomGroup("TheDragon_EN", "Tableau_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Showstopper_EN", Spoggle.Red);
            med.AddRandomGroup("YellowAngel_EN", "Showstopper_EN", "LostSheep_EN", "LostSheep_EN");
            med.AddRandomGroup("YellowAngel_EN", "Showstopper_EN", "Something_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Showstopper_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Wednesday_EN", "Showstopper_EN", "TheWhale_EN", "TheWhale_EN");
            med.AddRandomGroup("Wednesday_EN", "Showstopper_EN", "Scrungie_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(2, "Solitaire_EN", 1, "Showstopper_EN", 1, Enemies.Solvent);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "Showstopper_EN", "LostSheep_EN");
            med.AddRandomGroup("Author_EN", "Author_EN", "Showstopper_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "Showstopper_EN", "Scrungie_EN");
            med.AddRandomGroup("Nume_EN", "Showstopper_EN", Spoggle.Red);
            med.AddRandomGroup("Nume_EN", "Showstopper_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Whale.Med);
            med.AddRandomGroup("TheWhale_EN", "TheWhale_EN", "Showstopper_EN", "Nameless_EN");
            med.AddRandomGroup("TheWhale_EN", "TheWhale_EN", "Showstopper_EN", "Romantic_EN");
            med.AddRandomGroup("TheWhale_EN", "TheWhale_EN", "Showstopper_EN", "Enigma_EN");
            if (SaltsReseasoned.rando < 10) med.AddRandomGroup("TheWhale_EN", "TheWhale_EN", "Showstopper_EN", "Spectre_EN");
            med.AddRandomGroup("TheWhale_EN", "TheWhale_EN", "Showstopper_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "Showstopper_EN");
            med.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "Crystal_EN");
            med.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "Solitaire_EN");
            med.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "Nume_EN");
            med.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "Insider_EN");

            hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, "Showstopper_EN");
            hard.SimpleAddGroup(1, "ILoveYou_EN", 3, "Showstopper_EN");
            hard.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomGroup("ILoveYou_EN", "Showstopper_EN", "TheWhale_EN", "TheWhale_EN");

            hard = new AddTo(Orph.H.Tableau.Hard);
            hard.AddRandomGroup("Tableau_EN", "Something_EN", "Something_EN");
            if (SaltsReseasoned.silly < 33) hard.AddRandomGroup("Tableau_EN", "TheWhale_EN", "TheWhale_EN", "Nameless_EN");
            else if (SaltsReseasoned.silly < 67) hard.AddRandomGroup("Tableau_EN", "MusicMan_EN", "MusicMan_EN", "Wednesday_EN");
            else hard.AddRandomGroup("Tableau_EN", "MusicMan_EN", "MusicMan_EN", "Nameless_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Tableau_EN", "Insider_EN", "Scrungie_EN");
            else hard.AddRandomGroup("Tableau_EN", "Nume_EN", "Scrungie_EN");
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Tableau_EN", "Melder_EN", Spoggle.Red);
            hard.AddRandomGroup("Tableau_EN", "Solitaire_EN", "Solitaire_EN", Enemies.Solvent);
            hard.AddRandomGroup("Tableau_EN", Enemies.Camera, Enemies.Camera, Jumble.Red);
            if (SaltsReseasoned.silly <= 50) hard.AddRandomGroup("Tableau_EN", "Crystal_EN", Spoggle.Red);
            if (SaltsReseasoned.rando < 50) hard.AddRandomGroup("Tableau_EN", "Showstopper_EN", "Evileye_EN");
            else hard.AddRandomGroup("Tableau_EN", "Evileye_EN", "YellowAngel_EN");
            if (SaltsReseasoned.rando > 50) hard.AddRandomGroup("Tableau_EN", "Author_EN", "Author_EN", "Spectre_EN");
            else hard.AddRandomGroup("Tableau_EN", "Solitaire_EN", "Solitaire_EN", "Enigma_EN");
            if (SaltsReseasoned.trolling < 50) hard.SimpleAddGroup(1, "Tableau_EN", 4, "Enigma_EN");
            else hard.AddRandomGroup("Tableau_EN", "Maw_EN", Enemies.Shooter);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("Tableau_EN", "TheCrow_EN", "Scrungie_EN");
            else hard.AddRandomGroup("Tableau_EN", "Freud_EN", "Showstopper_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("Tableau_EN", Bots.Red, Bots.Yellow, Bots.Blue);
            else hard.AddRandomGroup("Tableau_EN", Bots.Red, Bots.Yellow, Bots.Purple);
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Tableau_EN", Flower.Yellow, "MusicMan_EN", "MusicMan_EN");
            else hard.AddRandomGroup("Tableau_EN", Flower.Purple, "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomGroup("Tableau_EN", "ILoveYou_EN", "Foxtrot_EN", "Foxtrot_EN");
            if (SaltsReseasoned.rando > 50) hard.AddRandomGroup("Tableau_EN", "MusicMan_EN", "MusicMan_EN", "WindSong_EN");
            else hard.AddRandomGroup("Tableau_EN", "MusicMan_EN", "MusicMan_EN", "Melder_EN");
        }
    }
}
