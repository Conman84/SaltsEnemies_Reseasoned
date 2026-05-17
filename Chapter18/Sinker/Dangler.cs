using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Dangler
    {
        public static void Add()
        {
            Enemy dangler = new Enemy("Dangler", "Dangler_EN")
            {
                Health = 6,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("DanglerIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinkerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinkerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            dangler.PrepareEnemyPrefab("Assets/enem2/Dangler_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/enem2/Dangler_Gibs.prefab").GetComponent<ParticleSystem>());
            dangler.enemy.enemyTemplate.m_Data.m_Renderer = dangler.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").GetChild(1).GetComponent<SpriteRenderer>();

            dangler.AddPassives(LoadedAssetsHandler.GetEnemy("Sinker_EN").passiveAbilities.ToArray());
            dangler.AddUnitType("Fish");

            //ADD ENEMY
            dangler.AddEnemyAbilities(LoadedAssetsHandler.GetEnemy("Sinker_EN").abilities.ToArray());
            dangler.AddEnemy(true, true, true);
            dangler.enemy.AddToSynodPool();
            dangler.enemy.AddToToysPool();
            dangler.enemy.AddToEcstasyPool();
        }
    }
}
