using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class BlackStarEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_BlackStarEncounter_Sign", ResourceLoader.LoadSprite("BlackstarWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.BlackStar.Easy, "Salt_BlackStarEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/BlackStarTheme";
            easy.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            easy.SimpleAddEncounter(1, "BlackStar_EN", 4, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "BlackStar_EN", 2, Enemies.Shivering);
            easy.AddRandomEncounter("BlackStar_EN", "BlackStar_EN");
            easy.SimpleAddEncounter(1, "BlackStar_EN", 3, "Damocles_EN");
            easy.AddRandomEncounter("BlackStar_EN", Enemies.Camera, Enemies.Camera);
            easy.SimpleAddEncounter(1, "BlackStar_EN", 2, "EyePalm_EN");
            easy.AddRandomEncounter("BlackStar_EN", "EyePalm_EN");
            easy.AddRandomEncounter("BlackStar_EN", "BlackStar_EN", "Merced_EN");
            easy.SimpleAddEncounter(2, "BlackStar_EN", 1, "GlassFigurine_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.BlackStar.Easy, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");

            AddTo easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, "BlackStar_EN");

            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, Flower.Red, "BlackStar_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, "InHerImage_EN", "InHerImage_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "InHisImage_EN", "InHerImage_EN", "BlackStar_EN");

            AddTo hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Flower.Red, "BlackStar_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "InHerimage_EN", "InHerImage_EN", "BlackStar_EN");
            med.AddRandomGroup("Satyr_EN", "InHerImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomGroup("Satyr_EN", Enemies.Minister, "BlackStar_EN");

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", Enemies.Skinning, "BlackStar_EN");
            hard.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 3, "BlackStar_EN");
            hard.AddRandomGroup("ClockTower_EN", Enemies.Minister, Enemies.Minister, "BlackStar_EN");

            easy = new AddTo(Garden.H.WindSong.Easy);
            easy.AddRandomGroup("WindSong_EN", "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "BlackStar_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.SimpleAddGroup(2, "EyePalm_EN", 1, "BlackStar_EN");
            easy.SimpleAddGroup(3, "EyePalm_EN", 1, "BlackStar_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "BlackStar_EN");
            med.AddRandomGroup("EyePalm_EN", "InHerImage_EN", "InHerImage_EN", "BlackStar_EN");
            med.AddRandomGroup("EyePalm_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "BlackStar_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Enemies.Tank, "BlackStar_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Merced.Hard);
            hard.AddRandomGroup("Merced_EN", "BlackStar_EN", "Damocles_EN", "Damocles_EN", "Damocles_EN");

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.SimpleAddGroup(1, "Shua_EN", 2, "InHisImage_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(1, "Shua_EN", 2, "InHerImage_EN", 1, "BlackStar_EN");

            easy = new AddTo(Garden.H.GlassFigurine.Easy);
            easy.AddRandomGroup("GlassFigurine_EN", "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "InHisImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.AddRandomGroup("Hunter_EN", "EyePalm_EN", "EyePalm_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "InHerImage_EN", "InHerImage_EN", "BlackStar_EN");
            med.AddRandomGroup("Firebird_EN", "EyePalm_EN", "EyePalm_EN", "BlackStar_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 4, "BlackStar_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.SimpleAddGroup(2, "InHerImage_EN", 1, "InHisImage_EN", 1, "BlackStar_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.SimpleAddGroup(2, "InHisImage_EN", 1, "BlackStar_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 1, "BlackStar_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "BlackStar_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "BlackStar_EN");
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, Enemies.Shivering, "BlackStar_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(2, Enemies.Skinning, 3, "BlackStar_EN");
            hard.SimpleAddGroup(2, Enemies.Skinning, 1, "BlackStar_EN", 1, Enemies.Shivering);

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "BlackStar_EN");
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHisImage_EN", "BlackStar_EN");
            med.SimpleAddGroup(1, Enemies.Minister, 2, "Damocles_EN", 1, "BlackStar_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "MiniReaper_EN", "MiniReaper_EN", "BlackStar_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "ChoirBoy_EN", "BlackStar_EN");
        }
    }
}
