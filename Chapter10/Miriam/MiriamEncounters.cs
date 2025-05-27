using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MiriamEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_MiriamEncounter_Sign", ResourceLoader.LoadSprite("MiriamWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Miriam.Hard, "Salt_MiriamEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/Redo/MiriamSong";
            hard.RoarEvent = LoadedAssetsHandler.GetCharacter("Bimini_CH").damageSound;

            hard.AddRandomEncounter("Miriam_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 4, "EyePalm_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 3, "EyePalm_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 2, "EyePalm_EN", 1, "MiniReaper_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 3, "EyePalm_EN", 1, "Skyloft_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 3, "InHerImage_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 2, "InHerImage_EN", 1, "MiniReaper_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 2, "EyePalm_EN", 1, "LittleAngel_EN");
            hard.AddRandomEncounter("Miriam_EN", Flower.Red, Flower.Blue, Flower.Yellow, Flower.Purple);
            hard.AddRandomEncounter("Miriam_EN", Flower.Red, Flower.Blue, "EyePalm_EN");
            hard.AddRandomEncounter("Miriam_EN", Flower.Grey, "LittleAngel_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 4, Enemies.Camera);
            hard.SimpleAddEncounter(1, "Miriam_EN", 2, Enemies.Camera, 2, "EyePalm_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 1, "WindSong_EN", 3, "EyePalm_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 1, "WindSong_EN", 2, "EyePalm_EN");
            hard.AddRandomEncounter("Miriam_EN", "ChoirBoy_EN", "ChoirBoy_EN");
            hard.AddRandomEncounter("Miriam_EN", "ChoirBoy_EN", "Skyloft_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 3, Enemies.Shivering);
            hard.SimpleAddEncounter(1, "Miriam_EN", 2, Enemies.Shivering, 1, "EyePalm_EN");
            hard.SimpleAddEncounter(1, "Miriam_EN", 1, Enemies.Skinning, 2, Enemies.Shivering);
            hard.AddRandomEncounter("Miriam_EN", Enemies.Skinning, Enemies.Shivering);
            hard.AddRandomEncounter("Miriam_EN", Enemies.Skinning, "MiniReaper_EN");
            hard.AddRandomEncounter("Miriam_EN", Enemies.Skinning, "MiniReaper_EN", "Skyloft_EN");
            hard.AddRandomEncounter("Miriam_EN", Enemies.Skinning, "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomEncounter("Miriam_EN", Enemies.Minister, Enemies.Minister);
            hard.AddRandomEncounter("Miriam_EN", Enemies.Minister, Enemies.Minister, "LittleAngel_EN");
            hard.AddRandomEncounter("Miriam_EN", Enemies.Minister, "MiniReaper_EN");
            hard.AddRandomEncounter("Miriam_EN", "Grandfather_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomEncounter("Miriam_EN", "Grandfather_EN", Flower.Grey);
            hard.AddRandomEncounter("Miriam_EN", "Grandfather_EN", "WindSong_EN", "Skyloft_EN");
            hard.AddRandomEncounter("Miriam_EN", "ClockTower_EN");
            hard.AddRandomEncounter("Miriam_EN", "ClockTower_EN", "EyePalm_EN", "EyePalm_EN");
            hard.AddRandomEncounter("Miriam_EN", "Merced_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Miriam.Hard, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
