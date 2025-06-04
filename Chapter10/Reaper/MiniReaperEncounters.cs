using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MiniReaperEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_MiniReaperEncounter_Sign", ResourceLoader.LoadSprite("ReaperWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.MiniReaper.Med, "Salt_MiniReaperEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ReaperTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyAbility("FlayTheFlesh_A").visuals.audioReference;

            med.AddRandomEncounter("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", "NextOfKin_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHerImage_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("MiniReaper_EN", Enemies.Shivering, Enemies.Shivering, Enemies.Shivering);
            med.AddRandomEncounter("MiniReaper_EN", "MiniReaper_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", Flower.Red);
            med.AddRandomEncounter("MiniReaper_EN", "InHisImage_EN", "InHisImage_EN", Flower.Blue);
            med.AddRandomEncounter("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", Spoggle.Grey);
            med.AddRandomEncounter("MiniReaper_EN", Flower.Red, Flower.Blue, "ChoirBoy_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHerImage_EN", "InHerImage_EN", "WindSong_EN");
            med.AddRandomEncounter("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "WindSong_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.MiniReaper.Med, 8 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "MiniReaper_EN");
            easy.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "MiniReaper_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "MiniReaper_EN");

            AddTo med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "MiniReaper_EN", "InHisImage_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHerImage_EN", "MiniReaper_EN");
            med.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "WindSong_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "InHisImage_EN", "MiniReaper_EN");
            med.AddRandomGroup("InHisImage_EN", "InHerImage_EN", "ChoirBoy_EN", "MiniReaper_EN");
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "Grandfather_EN", "MiniReaper_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "ChoirBoy_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "MiniReaper_EN");
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, Enemies.Shivering, "MiniReaper_EN");

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "MiniReaper_EN");
            hard.AddRandomGroup(Enemies.Skinning, "ChoirBoy_EN", "MiniReaper_EN");
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "WindSong_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Flower.Yellow, "MiniReaper_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, Flower.Purple, "MiniReaper_EN");

            med = new AddTo(Garden.H.Camera.Med);
            if (SaltsReseasoned.silly > 66) med.AddRandomGroup(Enemies.Camera, Enemies.Camera, Enemies.Camera, Enemies.Camera, "MiniReaper_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Enemies.Skinning, Enemies.Shivering, "MiniReaper_EN");
            hard.AddRandomGroup("ClockTower_EN", "ChoirBoy_EN", "ChoirBoy_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "MiniReaper_EN", Enemies.Shivering);
        }
    }
}
