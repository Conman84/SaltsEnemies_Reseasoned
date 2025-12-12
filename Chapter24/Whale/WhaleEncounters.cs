using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WhaleEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WhaleEncounter_Sign", ResourceLoader.LoadSprite("WhalePortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Whale.Med, "Salt_WhaleEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ActuallyJustPepperSteak";
            med.RoarEvent = "event:/Hawthorne/Surround/DeepRoar";

            if (SaltsReseasoned.silly < 40 || SaltsReseasoned.silly > 90) med.SimpleAddEncounter(4, "TheWhale_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 2, "MusicMan_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 2, "Scrungie_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, Jumble.Blue, 1, Jumble.Yellow);
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, Spoggle.Red, 1, Spoggle.Blue);
            med.SimpleAddEncounter(2, "TheWhale_EN", 2, "Enigma_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 2, "Rabies_EN");
            med.AddRandomEncounter("TheWhale_EN", "TheWhale_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("TheWhale_EN", "TheWhale_EN", Bots.Blue, Bots.Purple);
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, Enemies.Shooter);
            med.SimpleAddEncounter(2, "TheWhale_EN", 2, "Delusion_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, Enemies.Solvent, 1, Jumble.Red);
            med.AddRandomEncounter("TheWhale_EN", "TheWhale_EN", Flower.Purple, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("TheWhale_EN", "TheWhale_EN", Flower.Yellow, Enemies.Suckle, Enemies.Suckle);
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, "WindSong_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, "Nameless_EN", 1, "Solitaire_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 2, "Foxtrot_EN");
            med.SimpleAddEncounter(2, "TheWhale_EN", 1, "Nume_EN", 1, "Wednesday_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Whale.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Whale.Med);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Jumble.Purple, 1, Jumble.Unstable);
            med.SimpleAddGroup(2, "TheWhale_EN", 1, Spoggle.Purple, 1, Spoggle.Unstable);
            med.SimpleAddGroup(2, "TheWhale_EN", 2, "Moone_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 2, "Frostbite_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 2, "BackupDancer_EN");
            med.SimpleAddGroup(1, "TheWhale_EN", 3, "Gungrot_EN");
        }
    }
}
