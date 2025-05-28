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
    }
}
