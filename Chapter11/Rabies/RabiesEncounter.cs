using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class RabiesEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_RabiesEncounter_Sign", ResourceLoader.LoadSprite("RabiesWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.Rabies.Med, "Salt_RabiesEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/Redo/RabiesTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Pearl_CH").deathSound;

            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", "Sigil_EN");
            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", "Enigma_EN");
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", "MusicMan_EN", "LostSheep_EN");
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Jumble.Blue);
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Jumble.Purple);
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", "Enigma_EN", "SingingStone_EN");
            med.AddRandomEncounter("Rabies_EN", Spoggle.Red, "Enigma_EN");
            med.AddRandomEncounter("Rabies_EN", Spoggle.Purple, "Enigma_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Rabies.Med, 12, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Medium);
        }
        public static void Add_Hardmode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Rabies.Med, "Salt_RabiesEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/Redo/RabiesTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("Pearl_CH").deathSound;

            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", "Sigil_EN", Enemies.Suckle, Enemies.Suckle);
            med.SimpleAddEncounter(2, "Rabies_EN", 2, "Enigma_EN");
            med.SimpleAddEncounter(3, "Rabies_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(3, "Rabies_EN");
            med.SimpleAddEncounter(2, "Rabies_EN", 2, "MusicMan_EN");
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", "MusicMan_EN", "LostSheep_EN");
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Jumble.Blue);
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Jumble.Purple);
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Spoggle.Red);
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Spoggle.Purple);
            med.SimpleAddEncounter(1, "Rabies_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Flower.Yellow);
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", Flower.Purple);
            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", "MusicMan_EN", "Sigil_EN");
            med.SimpleAddEncounter(2, "Rabies_EN", 2, "DeadPixel_EN");
            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", "WindSong_EN");
            med.AddRandomEncounter("Rabies_EN", "MusicMan_EN", "WindSong_EN");
            med.SimpleAddEncounter(1, "Rabies_EN", 3, "Delusion_EN");
            med.SimpleAddEncounter(2, "Rabies_EN", 2, "Delusion_EN");
            med.AddRandomEncounter("Rabies_EN", "Delusion_EN", Spoggle.Purple);
            med.AddRandomEncounter("Rabies_EN", "Delusion_EN", Spoggle.Red);
            med.AddRandomEncounter("Rabies_EN", "Delusion_EN", "Delusion_EN", "Butterfly_EN");
            med.SimpleAddEncounter(2, "Rabies_EN", 2, "Butterfly_EN");
            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", Enemies.Solvent, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("Rabies_EN", "Rabies_EN", Enemies.Camera, Enemies.Suckle, Enemies.Suckle);
            med.SimpleAddEncounter(2, "Rabies_EN", 1, Enemies.Camera, 1, "Sigil_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Rabies.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Something.Med);
            med.AddRandomGroup("Something_EN", "Rabies_EN", Spoggle.Yellow);
            med.AddRandomGroup("Something_EN", "Rabies_EN", Spoggle.Blue);

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Rabies_EN", "Scrungie_EN");

            med = new AddTo(Orph.H.Freud.Med);
            med.AddRandomGroup("Freud_EN", "Rabies_EN", "Delusion_EN");
            med.AddRandomGroup("Freud_EN", "Rabies_EN", Jumble.Blue);

            med = new AddTo(Orph.H.Camera.Med);
            med.AddRandomGroup(Enemies.Camera, Enemies.Camera, "Rabies_EN", "Rabies_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.SimpleAddGroup(3, "Delusion_EN", 1, "Rabies_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Rabies_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Rabies_EN");

            med = new AddTo(Orph.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "Rabies_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Sigil.Med);
            med.AddRandomGroup("Sigil_EN", "MusicMan_EN", "MusicMan_EN", "Rabies_EN");
            med.AddRandomGroup("Sigil_EN", "Rabies_EN", "Rabies_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Rabies_EN", "Delusion_EN", "Delusion_EN");
            med.AddRandomGroup("WindSong_EN", "Rabies_EN", "MusicMan_EN", "MusicMan_EN");

            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Rabies_EN", Enemies.Suckle);

            hard = new AddTo(Orph.Scrungie.Hard);
            hard.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Rabies_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Rabies_EN");

            med = new AddTo(Orph.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, "Rabies_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            med.AddRandomGroup(Jumble.Blue, Jumble.Purple, "Rabies_EN");

            med = new AddTo(Orph.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, "Rabies_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, Jumble.Blue, "Rabies_EN");

            med = new AddTo(Orph.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, "Rabies_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Spoggle.Red.Med);
            med.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Rabies_EN");

            med = new AddTo(Orph.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Purple, "Rabies_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Spoggle.Purple.Med);
            med.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "Rabies_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Rabies_EN", "Rabies_EN");

            hard = new AddTo(Orph.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Rabies_EN");

            hard = new AddTo(Orph.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Rabies_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Rabies_EN", "LostSheep_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Rabies_EN", "MusicMan_EN", "Sigil_EN");
            hard.AddRandomGroup("Conductor_EN", "Rabies_EN", "Enigma_EN", "Sigil_EN");
        }
    }
}
