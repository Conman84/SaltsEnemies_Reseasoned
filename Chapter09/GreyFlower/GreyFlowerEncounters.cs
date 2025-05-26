using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GreyFlowerEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_GreyFlowerEncounter_Sign", ResourceLoader.LoadSprite("GreyFlowerWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Flower.Grey.Med, "Salt_GreyFlowerEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/FlowerSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent;

            med.AddRandomEncounter(Flower.Grey, "InHerImage_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter(Flower.Grey, "InHerImage_EN", "InHerImage_EN", "InHisImage_EN");
            med.AddRandomEncounter(Flower.Grey, "InHerImage_EN", "InHerImage_EN", "ChoirBoy_EN");
            med.AddRandomEncounter(Flower.Grey, "InHerImage_EN", "InHerImage_EN", "LittleAngel_EN");
            med.AddRandomEncounter(Flower.Grey, "InHerImage_EN", "InHerImage_EN", "Grandfather_EN");
            med.AddRandomEncounter(Flower.Grey, Flower.Red, Flower.Blue);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Flower.Grey.Med, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.Flower.Grey.Hard, "Salt_GreyFlowerEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/FlowerSong";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent;

            hard.AddRandomEncounter(Flower.Grey, Flower.Red, Flower.Blue, Flower.Yellow);
            hard.AddRandomEncounter(Flower.Grey, Flower.Red, Flower.Blue, Flower.Purple);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Flower.Grey.Hard, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, Flower.Grey);

            AddTo hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, Flower.Grey);

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "ChoirBoy_EN", Flower.Grey);

            hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "InHerImage_EN", "InHerImage_EN", Flower.Grey);
            hard.AddRandomGroup("Satyr_EN", Enemies.Skinning, Flower.Grey);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", Flower.Grey, "InHerImage_EN", "InHerImage_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, Flower.Grey);
        }
    }
}
