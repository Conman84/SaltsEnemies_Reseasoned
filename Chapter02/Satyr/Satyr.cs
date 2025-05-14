using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class Satyr
    {
        public static void Add()
        {
            //Enemy Code
            Enemy Satyr = new Enemy("Satyr", "Satyr_EN")
            {
                Health = 50,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority-1"),
                CombatSprite = ResourceLoader.LoadSprite("SatyrIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SatyrDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SatyrIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Oisenay/SatyrHurt",
                DeathSound = "event:/Hawthorne/Oisenay/SatyrDie",
            };

            Satyr.PrepareMultiEnemyPrefab("assets/Senis2/Satyr_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis2/Satyr_Giblets.prefab").GetComponent<ParticleSystem>());
            (Satyr.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                Satyr.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("TorsoBack").GetComponent<SpriteRenderer>()
            };
            Satyr.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Satyr>();

            Satyr.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Skittish,
                Passives.Dying
            });
            Satyr.AddUnitType("Bird");

            //Sweet
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
            indirect._indirect = true;

            Ability sweet = new Ability("Sweet Flavour", "Salt_SweetFlavour_A");
            if (UnityEngine.Random.Range(0, 100) < 50) { sweet.Name = "Sweet Flavor"; }
            sweet.Description = "Attempt to revive a dead enemy with a third of its maximum health. If successful, deal a Mortal amount of indirect damage to this enemy. \nCannot revive Inanimate or Dying enemies.";
            sweet.Rarity = Rarity.GetCustomRarity("rarity5");
            sweet.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyFromDeadListEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(indirect, 30, Targeting.Slot_SelfSlot, didThat),
            };
            sweet.Visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            sweet.AnimationTarget = Targeting.Slot_SelfSlot;
            sweet.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc",
            });
            sweet.AddIntentsToTarget(ScriptableObject.CreateInstance<EmptyTargetting>(), IntentType_GameIDs.Other_MaxHealth.ToString().SelfArray());
            sweet.AddIntentsToTarget(Slots.Self, "Damage_21".SelfArray());

            //Savory
            CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
            Pigments.Red,
            Pigments.Blue,
            Pigments.Yellow,
            Pigments.Purple
            };
            SwapToOneSideEffect moveLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            moveLeft._swapRight = false;
            SwapToOneSideEffect moveRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            moveRight._swapRight = true;

            Ability savory = new Ability("Savory Flavour", "Salt_SavoryFlavour_A");
            if (UnityEngine.Random.Range(0, 100) < 50) { savory.Name = "Savory Flavor"; }
            savory.Description = "Attempt to revive a dead enemy. If successful, apply 1 Divine Protection to the enemy, deal its current health as indirect damage to it, then remove all Divine Protection from it. \nCannot revive Inanimate or Dying enemies.";
            savory.Rarity = Rarity.GetCustomRarity("rarity5");
            savory.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ReviveReKillEnemyEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            savory.Visuals = CustomVisuals.GetVisuals("Salt/Unlock");
            savory.AnimationTarget = Targeting.Slot_SelfSlot;
            savory.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc",
            });
            savory.AddIntentsToTarget(ScriptableObject.CreateInstance<EmptyTargetting>(), new string[] { IntentType_GameIDs.Status_DivineProtection.ToString(), IntentType_GameIDs.Damage_21.ToString() });

            //Sour
            IncreaseStatusEffectsEffect increaseAllStatus = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus._increasePositives = true;
            IncreaseStatusEffectsEffect increaseAllStatus2 = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus2._increasePositives = false;

            Ability sour = new Ability("Sour Flavour", "Salt_SourFlavour_A");
            if (UnityEngine.Random.Range(0, 100) < 50) { sour.Name = "Sour Flavor"; }
            sour.Description = "Apply 7 Determined to the Left and Right enemies. If successful, deal a Deadly amount of damage to the Left and Right enemies. This ability will never kill the target.";
            sour.Rarity = Rarity.GetCustomRarity("rarity5");
            sour.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 7, Targeting.Slot_AllySides),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<NoKillingDamageEffect>(), 15, Targeting.Slot_AllySides, didThat),
            };
            sour.Visuals = CustomVisuals.GetVisuals("Salt/Sprout");
            sour.AnimationTarget = Targeting.Slot_AllySides;
            sour.AddIntentsToTarget(Targeting.Slot_AllySides, new string[]
            {
                "Status_Determined",
                "Damage_11_15",
            });

            //Bitter
            Extra1Or2LootOptionsEffect TApple = ScriptableObject.CreateInstance<Extra1Or2LootOptionsEffect>();
            TApple._itemName = "TaintedApple_TW";
            SatyrAnimationVisualsEffect bitterAnim = ScriptableObject.CreateInstance<SatyrAnimationVisualsEffect>();
            bitterAnim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
            bitterAnim._visuals2 = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bitterAnim._animationTarget = Targeting.Slot_Front;

            Ability bitter = new Ability("Bitter Flavour", "Salt_BitterFlavour_A");
            if (UnityEngine.Random.Range(0, 100) < 50) { bitter.Name = "Bitter Flavor"; }
            bitter.Description = "Instantly kill the Opposing party member. If successful, give 1-2 Tainted Apples and instantly kill this enemy.";
            bitter.Rarity = Rarity.GetCustomRarity("rarity4");
            bitter.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(bitterAnim, 1, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_Front),
                Effects.GenerateEffect(TApple, 1, Targeting.Slot_SelfSlot, didThat),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 7, Targeting.Slot_SelfSlot, BasicEffects.DidThat(true, 2)),
            };
            bitter.Visuals = null;
            bitter.AnimationTarget = Targeting.Slot_SelfSlot;
            bitter.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_Death",
            });
            bitter.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Misc.ToString().SelfArray());
            bitter.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Damage_Death",
            });

            //Add
            Satyr.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                sweet.GenerateEnemyAbility(true),
                savory.GenerateEnemyAbility(true),
                sour.GenerateEnemyAbility(true),
                bitter.GenerateEnemyAbility(true),
            });
            Satyr.AddEnemy(true, true, false);
        }
    }
}
