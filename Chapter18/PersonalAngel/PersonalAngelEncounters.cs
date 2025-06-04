using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PersonalAngelEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_PersonalAngelEncounter_Sign", ResourceLoader.LoadSprite("PersonalWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Garden.H.PersonalAngel.Med, "Salt_PersonalAngelEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/PersonalAngelSong";
            med.RoarEvent = "event:/Hawthorne/Noisy/PA_Roar";

            med.AddRandomEncounter("PersonalAngel_EN", "LittleAngel_EN", "LittleAngel_EN");
            med.SimpleAddEncounter(1, "PersonalAngel_EN", 3, "InHisImage_EN");
            med.SimpleAddEncounter(1, "PersonalAngel_EN", 3, Enemies.Shivering);
            med.AddRandomEncounter("PersonalAngel_EN", "ChoirBoy_EN", "Shua_EN");
            med.AddRandomEncounter("PersonalAngel_EN", Enemies.Minister, "Damocles_EN");
            med.AddRandomEncounter("PersonalAngel_EN", Flower.Blue, Flower.Red);
            med.AddRandomEncounter("PersonalAngel_EN", Flower.Grey, "Firebird_EN");
            med.AddRandomEncounter("PersonalAngel_EN", Jumble.Grey, Enemies.Minister);
            med.AddRandomEncounter("PersonalAngel_EN", Spoggle.Grey, "Grandfather_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "OdeToHumanity_EN", "Grandfather_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "WindSong_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "InHisImage_EN", "InHisImage_EN", "LittleAngel_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "InHisImage_EN", "InHisImage_EN", "MiniReaper_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "InHisImage_EN", "InHisImage_EN", "Indicator_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "BlackStar_EN", "EvilDog_EN", "EvilDog_EN");
            med.AddRandomEncounter("PersonalAngel_EN", Bots.Grey, Enemies.Shivering);
            med.AddRandomEncounter("PersonalAngel_EN", "YNL_EN", "Firebird_EN");
            med.AddRandomEncounter("PersonalAngel_EN", "Hunter_EN", "Grandfather_EN", "Children6_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.PersonalAngel.Med, 7, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo med = new AddTo(Garden.H.Satyr.Med);
            med.AddRandomGroup("Satyr_EN", "PersonalAngel_EN", "Damocles_EN");

            AddTo hard = new AddTo(Garden.H.Satyr.Hard);
            hard.AddRandomGroup("Satyr_EN", "PersonalAngel_EN", "InHerImage_EN", "InHerImage_EN");

            hard = new AddTo(Garden.H.ClockTower.Hard);
            hard.AddRandomGroup("ClockTower_EN", "PersonalAngel_EN", Enemies.Skinning);

            hard = new AddTo(Garden.H.Tank.Hard);
            hard.AddRandomGroup(Enemies.Tank, "PersonalAngel_EN", "BlackStar_EN");

            med = new AddTo(Garden.H.Stoplight.Med);
            med.AddRandomGroup("Stoplight_EN", "PersonalAngel_EN", "TortureMeNot_EN", "TortureMeNot_EN", "TortureMeNot_EN");

            hard = new AddTo(Garden.H.Stoplight.Hard);
            hard.AddRandomGroup("Stoplight_EN", "PersonalAngel_EN", "ChoirBoy_EN");

            hard = new AddTo(Garden.H.GlassedSun.Hard);
            hard.SimpleAddGroup(3, "GlassedSun_EN", 1, "PersonalAngel_EN");

            hard = new AddTo(Garden.H.Miriam.Hard);
            hard.AddRandomGroup("Miriam_EN", "PersonalAngel_EN", "Stoplight_EN");

            med = new AddTo(Garden.H.Complimentary.Med);
            med.AddRandomGroup("Complimentary_EN", "PersonalAngel_EN");

            med = new AddTo(Garden.H.Skinning.Med);
            med.AddRandomGroup(Enemies.Skinning, "Complimentary_EN", Enemies.Shivering);

            hard = new AddTo(Garden.H.Skinning.Hard);
            hard.AddRandomGroup(Enemies.Skinning, "PersonalAngel_EN", "MiniReaper_EN");

            hard = new AddTo(Garden.H.Minister.Hard);
            hard.AddRandomGroup(Enemies.Minister, "PersonalAngel_EN", Flower.Grey);
        }
    }
}
