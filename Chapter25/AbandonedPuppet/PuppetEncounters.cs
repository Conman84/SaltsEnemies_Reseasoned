using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PuppetEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_PuppetEncounter_Sign", ResourceLoader.LoadSprite("PuppetPortal.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Abyss.H.Puppet.Med, "Salt_PuppetEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/CorpseChanSong";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.SimpleAddEncounter(3, "AbandonedPuppet_EN", 1, "Nine_EN");
            med.SimpleAddEncounter(3, "AbandonedPuppet_EN", 1, "EyePalm_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToCustomZoneSelector(Abyss.H.Puppet.Med, 8, "TheAbyss_Zone3", BundleDifficulty.Medium);
        }

        public static void Post()
        {
            AddTo easy = new AddTo(Abyss.H.EyePalm.Easy);
            easy.SimpleAddGroup(2, "EyePalm_EN", 1, "AbandonedPuppet_EN");

            AddTo med = new AddTo(Abyss.H.EyePalm.Med);
            med.SimpleAddGroup(3, "EyePalm_EN", 1, "AbandonedPuppet_EN");
        }
    }
}
