using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class SevenSins
    {
        public static List<EnemySO> Sins = [];
        public static ParticleSystem Gibs;
        public static void Add()
        {
            PerformEffectPassiveAbility overdose = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            overdose.name = "Overdose_PA";
            overdose._passiveName = "Overdose";
            overdose.m_PassiveID = "Overdose_PA";
            overdose.passiveIcon = ResourceLoader.LoadSprite("OverdosePassive.png");
            overdose._enemyDescription = "On being directly damaged, transform into a random other Seventh Sin.";
            overdose._characterDescription = "On being directly damaged, probably transform into Agon i think.";
            overdose._triggerOn = [TriggerCalls.OnDirectDamaged];
            overdose.conditions = Passives.Slippery.conditions;

            RandomTransformationNotSelfEffect overdose_effect = ScriptableObject.CreateInstance<RandomTransformationNotSelfEffect>();
            overdose_effect._maintainMaxHealth = true;
            overdose_effect._fullyHeal = false;
            overdose_effect._maintainTimelineAbilities = true;
            overdose_effect.ByColor = true;

            overdose.effects = [
                Effects.GenerateEffect(overdose_effect, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>())
                ];

            Gibs = SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Sins/Sins_Gibs.prefab").GetComponent<ParticleSystem>();

            Wrath(overdose);
            Pride(overdose);
            Lust(overdose);
            Envy(overdose);
            Greed(overdose);
            Sloth(overdose);
            Gluttony(overdose);


            overdose_effect._allTransforms = [];
            for (int i = 0; i < Sins.Count; i++) overdose_effect._allTransforms.Add(new TransformOption(Sins[i]));
        }
        public static void Wrath(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin of Wrath", "Sin_Wrath_EN")
            {
                Health = 48,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SinWrath_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinWrath_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Agon_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Agon_CH").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Wrath_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Wrath_Kill_A");
            test.Name = "Wrath Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "Deal a Lethal amount of damage to the Opposing party member, damage spreads indirectly to adjacent party members.\nDamage this enemy for the amount dealt.";
            DamageOnDoubleCascadeEffect damage = ScriptableObject.CreateInstance<DamageOnDoubleCascadeEffect>();
            damage._decreaseAsPercentage = true;
            damage._cascadeDecrease = 50;
            damage._cascadeIsIndirect = true;
            DamageEffect byExit = ScriptableObject.CreateInstance<DamageEffect>();
            byExit._usePreviousExitValue = true;
            test.Effects = [
                Effects.GenerateEffect(damage, 20, Targeting.Slot_Front_ThenAllRights_ThenAllLefts),
                Effects.GenerateEffect(byExit, 1, Slots.Self),
                ];
            test.AddIntentsToTarget(Slots.Front, ["Damage_16_20"]);
            test.AddIntentsToTarget(Slots.LeftRight, ["Damage_7_10"]);
            test.AddIntentsToTarget(Slots.SlotTarget([-2, 2], false), ["Damage_3_6"]);
            test.AddIntentsToTarget(Slots.SlotTarget([-3, 3], false), ["Damage_1_2"]);
            test.AddIntentsToTarget(Slots.Self, ["Damage_21"]);
            test.Visuals = Visuals.SliceAndDice;
            test.AnimationTarget = Slots.Front;

            Ability spawn = new Ability("Wrath_Spawn_A");
            spawn.Name = "Wrath Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "Attempt to split in two.\nIf this fails, gain Spotlight.";
            spawn.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SplitInTwoEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<HasEnemySpaceEffectCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, Slots.Self, BasicEffects.DidThat(false)),
                ];
            spawn.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Status_Spotlight.ToString()]);
            spawn.Visuals = Visuals.Mitosis;
            spawn.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
        public static void Pride(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin of Pride", "Sin_Pride_EN")
            {
                Health = 48,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("SinPride_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinPride_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Burnout_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Burnout_CH").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Pride_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Pride_Kill_A");
            test.Name = "Pride Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "If the Opposing party member has less health than this enemy, deal a Variable amount of damage to them.";
            DamageCompareHealthToCasterEffect less = ScriptableObject.CreateInstance<DamageCompareHealthToCasterEffect>();
            less.More = false;
            less._usePreviousExitValue = true;
            test.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ReturnExitZeroToEntryEffect>(), 17),
                Effects.GenerateEffect(less, 1, Slots.Front),
                ];
            test.AddIntentsToTarget(Slots.Front, ["Misc_Hidden"]);
            test.AddIntentsToTarget(Slots.Front, new string[]
            {
                FallColor.Intent,
                "Damage_1_2",
                "Damage_3_6",
                "Damage_7_10",
                "Damage_11_15",
                "Damage_16_20",
            });
            test.Visuals = Visuals.Clobber_Left;
            test.AnimationTarget = Slots.Front;

            Ability spawn = new Ability("Pride_Spawn_A");
            spawn.Name = "Pride Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "Fully heal all Seventh Sins, then take damage equal to the amount healed.";
            DamageEffect byExit = ScriptableObject.CreateInstance<DamageEffect>();
            byExit._usePreviousExitValue = true;
            spawn.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FullyHealSinsEffect>(), 1, Targeting.Unit_AllAllies),
                Effects.GenerateEffect(byExit, 1, Slots.Self, BasicEffects.DidThat(true)),
                ];
            spawn.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Misc_Hidden", IntentType_GameIDs.Heal_11_20.ToString()]);
            spawn.AddIntentsToTarget(Slots.Self, ["Damage_21"]);
            spawn.Visuals = Visuals.ShedSkin;
            spawn.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
        public static void Lust(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin of Lust", "Sin_Lust_EN")
            {
                Health = 48,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("SinLust_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinLust_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("ShellyK_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("ShellyK_CH").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Lust_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Lust_Kill_A");
            test.Name = "Lust Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "Level down the Opposing party member.\nIf they were already at level 1, deal a Deadly amount of damage to them.";
            test.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TempRankDownEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 15, Slots.Front, BasicEffects.DidThat(false)),
                ];
            test.AddIntentsToTarget(Slots.Front, ["Misc", "Damage_11_15"]);
            test.Visuals = CustomVisuals.GetVisuals("Salt/Curse");
            test.AnimationTarget = Slots.Front;


            Ability spawn = new Ability("Lust_Spawn_A");
            spawn.Name = "Lust Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "Take an Agonizing amount of damage and spawn a copy of this enemy with equivalent health.";
            spawn.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyCopyBasedOffExitEffect>(), 1, Slots.Self),
                ];
            spawn.AddIntentsToTarget(Slots.Self, ["Damage_7_10", IntentType_GameIDs.Other_Spawn.ToString()]);
            spawn.Visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
            spawn.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
        public static void Envy(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin Envy", "Sin_Envy_EN")
            {
                Health = 48,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("SinEnvy_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinEnvy_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("CorpseChan_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("CorpseChan_EN").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Envy_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Envy_Kill_A");
            test.Name = "Envy Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "If the Opposing party member has more health than this enemy, deal a Variable amount of damage to them.";
            DamageCompareHealthToCasterEffect less = ScriptableObject.CreateInstance<DamageCompareHealthToCasterEffect>();
            less.More = true;
            less._usePreviousExitValue = true;
            test.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ReturnExitZeroToEntryEffect>(), 17),
                Effects.GenerateEffect(less, 1, Slots.Front),
                ];
            test.AddIntentsToTarget(Slots.Front, ["Misc_Hidden"]);
            test.AddIntentsToTarget(Slots.Front, new string[]
            {
                FallColor.Intent,
                "Damage_1_2",
                "Damage_3_6",
                "Damage_7_10",
                "Damage_11_15",
                "Damage_16_20",
            });
            test.Visuals = Visuals.Clobber_Right;
            test.AnimationTarget = Slots.Front;

            Ability spawn = new Ability("Envy_Spawn_A");
            spawn.Name = "Envy Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "If this is the only Seventh Sin in combat, spawn as many copies of this enemy with 10 health as possible.";
            SpawnEnemyCopyHealthByEntryEffect copy = ScriptableObject.CreateInstance<SpawnEnemyCopyHealthByEntryEffect>();
            SoloSinEffectCondition front = ScriptableObject.CreateInstance<SoloSinEffectCondition>();
            spawn.Effects = [
                Effects.GenerateEffect(copy, 10, Slots.Self, front),
                Effects.GenerateEffect(copy, 10, Slots.Self, front),
                Effects.GenerateEffect(copy, 10, Slots.Self, front),
                Effects.GenerateEffect(copy, 10, Slots.Self, front),
                Effects.GenerateEffect(copy, 10, Slots.Self, front),
                ];
            spawn.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Misc_Hidden"]);
            spawn.AddIntentsToTarget(Slots.SlotTarget([-4, 4], true), ["Other_Spawn"]);
            spawn.AddIntentsToTarget(Slots.SlotTarget([-3, 3], true), ["Other_Spawn"]);
            spawn.AddIntentsToTarget(Slots.SlotTarget([-2, 2], true), ["Other_Spawn"]);
            spawn.AddIntentsToTarget(Slots.SlotTarget([-1, 1], true), ["Other_Spawn"]);
            spawn.Visuals = Visuals.Weep;
            spawn.AnimationTarget = Targeting.Unit_AllAllies;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
        public static void Greed(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin of Greed", "Sin_Greed_EN")
            {
                Health = 48,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("SinGreed_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinGreed_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Mordrake_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Mordrake_CH").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Greed_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Greed_Kill_A");
            test.Name = "Greed Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "Attempt to destroy the Opposing party member's held item, producing 2 items if successful.\nOtherwise, deal an Agonizing amount of damage to them.";
            ExtraLootEffect items = ScriptableObject.CreateInstance<ExtraLootEffect>();
            items._isTreasure = true;
            items._getLocked = true;
            test.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(items, 2, Slots.Self, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(false, 2))
                ];
            test.AddIntentsToTarget(Slots.Front, ["Misc", "Damage_7_10"]);
            test.Visuals = CustomVisuals.GetVisuals("Salt/Hunt");
            test.AnimationTarget = Slots.Front;

            Ability spawn = new Ability("Greed_Spawn_A");
            spawn.Name = "Greed Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "Attempt to split in two.\nIf unsuccessful, Inspire all party members.";
            spawn.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SplitInTwoEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<HasEnemySpaceEffectCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyInspirationEffect>(), 1, Targeting.Unit_AllOpponents, BasicEffects.DidThat(false)),
                ];
            spawn.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString()]);
            spawn.AddIntentsToTarget(Targeting.Unit_AllOpponents, [Inspiration.Intent]);
            spawn.Visuals = Visuals.Scales;
            spawn.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
        public static void Sloth(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin of Sloth", "Sin_Sloth_EN")
            {
                Health = 48,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("SinSloth_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinSloth_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Bimini_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Bimini_CH").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Sloth_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Sloth_Kill_A");
            test.Name = "Sloth Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "If all enemy positions are occupied, take a Mortal amount of damage and inflict a Slew of Negative Status Effects on all party members.";
            test.Effects = [
                Effects.GenerateEffect(BasicEffects.Empty, 1, Slots.Self, ScriptableObject.CreateInstance<HasEnemySpaceEffectCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 30, Slots.Self, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SlewStatusEffect>(), 1, Targeting.Unit_AllOpponents, BasicEffects.DidThat(false, 2))
                ];
            test.Visuals = Visuals.UglyOnTheInside;
            test.AnimationTarget = MultiTargetting.Create(Targetting.Everything(true), Targetting.Everything(false));
            test.AddIntentsToTarget(Targetting.Everything(true), ["Misc_Hidden"]);
            test.AddIntentsToTarget(Slots.Self, ["Damage_21"]);
            test.AddIntentsToTarget(Targetting.Everything(false), new string[]
            {
                FallColor.Intent,
                "Status_Cursed",
                "Status_Scars",
                Acid.Intent,
                Entropy.Intent,
                "Status_Frail",
                "Status_OilSlicked",
                Pimples.Intent,
                "Status_Ruptured",
                Magnetism.Intent,
            });

            Ability spawn = new Ability("Sloth_Spawn_A");
            spawn.Name = "Sloth Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "Attempt to revive a random dead Seventh Sin wih health equal to this enemy's.\nIf unsuccessful, takes a Mortal amount of damage.";
            spawn.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ReviveSinWithSelfHealthEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 30, Slots.Self, BasicEffects.DidThat(false))
                ];
            spawn.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Resurrect.ToString(), "Damage_21"]);
            spawn.Visuals = Visuals.Excommunicate;
            spawn.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
        public static void Gluttony(BasePassiveAbilitySO overdose)
        {
            Enemy template = new Enemy("Seventh Sin of Gluttony", "Sin_Gluttony_EN")
            {
                Health = 48,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SinGluttony_Icon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinGluttony_World.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinSeven_Dead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Delusion_EN").deathSound,
                UnitTypes = ["Sin"]
            };
            template.PrepareEnemyPrefab("Assets/Sins/Sin_Gluttony_Enemy.prefab", SaltsReseasoned.Meow, Gibs);

            template.AddPassives(new BasePassiveAbilitySO[] { overdose, Passives.Slippery, Passives.Theophobia, Passives.Withering });

            template.CombatEnterEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), 1)];
            template.CombatExitEffects = [Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Sin"), -1)];

            Ability test = new Ability("Gluttony_Kill_A");
            test.Name = "Gluttony Kills";
            test.Priority = Priority.Fast;
            test.Rarity = Rarity.Common;
            test.Description = "100 Pale comes for the Left, Right, and Opposing party members.\nInstantly kill this enemy.";
            test.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 10, Slots.FrontLeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self),
                ];
            test.AddIntentsToTarget(Slots.FrontLeftRight, [Pale.Intent]);
            test.AddIntentsToTarget(Slots.Self, ["Damage_Death"]);
            test.Visuals = CustomVisuals.GetVisuals("Salt/StarBomb");
            test.AnimationTarget = Slots.FrontLeftRight;

            Ability spawn = new Ability("Gluttony_Spawn_A");
            spawn.Name = "Gluttony Spawns";
            spawn.Priority = Priority.Slow;
            spawn.Rarity = Rarity.Common;
            spawn.Description = "Spawn a copy of this enemy with health equal to its missing health.\nSet this enemy's maximum health to its current health.";
            spawn.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnEnemyCopyBasedOffMissingHealth>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<MaxToCurrentEffect>(), 1, Slots.Self),
                ];
            spawn.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Other_MaxHealth.ToString()]);
            spawn.Visuals = Visuals.Egg;
            spawn.AnimationTarget = Slots.Self;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
                spawn.GenerateEnemyAbility(true)
            });
            template.SilentAddEnemy(true, true);
            template.enemy.AddToEcstasyPool();

            Sins.Add(template.enemy);
        }
    }
}
