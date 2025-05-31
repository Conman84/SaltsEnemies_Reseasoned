using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class TortureMeNotEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_CrueltiesEncounter_Sign", ResourceLoader.LoadSprite("ForgetPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Garden.H.TortureMeNot.Hard, "Salt_CrueltiesEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/CrueltiesSong";
            hard.RoarEvent = "";

            hard.AddRandomEncounter("Cruelties1_EN", "Cruelties2_EN", "Cruelties3_EN", "Cruelties4_EN", "Cruelties5_EN");

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.TortureMeNot.Hard, 1, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {
            AddTo easy = new AddTo(Shore.H.DeadPixel.Easy);
            easy.AddRandomGroup("DeadPixel_EN", "DeadPixel_EN", "TortureMeNot_EN");

            AddTo med = new AddTo(Shore.H.Angler.Med);
            med.AddRandomGroup("AFlower_EN", "MudLung_EN", "TortureMeNot_EN");

            AddTo hard = new AddTo(Shore.H.Camera.Hard);
            hard.SimpleAddGroup(1, Enemies.Camera, 3, "TortureMeNot_EN");

            hard = new AddTo(Shore.H.Warbird.Hard);
            hard.AddRandomGroup("Warbird_EN", "FlaMinGoa_EN", "TortureMeNot_EN");

            med = new AddTo(Shore.H.Pinano.Med);
            med.AddRandomGroup("Pinano_EN", "Pinano_EN", "TortureMeNot_EN");

            hard = new AddTo(Shore.H.Unmung.Hard);
            hard.AddRandomGroup(Enemies.Unmung, "TortureMeNot_EN");

            easy = new AddTo(Shore.H.Mungling.Easy);
            easy.AddRandomGroup(Enemies.Mungling, "Mung_EN", "TortureMeNot_EN");

            med = new AddTo(Shore.H.Jumble.Yellow.Med);
            med.AddRandomGroup(Jumble.Yellow, Jumble.Red, "TortureMeNot_EN", "TortureMeNot_EN");

            easy = new AddTo(Shore.H.Keko.Easy);
            easy.SimpleAddGroup(3, "Keko_EN", 1, "TortureMeNot_EN");

            hard = new AddTo(Shore.H.Voboola.Hard);
            hard.AddRandomGroup("Voboola_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            med = new AddTo(Orph.H.Enigma.Med);
            med.SimpleAddGroup(4, "Enigma_EN", 1, "TortureMeNot_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            med.AddRandomGroup("TheCrow_EN", "Something_EN", "TortureMeNot_EN");

            easy = new AddTo(Orph.H.Delusion.Easy);
            easy.SimpleAddGroup(2, "Delusion_EN", 2, "TortureMeNot_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            med.AddRandomGroup(Flower.Purple, Flower.Yellow, "TortureMeNot_EN");

            med = new AddTo(Orph.H.WindSong.Med);
            med.AddRandomGroup("WindSong_EN", "Scrungie_EN", "Scrungie_EN", "TortureMeNot_EN");

            med = new AddTo(Orph.H.Maw.Med);
            med.AddRandomGroup("Maw_EN", "Delusion_EN", "Delusion_EN", "TortureMeNot_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Crystal_EN", "TortureMeNot_EN");

            easy = new AddTo(Orph.H.MusicMan.Easy);
            easy.SimpleAddGroup(3, "MusicMan_EN", 1, "TortureMeNot_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            med.AddRandomGroup(Jumble.Purple, Jumble.Blue, "TortureMeNot_EN");

            hard = new AddTo(Orph.H.Sacrifice.Hard);
            hard.SimpleAddGroup(2, Enemies.Sacrifice, 3, "TortureMeNot_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", Bots.Yellow, "TortureMeNot_EN");

            med = new AddTo(Garden.H.Jumble.Grey.Med);
            med.SimpleAddGroup(1, Jumble.Grey, 1, Enemies.Minister, 3, "TortureMeNot_EN");

            easy = new AddTo(Garden.H.Flower.Blue.Easy);
            easy.AddRandomGroup(Flower.Blue, Flower.Red, "TortureMeNot_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.SimpleAddGroup(1, "ClockTower_EN", 1, Enemies.Skinning, 3, "TortureMeNot_EN");

            med = new AddTo(Garden.H.Grandfather.Med);
            med.AddRandomGroup("Grandfather_EN", "InHerImage_EN", "InHerImage_EN", "TortureMeNot_EN");

            easy = new AddTo(Garden.H.EyePalm.Easy);
            easy.SimpleAddGroup(3, "EyePalm_EN", 1, "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.SimpleAddGroup(1, Enemies.Tank, 3, "TortureMeNot_EN");

            easy = new AddTo(Garden.H.Merced.Easy);
            easy.SimpleAddGroup(1, "Merced_EN", 3, "TortureMeNot_EN", 1, "BlackStar_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Hunter_EN", "WindSong_EN", "TortureMeNot_EN");

            easy = new AddTo(Garden.H.GlassFigurine.Easy);
            easy.SimpleAddGroup(1, "GlassFigurine_EN", 4, "TortureMeNot_EN");

            med = new AddTo(Garden.H.Indicator.Med);
            med.AddRandomGroup("Indicator_EN", "InHisImage_EN", "InHisImage_EN", "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "ChoirBoy_EN", "ChoirBoy_EN", "TortureMeNot_EN");

            med = new AddTo(Garden.H.GreyBot.Med);
            med.AddRandomGroup(Bots.Grey, "MiniReaper_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(4, "GlassedSun_EN", 1, "TortureMeNot_EN");
            hard.SimpleAddGroup(3, "GlassedSun_EN", 2, "TortureMeNot_EN");
            hard.SimpleAddGroup(2, "GlassedSun_EN", 3, "TortureMeNot_EN");

            easy = new AddTo(Garden.H.InHerImage.Easy);
            easy.SimpleAddGroup(2, "InHerImage_EN", 3, "TortureMeNot_EN");

            easy = new AddTo(Garden.H.ChoirBoy.Easy);
            easy.SimpleAddGroup(1, "ChoirBoy_EN", 4, "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.SimpleAddGroup(2, Enemies.Skinning, 3, "TortureMeNot_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, Enemies.Minister, "EyePalm_EN", "TortureMeNot_EN");
        }
    }
}
