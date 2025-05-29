using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class FirebirdEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_FirebirdEncounter_Sign", ResourceLoader.LoadSprite("FirebirdWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Firebird.Med, "Salt_FirebirdEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/FirebirdTheme";
            med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent;

            med.AddRandomEncounter("Firebird_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Firebird_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddEncounter(1, "Firebird_EN", 3, "EyePalm_EN");
            med.AddRandomEncounter("Firebird_EN", "Shua_EN", "LittleAngel_EN");
            med.AddRandomEncounter("Firebird_EN", "MiniReaper_EN", "MiniReaper_EN");
            med.SimpleAddEncounter(1, "Firebird_EN", 3, Enemies.Camera);
            med.AddRandomEncounter("Firebird_EN", "Hunter_EN", "Damocles_EN", "Damocles_EN");
            med.AddRandomEncounter("Firebird_EN", "WindSong_EN", "Hunter_EN");
            med.AddRandomEncounter("Firebird_EN", "Grandfather_EN", Flower.Blue);
            med.AddRandomEncounter("Firebird_EN", Flower.Grey, "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Firebird_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Firebird_EN", Spoggle.Grey, "ChoirBoy_EN");
            med.AddRandomEncounter("Firebird_EN", "ChoirBoy_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Firebird_EN", "WindSong_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Firebird_EN", "ChoirBoy_EN", "GlassFigurine_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Firebird.Med, 6, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
