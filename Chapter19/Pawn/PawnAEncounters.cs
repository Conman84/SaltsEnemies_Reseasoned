using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PawnAEncounters
    {
        public static void Add()
        {
            Add_Easy();
            Add_Med();
        }
        public static void Add_Easy()
        {
            Portals.AddPortalSign("Salt_PawnAEncounter_Sign", ResourceLoader.LoadSprite("PawnWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.Pawn.Easy, "Salt_PawnAEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/PawnSong";
            easy.RoarEvent = "event:/Hawthorne/Noi3e/PawnRoar";

            easy.SimpleAddEncounter(3, "PawnA_EN");
            easy.SimpleAddEncounter(3, "PawnA_EN", 1, "BlackStar_EN");
            easy.SimpleAddEncounter(3, "PawnA_EN", 1, "GlassFigurine_EN");
            easy.SimpleAddEncounter(3, "PawnA_EN", 1, "TortureMeNot_EN");
            easy.SimpleAddEncounter(3, "PawnA_EN", 1, "Damocles_EN");
            easy.SimpleAddEncounter(2, "PawnA_EN", 1, "Indicator_EN");

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Pawn.Easy, 10 * April.Mod, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Add_Med()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Pawn.Med, "Salt_PawnAEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PawnSong";
            med.RoarEvent = "event:/Hawthorne/Noi3e/PawnRoar";

            med.SimpleAddEncounter(4, "PawnA_EN");
            med.SimpleAddEncounter(5, "PawnA_EN");
            med.SimpleAddEncounter(4, "PawnA_EN", 1, "BlackStar_EN");
            med.SimpleAddEncounter(4, "PawnA_EN", 1, "GlassFigurine_EN");
            med.SimpleAddEncounter(4, "PawnA_EN", 1, "TortureMeNot_EN");
            med.SimpleAddEncounter(4, "PawnA_EN", 1, "Damocles_EN");
            med.SimpleAddEncounter(2, "PawnA_EN", 3, "Damocles_EN");
            med.SimpleAddEncounter(3, "PawnA_EN", 1, "Indicator_EN");
            med.SimpleAddEncounter(3, "PawnA_EN", 1, "Grandfather_EN");
            med.SimpleAddEncounter(3, "PawnA_EN", 1, "MiniReaper_EN");
            med.SimpleAddEncounter(3, "PawnA_EN", 1, "WindSong_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Pawn.Med, 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, "PawnA_EN", "InHisImage_EN", "InHisImage_EN");
            med.SimpleAddGroup(1, Jumble.Grey, 3, "PawnA_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "PawnA_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup(Spoggle.Grey, "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            med.SimpleAddGroup(1, Spoggle.Grey, 3, "PawnA_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.SimpleAddGroup(1, "Satyr_EN", 3, "PawnA_EN");
            med.AddRandomGroup("Satyr_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Satyr_EN", "PawnA_EN", "PawnA_EN", "ChoirBoy_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "PawnA_EN", "PawnA_EN", "Hunter_EN");
            hard.AddRandomGroup("Satyr_EN", "Stoplight_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Satyr_EN", "PawnA_EN", "PawnA_EN", Flower.Grey);

            AddTo easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, "PawnA_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Flower.Blue, "PawnA_EN", "InHisImage_EN", "InHisImage_EN");

            easy = new AddTo(Garden.H.Flower.Red.Easy);
            easy.AddRandomGroup(Flower.Red, Flower.Blue, "PawnA_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Red, Flower.Blue, "PawnA_EN", "PawnA_EN");
            med.AddRandomGroup(Flower.Red, "PawnA_EN", "InHerImage_EN", "InHerImage_EN");

            med = new AddTo(Garden.H.Flower.Grey.Med);
            med.AddRandomGroup(Flower.Grey, "PawnA_EN", "InHisImage_EN", "InHerImage_EN");
            med.SimpleAddGroup(1, Flower.Grey, 3, "PawnA_EN");
            med.AddRandomGroup(Flower.Grey, "PawnA_EN", "PawnA_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Yellow, "PawnA_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Flower.Yellow, "PawnA_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Purple, "PawnA_EN");
            hard.AddRandomGroup(Flower.Grey, Flower.Blue, Flower.Purple, "PawnA_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 4, "PawnA_EN");
            hard.AddRandomGroup("ClockTower_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("ClockTower_EN", "PawnA_EN", "PawnA_EN", Enemies.Skinning);
            hard.AddRandomGroup("ClockTower_EN", "Stoplight_EN", "PawnA_EN", "BlackStar_EN");
            hard.AddRandomGroup("ClockTower_EN", "PawnA_EN", "PawnA_EN", "Eyeless_EN");

            easy = new AddTo(Garden.H.WindSong.Easy);
            easy.AddRandomGroup("WindSong_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.SimpleAddGroup(1, "Grandfather_EN", 3, "PawnA_EN");
            med.AddRandomGroup("Grandfather_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Grandfather_EN", "PawnA_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.SimpleAddGroup(1, "MiniReaper_EN", 3, "PawnA_EN");
            med.AddRandomGroup("MiniReaper_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("MiniReaper_EN", "PawnA_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomGroup("MiniReaper_EN", "PawnA_EN", "PawnA_EN", "WindSong_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup(Enemies.Tank, "Starless_EN", "PawnA_EN");

            easy = new AddTo(Garden.H.Merced.Easy);
            easy.SimpleAddGroup(1, "Merced_EN", 4, "PawnA_EN");

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "PawnA_EN", "PawnA_EN");
            easy.SimpleAddGroup(1, "Shua_EN", 3, "PawnA_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Shua_EN", "PawnA_EN", "ChoirBoy_EN");
            med.AddRandomGroup("Shua_EN", "PawnA_EN", "Starless_EN");

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "PawnA_EN", "PawnA_EN", "Firebird_EN");
            med.AddRandomGroup("Hunter_EN", "PawnA_EN", "InHisImage_EN", "InHisImage_EN");
            med.AddRandomGroup("Hunter_EN", "PawnA_EN", "PawnA_EN", Flower.Red);

            med = new AddTo(Garden.H.Firebird.Med);
            med.SimpleAddGroup(1, "Firebird_EN", 3, "PawnA_EN");
            med.AddRandomGroup("Firebird_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Firebird_EN", "PawnA_EN", "MiniReaper_EN", "Damocles_EN");
            med.AddRandomGroup("Firebird_EN", "PawnA_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "PawnA_EN");
            med.AddRandomGroup("Indicator_EN", "InHerImage_EN", "InHerImage_EN", "PawnA_EN");
            med.SimpleAddGroup(1, "Indicator_EN", 3, "PawnA_EN");

            med = new AddTo(Garden.H.YNL.Med);
            med.SimpleAddGroup(1, "YNL_EN", 3, "PawnA_EN");
            med.AddRandomGroup("YNL_EN", "InHisImage_EN", "InHisImage_EN", "PawnA_EN");
            med.AddRandomGroup("YNL_EN", Enemies.Minister, "PawnA_EN");
            med.AddRandomGroup("YNL_EN", "Starless_EN", "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.SimpleAddGroup(1, "Stoplight_EN", 3, "PawnA_EN");
            med.AddRandomGroup("Stoplight_EN", "Starless_EN", "PawnA_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            hard.AddRandomGroup("Stoplight_EN", "PawnA_EN", "PawnA_EN", "ChoirBoy_EN");
            hard.AddRandomGroup("Stoplight_EN", "PawnA_EN", "PawnA_EN", "OdeToHumanity_EN");
            hard.AddRandomGroup("Stoplight_EN", "PawnA_EN", "PawnA_EN", Flower.Grey);

            med = new AddTo(Garden.H.GreyBot.Med);
            med.SimpleAddGroup(1, Bots.Grey, 3, "PawnA_EN");
            med.AddRandomGroup(Bots.Grey, "PawnA_EN", "PawnA_EN", "MiniReaper_EN");
            med.AddRandomGroup(Bots.Grey, "PawnA_EN", "PawnA_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.SimpleAddGroup(1, "OdeToHumanity_EN", 3, "PawnA_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "PawnA_EN", "InHerImage_EN", "InHisImage_EN");
            med.AddRandomGroup("OdeToHumanity_EN", "PawnA_EN", "PawnA_EN", "Damocles_EN", "Damocles_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 4, "PawnA_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.SimpleAddGroup(1, "Complimentary_EN", 2, "PawnA_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.SimpleAddGroup(1, "Starless_EN", 3, "PawnA_EN");
            med.AddRandomGroup("Starless_EN", "PawnA_EN", "InHisImage_EN", "InHerImage_EN");
            med.AddRandomGroup("Starless_EN", "PawnA_EN", "Indicator_EN", "GlassFigurine_EN");
            med.AddRandomGroup("Starless_EN", "PawnA_EN", "PawnA_EN", "Grandfather_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.SimpleAddGroup(2, "Eyeless_EN", 2, "PawnA_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Eyeless_EN", "Starless_EN", "MiniReaper_EN", "PawnA_EN");
            hard.AddRandomGroup("Eyeless_EN", "Hunter_EN", "PawnA_EN", "PawnA_EN");
            hard.AddRandomGroup("Eyeless_EN", "Indicator_EN", "PawnA_EN", "PawnA_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "PawnA_EN");
            easy.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "PawnA_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHisImage_EN", "PawnA_EN");
            med.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "PawnA_EN");
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "InHisImage_EN", "PawnA_EN", "NextOfKin_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "PawnA_EN");
            easy.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "PawnA_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.SimpleAddGroup(3, "InHisImage_EN", 1, "PawnA_EN");
            med.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "PawnA_EN", "PawnA_EN");
            med.SimpleAddGroup(3, "InHisImage_EN", 2, "PawnA_EN");
            med.SimpleAddGroup(2, "InHisImage_EN", 3, "PawnA_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "PawnA_EN", "PawnA_EN");
            easy.AddRandomGroup("ChoirBoy_EN", "PawnA_EN", "PawnA_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.SimpleAddGroup(1, Enemies.Skinning, 3, "PawnA_EN");
            med.SimpleAddGroup(1, Enemies.Skinning, 2, "PawnA_EN", 1, Enemies.Shivering);
            med.SimpleAddGroup(1, Enemies.Skinning, 1, "PawnA_EN", 2, Enemies.Shivering);
            med.SimpleAddGroup(1, Enemies.Skinning, 2, "PawnA_EN", 1, "BlackStar_EN");
            med.SimpleAddGroup(1, Enemies.Skinning, 1, "PawnA_EN", 1, "Starless_EN");
            med.SimpleAddGroup(1, Enemies.Skinning, 1, "PawnA_EN", 1, Bots.Grey);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(2, Enemies.Skinning, 2, "PawnA_EN");
            hard.AddRandomGroup(Enemies.Skinning, "PawnA_EN", "InHerImage_EN", "InHerImage_EN");
            hard.SimpleAddGroup(1, Enemies.Skinning, 3, "PawnA_EN", 1, Enemies.Shivering);
            hard.SimpleAddGroup(1, Enemies.Skinning, 3, "PawnA_EN", 1, "Eyeless_EN");
            hard.SimpleAddGroup(1, Enemies.Skinning, 3, "PawnA_EN", 1, "Starless_EN");
            hard.SimpleAddGroup(1, Enemies.Skinning, 2, "PawnA_EN", 1, "Stoplight_EN");

            easy = new AddTo(Garden.H.Minister.Easy);
            easy.AddRandomGroup(Enemies.Minister, "PawnA_EN", "PawnA_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "PawnA_EN");
            med.SimpleAddGroup(1, Enemies.Minister, 4, "PawnA_EN");
            med.SimpleAddGroup(2, Enemies.Minister, 2, "PawnA_EN");
            med.SimpleAddGroup(1, Enemies.Minister, 2, "PawnA_EN", 1, "ChoirBoy_EN");
            med.SimpleAddGroup(1, Enemies.Minister, 2, "PawnA_EN", 1, "Starless_EN");
            med.SimpleAddGroup(1, Enemies.Minister, 2, "PawnA_EN", 1, Bots.Grey);

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.SimpleAddGroup(2, Enemies.Minister, 3, "PawnA_EN");
            hard.AddRandomGroup(Enemies.Minister, "PawnA_EN", "PawnA_EN", "ChoirBoy_EN");
            hard.AddRandomGroup(Enemies.Minister, "PawnA_EN", "PawnA_EN", "Eyeless_EN");
        }
    }
}
