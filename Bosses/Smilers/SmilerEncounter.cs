using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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
            boss.RoarEvent = "event:/Blackwater/Roar/SmilerRoar";
            boss.BossID = "Smilers_BOSS";
            boss.AddSpecialEnvironment("Smilers_Arena");

            boss.SimpleAddEncounter(5, "Smilers_BOSS");

            boss.AddEncounterToDataBases();

            VsBossData vsBossData = new VsBossData();
            vsBossData.animation = SaltsReseasoned.Dreams.LoadAsset<AnimationClip>("Assets/Bosses/Smiler/Splash_Smiler.anim");
            vsBossData.roarTime = 8.5f;
            vsBossData.arenaSprite = ResourceLoader.LoadSprite("Env_Smiler.png");
            vsBossData.extraArenaSprite = ResourceLoader.LoadSprite("Ex_Smiler.png");
            vsBossData.bossSprite = ResourceLoader.LoadSprite("Art_Smiler.png");
            vsBossData.signatureSprite = ResourceLoader.LoadSprite("Splash_Smiler.png");
            vsBossData.extraSignatureSprite = ResourceLoader.LoadSprite("Splash_Smiler.png");
            Misc.AddCustom_VSAnimationData("Smilers_BOSS", vsBossData);

            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone01_Smilers_EnemyBundle", 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Boss);
        }
    }
}
