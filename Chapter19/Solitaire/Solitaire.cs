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
                CombatSprite = ResourceLoader.LoadSprite("PawnIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PawnWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PawnDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/DeadPixelHurt",
                DeathSound = "event:/Hawthorne/Die/DeadPixelDie",
            };
            tv.PrepareEnemyPrefab("Assets/enem3/Solitaire_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Pawn_Gibs.prefab").GetComponent<ParticleSystem>());

            AbilitySelector_Heaven selector = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            selector._ComeHomeAbility = "Dreamers_A";
            selector._useAfterTurns = 1;
            tv.AbilitySelector = selector;
            tv.AddPassives(new BasePassiveAbilitySO[] { Passives.TwoFaced, Passives.Forgetful, Passives.Dying });

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
            GenerateRandomManaBetweenEffect produce = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            produce.possibleMana = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple];
            radio.Effects[0] = Effects.GenerateEffect(produce, 1, Slots.Self);
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
            entropy.Description = "Deal a Painful amount of damage to the Opposing party member then move Left or Right.\nInflict 1 Scar on all party members.";
            entropy.Rarity = radio.Rarity;
            entropy.Effects = new EffectInfo[3];
            entropy.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            entropy.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            entropy.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Unit_AllOpponents);
            entropy.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            entropy.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);
            entropy.AddIntentsToTarget(Targeting.Unit_AllOpponents, [IntentType_GameIDs.Status_Scars.ToString()]);
            entropy.Visuals = CustomVisuals.GetVisuals("Salt/Censor");
            entropy.AnimationTarget = Slots.Front;

            //scanner
            Ability scanner = new Ability("Dream Scanner", "DreamScanner_A");
            scanner.Description = "Deal damage to the Opposing party member equal to the amount of times any Solitaire has taken damage this combat.";
            scanner.Rarity = radio.Rarity;
            scanner.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DreamScannerEffect>(), 1, Slots.Front).SelfArray();
            scanner.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString()]);
            scanner.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            scanner.AnimationTarget = Slots.Front;

            //tp garden cuz fuck you
            Ability dreamers = new Ability("A Dream Within A Dream", "Dreamers_A");
            dreamers.Description = "\"Somewhere better than here\"";
            dreamers.Rarity = Rarity.GetCustomRarity("rarity5");
            dreamers.Priority = Priority.ExtremelySlow;
            dreamers.Effects = new EffectInfo[5];
            dreamers.Effects[0] = Effects.GenerateEffect(BasicEffects.SetStoreValue("Dreamer_A"), 1, Slots.Self);
            dreamers.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 2, Slots.Self);
            dreamers.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<BoxAllEnemiesEffect>());
            dreamers.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToGardenEffect>(), 1, Slots.Self);
            dreamers.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnGardenEnemyBundleEffect>());
            dreamers.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc.ToString()]);
            dreamers.Visuals = CustomVisuals.GetVisuals("Salt/Curtains");
            dreamers.AnimationTarget = Slots.Self;


            //ADD ENEMY
            tv.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                sob,
                radio.GenerateEnemyAbility(true),
                anon.GenerateEnemyAbility(true),
                entropy.GenerateEnemyAbility(true),
                scanner.GenerateEnemyAbility(true),
                dreamers.GenerateEnemyAbility(true),
            });
            tv.AddEnemy(true, true);
        }
    }
}
