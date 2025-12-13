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
            med.SimpleAddGroup(2, "TheWhale_EN", 3, "Surrogate_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 2, "StarVampire_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 1, "Lloigor_EN");
            med.SimpleAddGroup(2, "TheWhale_EN", 2, "ClayChildSleep_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "TheWhale_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "TheWhale_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "TheWhale_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.SimpleAddGroup(2, Enemies.Camera, 1, "TheWhale_EN", 1, Bots.Yellow);

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(2, "Delusion_EN", 1, "FakeAngel_EN", 1, "TheWhale_EN");
            med.SimpleAddGroup(3, "Delusion_EN", 1, "TheWhale_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "TheWhale_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "TheWhale_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "TheWhale_EN", "TheWhale_EN", "Enigma_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "TheWhale_EN", "MusicMan_EN", "MusicMan_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "TheWhale_EN", Enemies.Suckle);

            hard = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "TheWhale_EN", Enemies.Solvent, Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "TheWhale_EN", "Enigma_EN", "Enigma_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "TheWhale_EN", "Crystal_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Yellow, Bots.Red, "TheWhale_EN");
            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Yellow, Bots.Red, "TheWhale_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "TheWhale_EN");
            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "TheWhale_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "TheWhale_EN", "Surrogate_EN", "Surrogate_EN");

            med = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "TheWhale_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "TheWhale_EN", "WindSong_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "TheWhale_EN", Spoggle.Red);

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "TheWhale_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.AddRandomGroup("Wednesday_EN", "TheWhale_EN", "Solitaire_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(3, "Solitaire_EN", 1, "TheWhale_EN");

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Author_EN", "TheWhale_EN", "Sigil_EN");

            med = new AddTo(Orph.H.Insider.Med);
            med.SimpleAddGroup(2, "Insider_EN", 1, "TheWhale_EN");

            med = new AddTo(Orph.H.Nume.Med);
            med.AddRandomGroup("Nume_EN", "TheWhale_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, "TheWhale_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.SimpleAddGroup(2, "Scrungie_EN", 1, "TheWhale_EN", 1, "Romantic_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, "TheWhale_EN");
            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, "TheWhale_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "TheWhale_EN");
            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "TheWhale_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "TheWhale_EN", "TheWhale_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "TheWhale_EN", "Enigma_EN", "Enigma_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "TheWhale_EN", Jumble.Purple);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "TheWhale_EN", "TheWhale_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Moone.Med);
            med.SimpleAddGroup(3, "Moone_EN", 1, "TheWhale_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "TheWhale_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "TheWhale_EN", Spoggle.Purple);

            med = new AddTo(Orph.H.Heehoo.Hard);
            hard.AddRandomGroup("Heehoo_EN", "TheWhale_EN", "TheWhale_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Frostbite.Med);
            med.SimpleAddGroup(3, "Frostbite_EN", 1, "TheWhale_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "BackupDancer_EN", "TheWhale_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", "TheWhale_EN", Jumble.Unstable);

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "TheWhale_EN", "TheWhale_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Clergy.Med);
            med.AddRandomGroup("Clergy_EN", "TheWhale_EN", Bots.Yellow);

            hard = new AddTo(Orph.H.Clergy.Hard);
            hard.AddRandomGroup("Clergy_EN", "TheWhale_EN", "TheWhale_EN", "Romantic_EN");

            hard = new AddTo(Orph.H.Sonoduct.Hard);
            hard.AddRandomGroup("Sonoduct_EN", "TheWhale_EN");

            med = new AddTo(Orph.H.Byakhee.Med);
            med.AddRandomGroup("Byakhee_EN", "TheWhale_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Vampire.Med);
            med.AddRandomGroup("StarVampire_EN", "TheWhale_EN", Flower.Purple);

            med = new AddTo(Orph.H.Bloatfinger.Med);
            med.AddRandomGroup("Bloatfinger_EN", "TheWhale_EN", "Foxtrot_EN", "Foxtrot_EN");
        }
    }
}
