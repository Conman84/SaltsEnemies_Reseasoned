using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class CrowChildEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_CrowChildEncounter_Sign", ResourceLoader.LoadSprite("CrowChildWorld.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/CrowArena.prefab", "CrowChild_Arena", SaltsReseasoned.Dreams);

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("CrowChild_BOSS", EncounterExtensions.SetBossPortalMaterial("CrowChildPortal.png", "01"));

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone01_CrowChild_EnemyBundle", "Salt_CrowChildEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/CrowChildSong";
            boss.RoarEvent = "event:/Blackwater/Roar/CCRoar";
            boss.BossID = "CrowChild_BOSS";
            boss.AddSpecialEnvironment("CrowChild_Arena");

            boss.CreateNewEnemyEncounterData(["CrowChild_BOSS"], [2]);

            boss.AddEncounterToDataBases();

            VsBossData vsBossData = new VsBossData();
            vsBossData.animation = SaltsReseasoned.Dreams.LoadAsset<AnimationClip>("Assets/Bosses/Crow/CrowChildSplash.anim");
            vsBossData.roarTime = 4.5f;
            vsBossData.arenaSprite = ResourceLoader.LoadSprite("CrowChildEnv.png");
            vsBossData.extraArenaSprite = ResourceLoader.LoadSprite("CrowChildEnv.png");
            vsBossData.bossSprite = ResourceLoader.LoadSprite("art_crow_head.png");
            vsBossData.signatureSprite = ResourceLoader.LoadSprite("splash_crow.png");
            vsBossData.extraSignatureSprite = ResourceLoader.LoadSprite("splash_crow.png");
            Misc.AddCustom_VSAnimationData("CrowChild_BOSS", vsBossData);

            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone01_CrowChild_EnemyBundle", 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Boss);
        }
    }
}
