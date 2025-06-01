using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class CrystallineCorpseEaterEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_CrystallineCorpseEaterEncounter_Sign", ResourceLoader.LoadSprite("CrystalWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Crystal.Med, "Salt_CrystallineCorpseEaterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CrystalSong";
            med.RoarEvent = "event:/Hawthorne/Noise/CrystalRoar";

            med.SimpleAddEncounter(1, "Crystal_EN", 3, "CandyStone_EN");
            med.AddRandomEncounter("Crystal_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("Crystal_EN", "Enigma_EN", "Enigma_EN");
            med.SimpleAddEncounter(1, "Crystal_EN", 1, "MusicMan_EN", 3, Enemies.Suckle);
            med.SimpleAddEncounter(1, "Crystal_EN", 1, "Scrungie_EN", 3, Enemies.Suckle);
            med.AddRandomEncounter("Crystal_EN", "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            med.AddRandomEncounter("Crystal_EN", "Scrungie_EN", "LostSheep_EN");
            med.AddRandomEncounter("Crystal_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("Crystal_EN", "Scrungie_EN", Bots.Yellow);
            med.AddRandomEncounter("Crystal_EN", Bots.Red, "TheCrow_EN");
            med.AddRandomEncounter("Crystal_EN", "Freud_EN", Bots.Red);
            med.AddRandomEncounter("Crystal_EN", "Something_EN", "Something_EN");
            med.AddRandomEncounter("Crystal_EN", "Delusion_EN", "Delusion_EN");
            med.AddRandomEncounter("Crystal_EN", Flower.Yellow, "Something_EN");
            med.AddRandomEncounter("Crystal_EN", Flower.Purple, "Something_EN");
            med.AddRandomEncounter("Crystal_EN", "Crystal_EN", Enemies.Solvent);
            med.AddRandomEncounter("Crystal_EN", "WindSong_EN", "Something_EN");
            med.SimpleAddEncounter(1, "Crystal_EN", 3, "Spectre_EN");
            med.AddRandomEncounter("Crystal_EN", "Rabies_EN", "Sigil_EN", Enemies.Suckle, Enemies.Suckle);
            med.AddRandomEncounter("Crystal_EN", Enemies.Solvent, Enemies.Camera);
            med.AddRandomEncounter("Crystal_EN", Flower.Purple, "Scrungie_EN");
            med.AddRandomEncounter("Crystal_EN", Bots.Blue, "MusicMan_EN");
            med.AddRandomEncounter("Crystal_EN", Bots.Purple, "Enigma_EN");
            med.AddRandomEncounter("Crystal_EN", "WindSong_EN", "Scrungie_EN");
            med.AddRandomEncounter("Crystal_EN", "Crystal_EN", "Spectre_EN");
            med.AddRandomEncounter("Crystal_EN", "Crystal_EN", "LostSheep_EN");
            med.AddRandomEncounter("Crystal_EN", Spoggle.Red, Spoggle.Purple);
            med.AddRandomEncounter("Crystal_EN", Jumble.Blue, "Freud_EN");
            med.AddRandomEncounter("Crystal_EN", Spoggle.Red, "TheCrow_EN");
            med.AddRandomEncounter("Crystal_EN", Jumble.Purple, "Rabies_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Crystal.Med, 5 * Winter.Mod, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            if (Winter.Chance) hard.AddRandomGroup("StalwartTortoise_EN", "Crystal_EN");

            AddTo med = new AddTo(Orph.H.Maw.Med);
            if (Winter.Chance) med.AddRandomGroup("Maw_EN", "Crystal_EN", Enemies.Suckle, Enemies.Suckle);
            if (Winter.Chance) med.AddRandomGroup("Maw_EN", "Crystal_EN", "LostSheep_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "Crystal_EN", "WindSong_EN");
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "Crystal_EN", "Enigma_EN", "Enigma_EN");
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "Crystal_EN", Bots.Yellow);
            if (Winter.Chance) hard.AddRandomGroup("Maw_EN", "Crystal_EN", Spoggle.Red);

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            if (Winter.Chance) hard.AddRandomGroup(Enemies.Sacrifice, "Crystal_EN", "Crystal_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Revola_EN", "Crystal_EN", "LostSheep_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            if (Winter.Chance) med.AddRandomGroup("Conductor_EN", "Crystal_EN", "SingingStone_EN");
            if (Winter.Chance) med.AddRandomGroup("Conductor_EN", "Crystal_EN", "MusicMan_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Crystal_EN", Spoggle.Red);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Crystal_EN", Jumble.Blue);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Crystal_EN", Flower.Yellow);
            if (Winter.Chance) hard.AddRandomGroup("Conductor_EN", "Crystal_EN", Bots.Red);
        }
    }
}
