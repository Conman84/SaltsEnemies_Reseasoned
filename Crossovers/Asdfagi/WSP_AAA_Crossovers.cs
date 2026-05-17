using System;
using System.Collections.Generic;
using System.Text;

//WinterLantern_EN

//SomeoneSister_EN
//NooneSister_EN
//re-review the sisters encounters if they get tweaked to be more equal.

//Phobia_Phobias_EN

namespace SaltsEnemies_Reseasoned
{
    public static class WSP_AAA_Crossovers
    {
        public static void Add()
        {
            AddTo med = new AddTo(Siren.H.Ecstasy.Red.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, "BirdBath_EN", "WinterLantern_EN");
            med = new AddTo(Siren.H.Ecstasy.Blue.Med);
            med.AddRandomGroup(Ecstasy.Blue, Ecstasy.Red, "BirdBath_EN", "WinterLantern_EN");
            med = new AddTo(Siren.H.Ecstasy.Yellow.Med);
            med.AddRandomGroup(Ecstasy.Yellow, Ecstasy.Red, "BirdBath_EN", "WinterLantern_EN");
            med = new AddTo(Siren.H.Ecstasy.Purple.Med);
            med.AddRandomGroup(Ecstasy.Purple, Ecstasy.Red, "BirdBath_EN", "WinterLantern_EN");

            med = new AddTo(Siren.H.Winterlantern.Med);
            med.AddRandomGroup("WinterLantern_EN", Ecstasy.Random, "Stalker2_EN");
            med.AddRandomGroup("WinterLantern_EN", "Tassnn_EN", "Stalker2_EN");

            med = new AddTo(Garden.H.Sisters.Med);
            med.AddRandomGroup(Enemies.MainSister, "Grandfather_EN", "BlackStar_EN");
            med.SimpleAddGroup(1, Enemies.MainSister, 3, "Damocles_EN");
            med.AddRandomGroup(Enemies.MainSister, "MiniReaper_EN", Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Sisters.Hard);
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, "LittleAngel_EN");
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, "WindSong_EN");
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, Ecstasy.Gray);
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, Jumble.Gray);
            hard.SimpleAddGroup(1, Enemies.MainSister, 3, "EyePalm_EN");
            hard.AddRandomGroup(Enemies.MainSister, Enemies.SubSister, "Indicator_EN");
            hard.SimpleAddGroup(1, Enemies.MainSister, 2, "Insider_EN");
            hard.SimpleAddGroup(1, Enemies.MainSister, 2, Ecstasy.Gray);
            hard.SimpleAddGroup(1, Enemies.MainSister, 1, Enemies.SubSister, 2, "TortureMeNot_EN");
            hard.SimpleAddGroup(1, Enemies.MainSister, 3, "PawnA_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Gray, "SomeoneSister_EN", "Grandfather_EN");
            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Gray, "NooneSister_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "SomeoneSister_EN", "BlackStar_EN");
            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "NooneSister_EN", "SomeoneSister_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "NooneSister_EN", "SomeoneSister_EN");
            hard.AddRandomGroup("ClockTower_EN", "NooneSister_EN", Enemies.Camera, Enemies.Camera);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "NooneSister_EN", "SomeoneSister_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "SomeoneSister_EN", Jumble.Gray);

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.MainSister);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "NooneSister_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Enemies.MainSister, "Children6_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", Enemies.MainSister, Enemies.Shivering);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "SomeoneSister_EN", "Yang_EN");
            hard.AddRandomGroup("Stoplight_EN", "SomeoneSister_EN", "NooneSister_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Gray, Enemies.MainSister, "TortureMeNot_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, Enemies.MainSister);

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "NooneSister_EN", "Merced_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", Enemies.MainSister);

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "NooneSister_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "SomeoneSister_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "SomeoneSister_EN", "SomeoneSister_EN");
            hard.AddRandomGroup("Eyeless_EN", "SomeoneSister_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "SomeoneSister_EN", "PawnA_EN");
            med.AddRandomGroup("Yang_EN", "SomeoneSister_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", Enemies.MainSister);
            hard.AddRandomGroup("Yang_EN", Enemies.MainSister, "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", Enemies.MainSister);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "SomeoneSister_EN", "TortureMeNot_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", "SomeoneSister_EN", "WindSong_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", "SomeoneSister_EN", "SomeoneSister_EN");
            hard.AddRandomGroup("InTheDark_EN", "InTheDark_EN", "SomeoneSister_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", "SomeoneSister_EN", "Romantic_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", Enemies.MainSister, "SomeoneSister_EN");
            hard.AddRandomGroup("Lunoscope_EN", "NooneSister_EN", Jumble.Gray);
            hard.AddRandomGroup("Lunoscope_EN", "SomeoneSister_EN", "Grandfather_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "SomeoneSister_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(2, "Panopticon_EN", 1, "SomeoneSister_EN", 1, Enemies.Shivering);

            med = new AddTo(Garden.H.Phobia.Med);
            med.SimpleAddGroup(2, Enemies.Phobia, 1, "LittleAngel_EN");
            med.SimpleAddGroup(2, Enemies.Phobia, 1, Jumble.Gray);
            med.SimpleAddGroup(1, Enemies.Phobia, 2, Enemies.Camera);
            med.SimpleAddGroup(1, Enemies.Phobia, 2, "EyePalm_EN");
            med.AddRandomGroup(Enemies.Phobia, "Hunter_EN", "Firebird_EN");
            med.SimpleAddGroup(1, Enemies.Phobia, 2, "EvilDog_EN");
            med.AddRandomGroup(Enemies.Phobia, "Complimentary_EN");
            med.SimpleAddGroup(1, Enemies.Phobia, 2, "Insider_EN");

            hard = new AddTo(Garden.H.Phobia.Hard);
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, Spoggle.Gray);
            hard.AddRandomGroup(Enemies.Phobia, "Satyr_EN", "ChoirBoy_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "WindSong_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "Shua_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "Indicator_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "YNL_EN");
            hard.AddRandomGroup(Enemies.Phobia, "Stoplight_EN", "BlackStar_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 1, "OdeToHumanity_EN");
            hard.AddRandomGroup(Enemies.Phobia, "PersonalAngel_EN", "Romantic_EN");
            hard.AddRandomGroup(Enemies.Phobia, "Starless_EN", "Damocles_EN");
            hard.SimpleAddGroup(1, Enemies.Phobia, 3, "PawnA_EN");
            hard.AddRandomGroup(Enemies.Phobia, "Yang_EN", "Yang_EN");
            hard.AddRandomGroup(Enemies.Phobia, "CorpseChan_EN", Flower.Red);
            hard.AddRandomGroup(Enemies.Phobia, "InTheDark_EN", Enemies.Minister);
            hard.SimpleAddGroup(2, Enemies.Phobia, 2, "Sundowner_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 2, "Panopticon_EN");
            hard.SimpleAddGroup(2, Enemies.Phobia, 2, Ecstasy.Gray);
            hard.AddRandomGroup(Enemies.Phobia, "Lunoscope_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Phobia);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", Enemies.Phobia, Enemies.Phobia);

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Phobia);

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(2, "GlassedSun_EN", 1, Enemies.Phobia);

            EcstasyPool.Add(Enemies.Phobia);
            EcstasyPool.Add("SomeoneSister_EN");
            EcstasyPool.Add("NooneSister_EN");
            EcstasyPool.Add("WinterLantern_EN");
            EcstasyPool.Add("Phobia_Eyes_EN");
            EcstasyPool.Add("Phobia_Words_EN");
            EcstasyPool.Add("Phobia_Darkness_EN");
            EcstasyPool.Add("Phobia_Death_EN");
            EcstasyPool.Add(Symbols.Red);
            EcstasyPool.Add(Symbols.Blue);
            EcstasyPool.Add(Symbols.Yellow);
            EcstasyPool.Add(Symbols.Purple);
        }
    }
}
