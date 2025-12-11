using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class NamelessEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_NamelessEncounter_Sign", ResourceLoader.LoadSprite("NamelessWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Nameless.Med, "Salt_NamelessEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NamelessTheme";
            med.RoarEvent = "event:/Hawthorne/Soisenay/BlackStarDie";

            med.SimpleAddEncounter(3, "Nameless_EN");
            med.AddRandomEncounter("Nameless_EN", "Nameless_EN", "MusicMan_EN", "MusicMan_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 1, "Scrungie_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 2, "Enigma_EN");
            med.AddRandomEncounter("Nameless_EN", "Nameless_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("Nameless_EN", "Nameless_EN", Bots.Red, Bots.Blue);
            med.SimpleAddEncounter(2, "Nameless_EN", 1, Enemies.Shooter);
            med.SimpleAddEncounter(2, "Nameless_EN", 2, "ManicMan_EN", 1, "Wednesday_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 1, "Something_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 2, "Delusion_EN", 1, "FakeAngel_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 1, Flower.Yellow, 1, Enemies.Solvent);
            med.SimpleAddEncounter(2, "Nameless_EN", 1, Flower.Purple, 1, Enemies.Solvent);
            med.SimpleAddEncounter(2, "Nameless_EN", 1, "WindSong_EN", 1, "Rabies_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 2, "Spectre_EN", 1, "TortureMeNot_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 2, "Solitaire_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 1, "Author_EN", 2, Enemies.Suckle);
            med.SimpleAddEncounter(2, "Nameless_EN", 1, "Insider_EN", 2, "SingingStone_EN");
            med.SimpleAddEncounter(2, "Nameless_EN", 1, "Foxtrot_EN", 1, Jumble.Yellow);
            med.SimpleAddEncounter(2, "Nameless_EN", 1, Spoggle.Red, 1, Spoggle.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Nameless.Med, April.Birthday ? 15 : April.Custom ? 10 : 0, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
            //EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Nameless.Med, 300, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Something_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", Jumble.Blue, "Nameless_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(3, "Delusion_EN", 1, "FakeAngel_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "LostSheep_EN", "Nameless_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.SimpleAddGroup(1, "WindSong_EN", 1, "Nameless_EN", 3, "MusicMan_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Nameless_EN", Flower.Purple);

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(4, "MusicMan_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Nameless_EN", "Something_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Nameless_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", Enemies.Camera, Enemies.Camera, "Nameless_EN");

            SaltsReseasoned.PCall(Again);
        }
        public static void Again()
        {
            AddTo med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Scrungie_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.SimpleAddGroup(1, "Maw_EN", 3, "Nameless_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Nameless_EN");
            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Nameless_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "MusicMan_EN", "MusicMan_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Nameless_EN", Spoggle.Red);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Nameless_EN", Jumble.Red, Jumble.Yellow);

            med = new AddTo(Orph.H.Solitaire.Med);
            med.AddRandomGroup("Solitaire_EN", "Solitaire_EN", "Nameless_EN", Jumble.Unstable);

            med = new AddTo(Orph.H.Author.Med);
            med.AddRandomGroup("Author_EN", "Nameless_EN", "Scrungie_EN", "Author_EN");

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Nameless_EN");
            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Nameless_EN");

            AddTo hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Jumble.Blue, "Nameless_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Nameless_EN", "Scrungie_EN", "Scrungie_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, Enemies.Sacrifice, "Nameless_EN");

            med = new AddTo(Orph.H.Errant.Med);
            med.AddRandomGroup("Errant_EN", Jumble.Unstable, "Nameless_EN");
            med.AddRandomGroup("Errant_EN", "Nameless_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Dancer.Med);
            med.AddRandomGroup("BackupDancer_EN", "MusicMan_EN", "MusicMan_EN", "Nameless_EN");

            med = new AddTo(Orph.H.Shuffler.Med);
            med.AddRandomGroup(Enemies.Shuffler, Enemies.Shuffler, "Nameless_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Nameless_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", Spoggle.Red, "Nameless_EN");

            med = new AddTo(Orph.H.Moone.Med);
            med.SimpleAddGroup(3, "Moone_EN", 1, "Nameless_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.SimpleAddGroup(2, Enemies.Shooter, 1, "Nameless_EN");
        }
    }
}
