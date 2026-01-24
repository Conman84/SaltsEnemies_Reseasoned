using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class FoundlingEncounters
    {
        public static void Post()
        {
            AddTo h_found = new AddTo(Garden.H.Foundling.Hard);
            h_found.SimpleAddGroup(3, Enemies.Foundling, 1, "LittleAngel_EN");

            h_found.SimpleAddGroup(2, Enemies.Foundling, 1, "Satyr_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Foundling, "Hunter_EN");
            hard.AddRandomGroup("Satyr_EN", Enemies.Foundling, Enemies.Minister);
            hard.AddRandomGroup("Satyr_EN", Enemies.Foundling, "ChoirBoy_EN");

            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Enemies.Foundling);
            med.AddRandomGroup("Satyr_EN", Enemies.Foundling, "BlackStar_EN");

            AddTo m_found = new AddTo(Garden.H.Foundling.Med);
            m_found.AddRandomGroup(Enemies.Foundling, Enemies.Camera, Enemies.Camera);

            m_found.AddRandomGroup(Enemies.Foundling, Spoggle.Gray, "InHisImage_EN", "InHisImage_EN");

            m_found.AddRandomGroup(Enemies.Foundling, Flower.Red, Flower.Blue);

            m_found.AddRandomGroup(Enemies.Foundling, Jumble.Gray, "Attrition_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, Enemies.Foundling);
            hard.SimpleAddGroup(1, "ClockTower_EN", 1, Enemies.Foundling, 2, "Bonsai_EN");
            hard.SimpleAddGroup(1, "ClockTower_EN", 1, Enemies.Foundling, 3, "PawnA_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "WindSong_EN", "Bonsai_EN", "Bonsai_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Foundling, Enemies.Foundling);
            hard.AddRandomGroup(Enemies.Tank, Enemies.Foundling, "Romantic_EN");
            hard.AddRandomGroup(Enemies.Tank, Enemies.Foundling, "EggKeeper_EN");

            h_found.SimpleAddGroup(3, Enemies.Foundling, 1, "Grandfather_EN");

            h_found.SimpleAddGroup(3, Enemies.Foundling, 1, Flower.Gray);

            m_found.SimpleAddGroup(1, Enemies.Foundling, 3, "EyePalm_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "Merced_EN", "EvilDog_EN", "EvilDog_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "MiniReaper_EN", "InHisImage_EN", "InHerImage_EN");

            h_found.SimpleAddGroup(3, Enemies.Foundling, 1, "MiniReaper_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "Shua_EN", "YNL_EN");

            h_found.SimpleAddGroup(2, Enemies.Foundling, 1, "Skyloft_EN", 1, "InTheDark_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "Damocles_EN", "ChoirBoy_EN");

            h_found.AddRandomGroup(Enemies.Foundling, "GlassFigurine_EN", "Stoplight_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Enemies.Foundling);

            m_found.AddRandomGroup(Enemies.Foundling, "Firebird_EN", "PawnA_EN", "PawnA_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "Hunter_EN", "EyePalm_EN", "EyePalm_EN");

            h_found.SimpleAddGroup(3, Enemies.Foundling, 1, "BlackStar_EN");
            m_found.AddRandomGroup(Enemies.Foundling, "BlackStar_EN", Enemies.Polyp);

            m_found.AddRandomGroup(Enemies.Foundling, "Indicator_EN", Noses.Yellow);

            m_found.AddRandomGroup(Enemies.Foundling, Enemies.Minister, "Children6_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Enemies.Foundling);
            med.AddRandomGroup("Stopight_EN", Enemies.Foundling, Enemies.Shivering);
            med.AddRandomGroup("Stoplight_EN", Enemies.Foundling, "Surrogate_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Foundling, "Romantic_EN", "Romantic_EN");
            hard.AddRandomGroup("Stoplight_EN", Enemies.Foundling, Noses.Purple);
            hard.AddRandomGroup("Stoplight_EN", Enemies.Foundling, "CorpseChan_EN");

            h_found.SimpleAddGroup(2, Enemies.Foundling, 1, "Stoplight_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "YNL_EN", "EyePalm_EN", "EyePalm_EN");

            m_found.AddRandomGroup(Enemies.Foundling, Bots.Gray, "Yang_EN");

            h_found.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "OdeToHumanity_EN", "Damocles_EN");

            m_found.SimpleAddGroup(1, Enemies.Foundling, 4, "TortureMeNot_EN");

            m_found.SimpleAddGroup(1, Enemies.Foundling, 3, "EvilDog_EN");

            h_found.AddRandomGroup(Enemies.Foundling, "Complimentary_EN", Enemies.Foundling);

            h_found.AddRandomGroup(Enemies.Foundling, "PersonalAngel_EN", Enemies.Skinning);

            m_found.SimpleAddGroup(1, Enemies.Foundling, 3, "PawnA_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "Starless_EN", Enemies.Shivering, Enemies.Shivering);

            h_found.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Eyeless_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "Yang_EN", "PawnA_EN");

            h_found.AddRandomGroup(Enemies.Foundling, "Yang_EN", "Yin_EN");

            m_found.AddRandomGroup(Enemies.Foundling, "CorpseChan_EN", Enemies.Shivering);

            h_found.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Firebird_EN", "Hauntling_EN");

            h_found.SimpleAddGroup(1, Enemies.Foundling, 2, "Insider_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", Enemies.Foundling);
            med.AddRandomGroup("InTheDark_EN", Enemies.Foundling, "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(2, "InTheDark_EN", 1, Enemies.Foundling);
            hard.AddRandomGroup("InTheDark_EN", Enemies.Foundling, "ChoirBoy_EN");
            hard.AddRandomGroup("InTheDark_EN", Enemies.Foundling, "Attrition_EN", "Attrition_EN");

            h_found.SimpleAddGroup(2, Enemies.Foundling, 1, "InTheDark_EN");

            h_found.SimpleAddGroup(1, Enemies.Foundling, 3, "Sundowner_EN");

            h_found.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Lunoscope_EN");

            m_found.SimpleAddGroup(1, Enemies.Foundling, 2, "Panopticon_EN", 1, "Romantic_EN");
        }
    }
}
