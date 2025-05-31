using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class OdeToHumanityEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_OdeToHumanityEncounter_Sign", ResourceLoader.LoadSprite("VaseWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Ode.Med, "Salt_OdeToHumanityEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/VaseSong";
            med.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            med.AddRandomEncounter("OdeToHumanity_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "OdeToHumanity_EN", 3, Enemies.Shivering);
            med.AddRandomEncounter("OdeToHumanity_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("OdeToHumanity_EN", Bots.Grey, Enemies.Minister);
            med.AddRandomEncounter("OdeToHumanity_EN", "WindSong_EN", Enemies.Minister);
            med.AddRandomEncounter("OdeToHumanity_EN", "ChoirBoy_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("OdeToHumanity_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", Spoggle.Grey, Enemies.Minister);
            med.AddRandomEncounter("OdeToHumanity_EN", "Shua_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "Hunter_EN", "Shua_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "Grandfather_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "YNL_EN", Enemies.Minister);
            med.AddRandomEncounter("OdeToHumanity_EN", "YNL_EN", "Grandfather_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "Firebird_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "Firebird_EN", "Indicator_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", Enemies.Minister, "ChoirBoy_EN", "Children6_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "Grandfather_EN", "EyePalm_EN", "EyePalm_EN");
            med.SimpleAddEncounter(1, "OdeToHumanity_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "InHisImage_EN", "InHisImage_EN", "Damocles_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", Enemies.Minister, "LittleAngel_EN");
            med.AddRandomEncounter("OdeToHumanity_EN", "Shua_EN", "LittleAngel_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Ode.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "OdeToHumanity_EN", "EyePalm_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "OdeToHumanity_EN", "InHisImage_EN", "InHisImage_EN");
            hard.AddRandomGroup("Satyr_EN", "OdeToHumanity_EN", Enemies.Skinning);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, "ChoirBoy_EN", "OdeToHumanity_EN");
            hard.AddRandomGroup("ClockTower_EN", "InHerImage_EN", "InHerImage_EN", "OdeToHumanity_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "OdeToHumanity_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "OdeToHumanity_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomGroup("Stoplight_EN", "OdeToHumanity_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "OdeToHumanity_EN", Bots.Grey);
            hard.AddRandomGroup("Stoplight_EN", "OdeToHumanity_EN", Enemies.Minister);

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "OdeToHumanity_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "OdeToHumanity_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "OdeToHumanity_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomGroup(Enemies.Skinning, "OdeToHumanity_EN", Enemies.Shivering, Enemies.Shivering);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "OdeToHumanity_EN");
            hard.AddRandomGroup(Enemies.Skinning, "OdeToHumanity_EN", "Stoplight_EN");
        }
    }
}
