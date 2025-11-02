using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class EcstasyEncounters
    {
        public static void Add()
        {
            Add_Red();
            Add_Blue();
            Add_Yellow();
            Add_Purple();
        }
        public static void Add_Red()
        {
            Portals.AddPortalSign("Salt_RedEcstasyEncounter_Sign", ResourceLoader.LoadSprite("RedEcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Ecstasy.Red.Med, "Salt_RedEcstasyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Foxtrot_EN").deathSound;

            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Blue, Ecstasy.Yellow, Ecstasy.Purple);
            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Random, Ecstasy.Random, "Tumult_EN");
            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Random, "Boiler_EN", "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Random, Ecstasy.Random, "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Random, "Tassnn_EN", Enemies.Puker);
            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Random, Ecstasy.Random, Enemies.Puker);
            med.SimpleAddEncounter(4, Ecstasy.Red);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Ecstasy.Red.Med, 3, "TheSiren_Zone1", BundleDifficulty.Medium);
        }
        public static void Add_Yellow()
        {
            Portals.AddPortalSign("Salt_YellowEcstasyEncounter_Sign", ResourceLoader.LoadSprite("YellowEcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Ecstasy.Yellow.Med, "Salt_YellowEcstasyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Foxtrot_EN").deathSound;

            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Blue, Ecstasy.Yellow, Ecstasy.Purple);
            med.AddRandomEncounter(Ecstasy.Yellow, Ecstasy.Random, Ecstasy.Random, "Tumult_EN");
            med.AddRandomEncounter(Ecstasy.Yellow, Ecstasy.Random, "Boiler_EN", "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Yellow, Ecstasy.Random, Ecstasy.Random, "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Yellow, Ecstasy.Random, "Tassnn_EN", Enemies.Puker);
            med.AddRandomEncounter(Ecstasy.Yellow, Ecstasy.Random, Ecstasy.Random, Enemies.Puker);
            med.SimpleAddEncounter(4, Ecstasy.Yellow);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Ecstasy.Yellow.Med, 3, "TheSiren_Zone1", BundleDifficulty.Medium);
        }
        public static void Add_Blue()
        {
            Portals.AddPortalSign("Salt_BlueEcstasyEncounter_Sign", ResourceLoader.LoadSprite("BlueEcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Ecstasy.Blue.Med, "Salt_BlueEcstasyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Grandfather_EN").deathSound;

            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Blue, Ecstasy.Yellow, Ecstasy.Purple);
            med.AddRandomEncounter(Ecstasy.Blue, Ecstasy.Random, Ecstasy.Random, "Tumult_EN");
            med.AddRandomEncounter(Ecstasy.Blue, Ecstasy.Random, "Boiler_EN", "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Blue, Ecstasy.Random, Ecstasy.Random, "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Blue, Ecstasy.Random, "Tassnn_EN", Enemies.Puker);
            med.AddRandomEncounter(Ecstasy.Blue, Ecstasy.Random, Ecstasy.Random, Enemies.Puker);
            med.SimpleAddEncounter(4, Ecstasy.Blue);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Ecstasy.Blue.Med, 3, "TheSiren_Zone1", BundleDifficulty.Medium);
        }
        public static void Add_Purple()
        {
            Portals.AddPortalSign("Salt_PurpleEcstasyEncounter_Sign", ResourceLoader.LoadSprite("PurpleEcstasyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Ecstasy.Purple.Med, "Salt_PurpleEcstasyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/EcstasySong";
            med.RoarEvent = "event:/Hawthorne/Noise/Ominous";

            med.AddRandomEncounter(Ecstasy.Red, Ecstasy.Blue, Ecstasy.Yellow, Ecstasy.Purple);
            med.AddRandomEncounter(Ecstasy.Purple, Ecstasy.Random, Ecstasy.Random, "Tumult_EN");
            med.AddRandomEncounter(Ecstasy.Purple, Ecstasy.Random, "Boiler_EN", "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Purple, Ecstasy.Random, Ecstasy.Random, "Boiler_EN");
            med.AddRandomEncounter(Ecstasy.Purple, Ecstasy.Random, "Tassnn_EN", Enemies.Puker);
            med.AddRandomEncounter(Ecstasy.Purple, Ecstasy.Random, Ecstasy.Random, Enemies.Puker);
            med.SimpleAddEncounter(4, Ecstasy.Purple);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Ecstasy.Purple.Med, 3, "TheSiren_Zone1", BundleDifficulty.Medium);
        }
        public static void Post()
        {
            AddTo hard = new AddTo(Siren.H.Piscina.Hard);
            hard.AddRandomGroup("LivingPiscina_EN", "Boiler_EN", Ecstasy.Random);
            hard.AddRandomGroup("LivingPiscina_EN", "Tassnn_EN", Ecstasy.Random);
            hard.AddRandomGroup("LivingPiscina_EN", "Tumult_EN", Ecstasy.Random);

            AddTo med = new AddTo(Siren.H.Tumult.Med);
            med.SimpleAddGroup(2, "Tumult_EN", 1, Ecstasy.Red);
            med.SimpleAddGroup(2, "Tumult_EN", 1, Ecstasy.Random);

            med = new AddTo(Siren.H.Boiler.Med);
            med.SimpleAddGroup(3, "Boiler_EN", 1, Ecstasy.Red);
            med.SimpleAddGroup(2, "Boiler_EN", 1, Ecstasy.List.Exclude(Ecstasy.Red).GetRandom());
            med.SimpleAddGroup(2, "Boiler_EN", 1, Ecstasy.Random, 1, "BirdBath_EN");
            med.SimpleAddGroup(2, "Boiler_EN", 1, Ecstasy.Random, 1, Enemies.Puker);

            med = new AddTo(Siren.H.Tassnn.Med);
            med.SimpleAddGroup(2, "Tassnn_EN", 1, Ecstasy.Random);
            med.SimpleAddGroup(2, "Tassnn_EN", 1, Ecstasy.Random, 1, "BirdBath_EN");
            med.SimpleAddGroup(2, "Tassnn_EN", 1, Ecstasy.Random, 1, Enemies.Puker);
            med.AddRandomGroup("Tassnn_EN", Ecstasy.Random, Ecstasy.Random);

            med = new AddTo(Siren.H.Soothsayer.Med);
            med.AddRandomGroup("Soothsayer_EN", "Boiler_EN", Ecstasy.Random);
            med.AddRandomGroup("Soothsayer_EN", Ecstasy.Random, Ecstasy.Random);
            med.AddRandomGroup("Soothsayer_EN", "Tumult_EN", Ecstasy.Random);
            med.AddRandomGroup("Soothsayer_EN", "Tassnn_EN", Ecstasy.Random);

            med = new AddTo(Siren.H.OneShooter.Med);
            med.AddRandomGroup("OneShooter_EN", Ecstasy.Random, Ecstasy.Random);
            med.AddRandomGroup("OneShooter_EN", "Boiler_EN", Ecstasy.Random);
            med.AddRandomGroup("OneShooter_EN", "Tassnn_EN", Ecstasy.Random);

            med = new AddTo(Siren.H.Olmic.Med);
            med.AddRandomGroup("Olmic_EN", Ecstasy.Random, "Boiler_EN");
            med.AddRandomGroup("Olmic_EN", Ecstasy.Random, "Tumult_EN");
            med.AddRandomGroup("Olmic_EN", Ecstasy.Random, "Tassnn_EN");
            med.AddRandomGroup("Olmic_EN", Ecstasy.Random, Ecstasy.Random);

            hard = new AddTo(Siren.H.Olmic.Hard);
            hard.SimpleAddGroup(2, "Olmic_EN", 1, Ecstasy.Random);
            hard.AddRandomGroup("Olmic_EN", Ecstasy.Random, Ecstasy.Random, Ecstasy.Red);
            hard.AddRandomGroup("Olmic_EN", Ecstasy.Random, Ecstasy.Random, "Boiler_EN");
            hard.AddRandomGroup("Olmic_EN", Ecstasy.Random, "Boiler_EN", "Boiler_EN");
            hard.AddRandomGroup("Olmic_EN", Ecstasy.Random, Ecstasy.Random, "Tassnn_EN");

            hard = new AddTo(Siren.H.Phalaris.Hard);
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, Ecstasy.Random);
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, "Boiler_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, "Tassnn_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, "Tumult_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, "BirdBath_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, "BirdBath_EN", "BirdBath_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, Enemies.Puker);
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, "Boiler_EN", "Boiler_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, "Tumult_EN", "Tumult_EN");

            med = new AddTo(Siren.H.Ecstasy.Red.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, Ecstasy.Random, "Lloigor_EN");
            med = new AddTo(Siren.H.Ecstasy.Blue.Med);
            med.AddRandomGroup(Ecstasy.Blue, Ecstasy.Random, Ecstasy.Random, "Lloigor_EN");
            med = new AddTo(Siren.H.Ecstasy.Yellow.Med);
            med.AddRandomGroup(Ecstasy.Yellow, Ecstasy.Random, Ecstasy.Random, "Lloigor_EN");
            med = new AddTo(Siren.H.Ecstasy.Purple.Med);
            med.AddRandomGroup(Ecstasy.Purple, Ecstasy.Random, Ecstasy.Random, "Lloigor_EN");
        }
    }
}
