using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueSkyEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_BlueSkyEncounter_Sign", ResourceLoader.LoadSprite("MikuWorld.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/BlueSky_Arena.prefab", "BlueSky_Arena", SaltsReseasoned.Dreams);
            LoadedAssetsHandler.TryGetCombatEnvironmentPrefab("BlueSky_Arena").gameObject.SetGrassMaterial();

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("BlueSky_BOSS", EncounterExtensions.SetBossPortalMaterial("BlueSkyPortal.png", "03"));

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone03_BlueSky_EnemyBundle", "Salt_BlueSkyEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/BlueSkySong";
            boss.RoarEvent = "event:/Blackwater/Roar/BSRoar";
            boss.BossID = "BlueSky_BOSS";
            boss.SpecialEnvironmentID = "BlueSky_Arena";
            boss.UsesSpecialEnvironment = true;

            boss.CreateNewEnemyEncounterData(["BlueSky_BOSS"], [2]);

            boss.AddEncounterToDataBases();

            VsBossData vsBossData = new VsBossData();
            vsBossData.animation = SaltsReseasoned.Dreams.LoadAsset<AnimationClip>("Assets/Bosses/BS/BS_Splash.anim");
            vsBossData.roarTime = 6.5f;
            vsBossData.arenaSprite = ResourceLoader.LoadSprite("TvEnv.png");
            vsBossData.extraArenaSprite = ResourceLoader.LoadSprite("TvEnv.png");
            vsBossData.bossSprite = ResourceLoader.LoadSprite("Art_BS.png");
            vsBossData.signatureSprite = ResourceLoader.LoadSprite("Splash_BlueSky.png");
            vsBossData.extraSignatureSprite = ResourceLoader.LoadSprite("Splash_BlueSky.png");
            Misc.AddCustom_VSAnimationData("BlueSky_BOSS", vsBossData);

            //consider setting rarity to 0
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone03_BlueSky_EnemyBundle", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Boss);
        }
        public static void SetGrassMaterial(this GameObject self)
        {
            Transform holder = self.transform.Find("Grass");

            Material use = GettingTheShader();

            for (int i = 0; i < 192; i++)
            {
                holder.GetChild(i).GetComponent<SpriteRenderer>().material = use;
            }
        }
        public static Material GettingTheShader()
        {
            return LoadedAssetsHandler.TryGetCombatEnvironmentPrefab(LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01").CombatEnvironment)._propPrefabs[4].transform.Find("PropLocations").Find("SmallProps").GetChild(0).GetComponent<SpriteRenderer>().material;
        }
    }
}
