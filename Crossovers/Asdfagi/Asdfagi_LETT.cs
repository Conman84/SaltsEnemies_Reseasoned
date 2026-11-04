using System;
using System.Collections.Generic;
using System.Text;

//TangledGuests_EN
//GuestColony_EN

namespace SaltsEnemies_Reseasoned
{
    public static class Asdfagi_LETT
    {
        public static void _Logos(string med_enc, string hard_enc, string mainlogos)
        {
            AddTo med = new AddTo(med_enc);
            med.AddRandomGroup(mainlogos, "BlackStar_EN", "Yang_EN");
            med.AddRandomGroup(mainlogos, "LittleAngel_EN", "Grandfather_EN");
            med.AddRandomGroup(mainlogos, "WindSong_EN", Enemies.Shivering);
            med.AddRandomGroup(mainlogos, "MiniReaper_EN", "Damocles_EN");
            med.AddRandomGroup(mainlogos, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(mainlogos, "GlassFigurine_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomGroup(mainlogos, "Panopticon_EN", "Panopticon_EN");
            med.AddRandomGroup(mainlogos, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(mainlogos, "EvilDog_EN", "EvilDog_EN");
            med.AddRandomGroup(mainlogos, Bots.Grey, "NextOfKin_EN");
            if (SaltsReseasoned.rando < 20) med.AddRandomGroup(mainlogos, "Children6_EN");
            med.AddRandomGroup(mainlogos, "Lightbulbkin_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomGroup(mainlogos, "Yang_EN", "PawnA_EN");
            med.AddRandomGroup(mainlogos, "Shua_EN", "EyePalm_EN");

            AddTo hard = new AddTo(hard_enc);
            hard.AddRandomGroup(mainlogos, "Satyr_EN", "Indicator_EN");
            hard.AddRandomGroup(mainlogos, "Celebration_EN", "Celebration_EN");
            hard.AddRandomGroup(mainlogos, Enemies.Foundling, "Merced_EN");
            hard.AddRandomGroup(mainlogos, "OdeToHumanity_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomGroup(mainlogos, "Starless_EN", "Damocles_EN");
            hard.AddRandomGroup(mainlogos, "Stoplight_EN", "PawnA_EN");
            hard.AddRandomGroup(mainlogos, "Firebird_EN", "BlackStar_EN");
            hard.AddRandomGroup(mainlogos, "PersonalAngel_EN", "Lightbulbkin_EN");
            hard.AddRandomGroup(mainlogos, Ecstasy.Gray, Ecstasy.Gray);
            hard.AddRandomGroup(mainlogos, Enemies.Eclipse, "NextOfKin_EN", "NextOfKin_EN");
            hard.AddRandomGroup(mainlogos, "Yang_EN", "Yang_EN");
            hard.AddRandomGroup(mainlogos, "Complimentary_EN");
            hard.AddRandomGroup(mainlogos, "Insider_EN", "Insider_EN", Enemies.Shivering);
            hard.AddRandomGroup(mainlogos, "ClockTower_EN", Enemies.Skinning);
            hard.AddRandomGroup(mainlogos, "YNL_EN", "Grandfather_EN");
            hard.AddRandomGroup(mainlogos, "InTheDark_EN", "BlackStar_EN");
            hard.AddRandomGroup(mainlogos, "Lunoscope_EN", "EyePalm_EN");
            hard.AddRandomGroup(mainlogos, "CorpseChan_EN", "WindSong_EN");
        }
        public static void AddLogos()
        {
            _Logos(Garden.H.Logos.Red.Med, Garden.H.Logos.Red.Hard, Logos.Red);
            _Logos(Garden.H.Logos.Blue.Med, Garden.H.Logos.Blue.Hard, Logos.Blue);
            _Logos(Garden.H.Logos.Yellow.Med, Garden.H.Logos.Yellow.Hard, Logos.Yellow);
            _Logos(Garden.H.Logos.Purple.Med, Garden.H.Logos.Purple.Hard, Logos.Purple);
        }

        public static void AddShore()
        {
            AddTo med = new AddTo(Shore.H.Guests.Med);
            med.SimpleAddGroup(3, "TangledGuests_EN", 1, "LostSheep_EN");
            med.SimpleAddGroup(2, "TangledGuests_EN", 2, "Waltz_EN");

            AddTo hard = new AddTo(Shore.H.Guests.Hard);
            hard.AddRandomGroup("GuestColony_EN", "TangledGuests_EN", "Pinano_EN");
            hard.AddRandomGroup("GuestColony_EN", "TangledGuests_EN", "TangledGuests_EN", "LostSheep_EN");
            hard.AddRandomGroup("GuestColony_EN", "TangledGuests_EN", "Wall_EN");
            hard.AddRandomGroup("GuestColony_EN", "TangledGuests_EN", "ToyUfo_EN");
            hard.AddRandomGroup("GuestColony_EN", "TangledGuests_EN", "2009_EN");
            hard.AddRandomGroup("GuestColony_EN", "TangledGuests_EN", "VoiceTrumpet_EN");
            hard.AddRandomGroup("GuestColony_EN", "LittleBeak_EN");
            hard.AddRandomGroup("GuestColony_EN", "Jabberwocky_EN");

            AddTo easy = new AddTo(Shore.H.Clown.Easy);
            easy.SimpleAddGroup(2, "Waltz_EN", 1, "TangledGuests_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, "MudLung_EN", 1, "TangledGuests_EN");
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, "Pinano_EN", 1, "TangledGuests_EN");

            easy = new AddTo(Shore.H.Pinano.Easy);
            easy.AddRandomGroup("Pinano_EN", "TangledGuests_EN", "TangledGuests_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "TangledGuests_EN", "TangledGuests_EN");
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "TangledGuests_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.SimpleAddGroup(1, "AFlower_EN", 3, "TangledGuests_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "TangledGuests_EN", "TangledGuests_EN", Spoggle.Yellow);
            hard.AddRandomGroup("AFlower_EN", "TangledGuests_EN", "TangledGuests_EN", Spoggle.Blue);
            hard.AddRandomGroup("AFlower_EN", "TangledGuests_EN", "TangledGuests_EN", Spoggle.Unstable);

            med = new AddTo(Shore.H.Ufo.Med);
            med.SimpleAddGroup(1, "ToyUfo_EN", 3, "TangledGuests_EN");

            med = new AddTo(Shore.H.Wall.Med);
            med.SimpleAddGroup(2, "Wall_EN", 2, "TangledGuests_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Sinker_EN", "TangledGuests_EN", "TangledGuests_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.SimpleAddGroup(1, "LittleBeak_EN", 3, "TangledGuests_EN");
            med.AddRandomGroup("LittleBeak_EN", "TangledGuests_EN", "TangledGuests_EN", "Papereater_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "TangledGuests_EN", "TangledGuests_EN", "LittleBeak_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "TangledGuests_EN", "TangledGuests_EN", "Sinker_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.SimpleAddGroup(1, "Sinker_EN", 3, "TangledGuests_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.SimpleAddGroup(1, "Sinker_EN", 2, "TangledGuests_EN", 1, "Pinano_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.SimpleAddGroup(1, "2009_EN", 3, "TangledGuests_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.SimpleAddGroup(1, "33_EN", 4, "TangledGuests_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.SimpleAddGroup(1, "Jabberwocky_EN", 3, "TangledGuests_EN");
        }
        public static void AddOrph()
        {
            //no totenmaske ?
        }
        public static void AddGarden()
        {
            AddTo med = new AddTo(Garden.H.Vessel.Med);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "LittleAngel_EN");
            med.AddRandomGroup(Enemies.Vessel, Flower.Red, Flower.Blue);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, Spoggle.Grey);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "WindSong_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, Enemies.Spirit, "MiniReaper_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Shua_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Damocles_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Hunter_EN");
            med.AddRandomGroup(Enemies.Vessel, "Firebird_EN");
            med.AddRandomGroup(Enemies.Vessel, "Indicator_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "YNL_EN");
            med.AddRandomGroup(Enemies.Vessel, "EvilDog_EN", "EvilDog_EN");
            med.AddRandomGroup(Enemies.Vessel, "OdeToHumanity_EN", Enemies.Spirit);
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, Bots.Grey);
            med.AddRandomGroup(Enemies.Vessel, "Yang_EN", "PawnA_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Eclipse);
            med.AddRandomGroup(Enemies.Vessel, "Celebration_EN", "Celebration_EN");
            med.SimpleAddGroup(1, Enemies.Vessel, 3, "TortureMeNot_EN");
            med.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, Enemies.Camera);

            AddTo hard = new AddTo(Garden.H.Vessel.Hard);
            hard.SimpleAddGroup(2, Enemies.Vessel, 1, "Grandfather_EN");
            hard.SimpleAddGroup(2, Enemies.Vessel, 1, Enemies.Spirit, 1, Jumble.Gray);
            hard.SimpleAddGroup(2, Enemies.Vessel, 1, Enemies.Spirit, 1, "Skyloft_EN");
            hard.SimpleAddGroup(2, Enemies.Vessel, 1, Enemies.Spirit, 1, "BlackStar_EN");
            hard.SimpleAddGroup(1, Enemies.Vessel, 3, "PawnA_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Stoplight_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, Ecstasy.Gray, Ecstasy.Gray);
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Complimentary_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "PersonalAngel_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Starless_EN");
            hard.AddRandomGroup(Enemies.Vessel, "Eyeless_EN", Enemies.Spirit);
            hard.AddRandomGroup(Enemies.Vessel, "Yang_EN", "Yang_EN", Enemies.Spirit);
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Insider_EN", "Insider_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "CorpseChan_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Spirit, "Lunoscope_EN");
            hard.AddRandomGroup(Enemies.Spirit, Enemies.Vessel, "Panopticon_EN", "Panopticon_EN");
            hard.AddRandomGroup(Enemies.Vessel, Enemies.Eclipse, Enemies.Eclipse);
            hard.AddRandomGroup(Enemies.Vessel, "Lightbulbkin_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup(Enemies.Vessel, "Satyr_EN", Enemies.Spirit);

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", Enemies.Vessel, Enemies.Spirit);

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", "InTheDark_EN", Enemies.Vessel);

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Vessel, Enemies.Spirit);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Vessel, Enemies.Spirit);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Vessel, Enemies.Spirit, "GlassFigurine_EN");

            EcstasyPool.Add(Enemies.Vessel);
            EcstasyPool.Add(Enemies.Spirit);
        }
    }
}
