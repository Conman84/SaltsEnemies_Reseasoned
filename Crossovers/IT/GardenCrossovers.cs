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

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Enemies.Leviat, "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", Enemies.Leviat, "Grandfather_EN");
            med.AddRandomGroup("YNL_EN", Enemies.Leviat, "WindSong_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Leviat, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Leviat, "Yang_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Leviat, "Attrition_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", Enemies.Leviat, "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", Enemies.Leviat, Enemies.Leviat);
            med.AddRandomGroup("Starless_EN", Enemies.Leviat, "Vivarium_EN", "Vivarium_EN", "Vivarium_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Leviat, "PawnA_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Leviat, Bots.Grey);

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, Enemies.Leviat, "Yang_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Leviat, Enemies.Leviat);
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", Enemies.Leviat);

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 1, Enemies.Leviat);
            med.AddRandomGroup("Yang_EN", Enemies.Leviat, "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", Enemies.Leviat);

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", Enemies.Leviat, Flower.Blue);
            med.AddRandomGroup("InTheDark_EN", Enemies.Leviat, "Bonsai_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, Enemies.Leviat);

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", Enemies.Leviat, "EggKeeper_EN");
            med.AddRandomGroup("Lunoscope_EN", Enemies.Leviat, "MiniReaper_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", Enemies.Leviat, "ChoirBoy_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, Enemies.Leviat);

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Leviat, Enemies.Leviat);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Leviat, "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.AddRandomGroup(Enemies.Eclipse, Enemies.Eclipse, Enemies.Leviat);
        }
    }
}
