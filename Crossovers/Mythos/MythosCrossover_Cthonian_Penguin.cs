using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MythosCrossover_Cthonian_Penguin
    {
        public static void Add()
        {
            AddTo med = new AddTo(Shore.H.Penguin.Med);
            med.AddRandomGroup(Enemies.Penguin, "Pinano_EN", "Pinano_EN");
            med.AddRandomGroup(Enemies.Penguin, "LostSheep_EN", Enemies.Mungling);
            med.AddRandomGroup(Enemies.Penguin, "MudLung_EN", "MudLung_EN", "NobodyGrave_EN");
            med.AddRandomGroup(Enemies.Penguin, "Wall_EN", "Wall_EN", "Wall_EN");
            med.AddRandomGroup(Enemies.Penguin, "ToyUfo_EN", Jumble.Yellow);
            med.AddRandomGroup(Enemies.Penguin, "2009_EN", Spoggle.Blue);
            med.AddRandomGroup(Enemies.Penguin, "DeadPixel_EN", "DeadPixel_EN", "LostSheep_EN");
            med.AddRandomGroup(Enemies.Penguin, "Waltz_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomGroup(Enemies.Penguin, "Windle_EN", "LittleBeak_EN");
            med.AddRandomGroup(Enemies.Penguin, "Papereater_EN", "Papereater_EN");
            med.AddRandomGroup(Enemies.Penguin, "Jabberwocky_EN", "Keko_EN", "Keko_EN");
            med.AddRandomGroup(Enemies.Penguin, "Jabberwocky_EN", "Hauntling_EN");
            med.SimpleAddGroup(2, Enemies.Penguin, 1, "Hauntling_EN");

            AddTo hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, Enemies.Penguin);

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, Enemies.Penguin, Enemies.Penguin, "TortureMeNot_EN");
            hard.AddRandomGroup(Enemies.Camera, Enemies.Penguin, "FlaMinGoa_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", Jumble.Yellow, Enemies.Penguin);

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", Enemies.Penguin, "Arceles_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", Enemies.Penguin, Enemies.Penguin);
            hard.AddRandomGroup("Clione_EN", Enemies.Penguin, "Sinker_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.SimpleAddGroup(1, "Warbird_EN", 2, Enemies.Penguin);
            hard.AddRandomGroup("Warbird_EN", Enemies.Penguin, "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", Enemies.Penguin, Jumble.Unstable);
            med.AddRandomGroup("Sinker_EN", Enemies.Penguin, "Snaurce_EN");
            med.AddRandomGroup("Sinker_EN", Enemies.Penguin, "Papereater_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.SimpleAddGroup(2, "Sinker_EN", 1, Enemies.Penguin);
            hard.AddRandomGroup("Sinker_EN", Enemies.Penguin, "Surimi_EN", "Surimi_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Enemies.Penguin, "Draugr_EN");
            med.AddRandomGroup("AFlower_EN", Enemies.Penguin, "Skyloft_EN");
            med.AddRandomGroup("AFlower_EN", Enemies.Penguin, "Asterism_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", Enemies.Penguin, "Surimi_EN", "Surimi_EN");
            hard.AddRandomGroup("AFlower_EN", Enemies.Penguin, "FlaMinGoa_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.SimpleAddGroup(2, Enemies.Penguin, 1, "33_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", Enemies.Penguin);
            hard.AddRandomGroup("Clown_EN", Enemies.Penguin, "Waltz_EN");

            //garden: cthonian
            hard = new AddTo(Garden.H.Cthonian.Hard);
            hard.AddRandomGroup(Enemies.Cthonian, Spoggle.Grey, "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Cthonian, Spoggle.Grey, Spoggle.Mythos, Spoggle.Mythos);
            hard.AddRandomGroup(Enemies.Cthonian, Jumble.Grey, "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Cthonian, Jumble.Grey, Jumble.Mythos, Jumble.Mythos);
            hard.AddRandomGroup(Enemies.Cthonian, Flower.Red, Flower.Blue);
            hard.AddRandomGroup(Enemies.Cthonian, "ClockTower_EN", "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Cthonian, Enemies.Tank);
            hard.AddRandomGroup(Enemies.Cthonian, "MiniReaper_EN", "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "Shua_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "Hunter_EN", Enemies.Minister);
            hard.AddRandomGroup(Enemies.Cthonian, "Firebird_EN", Enemies.Minister);
            hard.AddRandomGroup(Enemies.Cthonian, "Satyr_EN", "BlackStar_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "Stoplight_EN", "NextOfKin_EN", "NextOfKin_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "YNL_EN", "Ascendant_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "TortureMeNot_EN", "TortureMeNot_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "OdeToHumanity_EN", Spoggle.Mythos);
            hard.AddRandomGroup(Enemies.Cthonian, "OdeToHumanity_EN", Jumble.Mythos);
            hard.AddRandomGroup(Enemies.Cthonian, "Starless_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "Eyeless_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "PawnA_EN", "Yang_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "InTheDark_EN");
            hard.AddRandomGroup(Enemies.Cthonian, "Panopticon_EN", "Panopticon_EN");
            hard.AddRandomGroup(Enemies.Cthonian, Enemies.Eclipse, Enemies.Eclipse);
            hard.AddRandomGroup(Enemies.Cthonian, "Celebration_EN", Spoggle.Mythos);
            hard.AddRandomGroup(Enemies.Cthonian, "Celebration_EN", Jumble.Mythos);
        }
    }
}
