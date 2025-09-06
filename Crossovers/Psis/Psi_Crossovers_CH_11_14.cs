using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Psi_Crossovers_CH_11_14
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Shore.H.Mungman.Easy);
            easy.AddRandomGroup("Mungman_EN", "Windle_EN", "Mungman_EN");

            easy = new AddTo(Shore.H.Squirmer.Easy);
            easy.AddRandomGroup("Squirmer_EN", "Windle_EN", "Squirmer_EN");

            AddTo med = new AddTo(Shore.H.Mungman.Med);
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "Pinano_EN", "Flarbleft_EN");
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "LostSheep_EN", "Pinano_EN");
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "Pinano_EN", "NobodyGrave_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "Digger_EN", "Pinano_EN");
            med.AddRandomGroup("Digger_EN", "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup("Digger_EN", "Pinano_EN", Spoggle.Yellow);

            med = new AddTo(Shore.H.Squirmer.Med);
            med.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "Pinano_EN", "Minana_EN");
            med.AddRandomGroup("Squirmer_EN", "Pinano_EN", Jumble.Yellow, Jumble.Red);

            med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "Pinano_EN", "ShoreRock_EN");
            med.AddRandomGroup("Wailer_EN", "LittleBeak_EN", "Goa_EN");
            med.AddRandomGroup("Wailer_EN", "Pinano_EN", "Arceles_EN");

            AddTo hard = new AddTo(Shore.H.Wailer.Hard);
            hard.AddRandomGroup("Wailer_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomGroup("Wailer_EN", "Pinano_EN", Spoggle.Blue);
            hard.AddRandomGroup("Wailer_EN", "LittleBeak_EN", "FlaMinGoa_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.SimpleAddGroup(1, "Tripod_EN", 3, "Mungman_EN");
            hard.AddRandomGroup("Tripod_EN", "Squirmer_EN", "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Mungman_EN", Jumble.Yellow);
            med.AddRandomGroup("LittleBeak_EN", "Digger_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup("LittleBeak_EN", "Squirmer_EN", "Squirmer_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Wailer_EN", Jumble.Red);
            hard.AddRandomGroup("Warbird_EN", "Squirmer_EN", "Digger_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Mungman_EN", "MudLung_EN");
            med.AddRandomGroup("Clione_EN", "Digger_EN", "LostSheep_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Squirmer_EN", "Squirmer_EN", "Squirmer_EN");
            hard.AddRandomGroup("Clione_EN", "Wailer_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Suckler_EN");

            med = new AddTo(Orph.H.Suckler.Med);
            med.AddRandomGroup("Suckler_EN", "Suckler_EN", "Rabies_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "Damocles_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("Beakart_EN", "EvilDog_EN", "EvilDog_EN", "GlassFigurine_EN");
            med.AddRandomGroup("Beakart_EN", "InHisImage_EN", "InHerImage_EN", "BlackStar_EN");
            med.AddRandomGroup("Beakart_EN", Enemies.Minister, "Indicator_EN");
            med.AddRandomGroup("Beakart_EN", Enemies.Minister, "YNL_EN");
            med.AddRandomGroup("Beakart_EN", "Firebird_EN", "Indicator_EN");
            med.SimpleAddGroup(1, "Beakart_EN", 3, "BlackStar_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Beakart_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Beakart_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Beakart_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Beakart_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Beakart_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Stoplight_EN", "Beakart_EN", "EyePalm_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Beakart_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "Beakart_EN", "Firebird_EN");
            hard.AddRandomGroup("Stoplight_EN", "Beakart_EN", Enemies.Minister);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Stoplight_EN", "Beakart_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Stoplight_EN", "Beakart_EN", "Children6_EN");
        }
    }
}
