using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Complimentary
    {
        public static void Add()
        {
            Enemy complimentary = new Enemy("Complimentary", "Complimentary_EN")
            {
                Health = 60,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ComplimentaryIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ComplimentaryWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ComplimentaryDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound,
            };
            complimentary.PrepareEnemyPrefab("assets/enemie/Complimentary_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Complimentary_Gibs.prefab").GetComponent<ParticleSystem>());

            //divison
            PerformEffectPassiveAbility division = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            division._passiveName = "Divisible";
            division.m_PassiveID = "Divisible_PA";
            division.passiveIcon = ResourceLoader.LoadSprite("DivisibleIcon.png");
            division._enemyDescription = "On taking any damage, if there is available space split into 2 copies of this enemy with half the health.";
            division._characterDescription = division._enemyDescription;
            division.doesPassiveTriggerInformationPanel = true;
            division.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SplitInTwoEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<HasEnemySpaceEffectCondition>()).SelfArray();
            division._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDamaged };
            division.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions != null ? Passives.Slippery.conditions : new EffectorConditionSO[0]) { ScriptableObject.CreateInstance<HasEnemySpaceCondition>() }.ToArray();

            complimentary.AddPassives(new BasePassiveAbilitySO[] { division, Passives.Skittish });

            //bash
            EnemyAbilityInfo bash = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Bash_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //santanomanoma
            Ability santa = new Ability("Santanomanoma", "Santanomanoma_A");
            santa.Description = "Randomize this enemy's health color. Move to the Left or Right 3 times.";
            santa.Rarity = Rarity.GetCustomRarity("rarity5");
            santa.Priority = Priority.Fast;
            santa.Effects = new EffectInfo[5];
            santa.Effects[0] = Effects.GenerateEffect(BasicEffects.PlaySound(LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent), 1, Slots.Self);
            santa.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorEffect>(), 1, Slots.Self);
            santa.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            santa.Effects[3] = santa.Effects[2];
            santa.Effects[4] = santa.Effects[2];
            santa.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Modify.ToString(), "Swap_Sides", "Swap_Sides", "Swap_Sides"]);
            santa.Visuals = CustomVisuals.GetVisuals("Salt/Notif");
            santa.AnimationTarget = Slots.Self;

            //antipathi
            Ability anti = new Ability("Antipathi", "Antipathi_A");
            anti.Description = "Produce 2 random pigment. Apply 2 Power to all enemies.";
            anti.Rarity = Rarity.GetCustomRarity("rarity5");
            anti.Priority = Priority.Fast;
            anti.Effects = new EffectInfo[2];
            GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            random.possibleMana = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple];
            anti.Effects[0] = Effects.GenerateEffect(random, 2, Slots.Self);
            anti.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Targeting.Unit_AllAllies);
            anti.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);
            anti.AddIntentsToTarget(Targeting.Unit_AllAllies, [Power.Intent]);
            anti.Visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;
            anti.AnimationTarget = Slots.Self;

            //ADD ENEMY
            complimentary.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bash,
                santa.GenerateEnemyAbility(true),
                anti.GenerateEnemyAbility(true)
            });
            complimentary.AddEnemy(true, true);
        }
    }
}
