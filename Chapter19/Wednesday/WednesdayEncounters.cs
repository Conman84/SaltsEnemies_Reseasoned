using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WednesdayEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WednesdayEncounter_Sign", ResourceLoader.LoadSprite("PhoneWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Wednesday.Med, "Salt_WednesdayEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PhoneSong";
            med.RoarEvent = "event:/Hawthorne/Noise/TrainRoar";

            med.SimpleAddEncounter(1, "Wednesday_EN", 3, "MusicMan_EN");
            med.AddRandomEncounter("Wednesday_EN", "Scrungie_EN", "Scrungie_EN", Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("Wednesday_EN", Enemies.Shooter, Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", Bots.Yellow, Bots.Red);
            med.AddRandomEncounter("Wednesday_EN", "Something_EN", Jumble.Blue);
            med.AddRandomEncounter("Wednesday_EN", "Rabies_EN", "Rabies_EN", "LostSheep_EN");
            med.SimpleAddEncounter(1, "Wednesday_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            med.AddRandomEncounter("Wednesday_EN", "Delusion_EN", "Delusion_EN", Enemies.Solvent);
            med.AddRandomEncounter("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", "Delusion_EN", "Delusion_EN", "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", Spoggle.Red, Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", Jumble.Purple, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", "Something_EN", Flower.Yellow);
            med.AddRandomEncounter("Wednesday_EN", "TheCrow_EN", Bots.Red);
            med.AddRandomEncounter("Wednesday_EN", "WindSong_EN", "MusicMan_EN", "MusicMan_EN");
            med.SimpleAddEncounter(1, "Wednesday_EN", 3, "Spectre_EN");
            med.AddRandomEncounter("Wednesday_EN", Enemies.Camera, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Camera);
            med.AddRandomEncounter("Wednesday_EN", "Scrungie_EN", Enemies.Shooter);
            med.AddRandomEncounter("Wednesday_EN", "Scrungie_EN", Bots.Blue, "TortureMeNot_EN");
            med.AddRandomEncounter("Wednesday_EN", "Sigil_EN", "MusicMan_EN", "MusicMan_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Wednesday.Med, 8, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {

        }
    }
}
