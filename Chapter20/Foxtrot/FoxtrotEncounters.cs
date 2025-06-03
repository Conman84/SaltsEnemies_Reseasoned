using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class FoxtrotEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_FoxtrotEncounter_Sign", ResourceLoader.LoadSprite("FoxtrotWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Orph.H.Foxtrot.Easy, "Salt_FoxtrotEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/FoxtrotPlaceholder";
            easy.RoarEvent = "event:/Hawthorne/Sund/FoxtrotDie";

            easy.SimpleAddEncounter(3, "Foxtrot_EN");
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 1, "LostSheep_EN");
            easy.SimpleAddEncounter(3, "Foxtrot_EN", 1, "LostSheep_EN");
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 3, Enemies.Suckle);
            easy.SimpleAddEncounter(3, "Foxtrot_EN", 2, Enemies.Suckle);
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 1, Jumble.Yellow);
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 1, Jumble.Red);
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 1, Spoggle.Blue);
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 1, Spoggle.Yellow);
            easy.SimpleAddEncounter(2, "Foxtrot_EN", 1, "Enigma_EN");
            easy.SimpleAddEncounter(3, "Foxtrot_EN", 1, "SingingStone_EN");
            easy.SimpleAddEncounter(3, "Foxtrot_EN", 1, "CandyStone_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Foxtrot.Easy, 3, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Orph.H.Enigma.Easy);
            easy.SimpleAddGroup(2, "Enigma_EN", 2, "Foxtrot_EN");

            AddTo med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(3, "Enigma_EN", 2, "Foxtrot_EN");
            med.SimpleAddGroup(4, "Enigma_EN", 1, "Foxtrot_EN");

            easy = new AddTo(Orph.H.Something.Easy);
            easy.AddRandomGroup("Something_EN", "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", Bots.Purple, "Foxtrot_EN", "Foxtrot_EN");
            med.AddRandomGroup("Something_EN", "MusicMan_EN", "MusicMan_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.SimpleAddGroup(1, "TheCrow_EN", 4, "Foxtrot_EN");
            med.AddRandomGroup("TheCrow_EN", "Spectre_EN", "Spectre_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Camera.Med);
            med.SimpleAddGroup(3, Enemies.Camera, 1, "Foxtrot_EN");

            easy = new AddTo(Orph.H.Delusion.Easy);
            easy.SimpleAddGroup(2, "Delusion_EN", 1, "Foxtrot_EN");
            easy.SimpleAddGroup(1, "Delusion_EN", 3, "Foxtrot_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(3, "Delusion_EN", 1, "Foxtrot_EN");
            med.SimpleAddGroup(2, 'Delusion_EN', 1, "Foxtrot_EN", 1, Enemies.Solvent);

            easy = new AddTo(Orph.H.Flower.Yellow.Easy);
            easy.AddRandomGroup(Flower.Yellow, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.SimpleAddGroup(1, "Sigil_EN", 3, "Foxtrot_EN");
            med.SimpleAddGroup(1, "Sigil_EN", 2, "Solitaire_EN", 1, "Foxtrot_EN");

            easy = new AddTo(Orph.H.Solvent.Easy);
            easy.AddRandomGroup(Enemies.Solvent, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Scrungie_EN", "Scrungie_EN", "Foxtrot_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.SimpleAddGroup(1, "StalwartTortoise_EN", 2, "Foxtrot_EN");

            med = new AddTo(Orph.H.Butterfly.Med);
            med.SimpleAddGroup(3, "Spectre_EN", 1, "Foxtrot_EN");

            med = new AddTo(Orph.H.Rabies.Med);
            med.SimpleAddGroup(2, "Rabies_EN", 1, "Foxtrot_EN");
            med.SimpleAddGroup(1, "Rabies_EN", 3, "Foxtrot_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.SimpleAddGroup(1, "Maw_EN", 3, "Foxtrot_EN");
            med.AddRandomGroup("Maw_EN", "Foxtrot_EN", "Solitaire_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "YellowAngel_EN", "Foxtrot_EN");
            hard.AddRandomGroup("Maw_EN", Jumble.Blue, Jumble.Purple, "Foxtrot_EN");

            med = new AddTo(Orph.H.Bot.Red.Med);
            med.AddRandomGroup(Bots.Red, Bots.Yellow, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Bot.Yellow.Med);
            med.AddRandomGroup(Bots.Yellow, Bots.Red, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Bot.Purple.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Bot.Blue.Med);
            med.AddRandomGroup(Bots.Blue, Bots.Purple, "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Foxtrot_EN", "Foxtrot_EN");
            med.SimpleAddGroup(2, "Crystal_EN", 2, "Foxtrot_EN");
            med.AddRandomGroup("Crystal_EN", "MusicMan_EN", "Foxtrot_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.SimpleAddGroup(1, "TheDragon_EN", 3, "Foxtrot_EN");
            hard.AddRandomGroup("TheDragon_EN", "Foxtrot_EN", Spoggle.Red);

            med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Foxtrot_EN", "Foxtrot_EN", "Solitaire_EN");
            med.AddRandomGroup("Evileye_EN", "Foxtrot_EN", "TheCrow_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Foxtrot_EN", Bots.Blue);
            med.AddRandomGroup("YellowAngel_EN", "Foxtrot_EN", "Spectre_EN", "Spectre_EN");

            easy = new AddTo(Orph.H.Shooter.Easy);
            easy.SimpleAddGroup(2, Enemies.Shooter, 1, "Foxtrot_EN");

            med = new AddTo(Orph.H.Shooter.Med);
            med.AddRandomGroup(Enemies.Shooter, "Foxtrot_EN", "Foxtrot_EN", Jumble.Blue);
            med.AddRandomGroup(Enemies.Shooter, "Foxtrot_EN", Bots.Purple);

            med = new AddTo(Orph.H.Solitaire.Med);
            med.SimpleAddGroup(2, "Solitaire_EN", 2, "Foxtrot_EN");
            med.SimpleAddGroup(2, "Solitaire_EN", 1, "Delusion_EN", 1, "Foxtrot_EN");

            easy = new AddTo(Orph.H.MusicMan.Easy);
            easy.AddRandomGroup("MusicMan_EN", "Foxtrot_EN", "Foxtrot_EN");
            easy.SimpleAddGroup(2, "MusicMan_EN", 1, "Foxtrot_EN");

            med = new AddTo(Orph.H.MusicMan.Med);
            med.SimpleAddGroup(3, "MusicMan_EN", 1, "Foxtrot_EN");
            med.AddRandomGroup("MusicMan_EN", "MusicMan_EN", Bots.Yellow, "Foxtrot_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.SimpleAddGroup(2, "Scrungie_EN", 2, "Foxtrot_EN");
            med.AddRandomGroup("Scrungie_EN", "Foxtrot_EN", "Foxtrot_EN", Flower.Purple);

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, "Foxtrot_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, Jumble.Blue, "Foxtrot_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Foxtrot_EN");

            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "Foxtrot_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Foxtrot_EN", "Foxtrot_EN", "Something_EN");
            hard.AddRandomGroup(Enemies.Sacrifice, "Foxtrot_EN", "TheCrow_EN", "Nameless_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Foxtrot_EN", "Foxtrot_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Foxtrot_EN", "Foxtrot_EN", "SingingStone_EN");
            med.AddRandomGroup("Conductor_EN", "Foxtrot_EN", Spoggle.Purple);

            hard = new AddTo(Orph.H.Conductor.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Crystal_EN", "Foxtrot_EN", "SingingStone_EN");
            hard.AddRandomGroup("Conductor_EN", "Freud_EN", "Foxtrot_EN", "Foxtrot_EN");
        }
    }
}
