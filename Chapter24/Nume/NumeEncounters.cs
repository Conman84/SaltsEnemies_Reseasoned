using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NumeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_NumeEncounter_Sign", ResourceLoader.LoadSprite("NumeWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Nume.Med, "Salt_NumeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NumeSong";
            med.RoarEvent = "event:/Hawthorne/Surround/EnigmaRoar";

            med.SimpleAddEncounter(2, "Nume_EN", 2, "SingingStone_EN");
            med.SimpleAddEncounter(1, "Nume_EN", 3, "MusicMan_EN");
            med.AddRandomEncounter("Nume_EN", "Scrungie_EN", "Scrungie_EN", "LostSheep_EN");
            med.AddRandomEncounter("Nume_EN", Spoggle.Red, Spoggle.Yellow);
            med.AddRandomEncounter("Nume_EN", Jumble.Red, Jumble.Purple);
            med.SimpleAddEncounter(1, "Nume_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("Nume_EN", "Sigil_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomEncounter("Nume_EN", Flower.Yellow, Enemies.Shooter);
            med.AddRandomEncounter("Nume_EN", Flower.Purple, Enemies.Shooter);
            med.AddRandomEncounter("Nume_EN", Enemies.Solvent, Jumble.Blue);
            med.AddRandomEncounter("Nume_EN", Bots.Yellow, Bots.Red);
            med.SimpleAddEncounter(1, "Nume_EN", 2, "Delusion_EN", 1, "FakeAngel_EN");
            med.SimpleAddEncounter(1, "Nume_EN", 2, "Rabies_EN");
            if (SaltsReseasoned.rando == 16) med.SimpleAddEncounter(1, "Nume_EN", 3, "Spectre_EN");
            med.AddRandomEncounter("Nume_EN", Enemies.Camera, "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("Nume_EN", "Nameless_EN", "Enigma_EN", "Enigma_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Nume.Med, 13, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, "Nume_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.SimpleAddGroup(2, "Scrungie_EN", 1, "Nume_EN", 2, Enemies.Suckle);

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Nume_EN", Jumble.Red);

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, "Nume_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, "Nume_EN", Spoggle.Purple);

            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Purple, "Nume_EN", Spoggle.Unstable);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Nume_EN", "Solitaire_EN");

            AddTo hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.SimpleAddGroup(1, Enemies.Sacrifice, 2, "Nume_EN");
            hard.AddRandomGroup(Enemies.Sacrifice, "Nume_EN", "Enigma_EN", "Enigma_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Nume_EN", "Sigil_EN");
            hard.AddRandomGroup("Revola_EN", "Nume_EN", "Numeless_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Nume_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Nume_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Nume_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Nume_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "FakeAngel_EN", "Nume_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, "Nume_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, "Nume_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "Nume_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Nume_EN", "Solitaire_EN");

            hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Nume_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Nameless.Med);
            med.AddRandomGroup("Nameless_EN", "Nume_EN", "Author_EN");
            med.AddRandomGroup("Nameless_EN", "Nume_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Nume_EN", "Insider_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Nume_EN", "YellowAngel_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Nume_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Yellow, Bots.Red, "Nume_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Nume_EN", "Evileye_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Nume_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Nume_EN", Bots.Purple);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Nume_EN", "Something_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "Nume_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "Nume_EN", "Scrungie_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Nume_EN", Enemies.Suckle);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "Nume_EN");

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "Moone_EN", "Moone_EN");
            med.SimpleAddGroup(1, "Nume_EN", 3, "Frostbite_EN");
            med.SimpleAddGroup(1, "Nume_EN", 1, "BackupDancer_EN", 2, "MusicMan_EN");
            med.SimpleAddGroup(1, "Nume_EN", 3, "Gungrot_EN");
            med.AddRandomGroup("Nume_EN", Jumble.Blue, Jumble.Unstable);
            med.AddRandomGroup("Nume_EN", Spoggle.Purple, Spoggle.Unstable);
            med.AddRandomGroup("Nume_EN", "Romantic_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("Nume_EN", "StarVampire_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Moone.Med);
            med.SimpleAddGroup(2, "Moone_EN", 1, "Nume_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Nume_EN", Enemies.Solvent);

            hard = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "Insider_EN", "Nume_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "Nume_EN", "Gungrot_EN", "Gungrot_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "Nume_EN", "BackupDancer_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Clergy.Med);
            med.AddRandomGroup("Clergy_EN", "Nume_EN", Bots.Blue);

            hard = new AddTo(Orph.H.Clergy.Hard);
            hard.AddRandomGroup("Clergy_EN", "Nume_EN", "Solitaire_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Vampire.Med);
            med.AddRandomGroup("StarVampire_EN", "Nume_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Byakhee.Med);
            med.AddRandomGroup("Byakhee_EN", "Nume_EN", "Freud_EN");
            med.AddRandomGroup("Byakhee_EN", "Nume_EN", "Insider_EN");

            med = new AddTo(Orph.H.Bloatfinger.Med);
            med.AddRandomGroup("Bloatfinger_EN", "Nume_EN", "WindSong_EN");

            hard = new AddTo(Orph.H.Sonoduct.Hard);
            hard.AddRandomGroup("Sonoduct_EN", "Nume_EN", "Lloigor_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "Nume_EN", Enemies.Suckle, Enemies.Suckle);
        }
    }
}
