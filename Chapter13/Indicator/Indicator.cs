using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Indicator
    {
        public static void Add()
        {
            Enemy nerve = new Enemy("Indicator", "Indicator_EN")
            {
                Health = 22,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("IndicatorIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("IndicatorWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("IndicatorDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Soisenay/IndicatorHit",
                DeathSound = "event:/Hawthorne/Soisenay/IndicatorDie",
            };
            nerve.PrepareEnemyPrefab("assets/group4/Indicator/Indicator_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Indicator/Indicator_Gibs.prefab").GetComponent<ParticleSystem>());
            nerve.enemy.enemyTemplate.m_Data.m_Renderer = nerve.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("Sprite").Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();
            
            //compulsory
            PerformEffectPassiveAbility com = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            com._passiveName = "Compulsory";
            com.m_PassiveID = "Compulsory_PA";
            com.passiveIcon = ResourceLoader.LoadSprite("IndicatorPassive.png");
            com._enemyDescription = "On an Opponent moving in front of this enemy, force the Opposing unit to perform a random ability.";
            com._characterDescription = com._enemyDescription;
            com.doesPassiveTriggerInformationPanel = true;
            //com.effects = Effects.GenerateEffect(SubActionEffect.Create(new EffectInfo[] { Effects.GenerateEffect(CasterRootActionEffect.Create(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, Slots.Self) }), 1, Slots.Self) }), 1, Slots.Front).SelfArray();
            com.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, Slots.Front)];
            com._triggerOn = new TriggerCalls[1] { (TriggerCalls)AmbushManager.Patiently };

            //spasm
            PerformEffectPassiveAbility spasm = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            spasm._passiveName = "Spasm";
            spasm.m_PassiveID = "Spasm_PA";
            spasm.passiveIcon = ResourceLoader.LoadSprite("SpasmPassive.png");
            spasm._enemyDescription = "On death, all living enemies will attempt to prematurely perform their next turn then gain another action on the timeline if succesful.";
            spasm._characterDescription = "doesnt work";
            spasm.doesPassiveTriggerInformationPanel = true;
            spasm.effects = [
                Effects.GenerateEffect(SubActionEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<LivingTargetForceFirstActionEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(CasterRootActionEffect.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self)]), 1, Slots.Self, BasicEffects.DidThat(true))
                    ]), 1, Targeting.Unit_AllAllies)
                ];
            spasm._triggerOn = [TriggerCalls.OnDeath];
            DeathReferenceDetectionEffectorCondition noWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            noWither._useWithering = true;
            noWither._witheringDeath = false;
            spasm.conditions = [noWither];


            nerve.AddPassives(new BasePassiveAbilitySO[] { com, Passives.Slippery, Passives.Forgetful, spasm });

            AbilitySelector_Heaven selector = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            selector._ComeHomeAbility = "TransmitSensory_A";
            selector._useAfterTurns = 1;

            nerve.AbilitySelector = selector;

            //transmit pain
            RemoveStatusEffectEffect noLink = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            noLink._status = StatusField.Linked;

            Ability pain = new Ability("TransmitPain_A")
            {
                Name = "Transmit Pain",
                Description = "Attempt to remove Linked from the Opposing party member. If successful, deal an Agonizing amount of damage to the Opposing party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(noLink, 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.Front, BasicEffects.DidThat(true))
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Ribbon"),
                AnimationTarget = Slots.Front,
            };
            pain.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Rem_Status_Linked.ToString(), IntentType_GameIDs.Damage_7_10.ToString()]);


            ChangeHealthColorEffect turnRed = ChangeHealthColorEffect.Create(Pigments.Red);
            //transmit sensory
            Ability sensory = new Ability("TransmitSensory_A")
            {
                Name = "Transmit Sensory",
                Description = "If this enemy is not Withering, gain Withering as a passive and spawn a clone of this enemy.\nTurn Red.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("indicator 1", 1),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.AddPassive(Passives.Withering), 1, Slots.Self, ScriptableObject.CreateInstance<EmptyEnemySpaceNoWitheringEffectCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyCopySelfEffect>(), 1, Slots.Self, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(turnRed, 1, Slots.Self),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals,
                AnimationTarget = Slots.Self,
            };
            sensory.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.PA_Withering.ToString(), IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Mana_Modify.ToString()]);

            //emotional
            Ability emotion = new Ability("TransmitEmotion_A")
            {
                Name = "Transmit Emotion",
                Description = "Inflict 4 Slip on the Opposing position.\nForce the Opposing party member to perform a random one of their abilities.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 4, Slots.Front),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, Slots.Front)
                    },
                Visuals = CustomVisuals.GetVisuals("Salt/Rose"),
                AnimationTarget = Slots.Front,
            };
            emotion.AddIntentsToTarget(Slots.Front, [Slip.Intent, SkyloftIntent.Intent]);

            //hunger
            Ability hunger = new Ability("TransmitHunger_A")
            {
                Name = "Transmit Hunger",
                Description = "Inflict 6 Linked to the Left and Right party members and move them to random positions.",
                Rarity = Rarity.GetCustomRarity("rarity8"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 6, Slots.LeftRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneFoolEffect>(), 1, Slots.LeftRight)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals,
                AnimationTarget = Slots.LeftRight,
            };
            hunger.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Status_Linked.ToString(), IntentType_GameIDs.Swap_Mass.ToString()]);

            //ADD ENEMY
            nerve.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                pain.GenerateEnemyAbility(true),
                sensory.GenerateEnemyAbility(true),
                emotion.GenerateEnemyAbility(true),
                hunger.GenerateEnemyAbility(true)
            });
            nerve.AddEnemy(true, true);
        }
    }
}
