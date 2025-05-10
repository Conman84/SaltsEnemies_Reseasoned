using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Chiito
    {
        public static void Add()
        {
            Enemy chiito = new Enemy("Chiito", "Chiito_EN")
            {
                Health = 20,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ChiitoIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ChiitoDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ChiitoWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Keko_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Keko_EN").deathSound
            };
            chiito.PrepareEnemyPrefab("Assets/enem3/Chiito_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Chiito_Gibs.prefab").GetComponent<ParticleSystem>());

            //stealth
            Connection_PerformEffectPassiveAbility stealth = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            stealth._passiveName = "Stealth Mechanics";
            stealth.passiveIcon = ResourceLoader.LoadSprite("StealthPassive.png");
            stealth.m_PassiveID = "StealthMechanics_PA";
            stealth._enemyDescription = "At the start of combat, instantly flee.";
            stealth._characterDescription = stealth._enemyDescription;
            stealth._triggerOn = [TriggerCalls.Count];
            stealth.disconnectionEffects = new EffectInfo[0];
            stealth.connectionEffects = new EffectInfo[2];
            stealth.connectionEffects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<StealthPassiveEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<TurnOneCondition>());
            stealth.connectionEffects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<TurnOneCondition>());

            //LAZY
            PerformEffectPassiveAbility lazy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            lazy._passiveName = "Lazy";
            lazy.passiveIcon = ResourceLoader.LoadSprite("Lazy.png");
            lazy._enemyDescription = "When fleeing, this enemy will return at the end of the next 2 rounds if combat hasn't ended.";
            lazy._characterDescription = "When fleeing, this character will return at the end of the next 2 rounds if combat hasn't ended.";
            lazy.m_PassiveID = ButterflyUnboxer.SkyloftPassive;
            lazy.doesPassiveTriggerInformationPanel = true;
            lazy._triggerOn = new TriggerCalls[] { TriggerCalls.OnFleeting };
            lazy.effects = new EffectInfo[0];
            lazy.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<NotFlitheringCondition>() };

            chiito.AddPassives(new BasePassiveAbilitySO[] { stealth, Passives.Slippery, lazy });

            //gutting
            HealEffect exitHeal = ScriptableObject.CreateInstance<HealEffect>();
            exitHeal.usePreviousExitValue = true;

            Ability gutting = new Ability("Gutting", "Gutting_A");
            gutting.Description = "Deal an Agonizing amount of damage to the Opposing party member and heal this enemy for the amount of damage dealt.\nIf no damage is dealt, instantly flee.";
            gutting.Rarity = Rarity.GetCustomRarity("rarity5");
            gutting.Effects = new EffectInfo[3];
            gutting.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front);
            gutting.Effects[1] = Effects.GenerateEffect(exitHeal, 1, Slots.Self);
            gutting.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self, BasicEffects.DidThat(false, 2));
            gutting.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString()]);
            gutting.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Heal_5_10.ToString(), IntentType_GameIDs.PA_Fleeting.ToString()]);
            gutting.Visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals;
            gutting.AnimationTarget = Slots.Front;

            Ability fracking = new Ability("Fracking", "Fracking_A");
            fracking.Description = "Move to the Left or Right 3 times. If there is an Opposing party member, deal a Painful amount of damage to them and instantly flee.";
            fracking.Rarity = Rarity.GetCustomRarity("rarity5");
            fracking.Effects = new EffectInfo[7];
            fracking.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            fracking.Effects[1] = fracking.Effects[0];
            fracking.Effects[2] = fracking.Effects[0];
            fracking.Effects[3] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Drill", false, Slots.Front));
            fracking.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, Slots.Front);
            fracking.Effects[5] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front, BasicEffects.DidThat(true));
            fracking.Effects[6] = Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self, BasicEffects.DidThat(true, 2));
            fracking.AddIntentsToTarget(Slots.Self, ["Swap_Sides", "Swap_Sides", "Swap_Sides"]);
            fracking.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            fracking.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.PA_Fleeting.ToString()]);
            fracking.Visuals = null;
            fracking.AnimationTarget = Slots.Self;

            //nibble
            EnemyAbilityInfo nibble = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Nibble_A"),
                rarity = Rarity.CreateAndAddCustomRarityToPool("chiito_2", 2)
            };

            //ADD ENEMY
            chiito.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                gutting.GenerateEnemyAbility(true),
                fracking.GenerateEnemyAbility(true),
                nibble
            });
            chiito.AddEnemy(true, true);
        }
    }
}
