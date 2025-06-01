using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ComplimentaryEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ComplimentaryEncounter_Sign", ResourceLoader.LoadSprite("ComplimentaryWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Complimentary.Med, "Salt_ComplimentaryEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ComplimentaryTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound;

            med.AddRandomEncounter("Complimentary_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomEncounter("Complimentary_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomEncounter("Complimentary_EN", "ChoirBoy_EN");
            med.AddRandomEncounter("Complimentary_EN", Enemies.Minister);
            med.AddRandomEncounter("Complimentary_EN", Jumble.Grey, Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", Spoggle.Grey, Enemies.Shivering);
            med.AddRandomEncounter("Complimentary_EN", Enemies.Camera, Enemies.Camera);
            med.AddRandomEncounter("Complimentary_EN", Flower.Red, Flower.Blue);
            med.AddRandomEncounter("Complimentary_EN", Flower.Grey, "LittleAngel_EN");
            med.AddRandomEncounter("Complimentary_EN", "WindSong_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "Grandfather_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Complimentary_EN", "EyePalm_EN", "MiniReaper_EN");
            med.AddRandomEncounter("Complimentary_EN", "EyePalm_EN", "EyePalm_EN");
            med.AddRandomEncounter("Complimentary_EN", "Merced_EN", "Skyloft_EN");
            med.AddRandomEncounter("Complimentary_EN", "Shua_EN", Enemies.Shivering);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Complimentary.Med, 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
    }
}
