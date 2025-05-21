using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Solitaire
    {
        public static void Add()
        {
            SolitaireHandler.Setup();
            Enemy tv = new Enemy("Solitaire", "Solitaire_EN")
            {
                Health = 20,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("SolitaireIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SolitaireDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SolitaireWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sund/SolitaireHit",
                DeathSound = "event:/Hawthorne/Sund/SolitaireDie",
            };
            tv.PrepareMultiEnemyPrefab("Assets/enem3/Solitaire_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Solitaire_Gibs.prefab").GetComponent<ParticleSystem>());
            (tv.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                tv.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").GetComponent<SpriteRenderer>(),
            };

            Enemy child = new Enemy("Spades", "Spades_EN")
            {
                Health = 10,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("SpadesIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SpadesDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SpadesWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sund/SolitaireHit",
                DeathSound = "event:/Hawthorne/Sund/SolitaireDie",
            };
            child.PrepareEnemyPrefab("Assets/enem3/Spades_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Spades_Gibs.prefab").GetComponent<ParticleSystem>());
            child.enemy.enemyTemplate.m_Data.m_Renderer = child.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").GetComponent<SpriteRenderer>();
            child.AddPassive(Passives.TwoFaced);
            child.AddPassive(Passives.Withering);
            child.CombatExitEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SolitaireExitEffect>(), 1, Slots.Self).SelfArray();

            //decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = PassiveType_GameIDs.Decay.ToString();
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay._enemyDescription = "On death, 30% chance to spawn a Spades.";
            decay._characterDescription = decay._enemyDescription;
            decay.doesPassiveTriggerInformationPanel = true;
            decay.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<SolitaireSpecialDecayCondition>() };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            SpawnEnemyInSlotFromEntryStringNameEffect spawnspades = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
            spawnspades.en = "Spades_EN";
            decay.effects = Effects.GenerateEffect(spawnspades, 0, Slots.Self).SelfArray();

            AbilitySelector_Heaven selector = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            selector._ComeHomeAbility = "Dreamers_A";
            selector._useAfterTurns = 2;
            tv.AbilitySelector = selector;
            tv.AddPassives(new BasePassiveAbilitySO[] { Passives.TwoFaced, Passives.Forgetful, Passives.Dying, decay });
            tv.CombatExitEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SolitaireExitEffect>(), 1, Slots.Self).SelfArray();

            //sob
            EnemyAbilityInfo sob = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Sob_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //radio
            Ability radio = new Ability("Radio", "Radio_A");
            radio.Description = "Produce 1 random Pigment. Move to the Left or Right.";
            radio.Rarity = Rarity.GetCustomRarity("rarity5");
            radio.Effects = new EffectInfo[2];
            radio.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<LoadIntoFutureEffect>(), 1, Slots.Self);
            radio.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            radio.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);
            radio.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            radio.AnimationTarget = Slots.Self;

            //anon
            Ability anon = new Ability("Anonymity", "Anonymity_A");
            anon.Description = "If this enemy is not defended by Shield, apply 8 Shield to this enemy's position.";
            anon.Rarity = radio.Rarity;
            anon.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 8, Slots.Self, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.Shield_ID.ToString(), 0, false, true)).SelfArray();
            anon.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Field_Shield.ToString()]);
            anon.Visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;
            anon.AnimationTarget = Slots.Self;

            //entropy
            Ability entropy = new Ability("Entropic Measurement", "EntropicMeasurement_A");
            entropy.Description = "This enemy chooses a random Pigment color. \nUntil this enemy changes its color or leaves combat, party members using this Pigment color inflict 1 random Status Effect on themselves.";
            entropy.Rarity = radio.Rarity;
            entropy.Effects = new EffectInfo[1];
            entropy.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<LoadIntoPresentEffect>(), 1, Slots.Self);
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_Red", Intents.GetInGame_IntentInfo(IntentType_GameIDs.Misc)._sprite, Color.red);
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_Blue", Intents.GetInGame_IntentInfo(IntentType_GameIDs.Misc)._sprite, Color.blue);
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_Yellow", Intents.GetInGame_IntentInfo(IntentType_GameIDs.Misc)._sprite, Color.yellow);
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_Purple", Intents.GetInGame_IntentInfo(IntentType_GameIDs.Misc)._sprite, Color.magenta);
            entropy.AddIntentsToTarget(Slots.Self, [FallColor.Intent3, "Misc_Red", "Misc_Blue", "Misc_Yellow", "Misc_Purple"]);
            entropy.Visuals = CustomVisuals.GetVisuals("Salt/Censor");
            entropy.AnimationTarget = Slots.Self;

            //scanner
            Ability scanner = new Ability("Dream Scanner", "DreamScanner_A");
            scanner.Description = "Deal damage to the Opposing party member equal to the amount of times any Solitaire has taken any damage this run.";
            scanner.Rarity = radio.Rarity;
            scanner.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DreamScannerEffect>(), 1, Slots.Front).SelfArray();
            scanner.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString()]);
            scanner.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            scanner.AnimationTarget = Slots.Front;

            Intents.CreateAndAddCustom_Basic_IntentToPool("Dreaming_A", ResourceLoader.LoadSprite("ExitIntent.png"), Color.white);

            //tp garden cuz fuck you
            Ability dreamers = new Ability("A Dream Within A Dream", "Dreamers_A");
            dreamers.Description = "\"Somewhere better than here\"";
            dreamers.Rarity = Rarity.GetCustomRarity("rarity5");
            dreamers.Priority = Priority.CreateAndAddCustomPriorityToPool("Solitaire_SupeSlow", -10);
            dreamers.Effects = new EffectInfo[7];
            dreamers.Effects[0] = Effects.GenerateEffect(BasicEffects.SetStoreValue("Dreamer_A"), 1, Slots.Self);
            dreamers.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Curtains", false, Slots.Self));
            dreamers.Effects[2] = Effects.GenerateEffect(UIActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToGardenEffect>(), 1, Slots.Self).SelfArray()), 1, Targeting.Slot_SelfSlot);
            dreamers.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 15, Slots.Self);
            dreamers.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<BoxAllEnemiesEffect>());
            dreamers.Effects[5] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnGardenEnemyBundleEffect>());
            dreamers.Effects[6] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Targeting.Unit_AllOpponents);
            dreamers.AddIntentsToTarget(Slots.Self, ["Dreaming_A", IntentType_GameIDs.Damage_11_15.ToString()]);
            dreamers.AddIntentsToTarget(Targeting.Unit_AllOpponents, [IntentType_GameIDs.Status_Focused.ToString()]);
            dreamers.Visuals = null;
            dreamers.AnimationTarget = Slots.Self;


            //ADD ENEMY
            tv.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                //sob,
                radio.GenerateEnemyAbility(true),
                //anon.GenerateEnemyAbility(true),
                entropy.GenerateEnemyAbility(true),
                scanner.GenerateEnemyAbility(true),
                dreamers.GenerateEnemyAbility(true),
            });
            tv.AddEnemy(true, true);

            child.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                entropy.GenerateEnemyAbility(false),
                dreamers.GenerateEnemyAbility(false)
            });
            child.AddEnemy(true, true, true);
        }
    }
}
