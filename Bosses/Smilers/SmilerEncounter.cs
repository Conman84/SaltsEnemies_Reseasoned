using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class SmilerEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_SmilersEncounter_Sign", ResourceLoader.LoadSprite("SmilersWorld.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/Smiler_Arena.prefab", "Smilers_Arena", SaltsReseasoned.Dreams);

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("Smilers_BOSS", EncounterExtensions.SetBossPortalMaterial("SmilerPortal.png", "01"));

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Random, "BOSS_Zone01_Smilers_EnemyBundle", "Salt_SmilersEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/SmilerTheme";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("BOSS_Zone01_Roids_EnemyBundle")._roarReference.roarEvent;
            boss.BossID = "Smilers_BOSS";
            boss.AddSpecialEnvironment("Smilers_Arena");

            boss.SimpleAddEncounter(5, "Smilers_BOSS");

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone01_Smilers_EnemyBundle", 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Boss);
        }
    }
}
