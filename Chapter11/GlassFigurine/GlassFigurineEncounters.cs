using BrutalAPI;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class GlassFigurineEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_GlassFigurineEncounter_Sign", ResourceLoader.LoadSprite("GlassPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API easy = new EnemyEncounter_API(EncounterType.Random, Garden.H.GlassFigurine.Easy, "Salt_GlassFigurineEncounter_Sign");
            easy.MusicEvent = "event:/Hawthorne/GlassSong";
            easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent;

            easy.SimpleAddEncounter(1, "GlassFigurine_EN", 3, "NextOfKin_EN");
            easy.SimpleAddEncounter(1, "GlassFigurine_EN", 2, Enemies.Shivering);
            easy.AddRandomEncounter("GlassFigurine_EN", Flower.Purple, Flower.Yellow);

            easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.GlassFigurine.Easy, 4, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Garden.H.LittleAngel.Easy);
            easy.AddRandomGroup("LittleAngel_EN", "GlassFigurine_EN", "GlassFigurine_EN");

            AddTo med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.AddRandomGroup(Jumble.Grey, Enemies.Minister, "GlassFigurine_EN");

            med = new AddTo(Garden.H.Spoggle.Grey.Med);
            med.AddRandomGroup(Spoggle.Grey, "InHisImage_EN", "InHisImage_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "GlassFigurine_EN", "Damocles_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "GlassFigurine_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Flower.Blue.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, "GlassFigurine_EN");

            med = new AddTo(Garden.H.Flower.Red.Med);
            med.AddRandomGroup(Flower.Blue, Flower.Red, "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, "GlassFigurine_EN");

            med = new AddTo(Garden.H.Camera.Med);
            med.SimpleAddGroup(3, Enemies.Camera, 1, "GlassFigurine_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "GlassFigurine_EN", Enemies.Skinning);

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.MiniReaper.Med);
            med.AddRandomGroup("MiniReaper_EN", "InHisImage_EN", "InHerImage_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.EyePalm.Med);
            med.SimpleAddGroup(4, "EyePalm_EN", 1, "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "GlassFigurine_EN", "EyePalm_EN");

            easy = new AddTo(Garden.H.Shua.Easy);
            easy.AddRandomGroup("Shua_EN", "EyePalm_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "ChoirBoy_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "GlassFigurine_EN", "EyePalm_EN", "EyePalm_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.AddRandomGroup("InHerImage_EN", "InHisImage_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.InHerImage.Med);
            med.AddRandomGroup("InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN", "NextOfKin_EN");

            easy = new AddTo(Garden.H.InHisImage.Easy);
            easy.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "GlassFigurine_EN");

            med = new AddTo(Garden.H.InHisImage.Med);
            med.AddRandomGroup("InHisImage_EN", "InHisImage_EN", "GlassFigurine_EN", "NextOfKin_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.AddRandomGroup("ChoirBoy_EN", "GlassFigurine_EN", Enemies.Shivering);

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, Enemies.Shivering, "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Skinning, "GlassFigurine_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.SimpleAddGroup(2, Enemies.Minister, 1, "GlassFigurine_EN");
            med.AddRandomGroup(Enemies.Minister, "InHerImage_EN", "InHerImage_EN", "GlassFigurine_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "ChoirBoy_EN", "GlassFigurine_EN");
        }
    }
}
