using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class Windle
    {
        public static void Add()
        {
            Enemy windle = new Enemy("Windle", "Windle_EN")
            {
                Health = 12,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("WindleIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WindleWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WindleDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Doll_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound,
            };
            windle.PrepareMultiEnemyPrefab("assets/group4/Windle/Windle_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Windle/Windle_Gibs.prefab").GetComponent<ParticleSystem>());
            (windle.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                windle.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
            };


            windle.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery });
            windle.AddUnitType("Fish");

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            windle.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            windle.AddEnemy(true, true);
        }
    }
}
