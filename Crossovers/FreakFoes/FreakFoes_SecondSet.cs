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
            
        }
    }
}
