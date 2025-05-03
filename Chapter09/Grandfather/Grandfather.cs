using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Grandfather
    {
        public static void Add()
        {
            Enemy template = new Enemy("Grandfather", "Grandfather_EN")
            {
                Health = 16,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CoffinIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CoffinWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CoffinDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/Coffin/Coffin_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Coffin/Coffin_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }
}
