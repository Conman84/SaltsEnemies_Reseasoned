using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Whale
    {
        public static ParticleSystem Collisionless;
        public static void Add()
        {
            Enemy whale = new Enemy("The Whale", "TheWhale_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("WhaleIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("WhaleWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("WhaleDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TheDeep_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TheDeep_EN").deathSound,
            };
            whale.PrepareEnemyPrefab("Assets/wip5/Whale_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Whale_Wip_Gibs.prefab").GetComponent<ParticleSystem>());
            Collisionless = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Whale_Far_Wip_Gibs.prefab").GetComponent<ParticleSystem>();

            whale.CombatEnterEffects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<WhaleEnterEffect>())];

            Ability descent = new Ability("Descent", "Whale_Descent_A");
            descent.Name = "Descent";
            descent.Description = "If this ability is used 3 or more times, deal a Painful amount of damage to all party members.";
            descent.Rarity = Rarity.CreateAndAddCustomRarityToPool("whale_high", 20);
            descent.Effects = [
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Anchoring", false, Targetting.Everything(false)), 0, Slots.Self, ScriptableObject.CreateInstance<WhaleCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targetting.Everything(false), BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<WhaleEffect>())
                ];
            descent.AddIntentsToTarget(Slots.Self, ["Misc_Hidden"]);
            descent.AddIntentsToTarget(Targetting.Everything(false), ["Damage_3_6"]);
            descent.Visuals = null;
            descent.AnimationTarget = Slots.Self;

            //ADD ENEMY
            whale.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                descent.GenerateEnemyAbility(true),
            });
            whale.SilentAddEnemy(true, true);
        }
    }
}
