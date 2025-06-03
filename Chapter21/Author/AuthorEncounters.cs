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
            med.AddRandomEncounter("Author_EN", "Something_EN", Bots.Red);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Bots.Blue);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Bots.Yellow);
            med.AddRandomEncounter("Author_EN", "Something_EN", Bots.Purple);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Jumble.Blue);
            med.AddRandomEncounter("Author_EN", "Something_EN", Jumble.Purple);
            med.AddRandomEncounter("Author_EN", "Scrungie_EN", Spoggle.Red);
            med.AddRandomEncounter("Author_EN", "Something_EN", Spoggle.Purple);
            med.AddRandomEncounter("Author_EN", "Something_EN", Flower.Yellow);
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
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Author_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Author_EN", Spoggle.Red);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Author_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "Author_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "MusicMan_EN", "Author_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Author_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Author_EN", Bots.Yellow);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Author_EN", "Evileye_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Author_EN", "LostSheep_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Author_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Author_EN", Jumble.Purple);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Author_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "MusicMan_EN", "MusicMan_EN", "Author_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Author_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.SimpleAddGroup(2, "Scrungie_EN", 1, "Author_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, "Author_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Author_EN", "Author_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Author_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Author_EN", "SingingStone_EN", "SingingStone_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Author_EN", "Crystal_EN");
        }
    }
}
