using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AuthorEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_AuthorEncounter_Sign", ResourceLoader.LoadSprite("AuthorWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Author.Med, "Salt_AuthorEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/AuthorSong";
            med.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            med.SimpleAddEncounter(1, "Author_EN", 3, "MusicMan_EN");
            med.SimpleAddEncounter(1, "Author_EN", 2, "Solitaire_EN");
            med.AddRandomEncounter("Author_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            med.SimpleAddEncounter(1, "Author_EN", 3, "Enigma_EN");
            med.SimpleAddEncounter(1, "Author_EN", 2, Enemies.Shooter);
            med.AddRandomEncounter("Author_EN", "MusicMan_EN", "MusicMan_EN", Enemies.Shooter);
            med.AddRandomEncounter("Author_EN", "MusicMan_EN", "MusicMan_EN", "Solitaire_EN");
            med.AddRandomEncounter("Author_EN", "Delusion_EN", "Delusion_EN", Enemies.Shooter);
            med.AddRandomEncounter("Author_EN", "Delusion_EN", "Delusion_EN", "Solitaire_EN");
            med.SimpleAddEncounter(1, "Author_EN", 2, "Scrungie_EN");
            med.AddRandomEncounter("Author_EN", "Solitiare_EN", Enemies.Shooter, "Delusion_EN");
            med.AddRandomEncounter("Author_EN", "Solitiare_EN", Enemies.Shooter, "MusicMan_EN");
            med.AddRandomEncounter("Author_EN", "MusicMan_EN", "MusicMan_EN", "SingingStone_EN");
            med.AddRandomEncounter("Author_EN", "Delusion_EN", "Delusion_EN", "LostSheep_EN");
            med.AddRandomEncounter("Author_EN", "Solitaire_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Author_EN", Enemies.Shooter, "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Bots.Red);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Bots.Blue);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Bots.Yellow);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Bots.Purple);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Jumble.Blue);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Jumble.Purple);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Spoggle.Red);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Spoggle.Purple);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Flower.Yellow);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Flower.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Author.Med, 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.Author.Hard, "Salt_AuthorEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/AuthorSong";
            hard.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            hard.SimpleAddEncounter(4, "Author_EN");
            hard.SimpleAddEncounter(3, "Author_EN", 2, Enemies.Suckle);
            hard.SimpleAddEncounter(3, "Author_EN", 1, "Foxtrot_EN");
            hard.SimpleAddEncounter(3, "Author_EN", 1, "LostSheep_EN");
            hard.SimpleAddEncounter(3, "Author_EN", 1, Enemies.Solvent);
            hard.SimpleAddEncounter(3, "Author_EN", 1, "WindSong_EN");
            hard.SimpleAddEncounter(3, "Author_EN", 1, "Sigil_EN");
            hard.SimpleAddEncounter(3, "Author_EN", 1, "Wednesday_EN");
            hard.SimpleAddEncounter(3, "Author_EN", 1, "Nameless_EN");
            hard.SimpleAddEncounter(2, "Author_EN", 2, "Spectre_EN");
            hard.SimpleAddEncounter(2, "Author_EN", 2, "Rabies_EN");
            hard.SimpleAddEncounter(2, "Author_EN", 2, Enemies.Camera);
            hard.SimpleAddEncounter(2, "Author_EN", 2, "Enigma_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Author.Hard, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
