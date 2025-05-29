using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class MawEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_MawEncounter_Sign", ResourceLoader.LoadSprite("MawWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Maw.Med, "Salt_MawEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/NewMawTheme";
            med.RoarEvent = LoadedAssetsHandler.GetCharacter("LongLiver_CH").deathSound;

            med.SimpleAddEncounter(1, "Maw_EN", 4, Enemies.Suckle);
            med.AddRandomEncounter("Maw_EN", "WindSong_EN");
            med.AddRandomEncounter("Maw_EN", Enemies.Solvent);
            med.AddRandomEncounter("Maw_EN", "Something_EN");
            med.AddRandomEncounter("Maw_EN", Flower.Purple);
            med.AddRandomEncounter("Maw_EN", Flower.Yellow);
            med.AddRandomEncounter("Maw_EN", Spoggle.Red);
            med.AddRandomEncounter("Maw_EN", Spoggle.Purple);
            med.AddRandomEncounter("Maw_EN", Jumble.Blue);
            med.AddRandomEncounter("Maw_EN", Jumble.Purple);
            med.AddRandomEncounter("Maw_EN", "Nameless_EN");
            med.SimpleAddEncounter(1, "Maw_EN", 2, "SingingStone_EN");
            med.AddRandomEncounter("Maw_EN", "Delusion_EN");
            med.AddRandomEncounter("Maw_EN", "MusicMan_EN");
            med.AddRandomEncounter("Maw_EN", "Sigil_EN");
            med.AddRandomEncounter("Maw_EN", "LostSheep_EN");
            med.AddRandomEncounter("Maw_EN", "Enigma_EN");
            med.AddRandomEncounter("Maw_EN", "Scrungie_EN");
            med.AddRandomEncounter("Maw_EN", Enemies.Camera);
            med.AddRandomEncounter("Maw_EN", "Butterfly_EN");
            med.AddRandomEncounter("Maw_EN", "Rabies_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Maw.Med, 5, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.Maw.Hard, "Salt_MawEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/NewMawTheme";
            hard.RoarEvent = LoadedAssetsHandler.GetCharacter("LongLiver_CH").deathSound;

            hard.SimpleAddEncounter(2, "Maw_EN", 3, Enemies.Suckle);
            hard.SimpleAddEncounter(1, "Maw_EN", 3, "MusicMan_EN", 1, "SingingStone_EN");
            hard.AddRandomEncounter("Maw_EN", "Scrungie_EN", "Scrungie_EN");
            hard.SimpleAddEncounter(1, "Maw_EN", 3, "Enigma_EN");
            hard.AddRandomEncounter("Maw_EN", "MusicMan_EN", "MusicMan_EN", "Sigil_EN");
            hard.AddRandomEncounter("Maw_EN", "Scrungie_EN", "Sigil_EN");
            hard.AddRandomEncounter("Maw_EN", "Something_EN", "Something_EN");
            hard.AddRandomEncounter("Maw_EN", "TheCrow_EN", "Delusion_EN");
            hard.AddRandomEncounter("Maw_EN", "Freud_EN", "MusicMan_EN");
            hard.AddRandomEncounter("Maw_EN", "Delusion_EN", "Delusion_EN", "FakeAngel_EN");
            hard.SimpleAddEncounter(1, "Maw_EN", 3, "Delusion_EN");
            hard.SimpleAddEncounter(1, "Maw_EN", 3, Enemies.Camera);
            hard.AddRandomEncounter("Maw_EN", Flower.Yellow, Flower.Purple);
            hard.AddRandomEncounter("Maw_EN", Jumble.Blue, Jumble.Purple);
            hard.AddRandomEncounter("Maw_EN", Spoggle.Red, Spoggle.Purple);
            hard.AddRandomEncounter("Maw_EN", "WindSong_EN", "Scrungie_EN");
            hard.AddRandomEncounter("Maw_EN", Enemies.Solvent, "Delusion_EN", "Delusion_EN");
            hard.SimpleAddEncounter(1, "Maw_EN", 3, "Butterfly_EN");
            hard.SimpleAddEncounter(1, "Maw_EN", 3, "ManicMan_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Maw.Hard, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Orph.H.Tortoise.Hard);
            hard.AddRandomGroup("StalwartTortoise_EN", "Maw_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.SimpleAddGroup(1, "Sacrifice_EN", 1, "Maw_EN", 3, Enemies.Suckle);

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "Maw_EN", "SingingStone_EN");
        }
    }
}
