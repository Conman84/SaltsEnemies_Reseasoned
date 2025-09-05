using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Glitch_Crossovers_13_14
    {
        public static void Add()
        {
            //SHORE
            AddTo easy = new AddTo(Shore.H.Flakkid.Easy);
            easy.AddRandomGroup("Flakkid_EN", "MudLung_EN", "Windle_EN");

            easy = new AddTo(Shore.H.Swine.Easy);
            easy.AddRandomGroup(Enemies.Swine, "Arceles_EN", "MudLung_EN");

            AddTo med = new AddTo(Shore.H.Flakkid.Med);
            med.AddRandomGroup("Flakkid_EN", "Pinano_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Swine.Med);
            med.AddRandomGroup(Enemies.Swine, Enemies.Swine, "Pinano_EN");

            med = new AddTo(Shore.H.Pipe.Med);
            med.AddRandomGroup("NotAn_EN", "Pinano_EN", Jumble.Yellow);

            med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "Pinano_EN", "Pinano_EN");

            AddTo hard = new AddTo(Shore.H.Bait.Hard);
            hard.SimpleAddGroup(1, "DryBait_EN", 3, "Pinano_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.SimpleAddGroup(2, "Pinano_EN", 1, Enemies.Swine);

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Flakkid_EN", "Flakkid_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "DryBait_EN", "FlaMinGoa_EN");

            //ORPHEUM

            med = new AddTo(Orph.H.Maw.Med);
            med.SimpleAddGroup(1, "Maw_EN", 2, "BackupDancer_EN");
            med.SimpleAddGroup(1, "Maw_EN", 3, "Frostbite_EN");
            med.AddRandomGroup("Maw_EN", "MusicMan_EN", "BackupDancer_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "BackupDancer_EN", "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomGroup("Maw_EN", "Frostbite_EN", "Frostbite_EN", Jumble.Blue);
            hard.AddRandomGroup("Maw_EN", "Frostbite_EN", "Frostbite_EN", "TheCrow_EN");
        }
    }
}
