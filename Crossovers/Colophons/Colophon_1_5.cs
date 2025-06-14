using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class Colophon_1_5
    {
        public static void Crossovers()
        {
            //SHORE
            AddTo easy = new AddTo(Shore.H.Colophon.Red.Easy);
            easy.AddRandomGroup(Colophon.Red, Colophon.Blue, "LostSheep_EN");
            easy = new AddTo(Shore.H.Colophon.Blue.Easy);
            easy.AddRandomGroup(Colophon.Red, Colophon.Blue, "LostSheep_EN");

            easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.SimpleAddGroup(2, "DeadPixel_EN", 1, Colophon.Red);
            easy.SimpleAddGroup(2, "DeadPixel_EN", 1, Colophon.Blue);

            AddTo med = new AddTo(Shore.H.DeadPixel.Med);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", Colophon.Red, "MudLung_EN");
            med.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", Colophon.Blue, "MudLung_EN");

            AddTo hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, Colophon.Blue);
            hard.AddRandomGroup(Enemies.Unmung, Colophon.Red);

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("AFlower_EN", Colophon.Red, "MudLung_EN");
            med.AddRandomGroup("AFlower_EN", Colophon.Blue, "MudLung_EN");
            med.AddRandomGroup("AFlower_EN", Colophon.Red, Enemies.Mungling);
            med.AddRandomGroup("AFlower_EN", Colophon.Blue, Enemies.Mungling);

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", Colophon.Red, "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("AFlower_EN", Colophon.Blue, "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("AFlower_EN", Colophon.Red, "FlaMinGoa_EN");
            hard.AddRandomGroup("AFlower_EN", Colophon.Blue, "FlaMinGoa_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "FlaMinGoa_EN", Colophon.Red, Colophon.Blue);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Camera, Colophon.Red, Colophon.Blue);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Mungling, "FlaMinGoa_EN", Colophon.Blue);
            hard.AddRandomGroup(Enemies.Camera, "DeadPixel_EN", "DeadPixel_EN", Colophon.Blue);

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "DeadPixel_EN", "DeadPixel_EN", Colophon.Red);

            hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "AFlower_EN", Colophon.Blue);
            hard.AddRandomGroup("FlaMinGoa_EN", "AFlower_EN", Colophon.Red);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", Colophon.Blue, "LostSheep_EN");
            hard.AddRandomGroup("Flarb_EN", Colophon.Red, Enemies.Camera);

            //ORPHEUM
            easy = new AddTo(Orph.H.Enigma.Easy);
            easy.SimpleAddGroup(2, "Enigma_EN", 1, Colophon.Red);
            easy.SimpleAddGroup(2, "Enigma_EN", 1, Colophon.Blue);

            med = new AddTo(Orph.H.Enigma.Med);
            med.AddRandomGroup("Enigma_EN", "Enigma_EN", Colophon.Red, Colophon.Blue);
            med.SimpleAddGroup(3, "Enigma_EN", 1, Colophon.Blue);
            med.SimpleAddGroup(3, "Enigma_EN", 1, Colophon.Red);

            easy = new AddTo(Orph.H.Something.Easy);
            easy.AddRandomGroup("Something_EN", Colophon.Blue, Colophon.Red);

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Colophon.Purple, "Enigma_EN");
            med.AddRandomGroup("Something_EN", Colophon.Yellow, "Enigma_EN");
            med.AddRandomGroup("Something_EN", Colophon.Purple, "MusicMan_EN");
            med.AddRandomGroup("Something_EN", Colophon.Yellow, "MusicMan_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Colophon.Purple, "Enigma_EN");
            med.AddRandomGroup("TheCrow_EN", Colophon.Yellow, "Enigma_EN");
            med.AddRandomGroup("TheCrow_EN", Colophon.Purple, "MusicMan_EN");
            med.AddRandomGroup("TheCrow_EN", Colophon.Yellow, "MusicMan_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Colophon.Purple, "Enigma_EN");
            med.AddRandomGroup("Freud_EN", Colophon.Yellow, "Enigma_EN");
            med.AddRandomGroup("Freud_EN", Colophon.Purple, "MusicMan_EN");
            med.AddRandomGroup("Freud_EN", Colophon.Yellow, "MusicMan_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Colophon.Purple, Colophon.Yellow);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Colophon.Purple, "MusicMan_EN");
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Colophon.Purple, "MusicMan_EN");

            med = new AddTo(Orph.H.Colophon.Yellow.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "Something_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "Enigma_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "LostSheep_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, Enemies.Camera);

            med = new AddTo(Orph.H.Colophon.Purple.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "Something_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "Enigma_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "LostSheep_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, Enemies.Camera);
        }
    }
}
