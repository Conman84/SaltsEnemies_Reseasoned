using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class JabberwockyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_JabberEncounter_Sign", ResourceLoader.LoadSprite("JabberWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Jabber.Med, "Salt_JabberEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/JabberwockyTheme";
            med.RoarEvent = "event:/Hawthorne/Soisenay/IndicatorDie";

            med.SimpleAddEncounter(2, "Jabberwocky_EN", 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "Wall_EN", 1, "Jabberwocky_EN");
            med.AddRandomEncounter("ToyUfo_EN", "Flarblet_EN", "Jabberwocky_EN");
            med.AddRandomEncounter("Jabberwocky_EN", Jumble.Red, Jumble.Yellow);
            med.AddRandomEncounter("Jabberwocky_EN", Spoggle.Blue, "MudLung_EN");
            med.AddRandomEncounter("Jabberwocky_EN", Spoggle.Yellow, "MudLung_EN");
            med.SimpleAddEncounter(3, "Keko_EN", 1, "Jabberwocky_EN");
            med.SimpleAddEncounter(2, "Jabberwocky_EN", 1, "NobodyGrave_EN");
            med.AddRandomEncounter("Jabberwocky_EN", "Wringle_EN", "Skyloft_EN");
            med.SimpleAddEncounter(2, "DeadPixel_EN", 1, "Jabberwocky_EN");
            med.AddRandomEncounter("Jabberwocky_EN", "Arceles_EN", "MudLung_EN", "MudLung_EN");
            med.AddRandomEncounter("Jabberwocky_EN", "Windle_EN", "2009_EN");
            med.SimpleAddEncounter(2, "Waltz_EN", 1, "Jabberwocky_EN");
            med.AddRandomEncounter("Jabberwocky_EN", "Hauntling_EN", "MudLung_EN");
            med.SimpleAddEncounter(2, "Pinano_EN", 1, "Jabberwocky_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Jabber.Med, 15 * April.Mod, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "Jabberwocky_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Jabberwocky_EN", Jumble.Yellow);

            AddTo hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "Jabberwocky_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Jabberwocky_EN", "Flarb_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Jabberwocky_EN", "Voboola_EN");

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Jabberwocky_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Jabberwocky_EN", "Chiito_EN", Spoggle.Yellow);

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Jabberwocky_EN", "Flarblet_EN", "Flarblet_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Jabberwocky_EN", "Sinker_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Jabberwocky_EN", "Pinano_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Jabberwocky_EN", Spoggle.Unstable);

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "Jabberwocky_EN", "2009_EN");

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Jabberwocky_EN", "LittleBeak_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Jabberwocky_EN", "Warbird_EN", "Jabberwocky_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Jabberwocky_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Jabberwocky_EN", Jumble.Unstable);

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Jabberwocky_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "Jabberwocky_EN", "Wall_EN", "Wall_EN");

            med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "Jabberwocky_EN", Enemies.Mungling);

            hard = new AddTo(Shore.H.Bait.Hard);
            hard.AddRandomGroup("DryBait_EN", "Jabberwocky_EN", "Waltz_EN", "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "Jabberwocky_EN", "Goa_ENs");

            med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "Jabberwocky_EN");

            hard = new AddTo(Shore.H.Wailer.Hard);
            hard.AddRandomGroup("Wailer_EN", "Jabberwocky_EN", "Pinano_EN");
        }
    }
}
