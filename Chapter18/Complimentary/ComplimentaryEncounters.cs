using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ComplimentaryEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ComplimentaryEncounter_Sign", ResourceLoader.LoadSprite("ComplimentaryWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Complimentary.Med, "Salt_ComplimentaryEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ComplimentaryTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;

            med.AddRandomEncounter("Complimentary_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Complimentary_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Complimentary_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Complimentary_EN", Jumble.Grey, Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("Complimentary_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Complimentary_EN", "WindSong_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "Grandfather_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Complimentary_EN", "EyePalm_EN", "MiniReaper_EN");
            med.AddRandomEncounter("Complimentary_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "Merced_EN", "Skyloft_EN");
            med.AddRandomEncounter("Complimentary_EN", "Shua_EN", Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", "GlassFigurine_EN", "PawnA_EN");
            med.AddRandomEncounter("Complimentary_EN", "BlackStar_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "MiniReaper_EN", "BlackStar_EN");
            med.AddRandomEncounter("Complimentary_EN", "Indicator_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "YNL_EN", Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("Complimentary_EN", "Complimentary_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Complimentary.Med, 7, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Complimentary_EN", "WindSong_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Complimentary_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Complimentary_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Complimentary_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Complimentary_EN", Enemies.Shivering);


            AddTo main = new AddTo(Garden.H.Complimentary.Med);
            main.AddRandomGroup("Complimentary_EN", "LittleAngel_EN", "BlackStar_EN");

            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Complimentary_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "Complimentary_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Complimentary_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup("Complimentary_EN", Spoggle.Grey);

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Complimentary_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, "Complimentary_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Complimentary_EN", Jumble.Gray);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "Complimentary_EN", "Skyloft_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Complimentary_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Complimentary_EN", "Shua_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Complimentary_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Yang_EN", "Complimentary_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yang_EN", "Yin_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.CorpseChan.Med);
            med.AddRandomGroup("CorpseChan_EN", "Complimentary_EN");

            med = new AddTo(Garden.H.Lunoscope.Med);
            med.AddRandomGroup("Complimentary_EN", "Lunoscope_EN");

            hard = new AddTo(Garden.H.Lunoscope.Hard);
            hard.AddRandomGroup("Complimentary_EN", "Lunoscope_EN", "Skyloft_EN");
        }
    }
}
