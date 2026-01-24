using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class PapereaterEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Easy();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_PapereaterEncounter_Sign", ResourceLoader.LoadSprite("PapereaterWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Shore.H.Papereater.Med, "Salt_PapereaterEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PapereaterTheme";
            med.RoarEvent = "event:/Hawthorne/Sound2/EaterRoar";

            med.SimpleAddEncounter(2, "Papereater_EN", 1, "MudLung_EN");
            med.SimpleAddEncounter(2, "Papereater_EN", 2, "Keko_EN");
            med.AddRandomEncounter("Papereater_EN", "MudLung_EN", "Flarblet_EN");
            med.AddRandomEncounter("Papereater_EN", "Papereater_EN", Jumble.Red);
            med.SimpleAddEncounter(2, "Papereater_EN", 1, "LostSheep_EN");
            med.AddRandomEncounter("Papereater_EN", "Pinano_EN", "LostSheep_EN");
            med.AddRandomEncounter("Papereater_EN", "Wall_EN", "Papereater_EN");
            med.AddRandomEncounter("Papereater_EN", "Pinano_EN", "NobodyGrave_EN");
            med.AddRandomEncounter("Papereater_EN", "Papereater_EN", "Wringle_EN");
            med.AddRandomEncounter("Papereater_EN", "Papereater_EN", "TortureMeNot_EN", "TortureMeNot_EN");
            med.AddRandomEncounter("Papereater_EN", "Waltz_EN", "Waltz_EN");
            med.AddRandomEncounter("Papereater_EN", "Pinano_EN", "Skyloft_EN");
            med.AddRandomEncounter("Papereater_EN", "Windle_EN", "MudLung_EN");
            med.AddRandomEncounter("Papereater_EN", "Hauntling_EN", "MudLung_EN");
            med.AddRandomEncounter("Papereater_EN", "MudLung_EN", Jumble.Yellow);
            med.AddRandomEncounter("Papereater_EN", "VoiceTrumpet_EN", "Arceles_EN");


            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Papereater.Med, 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Easy()
        {
            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Papereater.Easy, "Salt_PapereaterEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/PapereaterTheme";
            easy.RoarEvent = "event:/Hawthorne/Sound2/EaterRoar";

            easy.SimpleAddEncounter(2, "Papereater_EN");
            easy.AddRandomEncounter("Papereater_EN", "MudLung_EN");
            easy.AddRandomEncounter("Papereater_EN", "Wall_EN");
            easy.AddRandomEncounter("Papereater_EN", "TortureMeNot_EN");
            easy.AddRandomEncounter("Papereater_EN", Jumble.Red);


            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Papereater.Easy, 4, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }

        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.Papereater.Easy);
            easy.AddRandomGroup("Snaurce_EN", "Papereater_EN");

            AddTo med = new AddTo(Shore.H.Papereater.Med);
            med.SimpleAddGroup(2, "Papereater_EN", 2, "Snaurce_EN");
            med.SimpleAddGroup(2, "Papereater_EN", 1, "Surimi_EN");
            med.AddRandomGroup("Papereater_EN", Jumble.Red, "Surimi_EN");
            med.SimpleAddGroup(2, "Papereater_EN", 1, "Mungman_EN");

            med = new AddTo(Shore.H.MudLung.Med);
            med.SimpleAddGroup(3, "MudLung_EN", 1, "Papereater_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Papereater_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "Papereater_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "Papereater_EN", "Pinano_EN");

            med = new AddTo(Shore.H.Spoggle.Yellow.Med);
            med.AddRandomGroup(Spoggle.Yellow, "Papereater_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, Jumble.Unstable, "Papereater_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Papereater_EN", Spoggle.Unstable);

            med = new AddTo(Shore.H.Keko.Med);
            med.SimpleAddGroup(3, "Keko_EN", 1, "Papereater_EN");

            AddTo hard = new AddTo(Shore.H.FlaMinGoa.Hard);
            hard.AddRandomGroup("FlaMinGoa_EN", "Papereater_EN", "DeadPixel_EN", "DeadPixel_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Papereater_EN", "Papereater_EN");
            hard.AddRandomGroup("Flarb_EN", "Papereater_EN", "Flarblet_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Papereater_EN");

            hard = new AddTo(Shore.H.Kekastle.Hard);
            hard.AddRandomGroup("Kekastle_EN", "Papereater_EN", "LostSheep_EN");

            med = new AddTo(Shore.H.DeadPixel.Med);
            med.SimpleAddGroup(2, "DeadPixel_EN", 1, "Papereater_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup("TeachaMantoFish_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Papereater_EN", "MudLung_EN", "NobodyGrave_EN");

            hard = new AddTo(Shore.H.Angler.Hard);
            hard.AddRandomGroup("AFlower_EN", "Papereater_EN", Jumble.Unstable, Jumble.Yellow);

            hard = new AddTo(Shore.H.Camera.Hard);
            hard.AddRandomGroup(Enemies.Camera, "Papereater_EN", "LittleBeak_EN", "Papereater_EN");

            hard = new AddTo(Shore.H.Tripod.Hard);
            hard.AddRandomGroup("Tripod_EN", "Papereater_EN", "Papereater_EN", Jumble.Red);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "Papereater_EN", "Papereater_EN");
            med.AddRandomGroup("LittleBeak_EN", "Papereater_EN", "Surimi_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Papereater_EN", "MudLung_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Papereater_EN", Jumble.Red);

            hard = new AddTo(Shore.H.Clione.Hard);
            hard.AddRandomGroup("Clione_EN", "Papereater_EN", "ToyUfo_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Papereater_EN", "Pinano_EN");
            med.AddRandomGroup("Pinano_EN", "Papereater_EN", "Wall_EN");

            med = new AddTo(Shore.H.Ufo.Med);
            med.AddRandomGroup("ToyUfo_EN", "Papereater_EN", "Papereater_EN");
            med.AddRandomGroup("ToyUfo_EN", "Papereater_EN", "2009_EN");

            med = new AddTo(Shore.H.Sinker.Med);
            med.AddRandomGroup("Sinker_EN", "Papereater_EN", "Windle_EN");

            hard = new AddTo(Shore.H.Sinker.Hard);
            hard.AddRandomGroup("Sinker_EN", "Papereater_EN", "Papereater_EN", "VoiceTrumpet_EN");

            med = new AddTo(Shore.H.TwoThousandNine.Med);
            med.AddRandomGroup("2009_EN", "Papereater_EN", "Waltz_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Chiito.Med);
            med.AddRandomGroup("Chiito_EN", "Papereater_EN", "Papereater_EN", "Asterism_EN");

            med = new AddTo(Shore.H.Wall.Med);
            med.AddRandomGroup("Wall_EN", "Wall_EN", "Papereater_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Amalga.Hard);
            hard.AddRandomGroup("33_EN", "Papereater_EN", "Papereater_EN", "Papereater_EN");

            hard = new AddTo(Shore.H.Clown.Hard);
            hard.AddRandomGroup("Clown_EN", "Papereater_EN", "Waltz_EN");

            med = new AddTo(Shore.H.Trumpet.Med);
            med.SimpleAddGroup(2, "VoiceTrumpet_EN", 1, "Papereater_EN");

            med = new AddTo(Shore.H.Jabber.Med);
            med.AddRandomGroup("Jabberwocky_EN", "Papereater_EN", "Pinano_EN");

            med = new AddTo(Shore.H.Flakkid.Med);
            med.AddRandomGroup("Flakkid_EN", "Flakkid_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Swine.Med);
            med.AddRandomGroup(Enemies.Swine, Enemies.Swine, "Papereater_EN");

            med = new AddTo(Shore.H.Pipe.Med);
            med.AddRandomGroup("NotAn_EN", "Papereater_EN", "Squirmer_EN");

            med = new AddTo(Shore.H.Bait.Med);
            med.AddRandomGroup("DryBait_EN", "Papereater_EN", "Papereater_EN");

            hard = new AddTo(Shore.H.Bait.Hard);
            hard.AddRandomGroup("DryBait_EN", "Papereater_EN", "Surimi_EN", "Surimi_EN");
            hard.AddRandomGroup("DryBait_EN", "SandSifter_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Snaurce.Med);
            med.AddRandomGroup("Papereater_EN", "Snaurce_EN", "Snaurce_EN");

            med = new AddTo(Shore.H.Surimi.Med);
            med.AddRandomGroup("Surimi_EN", "Surimi_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Mungman.Med);
            med.AddRandomGroup("Mungman_EN", "Mungman_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Digger.Med);
            med.AddRandomGroup("Digger_EN", "Papereater_EN", "DeadPixel_EN", "DeadPixel_EN");

            med = new AddTo(Shore.H.Squirmer.Med);
            med.AddRandomGroup("Squirmer_EN", "Squirmer_EN", "Papereater_EN");

            med = new AddTo(Shore.H.Wailer.Med);
            med.AddRandomGroup("Wailer_EN", "Papereater_EN", Jumble.Red, Jumble.Yellow);

            med = new AddTo(Shore.H.Asterism.Med);
            med.SimpleAddGroup(2, "Asterism_EN", 1, "Papereater_EN");

        }
    }
}
