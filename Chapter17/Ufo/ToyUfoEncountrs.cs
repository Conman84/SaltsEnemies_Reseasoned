using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ToyUfoEncounters
    {
        public static void Add_Normal()
        {
            Portals.AddPortalSign("Salt_ToyUFOEncounter_Sign", ResourceLoader.LoadSprite("UFOWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.Ufo.Med, "Salt_ToyUFOEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/UFOTheme";
            med.RoarEvent = "event:/Hawthorne/Roar/PixelRoar";

            med.AddRandomEncounter("ToyUfo_EN", "ToyUfo_EN", "LostSheep_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("ToyUfo_EN", "MudLung_EN", Jumble.Yellow);


            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.Ufo.Med, 25, ZoneType_GameIDs.FarShore_Easy, BundleDifficulty.Medium);
        }
    }
}
