using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WarbirdEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WarbirdEncounter_Sign", ResourceLoader.LoadSprite("ScarecrowWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Warbird.Hard, "Salt_WarbirdEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/WarbirdTheme";
            hard.RoarEvent = "event:/Hawthorne/Roar/HunterRoar";

            hard.AddRandomEncounter("Warbird_EN", Jumble.Red, Jumble.Yellow, "LittleBeak_EN");
            hard.AddRandomEncounter("Warbird_EN", Spoggle.Blue, Spoggle.Yellow, "LostSheep_EN");
            hard.AddRandomEncounter("Warbird_EN", "FlaMinGoa_EN", Enemies.Mungling);
            hard.AddRandomEncounter("Warbird_EN", "FlaMinGoa_EN", "LittleBeak_EN");
            hard.AddRandomEncounter("Warbird_EN", "FlaMinGoa_EN", "AFlower_EN");
            hard.AddRandomEncounter("Warbird_EN", "AFlower_EN", Enemies.Mungling);
            hard.AddRandomEncounter("Warbird_EN", "AFlower_EN", "LittleBeak_EN");
            hard.AddRandomEncounter("Warbird_EN", "LittleBeak_EN", Enemies.Mungling);
            hard.SimpleAddEncounter(1, "Warbird_EN", 4, "Keko_EN");
            hard.SimpleAddEncounter(1, "Warbird_EN", 4, "LostSheep_EN");
            hard.AddRandomEncounter("Warbird_EN", "DeadPixel_EN", "DeadPixel_EN", "MudLung_EN");
            hard.AddRandomEncounter("Warbird_EN", "DeadPixel_EN", "DeadPixel_EN", Jumble.Red);
            hard.AddRandomEncounter("Warbird_EN", "Skyloft_EN", "AFlower_EN");
            hard.AddRandomEncounter("Warbird_EN", "Skyloft_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("Warbird_EN", Enemies.Mungling, Enemies.Mungling);
            hard.AddRandomEncounter("Warbird_EN", "LittleBeak_EN", "LittleBeak_EN");
            hard.AddRandomEncounter("Warbird_EN", "LittleBeak_EN", Spoggle.Yellow);
            hard.AddRandomEncounter("Warbird_EN", "LittleBeak_EN", Spoggle.Blue);
            hard.AddRandomEncounter("Warbird_EN", "FlaMinGoa_EN", Spoggle.Yellow);
            hard.AddRandomEncounter("Warbird_EN", "FlaMinGoa_EN", Spoggle.Blue);
            hard.AddRandomEncounter("Warbird_EN", "FlaMinGoa_EN", Enemies.Camera);
            hard.AddRandomEncounter("Warbird_EN", "AFlower_EN", Enemies.Camera);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Warbird.Hard, 20, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Warbird_EN", "FlaMinGoa_EN");
            hard.AddRandomGroup(Enemies.Camera, "Warbird_EN", "AFlower_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Warbird_EN", "LostSheep_EN", "LostSheep_EN");
            hard.AddRandomGroup("Tripod_EN", "Warbird_EN", Jumble.Red, Jumble.Yellow);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Warbird_EN");
            hard.AddRandomGroup("Flarb_EN", "Warbird_EN", "Flarblet_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Warbird_EN");
            hard.AddRandomGroup("Voboola_EN", "Warbird_EN", "Flarblet_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "Warbird_EN");
        }
    }
}
