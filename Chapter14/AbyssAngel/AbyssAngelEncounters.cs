using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AbyssAngelEncounters
    {
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_AbyssAngelEncounter_Sign", ResourceLoader.LoadSprite("ClioneWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Clione.Med, "Salt_AbyssAngelEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ClioneSong";
            med.RoarEvent = "event:/Hawthorne/Misc/Water";

            med.AddRandomEncounter("Clione_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("Clione_EN", Enemies.Mungling);
            med.AddRandomEncounter("Cione_EN", "Flarblet_EN", "Flarblet_EN", "LostSheep_EN");
            med.SimpleAddEncounter(1, "Clione_EN", 3, "Keko_EN");
            med.AddRandomEncounter("Clione_EN", Jumble.Red, "MudLung_EN");
            med.AddRandomEncounter("Clione_EN", "Windle_EN", "LostSheep_EN");
            med.AddRandomEncounter("Clione_EN", Jumble.Yellow, Jumble.Red);
            med.AddRandomEncounter("Clione_EN", "Skyloft_EN", Enemies.Mungling);
            med.SimpleAddEncounter(1, "Clione_EN", 3, "Mung_EN");
            med.AddRandomEncounter("Clione_EN", "DeadPixel_EN", "DeadPixel_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Clione.Med, 12, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Clione.Hard, "Salt_AbyssAngelEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/ClioneSong";
            hard.RoarEvent = "event:/Hawthorne/Misc/Water";



            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Clione.Hard, 20, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
