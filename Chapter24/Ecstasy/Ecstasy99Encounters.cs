using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Ecstasy99Encounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_Ecstasy99Encounter_Sign", ResourceLoader.LoadSprite("GrayEcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Ecstasy99.Med, "Salt_Ecstasy99Encounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = "event:/Hawthorne/Sound3/YelEcRoar";

            med.SimpleAddEncounter(4, Ecstasy.Gray);
            if (SaltsReseasoned.rando < 5) med.SimpleAddEncounter(3, Ecstasy.Gray, 2, "TortureMeNot_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Ecstasy99.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.SimpleAddGroup(2, "InHisImage_EN", 1, Ecstasy.Gray);

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.SimpleAddGroup(2, "InHerImage_EN", 1, Ecstasy.Gray);

            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.SimpleAddGroup(1, "Satyr_EN", 2, Ecstasy.Gray);

            med = new AddTo(Garden.H.Skinning.Med);
            med.SimpleAddGroup(1, Enemies.Skinning, 2, Ecstasy.Gray);

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "InHisImage_EN", "InHerImage_EN", Ecstasy.Gray);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(2, Enemies.Skinning, 1, Ecstasy.Gray);

            easy = new AddTo(Garden.H.Minister.Easy);
            easy.SimpleAddGroup(2, Enemies.Minister, 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", Ecstasy.Gray);
            med.SimpleAddGroup(1, Enemies.Minister, 2, "Bonsai_EN", 1, Ecstasy.Gray);

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Ecstasy.Gray, Ecstasy.Gray, Ecstasy.Gray);

            med = new AddTo(Garden.H.Foundling.Med);
            med.SimpleAddGroup(1, Enemies.Foundling, 2, Ecstasy.Gray);

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.SimpleAddGroup(2, Enemies.Foundling, 2, Ecstasy.Gray);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Ecstasy.Gray, Ecstasy.Gray, Enemies.Foundling);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, Ecstasy.Gray);

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "PawnA_EN", "PawnA_EN", Ecstasy.Gray);

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", Ecstasy.Gray, "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, Ecstasy.Gray);

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 3, Ecstasy.Gray);

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", Ecstasy.Gray, Enemies.Shivering);

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Attrition_EN", "Attrition_EN", Ecstasy.Gray);

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", Ecstasy.Gray);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", Ecstasy.Gray, "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", Ecstasy.Gray, Ecstasy.Gray, "LittleAngel_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "Attrition_EN", "Attrition_EN", Ecstasy.Gray);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", Ecstasy.Gray, Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Ecstasy.Gray, "BlackStar_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Ecstasy.Gray, "Bonsai_EN", "Bonsai_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", Ecstasy.Gray, Ecstasy.Gray, "Surrogate_EN");

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(3, "EvilDog_EN", 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", Ecstasy.Gray, "Beakart_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", Ecstasy.Gray, "InHisImage_EN", "InHisImage_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", Ecstasy.Gray, "EyePalm_EN", "EyePalm_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", Ecstasy.Gray, Ecstasy.Gray, "GlassFigurine_EN");

            med = new AddTo(Garden.H.Pawn.Med);
            med.AddRandomGroup("PawnA_EN", "PawnA_EN", "PawnA_EN", Ecstasy.Gray);

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", Ecstasy.Gray);

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", Ecstasy.Gray, "Beakart_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", Ecstasy.Gray, Ecstasy.Gray);

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", Ecstasy.Gray, Ecstasy.Gray);

            med = new AddTo(Garden.H.Dark.Med);
            med.AddRandomGroup("InTheDark_EN", Ecstasy.Gray, "Romantic_EN", "Romantic_EN", "Romantic_EN");

            hard = new AddTo(Garden.H.Dark.Hard);
            hard.AddRandomGroup("InTheDark_EN", "InTheDark_EN", Ecstasy.Gray, Ecstasy.Gray);

            med = new AddTo(Garden.H.Sundowner.Med);
            med.SimpleAddGroup(3, "Sundowner_EN", 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Lunoscope_EN", Ecstasy.Gray, "WindSong_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Lunoscope_EN", Ecstasy.Gray, "Bonsai_EN", "Bonsai_EN");

            med = new AddTo(Garden.H.Panopticon.Med);
            med.SimpleAddGroup(2, "Panopticon_EN", 2, Ecstasy.Gray);

            med = new AddTo(Garden.H.Git.Med);
            med.SimpleAddGroup(3, "Git_EN", 1, Ecstasy.Gray);

            easy = new AddTo(Garden.H.Attrition.Easy);
            easy.SimpleAddGroup(2, "Attrition_EN", 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(3, "Attrition_EN", 1, Ecstasy.Gray);

            easy = new AddTo(Garden.H.Bonsai.Easy);
            easy.SimpleAddGroup(2, "Bonsai_EN", 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(3, "Bonsai_EN", 1, Ecstasy.Gray);

            med = new AddTo(Garden.H.EggKeeper.Med);
            med.AddRandomGroup("ChoirBoy_EN", Ecstasy.Gray, "EggKeeper_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "InHisImage_EN", "InHerImage_EN", Ecstasy.Gray);

            med = new AddTo(Garden.H.Polyp.Med);
            med.AddRandomGroup(Enemies.Polyp, Ecstasy.Gray, "InHerImage_EN", "InHerImage_EN");
        }
    }
}
