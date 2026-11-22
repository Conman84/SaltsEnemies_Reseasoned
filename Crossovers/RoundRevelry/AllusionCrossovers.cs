using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AllusionCrossovers
    {
        public static void Add()
        {
            AddTo easy = new AddTo(Garden.H.Allusion.Easy);
            easy.AddRandomGroup("Allusion_EN", "BlackStar_EN", "BlackStar_EN");
            easy.AddRandomGroup("Allusion_EN", Enemies.Camera, Enemies.Camera);
            easy.AddRandomGroup("Allusion_EN", "PawnA_EN", "PawnA_EN");
            easy.AddRandomGroup("Allusion_EN", "LittleAngel_EN");

            AddTo med = new AddTo(Garden.H.Allusion.Med);
            //med.SimpleAddGroup(1, "Allusion_EN", 3, "EyePalm_EN");
            //med.SimpleAddGroup(1, "Allusion_EN", 3, "PawnA_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "EyePalm_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(1, "Allusion_EN", 3, "Hauntling_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "Hauntling_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 3, "Vivarium_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "Indicator_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "Skyloft_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "Grandfather_EN");
            med.SimpleAddGroup(2, "Allusion_EN", 1, "WindSong_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Allusion_EN", "Allusion_EN");
            med.AddRandomGroup("Satyr_EN", "Allusion_EN", "BlackStar_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Allusion_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Satyr_EN", "Allusion_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "Allusion_EN", "Allusion_EN");
            med.AddRandomGroup(Jumble.Grey, "Allusion_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Jumble.Grey, "Allusion_EN", "WindSong_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Allusion_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomGroup(Spoggle.Grey, "Allusion_EN", "Panopticon_EN");
            med.AddRandomGroup(Spoggle.Grey, "Allusion_EN", Enemies.Shivering, Enemies.Shivering);

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, "Allusion_EN", "NextOfKin_EN", "NextOfKin_EN");
            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Allusion_EN");
            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, "Allusion_EN", "NextOfKin_EN", "NextOfKin_EN");
            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Allusion_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Allusion_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "InHisImage_EN", "InHerImage_EN", "Allusion_EN");
            hard.AddRandomGroup(Flower.Grey, "Bonsai_EN", "Bonsai_EN", "Allusion_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Allusion_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.SimpleAddGroup(1, "MiniReaper_EN", 2, "Allusion_EN");
            med.AddRandomGroup("MiniReaper_EN", "Allusion_EN", "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "Allusion_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Allusion_EN", "Git_EN");
            med.AddRandomGroup("Shua_EN", "Allusion_EN", Jumble.Mythos);
            med.AddRandomGroup("Shua_EN", "Allusion_EN", Jumble.Gray);
            med.AddRandomGroup("Shua_EN", "Allusion_EN", "Drippings_EN");
            med.AddRandomGroup("Shua_EN", "Allusion_EN", Enemies.Shivering, Enemies.Shivering);

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "Allusion_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Allusion_EN", "Allusion_EN");
            med.AddRandomGroup("Hunter_EN", "Allusion_EN", "Shua_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Allusion_EN", Flower.Blue);
            med.AddRandomGroup("Firebird_EN", "Allusion_EN", "Damocles_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.SimpleAddGroup(2, "Indicator_EN", 1, "Allusion_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Allusion_EN", "Shua_EN");
            med.AddRandomGroup("YNL_EN", "Allusion_EN", "Indicator_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Allusion_EN", "Damocles_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Allusion_EN", Enemies.Foundling);
            hard.AddRandomGroup("Stoplight_EN", "Allusion_EN", "OdeToHumanity_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Allusion_EN", "Drippings_EN");
            med.AddRandomGroup(Bots.Grey, "Allusion_EN", "Indicator_EN");
            med.AddRandomGroup(Bots.Grey, "Allusion_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Allusion_EN", "EvilDog_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Allusion_EN", Ecstasy.Gray);

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Allusion_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Allusion_EN", Flower.Red);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Allusion_EN", Enemies.Camera);
            med.AddRandomGroup("Starless_EN", "Allusion_EN", "EyePalm_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Allusion_EN", "BlackStar_EN", "BlackStar_EN");
            hard.AddRandomGroup("Eyeless_EN", "Allusion_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, "Allusion_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 1, "Allusion_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Allusion_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", "Allusion_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Allusion_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomGroup("CorpseChan_EN", "Allusion_EN", "Attrition_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Allusion_EN", "EggKeeper_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Allusion_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Allusion_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup("Lunoscope_EN", "Allusion_EN", "Allusion_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "Allusion_EN", "Git_EN", "Git_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Allusion_EN", "Ascendant_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Allusion_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Allusion_EN");
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "Allusion_EN", 1, "Grandfather_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, "Allusion_EN");
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, "Allusion_EN", 1, "Insider_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, "Allusion_EN", "Yang_EN");
            med.AddRandomGroup(Enemies.Eclipse, "Allusion_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Allusion_EN", "Allusion_EN", Enemies.Foundling);
            hard.AddRandomGroup("ClockTower_EN", "Allusion_EN", "Allusion_EN", Bots.Grey);

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, "Allusion_EN");

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, "Allusion_EN");
            med.AddRandomGroup("Celebration_EN", "Allusion_EN", "Allusion_EN");

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.AddRandomGroup("Celebration_EN", "Allusion_EN", "InHisImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Celebration_EN", "Allusion_EN", "EvilDog_EN", "EvilDog_EN");

            easy = new AddTo(Garden.H.Lightbulbkin.Easy);
            easy.AddRandomGroup("Allusion_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "Allusion_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Lightbulbkin_EN", "Allusion_EN", "EyePalm_EN", "EyePalm_EN");

            EcstasyPool.Add("Allusion_EN");
        }
    }
}
