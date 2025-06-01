using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public static class YellowAngelEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_YellowAngelEncounter_Sign", ResourceLoader.LoadSprite("HarpoonWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.YellowAngel.Med, "Salt_YellowAngelEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/YellowAngelTheme";
            med.RoarEvent = "event:/Hawthorne/Noisy/YA_Roar";

            med.SimpleAddEncounter(1, "YellowAngel_EN", 3, "Enigma_EN");
            med.AddRandomEncounter("YellowAngel_EN", "MusicMan_EN", "MusicMan_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Scrungie_EN", "Scrungie_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Something_EN", Jumble.Blue);
            med.AddRandomEncounter("YellowAngel_EN", "Freud_EN", Spoggle.Purple);
            med.AddRandomEncounter("YellowAngel_EN", Bots.Red, Bots.Yellow);
            med.AddRandomEncounter("YellowAngel_EN", Spoggle.Red, "TheCrow_EN");
            med.AddRandomEncounter("YellowAngel_EN", Enemies.Solvent, Flower.Yellow);
            med.AddRandomEncounter("YellowAngel_EN", "WindSong_EN", "SingingStone_EN", "SingingStone_EN", "SingingStone_EN");
            med.AddRandomEncounter("YellowAngel_EN", "Evileye_EN", "Sigil_EN");
            med.AddRandomEncounter("YellowAngel_EN", "ManicMan_EN", "ManicMan_EN");
            if (Winter.Chance) med.AddRandomEncounter("YellowAngel_EN", "Crystal_EN", "LostSheep_EN");
            med.SimpleAddEncounter(1, "YellowAngel_EN", 4, "TortureMeNot_EN");
            med.AddRandomEncounter("YellowAngel_EN", Enemies.Camera, Enemies.Camera, Spoggle.Red);
            med.AddRandomEncounter("YellowAngel_EN", "Spectre_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.YellowAngel.Med, 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
    }
}
