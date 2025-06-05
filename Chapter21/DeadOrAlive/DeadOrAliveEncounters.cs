using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class DeadOrAliveEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_DeadOrAliveEncounter_Sign", ResourceLoader.LoadSprite("CorpseWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Shore.H.Clown.Hard, "Salt_DeadOrAliveEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/ClownSong";
            hard.RoarEvent = LoadedAssetsHandler.GetEnemy("Derogatory_EN").deathSound;

            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Waltz_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Flarblet_EN", "Flarblet_EN");
            hard.AddRandomEncounter("Clown_EN", "Flarblet_EN", "Flarblet_EN", "Flarblet_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Waltz_EN", "LostSheep_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Waltz_EN", "NobodyGrave_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Waltz_EN", "Skyloft_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Waltz_EN", "TortureMeNot_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomEncounter("Clown_EN", "DeadPixel_EN", "DeadPixel_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "MudLung_EN");
            hard.AddRandomEncounter("Clown_EN", "MudLung_EN", "MudLung_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", Jumble.Red);
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", Jumble.Yellow);
            hard.AddRandomEncounter("Clown_EN", Jumble.Red, Jumble.Yellow);
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", Spoggle.Yellow);
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", Spoggle.Blue);
            hard.AddRandomEncounter("Clown_EN", Spoggle.Yellow, Spoggle.Blue);
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", Enemies.Mungling);
            hard.AddRandomEncounter("Clown_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "FlaMinGoa_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Keko_EN", "Keko_EN");
            hard.AddRandomEncounter("Clown_EN", "AFlower_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Pinano_EN");
            hard.AddRandomEncounter("Clown_EN", "Pinano_EN", "Pinano_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "ToyUfo_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Wall_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Wringle_EN");
            hard.AddRandomEncounter("Clown_EN", Enemies.Camera);
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", Enemies.Camera);
            hard.AddRandomEncounter("Clown_EN", "LittleBeak_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "LittleBeak_EN");
            hard.AddRandomEncounter("Clown_EN", "Clione_EN");
            hard.AddRandomEncounter("Clown_EN", "Warbird_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Windle_EN");
            hard.AddRandomEncounter("Clown_EN", "Sinker_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "Sinker_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "2009_EN");
            hard.AddRandomEncounter("Clown_EN", "Waltz_EN", "VoiceTrumpet_EN");
            hard.AddRandomEncounter("Clown_EN", "VoiceTrumpet_EN", "VoiceTrumpet_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Clown.Hard, 20, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Clown_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Clown_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Clown_EN");
        }
    }
}
