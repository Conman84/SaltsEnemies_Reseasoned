using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Candy
    {
        public static void Add()
        {
            Enemy template = new Enemy("Candy Stone", "CandyStone_EN")
            {
                Health = 10,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("StoneIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("StoneWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("StoneDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/CrystalHit",
                DeathSound = "event:/Hawthorne/Noise/CrystalDie",
            };
            template.PrepareEnemyPrefab("assets/16/Stone_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/Stone_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering });

            EnemyAbilityInfo nibble = new EnemyAbilityInfo();
            nibble.ability = LoadedAssetsHandler.GetEnemyAbility("Nibble_A");
            nibble.rarity = Rarity.GetCustomRarity("rarity5");

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                nibble
            });
            template.AddEnemy(true, true, true);
        }
    }
}
