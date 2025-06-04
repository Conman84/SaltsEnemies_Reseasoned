using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;

namespace SaltsEnemies_Reseasoned
{
    public static class YourNewLifeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_YourNewLifeEncounter_Sign", ResourceLoader.LoadSprite("LobotomyPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.YNL.Med, "Salt_YourNewLifeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/LobotomyTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;

            med.AddRandomEncounter("YNL_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", "InHisImage-EN");
            med.SimpleAddEncounter(1, "YNL_EN", 4, "NextOfKin_EN");
            med.AddRandomEncounter("YNL_EN", "ChoirBoy_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "InHerImage_EN", "InHerImage_EN", "LittleAngel_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", Jumble.Grey);
            med.AddRandomEncounter("YNL_EN", Flower.Red, Flower.Blue, "LittleAngel_EN");
            med.AddRandomEncounter("YNL_EN", "Grandfather_EN", Flower.Red);
            med.AddRandomEncounter("YNL_EN", "Grandfather_EN", Flower.Blue);
            med.AddRandomEncounter("YNL_EN", "WindSong_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", Flower.Grey, "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "MiniReaper_EN", Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "WindSong_EN");
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", Flower.Red, "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", Flower.Blue, "GlassFigurine_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "BlackStar_EN", "BlackStar_EN");
            med.AddRandomEncounter("YNL_EN", "Hunter_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("YNL_EN", "Firebird_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("YNL_EN", "Shua_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("YNL_EN", "Indicator_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "ChoirBoy_EN", "Grandfather_EN");
            med.AddRandomEncounter("YNL_EN", "InHisImage_EN", "InHisImage_EN", Enemies.Minister);
            med.AddRandomEncounter("YNL_EN", "Grandfather_EN", Enemies.Minister);
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "WindSong_EN");
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "LittleAngel_EN");
            med.AddRandomEncounter("YNL_EN", Enemies.Minister, "ChoirBoy_EN");
            med.SimpleAddEncounter(1, "YNL_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("YNL_EN", "EyePalm_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("YNL_EN", "EyePalm_EN", "EyePalm_EN", "MiniReaper_EN");
            med.AddRandomEncounter("YNL_EN", "EyePalm_EN", "EyePalm_EN", "Hunter_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.YNL.Med, 7, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, Enemies.Minister, "YNL_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "InHerImage_EN", "InHerImage_EN", "YNL_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "YNL_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("Satyr_EN", "YNL_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Satyr_EN", "YNL_EN", "Hunter_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "YNL_EN", Enemies.Skinning);
            hard.AddRandomGroup("Satyr_EN", "YNL_EN", Flower.Red, Flower.Blue);

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "YNL_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "YNL_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "Grandfather_EN", "YNL_EN");
            med.AddRandomGroup(Flower.Grey, "Shua_EN", "YNL_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, Enemies.Minister, "YNL_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Shivering, "YNL_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, "WindSong_EN", "YNL_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "YNL_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "YNL_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "YNL_EN", "BlackStar_EN");
            hard.AddRandomGroup(Enemies.Tank, "YNL_EN", "Damocles_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "YNL_EN", Enemies.Minister);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "YNL_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "YNL_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "YNL_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "YNL_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(2, "InHisImage_EN", 1, "YNL_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "YNL_EN", Enemies.Shivering);
            med.AddRandomGroup(Enemies.Skinning, "YNL_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "YNL_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, "YNL_EN");
            med.AddRandomGroup(Enemies.Minister, "YNL_EN", "Damocles_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "YNL_EN", "WindSong_EN");
        }
    }
}
