using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class StalwartTortoiseEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_TortoiseEncounter_Sign", ResourceLoader.LoadSprite("TortoiseWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.Tortoise.Hard, "Salt_TortoiseEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/TortoiseSong";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Flarb_Hard_EnemyBundle")._roarReference.roarEvent;

            hard.AddRandomEncounter("StalwartTortoise_EN", "MusicMan_EN", "MusicMan_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "Something_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "TheCrow_EN");
            if (SaltsReseasoned.trolling > 50) hard.AddRandomEncounter("StalwartTortoise_EN", Jumble.Purple);
            if (SaltsReseasoned.trolling < 50) hard.AddRandomEncounter("StalwartTortoise_EN", Spoggle.Purple);
            if (SaltsReseasoned.silly > 50) hard.AddRandomEncounter("StalwartTortoise_EN", Flower.Yellow);
            if (SaltsReseasoned.silly < 50) hard.AddRandomEncounter("StalwartTortoise_EN", Flower.Purple);
            hard.AddRandomEncounter("StalwartTortoise_EN", "WindSong_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", Enemies.Solvent);
            hard.AddRandomEncounter("StalwartTortoise_EN", "Sigil_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "TheCrow_EN", "SilverSuckle_EN", "SilverSuckle_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "MusicMan_EN", "SingingStone_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "MusicMan_EN", "LostSheep_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "Enigma_EN", "LostSheep_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "Enigma_EN", "Sigil_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "Scrungie_EN", "LostSheep_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", "Scrungie_EN", Enemies.Suckle, Enemies.Suckle);
            hard.AddRandomEncounter("StalwartTortoise_EN", "Scrungie_EN", "Sigil_EN");
            hard.AddRandomEncounter("StalwartTortoise_EN", Enemies.Solvent, "WindSong_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Tortoise.Hard, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
