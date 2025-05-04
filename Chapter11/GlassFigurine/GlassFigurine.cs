using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class GlassFigurine
    {
        public static void Add()
        {
            Enemy glass = new Enemy("Glass Figurine", "GlassFigurine_EN")
            {
                Health = 17,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("GlassIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GlassWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GlassDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound,
            };
            glass.PrepareMultiEnemyPrefab("assets/group4/Glass/Glass_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Glass/Glass_Gibs.prefab").GetComponent<ParticleSystem>());
            (glass.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetChild(0).GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetChild(1).GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
            };

            //DISORIENTING
            PerformEffectPassiveAbility disorient = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();


            glass.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            glass.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            glass.AddEnemy(true, true);
        }
    }
}
