using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GreyBotEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_GreyBotEncounter_Sign", ResourceLoader.LoadSprite("GreyBotWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.GreyBot.Med, "Salt_GreyBotEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ApparatusSong";
            med.RoarEvent = "event:/Hawthorne/Roar/TankRoar";

            med.SimpleAddEncounter(1, Bots.Grey, 3, "InHisImage_EN");
            med.SimpleAddEncounter(1, Bots.Grey, 2, "InHisImage_EN", 1, "InHerImage_EN");
            med.SimpleAddEncounter(1, Bots.Grey, 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, Bots.Grey, 4, "NextOfKin_EN");
            med.SimpleAddEncounter(1, Bots.Grey, 2, Enemies.Shivering, 1, "ChoirBoy_EN");
            med.AddRandomEncounter(Bots.Grey, "WindSong_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter(Bots.Grey, "MiniReaper_EN", "InHisImage_EN", "InHisImage_EN");
            med.SimpleAddEncounter(1, Bots.Grey, 3, "EyePalm_EN");
            med.SimpleAddEncounter(1, Bots.Grey, 2, "EyePalm_EN", 1, "MiniReaper_EN");
            med.AddRandomEncounter(Bots.Grey, "EyePalm_EN", "EyePalm_EN", Enemies.Minister);
            med.AddRandomEncounter(Bots.Grey, "Shua_EN", Enemies.Minister);
            med.AddRandomEncounter(Bots.Grey, "Shua_EN", "WindSong_EN");
            med.AddRandomEncounter(Bots.Grey, "Damocles_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter(Bots.Grey, "Shua_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter(Bots.Grey, "Hunter_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter(Bots.Grey, "Grandfather_EN", "Hunter_EN");
            med.AddRandomEncounter(Bots.Grey, "Indicator_EN", "Shua_EN");
            med.AddRandomEncounter(Bots.Grey, "Indicator_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomEncounter(Bots.Grey, "YNL_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter(Bots.Grey, "YNL_EN", Enemies.Minister);
            med.AddRandomEncounter(Bots.Grey, "YNL_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter(Bots.Grey, "YNL_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter(Bots.Grey, "Shua_EN", "InHerImage_EN", "InHerImage_EN", "Children6_EN");
            med.AddRandomEncounter(Bots.Grey, Enemies.Minister, "LittleAngel_EN");
            med.AddRandomEncounter(Bots.Grey, "EyePalm_EN", "EyePalm_EN", "BlackStar_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.GreyBot.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", Bots.Grey, "WindSong_EN");
            med.AddRandomGroup("Satyr_EN", Bots.Grey, "MiniReaper_EN");
            med.AddRandomGroup("Satyr_EN", Bots.Grey, "Indicator_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Bots.Grey, Enemies.Skinning);
            hard.AddRandomGroup("Satyr_EN", Bots.Grey, Enemies.Minister);
            hard.AddRandomGroup("Satyr_EN", Bots.Grey, "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Satyr_EN", Bots.Grey, "Stoplight_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Bots.Grey, Enemies.Minister, Enemies.Minister);
            hard.AddRandomGroup("ClockTower_EN", Bots.Grey, "Hunter_EN", "Firebird_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Bots.Grey, "Children6_EN");
            hard.AddRandomGroup(Enemies.Tank, Bots.Grey, "Damocles_EN");
            hard.AddRandomGroup(Enemies.Tank, Bots.Grey, "GlassFigurine_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", Bots.Grey);
            med.AddRandomGroup("YNL_EN", "Shua_EN", Bots.Grey);

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", Bots.Grey, "BlackStar_EN");
            med.AddRandomGroup("Stoplight_EN", Bots.Grey, Enemies.Minister);

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", Bots.Grey, "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", Bots.Grey, "Hunter_EN", "Damocles_EN");
            hard.AddRandomGroup("Stoplight_EN", Bots.Grey, "ChoirBoy_EN", "Children6_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, Bots.Grey);
            med.AddRandomGroup(Enemies.Minister, Bots.Grey, "WindSong_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, Bots.Grey, "GlassFigurine_EN");
            hard.AddRandomGroup(Enemies.Minister, Bots.Grey, "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Bots.Grey, "BlackStar_EN");
            med.AddRandomGroup(Enemies.Skinning, Bots.Grey, Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, Bots.Grey, "Grandfather_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, Bots.Grey);
            hard.AddRandomGroup(Enemies.Skinning, Bots.Grey, "Stoplight_EN");
            hard.AddRandomGroup(Enemies.Skinning, Bots.Grey, "Satyr_EN");
        }
    }
}
