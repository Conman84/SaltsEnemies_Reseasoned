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

        public static void Screamer()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Satyr_EN", Enemies.Screaming, "Git_EN", "Git_EN");
            med.AddRandomGroup("Satyr_EN", Enemies.Screaming, "ChoirBoy_EN");
            med.AddRandomGroup("Satyr_EN", Enemies.Screaming, Jumble.Grey);

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Screaming, "Yang_EN", "Yang_EN");
            hard.AddRandomGroup("Satyr_EN", Enemies.Screaming, "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, Enemies.Screaming, "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup(Jumble.Grey, Enemies.Screaming, "ChoirBoy_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, Enemies.Screaming, "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup(Spoggle.Grey, Enemies.Screaming, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Spoggle.Grey, Enemies.Screaming, "OdeToHumanity_EN");

            AddTo easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Screaming);
            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "InHisImage_EN", "InHisImage_EN", Enemies.Screaming);
            med.AddRandomGroup(Flower.Red, "EvilDog_EN", "EvilDog_EN", Enemies.Screaming);
            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Screaming);
            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "InHisImage_EN", "InHisImage_EN", Enemies.Screaming);
            med.AddRandomGroup(Flower.Blue, "EvilDog_EN", "EvilDog_EN", Enemies.Screaming);

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "PawnA_EN", "PawnA_EN", Enemies.Screaming);
            med.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, Enemies.Screaming);

            hard = new AddTo(Garden.H.Flower.Grey.Hard);

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "EvilDog_EN", "EvilDog_EN", Enemies.Screaming);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Screaming, Enemies.Screaming);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Screaming, "EggKeeper_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Screaming);
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Screaming);
            med.AddRandomGroup("MiniReaper_EN", "Git_EN", "Git_EN", Enemies.Screaming);
            med.AddRandomGroup("MiniReaper_EN", "Bonsai_EN", "Bonsai_EN", Enemies.Screaming);

            easy = new AddTo(Garden.H.Merced.Easy);
            easy.SimpleAddGroup(1, "Merced_EN", 4, Enemies.Screaming);

            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.SimpleAddGroup(3, "EyePalm_EN", 1, Enemies.Screaming);

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(4, "EyePalm_EN", 1, Enemies.Screaming);
            med.SimpleAddGroup(2, "EyePalm_EN", 1, Enemies.Screaming, 2, Enemies.Shivering);

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Shua_EN", Enemies.Screaming, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Shua_EN", Enemies.Screaming, "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", Enemies.Screaming, "Firebird_EN");
            med.AddRandomGroup("Hunter_EN", Enemies.Screaming, Spoggle.Grey);
            med.AddRandomGroup("Hunter_EN", Enemies.Screaming, "CorpseChan_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Hunter_EN", Enemies.Screaming);
            med.AddRandomGroup("Firebird_EN", Enemies.Screaming, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Firebird_EN", Enemies.Screaming, "ChoirBoy_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Screaming);
            med.AddRandomGroup("Indicator_EN", "EvilDog_EN", "EvilDog_EN", Enemies.Screaming);
            med.AddRandomGroup("Indicator_EN", "EyePalm_EN", "EyePalm_EN", Enemies.Screaming);
            med.SimpleAddGroup(3, "Indicator_EN", 1, Enemies.Screaming);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", Enemies.Screaming, "Damocles_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomGroup("YNL_EN", Enemies.Screaming, Flower.Red, Flower.Blue);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Screaming, "OdeToHumanity_EN");
            med.AddRandomGroup("Stoplight_EN", Enemies.Screaming, "CorpseChan_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Screaming, Ecstasy.Gray, Ecstasy.Gray);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Screaming, "Sundowner_EN", "Sundowner_EN");
            hard.AddRandomGroup("Stoplight_EN", Enemies.Screaming, "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup(Bots.Grey, Enemies.Screaming, "Git_EN", "Git_EN");
            med.AddRandomGroup(Bots.Grey, Enemies.Screaming, "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Screaming, "Hunter_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Screaming, "Starless_EN");
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Screaming, "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, Enemies.Screaming);
            med.SimpleAddGroup(4, "EvilDog_EN", 1, Enemies.Screaming);

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", Enemies.Leviat, "BlackStar_EN");
            med.AddRandomGroup("Complimentary_EN", Enemies.Screaming, "Vivarium_EN");
            med.SimpleAddGroup(2, "Complimentary_EN", 1, Enemies.Screaming);

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", Enemies.Screaming, "Grandfather_EN");
            med.AddRandomGroup("PersonalAngel_EN", Enemies.Screaming, "Firebird_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Starless_EN", Enemies.Screaming, "Celebration_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Screaming, Enemies.Screaming, Enemies.Screaming);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Screaming, "Starless_EN");

            easy = new AddTo(Garden.H.Pawn.Easy);
            easy.AddRandomGroup("PawnA_EN", "PawnA_EN", "PawnA_EN", Enemies.Screaming);

            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(4, "PawnA_EN", 1, Enemies.Screaming);
            med.SimpleAddGroup(2, "PawnA_EN", 1, Enemies.Screaming, 2, Enemies.Shivering);

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Enemies.Screaming);
            med.AddRandomGroup("Yang_EN", Enemies.Screaming, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Yang_EN", Enemies.Screaming, "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, Enemies.Screaming);

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.SimpleAddGroup(2, "Yin_EN", 1, Enemies.Screaming);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", Enemies.Screaming);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", Enemies.Screaming, "ChoirBoy_EN");

            med = new AddTo(Garden.H.Sundowner.Med);
            med.SimpleAddGroup(3, "Sundowner_EN", 1, Enemies.Screaming);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 3, Enemies.Screaming);
            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Screaming);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Leviat);

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", Enemies.Screaming, "Vivarium_EN", "Vivarium_EN");
            med.AddRandomGroup("Lunoscope_EN", Enemies.Screaming, Ecstasy.Gray);

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", Enemies.Screaming, "Bonsai_EN", "Bonsai_EN");
            hard.AddRandomGroup("Lunoscope_EN", Enemies.Screaming, "ChoirBoy_EN");
            hard.AddRandomGroup("Lunoscope_EN", Enemies.Screaming, Enemies.Foundling);

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, Enemies.Screaming);
            med.SimpleAddGroup(2, "Panopticon_EN", 1, Enemies.Screaming, 1, "BlackStar_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, Enemies.Screaming);
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, Enemies.Screaming, 1, "GlassFigurine_EN");
            med.SimpleAddGroup(2, Ecstasy.Gray, 1, Enemies.Screaming, 1, "TortureMeNot_EN");

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Screaming, "Hauntling_EN", "Hauntling_EN");

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 1, Enemies.Screaming);

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, Enemies.Screaming);
            med.AddRandomGroup("Celebration_EN", Enemies.Screaming, "Git_EN", "Git_EN");
            med.AddRandomGroup("Celebration_EN", Enemies.Screaming, Spoggle.Grey);
            med.AddRandomGroup("Celebration_EN", Enemies.Screaming, Enemies.Minister);

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.SimpleAddGroup(2, "Celebration_EN", 2, Enemies.Screaming);
            hard.AddRandomGroup("Celebration_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Screaming);
            hard.AddRandomGroup("Celebration_EN", "EvilDog_EN", "EvilDog_EN", Enemies.Screaming);

            easy = new AddTo(Garden.H.Lightbulbkin.Easy);
            easy.AddRandomGroup("Lightbulbkin_EN", Enemies.Screaming, Enemies.Shivering);

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "Lightbulbkin_EN", Enemies.Screaming);
            med.AddRandomGroup("Lightbulbkin_EN", Enemies.Screaming, Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "Yang_EN");
            med.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, Ecstasy.Gray);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, Enemies.Eclipse);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "Stoplight_EN");
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "Starless_EN");
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "Hunter_EN");
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Screaming, "OdeToHumanity_EN");
        }
    }
}
