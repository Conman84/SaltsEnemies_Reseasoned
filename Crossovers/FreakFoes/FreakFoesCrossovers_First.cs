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

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "LockJaw_EN");
        }
    }
}
