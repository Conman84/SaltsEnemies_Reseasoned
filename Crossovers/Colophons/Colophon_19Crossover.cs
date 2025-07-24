using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Colophon_19Crossover
    {
        public static void Add()
        {
            //its just the wednesday lol

            AddTo med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Colophon.Yellow);
            med.AddRandomGroup("Wednesday_EN", Colophon.Purple, Colophon.Red, Colophon.Blue);
            med.AddRandomGroup("Wednesday_EN", "Spectre_EN", "Spectre_EN", Colophon.Purple);
            med.AddRandomGroup("Wednesday_EN", Colophon.Yellow, "Delusion_EN", "FakeAngel_EN");

            med = new AddTo(Orph.H.Colophon.Yellow.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Colophon.Yellow, "MusicMan_EN", "MusicMan_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Colophon.Purple.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Colophon.Purple, "Wednesday_EN", "Enigma_EN", "Enigma_EN");
        }
    }
}
