using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colophon11_15
    {
        public static void AddCrossovers()
        {
            AddTo hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", Colophon.Red, Colophon.Blue, "Pinano_EN");
            hard.AddRandomGroup("Tripod_EN", Colophon.Red, Colophon.Blue, "MechanicalLens_EN");
            hard.AddRandomGroup("Tripod_EN", Colophon.Blue, Colophon.Red, Enemies.Mungling);

            AddTo med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Colophon.Blue, Colophon.Red);
            med.AddRandomGroup("LittleBeak_EN", Colophon.Blue, "Pinano_EN");
            med.AddRandomGroup("LittleBeak_EN", Colophon.Blue, "LittleBeak_EN");
            med.AddRandomGroup("LittleBeak_EN", Colophon.Blue, Colophon.Red, "LostSheep_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", Colophon.Red, Colophon.Blue, "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Warbird_EN", Colophon.Red, Colophon.Blue, "FlaMinGoa_EN");
            hard.AddRandomGroup("Warbird_EN", Colophon.Red, "AFlower_EN");
            hard.AddRandomGroup("Warbird_EN", Colophon.Red, "Clione_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("Clione_EN", Colophon.Blue, "MudLung_EN");
            med.AddRandomGroup("Clione_EN", Colophon.Red, Colophon.Red);
            med.AddRandomGroup("Clione_EN", Colophon.Blue, "Pinano_EN");
            med.AddRandomGroup("Clione_EN", Colophon.Red, "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", Colophon.Red, Colophon.Blue, "FlaMinGoa_EN");
            hard.AddRandomGroup("Clione_EN", Colophon.Blue, Colophon.Red, "AFlower_EN");
            hard.AddRandomGroup("Clione_EN", Colophon.Red, Colophon.Blue, "LittleBeak_EN");

            AddTo easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Pinano_EN", Colophon.Red);
            easy.AddRandomGroup("Pinano_EN", Colophon.Blue);

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", Colophon.Red);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", Colophon.Blue);
            med.AddRandomGroup("Pinano_EN", "MudLung_EN", Colophon.Blue, "LittleBeak_EN");
            med.AddRandomGroup("Pinano_EN", Colophon.Blue, Colophon.Red);


            easy = new AddTo(Shore.H.Colophon.Red.Easy);
            easy.AddRandomGroup(Colophon.Red, Colophon.Blue, "Arceles_EN");

            easy = new AddTo(Shore.H.Colophon.Blue.Easy);
            easy.AddRandomGroup(Colophon.Blue, Colophon.Red, "Arceles_EN");

            med = new AddTo(Shore.H.Colophon.Red.Med);
            med.AddRandomGroup(Colophon.Blue, Colophon.Red, "Pinano_EN");
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "Windle_EN");

            med = new AddTo(Shore.H.Colophon.Blue.Med);
            med.AddRandomGroup(Colophon.Red, Colophon.Blue, "Pinano_EN");
            med.AddRandomGroup(Colophon.Blue, Colophon.Red, "Windle_EN");


            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Colophon.Blue, "Pinano_EN");
            med.AddRandomGroup("AFlower_EN", Colophon.Red, "Pinano_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", Colophon.Red, Colophon.Blue, "Pinano_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup("MechanicalLens_EN", Colophon.Red, Colophon.Blue, "Pinano_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, Colophon.Blue, "Pinano_EN");
            med.AddRandomGroup(Enemies.Mungling, Colophon.Red, "Pinano_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", Colophon.Red, "Pinano_EN");
            med.AddRandomGroup("FlaMinGoa_EN", Colophon.Blue, "Pinano_EN");

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", Colophon.Red, Colophon.Blue, "Pinano_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", Colophon.Blue, "Pinano_EN");
            hard.AddRandomGroup("Flarb_EN", Colophon.Red, "Pinano_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", Colophon.Red, "Pinano_EN");
            hard.AddRandomGroup("Voboola_EN", Colophon.Blue, "Pinano_EN");


            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", Colophon.Yellow);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", Colophon.Purple);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", Colophon.Yellow, Colophon.Purple);
            med.AddRandomGroup("Maw_EN", Colophon.Yellow, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Purple, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Yellow, "WindSong_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Purple, "WindSong_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Yellow, "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Purple, "Enigma_EN", "Enigma_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Yellow, "Delusion_EN", "Delusion_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Purple, "Delusion_EN", "Delusion_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Yellow, "Something_EN");
            med.AddRandomGroup("Maw_EN", Colophon.Purple, "Something_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", Colophon.Yellow, Colophon.Purple, Colophon.Blue);
            hard.AddRandomGroup("Maw_EN", Colophon.Yellow, Colophon.Purple, Colophon.Red);
            hard.AddRandomGroup("Maw_EN", Colophon.Yellow, "Freud_EN", Enemies.Suckle, Enemies.Suckle);
            hard.AddRandomGroup("Maw_EN", Colophon.Purple, "TheCrow_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Colophon.Yellow.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "Rabies_EN");

            med = new AddTo(Orph.H.Colophon.Purple.Med);
            med.AddRandomGroup(Colophon.Purple, Colophon.Yellow, "Rabies_EN");


            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", Colophon.Yellow, Colophon.Purple, "Nameless_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Colophon.Yellow, "Nameless_EN");
            hard.AddRandomGroup("Revola_EN", Colophon.Purple, "Nameless_EN");
        }
    }
}
