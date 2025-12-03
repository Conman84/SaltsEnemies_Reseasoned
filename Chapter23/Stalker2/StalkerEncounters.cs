using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class StalkerEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_StalkerEncounter_Sign", ResourceLoader.LoadSprite("StalkerPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Stalker.Med, "Salt_StalkerEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/StalkerSong";
            med.RoarEvent = "event:/Hawthorne/Ssound/StalkerDie";

            med.SimpleAddEncounter(5, "Stalker2_EN");
            med.SimpleAddEncounter(3, "Stalker2_EN", 1, "Tassnn_EN");
            med.SimpleAddEncounter(2, "Stalker2_EN", 1, Ecstasy.Random, 1, Ecstasy.Random);
            med.SimpleAddEncounter(2, "Stalker2_EN", 2, "Tassnn_EN");
            med.SimpleAddEncounter(2, "Stalker2_EN", 1, "Tassnn_EN", 1, Ecstasy.Random);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Stalker.Med, 10, "TheSiren_Zone1", BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Siren.H.Ecstasy.Red.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, Ecstasy.Random, "Stalker2_EN");
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, "Tassnn_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Ecstasy.Blue.Med);
            med.AddRandomGroup(Ecstasy.Blue, Ecstasy.Random, Ecstasy.Random, "Stalker2_EN");
            med.AddRandomGroup(Ecstasy.Blue, Ecstasy.Random, "WolfColony_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Ecstasy.Yellow.Med);
            med.AddRandomGroup(Ecstasy.Yellow, Ecstasy.Random, Ecstasy.Random, "Stalker2_EN");
            med.AddRandomGroup(Ecstasy.Yellow, Ecstasy.Random, "Boiler_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Ecstasy.Purple.Med);
            med.AddRandomGroup(Ecstasy.Purple, Ecstasy.Random, Ecstasy.Random, "Stalker2_EN");
            med.AddRandomGroup(Ecstasy.Purple, Ecstasy.Random, "Tumult_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Wolf.Med);
            med.AddRandomGroup("WolfColony_EN", "WolfColony_EN", "Tassnn_EN", "Stalker2_EN");

            AddTo hard = new AddTo(Siren.H.Piscina.Hard);
            hard.AddRandomGroup("LivingPiscina_EN", "Stalker2_EN", Ecstasy.Random);
            hard.AddRandomGroup("LivingPiscina_EN", "Stalker2_EN", "Tumult_EN", "Tumult_EN");

            AddTo easy = new AddTo(Siren.H.Tumult.Easy);
            easy.SimpleAddGroup(2, "Tumult_EN", 1, "Stalker2_EN");

            med = new AddTo(Siren.H.Tumult.Med);
            med.SimpleAddGroup(3, "Tumult_EN", 1, "Stalker2_EN");
            med.SimpleAddGroup(2, "Tumult_EN", 1, "Stalker2_EN", 1, "Boiler_EN");

            easy = new AddTo(Siren.H.Boiler.Easy);
            easy.SimpleAddGroup(2, "Boiler_EN", 1, "Stalker2_EN");
            easy.AddRandomGroup("Boiler_EN", "BirdBath_EN", "BirdBath_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Boiler.Med);
            med.SimpleAddGroup(2, "Boiler_EN", 1, "Stalker2_EN", 1, "Tassnn_EN");
            med.SimpleAddGroup(2, "Boiler_EN", 1, "Stalker2_EN", 1, Ecstasy.Random);

            easy = new AddTo(Siren.H.Tassnn.Easy);
            easy.SimpleAddGroup(1, "Tassnn_EN", 2, "Stalker2_EN");

            med = new AddTo(Siren.H.Tassnn.Med);
            med.SimpleAddGroup(2, "Tassnn_EN", 2, "Stalker2_EN");
            med.AddRandomGroup("Tassnn_EN", "WolfColony_EN", "Stalker2_EN", "Stalker2_EN");

            med = new AddTo(Siren.H.Olmic.Med);
            med.AddRandomGroup("Olmic_EN", "Stalker2_EN", "Boiler_EN", "Boiler_EN");
            med.AddRandomGroup("Olmic_EN", "Stalker2_EN", "Tumult_EN", "Tumult_EN");

            hard = new AddTo(Siren.H.Olmic.Hard);
            hard.AddRandomGroup("Olmic_EN", "Stalker2_EN", "Tassnn_EN", "Tassnn_EN");
            hard.AddRandomGroup("Olmic_EN", "Stalker2_EN", Ecstasy.Random, Ecstasy.Random);

            hard = new AddTo(Siren.H.Phalaris.Hard);
            hard.AddRandomGroup(Enemies.Phalaris, "Tassnn_EN", "Tassnn_EN", "Stalker2_EN", "Stalker2_EN");
            hard.AddRandomGroup(Enemies.Phalaris, Ecstasy.Random, Ecstasy.Random, Ecstasy.Random, "Stalker2_EN");

            med = new AddTo(Siren.H.Soothsayer.Med);
            med.SimpleAddGroup(1, "Soothsayer_EN", 3, "Stalker2_EN");
            med.AddRandomGroup("Soothsayer_EN", "Stalker2_EN", "Tassnn_EN");
        }
    }
}
