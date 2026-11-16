using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GardenCrossovers
    {
        public static void Leviat()
        {
            AddTo med = new AddTo(Garden.H.Leviat.Med);
            med.AddRandomGroup(Enemies.Leviat, Flower.Red, Flower.Blue);
            med.AddRandomGroup(Enemies.Leviat, "MiniReaper_EN", "CorpseChan_EN");
            med.AddRandomGroup(Enemies.Leviat, "MiniReaper_EN", "Indicator_EN");
            med.SimpleAddGroup(2, Enemies.Leviat, 1, "MiniReaper_EN");
            med.AddRandomGroup(Enemies.Leviat, Spoggle.Grey, "NextOfKin_EN", "NextOfKin_EN");
            med.SimpleAddGroup(1, Enemies.Leviat, 3, "PawnA_EN");
            med.SimpleAddGroup(2, Enemies.Leviat, 1, "PawnA_EN");
            med.SimpleAddGroup(1, Enemies.Leviat, 2, "EvilDog_EN", 1, "Vivarium_EN");
            med.SimpleAddGroup(1, Enemies.Leviat, 2, "Insider_EN");
            med.SimpleAddGroup(1, Enemies.Leviat, 2, "Panopticon_EN", 1, "BlackStar_EN");
            med.AddRandomGroup(Enemies.Leviat, "Lightbulbkin_EN", Enemies.Shivering, Enemies.Shivering);
            med.SimpleAddGroup(1, Enemies.Leviat, 2, Enemies.Camera);

            AddTo hard = new AddTo(Garden.H.Leviat.Hard);
            hard.AddRandomGroup(Enemies.Leviat, "EvilDog_EN", "EvilDog_EN", Enemies.Camera);
            hard.AddRandomGroup(Enemies.Leviat, "Celebration_EN", "Celebration_EN");
            hard.SimpleAddGroup(2, Enemies.Leviat, 1, "Celebration_EN");
            hard.AddRandomGroup(Enemies.Leviat, Jumble.Grey, Enemies.Minister);
            hard.AddRandomGroup(Enemies.Leviat, Spoggle.Grey, Enemies.Minister);
            hard.AddRandomGroup(Enemies.Leviat, "PawnA_EN", "PawnA_EN", "Indicator_EN");
            hard.AddRandomGroup(Enemies.Leviat, Ecstasy.Gray, Ecstasy.Gray, Enemies.Leviat);
            hard.AddRandomGroup(Enemies.Leviat, Ecstasy.Gray, Ecstasy.Gray, "WindSong_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Leviat, Enemies.Camera);

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Leviat, "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Enemies.Leviat);
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Enemies.Leviat);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Leviat, Enemies.Leviat, "ChoirBoy_EN");
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, Enemies.Leviat, 1, "Vivarium_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Leviat);

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", Enemies.Leviat, "LittleAngel_EN");
            med.AddRandomGroup("Shua_EN", Enemies.Leviat, "Merced_EN");
            med.AddRandomGroup("Shua_EN", Enemies.Leviat, "Damocles_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", Enemies.Leviat, "EyePalm_EN", "EyePalm_EN");


        }
    }
}
