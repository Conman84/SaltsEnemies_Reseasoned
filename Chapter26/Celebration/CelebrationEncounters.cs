using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class CelebrationEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_CelebrationEncounter_Sign", ResourceLoader.LoadSprite("CelebrationWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Celebration.Med, "Salt_CelebrationEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CelebrationTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/PumkinDie";

            med.AddRandomEncounter("Celebration_EN", "PawnA_EN", "PawnA_EN", "Celebration_EN");
            med.SimpleAddEncounter(1, "Celebration_EN", 3, Enemies.Shivering);
            med.SimpleAddEncounter(1, "Celebration_EN", 2, "InHerImage_EN");
            med.AddRandomEncounter("Celebration_EN", "InHerImage_EN", "InHisImage_EN");
            med.SimpleAddEncounter(1, "Celebration_EN", 4, "NextOfKin_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 1, "ChoirBoy_EN");
            med.AddRandomEncounter("Celebration_EN", Spoggle.Gray, "NextOfKin_EN", "NextOfKin_EN");
            med.AddRandomEncounter("Celebration_EN", Jumble.Gray, "PawnA_EN", "PawnA_EN");
            med.AddRandomEncounter("Celebration_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("Celebration_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "WindSong_EN");
            med.AddRandomEncounter("Celebration_EN", "MiniReaper_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Grandfather_EN");
            med.AddRandomEncounter("Celebration_EN", "Shua_EN", "BlackStar_EN", "BlackStar_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Damocles_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "GlassFigurine_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Indicator_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 3, "TortureMeNot_EN");
            med.AddRandomEncounter("Celebration_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Yang_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Insider_EN");
            med.AddRandomEncounter("Celebration_EN", "Celebration_EN", "Sundowner_EN");
            med.SimpleAddEncounter(2, "Celebration_EN", 1, Ecstasy.Gray);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Celebration.Med, 8 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Celebration.Hard, "Salt_CelebrationEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/CelebrationTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/PumkinDie";

            hard.AddRandomEncounter("Celebration_EN", "InHerImage_EN", "InHerImage_EN", "Celebration_EN");
            hard.SimpleAddEncounter(3, "Celebration_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Celebration.Hard, 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Celebration_EN", Enemies.Shivering);

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Celebration_EN", "Celebration_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Celebration_EN", "NextOfKin_EN", "NextOfKin_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "Celebration_EN", "Celebration_EN");
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Celebration_EN");

            med = new AddTo(Garden.H.Foundling.Med);
            med.AddRandomGroup(Enemies.Foundling, "Celebration_EN", "Celebration_EN");

            hard = new AddTo(Garden.H.Foundling.Hard);
            hard.AddRandomGroup(Enemies.Foundling, Enemies.Foundling, "Celebration_EN");
            hard.SimpleAddGroup(1, Enemies.Foundling, 3, "Celebration_EN");
        }
    }
}
