using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Psi_CH_15_18_Crossover
    {
        public static void Add()
        {
            //SHORE
            AddTo easy = new AddTo(Shore.H.Mungman.Easy);
            easy.AddRandomGroup("Mungman_EN", "Mungman_EN", "NobodyGrave_EN");

            easy = new AddTo(Shore.H.Squirmer.Easy);
            easy.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "TortureMeNot_EN", "TortureMeNot");

            AddTo med = new AddTo(Shore.H.Mungman.Med);
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "Mungman_EN", "TortureMeNot_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "ToyUfo_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Squirmer.Med);
            med.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "Pinano_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Mungman_EN", "Mungman_EN");
            med.AddRandomGroup("ToyUfo_EN", Jumble.Yellow, "Squirmer_EN");
            med.AddRandomGroup("ToyUfo_EN", "ShoreRock_EN", "Pinano_EN", "Pinano_EN");

            med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "ToyUfo_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Mungman_EN", Spoggle.Yellow);

            AddTo hard = new AddTo(Shore.H.Wailer.Hard);
            hard.AddRandomGroup("Wailer_EN", "Sinker_EN", "Skyloft_EN");
            hard.AddRandomGroup("Wailer_EN", "ToyUfo_EN", "Pinano_EN", "Pinano_EN");

            //ORPH
            easy = new AddTo(Orph.H.Suckler.Easy);
            easy.AddRandomGroup("Suckler_EN", "Suckler_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            med = new AddTo(Orph.H.Suckler.Med);
            med.AddRandomGroup("Suckler_EN", Enemies.Shooter, Enemies.Shooter);

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup("Suckler_EN", Enemies.Shooter, Enemies.Shooter);

            //GARDEN
            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(2, "GlassedSun_EN", 1, "Beakart_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", Bots.Grey, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Beakart_EN", Bots.Grey, "EyePalm_EN", "EyePalm_EN");
            med.SimpleAddGroup(1, "Beakart_EN", 3, "EvilDog_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Beakart_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Beakart_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("Beakart_EN", "PersonalAngel_EN", "Grandfather_EN");
        }
    }
}
