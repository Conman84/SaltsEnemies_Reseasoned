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
                Health = 8,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("BoatIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BoatWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BoatDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Merced_EN").deathSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound,
            };
            boat.PrepareEnemyPrefab("assets/train/Boat_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/train/Boat_Gibs.prefab").GetComponent<ParticleSystem>());

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

            //nylon
            PerformEffectPassiveAbility nylon = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            nylon._passiveName = "Nylon (3)";
            nylon.m_PassiveID = "Nylon_PA";
            nylon.name = "Nylon_3_PA";
            nylon.passiveIcon = ResourceLoader.LoadSprite("NylonPassive.png");
            nylon._enemyDescription = "On being directly damaged, apply 3 Slip on the Opposing position.";
            nylon._characterDescription = nylon._enemyDescription;
            nylon.doesPassiveTriggerInformationPanel = false;
            nylon.effects = Effects.GenerateEffect(CasterRootActionEffect.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<NylonPassiveEffect>()), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 3, Slots.Front)]), 1, Slots.Self).SelfArray();
            nylon._triggerOn = [TriggerCalls.OnDirectDamaged];
            nylon.AddToPassiveDatabase();

            boat.AddPassives(new BasePassiveAbilitySO[] { nylon, knock });

            //windy day
            Ability windy = new Ability("WindyDay_A")
            {
                Name = "Windy Day",
                Description = "Move to the Left or Right. Inflict 3 Slip on this enemy's position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 2, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                AnimationTarget = Slots.Self,
            };
            windy.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString(), Slip.Intent]);

            //drift
            Ability drift = new Ability("Adrift_A")
            {
                Name = "Adrift",
                Description = "Inflict 2 Slip on the Left and Right party member positions.",
                Rarity = windy.Rarity,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.LeftRight),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                AnimationTarget = Slots.LeftRight,
            };
            drift.AddIntentsToTarget(Slots.LeftRight, [Slip.Intent]);

            //rush
            Ability rush = new Ability("Boat_Rush_A")
            {
                Name = "Rush",
                Description = "Inflict 1 Left on the Left, Right, and Opposing party members.",
                Rarity = windy.Rarity,
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 1, Slots.FrontLeftRight),
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Shatter"),
                AnimationTarget = Slots.FrontLeftRight,
            };
            rush.AddIntentsToTarget(Slots.FrontLeftRight, [Left.Intent]);

            //ADD ENEMY
            boat.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                windy.GenerateEnemyAbility(true),
                drift.GenerateEnemyAbility(true),
                rush.GenerateEnemyAbility(true)
            });
            boat.AddEnemy(true, true);
            boat.enemy.AddToSynodPool();
            boat.enemy.AddToToysPool();
        }
    }
}
