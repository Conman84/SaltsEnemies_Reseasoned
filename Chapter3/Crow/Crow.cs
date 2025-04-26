using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public class Crow
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

            //Enemy Code
            Enemy Crow = new Enemy("The Crow", "TheCrow_EN")
            {
                Health = 28,
                HealthColor = Pigments.Blue,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("CrowIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CrowDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CrowIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Nois2/CrowHurt",
                DeathSound = "event:/Hawthorne/Nois2/CrowDie",
            };
            Crow.PrepareMultiEnemyPrefab("assets/Senis3/Crow_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis3/Crow_Gibs.prefab").GetComponent<ParticleSystem>());
            (Crow.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                Crow.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").GetComponent<SpriteRenderer>()
            };

            Crow.AddPassives(new BasePassiveAbilitySO[]
            {
                lightweight,
                LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[1]
            });
            Crow.UnitTypes = new List<string> 
            { 
                "Bird" 
            };

            //Count
            AnimationVisualsEffect homonDomin = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            homonDomin._animationTarget = Targeting.Slot_Front;
            homonDomin._visuals = CustomVisuals.GetVisuals("Salt/Decapitate");
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability counting = new Ability("Count", "Salt_Count_A");
            counting.UnitStoreData = LoadedDBsHandler.MiscDB.GetUnitStoreData(CrowIntents.Count);
            counting.Description = "Increase \"Count\" by 1. If this counter reaches 3 or higher, reset the counter and deal a Deadly amount of damage to the opposing party member.";
            counting.Rarity = Rarity.GetCustomRarity("rarity5");
            counting.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CountCountEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(homonDomin, 1, Targeting.Slot_Front, didThat),
                Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 12, Targeting.Slot_Front),
                }), 12, Targeting.Slot_Front, didThat),
            };
            counting.Visuals = null;
            counting.AnimationTarget = Targeting.Slot_SelfSlot;
            counting.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                CrowIntents.Count
            });
            counting.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_11_15"
            });

            //Wait
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._animationTarget = Targeting.Slot_Front;
            talons._visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;

            Ability waiting = new Ability("Wait", "Salt_Wait_A");
            waiting.UnitStoreData = LoadedDBsHandler.MiscDB.GetUnitStoreData(CrowIntents.Wait);
            waiting.Description = "Increase \"Wait\" by 1. If this counter reaches 2 or higher, reset the counter, Curse the opposing party member, and inflict 3 Frail on all Cursed party members.";
            waiting.Rarity = Rarity.GetCustomRarity("rarity4");
            waiting.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<WaitCountEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(talons, 1, Targeting.Slot_Front, didThat),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, Targeting.Slot_SelfSlot, didThat),
                Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Targeting.Slot_Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, TargettingByStatusEffect.Create(Targetting.AllEnemy, "Cursed_ID")),
                }), 1, Targeting.Slot_Front, didThat),
            };
            waiting.Visuals = null;
            waiting.AnimationTarget = Targeting.Slot_SelfSlot;
            waiting.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                CrowIntents.Wait
            });
            waiting.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Status_Cursed"
            });
            waiting.AddIntentsToTarget(TargettingByStatusEffect.Create(Targetting.AllEnemy, "Cursed_ID"), new string[]
            {
                "Status_Frail"
            });
            waiting.AddIntentsToTarget(TargettingByStatusEffect.Create(Targeting.Slot_Front, "Cursed_ID", false), new string[]
            {
                "Status_Frail"
            });

            //Serenity
            Ability serenity = new Ability("Serenity", "Salt_Serenity_A");
            serenity.Description = "Increase both \"Count\" and \"Wait\" by 1. Move left or right.";
            serenity.Rarity = Rarity.GetCustomRarity("rarity3");
            serenity.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SerenityEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            serenity.Visuals = null;
            serenity.AnimationTarget = Targeting.Slot_SelfSlot;
            serenity.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Sides",
                CrowIntents.Count,
                CrowIntents.Wait
            });

            //Add
            Crow.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                counting.GenerateEnemyAbility(true),
                waiting.GenerateEnemyAbility(true),
                serenity.GenerateEnemyAbility(true),
            });
            Crow.AddEnemy(true, true, false);
        }
    }
}
