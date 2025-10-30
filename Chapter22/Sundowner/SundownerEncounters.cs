using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SundownerEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_SundownerEncounter_Sign", ResourceLoader.LoadSprite("SundownerWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Sundowner.Med, "Salt_SundownerEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SundownerSong";
            med.RoarEvent = "event:/Hawthorne/Sosn2/LARoar";

            med.SimpleAddEncounter(5, "Sundowner_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Children6_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "BlackStar_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "GlassFigurine_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Damocles_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Merced_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Romantic_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Surrogate_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "EggKeeper_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Skyloft_EN");
            med.SimpleAddEncounter(4, "Sundowner_EN", 1, "Hauntling_EN");
            med.SimpleAddEncounter(3, "Sundowner_EN", 1, "MiniReaper_EN");
            med.SimpleAddEncounter(3, "Sundowner_EN", 1, "Grandfather_EN");
            med.SimpleAddEncounter(3, "Sundowner_EN", 1, "Indicator_EN");
            med.SimpleAddEncounter(3, "Sundowner_EN", 1, "WindSong_EN");
            med.SimpleAddEncounter(3, "Sundowner_EN", 1, Jumble.Gray);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Sundowner.Med, April.Me && !April.Birthday ? 10 : April.LessMod * 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(2, "InHisImage_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(2, "InHerImage_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Sundowner_EN", "Sundowner_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.SimpleAddGroup(2, "Sundowner_EN", 1, Enemies.Skinning);

            AddTo hard = new AddTo(Garden.H.Minister.Hard);
            hard.SimpleAddGroup(1, Enemies.Minister, 3, "Sundowner_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(1, Enemies.Skinning, 3, "Sundowner_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.SimpleAddGroup(1, "Shua_EN", 2, "Sundowner_EN", 1, "EyePalm_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.SimpleAddGroup(1, "Starless_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.SimpleAddGroup(1, Spoggle.Grey, 3, "Sundowner_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Sundowner_EN", "Sundowner_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "Sundowner_EN", "Sundowner_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.SimpleAddGroup(1, "YNL_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.SimpleAddGroup(1, "GreyBot_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.SimpleAddGroup(1, "Firebird_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.SimpleAddGroup(1, "Hunter_EN", 2, "Sundowner_EN");
            
            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Sundowner_EN", "Git_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.SimpleAddGroup(1, "PersonalAngel_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.SimpleAddGroup(1, "Yang_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.SimpleAddGroup(1, "Satyr_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.SimpleAddGroup(1, "Stoplight_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.SimpleAddGroup(1, "CorpseChan_EN", 2, "Sundowner_EN");
            
            med = new AddTo(Garden.H.Attrition.Med);
            med.SimpleAddGroup(2, "Attrition_EN", 2, "Sundowner_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(2, "Bonsai_EN", 2, "Sundowner_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.SimpleAddGroup(1, Flower.Grey, 3, "Sundowner_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.SimpleAddGroup(1, "Eyeless_EN", 2, "Sundowner_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.SimpleAddGroup(2, "Yang_EN", 1, "Sundowner_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.SimpleAddGroup(1, "Yin_EN", 2, "Sundowner_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.SimpleAddGroup(1, "Stoplight_EN", 2, "Sundowner_EN", 1, "EggKeeper_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, "Sundowner_EN", 1, Noses.Blue);
            hard.SimpleAddGroup(1, "Satyr_EN", 2, "Sundowner_EN", 1, Noses.Red);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 2, "Sundowner_EN", 1, Noses.Grey);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 2, "Sundowner_EN");
            
            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, "Sundowner_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Sundowner_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.SimpleAddGroup(2, "Sundowner_EN", 1, "Beakart_EN");
        }
    }
}
