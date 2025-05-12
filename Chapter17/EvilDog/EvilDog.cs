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

            //nylon
            PerformEffectPassiveAbility nylon = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            nylon._passiveName = "Nylon";
            nylon.m_PassiveID = "Nylon_PA";
            nylon.passiveIcon = ResourceLoader.LoadSprite("NylonPassive.png");
            nylon._enemyDescription = "On being directly damaged, apply 1 Slip on the Opposing position.";
            nylon._characterDescription = nylon._enemyDescription;
            nylon.doesPassiveTriggerInformationPanel = true;
            nylon.effects = Effects.GenerateEffect(RootActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front).SelfArray()), 1, Slots.Self).SelfArray();
            nylon._triggerOn = [TriggerCalls.OnDirectDamaged];

            //addpassives
            dog.AddPassives(new BasePassiveAbilitySO[] { Passives.TwoFaced, warp, nylon, Passives.Slippery });

            //ringer
            Ability ringer = new Ability("Ringer", "Ringer_A");
            ringer.Description = "Apply 1 Slip on the Opposing position.\nIf there was already Slip on the Opposing position, queue the ability \"Flip Flop\" and move to the Left or Right.";
            ringer.Rarity = Rarity.GetCustomRarity("rarity5");
            ringer.Effects = new EffectInfo[3];
            ringer.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front);
            ringer.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<FlipFlopEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<FrontHas2SlipEffectCondition>());
            ringer.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self, BasicEffects.DidThat(true));
            ringer.AddIntentsToTarget(Slots.Front, [Slip.Intent]);
            ringer.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Hidden.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);
            ringer.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            ringer.AnimationTarget = Slots.Front;

            //flipflop
            Ability flip = new Ability("Flip Flop", "FlipFlop_A");
            flip.Description = "If either the Left and Right party member positions have Slip, queue the ability \"Toggle\".\nOtherwise, queue the ability \"Ringer\".";
            flip.Rarity = Rarity.GetCustomRarity("rarity5");
            flip.Effects = new EffectInfo[2];
            flip.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ToggleEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<LRHas1SlipEffectCondition>());
            flip.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RingerEffect>(), 1, Slots.Self, BasicEffects.DidThat(false));
            flip.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            flip.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            flip.AnimationTarget = Slots.LeftRight;

            //toggle
            Ability pain = new Ability("Toggle", "Toggle_A");
            pain.Description = "If there is Slip on the Opposing position, deal an Agonizing amount of damage to the Opposing party member and move them to the Left or Right.\nOtherwise, queue the ability \"Ringer\".";
            pain.Rarity = Rarity.GetCustomRarity("rarity5");
            pain.Effects = new EffectInfo[5];
            pain.Effects[0] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Drill", false, Slots.Front), 0, null, ScriptableObject.CreateInstance<FrontHas1SlipEffectCondition>());
            pain.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.Front, BasicEffects.DidThat(true));
            pain.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front, BasicEffects.DidThat(true, 2));
            pain.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RingerEffect>(), 1, Slots.Self, BasicEffects.DidThat(false, 4));
            pain.Effects[3] = Effects.GenerateEffect(BasicEffects.GetVisuals("Wriggle_A", false, Slots.Self), 0, null, BasicEffects.DidThat(false, 3));
            pain.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Misc_Hidden.ToString(), IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);
            pain.Visuals = null;
            pain.AnimationTarget = Slots.Front;

            //ADD ENEMY
            dog.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                ringer.GenerateEnemyAbility(true),
                flip.GenerateEnemyAbility(true),
                pain.GenerateEnemyAbility(true)
            });
            dog.AddEnemy(true, true);
        }
    }
}
