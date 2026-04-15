using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class TheMoon
    {
        public static void AddMoon()
        {
            Enemy template = new Enemy("The Moon", "TheMoon_EN")
            {
                Health = 999,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("MoonIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MoonIcon.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MoonIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound,
                Priority = Priority.Slow
            };
            template.PrepareEnemyPrefab("Assets/Moon/Moon_Enemy.prefab", SaltsReseasoned.Meow);

            PerformEffectImmediaterPassiveAbility temporal = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            temporal.name = "Temporal_5_PA";
            temporal._passiveName = "Temporal (5)";
            temporal._enemyDescription = "On receiving any damage, deal it again to all enemy positions at the start of the next turn.";
            temporal.m_PassiveID = "Temporal_PA";
            temporal.passiveIcon = ResourceLoader.LoadSprite("TemporalPassive.png");
            temporal._triggerOn = [TriggerCalls.OnDamaged];
            temporal.conditions = [DelayToSelfCondition.Create(Targetting.Everything(true))];
            temporal.doesPassiveTriggerInformationPanel = true;
            temporal.effects = [];

            PerformEffectPassiveAbility cosmic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            cosmic.name = "Cosmic_4_PA";
            cosmic._passiveName = "Cosmic (4)";
            cosmic._enemyDescription = "At the start of each round, generate 1 Pigment of each primary color.";
            cosmic.m_PassiveID = "Cosmic_PA";
            cosmic.passiveIcon = ResourceLoader.LoadSprite("CosmicPassive.png");
            cosmic._triggerOn = [TriggerCalls.OnCombatStart, TriggerCalls.OnRoundFinished];
            cosmic.conditions = [];
            cosmic.doesPassiveTriggerInformationPanel = true;
            cosmic.effects = [
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 1),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Blue), 1),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Yellow), 1),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Purple), 1),
                ];

            template.AddPassives(new BasePassiveAbilitySO[] { temporal, cosmic, Passives.Forgetful, Passives.Withering });

            Ability closer = new Ability("Falling Closer", "MoonCloser_A");
            closer.Description = "At the start of the next turn deal Almost No damage to all party member positions.\nConsume all Pigment.";
            closer.Rarity = Rarity.Common;
            closer.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 1, Targetting.Everything(false)),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllManaEffect>(), 1, Slots.Self)];
            closer.AddIntentsToTarget(Targetting.Everything(false), ["Damage_Delay", "Damage_1_2"]);
            closer.AddIntentsToTarget(Slots.Self, ["Mana_Consume"]);
            closer.Visuals = Visuals.Excommunicate;
            closer.AnimationTarget = Targetting.Everything(false);

            Ability further = new Ability("Moving Further", "MoonFurther_A");
            further.Description = "Fully heal this enemy. Apply 20 Shield to all enemy positions.";
            ApplyShieldSlotEffect use_exit = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
            use_exit._UsePreviousExitValueAsMultiplier = false;
            further.Rarity = Rarity.Common;
            further.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 999, Slots.Self),
                Effects.GenerateEffect(use_exit, 20, Targetting.Everything(true))];
            further.AddIntentsToTarget(Slots.Self, ["Heal_21"]);
            further.AddIntentsToTarget(Targetting.Everything(true), ["Field_Shield"]);
            further.Visuals = Visuals.Excommunicate;
            further.AnimationTarget = Slots.Self;

            Ability eternity = new Ability("Stasis Eternity", "StasisEternity_A");
            eternity.Description = "Generate 1 Pigment of each primary color.";
            eternity.Rarity = Rarity.Common;
            eternity.Effects = [
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 1),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Blue), 1),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Yellow), 1),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Purple), 1)];
            eternity.AddIntentsToTarget(Slots.Self, ["Mana_Generate"]);
            eternity.AnimationTarget = Slots.Self;
            

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                closer.GenerateEnemyAbility(true),
                further.GenerateEnemyAbility(true),
                eternity.GenerateEnemyAbility(true),
            });

            LoadedAssetsHandler.LoadedEnemies.Add(template.enemy.name, template.enemy);
        }
        public static void AddStars()
        {
            Enemy template = new Enemy("The Stars", "TheStars_EN")
            {
                Health = 333,
                HealthColor = Pigments.Grey,
                CombatSprite = LoadedAssetsHandler.GetEnemy("StarGazer_EN").enemySprite,
                OverworldAliveSprite = LoadedAssetsHandler.GetEnemy("StarGazer_EN").enemyOverworldSprite,
                OverworldDeadSprite = LoadedAssetsHandler.GetEnemy("StarGazer_EN").enemyOWCorpseSprite,
                DamageSound = LoadedAssetsHandler.GetEnemy("StarGazer_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("StarGazer_EN").deathSound,
            };
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("StarGazer_EN").enemyTemplate;

            PerformEffectImmediaterPassiveAbility temporal = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            temporal.name = "Temporal_1_PA";
            temporal._passiveName = "Temporal (1)";
            temporal._enemyDescription = "On receiving any damage, deal it again to this current enemy position at the start of the next turn.";
            temporal.m_PassiveID = "Temporal_PA";
            temporal.passiveIcon = ResourceLoader.LoadSprite("TemporalPassive.png");
            temporal._triggerOn = [TriggerCalls.OnDamaged];
            temporal.conditions = [DelayToSelfCondition.Create(Slots.Self)];
            temporal.doesPassiveTriggerInformationPanel = true;
            temporal.effects = [];

            PerformEffectPassiveAbility cosmic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            cosmic.name = "Cosmic_1_PA";
            cosmic._passiveName = "Cosmic (1)";
            cosmic._enemyDescription = "At the start of each round, generate 1 Red Pigment.";
            cosmic.m_PassiveID = "Cosmic_PA";
            cosmic.passiveIcon = ResourceLoader.LoadSprite("CosmicPassive.png");
            cosmic._triggerOn = [TriggerCalls.OnCombatStart, TriggerCalls.OnRoundFinished];
            cosmic.conditions = [];
            cosmic.doesPassiveTriggerInformationPanel = true;
            cosmic.effects = [
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 1),
                ];

            template.AddPassives(new BasePassiveAbilitySO[] { temporal, cosmic, Passives.Forgetful });

            Ability andromeda = new Ability("Andromeda", "Stars_1_A");
            andromeda.Description = "Deal an Agonizing amount of damage to the current Opposing party member position at the start of the next turn.\nMove to a random position.";
            andromeda.Rarity = Rarity.Common;
            andromeda.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 8, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
                ];
            andromeda.AddIntentsToTarget(Slots.Front, ["Damage_Delay", "Damage_7_10"]);
            andromeda.AddIntentsToTarget(Slots.Self, ["Swap_Mass"]);
            andromeda.Visuals = Visuals.Wriggle;
            andromeda.AnimationTarget = Slots.Front;

            Ability pulsar = new Ability("Pulsar", "Stars_2_A");
            pulsar.Description = "Deal a Painful amount of damage to the current Opposing party member position at the start of the next turn.\nMove Left or Right.";
            pulsar.Rarity = Rarity.Common;
            pulsar.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                ];
            pulsar.AddIntentsToTarget(Slots.Front, ["Damage_Delay", "Damage_3_6"]);
            pulsar.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            pulsar.Visuals = Visuals.Wriggle;
            pulsar.AnimationTarget = Slots.Front;

            Ability comet = new Ability("Comet", "Stars_3_A");
            comet.Description = "Gain 2 Oil-Slicked and 35 Shield. Move Left or Right.";
            comet.Rarity = Rarity.Common;
            comet.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 35, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)
                ];
            comet.AddIntentsToTarget(Slots.Self, ["Status_OilSlicked", "Field_Shield", "Swap_Sides"]);
            comet.Visuals = Visuals.Wriggle;
            comet.AnimationTarget = Slots.Self;

            Ability singularity = new Ability("Singularity", "Stars_4_A");
            singularity.Description = "Gain 1 Divine Protection.\nApply 20 Shield to the Left, Right, and this enemy positions.";
            singularity.Rarity = Rarity.Common;
            singularity.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 20, Targeting.Slot_SelfAndSides)
                ];
            singularity.AddIntentsToTarget(Slots.Self, ["Status_DivineProtection"]);
            singularity.AddIntentsToTarget(Targeting.Slot_SelfAndSides, ["Field_Shield"]);
            singularity.Visuals = Visuals.Excommunicate;
            singularity.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                andromeda.GenerateEnemyAbility(true),
                pulsar.GenerateEnemyAbility(true),
                comet.GenerateEnemyAbility(true),
                singularity.GenerateEnemyAbility(true),
            });

            LoadedAssetsHandler.LoadedEnemies.Add(template.enemy.name, template.enemy);
        }
        public static void AddEncounters()
        {
            Portals.AddPortalSign("THEFREAKINGMOON_Encounter_Sign", ResourceLoader.LoadSprite("MoonIcon.png"), Portals.EnemyIDColor);

            EnemyEncounter_API med = new EnemyEncounter_API(EncounterType.Specific, Garden.H.Moon.Hard, "THEFREAKINGMOON_Encounter_Sign");
            med.MusicEvent = "event:/Hawthorne/MoonPlaceholder";
            med.RoarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;

            med.CreateNewEnemyEncounterData(["TheMoon_EN", "TheStars_EN", "TheStars_EN", "TheStars_EN", "TheStars_EN"], [2, 0, 1, 3, 4]);

            med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector(Garden.H.Moon.Hard, 0, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
