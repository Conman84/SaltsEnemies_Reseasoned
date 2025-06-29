using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colophon_6_10_Cross
    {
        public static void Ad()
        {
            //SHORE

            AddTo easy = new AddTo(Shore.H.Colophon.Red.Easy);
            easy.AddRandomGroup(Colophon.Red, Colophon.Blue, "Skyloft_EN");

            easy = new AddTo(Shore.H.Colophon.Blue.Easy);
            easy.AddRandomGroup(Colophon.Blue, Colophon.Red, "Skyloft_EN");

            AddTo med = new AddTo(Shore.H.Colophon.Red.Med);
            med.AddRandomGroup(Colophon.Red, "DeadPixel_EN", "DeadPixel_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, Colophon.Blue, "Skyloft_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", Colophon.Blue, "Skyloft_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Colophon.Blue, "Skyloft_EN");

            AddTo hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", Colophon.Red, "Skyloft_EN");

            //FORPHEUM

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", Colophon.Yellow);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", Colophon.Purple);

            med = new AddTo(Orph.H.Colophon.Yellow.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "FakeAngel_EN");
            med.AddRandomGroup(Colophon.Yellow, "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, Enemies.Solvent);
            med.AddRandomGroup(Colophon.Yellow, "Scrungie_EN", "WindSong_EN");
            if (SaltsReseasoned.trolling < 50) med.SimpleAddGroup(1, Colophon.Yellow, 3, "Spectre_EN");

            med = new AddTo(Orph.H.Colophon.Purple.Med);
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, "FakeAngel_EN");
            med.AddRandomGroup(Colophon.Purple, "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            med.AddRandomGroup(Colophon.Yellow, Colophon.Purple, Enemies.Solvent);
            med.AddRandomGroup(Colophon.Purple, "Scrungie_EN", "WindSong_EN");
            if (SaltsReseasoned.trolling > 50) med.SimpleAddGroup(1, Colophon.Purple, 3, "Spectre_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "MusicMan_EN", Colophon.Purple);
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "MusicMan_EN", Colophon.Yellow);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Sigil_EN", Colophon.Yellow);
            med.AddRandomGroup("Freud_EN", "Sigil_EN", Colophon.Purple);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", Colophon.Yellow, "Spectre_EN");
            med.AddRandomGroup("TheCrow_EN", Colophon.Purple, "Spectre_EN");

            hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", Colophon.Yellow);
            hard.AddRandomGroup("StalwartTortoise_EN", Colophon.Purple);

            med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Colophon.Yellow, Enemies.Solvent);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", Colophon.Purple, Enemies.Solvent);

            easy = new AddTo(Orph.H.Solvent.Easy);
            easy.AddRandomGroup(Enemies.Solvent, Colophon.Red, Colophon.Blue);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "WindSong_EN", Colophon.Yellow);
            hard.AddRandomGroup("Conductor_EN", "WindSong_EN", Colophon.Purple);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Sigil_EN", Colophon.Yellow);
            med.AddRandomGroup("Conductor_EN", "Sigil_EN", Colophon.Purple);

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Enemies.Solvent, Colophon.Red, Colophon.Blue);
        }
    }
}
