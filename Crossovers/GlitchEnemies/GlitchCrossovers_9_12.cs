using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GlitchCrossovers_9_12
    {
        public static void Add()
        {
            //SHORE
            AddTo med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "MudLung_EN", "MudLung_EN", "Skyloft_EN");

            AddTo hard = new AddTo(Shore.H.Bait.Hard);
            hard.AddRandomGroup("DryBait_EN", Enemies.Mungling, Enemies.Mungling, "Skyloft_EN");
            hard.AddRandomGroup("DryBait_EN", "LittleBeak_EN", Enemies.Mungling);

            AddTo easy = new AddTo(Shore.H.Flakkid.Easy);
            easy.AddRandomGroup("Flakkid_EN", Jumble.Red, "Skyloft_EN");

            med = new AddTo(Shore.H.Flakkid.Med);
            med.AddRandomGroup("Flakkid_EN", "Flakkid_EN", "Skyloft_EN");

            easy = new AddTo(Shore.H.Swine.Easy);
            easy.AddRandomGroup(Enemies.Swine, "MudLung_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.Swine.Med);
            med.AddRandomGroup(Enemies.Swine, Enemies.Swine, "Skyloft_EN");

            med = new AddTo(Shore.H.Pipe.Med);
            med.AddRandomGroup("NotAn_EN", "LittleBeak_EN", "Skyloft_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("NotAn_EN", "LittleBeak_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "DryBait_EN", Jumble.Red, Jumble.Yellow);
            hard.AddRandomGroup("Tripod_EN", "LittleBeak_EN", "NotAn_EN");

            //ORPHEMUM
            easy = new AddTo(Orph.H.Frostbite.Easy);
            easy.AddRandomGroup("Frostbite_EN", "Frostbite_EN", "Spectre_EN");

            easy = new AddTo(Orph.H.Dancer.Easy);
            easy.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Frostbite.Med);
            med.SimpleAddGroup(3, "Frostbite_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Frostbite_EN", "Frostbite_EN");

            hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Frostbite_EN", "Frostbite_EN");
        }
    }
}
