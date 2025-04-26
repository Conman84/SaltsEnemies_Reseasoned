using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class CoinHunter
    {
        public static void Add()
        {
            //Lightweight
            PerformEffectPassiveAbility lightweight = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            lightweight._passiveName = "Lightweight";
            lightweight.m_PassiveID = "Lightweight_PA";
            lightweight.passiveIcon = ResourceLoader.LoadSprite("Lightweight.png");
            lightweight._characterDescription = "Upon moving, 50% chance to move again.";
            lightweight._enemyDescription = "Upon moving, 50% chance to move again.";
            lightweight.doesPassiveTriggerInformationPanel = true;
            lightweight.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            lightweight._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };
            PercentageEffectorCondition light50P = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            light50P.triggerPercentage = 50;
            lightweight.conditions = new EffectorConditionSO[1] { light50P };

            //Revenge
            PerformEffectPassiveAbility revenge = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            revenge._passiveName = "Revenge";
            revenge.m_PassiveID = "Revenge_PA";
            revenge.passiveIcon = ResourceLoader.LoadSprite("Revenge.png");
            revenge._characterDescription = "On taking direct damage, give this enemy another ability.";
            revenge._enemyDescription = "On taking direct damage, give this enemy another ability.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            revenge._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Revenge.png"), "Revenge", revenge._enemyDescription);

            //Revenge
            PerformEffectPassiveAbility pocket = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            pocket._passiveName = "Pick-Pocket";
            pocket.m_PassiveID = "PickPocket_PA";
            pocket.passiveIcon = ResourceLoader.LoadSprite("PickPocket.png");
            pocket._characterDescription = "On fleeing, steal 5 coins.";
            pocket._enemyDescription = "On fleeing, steal 5 coins.";
            pocket.doesPassiveTriggerInformationPanel = true;
            pocket.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 5, Targeting.Slot_SelfSlot),
            };
            pocket._triggerOn = new TriggerCalls[] { TriggerCalls.OnFleeting };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("PickPocket.png"), "Pick-Pocket", pocket._enemyDescription);

            //Enemy Code
            Enemy CoinHunter = new Enemy("Coin Hunter", "CoinHunter_EN")
            {
                Health = 65,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("ShinyIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ShinyDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ShinyIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").deathSound,
            };
            CoinHunter.PrepareEnemyPrefab("assets/Blunder/Shiny_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Blunder/Shiny_Gibs.prefab").GetComponent<ParticleSystem>());

            CoinHunter.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.FleetingGenerator(2), 
                lightweight, 
                revenge, 
                Passives.Skittish, 
                pocket
            });
            CoinHunter.UnitTypes = new List<string>
            {
                "Bird"
            };

            CoinHunter.CombatEnterEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };

            CoinHunter.AddLootData(new EnemyLootItemProbability[2]
            {
                new EnemyLootItemProbability()
                {
                    isItemTreasure = true,
                    amount = 3,
                    probability = 100
                },
                new EnemyLootItemProbability()
                {
                    isItemTreasure = false,
                    amount = 3,
                    probability = 100
                }
            });

            //Emission
            Ability emission = new Ability("Volatile Emission", "Salt_VolatileEmission_A");
            emission.Description = "Inflict 1 Fire on the Left, Right, and Opposing party member spaces.";
            emission.Rarity = Rarity.GetCustomRarity("rarity5");
            emission.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targeting.Slot_OpponentSides),
            };
            emission.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            emission.AnimationTarget = Targeting.Slot_OpponentSides;
            emission.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[]
            {
                "Field_Fire"
            });

            //Wingbeat
            Ability wingbeat = new Ability("Wingbeat", "Salt_Wingbeat_A");
            wingbeat.Description = "Deal a painful amount of damage to the Left and Right party members. Apply Favor to one of them.";
            wingbeat.Rarity = Rarity.GetCustomRarity("rarity5");
            wingbeat.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_OpponentSides),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFavorSingleEffect>(), 1, Targeting.Slot_OpponentSides),
            };
            wingbeat.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            wingbeat.AnimationTarget = Targeting.Slot_OpponentSides;
            wingbeat.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[]
            {
                "Damage_3_6",
                "Status_Favor"
            });

            //Peck
            Ability peck = new Ability("Peck", "Salt_Peck_A");
            peck.Description = "Flip a coin. If unsuccessful, instantly kill the Opposing party member.";
            peck.Rarity = Rarity.GetCustomRarity("rarity5");
            peck.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CoinFlipDeathWithRerollEffect>(), 1, Targeting.Slot_Front),
            };
            peck.Visuals = null;
            peck.AnimationTarget = Targeting.Slot_Front;
            peck.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Misc_Currency",
                "Damage_Death"
            });

            //Add
            CoinHunter.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                emission.GenerateEnemyAbility(true),
                wingbeat.GenerateEnemyAbility(true),
                peck.GenerateEnemyAbility(true),
            });
            CoinHunter.AddEnemy(false, false, false);
        }
    }
}
