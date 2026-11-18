using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace YourNamespace
{
    public static class ExampleOfWhatIThink
    {

        public static void Add()
        {
            Portals.AddPortalSign("Salt_MegalaniaEncounter_Sign", ResourceLoader.LoadSprite("MegalaniaIcon.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/Tv_Arena.prefab", "Megalania_Arena", SaltsReseasoned.Dreams);

            ControlAlphaByHealthPercent controller = LoadedAssetsHandler.TryGetCombatEnvironmentPrefab("Megalania_Arena").gameObject.AddComponent<ControlAlphaByHealthPercent>();
            controller.Image = controller.transform.Find("Background_Wall").GetComponent<SpriteRenderer>();//note: get the correct path for the image renderer

            /*LoadedDBsHandler._PortalDB.AddBackgroundPortal("Megalania_BOSS", EncounterExtensions.SetBossPortalMaterial("MegalaniaPortal.png", "02"));

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone02_Megalania_EnemyBundle", "Salt_MegalaniaEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/TVSong";
            boss.RoarEvent = "event:/Blackwater/Roar/TvRoar";
            boss.BossID = "Megalania_BOSS";
            boss.SpecialEnvironmentID = "Megalania_Arena";
            boss.UsesSpecialEnvironment = true;

            boss.CreateNewEnemyEncounterData(["Megalania_BOSS"], [2]);

            boss.AddEncounterToDataBases();

            VsBossData vsBossData = new VsBossData();
            vsBossData.animation = SaltsReseasoned.Dreams.LoadAsset<AnimationClip>("Assets/Bosses/Tv/TvSplash.anim");
            vsBossData.roarTime = 4f;
            vsBossData.arenaSprite = ResourceLoader.LoadSprite("TvEnv.png");
            vsBossData.extraArenaSprite = ResourceLoader.LoadSprite("TvEnv.png");
            vsBossData.bossSprite = ResourceLoader.LoadSprite("Art_Tv.png");
            vsBossData.signatureSprite = ResourceLoader.LoadSprite("Splash_Tv.png");
            vsBossData.extraSignatureSprite = ResourceLoader.LoadSprite("Splash_Tv.png");
            Misc.AddCustom_VSAnimationData("Megalania_BOSS", vsBossData);

            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone02_Megalania_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);*/
        }
    }
    public class ControlAlphaByHealthPercent : MonoBehaviour
    {
        public SpriteRenderer Image;
        public float DecaySpd = 0.05f;
        public float TickSpd = 0.1f;
        float Tick = 0f;
        public void Update()
        {
            Tick -= Time.deltaTime;
            if (Tick <= 0f)
            {
                Tick = TickSpd;
            }
            else return;

            if (CombatManager._instance == null) return;
            if (Image == null)
            {
                Debug.LogWarning("the sprite to control alpha for is missing!");
            }

            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (enemy.Enemy.name == "Deathmatch_BOSS")
                {
                    float current_alpha = Image.color.a;
                    float health_percent = 1f - (float)enemy.CurrentHealth / (float)enemy.Enemy.health;

                    if (current_alpha > health_percent)
                    {
                        current_alpha = Math.Max(health_percent, current_alpha - DecaySpd);
                    }
                    else if (current_alpha < health_percent)
                    {
                        current_alpha = Math.Min(health_percent, current_alpha + DecaySpd);
                    }
                    
                    break;
                }
            }
        }
    }
}
