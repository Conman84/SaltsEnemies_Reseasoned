using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PanopticonEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_PanopticonEncounter_Sign", ResourceLoader.LoadSprite("PanopticonWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Panopticon.Med, "Salt_PanopticonEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PanopticonPlaceholder";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.SimpleAddEncounter(4, "Panopticon_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "InHisImage_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "PawnA_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 1, "InHisImage_EN", 1, "InHerImage_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, Enemies.Shivering);
            med.SimpleAddEncounter(2, "Panopticon_EN", 1, Enemies.Minister);
            med.SimpleAddEncounter(2, "Panopticon_EN", 1, Flower.Blue, 1, Flower.Red);
            med.SimpleAddEncounter(2, "Panopticon_EN", 3, "TortureMeNot_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, "Insider_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "Sundowner_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "EvilDog_EN");
            med.SimpleAddEncounter(2, "Panopticon_EN", 2, "InHerImage_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, "BlackStar_EN");
            med.SimpleAddEncounter(3, "Panopticon_EN", 1, "Grandfather_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Panopticon.Med, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 1, "Panopticon_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(3, "InHerImage_EN", 1, "Panopticon_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Panopticon_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, "Panopticon_EN", "Panopticon_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Panopticon_EN", "Panopticon_EN", Enemies.Shivering);
            hard.AddRandomGroup(Enemies.Skinning, "Panopticon_EN", "Panopticon_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Panopticon_EN", "Panopticon_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Panopticon_EN", "Panopticon_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Panopticon_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Panopticon_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.SimpleAddGroup(1, Flower.Grey, 3, "Panopticon_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "Panopticon_EN", "Panopticon_EN", "WindSong_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "Panopticon_EN", "Panopticon_EN", "Grandfather_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, "Panopticon_EN", 1, "Firebird_EN");
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, "Panopticon_EN", 1, "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, "Panopticon_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.SimpleAddGroup(1, "MiniReaper_EN", 2, "InHisImage_EN", 1, "Panopticon_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "Panopticon_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Panopticon_EN", "Panopticon_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Panopticon_EN", "Panopticon_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.SimpleAddGroup(1, "Firebird_EN", 3, "Panopticon_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "Panopticon_EN", "Panopticon_EN", "LittleAngel_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Panopticon_EN", "Panopticon_EN", "Surrogate_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.SimpleAddGroup(1, "Stoplight_EN", 3, "Panopticon_EN");
            hard.SimpleAddGroup(1, "Stoplight_EN", 1, "Panopticon_EN", 2, "InHisImage_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Panopticon_EN", "Panopticon_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Panopticon_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, "Panopticon_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.SimpleAddGroup(1, "Complimentary_EN", 2, "Panopticon_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Panopticon_EN", "Grandfather_EN");
            med.AddRandomGroup("PersonalAngel_EN", "Panopticon_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.SimpleAddGroup(1, "Eyeless_EN", 3, "Panopticon_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(2, "Yang_EN", 2, "Panopticon_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Panopticon_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.Insider.Med);
            med.SimpleAddGroup(2, "Insider_EN", 2, "Panopticon_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Panopticon_EN", "Panopticon_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Dark.Med);
            med.SimpleAddGroup(1, "InTheDark_EN", 2, "Panopticon_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.SimpleAddGroup(1, "InTheDark_EN", 3, "Panopticon_EN");

            med = new AddTo(Garden.H.Sundowner.Med);
            med.SimpleAddGroup(3, "Sundowner_EN", 1, "Panopticon_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.SimpleAddGroup(1, "Lunoscope_EN", 2, "Panopticon_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.SimpleAddGroup(1, "Lunoscope_EN", 3, "Panopticon_EN");
            hard.AddRandomGroup("Lunoscope_EN", "Panopticon_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Nosestone.Red.Hard);
            hard.AddRandomGroup(Noses.Red, Noses.Gray, "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Nosestone.Blue.Med);
            hard.AddRandomGroup(Noses.Blue, Noses.Red, "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Nosestone.Yellow.Med);
            hard.AddRandomGroup(Noses.Yellow, Noses.Red, "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Nosestone.Purple.Med);
            hard.AddRandomGroup(Noses.Purple, Noses.Red, "Panopticon_EN", "Panopticon_EN");

            hard = new AddTo(Garden.H.Nosestone.Grey.Med);
            hard.AddRandomGroup(Noses.Gray, Noses.Red, "Panopticon_EN", "Panopticon_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Romantic_EN");
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Surrogate_EN");
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Attrition_EN");
            med.SimpleAddGroup(2, "Panopticon_EN", 2, "Git_EN");
            med.SimpleAddGroup(3, "Panopticon_EN", 1, "Bonsai_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 2, "Panopticon_EN");

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(3, "Git_EN", 1, "Panopticon_EN", 1, "Surrogate_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(3, "Bonsai_EN", 1, "Panopticon_EN");
            med.SimpleAddGroup(2, "Bonsai_EN", 2, "Panopticon_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "Panopticon_EN", "Panopticon_EN", "EggKeeper_EN");
        }
    }
}
