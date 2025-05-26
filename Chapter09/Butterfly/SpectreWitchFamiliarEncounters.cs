using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SpectreWitchFamiliarEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_ButterflyEncounter_Sign", ResourceLoader.LoadSprite("ButterflyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.Butterfly.Med, "Salt_ButterflyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ButterflyTheme";
            med.RoarEvent = "";

            med.AddRandomEncounter("Butterfly_EN", "Butterfly_EN", "Butterfly_EN");
            for (int i = 0; i < 3; i++) med.AddRandomEncounter("Butterfly_EN", "Butterfly_EN", "Butterfly_EN", "Butterfly_EN");
            for (int t = 0; t < 2; t++) med.AddRandomEncounter("Butterfly_EN", "Butterfly_EN", "Butterfly_EN", "Butterfly_EN", "Butterfly_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.Butterfly.Med, 12, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo med = new AddTo(Orph.H.Scrungie.Med);
            med.AddRandomGroup("Scrungie_EN", "Scrungie_EN", "Scrungie_EN", "Butterfly_EN");

            med = new AddTo(Orph.H.Jumble.Blue.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Jumble.Blue, Jumble.Purple, "Butterfly_EN");

            med = new AddTo(Orph.H.Jumble.Purple.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Jumble.Purple, Jumble.Blue, "Butterfly_EN");

            AddTo hard = new AddTo(Orph.H.Sacrifice.Hard);
            if (SaltsReseasoned.rando == 5) hard.AddRandomGroup(Enemies.Sacrifice, "Butterfly_EN", "Butterfly_EN", "Butterfly_EN");
            if (SaltsReseasoned.rando == 6) hard.AddRandomGroup(Enemies.Sacrifice, Enemies.Sacrifice, "Butterfly_EN", "Butterfly_EN");

            hard = new AddTo(Orph.H.Revola.Hard);
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Revola_EN", "Butterfly_EN", "Butterfly_EN");

            med = new AddTo(Orph.H.Conductor.Med);
            if (SaltsReseasoned.silly < 50) med.AddRandomGroup("Conductor_EN", "Butterfly_EN", "Butterfly_EN", "Butterfly_EN");

            hard = new AddTo(Orph.H.Conductor.Hard);
            if (SaltsReseasoned.silly > 50) hard.AddRandomGroup("Conductor_EN", Jumble.Blue, "Butterfly_EN");
            if (SaltsReseasoned.silly < 50) hard.AddRandomGroup("Conductor_EN", "Enigma_EN", "Butterfly_EN", "Butterfly_EN");

            med = new AddTo(Orph.H.Crow.Med);
            med.AddRandomGroup("TheCrow_EN", "Butterfly_EN", "Butterfly_EN", "Butterfly_EN");

            med = new AddTo(Orph.H.Delusion.Med);
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Delusion_EN", "Butterfly_EN");
            med.AddRandomGroup("Delusion_EN", "Delusion_EN", "Butterfly_EN", "Butterfly_EN");

            med = new AddTo(Orph.H.Flower.Yellow.Med);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup(Flower.Yellow, Flower.Purple, "Butterfly_EN");

            med = new AddTo(Orph.H.Flower.Purple.Med);
            if (SaltsReseasoned.trolling > 50) med.AddRandomGroup(Flower.Purple, Flower.Yellow, "Butterfly_EN");

            hard = new AddTo(Orph.H.Tortoise.Hard);
            if (SaltsReseasoned.trolling < 50) med.AddRandomGroup("StalwartTortoise_EN", "Butterfly_EN", "Butterfly_EN");
        }
    }
}
