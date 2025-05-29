using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class IndicatorEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Med();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_IndicatorEncounter_Sign", ResourceLoader.LoadSprite("IndicatorWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Indicator.Easy, "Salt_IndicatorEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/IndicatorSong";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;

            easy.AddRandomEncounter("Indicator_EN", "Grandfather_EN");
            easy.AddRandomEncounter("Indicator_EN", "GlassFigurine_EN");
            easy.AddRandomEncounter("Indicator_EN", "BlackStar_EN", "BlackStar_EN");
            easy.AddRandomEncounter("Indicator_EN", "EyePalm_EN", "EyePalm_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 4, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering);
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "Skyloft_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "Damocles_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, "EyePalm_EN", 1, "BlackStar_EN");
            easy.AddRandomEncounter("Indicator_EN", Enemies.Camera, Enemies.Camera);
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "Damocles_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "BlackStar_EN");
            easy.SimpleAddEncounter(1, "Indicator_EN", 2, Enemies.Shivering, 1, "GlassFigurine_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Indicator.Easy, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_IndicatorEncounter_Sign", ResourceLoader.LoadSprite("IndicatorWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Indicator.Med, "Salt_IndicatorEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/IndicatorSong";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;

            med.SimpleAddEncounter(1, "Indicator_EN", 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, "Indicator_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Indicator_EN", Enemies.Shivering, Enemies.Shivering, Jumble.Grey);
            med.SimpleAddEncounter(2, "Indicator_EN", 2, Enemies.Camera);
            med.AddRandomEncounter("Indicator_EN", "EyePalm_EN", "EyePalm_EN", Flower.Red);
            med.AddRandomEncounter("Indicator_EN", "EyePalm_EN", "EyePalm_EN", Flower.Blue);
            med.AddRandomEncounter("Indicator_EN", "InHerImage_EN", "InHerImage_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Indicator_EN", "InHerImage_EN", "InHerImage_EN", "EyePalm_EN");
            med.AddRandomEncounter("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "EyePalm_EN");
            med.AddRandomEncounter("Indicator_EN", "InHerImage_EN", "InHerImage_EN", "Damocles_EN");
            med.AddRandomEncounter("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "Damocles_EN");
            med.AddRandomEncounter("Indicator_EN", "InHerImage_EN", "InHerImage_EN", "BlackStar_EN");
            med.AddRandomEncounter("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomEncounter("Indicator_EN", "InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "GlassFigurine_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Indicator.Med, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "Shua_EN", Enemies.Camera, "Indicator_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHerImage_EN", "Indicator_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Indicator_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Satyr.Hard);
            med.AddRandomGroup("Satyr_EN", Enemies.Skinning, "Indicator_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Flower.Blue, Flower.Red, "Indicator_EN");
            med.AddRandomGroup(Flower.Blue, "InHisImage_EN", "InHisImage_EN", "Indicator_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Flower.Red, Flower.Blue, "Indicator_EN");
            med.AddRandomGroup(Flower.Red, "InHerImage_EN", "InHerImage_EN", "Indicator_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "InHisImage_EN", "InHerImage_EN", "Indicator_EN");

            AddTo hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, "Indicator_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, "ChoirBoy_EN", "Indicator_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "InHisImage_EN", "InHisImage_EN", "Indicator_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "Indicator_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(4, "EyePalm_EN", 1, "Indicator_EN");
            med.AddRandomGroup("EyePalm_EN", "InHerImage_EN", "InHerImage_EN", "Indicator_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Indicator_EN", "Indicator_EN");

            AddTo easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "Indicator_EN", "NextOfKin_EN", "NextOfKin_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Indicator_EN", "InHerImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Indicator_EN", "MiniReaper_EN");
            med.AddRandomGroup("Hunter_EN", "Indicator_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Indicator_EN", "WindSong_EN", "BlackStar_EN");


        }
    }
}
