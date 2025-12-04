using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class WolfEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_WolfEncounter_Sign", ResourceLoader.LoadSprite("WolfWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Siren.H.Wolf.Med, "Salt_WolfEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/WolfColonySong";
            med.RoarEvent = "event:/Hawthorne/Ssound/WolfDie";

            med.SimpleAddEncounter(3, "WolfColony_EN");
            med.SimpleAddEncounter(2, "WolfColony_EN", 2, "Boiler_EN");
            med.SimpleAddEncounter(2, "WolfColony_EN", 1, "Tassnn_EN");
            med.SimpleAddEncounter(2, "WolfColony_EN", 1, Ecstasy.Random);
            med.SimpleAddEncounter(3, "WolfColony_EN", 1, "Stalker2_EN");
            med.SimpleAddEncounter(2, "WolfColony_EN", 2, "Tassnn_EN");
            med.SimpleAddEncounter(2, "WolfColony_EN", 1, "Tassnn_EN", 1, "Stalker2_EN");
            med.SimpleAddEncounter(2, "WolfColony_EN", 1, Ecstasy.Random, 1, Ecstasy.Random);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Siren.H.Wolf.Med, 15, "TheSiren_Zone1", BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo hard = new AddTo(Siren.H.Piscina.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup("LivingPiscina_EN", "WolfColony_EN", "WolfColony_EN");
            else hard.AddRandomGroup("LivingPiscina_EN", "WolfColony_EN", "Tassnn_EN");

            AddTo med = new AddTo(Siren.H.Tassnn.Med);
            med.SimpleAddGroup(2, "Tassnn_EN", 2, "WolfColony_EN");
            if (SaltsReseasoned.silly > 50) med.AddRandomGroup("Tassnn_EN", "WolfColony_EN", Ecstasy.Random);
            else med.AddRandomGroup("Tassnn_EN", "WolfColony_EN", "Tumult_EN");

            med = new AddTo(Siren.H.Wolf.Med);
            med.SimpleAddGroup(2, "WolfColony_EN", 1, "Tassnn_EN", 1, "Lloigor_EN");

            med = new AddTo(Siren.H.Olmic.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("Olmic_EN", "WolfColony_EN", "WolfColony_EN");
            else med.AddRandomGroup("Olmic_EN", "WolfColony_EN", "Boiler_EN");

            hard = new AddTo(Siren.H.Olmic.Hard);
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Olmic_EN", "WolfColony_EN", Ecstasy.Random, Ecstasy.Random);
            else hard.AddRandomGroup("Olmic_EN", "WolfColony_EN", "Tassnn_EN", "Tassnn_EN");

            hard = new AddTo(Siren.H.Phalaris.Hard);
            if (SaltsReseasoned.trolling > 50) hard.AddRandomGroup(Enemies.Phalaris, "WolfColony_EN", "Tassnn_EN", Ecstasy.Random);
            else hard.SimpleAddGroup(1, Enemies.Phalaris, 3, "WolfColony_EN");

            med = new AddTo(Siren.H.Soothsayer.Med);
            med.AddRandomGroup("Soothsayer_EN", "WolfColony_EN", "Tassnn_EN");

            med = new AddTo(Siren.H.Ecstasy.Red.Med);
            med.AddRandomGroup(Ecstasy.Red, Ecstasy.Random, "WolfColony_EN");
            med = new AddTo(Siren.H.Ecstasy.Blue.Med);
            med.AddRandomGroup(Ecstasy.Blue, Ecstasy.Random, "WolfColony_EN");
            med = new AddTo(Siren.H.Ecstasy.Yellow.Med);
            med.AddRandomGroup(Ecstasy.Yellow, Ecstasy.Random, "WolfColony_EN");
            med = new AddTo(Siren.H.Ecstasy.Purple.Med);
            med.AddRandomGroup(Ecstasy.Purple, Ecstasy.Random, "WolfColony_EN");
        }
    }
}
