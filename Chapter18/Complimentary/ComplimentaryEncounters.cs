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
            med.AddRandomEncounter("Complimentary_EN", Enemies.Minister);
            med.AddRandomEncounter("Complimentary_EN", Jumble.Grey, Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", Spoggle.Grey, Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("Complimentary_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Complimentary_EN", Flower.Grey, "LittleAngel_EN");
            med.AddRandomEncounter("Complimentary_EN", "WindSong_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "Grandfather_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Complimentary_EN", "EyePalm_EN", "MiniReaper_EN");
            med.AddRandomEncounter("Complimentary_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "Merced_EN", "Skyloft_EN");
            med.AddRandomEncounter("Complimentary_EN", "Shua_EN", Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", "GlassFigurine_EN", Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", "Hunter_EN", Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", "Firebird_EN");
            med.AddRandomEncounter("Complimentary_EN", "BlackStar_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "MiniReaper_EN", "BlackStar_EN");
            med.AddRandomEncounter("Complimentary_EN", "Indicator_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "YNL_EN", Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", Bots.Grey, "TortureMeNot_EN");
            med.AddRandomEncounter("Complimentary_EN", "OdeToHumanity_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("Complimentary_EN", "Complimentary_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Complimentary.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
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
        }
    }
}
