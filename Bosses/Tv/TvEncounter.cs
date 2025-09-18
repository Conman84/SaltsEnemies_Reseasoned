using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn;

namespace SaltsEnemies_Reseasoned
{
    public static class TvEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Salt_MegalaniaEncounter_Sign", ResourceLoader.LoadSprite("MegalaniaIcon.png"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Defacer/Tv_Arena.prefab", "Megalania_Arena", SaltsReseasoned.Dreams);
            LoadedAssetsHandler.TryGetCombatEnvironmentPrefab("Megalania_Arena").gameObject.AddMatcherComponent();

            EnemyEncounter_API boss = new EnemyEncounter_API(EncounterType.Specific, "BOSS_Zone02_Megalania_EnemyBundle", "Salt_MegalaniaEncounter_Sign");
            boss.MusicEvent = "event:/Blackwater/TVSong";
            boss.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            boss.BossID = "Megalania_BOSS";
            boss.SpecialEnvironmentID = "Megalania_Arena";
            boss.UsesSpecialEnvironment = true;

            boss.CreateNewEnemyEncounterData(["Megalania_BOSS"], [2]);

            boss.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("BOSS_Zone02_Megalania_EnemyBundle", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);
        }

        public static void AddMatcherComponent(this GameObject obj)
        {
            MegalaniaMatcher matcher = obj.AddComponent<MegalaniaMatcher>();

            Transform left = obj.transform.Find("TvHolder_Left");
            Transform right = obj.transform.Find("TvHolder_Right");

            List<SpriteRenderer> list = new List<SpriteRenderer>();
            for (int i = 0; i < 26; i++)
            {
                list.Add(left.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>());
                list.Add(right.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>());
            }

            matcher.Renderers = list.ToArray();
        }

        public class MegalaniaMatcher : MonoBehaviour
        {
            public SpriteRenderer[] Renderers;

            public void Update()
            {
                if (CombatManager._instance == null) return;

                SpriteRenderer original = null;

                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.Enemy.name == "Megalania_BOSS")
                    {
                        original = CombatManager.Instance._combatUI._enemyZone._enemies[enemy.FieldID].FieldEntity.m_Data.m_Locator.transform.Find("Sprite").Find("Head").Find("Screen").GetComponent<SpriteRenderer>();
                        break;
                    }
                }

                if (original == null)
                {
                    foreach (SpriteRenderer render in Renderers)
                    {
                        if (!render.gameObject.activeSelf) break;
                        render.gameObject.SetActive(false);
                    }

                    return;
                }
                
                foreach (SpriteRenderer render in Renderers)
                {
                    if (!render.gameObject.activeSelf) render.gameObject.SetActive(true);
                    render.sprite = original.sprite;
                    render.color = original.color * new Color32(255, 255, 255, 225);
                }
            }
        }
    }
}
