using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CorpseChanEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_CorpseChanEncounter_Sign", ResourceLoader.LoadSprite("CorpseChanWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.CorpseChan.Med, "Salt_CorpseChanEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CorpseChanSong";
            med.RoarEvent = "event:/Hawthorne/Sosn2/RotDie";

            med.SimpleAddEncounter(3, "CorpseChan_EN");
            med.AddRandomEncounter("CorpseChan_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("CorpseChan_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 3, Enemies.Shivering);
            med.AddRandomEncounter("CorpseChan_EN", "CorpseChan_EN", Enemies.Minister);
            med.AddRandomEncounter("CorpseChan_EN", "CorpseChan_EN", "LittleAngel_EN");
            med.AddRandomEncounter("CorpseChan_EN", "ChoirBoy_EN", "NextOfKin_EN");
            med.AddRandomEncounter("CorpseChan_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("CorpseChan_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("CorpseChan_EN", "WindSong_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("CorpseChan_EN", "CorpseChan_EN", "Grandfather_EN");
            med.AddRandomEncounter("CorpseChan_EN", "MiniReaper_EN", "NextOfKin_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "Merced_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("CorpseChan_EN", "Shua_EN", "EyePalm_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "Damocles_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "GlassFigurine_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "BlackStar_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "Indicator_EN");
            med.AddRandomEncounter("CorpseChan_EN", "YNL_EN", Enemies.Shivering);
            med.AddRandomEncounter("CorpseChan_EN", Bots.Grey, Enemies.Shivering);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 3, "TortureMeNot_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 2, "EvilDog_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "PawnA_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 4, "PawnA_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 4, "Hauntling_EN");
            med.AddRandomEncounter("CorpseChan_EN", "Insider_EN", "Insider_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 2, "Git_EN");
            med.SimpleAddEncounter(1, "CorpseChan_EN", 2, "Attrition_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "Beakart_EN");
            med.AddRandomEncounter("CorpseChan_EN", "Yang_EN", "PawnA_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, "EggKeeper_EN");
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Noses.Red);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Noses.Blue);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Noses.Yellow);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Noses.Purple);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Noses.Grey);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Jumble.Grey);
            med.SimpleAddEncounter(2, "CorpseChan_EN", 1, Spoggle.Grey);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.CorpseChan.Med, April.Me && !April.Birthday ? 10 : April.LessMod * 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "CorpseChan_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "CorpseChan_EN", "LittleAngel_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "CorpseChan_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "CorpseChan_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "CorpseChan_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "CorpseChan_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "CorpseChan_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "CorpseChan_EN", "Romantic_EN", "Romantic_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "CorpseChan_EN", "BlackStar_EN");

            AddTo hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "CorpseChan_EN", "Git_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "CorpseChan_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "CorpseChan_EN", "PawnA_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "CorpseChan_EN", "EvilDog_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "CorpseChan_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, "CorpseChan_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "CorpseChan_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(2, "GlassedSun_EN", 1, "CorpseChan_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, "CorpseChan_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "CorpseChan_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "CorpseChan_EN", "WindSong_EN");
        }
    }
}
