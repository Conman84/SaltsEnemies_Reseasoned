using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ArcelesEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ArcelesEncounter_Sign", ResourceLoader.LoadSprite("ArcelesWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Arceles.Easy, "Salt_ArcelesEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/NewBoatSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.AddRandomEncounter("Arceles_EN");
            easy.SimpleAddEncounter(1, "Arceles_EN", 3, "Flarblet_EN");
            easy.SimpleAddEncounter(1, "Arceles_EN", 3, "Mung_EN");
            easy.SimpleAddEncounter(1, "Arceles_EN", 3, "Goa_EN");
            easy.SimpleAddEncounter(1, "Arceles_EN", 3, "LostSheep_EN");
            easy.SimpleAddEncounter(2, "Arceles_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Arceles.Easy, 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Arceles_EN");

            easy = new AddTo(Shore.H.Skyloft.Easy);
            easy.AddRandomGroup("Skyloft_EN", "Arceles_EN", "MudLung_EN");

            AddTo med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", Enemies.Mungling, "Arceles_EN");

            AddTo hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "Arceles_EN", Jumble.Yellow, Jumble.Red);

            easy = new AddTo(Shore.H.Windle.Easy);
            easy.AddRandomGroup("Windle_EN", "Arceles_EN", "MudLung_EN");

            med = new AddTo(Shore.H.Clione.Med);
            med.AddRandomGroup("Clione_EN", "Arceles_EN", "FlaMinGoa_EN");

            easy = new AddTo(Shore.H.MudLung.Easy);
            easy.AddRandomGroup("MudLung_EN", "MudLung_EN", "Arceles_EN");

            med = new AddTo(Shore.H.MudLung.Med);
            med.SimpleAddGroup(3, "MudLung_EN", 1, "Arceles_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "Arceles_EN");

            med = new AddTo(Shore.H.Mungling.Med);
            med.AddRandomGroup(Enemies.Mungling, "MudLung_EN", "Arceles_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, "MudLung_EN", "MudLung_EN", "Arceles_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            med.AddRandomGroup(Jumble.Red, Jumble.Yellow, "Arceles_EN");

            med = new AddTo(Shore.H.Spoggle.Blue.Med);
            med.AddRandomGroup(Spoggle.Blue, "MudLung_EN", "Arceles_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "LittleBeak_EN", "Arceles_EN");

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Arceles_EN", "Skyloft_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "Arceles_EN", "Arceles_EN");
        }
    }
}
