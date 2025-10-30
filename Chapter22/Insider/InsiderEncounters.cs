using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class InsiderEncounters
    {
        public static void Add()
        {
            Add_Orph();
            Add_Garden();
        }
        public static void Add_Orph()
        {
            Portals.AddPortalSign("Salt_InsiderEncounter_Sign", ResourceLoader.LoadSprite("InsiderWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Insider.Med, "Salt_InsiderEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/InsiderSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.SimpleAddEncounter(2, "Insider_EN", 1, "MusicMan_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, Spoggle.Red);
            med.SimpleAddEncounter(2, "Insider_EN", 1, "Scrungie_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 3, "SingingStone_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, "Scrungie_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, Bots.Red);
            med.SimpleAddEncounter(2, "Insider_EN", 2, "Enigma_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, Enemies.Shooter, 1, "LostSheep_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, "Something_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, Enemies.Solvent);
            med.SimpleAddEncounter(2, "Insider_EN", 2, "Spectre_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 1, "Solitaire_EN");
            med.SimpleAddEncounter(2, "Insider_EN", 3, "TortureMeNot_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Insider.Med, April.Me && !April.Birthday ? 15 : April.LessMod * 3, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Garden()
        {
            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.Insider.Med, "Salt_InsiderEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/InsiderSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.SimpleAddEncounter(4, "Insider_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Insider.Med, April.Me && !April.Birthday ? 10 : April.LessMod * 2, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Evileye.Med);
            med.AddRandomGroup("Evileye_EN", "Insider_EN", "SingingStone_EN", "SingingStone_EN", "SingingStone_EN");

            med = new AddTo(Orph.H.Crystal.Med);
            med.AddRandomGroup("Crystal_EN", "Insider_EN", "Scrungie_EN");

            AddTo hard = new AddTo(Orph.H.Revola.Hard);
            hard.AddRandomGroup("Revola_EN", "Insider_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            hard.AddRandomGroup("Conductor_EN", "MusicMan_EN", "Insider_EN");

            med = new AddTo(Orph.H.YellowAngel.Med);
            med.AddRandomGroup("YellowAngel_EN", "Insider_EN", "MusicMan_EN");

            hard = new AddTo(Orph.H.Maw.Hard);
            hard.AddRandomGroup("Maw_EN", "Insider_EN", "Author_EN");

            hard = new AddTo(Orph.H.Errant.Hard);
            hard.AddRandomGroup("Errant_EN", "Insider_EN", "Enigma_EN");

            hard = new AddTo(Orph.H.Dragon.Hard);
            hard.AddRandomGroup("TheDragon_EN", "Insider_EN", "Freud_EN");

            med = new AddTo(Orph.H.Heehoo.Med);
            med.AddRandomGroup("Heehoo_EN", "Insider_EN", Enemies.Suckle, Enemies.Suckle);

            med = new AddTo(Orph.H.Thunderdome.Med);
            med.AddRandomGroup("Thunderdome_EN", "Insider_EN", "Romantic_EN");

            med = new AddTo(Orph.H.Clergy.Med);
            med.AddRandomGroup("Clergy_EN", "Insider_EN", Bots.Yellow);

            hard = new AddTo(Orph.H.Sonoduct.Hard);
            hard.AddRandomGroup("Sonoduct_EN", "Insider_EN");

            //GARDEN

            med = new AddTo(Garden.H.EvilDog.Med);
            med.SimpleAddGroup(2, "EvilDog_EN", 1, "Insider_EN");

            med = new AddTo(Garden.H.Shua.Med);
            med.AddRandomGroup("Shua_EN", "Insider_EN", "EyePalm_EN", "EyePalm_EN");

            med = new AddTo(Garden.H.Starless.Med);
            med.AddRandomGroup("Starless_EN", "Insider_EN", Flower.Red);

            med = new AddTo(Garden.H.YNL.Med);
            med.AddRandomGroup("YNL_EN", "Insider_EN", "Git_EN");

            med = new AddTo(Garden.H.Firebird.Med);
            med.AddRandomGroup("Firebird_EN", "Insider_EN", Enemies.Shivering, Enemies.Shivering);

            med = new AddTo(Garden.H.Hunter.Med);
            med.AddRandomGroup("Hunter_EN", "Insider_EN", "Granfather_EN");

            med = new AddTo(Garden.H.Ode.Med);
            med.AddRandomGroup("OdeToHumanity_EN", "Insider_EN", "MiniReaper_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "Insider_EN");

            med = new AddTo(Garden.H.PersonalAngel.Med);
            med.AddRandomGroup("PersonalAngel_EN", "Insider_EN", "Surrogate_EN");

            med = new AddTo(Garden.H.Yang.Med);
            med.AddRandomGroup("Yang_EN", "Yang_EN", "Insider_EN");

            med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "Insider_EN", "ChoirBoy_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "Insider_EN", Bots.Grey);
            med.AddRandomGroup("Stoplight_EN", "Insider_EN", "EggKeeper_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            hard.AddRandomGroup(Enemies.Skinning, Enemies.Shivering, "Insider_EN");

            med = new AddTo(Garden.H.Minister.Med);
            med.AddRandomGroup(Enemies.Minister, "Insider_EN", Noses.Blue);

            hard = new AddTo(Garden.H.Flower.Grey.Hard);
            hard.AddRandomGroup(Flower.Grey, Flower.Red, Flower.Blue, "Insider_EN");

            hard = new AddTo(Garden.H.Eyeless.Hard);
            hard.AddRandomGroup("Eyeless_EN", "Insider_EN", "Romantic_EN", "Romantic_EN");

            hard = new AddTo(Garden.H.Yang.Hard);
            hard.AddRandomGroup("Yang_EN", "Insider_EN", "Attrition_EN", "Attrition_EN");

            hard = new AddTo(Garden.H.Yin.Hard);
            hard.AddRandomGroup("Yin_EN", "Yang_EN", "Insider_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "Insider_EN", "EvilDog_EN", "EvilDog_EN");

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "Insider_EN", Noses.Yellow);

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "Insider_EN", "InHerImage_EN", "InHisImage_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "Insider_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.SimpleAddGroup(1, "Miriam_EN", 2, "Insider_EN");

            hard = new AddTo(Garden.H.SnakeGod.Hard);
            hard.AddRandomGroup("SnakeGod_EN", "Insider_EN");

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "Insider_EN", "EggKeeper_EN", "EggKeeper_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, Enemies.Minister, "Insider_EN");

            med = new AddTo(Garden.H.Beakart.Med);
            med.AddRandomGroup("Beakart_EN", "Insider_EN", "Shua_EN");

            med = new AddTo(Garden.H.Bonsai.Med);
            med.SimpleAddGroup(2, "Bonsai_EN", 1, "Insider_EN", 1, "GlassFigurine_EN");
        }
    }
}
