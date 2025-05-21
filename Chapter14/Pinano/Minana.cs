using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Minana
    {
        public static void Add()
        {
            Enemy minana = new Enemy("Minana", "Minana_EN")
            {
                Health = 6,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("MinanaIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MinanaWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MinanaDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Mung_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Mung_EN").deathSound,
            };
            minana.PrepareMultiEnemyPrefab("assets/Pinano/Minana_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Pinano/Minana_Gibs.prefab").GetComponent<ParticleSystem>());
            (minana.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                minana.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                minana.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("body").GetComponent<SpriteRenderer>(),
            };

            minana.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, Violent.Generate(1) });
            minana.UnitTypes = new List<string> { "Fish" };

            //THRASH
            Ability thrash = new Ability("Pinano_Thrash_A")
            {
                Name = "Thrash",
                Description = "Deal a Little damage to the Opposing party member and a Little damage to this enemy.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Pinano12", 12),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                AnimationTarget = Slots.Self,
            };
            thrash.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_1_2.ToString().SelfArray());
            thrash.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Damage_1_2.ToString().SelfArray());

            //burp
            Ability burp = new Ability("Pinano_Burp_A")
            {
                Name = "Burp",
                Description = "Produce 2 Yellow Pigment.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Yellow), 2, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                AnimationTarget = Slots.Self,
            };
            burp.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Mana_Generate.ToString().SelfArray());

            //ADD ENEMY
            minana.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                thrash.GenerateEnemyAbility(true),
                burp.GenerateEnemyAbility()
            });
            minana.AddEnemy(true, true, true);
        }
    }
}
