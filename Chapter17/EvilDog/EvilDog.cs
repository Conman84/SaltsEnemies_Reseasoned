using BrutalAPI;
using SaltEnemies_Reseasoned.SendingOver17;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Diagnostics.Contracts;

namespace SaltsEnemies_Reseasoned
{
    public static class EvilDog
    {
        public static void Add()
        {
            Enemy dog = new Enemy("Chien Tindalou", "EvilDog_EN")
            {
                Health = 30,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("EvilDogIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("EvilDogWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("EvilDogDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").damageSound,
            };
            dog.PrepareEnemyPrefab("assets/enemie/EvilDog_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/EvilDog_Gibs.prefab").GetComponent<ParticleSystem>());

            //warping
            PerformEffectPassiveAbility warp = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            warp._passiveName = "Warping";
            warp.m_PassiveID = WarpingHandler.Type;
            warp.passiveIcon = WarpingHandler.Icon;
            warp._enemyDescription = "Whenever anything damages this enemy, move the attacker to the Left or Right.";
            warp._characterDescription = warp._enemyDescription;
            warp.doesPassiveTriggerInformationPanel = false;
            warp.effects = new EffectInfo[0];
            warp._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
            warp.conditions = new EffectorConditionSO[0];

            //addpassives
            dog.AddPassives(new BasePassiveAbilitySO[] { Passives.TwoFaced, warp, Passives.Slippery });

            //ring
            Ability ring = new Ability("RingingNoise_A")
            {
                Name = "Ringing Noise",
                Description = "Apply 1 Slip on the Opposing position. \nDeal a Little damage to this enemy and inflict 1 Scar on it. \n50% chance to queue this ability again.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<RingingNoiseEffect>(), 1, Slots.Self, Effects.ChanceCondition(50))
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Class"),
                AnimationTarget = Slots.Front,
            };
            ring.AddIntentsToTarget(Slots.Front, [Slip.Intent]);
            ring.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Scars.ToString(), IntentType_GameIDs.Misc.ToString()]);

            //flipflop
            Ability flip = new Ability("Flip Flop", "FlipFlop_A");
            flip.Description = "Apply 1 Slip on the Left or Right positions if they have no Slip.\nInflict 1 Constricted on the Opposing position.\nIf the Opposing position already had Constricted, queue the ability \"Stinging Pain\".";
            flip.Rarity = ring.Rarity;
            flip.Effects = new EffectInfo[3];
            flip.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipIfNoneEffect>(), 1, Slots.LeftRight);
            flip.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Front);
            flip.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<StingingPainEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<FrontHas2ConstrictedEffectCondition>());
            flip.AddIntentsToTarget(Slots.LeftRight, [Slip.Intent]);
            flip.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Misc_Hidden.ToString()]);
            flip.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc.ToString()]);
            flip.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            flip.AnimationTarget = Slots.FrontLeftRight;

            Ability pain = new Ability("Stinging Pain", "StingingPain_A");
            pain.Description = "Deal an Agonizing amount of damage and inflict 1 Slip on the Opposing position.\nIf the Opposing position already had Slip, move Left or Right and queue the ability \"Flip Flop\".";
            pain.Rarity = ring.Rarity;
            pain.Effects = new EffectInfo[4];
            pain.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.Front);
            pain.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front);
            pain.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapSidesReturnTrueEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<FrontHas2SlipEffectCondition>());
            pain.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<FlipFlopEffect>(), 1, Slots.Self, BasicEffects.DidThat(true));
            pain.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString(), Slip.Intent, IntentType_GameIDs.Misc_Hidden.ToString()]);
            pain.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Misc.ToString()]);
            pain.Visuals = CustomVisuals.GetVisuals("Salt/Drill");
            pain.AnimationTarget = Slots.Front;

            //ADD ENEMY
            dog.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                ring.GenerateEnemyAbility(true),
                flip.GenerateEnemyAbility(true),
                pain.GenerateEnemyAbility(true)
            });
            dog.AddEnemy(true, true);
        }
    }
}
