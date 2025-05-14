using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Dragon
    {
        public static ParticleSystem Green;
        public static void Add()
        {
            Enemy dargon = new Enemy("The Dragon", "TheDragon_EN")
            {
                Health = 60,
                HealthColor = Pigments.Red,
                Size = 2,
                CombatSprite = ResourceLoader.LoadSprite("DragonIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DragonWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DragonDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Dragon>()
            };
            dargon.PrepareEnemyPrefab("assets/16/Dragon_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/Dragon_Gibs.prefab").GetComponent<ParticleSystem>());
            Green = SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/SecondGibsDragon.prefab").GetComponent<ParticleSystem>();

            //AWAKE MOVESET

            //SCORCH LEFT
            CustomOpponentTargetting_BySlot_Index tar_L = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            tar_L._frontOffsets = new int[1] { 0 };
            tar_L._slotPointerDirections = new int[1];
            Ability scorch_L = new Ability("ScorchLeft_A")
            {
                Name = "Scorch Left",
                Description = "Inflict 3 Fire on the Left Opposing party member position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, tar_L),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Scorch"),
                AnimationTarget = tar_L,
            };
            scorch_L.AddIntentsToTarget(tar_L, IntentType_GameIDs.Field_Fire.ToString().SelfArray());

            //SCORCH RIGHT
            CustomOpponentTargetting_BySlot_Index tar_R = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            tar_R._frontOffsets = new int[1] { 1 };
            tar_R._slotPointerDirections = new int[1];
            Ability scorch_R = new Ability("ScorchRight_A")
            {
                Name = "Scourge Right",
                Description = "Inflict 3 Fire on the Right Opposing party member position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, tar_R),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Scorch"),
                AnimationTarget = tar_R,
            };
            scorch_R.AddIntentsToTarget(tar_R, IntentType_GameIDs.Field_Fire.ToString().SelfArray());

            //PHOSPHOROUS
            Ability phosphate = new Ability("PhosphateFumes_A")
            {
                Name = "Phosphate Fumes",
                Description = "Deal a Little indirect damage to all party members.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.Indirect, 1, Targetting.AllEnemy)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals,
                AnimationTarget = Targetting.AllEnemy,
            };
            phosphate.AddIntentsToTarget(Targetting.AllEnemy, IntentType_GameIDs.Damage_1_2.ToString().SelfArray());

            //AWAKE REAL
            PerformEffectPassiveAbility awake = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            awake._passiveName = "Awoken";
            awake.m_PassiveID = "Dragon_Awake_PA";
            awake.passiveIcon = ResourceLoader.LoadSprite("AwakeDragonPassive.png");
            awake._enemyDescription = "The Dragon is awake.";
            awake._characterDescription = awake._enemyDescription;
            awake.doesPassiveTriggerInformationPanel = false;
            SetCasterAnimationParameterEffect param = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            param._parameterName = "Awake";
            param._parameterValue = 0;
            awake.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterPassivesToDefaultEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(param, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DragonSongEffect>(), 1, Slots.Self),
            };
            awake._triggerOn = new TriggerCalls[1] { TriggerCalls.TimelineEndReached };

            //NORIMIMI
            RemovePassiveEffect r = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            r.m_PassiveID = "Dragon_Awake_PA";
            AddPassiveEffect add = ScriptableObject.CreateInstance<AddPassiveEffect>();
            add._passiveToAdd = awake;
            Intents.CreateAndAddCustom_Basic_IntentToPool("DragonAsleep_PA", ResourceLoader.LoadSprite("AsleepDragonPassive.png"), Color.white);
            Ability norimimi = new Ability("Norimimi_A")
            {
                Name = "Norimimi",
                Description = "Inflict 1 Fire on all party member positions. Go to sleep at the end of the round.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                    Effects.GenerateEffect(r, 1,  Slots.Self),
                    Effects.GenerateEffect(add, 1, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals,
                AnimationTarget = TargettingSelf_NotSlot.Create(),
            };
            norimimi.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), IntentType_GameIDs.Field_Fire.ToString().SelfArray());
            norimimi.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), "DragonAsleep_PA".SelfArray());

            //AWAKE FAKE PASSIVE
            PerformEffectPassiveAbility fakeawake = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fakeawake._passiveName = "Awoken";
            fakeawake.m_PassiveID = "Dragon_Awake_PA";
            fakeawake.passiveIcon = ResourceLoader.LoadSprite("AwakeDragonPassive.png");
            fakeawake._enemyDescription = "The Dragon is awake.";
            fakeawake._characterDescription = fakeawake._enemyDescription;
            fakeawake.doesPassiveTriggerInformationPanel = true;
            fakeawake.effects = new EffectInfo[0];
            fakeawake._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };

            //ASLEEP PASSIVE
            PerformEffectPassiveAbility asleep = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            asleep._passiveName = "Slumber";
            asleep.m_PassiveID = "Dragon_Asleep_PA";
            asleep.passiveIcon = ResourceLoader.LoadSprite("AsleepDragonPassive.png");
            asleep._enemyDescription = "The Dragon is sleeping. On taking any damage, awaken.";
            asleep._characterDescription = asleep._enemyDescription;
            asleep.doesPassiveTriggerInformationPanel = false;
            SetCasterAnimationParameterEffect param_awake = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            param_awake._parameterName = "Awake";
            param_awake._parameterValue = 1;
            CasterSetStoredValueEffect a = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            a._valueName = UnitStoredValueNames_GameIDs.DemonCoreW.ToString();
            CasterSetStoredValueEffect b = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            b._valueName = DragonOnceCondition.Value;
            RaritySO five = ScriptableObject.CreateInstance<RaritySO>();
            five.canBeRerolled = true;
            five.rarityValue = 5;
            RaritySO three = ScriptableObject.CreateInstance<RaritySO>();
            three.canBeRerolled = true;
            three.rarityValue = 3;
            RerollSwapCasterAbilitiesEffect abil = ScriptableObject.CreateInstance<RerollSwapCasterAbilitiesEffect>();
            abil._abilitiesToSwap = new ExtraAbilityInfo[]
            {
                new ExtraAbilityInfo() {ability = scorch_L.GenerateEnemyAbility(true).ability, rarity = five},
                new ExtraAbilityInfo() {ability = scorch_R.GenerateEnemyAbility(true).ability, rarity = five},
                new ExtraAbilityInfo() {ability = phosphate.GenerateEnemyAbility(true).ability, rarity = five},
                new ExtraAbilityInfo() {ability = LoadedAssetsHandler.GetEnemyAbility("Chomp_A"), rarity = five},
                new ExtraAbilityInfo() {ability = norimimi.GenerateEnemyAbility(true).ability, rarity = three }
            };
            SwapCasterPassivesEffect pas = ScriptableObject.CreateInstance<SwapCasterPassivesEffect>();
            pas._passivesToSwap = new BasePassiveAbilitySO[]
            {
                Passives.Skittish, Passives.MultiAttack2, fakeawake
            };
            asleep.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(param_awake, 1, Slots.Self),
                Effects.GenerateEffect(a, 1, Slots.Self),
                Effects.GenerateEffect(abil, 1, Slots.Self),
                Effects.GenerateEffect(pas, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetFleetingEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DragonSongEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
                {
                    Effects.GenerateEffect(a, 0, Slots.Self),
                    Effects.GenerateEffect(b, 0, Slots.Self)
                }), 1, Slots.Self)
            };
            asleep._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDamaged };
            asleep.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<DragonOnceCondition>(), ScriptableObject.CreateInstance<IsAliveCondition>() };

            //addpassives
            dargon.AddPassives(new BasePassiveAbilitySO[] { Passives.FleetingGenerator(6), asleep });
            dargon.CombatExitEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DragonSongEffect>()).SelfArray();

            //ASLEEP MOVESET

            //SNEEZE
            Ability sneeze = new Ability("Dragon_Sneeze_A")
            {
                Name = "Sneeze",
                Description = "Inflict 1 Fire on the Opposing positions.",
                Rarity = three,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Slots.Front)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                AnimationTarget = Slots.Front,
            };
            sneeze.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Field_Fire.ToString().SelfArray());

            //SNORE
            Ability snore = new Ability("Dragon_Snore_A")
            {
                Name = "Snore",
                Description = "Does nothing.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("dragon10", 10),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, Slots.Self)
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };

            //DROOL
            Ability drool = new Ability("Dragon_Drool_A")
            {
                Name = "Drool",
                Description = "Inflict 3 Oil-Slicked on the Opposing party members.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, Slots.Front)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals,
                AnimationTarget = Slots.Front,
            };
            drool.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Status_OilSlicked.ToString().SelfArray());
            
            Ability snort = new Ability("Dragon_Snort_A")
            {
                Name = "Snort",
                Description = "This enemy might take a little indirect damage.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity2", 2),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Scream_1_A", true, TargettingSelf_NotSlot.Create()), 1, Slots.Self, Effects.ChanceCondition(50)),
                    Effects.GenerateEffect(BasicEffects.Indirect, 1, Slots.Self, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, Slots.Self, BasicEffects.DidThat(false, 2))
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            snort.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), IntentType_GameIDs.Damage_1_2.ToString().SelfArray());

            //ADD ENEMY
            dargon.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                sneeze.GenerateEnemyAbility(true),
                snore.GenerateEnemyAbility(true),
                drool.GenerateEnemyAbility(true),
                snort.GenerateEnemyAbility(true)
            });
            dargon.AddEnemy(true, true);
        }
    }
}
