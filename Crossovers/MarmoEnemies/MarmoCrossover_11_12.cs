using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MarmoCrossover_11_12
    {
        public static void Add()
        {
            //FLAR SORE
            AddTo hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Surimi_EN", "Surimi_EN", Jumble.Red);
            hard.AddRandomGroup("Tripod_EN", "Snaurce_EN", "Snaurce_EN", Jumble.Yellow);
            hard.SimpleAddGroup(1, "Tripod_EN", 3, "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", "LittleBeak_EN", "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", "Surimi_EN", Jumble.Red, Jumble.Yellow);
            hard.AddRandomGroup("Tripod_EN", "Surimi_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomGroup("Tripod_EN", "Skyloft_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup("Tripod_EN", Enemies.Mungling, "Snaurce_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "LittleBeak_EN", "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", Enemies.Mungling, "Surimi_EN");
            hard.AddRandomGroup("Warbird_EN", "Skyloft_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", "Surimi_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Warbird_EN", Spoggle.Yellow, Spoggle.Blue, "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", Jumble.Red, "Surimi_EN", "Surimi_EN");

        }
    }
}
