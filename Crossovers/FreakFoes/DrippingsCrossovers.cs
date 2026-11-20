using System;
using System.Collections.Generic;
using System.Text;

//Drippings_EN

namespace SaltsEnemies_Reseasoned
{
    public static class DrippingsCrossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Drippings_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Satyr_EN", "Drippings_EN", Enemies.Shivering, Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 1, "Drippings_EN", 2, "InHerImage_EN");
            hard.SimpleAddGroup(1, "Satyr_EN", 1, "Drippings_EN", 2, "EvilDog_EN");
            hard.AddRandomGroup("Satyr_EN", "Drippings_EN", Flower.Red, Flower.Blue);
            hard.SimpleAddGroup(1, "Satyr_EN", 1, "Drippings_EN", 2, Ecstasy.Gray);
            hard.SimpleAddGroup(1, "Satyr_EN", 1, "Drippings_EN", 2, "Bonsai_EN");
            hard.SimpleAddGroup(1, "Satyr_EN", 1, "Drippings_EN", 2, "Git_EN");
            hard.SimpleAddGroup(1, "Satyr_EN", 1, "Drippings_EN", 2, "Attrition_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "Drippings_EN", Enemies.Minister);
            med.AddRandomGroup(Jumble.Grey, "Drippings_EN", "Lightbulbkin_EN", "Lightbulbkin_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Drippings_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomGroup(Spoggle.Grey, "Drippings_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Camera.Med);
            med.SimpleAddGroup(2, Enemies.Camera, 1, "Drippings_EN", 1, "Grandfather_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, "Drippings_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "Drippings_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", "Drippings_EN");
            med.AddRandomGroup("MiniReaper_EN", "Bonsai_EN", "Bonsai_EN", "Drippings_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(4, "EyePalm_EN", 1, "Drippings_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Drippings_EN", "Allusion_EN");
            med.AddRandomGroup("Shua_EN", "Drippings_EN", Spoggle.Grey);
            med.AddRandomGroup("Shua_EN", "Drippings_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Drippings_EN", "Yang_EN");
            med.AddRandomGroup("Hunter_EN", "Drippings_EN", "Firebird_EN");
            med.AddRandomGroup("Hunter_EN", "Drippings_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("Hunter_EN", "Drippings_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Drippings_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Firebird_EN", "Drippings_EN", "Yang_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "Drippings_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("Indicator_EN", "Drippings_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Drippings_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("YNL_EN", "Drippings_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Drippings_EN", "EvilDog_EN");
            med.AddRandomGroup("Stoplight_EN", "Drippings_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Drippings_EN", Enemies.Eclipse);
            hard.AddRandomGroup("Stoplight_EN", "Drippings_EN", Bots.Grey);
            hard.AddRandomGroup("Stoplight_EN", "Drippings_EN", Enemies.Foundling);
            hard.AddRandomGroup("Stoplight_EN", "Drippings_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Drippings_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Drippings_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Drippings_EN", "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "Drippings_EN", Enemies.Eclipse);

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, "EvilDog_EN", 1, "Drippings_EN", 1, "EggKeeper_EN");
            med.SimpleAddGroup(2, "EvilDog_EN", 1, "Drippings_EN", 1, "Panopticon_EN");
            med.SimpleAddGroup(2, "EvilDog_EN", 1, "Drippings_EN", 1, "Insider_EN");
            med.SimpleAddGroup(2, "EvilDog_EN", 1, "Drippings_EN", 1, "Indicator_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Drippings_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Drippings_EN", "Lightbulbkin_EN");
            med.AddRandomGroup("Starless_EN", "Drippings_EN", "Yang_EN");
            med.AddRandomGroup("Starless_EN", "Drippings_EN", "Bonsai_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "Drippings_EN");
            hard.AddRandomGroup("Eyeless_EN", "Drippings_EN", Flower.Grey);
            hard.AddRandomGroup("Eyeless_EN", "Drippings_EN", "OdeToHumanity_EN");
            hard.AddRandomGroup("Eyeless_EN", "Drippings_EN", "Hunter_EN");
            hard.AddRandomGroup("Eyeless_EN", "Drippings_EN", Spoggle.Grey);

            med = new AddTo(Garden.H.Pawn.Med);
            med.SimpleAddGroup(3, "PawnA_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, "PawnA_EN", 1, "Drippings_EN", 1, "Indicator_EN");
            med.SimpleAddGroup(2, "PawnA_EN", 1, "Drippings_EN", 1, "Vivarium_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(2, "Yang_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, "Yang_EN", 1, "Drippings_EN", 1, "PawnA_EN");
            med.SimpleAddGroup(1, "Yang_EN", 1, "Drippings_EN", 2, "PawnA_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, "Drippings_EN");
            hard.SimpleAddGroup(2, "Yang_EN", 1, "Drippings_EN", 2, "PawnA_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", "Drippings_EN");
            hard.AddRandomGroup("Yin_EN", "Yin_EN", "Drippings_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Drippings_EN", "OdeToHumanity_EN");
            med.AddRandomGroup("CorpseChan_EN", "Drippings_EN", "ChoirBoy_EN");
            med.AddRandomGroup("CorpseChan_EN", "Drippings_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "Drippings_EN", "VIvarium_EN");
            med.AddRandomGroup("InTheDark_EN", "Drippings_EN", "WindSong_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, "Drippings_EN");

            med = new AddTo(Garden.H.Sundowner.Med);
            med.SimpleAddGroup(3, "Sundowner_EN", 1, "Drippings_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "Drippings_EN", Ecstasy.Gray);
            med.AddRandomGroup("Lunoscope_EN", "Drippings_EN", "Attrition_EN");
            med.AddRandomGroup("Lunoscope_EN", "Drippings_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "Drippings_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Drippings_EN", Bots.Grey, "Drippings_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Drippings_EN", Enemies.Eclipse, "Drippings_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Drippings_EN", "Celebration_EN", "Drippings_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Drippings_EN");
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "Drippings_EN", 1, "Vivarium_EN");
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "Drippings_EN", 1, "Bonsai_EN");
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "Drippings_EN", 1, "EvilDog_EN");

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, "Drippings_EN");
        }
    }
}
