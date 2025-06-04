using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EvileyeEncounters
    {
        public static void Add()
        {
            Add_Normal();
            Add_Hardmode();
        }
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_EvileyeEncounter_Sign", ResourceLoader.LoadSprite("EyeballWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.Evileye.Hard, "Salt_EvileyeEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/EvilEyeTheme";
            hard.RoarEvent = "event:/Hawthorne/Noisy/Eye_Roar";

            hard.SimpleAddEncounter(1, "Evileye_EN", 4, "SingingStones_EN");
            hard.SimpleAddEncounter(1, "Evileye_EN", 2, "MusicMan_EN");
            hard.SimpleAddEncounter(1, "Evileye_EN", 2, "Scrungie_EN");
            hard.AddRandomEncounter("Evileye_EN", "MusicMan_EN", "Sigil_EN");
            hard.AddRandomEncounter("Evileye_EN", "Enigma_EN", "Enigma_EN");
            hard.AddRandomEncounter("Evileye_EN", "Rabies_EN");
            hard.SimpleAddEncounter(1, "Evileye_EN", 4, "LostSheep_EN");
            hard.AddRandomEncounter("Evileye_EN", Bots.Red, Bots.Yellow);
            hard.AddRandomEncounter("Evileye_EN", Jumble.Purple, Jumble.Blue);
            hard.AddRandomEncounter("Evileye_EN", Spoggle.Red, Spoggle.Purple);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.Evileye.Hard, 10, ZoneType_GameIDs.Orpheum_Easy, BundleDifficulty.Hard);
        }
        public static void Add_Hardmode()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Evileye.Med, "Salt_EvileyeEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EvilEyeTheme";
            med.RoarEvent = "event:/Hawthorne/Noisy/Eye_Roar";

            med.SimpleAddEncounter(1, "Evileye_EN", 4, "SingingStones_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 3, "MusicMan_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 2, "Scrungie_EN");
            med.AddRandomEncounter("Evileye_EN", "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            med.AddRandomEncounter("Evileye_EN", "Delusion_EN", "Delusion_EN", "Sigil_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 3, "Enigma_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 4, "LostSheep_EN");
            med.AddRandomEncounter("Evileye_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("Evileye_EN", "Rabies_EN", "Rabies_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 3, "Spectre_EN");
            if (Winter.Chance) med.AddRandomEncounter("Evileye_EN", "Crystal_EN", Enemies.Suckle);
            if (Winter.Chance) med.AddRandomEncounter("Evileye_EN", "Crystal_EN", "LostSheep_EN");
            if (Winter.Chance) med.AddRandomEncounter("Evileye_EN", "Crystal_EN", "MusicMan_EN");
            if (Winter.Chance) med.AddRandomEncounter("Evileye_EN", "Crystal_EN", "Enigma_EN");
            med.AddRandomEncounter("Evileye_EN", "WindSong_EN", "Delusion_EN");
            med.AddRandomEncounter("Evileye_EN", Enemies.Solvent, "Scrungie_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 4, "TortureMeNot_EN");
            med.SimpleAddEncounter(1, "Evileye_EN", 2, Enemies.Camera);
            med.AddRandomEncounter("Evileye_EN", "Something_EN");
            med.AddRandomEncounter("Evileye_EN", "TheCrow_EN", Enemies.Suckle, Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("Evileye_EN", "Freud_EN", "LostSheep_EN");
            med.AddRandomEncounter("Evileye_EN", Jumble.Blue, Jumble.Purple);
            med.AddRandomEncounter("Evileye_EN", Spoggle.Red, Spoggle.Purple);
            med.AddRandomEncounter("Evileye_EN", Flower.Purple, Flower.Yellow);
            med.AddRandomEncounter("Evileye_EN", Bots.Blue, Bots.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Evileye.Med, 15 * April.Mod, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Evileye_EN");

            AddTo med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Evileye_EN");
            med.SimpleAddGroup(1, "Maw_EN", 1, "Evileye_EN", 3, Enemies.Suckle);

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", "MusicMan_EN");
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", "Delusion_EN");
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", Bots.Yellow);
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", Bots.Red);
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", "WindSong_EN");
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", "Freud_EN");
            hard.AddRandomGroup("Maw_EN", "Evileye_EN", "TheCrow_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Evileye_EN", "Enigma_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.AddRandomGroup(Enemies.Sacrifice, "Evileye_EN", "TheCrow_EN");

            hard = new AddTo(Orph.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Evileye_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Evileye_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("Conductor_EN", "Evileye_EN", "LostSheep_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Evileye_EN", "Crystal_EN");
        }
    }
}
