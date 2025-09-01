using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GlitchCrossover_6_8
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Orph.H.Dancer.Easy);
            easy.SimpleAddGroup(2, "BackupDancer_EN", 1, Enemies.Solvent);

            easy = new AddTo(Orph.H.Frostbite.Easy);
            easy.SimpleAddGroup(2, "Frostbite_EN", 1, Enemies.Solvent);

            easy = new AddTo(Orph.H.Flower.Yellow.Easy);
            easy.SimpleAddGroup(1, Flower.Yellow, 2, "Frostbite_EN");

            AddTo med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "BackupDancer_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "BackupDancer_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.SimpleAddGroup(3, "Frostbite_EN", 1, "Sigil_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "BackupDancer_EN", "MusicMan_EN", "MusicMan_EN");
            med.SimpleAddGroup(3, "Frostbite_EN", 1, "WindSong_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Frostbite.Med);
            med.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "Frostbite_EN", "WindSong_EN");
        }
    }
}
