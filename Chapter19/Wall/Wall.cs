using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Wall
    {
        public static void Add()
        {
            Enemy wall1 = new Enemy("Wall", "Wall_EN")
            {
                Health = 10,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WallIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WallWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WallDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
                Priority = Priority.CreateAndAddCustomPriorityToPool("wall1", 1)
            };
            wall1.PrepareEnemyPrefab("assets/enem3/Wall_1_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Wall_Gibs.prefab").GetComponent<ParticleSystem>());
            wall1.CombatEnterEffects = Effects.GenerateEffect(WallConnectionEffect.Create(true)).SelfArray();
            wall1.CombatExitEffects = Effects.GenerateEffect(WallConnectionEffect.Create(false)).SelfArray();

            //crush
            EnemyAbilityInfo crush = new EnemyAbilityInfo
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Crush_A"),
                rarity = Rarity.CreateAndAddCustomRarityToPool("Wall_20", 20)
            };

            //ADD ENEMY
            wall1.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                crush
            });
            wall1.AddEnemy(true, true);

            Enemy wall2 = new Enemy("Wall", "Wall_2_EN")
            {
                Health = 10,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("Wall2.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WallWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WallDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
                Priority = Priority.GetCustomPriority("wall1")
            };
            wall2.PrepareEnemyPrefab("assets/enem3/Wall_2_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Wall_Gibs.prefab").GetComponent<ParticleSystem>());
            wall2.AddEnemyAbilities([crush]);
            wall2.AddEnemy(true, true);
        }
    }
}
