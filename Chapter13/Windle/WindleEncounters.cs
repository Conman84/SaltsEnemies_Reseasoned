using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WindleEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WindleEncounter_Sign", ResourceLoader.LoadSprite("WindleWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Shore.H.Windle.Easy, "Salt_WindleEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/WindleSong";
            easy.RoarEvent = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound;

            easy.AddRandomEncounter("Windle_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "Mung_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "LostSheep_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "Skyloft_EN");
            easy.AddRandomEncounter("Windle_EN", "MudLung_EN", "MudLung_EN");
            easy.AddRandomEncounter("Windle_EN", "Mung_EN", "Mung_EN");
            easy.AddRandomEncounter("Windle_EN", "Wringle_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Shore.H.Windle.Easy, 4, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "Windle_EN");

            AddTo med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "Windle_EN", Enemies.Mungling);

            med = new AddTo(Shore.H.LittleBeak.Med);
            med.AddRandomGroup("LittleBeak_EN", "LittleBeak_EN", "Windle_EN");

            AddTo hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "Windle_EN");

            easy = new AddTo(Shore.H.Keko.Easy);
            easy.AddRandomGroup("Keko_EN", "Keko_EN", "Windle_EN");

            easy = new AddTo(Shore.H.MudLung.Easy);
            easy.AddRandomGroup("MudLung_EN", "MudLung_EN", "Windle_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "Mung_EN", "Windle_EN");

            med = new AddTo(Shore.H.Jumble.Red.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Jumble.Red, "MudLung_EN", "Windle_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Jumble.Yellow, "MudLung_EN", "Windle_EN");

            med = new AddTo(Shore.H.FlaMinGoa.Med);
            med.AddRandomGroup("FlaMinGoa_EN", "Windle_EN", Jumble.Yellow);

            hard = new AddTo(Shore.H.Flarb.Hard);
            hard.AddRandomGroup("Flarb_EN", "Windle_EN");

            hard = new AddTo(Shore.H.Jumble.Blue.Hard);
            if (SaltsReseasoned.rando == 5) hard.AddRandomGroup(Jumble.Blue, Jumble.Purple, "Windle_EN");

            hard = new AddTo(Shore.H.Jumble.Purple.Hard);
            if (SaltsReseasoned.rando == 6) hard.AddRandomGroup(Jumble.Purple, Jumble.Blue, "Windle_EN");

            hard = new AddTo(Shore.H.Spoggle.Red.Hard);
            if (SaltsReseasoned.rando == 7) hard.AddRandomGroup(Spoggle.Red, Spoggle.Purple, "Windle_EN");

            hard = new AddTo(Shore.H.Spoggle.Purple.Hard);
            if (SaltsReseasoned.rando == 8) hard.AddRandomGroup(Spoggle.Purple, Spoggle.Red, "Windle_EN");

        }
    }
}
