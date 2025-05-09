using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Rabies
    {
        public static void Add()
        {
            Enemy template = new Enemy("Lyssarabhas", "Rabies_EN")
            {
                Health = 18,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("RabiesIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RabiesWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("RabiesDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Pearl_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Pearl_CH").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/Rabies/Rabies_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Rabies/Rabies_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish2, Passives.SlipperyGenerator(2), Passives.MultiAttack2 });

            EnemyAbilityInfo chomp = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Chomp_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                chomp
            });
            template.AddEnemy(true, true);
        }
    }
}
