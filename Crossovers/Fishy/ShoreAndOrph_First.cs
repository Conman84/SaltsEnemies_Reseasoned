using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Fishy_ShoreAndOrph_First
    {
        public static void Add()
        {
            AddShore();
            AddOrph();
        }

        public static void AddShore()
        {
            AddTo med = new AddTo(Shore.H.Zucchini.Med);
            med.AddRandomGroup(Enemies.Zucchini, "ToyUfo_EN", "Windle_EN");
            med.AddRandomGroup(Enemies.Zucchini, "Pinano_EN");
            med.AddRandomGroup(Enemies.Zucchini, "MudLung_EN", "LostSheep_EN");
            med.AddRandomGroup(Enemies.Zucchini, "Wall_EN", "Arceles_EN");
            med.AddRandomGroup(Enemies.Zucchini, "2009_EN", "Windle_EN");
            med.AddRandomGroup(Enemies.Zucchini, "Skyloft_EN", "Pinano_EN");
            med.AddRandomGroup(Enemies.Zucchini, "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Enemies.Zucchini, "Jabberwocky_EN");
            med.AddRandomGroup(Enemies.Zucchini, "Papereater_EN", "LostSheep_EN");

            AddTo hard = new AddTo(Shore.H.Zucchini.Hard);
            hard.AddRandomGroup(Enemies.Zucchini, "Papereater_EN", "MudLung_EN");
            hard.AddRandomGroup(Enemies.Zucchini, "Sinker_EN", "Skyloft_EN");
            hard.AddRandomGroup(Enemies.Zucchini, "LittleBeak_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.WhaleHead.Med);
            med.SimpleAddGroup(2, Enemies.Whalehead, 1, "LostSheep_EN");


            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Enemies.Zucchini);
            med.AddRandomGroup("AFlower_EN", Enemies.Whalehead, Jumble.Yellow);

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", Enemies.Zucchini, "Papereater_EN");
            hard.AddRandomGroup("AFlower_EN", "ToyUfo_EN", Enemies.Whalehead);

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", Enemies.Whalehead);

            med = new AddTo(Shore.H.Wall.Med);
            med.SimpleAddGroup(3, "Wall_EN", 1, Enemies.Whalehead);

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, Enemies.Whalehead, 1, "MudLung_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Zucchini, "Windle_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, Enemies.Whalehead);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Enemies.Whalehead, "Pinano_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Enemies.Zucchini, "Flarblet_EN");
            hard.AddRandomGroup("Warbird_EN", Enemies.Whalehead, "2009_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Enemies.Zucchini);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", Enemies.Whalehead, "Sinker_EN");
            hard.AddRandomGroup("Clione_EN", Enemies.Zucchini, "MudLung_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", Enemies.Zucchini);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", Enemies.Zucchini, "Papereater_EN");
            hard.AddRandomGroup("Sinker_EN", Enemies.Whalehead, "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", Enemies.Whalehead, Jumble.Red);

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", Enemies.Whalehead, Enemies.Whalehead);

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", Enemies.Whalehead);

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", Enemies.Whalehead, "MudLung_EN");
        }
        public static void AddOrph()
        {
            AddTo med = new AddTo(Orph.H.WhaleHead.Med);
            med.SimpleAddGroup(2, Enemies.Whalehead, 2, "Foxtrot_EN");
            med.SimpleAddGroup(2, Enemies.Whalehead, 2, "Enigma_EN");

            med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, Enemies.Whalehead);

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Enemies.Whalehead, Jumble.Purple);

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Whalehead);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Enemies.Whalehead, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Maw_EN", Enemies.Whalehead, "Freud_EN");

            AddTo hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Enemies.Whalehead, "Solitaire_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Whalehead);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", Enemies.Whalehead, "Scrungie_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Whalehead);

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, Enemies.Whalehead);

            med = new AddTo(Orph.H.Author.Med);
            med.SimpleAddGroup(2, "Author_EN", 1, Enemies.Whalehead, 1, Jumble.Red);

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", Enemies.Whalehead, "Freud_EN");

            med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Enemies.Whalehead, 1, Enemies.Solvent);

            med = new AddTo(Orph.H.Melder.Med);
            med.AddRandomGroup("Melder_EN", "Melder_EN", Enemies.Whalehead, "LostSheep_EN");

            med = new AddTo(Orph.H.ILoveYou.Med);
            med.AddRandomGroup("ILoveYou_EN", Enemies.Whalehead, "Enigma_EN", "Enigma_EN");

            hard = new AddTo(Orph.H.ILoveYou.Hard);
            hard.SimpleAddGroup(2, "ILoveYou_EN", 1, Enemies.Whalehead);
        }
    }
}
