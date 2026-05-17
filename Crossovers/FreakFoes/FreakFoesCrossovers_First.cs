using System;
using System.Collections.Generic;
using System.Text;

//LockJaw_EN
//Beachcomber_EN
//Wavebreaker_EN

namespace SaltsEnemies_Reseasoned
{
    public static class FreakFoesCrossovers_First
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Shore.H.Lockjaw.Easy);
            easy.AddRandomGroup("LockJaw_EN", "Waltz_EN", "Waltz_EN");
            easy.AddRandomGroup("LockJaw_EN", "LostSheep_EN", "LockJaw_EN");
            easy.AddRandomGroup("LockJaw_EN", "Papereater_EN");

            AddTo med = new AddTo(Shore.H.Lockjaw.Med);
            med.AddRandomGroup("LockJaw_EN", "DeadPixel_EN", "DeadPixel_EN");
            med.AddRandomGroup("LockJaw_EN", "LockJaw_EN", "MudLung_EN", "Skyloft_EN");
            med.AddRandomGroup("LockJaw_EN", "LockJaw_EN", "Arceles_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "LockJaw_EN", "Pinano_EN");
            med.AddRandomGroup("Pinano_EN", Enemies.Mungling, "Wavebreaker_EN");
            med.AddRandomGroup("Pinano_EN", Jumble.Yellow, "LockJaw_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Wavebreaker_EN", Spoggle.Blue);
            med.AddRandomGroup("AFlower_EN", "Wavebreaker_EN", Spoggle.Yellow);

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "LockJaw_EN", "Wall_EN");
            med.AddRandomGroup("ToyUfo_EN", "Wavebreaker_EN", "VoiceTrumpet_EN");

            AddTo hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "LockJaw_EN", "TortureMeNot_EN");

            easy = new AddTo(Shore.H.Wall.Easy);
            easy.AddRandomGroup("Wall_EN", "Wall_EN", "Wavebreaker_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Wavebreaker_EN", "MudLung_EN");
            med.AddRandomGroup("LittleBeak_EN", "Wavebreaker_EN", "Papereater_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "LockJaw_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "LockJaw_EN", "2009_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "LockJaw_EN", "2009_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Wavebreaker_EN", Enemies.Mungling);

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Wavebreaker_EN", "VoiceTrumpet_EN");
            med.AddRandomGroup("Sinker_EN", "LockJaw_EN", "ToyUfo_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "LockJaw_EN", "Hauntling_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Wavebreaker_EN");
            hard.AddRandomGroup("Clown_EN", "LockJaw_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Papereater.Med);
            med.AddRandomGroup("Papereater_EN", "Papereater_EN", "LockJaw_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", "Wavebreaker_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "LockJaw_EN", "Keko_EN", "Keko_EN");

            hard = new AddTo(Shore.H.Comber.Hard);
            hard.AddRandomGroup("Beachcomber_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomGroup("Beachcomber_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Beachcomber_EN", "Pinano_EN", Jumble.Red);
            hard.AddRandomGroup("Beachcomber_EN", "Papereater_EN", "Papereater_EN");
            hard.AddRandomGroup("Beachcomber_EN", "Clione_EN");
            hard.AddRandomGroup("Beachcomber_EN", "LittleBeak_EN");
            hard.AddRandomGroup("Beachcomber_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            hard.AddRandomGroup("Beachcomber_EN", "ToyUfo_EN", "Windle_EN");
            hard.AddRandomGroup("Beachcomber_EN", "NobodyGrave_EN", "AFlower_EN");
            hard.AddRandomGroup("Beachcomber_EN", "Sinker_EN", "Skyloft_EN");
            hard.AddRandomGroup("Beachcomber_EN", "2009_EN", "LockJaw_EN");
            hard.AddRandomGroup("Beachcomber_EN", "Hauntling_EN", "Wall_EN");
            hard.AddRandomGroup("Beachcomber_EN", "Jabberwocky_EN", "NobodyGrave_EN");
            hard.AddRandomGroup("Beachcomber_EN", "Clown_EN");

            EcstasyPool.Add("LockJaw_EN");
            EcstasyPool.Add("Wavebreaker_EN");
            EcstasyPool.Add("Beachcomber_EN");
        }
    }
}
