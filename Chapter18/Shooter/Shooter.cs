using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Shooter
    {
        public static void Add()
        {
            Enemy skeleton = new Enemy("Skeleton Shooter", "SkeletonShooter_EN")
            {
                Health = 20,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("ShooterIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ShooterWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ShooterDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noisy/Bone_Hit",
                DeathSound = "event:/Hawthorne/Noisy/Bone_Death",
            };
            skeleton.PrepareEnemyPrefab("assets/enemie/Shooter_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Shooter_Gibs.prefab").GetComponent<ParticleSystem>());

            //sniper
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility sniper = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            sniper._passiveName = "Sniper";
            sniper._enemyDescription = "This enemy will peform the extra ability \"Sniper\" each turn.";
            Ability bonus = new Ability("Sniper_A");
            bonus.Name = "Sniper";
            bonus.Description = "Summon a Skeleton Head.";
            bonus.Priority = Priority.Slow;
            bonus.Effects = new EffectInfo[1];
            SpawnEnemyByStringNameEffect spawn = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            spawn.enemyName = "SkeletonHead_EN";
            bonus.Effects[0] = Effects.GenerateEffect(spawn, 1, Slots.Self);
            bonus.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Other_Spawn.ToString().SelfArray());
            bonus.Visuals = CustomVisuals.GetVisuals("Salt/Curse");
            bonus.AnimationTarget = Slots.Self;
            bonus.Rarity = Rarity.CreateAndAddCustomRarityToPool("sniper_0", 0);
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            sniper._extraAbility.ability = ability;

            skeleton.AddPassives(new BasePassiveAbilitySO[] { sniper });

            //coward
            IsFrontTargetCondition front = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
            front.returnTrue = true;
            Ability coward = new Ability("Coward_A")
            {
                Name = "Coward",
                Description = "If there is an Opposing party member, apply 10 Shield to this enemy's position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Slots.Self, front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Weep_A", false, Slots.Self), 1, Slots.Self, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, Slots.Self, BasicEffects.DidThat(true, 2))
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            coward.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Field_Shield.ToString().SelfArray());

            //opportunist
            Ability opportunist = new Ability("Opportunist_A")
            {
                Name = "Opportunist",
                Description = "If there is an Opposing party member, apply 5 Shield on the Left and Right enemy positions and move Left or Right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Slots.Self, front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Notif", false, Slots.Self), 1, Slots.Self, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, Slots.Sides, BasicEffects.DidThat(true, 2)),
                    Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                    }), 1, Slots.Self, BasicEffects.DidThat(true, 3)),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            opportunist.AddIntentsToTarget(Slots.Sides, IntentType_GameIDs.Field_Shield.ToString().SelfArray());
            opportunist.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());

            //bash
            EnemyAbilityInfo bash = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Bash_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //ADD ENEMY
            skeleton.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                coward.GenerateEnemyAbility(true),
                opportunist.GenerateEnemyAbility(true),
                bash
            });
            skeleton.AddEnemy(true, true);
        }
    }
}
