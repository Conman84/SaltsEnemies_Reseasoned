using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Fishy_Garden_First
    {
        public static void Add()
        {
            AddTo hard = new AddTo(Garden.H.Portrait.Hard);
            hard.AddRandomGroup(Enemies.Portrait, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Portrait, Flower.Red, Flower.Purple);
            hard.AddRandomGroup(Enemies.Portrait, "MiniReaper_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Portrait, "Damocles_EN", "Damocles_EN");
            hard.AddRandomGroup(Enemies.Portrait, "Firebird_EN");
            hard.AddRandomGroup(Enemies.Portrait, "BlackStar_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Portrait, "EvilDog_EN", "EvilDog_EN");
            hard.AddRandomGroup(Enemies.Portrait, "Complimentary_EN");
            hard.AddRandomGroup(Enemies.Portrait, "Celebration_EN", Enemies.Shivering);
            hard.AddRandomGroup(Enemies.Portrait, "Lightbulbkin_EN", Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Portrait, Enemies.Prior, "Indicator_EN");
            hard.AddRandomGroup(Enemies.Portrait, Enemies.Eclipse);
            hard.AddRandomGroup(Enemies.Portrait, "CorpseChan_EN");
            hard.AddRandomGroup(Enemies.Portrait, "Yang_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Portrait, Bots.Gray, "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Portrait, "BlackStar_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Portrait, "Skyloft_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Portrait, "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", Enemies.Portrait, Enemies.Shivering);

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Portrait);

            EcstasyPool.Add(Enemies.Portrait);

            //WHEN DONE, DELETE HALF THE IMAGES ENCOUNTES RANDOMLY
            AddTo med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", Enemies.Prioress, "LittleAngel_EN");
            med.AddRandomGroup("Lightbulbkin_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("EyePalm_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("EyePalm_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Damocles_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Children6_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("Panopticon_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup(Ecstasy.Gray, "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("Lightbulbkin_EN", "InHerImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Indicator_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Merced_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("GlassFigurine_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("Children6_EN", "InHerImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Panopticon_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("Panopticon_EN", "InHerImage_EN", "InHisImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup(Spoggle.Grey, Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Prior);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Prioress);
            med.AddRandomGroup(Flower.Red, Enemies.Prior, Enemies.Prioress);
            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Prior);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Enemies.Prioress);
            med.AddRandomGroup(Flower.Blue, Enemies.Prior, Enemies.Prioress);

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup(Flower.Grey, Flower.Red, Enemies.Prioress);
            med.AddRandomGroup(Flower.Grey, Flower.Blue, Enemies.Prior);

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Gray, Flower.Red, Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup(Flower.Gray, Flower.Blue, Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup(Flower.Gray, Flower.Red, Flower.Blue, Enemies.Prior);
            hard.AddRandomGroup(Flower.Gray, Flower.Red, Flower.Blue, Enemies.Prioress);

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", Enemies.Prioress);
            med.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", Enemies.Prior);
            med.AddRandomGroup("Satyr_EN", Enemies.Prior, "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup("Satyr_EN", Enemies.Prioress, "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Satyr_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            hard.AddRandomGroup("Satyr_EN", Enemies.Prior, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Satyr_EN", Enemies.Prioress, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Satyr_EN", Enemies.Foundling, Enemies.Prior, Enemies.Prioress);

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("Grandfather_EN", Enemies.Prioress, Enemies.Prioress);
            med.AddRandomGroup("Grandfather_EN", "PawnA_EN", "PawnA_EN", Enemies.Prioress);
            med.AddRandomGroup("Grandfather_EN", "PawnA_EN", "PawnA_EN", Enemies.Prior);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, Enemies.Prioress, Enemies.Prioress);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, Enemies.Prior, Enemies.Prior);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Foundling, Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Foundling, Enemies.Prioress, Enemies.Prioress);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Foundling, Enemies.Prior, Enemies.Prior);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Prioress, Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Prior, Enemies.Prior);

            //WHEN DONE, DELETE HALF THE MINISTER ENCOUNTES RANDOMLY
            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "WindSong_EN", Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Minister, "WindSong_EN", Enemies.Prioress, Enemies.Prioress);

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "GlassFigurine_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup(Enemies.Minister, "PawnA_EN", "PawnA_EN", Enemies.Prioress);
            med.AddRandomGroup(Enemies.Minister, "Children6_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup(Enemies.Minister, Ecstasy.Gray, Ecstasy.Gray, Enemies.Prioress);
            med.AddRandomGroup(Enemies.Minister, Enemies.Prior, "EvilDog_EN", "EvilDog_EN");
            med.AddRandomGroup(Enemies.Minister, Enemies.Prioress, "EvilDog_EN", "EvilDog_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Enemies.Prior);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Enemies.Prioress);
            med.SimpleAddGroup(2, "EyePalm_EN", 2, Enemies.Prior);
            med.SimpleAddGroup(2, "EyePalm_EN", 2, Enemies.Prioress);
            med.SimpleAddGroup(2, "EyePalm_EN", 1, Enemies.Prioress, 1, Enemies.Prior);

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("Shua_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Shua_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("Shua_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);

            hard = new AddTo(Garden.H.Merced.Hard);
            hard.SimpleAddGroup(1, "Merced_EN", 2, Enemies.Prior, 2, Enemies.Prioress);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", Enemies.Prior, Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup("Miriam_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);
            hard.AddRandomGroup("Miriam_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("Hunter_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Indicator_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("Indicator_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("Firebird_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Firebird_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("Firebird_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            med.AddRandomGroup("YNL_EN", Enemies.Prior, Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("YNL_EN", Enemies.Prioress, Enemies.Prioress, Enemies.Prioress);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Stoplight_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("Stoplight_EN", Enemies.Prioress, Enemies.Prioress);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Stoplight_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            hard.AddRandomGroup("Stoplight_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Stoplight_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup(Bots.Grey, "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup(Bots.Grey, "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup(Bots.Grey, "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, Enemies.Prior);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, Enemies.Prioress);

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("OdeToHumanity_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("OdeToHumanity_EN", Enemies.Prior, Enemies.Prioress);

            med = new AddTo(Garden.H.EvilDog.Med);
            med.AddRandomGroup("EvilDog_EN", "EvilDog_EN", "EvilDog_EN", Enemies.Prior);
            med.AddRandomGroup("EvilDog_EN", "EvilDog_EN", "EvilDog_EN", Enemies.Prioress);
            med.SimpleAddGroup(2, "EvilDog_EN", 2, Enemies.Prior);
            med.SimpleAddGroup(2, "EvilDog_EN", 2, Enemies.Prioress);

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Complimentary_EN", Enemies.Prioress, Enemies.Prioress);
            med.AddRandomGroup("Complimentary_EN", Enemies.Prior, Enemies.Prior);

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("PersonalAngel_EN", Enemies.Prior, Enemies.Prioress);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("Starless_EN", Enemies.Prior, Enemies.Prioress);

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup("Eyeless_EN", Enemies.Prioress, Enemies.Prioress);
            hard.AddRandomGroup("Eyeless_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Eyeless_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Eyeless_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Enemies.Prioress, Enemies.Prioress);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("Yang_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            med.AddRandomGroup("Yang_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Yang_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            med.AddRandomGroup("Yang_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            med.AddRandomGroup("Yang_EN", "PawnA_EN", "PawnA_EN", Enemies.Prior);
            med.AddRandomGroup("Yang_EN", "PawnA_EN", "PawnA_EN", Enemies.Prioress);

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(3, "Yang_EN", 1, Enemies.Prior);
            hard.SimpleAddGroup(3, "Yang_EN", 1, Enemies.Prioress);

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Enemies.Prior);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Enemies.Prioress);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Enemies.Prior, Enemies.Prior);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", Enemies.Prioress, Enemies.Prioress);

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("InTheDark_EN", Enemies.Prioress, Enemies.Prioress);
            med.AddRandomGroup("InTheDark_EN", Enemies.Prior, Enemies.Prior);

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", "InTheDark_EN", Enemies.Prior);
            hard.AddRandomGroup("InTheDark_EN", "InTheDark_EN", Enemies.Prioress);
            hard.AddRandomGroup("InTheDark_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("InTheDark_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            hard.AddRandomGroup("InTheDark_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("InTheDark_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);

            //RANDOMLY REMOVE HALF ENCOUNES
            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Yang_EN", Enemies.Prioress);
            med.AddRandomGroup(Enemies.Skinning, "PawnA_EN", "PawnA_EN", Enemies.Prior);
            med.AddRandomGroup(Enemies.Skinning, "EyePalm_EN", "EyePalm_EN", Enemies.Prioress);
            med.AddRandomGroup(Enemies.Skinning, "Lightbulbkin_EN", Enemies.Prior);
            med.AddRandomGroup(Enemies.Skinning, "Lightbulbkin_EN", Enemies.Prioress);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "EvilDog_EN", "EvilDog_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Skinning, "Starless_EN", Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Eclipse, Enemies.Prior);
            hard.AddRandomGroup(Enemies.Skinning, Ecstasy.Gray, Enemies.Prior);
            hard.AddRandomGroup(Enemies.Skinning, Ecstasy.Gray, Enemies.Prioress);

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Lunoscope_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("Lunoscope_EN", Enemies.Prioress, Enemies.Prioress);

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Lunoscope_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);
            hard.AddRandomGroup("Lunoscope_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Lunoscope_EN", "InHerImage_EN", "InHerImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, Enemies.Prior);
            med.AddRandomGroup("Panopticon_EN", "Panopticon_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Panopticon_EN", "Panopticon_EN", Enemies.Prior, Enemies.Prior);

            med = new AddTo(Garden.H.Ecstasy99.Med);
            med.SimpleAddGroup(3, Ecstasy.Gray, 1, Enemies.Prior);
            med.AddRandomGroup(Ecstasy.Gray, Ecstasy.Gray, Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup(Ecstasy.Gray, Ecstasy.Gray, Enemies.Prior, Enemies.Prior);

            med = new AddTo(Garden.H.Eclipse.Med);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup(Enemies.Eclipse, Enemies.Prioress, Enemies.Prioress);

            hard = new AddTo(Garden.H.Eclipse.Hard);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 2, Enemies.Prior);
            hard.SimpleAddGroup(2, Enemies.Eclipse, 2, Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Eclipse, "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Eclipse, "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Eclipse, "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Eclipse, "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Celebration.Med);
            med.SimpleAddGroup(2, "Celebration_EN", 1, Enemies.Prior);
            med.SimpleAddGroup(2, "Celebration_EN", 1, Enemies.Prioress);
            med.AddRandomGroup("Celebration_EN", Enemies.Prior, Enemies.Prioress);
            med.AddRandomGroup("Celebration_EN", Enemies.Prior, Enemies.Prior);
            med.AddRandomGroup("Celebration_EN", Enemies.Prioress, Enemies.Prioress);

            hard = new AddTo(Garden.H.Celebration.Hard);
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", Enemies.Prior, Enemies.Prioress);
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", Enemies.Prior, Enemies.Prior);
            hard.AddRandomGroup("Celebration_EN", "Celebration_EN", Enemies.Prioress, Enemies.Prioress);
            hard.AddRandomGroup("Celebration_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Celebration_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Prioress);
            hard.AddRandomGroup("Celebration_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prior);
            hard.AddRandomGroup("Celebration_EN", "InHisImage_EN", "InHerImage_EN", Enemies.Prioress);

            med = new AddTo(Garden.H.Lightbulbkin.Med);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 1, Enemies.Prior, 1, Enemies.Prioress);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 2, Enemies.Prior);
            med.SimpleAddGroup(2, "Lightbulbkin_EN", 2, Enemies.Prioress);

            //REMOVE HALF WHEN DONE
            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, Enemies.Prior, "Celebration_EN");
            med.AddRandomGroup(Enemies.Foundling, Enemies.Prioress, "Celebration_EN");
            med.AddRandomGroup(Enemies.Foundling, Flower.Red, Enemies.Prior);
            med.AddRandomGroup(Enemies.Foundling, "PawnA_EN", "PawnA_EN", Enemies.Prioress);

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, Enemies.Prior, Spoggle.Gray);
            hard.AddRandomGroup(Enemies.Foundling, "OdeToHumanity_EN", Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Foundling, "Starless_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Foundling, "Starless_EN", Enemies.Prioress);
            hard.AddRandomGroup(Enemies.Foundling, "Yang_EN", "Yang_EN", Enemies.Prior);
            hard.AddRandomGroup(Enemies.Foundling, "Lunoscope_EN", Enemies.Prior);

            EcstasyPool.Add(Enemies.Prior);
            EcstasyPool.Add(Enemies.Prioress);
        }
    }
}
