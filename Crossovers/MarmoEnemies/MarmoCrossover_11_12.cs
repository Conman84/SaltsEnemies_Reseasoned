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
            hard.AddRandomGroup("Tripod_EN", "AFlower_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "LittleBeak_EN", "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", Enemies.Mungling, "Surimi_EN");
            hard.AddRandomGroup("Warbird_EN", "Skyloft_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", "Surimi_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup("Warbird_EN", Spoggle.Yellow, Spoggle.Blue, "Snaurce_EN");
            hard.AddRandomGroup("Warbird_EN", Jumble.Red, "Surimi_EN", "Surimi_EN");

            AddTo med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Snaurce_EN", "Snaurce_EN");
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", Jumble.Yellow);
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", Spoggle.Yellow);
            med.AddRandomGroup("LittleBeak_EN", "Snaurce_EN", "Skyloft_EN", "Mung_EN");
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", Enemies.Mungling);
            med.AddRandomGroup("LittleBeak_EN", "Surimi_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", "Snaurce_EN");
            if (SaltsReseasoned.trolling < 50) hard.AddRandomGroup("AFlower_EN", "LittleBeak_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "LittleBeak_EN", "Snaurce_EN", "Snaurce_EN");
            hard.AddRandomGroup(Enemies.Camera, "AFlower_EN", "Surimi_EN");
        }
    }
}
