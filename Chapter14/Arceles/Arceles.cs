using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Arceles
    {
        public static void Add()
        {
            Enemy boat = new Enemy("Arceles", "Arceles_EN")
            {
                Health = 7,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("BoatIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BoatWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BoatDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Merced_EN").deathSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
            };
            boat.PrepareEnemyPrefab("assets/train/Boat_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/train/Boat_Gibs.prefab").GetComponent<ParticleSystem>());

            //bonus attack
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility knock = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            knock._passiveName = "Knock";
            knock._enemyDescription = "This enemy will perforn an extra ability \"Knock\" each turn.";
            Ability bonus = new Ability("Knock_A");
            bonus.Name = "Knock";
            bonus.Description = "Deal a Little damage to the Opposing party member and move them to the Left or Right.";
            bonus.Priority = Priority.Slow;
            bonus.Effects = new EffectInfo[2];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front);
            bonus.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front);
            bonus.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);
            bonus.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            bonus.AnimationTarget = Slots.Front;
            bonus.Rarity = Rarity.Impossible;
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            knock._extraAbility.ability = ability;


            boat.AddPassives(new BasePassiveAbilitySO[] { knock });

            //windy day
            Ability windy = new Ability("WindyDay_A")
            {
                Name = "Windy Day",
                Description = "Move to the Left or Right. Inflict 2 Slip on the Left and Right enemy positions.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 2, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Sides)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                AnimationTarget = Slots.Self,
            };
            windy.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);
            windy.AddIntentsToTarget(Slots.Sides, [Slip.Intent]);

            //drift
            Ability drift = new Ability("Adrift_A")
            {
                Name = "Adrift",
                Description = "Inflict 3 Slip on the Opposing party member position. Inflict 2 Ruptured on the Left and Right party members.",
                Rarity = windy.Rarity,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.LeftRight)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                AnimationTarget = Slots.Front,
            };
            drift.AddIntentsToTarget(Slots.Front, [Slip.Intent]);
            drift.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Status_Ruptured.ToString()]);

            //rush
            Ability rush = new Ability("Boat_Rush_A")
            {
                Name = "Rush",
                Description = "Move to Right. Inflict 4 Left on the Opposing party member, then move to the Left or Right.",
                Rarity = windy.Rarity,
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Shatter", false, Slots.Front), 1, Slots.Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 4, Slots.Front),
                            Effects.GenerateEffect(SubActionEffect.Create(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self) }), 1, Slots.Self)
                        },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            rush.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Right.ToString()]);
            rush.AddIntentsToTarget(Slots.Front, [Left.Intent]);
            rush.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);

            //ADD ENEMY
            boat.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                windy.GenerateEnemyAbility(true),
                drift.GenerateEnemyAbility(true),
                rush.GenerateEnemyAbility(true)
            });
            boat.AddEnemy(true, true);
        }
    }
}
