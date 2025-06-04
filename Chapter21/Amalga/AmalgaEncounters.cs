using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AmalgaEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_AmalgaEncounter_Sign", ResourceLoader.LoadSprite("WallWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Amalga.Hard, "Salt_AmalgaEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/WallTheme";
            hard.RoarEvent = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            hard.SimpleAddEncounter(2, "33_EN");
            hard.SimpleAddEncounter(1, "33_EN", 3, "Wall_EN");
            hard.AddRandomEncounter("33_EN", "MudLung_EN", "MudLung_EN", "LostSheep_EN");
            hard.AddRandomEncounter("33_EN", "Wall_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("33_EN", "Wall_EN", "AFlower_EN");
            hard.AddRandomEncounter("33_EN", Spoggle.Blue, Spoggle.Yellow);
            hard.AddRandomEncounter("33_EN", "ToyUfo_EN", "Wall_EN", "Skyloft_EN");
            hard.AddRandomEncounter("33_EN", "2009_EN", "Sinker_EN");
            hard.AddRandomEncounter("33_EN", Jumble.Yellow, "Pinano_EN", "Pinano_EN");
            hard.AddRandomEncounter("33_EN", Jumble.Red, Enemies.Mungling);
            hard.AddRandomEncounter("33_EN", "NobodyGrave_EN", "Wall_EN", "Wall_EN");
            hard.AddRandomEncounter("33_EN", "Clione_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomEncounter("33_EN", Enemies.Camera, Enemies.Camera, "LostSheep_EN");
            hard.AddRandomEncounter("33_EN", "Windle_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("33_EN", "ToyUfo_EN", Jumble.Yellow);
            hard.AddRandomEncounter("33_EN", "Sinker_EN", "ToyUfo_EN");
            hard.AddRandomEncounter("33_EN", "2009_EN", "LittleBeak_EN");
            hard.AddRandomEncounter("33_EN", "LittleBeak_EN", Jumble.Yellow, "Skyloft_EN");
            hard.AddRandomEncounter("33_EN", "Wringle_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomEncounter("33_EN", "Clione_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("33_EN", Enemies.Mungling, "MudLung_EN", "MudLung_EN");
            hard.SimpleAddEncounter(1, "33_EN", 4, "Keko_EN");
            hard.AddRandomEncounter("33_EN", Enemies.Camera, Spoggle.Blue);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Amalga.Hard, 5 * April.Mod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
