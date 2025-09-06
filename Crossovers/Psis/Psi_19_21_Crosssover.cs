using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Psi_19_21_Crosssover
    {
        public static void Add()
        {
            //SHORE
            AddTo easy = new AddTo(Shore.H.Mungman.Easy);
            easy.AddRandomGroup("Mungman_EN", "Waltz_EN", "Waltz_EN");

            easy = new AddTo(Shore.H.Squirmer.Easy);
            easy.AddRandomGroup("Squirmer_EN", "Wall_EN", "LostSheep_EN");

            AddTo med = new AddTo(Shore.H.Mungman.Med);
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "Wall_EN");
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "2009_EN");

            med = new AddTo(Shore.H.Squirmer.Med);
            med.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup("Digger_EN", Jumble.Yellow, "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Mungman_EN", "MudLung_EN");
            med.AddRandomGroup("2009_EN", "Squirmer_EN", "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.AddRandomGroup("VoiceTrumpet_EN", "VoiceTrumpet_EN", "Mungman_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", "Mungman_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomGroup("Chiito_EN", "Squirmer_EN", Spoggle.Blue, "Squirmer_EN");

            med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "Chiito_EN", "MudLung_EN");
            med.AddRandomGroup("Wailer_EN", "2009_EN", "Pinano_EN");

            AddTo hard = new AddTo(Shore.H.Wailer.Hard);
            hard.SimpleAddGroup(1, "Wailer_EN", 4, "Waltz_EN");
            hard.SimpleAddGroup(1, "Wailer_EN", 2, "VoiceTrumpet_EN", 1, "Skyloft_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Squirmer_EN", "Waltz_EN");
            hard.AddRandomGroup("Clown_EN", "Mungman_EN", "Waltz_EN");
            hard.AddRandomGroup("Clown_EN", "Wailer_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "Digger_EN", "Digger_EN");
            hard.AddRandomGroup("33_EN", "Wailer_EN", Spoggle.Yellow);
            hard.AddRandomGroup("33_EN", "Mungman_EN", Enemies.Mungling);

            //ORPH
            med = new AddTo(Orph.H.Suckler.Med);
            med.SimpleAddGroup(2, "Suckler_EN", 3, "Foxtrot_EN");

            //GARDEN
            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "PawnA_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Beakart_EN", "PawnA_EN", "PawnA_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Beakart_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Beakart_EN", "Grandfather_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Beakart_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Eyeless_EN", "Beakart_EN", Enemies.Minister);

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(2, "Yang_EN", 1, "Beakart_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", "Beakart_EN");
            hard.AddRandomGroup("Yin_EN", "Yin_EN", "Beakart_EN");
        }
    }
}
