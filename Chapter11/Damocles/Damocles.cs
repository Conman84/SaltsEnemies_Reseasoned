using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Damocles
    {
        public static void Add()
        {
            Enemy sword = new Enemy("Damocles", "Damocles_EN")
            {
                Health = 30,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("DamoclesIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DamoclesWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DamoclesDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound/StarlessHit",
                DeathSound = "event:/Hawthorne/Sound/StarlessDie",
            };
            sword.PrepareEnemyPrefab("assets/group4/Damocles/Damocles_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Damocles/Damocles_Gibs.prefab").GetComponent<ParticleSystem>());
            sword.enemy.enemyTemplate.m_Data.m_Renderer = sword.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Moon").GetComponent<SpriteRenderer>();


            //FALL
            PerformEffectPassiveAbility damocles = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            damocles._passiveName = "Closure";
            damocles.passiveIcon = ResourceLoader.LoadSprite("DamoclesPassive.png");
            damocles.m_PassiveID = "Closure_PA";
            damocles._enemyDescription = "On taking any amount of damage, there is a 50% chance that this enemy instantly dies then deals the amount of damage taken to the Opposing party member.";
            damocles._characterDescription = "On taking any amount of damage, there is a 50% chance that this party member instantly dies then deals the amount of damage taken to the Opposing enemy.";
            damocles.doesPassiveTriggerInformationPanel = false;
            damocles.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<DamoclesCondition>() };
            damocles._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDamaged };

            //decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            decay._enemyDescription = "Upon dying, this enemy decays into 2 copies of itself.";
            decay._characterDescription = "On dying, nothing happens. This effect won't work on party members. Be glad it doesnt break the game.";
            decay.doesPassiveTriggerInformationPanel = true;
            decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            DeathReferenceDetectionEffectorCondition detectWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            detectWither._witheringDeath = false;
            detectWither._useWithering = true;
            decay.conditions = new EffectorConditionSO[]
            {
                detectWither
            };
            DelayRespawnEffect spawn = ScriptableObject.CreateInstance<DelayRespawnEffect>();
            SpawnEnemyInSlotFromEntryStringNameEffect newD = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
            newD.en = "Damocles_EN";
            SpawnSelfEnemyAnywhereEffect copy = ScriptableObject.CreateInstance<SpawnSelfEnemyAnywhereEffect>();
            decay.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(newD, 0, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(copy, 1, Targeting.Slot_SelfSlot),
            };

            sword.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, damocles, Passives.Withering, decay });

            //fall
            Ability fall = new Ability("Fall", "Fall_A");
            fall.Description = "Deal 0-20 damage to this enemy.";
            fall.Rarity = Rarity.CreateAndAddCustomRarityToPool("damocles3", 3);
            fall.Effects = new EffectInfo[2];
            fall.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0);
            fall.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 20, Targeting.Slot_SelfSlot);
            fall.AddIntentsToTarget(Slots.Self, [FallColor.Intent, IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Damage_11_15.ToString(), IntentType_GameIDs.Damage_16_20.ToString()]);
            fall.Visuals = null;
            fall.AnimationTarget = Slots.Self;

            //dangle
            Ability dangle = new Ability("Dangle", "Dangle_A");
            dangle.Description = "Inflict 2-3 Frail and 4-6 Scars on this enemy.";
            dangle.Rarity = Rarity.GetCustomRarity("rarity5");
            dangle.Effects = new EffectInfo[5];
            dangle.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Slots.Self);
            dangle.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, Slots.Self, Effects.ChanceCondition(50));
            dangle.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 4, Slots.Self);
            dangle.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self, Effects.ChanceCondition(50));
            dangle.Effects[4] = dangle.Effects[3];
            dangle.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Status_Scars.ToString()]);
            dangle.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            dangle.AnimationTarget = Targeting.Slot_SelfAll;

            //pasts
            Ability pasts = new Ability("Pasts", "Pasts_A");
            pasts.Description = "Deal a Little damage to all enemies at full health.";
            pasts.Rarity = Rarity.GetCustomRarity("damocles3");
            pasts.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targetting_ByUnit_Side_FullHealth.Create(true)).SelfArray();
            pasts.AddIntentsToTarget(Targetting_ByUnit_Side_FullHealth.Create(true), [IntentType_GameIDs.Damage_1_2.ToString()]);
            pasts.AddIntentsToTarget(Targetting.AllAlly, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            pasts.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            pasts.AnimationTarget = Targetting_ByUnit_Side_FullHealth.Create(true);

            //future
            Ability futures = new Ability("Futures", "Futures_A");
            futures.Description = "At the start of the next turn, deal a Painful amount of damage to this enemy's current Opposing position.\nMove to the Left or Right.";
            futures.Rarity = Rarity.GetCustomRarity("rarity5");
            futures.Effects = new EffectInfo[2];
            futures.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, Slots.Front);
            futures.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            futures.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), "Damage_Delay"]);
            futures.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);
            futures.AnimationTarget = Slots.Front;
            futures.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;

            //ADD ENEMY
            sword.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                pasts.GenerateEnemyAbility(true),
                dangle.GenerateEnemyAbility(true),
                futures.GenerateEnemyAbility(true),
                fall.GenerateEnemyAbility(true)
            });
            sword.AddEnemy(true, true);
        }
    }
}
