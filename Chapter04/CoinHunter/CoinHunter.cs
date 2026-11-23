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
            revenge._enemyDescription = "On taking direct damage, give this enemy another action.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            revenge._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            revenge.conditions = Passives.Slippery.conditions;
            

            //Revenge
            PerformEffectPassiveAbility pocket = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            pocket._passiveName = "Pick-Pocket (5)";
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
            

            //Enemy Code
            Enemy CoinHunter = new Enemy("Coin Hunter", "CoinHunter_EN")
            {
                Health = 65,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("ShinyIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ShinyDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ShinyWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Nois2/CrowHurt",
                DeathSound = "event:/Hawthorne/Nois2/CrowDie",
            };
            CoinHunter.PrepareEnemyPrefab("assets/Blunder/Shiny_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Blunder/Shiny_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectPassiveAbility Apostle = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            Apostle.name = "Apostle_PA";
            Apostle._passiveName = "Apostle";
            Apostle.passiveIcon = ResourceLoader.LoadSprite("ApostlePassive.png");
            Apostle._enemyDescription = "On any other enemy being directly damaged, prematurely perform this enemy's next action on the timeline.";
            //ch desc
            Apostle.m_PassiveID = "Apostle_PA";
            Apostle.doesPassiveTriggerInformationPanel = true;
            Apostle._triggerOn = [AnyOtherAllyDamagedHandler.Trigger];
            Apostle.effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstActionEffect>(), 1, Slots.Self),
                ];
            Apostle.conditions = [ScriptableObject.CreateInstance<HasTurnsCondition>()];

            CoinHunter.AddPassives(new BasePassiveAbilitySO[]
            {
                //Passives.FleetingGenerator(2), 
                Passives.Slippery, 
                lightweight, 
                revenge, 
                Apostle,
                //Passives.Skittish, 
                //pocket
            });
            CoinHunter.UnitTypes = new List<string>
            {
                "Bird"
            };

            CoinHunter.CombatEnterEffects = new EffectInfo[]
            {
                //Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowPlayerCurrencyEffect>()),
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

            DamageEffect damage = ScriptableObject.CreateInstance<DamageEffect>();
            StealCoinsFromTargetEffect steal = ScriptableObject.CreateInstance<StealCoinsFromTargetEffect>();
            IsPlayerTurnEffectCondition isplayer = ScriptableObject.CreateInstance<IsPlayerTurnEffectCondition>();
            ApplyFavorSingleEffect favor = ScriptableObject.CreateInstance<ApplyFavorSingleEffect>();
            TargettingByStatusEffect isfavor = TargettingByStatusEffect.Create(Targeting.Unit_AllOpponents, Favor.StatusID, true);
            AddPassiveWithDisplayEffect cashout = ScriptableObject.CreateInstance<AddPassiveWithDisplayEffect>();
            cashout.passive = Passives.Cashout;

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

            Ability pyramid = new Ability("Pyramid Scheme", "Shiny_Pyramid_A");
            pyramid.Description = "Steal 5 Coins from all party members.\nIf no Coins were stolen, deal a Painful amount of damage to all party members and Favorite the Opposing party member.\nIf it is currently the Player's turn, takes a Little damage.";
            pyramid.Rarity = Rarity.CreateAndAddCustomRarityToPool("shiny_7", 7);
            pyramid.Effects = [
                Effects.GenerateEffect(steal, 5, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Talons_A", false, Targeting.Unit_AllOpponents), 0, null, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(damage, 4, Targeting.Unit_AllOpponents, BasicEffects.DidThat(false, 2)),
                Effects.GenerateEffect(favor, 1, Slots.Front, BasicEffects.DidThat(false, 3)),
                Effects.GenerateEffect(damage, 2, Slots.Self, isplayer)
                ];
            pyramid.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Currency", "Damage_3_6"]);
            pyramid.AddIntentsToTarget(Slots.Front, ["Status_Favor"]);
            pyramid.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            pyramid.Visuals = Visuals.Slap;
            pyramid.AnimationTarget = Targeting.Unit_AllOpponents;

            //Wingbeat
            Ability wingbeat = new Ability("Wingbeat", "Salt_Wingbeat_A");
            wingbeat.Description = "Deal an Agonizing amount of damage to the Left and Right party members and Favorite one of them.\nIf it is currently the Player's turn, takes a Little damage three times.";
            wingbeat.Rarity = Rarity.GetCustomRarity("shiny_7");
            wingbeat.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(damage, 8, Slots.LeftRight),
                Effects.GenerateEffect(favor, 1, Slots.LeftRight),
                Effects.GenerateEffect(damage, 2, Slots.Self, isplayer),
                Effects.GenerateEffect(damage, 2, Slots.Self, isplayer),
                Effects.GenerateEffect(damage, 2, Slots.Self, isplayer),

            };
            wingbeat.Visuals = CustomVisuals.GetVisuals("Salt/Nailing");
            wingbeat.AnimationTarget = Targeting.Slot_OpponentSides;
            wingbeat.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[]
            {
                "Damage_7_10",
                "Status_Favor"
            });
            wingbeat.AddIntentsToTarget(Slots.Self, ["Damage_1_2", "Damage_1_2", "Damage_1_2"]);

            Ability pick = new Ability("Pick-Pocket", "Shiny_Pocket_A");
            pick.Description = "Steal 10 Coins from the Left, Right, and Opposing party members.\nIf no Coins were stolen deal a Deadly amount of damage to the Opposing party member and Favorite one of the Left, Right, or Opposing party members.\nIf it is currently the Player's turn, takes a Little damage.";
            pick.Rarity = Rarity.GetCustomRarity("shiny_7");
            pick.Effects = [
                Effects.GenerateEffect(steal, 10, Slots.FrontLeftRight),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Hunt", false, Slots.Front), 0, null, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(damage, 12, Slots.Front, BasicEffects.DidThat(false, 2)),
                Effects.GenerateEffect(favor, 1, Slots.FrontLeftRight, BasicEffects.DidThat(false, 3)),
                Effects.GenerateEffect(damage, 2, Slots.Self, isplayer)
                ];
            pick.AddIntentsToTarget(Slots.FrontLeftRight, ["Misc_Currency"]);
            pick.AddIntentsToTarget(Slots.Front, ["Damage_11_15"]);
            pick.AddIntentsToTarget(Slots.FrontLeftRight, [Favor.Intent]);
            pick.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            pick.Visuals = Visuals.Slap;
            pick.AnimationTarget = Slots.FrontLeftRight;

            AnimationVisualsEffect turngold = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            turngold._visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
            //turngold._visuals = Visuals.Scales;
            turngold._animationTarget = isfavor;

            

            Ability midas = new Ability("Midas", "Shiny_Midas_A");
            midas.Description = "Steal 20 Coins.\nIf less than 20 Coins were stolen, turn all Favored party members into gold and destroy them.\nIf no party members are Favored, takes a Little damage.";
            midas.Rarity = Rarity.GetCustomRarity("rarity5");
            midas.Effects = [
                Effects.GenerateEffect(steal, 20, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<PrevExitMeetsEntryEffect>(), 20),
                Effects.GenerateEffect(turngold, 0, null, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(cashout, 1, isfavor, BasicEffects.DidThat(false, 2)),
                Effects.GenerateEffect(damage, 16, isfavor, BasicEffects.DidThat(false, 3)),
                Effects.GenerateEffect(damage, 2, Slots.Self, ScriptableObject.CreateInstance<NoPartyFavoredEffectCondition>())
                ];
            midas.AddIntentsToTarget(Slots.Self, ["Misc_Currency"]);
            midas.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            midas.AddIntentsToTarget(isfavor, ["Damage_16_20"]);
            midas.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            midas.Visuals = Visuals.Scales;
            midas.AnimationTarget = Slots.Self;

            IsFrontTargetCondition nofront = IsFrontTargetCondition.Create(false);
            DoubleEffectCondition peckcon = ScriptableObject.CreateInstance<DoubleEffectCondition>();
            peckcon.first = isplayer;
            peckcon.second = nofront;

            //Peck
            Ability peck = new Ability("Peck", "Salt_Peck_A");
            peck.Description = "Flip a Coin. If unsuccessful, instantly kill the Opposing party member.\nTake as many tries as you can afford.\nIf there is no Opposing party member, Favorite a random party member and takes a Little damage. If it is also currently the Player's turn, takes a Little damage another two times.";
            peck.Rarity = Rarity.Common;
            peck.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Gaze", false, Slots.Self), 0, null, nofront),
                Effects.GenerateEffect(favor, 1, Targeting.Unit_AllOpponents, nofront),
                Effects.GenerateEffect(damage, 2, Slots.Self, nofront),
                Effects.GenerateEffect(damage, 2, Slots.Self, peckcon),
                Effects.GenerateEffect(damage, 2, Slots.Self, peckcon),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CoinFlipDeathWithRerollEffect>(), 1, Targeting.Slot_Front),
            };
            peck.Visuals = null;
            peck.AnimationTarget = Targeting.Slot_Front;
            peck.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Misc_Currency",
                "Damage_Death"
            });
            peck.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Status_Favor"]);
            peck.AddIntentsToTarget(Slots.Self, ["Damage_1_2", "Damage_1_2", "Damage_1_2"]);

            

            //Add
            CoinHunter.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                //emission.GenerateEnemyAbility(true),
                pyramid.GenerateEnemyAbility(true),
                wingbeat.GenerateEnemyAbility(true),
                pick.GenerateEnemyAbility(true),
                midas.GenerateEnemyAbility(true),
                peck.GenerateEnemyAbility(true),
            });
            CoinHunter.AddEnemy(true, false, false);

            EnemySO clone = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemy("Bronzo_MoneyPile_EN"));
            clone.passiveAbilities = [.. clone.passiveAbilities];
            clone.passiveAbilities.Add(Passives.Withering);
            clone.passiveAbilities.Add(Passives.Fleeting4);

            LoadedAssetsHandler.LoadedEnemies.Add("Shiny_MoneyPile_EN", clone);
        }
    }
}
