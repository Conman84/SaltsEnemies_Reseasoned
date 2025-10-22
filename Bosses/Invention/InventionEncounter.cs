using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class InventionEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_InventionEncounter_Sign", ResourceLoader.LoadSprite("InventionWorld.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/Arena_HalfOrpheum.prefab", "Half_Orpheum_Arena", SaltsReseasoned.Dreams);
            LoadedAssetsHandler.TryGetCombatEnvironmentPrefab("Half_Orpheum_Arena")._extraEnvironmentAmbienceSound = "event:/Blackwater/Noise/InventionAmbi";

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("Invention_BOSS", EncounterExtensions.SetBossPortalMaterial("SecondInventionPortal.png", "02"));

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Random, "BOSS_Zone02_Invention_EnemyBundle", "Salt_InventionEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/InventionSong";
            boss.RoarEvent = "event:/Blackwater/Roar/InventionRoar";
            boss.BossID = "Invention_BOSS";
            boss.SpecialEnvironmentID = "Half_Orpheum_Arena";
            boss.UsesSpecialEnvironment = true;

            boss.AddRandomEncounter("Invention_BOSS");

            boss.AddEncounterToDataBases();

            VsBossData vsBossData = new VsBossData();
            vsBossData.animation = SaltsReseasoned.Dreams.LoadAsset<AnimationClip>("Assets/Bosses/Invention/Invention_Splash.anim");
            vsBossData.roarTime = 11f;
            vsBossData.arenaSprite = ResourceLoader.LoadSprite("InventionEnv2.png");
            vsBossData.extraArenaSprite = ResourceLoader.LoadSprite("InventionEnv2.png");
            vsBossData.bossSprite = ResourceLoader.LoadSprite("Art_Inv.png");
            vsBossData.signatureSprite = ResourceLoader.LoadSprite("Splash_Inv.png");
            vsBossData.extraSignatureSprite = ResourceLoader.LoadSprite("Splash_Inv.png");
            Misc.AddCustom_VSAnimationData("Invention_BOSS", vsBossData);

            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone02_Invention_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);
        }
    }
}
