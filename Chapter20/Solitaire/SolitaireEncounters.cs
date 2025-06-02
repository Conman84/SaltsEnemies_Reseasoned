using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SolitaireEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_SolitaireEncounter_Sign", ResourceLoader.LoadSprite("SolitaireWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Solitaire.Med, "Salt_SolitaireEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/SolitairePlaceholder";
            med.RoarEvent = "event:/Hawthorne/Sund/SolitaireDie";

            med.SimpleAddEncounter(3, "Solitaire_EN");
            med.SimpleAddEncounter(3, "Solitaire_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(3, "Solitaire_EN", 2, Enemies.Suckle);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "MusicMan_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Bots.Red);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Bots.Blue);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Wednesday_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Jumble.Blue);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Spoggle.Red);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Flower.Purple);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "WindSong_EN");
            med.SimpleAddEncounter(2, "Solitaire_EN", 3, "TortureMeNot_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Bots.Yellow);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Jumble.Purple);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Flower.Yellow);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Enemies.Solvent);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Nameless_EN");
            med.SimpleAddEncounter(2, "Solitaire_EN", 3, Enemies.Suckle);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Scrungie_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Enigma_EN", "Enigma_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Enemies.Shooter);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Something_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Rabies_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Bots.Purple);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", "Delusion_EN");
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Spoggle.Purple);
            med.AddRandomEncounter("Solitaire_EN", "Solitaire_EN", Enemies.Camera);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Solitaire.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.Solitaire.Hard, "Salt_SolitaireEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/SolitairePlaceholder";
            hard.RoarEvent = "event:/Hawthorne/Sund/SolitaireDie";

            hard.SimpleAddEncounter(4, "Solitaire_EN");
            hard.SimpleAddEncounter(5, "Solitaire_EN");
            hard.SimpleAddEncounter(4, "Solitaire_EN", 1, Enemies.Suckle);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Solitaire.Hard, 1, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 1, "Solitaire_EN");

            AddTo easy = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Something_EN", "Solitaire_EN", "Sigil_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Solitaire_EN", "Solitaire_EN", Enemies.Solvent);
            med.AddRandomGroup("TheCrow_EN", "Solitaire_EN", Flower.Purple);
            med.AddRandomGroup("TheCrow_EN", "Solitaire_EN", "Something_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Freud_EN", "Solitaire_EN", "Wednesday_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.SimpleAddGroup(3, Enemies.Camera, 1, "Solitaire_EN");

            easy = new AddTo(Orph.H.Delusion.Easy);
            easy.AddRandomGroup("Delusion_EN", "Delusion_EN", "Solitaire_EN", "FakeAngel_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Solitaire_EN", "Wednesday_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Solitaire_EN", "Delusion_EN");

            easy = new AddTo(Orph.H.Flower.Yellow.Easy);
            easy.AddRandomGroup(Flower.Yellow, "Solitaire_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Solitaire_EN");
            med.AddRandomGroup(Flower.Yellow, "Solitaire_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Solitaire_EN");
            med.AddRandomGroup(Flower.Purple, "Solitaire_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "Solitaire_EN", "Solitaire_EN", Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Sigil_EN", "Solitaire_EN", "MusicMan_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Solitaire_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomGroup("WindSong_EN", "Solitaire_EN", "Scrungie_EN", Enemies.Suckle, Enemies.Suckle);

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Solitaire_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Rabies.Med);
            med.AddRandomGroup("Rabies_EN", "Rabies_EN", "Solitaire_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Maw_EN", "Solitaire_EN", "Scrungie_EN");
            med.AddRandomGroup("Maw_EN", "Solitaire_EN", Jumble.Blue);

            hard = new AddTo(Orph.H.Maw.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "Solitaire_EN", "Crystal_EN");
            hard.AddRandomGroup("Maw_EN", "Solitaire_EN", Bots.Blue);
            hard.AddRandomGroup("Maw_EN", "Solitaire_EN", Bots.Purple);

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Solitaire_EN");
            med.AddRandomGroup(Bots.Red, "Solitaire_EN", Enemies.Shooter);

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Yellow, Bots.Red, "Solitaire_EN");
            med.AddRandomGroup(Bots.Yellow, "Solitaire_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, "Solitaire_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Purple, "Solitaire_EN", "LostSheep_EN", "LostSheep_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Solitaire_EN", "Solitaire_EN", "LostSheep_EN");
            med.AddRandomGroup("Crystal_EN", "Solitaire_EN", Spoggle.Red);
            med.AddRandomGroup("Crystal_EN", "Solitaire_EN", Jumble.Purple);

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Solitaire_EN", "Solitaire_EN");
            hard.AddRandomGroup("TheDragon_EN", "Solitaire_EN", Bots.Yellow);
            hard.AddRandomGroup("TheDragon_EN", "Solitaire_EN", Spoggle.Red);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Evileye_EN", "Solitaire_EN", "WindSong_EN");
            med.AddRandomGroup("Evileye_EN", "Solitaire_EN", Jumble.Blue);
            med.AddRandomGroup("Evileye_EN", "Solitaire_EN", Flower.Yellow);

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("YellowAngel_EN", "TheCrow_EN", "Solitaire_EN");
            med.AddRandomGroup("YellowAngel_EN", "Solitaire_EN", Spoggle.Red);

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.AddRandomGroup(Enemies.Shooter, "Solitaire_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, Enemies.Shooter, "Solitaire_EN");

            med = new AddTo(Orph.H.Wednesday.Med);
            med.SimpleAddGroup(1, "Wednesday_EN", 3, "Solitaire_EN");
            med.AddRandomGroup("Wednesday_EN", "Solitaire_EN", Bots.Red, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomGroup("Wednesday_EN", "Solitaire_EN", Jumble.Blue, "LostSheep_EN");

            easy = new AddTo(Orph.H.MusicMan.Easy);
            easy.AddRandomGroup("MusicMan_EN", "MusicMan_EN", "Solitaire_EN");
            easy.AddRandomGroup("MusicMan_EN", "Solitaire_EN", "SingingStone_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, "Solitaire_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Solitaire_EN");
            med.AddRandomGroup("Scrungie_EN", "Solitaire_EN", Flower.Yellow, Enemies.Suckle);

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Solitaire_EN", "MusicMan_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, "Solitaire_EN", "Enigma_EN", "Enigma_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Solitaire_EN");
            med.AddRandomGroup(Spoggle.Red, "Solitaire_EN", "WindSong_EN");

            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "Solitaire_EN");
            med.AddRandomGroup(Spoggle.Purple, "Solitaire_EN", "Sigil_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Solitaire_EN", "YellowAngel_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Solitaire_EN", Enemies.Solvent);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Solitaire_EN", "Solitaire_EN");
            med.AddRandomGroup("Conductor_EN", "Solitaire_EN", "MusicMan_EN");
            med.AddRandomGroup("Conductor_EN", "Solitaire_EN", Jumble.Purple);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Solitaire_EN", "Maw_EN");
            hard.AddRandomGroup("Conductor_EN", "Solitaire_EN", "Evileye_EN");
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Solitaire_EN", "Crystal_EN");
        }
    }
}
