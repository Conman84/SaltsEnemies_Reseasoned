using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class IdiotwareCross
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Garden.H.Idiotware.Easy);
            easy.SimpleAddGroup(1, "Idiotware_EN", 2, "PawnA_EN");
            easy.AddRandomGroup("Idiotware_EN", Flower.Red);
            easy.SimpleAddGroup(1, "Idiotware_EN", 2, "EyePalm_EN");
            easy.AddRandomGroup("Idiotware_EN", "BlackStar_EN", "BlackStar_EN");
            easy.AddRandomGroup("Idiotware_EN", "Lightbulbkin_EN", "NextOfKin_EN");

            AddTo med = new AddTo(Garden.H.Idiotware.Med);
            med.AddRandomGroup("Idiotware_EN", Jumble.Grey, Enemies.Shivering, Enemies.Shivering);
            med.SimpleAddGroup(2, "Idiotware_EN", 1, "Grandfather_EN");
            med.SimpleAddGroup(1, "Idiotware_EN", 3, "EyePalm_EN");
            med.SimpleAddGroup(2, "Idiotware_EN", 1, "EyePalm_EN");
            med.SimpleAddGroup(1, "Idiotware_EN", 2, "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Idiotware_EN");
            med.AddRandomGroup("Satyr_EN", "Idiotware_EN", Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, "Idiotware_EN");
            hard.AddRandomGroup("Satyr_EN", "Idiotware_EN", "Yang_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Idiotware_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Idiotware_EN");
            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Idiotware_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, Flower.Red, "Idiotware_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, "Idiotware_EN");
            hard.AddRandomGroup("ClockTower_EN", "Idiotware_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Idiotware_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Idiotware_EN", "EyePalm_EN");
            med.AddRandomGroup("Shua_EN", "Idiotware_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Idiotware_EN", Flower.Red);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Idiotware_EN", Flower.Blue);
            med.AddRandomGroup("Firebird_EN", "Idiotware_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Idiotware_EN", "Grandfather_EN");
            med.AddRandomGroup("YNL_EN", "Idiotware_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Idiotware_EN", "PawnA_EN");
            med.AddRandomGroup("Stoplight_EN", "Idiotware_EN", Enemies.Shivering);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Idiotware_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Stoplight_EN", "Idiotware_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup("Stoplight_EN", "Idiotware_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Idiotware_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Idiotware_EN", Enemies.Shivering);
            med.AddRandomGroup("OdeToHumanity_EN", "Idiotware_EN", "Yang_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(2, "EvilDog_EN", 1, "Idiotware_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Idiotware_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Idiotware_EN", Enemies.Shivering);
            med.AddRandomGroup("Starless_EN", "Idiotware_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Idiotware_EN", "OdeToHumanity_EN");
            hard.AddRandomGroup("Eyeless_EN", "Idiotware_EN", Spoggle.Grey);

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", "Idiotware_EN");
            med.SimpleAddGroup(1, "Yang_EN", 1, "Idiotware_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(1, "Yang_EN", 1, "Idiotware_EN", 2, "PawnA_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "Idiotware_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", "Idiotware_EN");
            hard.SimpleAddGroup(2, "Yin_EN", 1, "Idiotware_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Idiotware_EN");
            med.AddRandomGroup("CorpseChan_EN", "Idiotware_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Idiotware_EN");
            med.AddRandomGroup("InTheDark_EN", "Idiotware_EN", "Drippings_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Idiotware_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Idiotware_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "Idiotware_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Idiotware_EN", Enemies.Shivering, Enemies.Shivering);
            hard.AddRandomGroup("Lunoscope_EN", "Idiotware_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "Idiotware_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, "Idiotware_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "Idiotware_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Eclipse, "Idiotware_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Idiotware_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Lightbulbkin_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "EvilDog_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Panopticon_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", Ecstasy.Gray);
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Yang_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Bonsai_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Attrition_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Git_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", "Allusion_EN");
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", Enemies.Prior);
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", Enemies.Prioress);
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", Enemies.Help);
            med.AddRandomGroup("Celebration_EN", "Idiotware_EN", Enemies.Reckoner);

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 1, "Idiotware_EN");
            hard.AddRandomGroup("Celebration_EN", "Idiotware_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup("Celebration_EN", "Idiotware_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Celebration_EN", "Idiotware_EN", Enemies.Shivering, Enemies.Shivering);
        }
    }
}
