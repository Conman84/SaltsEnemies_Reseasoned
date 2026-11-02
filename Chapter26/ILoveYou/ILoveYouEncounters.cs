using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ILoveYouEncounters
    {
        public static void Add()
        {
            Add_Med();
            Add_Hard();
        }
        public static void Add_Med()
        {
            Portals.AddPortalSign("Salt_LullabyEncounter_Sign", ResourceLoader.LoadSprite("LullabyWorld.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Random, Orph.H.ILoveYou.Med, "Salt_LullabyEncounter_Sign");
            med.MusicEvent = "event:/Hawthorne/ILoveYouTheme";
            med.RoarEvent = "event:/Hawthorne/Snound1/LullabyRoar";

            med.AddRandomEncounter("ILoveYou_EN", "MusicMan_EN", "MusicMan_EN", "MusicMan_EN");

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.ILoveYou.Med, 15 * April.Mod, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);
        }
        public static void Add_Hard()
        {
            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, Orph.H.ILoveYou.Hard, "Salt_LullabyEncounter_Sign");
            hard.MusicEvent = "event:/Hawthorne/ILoveYouTheme";
            hard.RoarEvent = "event:/Hawthorne/Snound1/LullabyRoar";

            hard.AddRandomEncounter("ILoveYou_EN", "ILoveYou_EN", Spoggle.Red, Spoggle.Purple);

            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Orph.H.ILoveYou.Hard, 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
        public static void Post()
        {

        }
    }
}
