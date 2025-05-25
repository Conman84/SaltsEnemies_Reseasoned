using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class RBYPFlowers
    {
        public static void Add()
        {
            PerformEffectPassiveAbility splatter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            splatter._passiveName = "Splatter";
            splatter.passiveIcon = ResourceLoader.LoadSprite("splatter.png");
            splatter._enemyDescription = "On death, produce 4 pigment of this enemy's health color.";
            splatter._characterDescription = "On death, produce 4 pigment of this character's health color.";
            splatter.m_PassiveID = "Splatter_PA";
            splatter.doesPassiveTriggerInformationPanel = true;
            splatter._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            splatter.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 4, Targeting.Slot_SelfSlot) };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("splatter.png"), "Splatter", splatter._enemyDescription);

            PerformEffectPassiveAbility grow = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            grow._passiveName = "Overgrowth";
            grow.m_PassiveID = "Flowers_Overgrowth_PA";
            grow.passiveIcon = ResourceLoader.LoadSprite("Overgrowth.png");
            grow._enemyDescription = "On taking direct damage, inflict 3 Roots on the Opposing position.";
            grow._characterDescription = grow._enemyDescription;
            grow.doesPassiveTriggerInformationPanel = true;
            grow.effects = new EffectInfo[] { Effects.GenerateEffect(CasterRootActionEffect.Create(new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 3, Targeting.Slot_Front) }), 1, Targeting.Slot_SelfSlot) };
            grow._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
            grow.conditions = Passives.Slippery.conditions;
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Overgrowth.png"), "Overgrowth", grow._enemyDescription);

            //AROMA
            Ability aroma_1 = new Ability("Flower_Aroma_A")
            {
                Name = "Aroma",
                Description = "Move the Left and Right party members closer to this enemy. \nIf the Opposing position has Roots, deal a Painful amount of damage to the Opposing party member. \nApply 3 Roots to the Opposing position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(BasicEffects.GoRight, 1, Targeting.Slot_OpponentLeft),
                            Effects.GenerateEffect(BasicEffects.GoLeft, 1, Targeting.Slot_OpponentRight),
                            Effects.GenerateEffect(CasterRootActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(BasicEffects.GetVisuals("Thorns_1_A", true, Targeting.Slot_Front), 1, Targeting.Slot_Front),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<IfRootsDamageEffect>(), 5, Targeting.Slot_Front),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 3, Targeting.Slot_Front)
                            }), 1, Targeting.Slot_Front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Rose"),
                AnimationTarget = Targeting.Slot_SelfSlot
            };
            aroma_1.AddIntentsToTarget(Targeting.Slot_OpponentLeft, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            aroma_1.AddIntentsToTarget(Targeting.Slot_OpponentRight, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            aroma_1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), Roots.Intent });


            //AROMA
            Ability aroma_2 = new Ability("Flower_Bouquet_A")
            {
                Name = "Bouquet",
                Description = "Move the Left and Right party members closer to this enemy. \nIf the Opposing position has Roots, deal an Agonizing amount of damage to the Opposing party member. \nApply 3 Roots to the Opposing position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(BasicEffects.GoRight, 1, Targeting.Slot_OpponentLeft),
                            Effects.GenerateEffect(BasicEffects.GoLeft, 1, Targeting.Slot_OpponentRight),
                            Effects.GenerateEffect(CasterRootActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(BasicEffects.GetVisuals("Thorns_1_A", true, Targeting.Slot_Front), 1, Targeting.Slot_Front),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<IfRootsDamageEffect>(), 7, Targeting.Slot_Front),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 3, Targeting.Slot_Front)
                            }), 1, Targeting.Slot_Front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Rose"),
                AnimationTarget = Targeting.Slot_SelfSlot
            };
            aroma_2.AddIntentsToTarget(Targeting.Slot_OpponentLeft, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            aroma_2.AddIntentsToTarget(Targeting.Slot_OpponentRight, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            aroma_2.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString(), Roots.Intent });

            //PHOTOSYNTHESIZE
            HealEffect prevExit = ScriptableObject.CreateInstance<HealEffect>();
            prevExit.usePreviousExitValue = true;
            Ability photosynthesize = new Ability("Photosynthesize", "Flowers_Photosynthesize_A")
            {
                Description = "Consume all Pigment of this enemy's health color and apply double the amount of Pigment consumed as Roots, distributed among all occupied party member positions. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllCasterHealthManaEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DistributeRootsEffect>(), 1, Targetting.AllEnemy),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Sprout"),
                AnimationTarget = Targeting.Slot_SelfSlot
            };
            photosynthesize.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Consume.ToString(), Photo.Intent });
            photosynthesize.AddIntentsToTarget(Targetting.AllEnemy, new string[] { Roots.Intent });

            //REDFLOWER
            Enemy redflower = new Enemy("Bloody Flower", "RedFlower_EN")
            {
                Health = 32,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("RedFlowerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("RedFlowerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RedFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound,
            };
            redflower.PrepareEnemyPrefab("assets/group4/RedFlower/RedFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/RedFlower/RedFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            redflower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            redflower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //RED SPECIAL
            Ability loveu = new Ability("Love for You", "Love4U_A")
            {
                Description = "If the Opposing party member has Power, instantly kill them. Apply 5 Power on the Opposing party member.\nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<KillIfPowerEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 5, Targeting.Slot_Front, BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Snap"),
                AnimationTarget = Targeting.Slot_Front
            };
            loveu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_Death.ToString(), Power.Intent });
            loveu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { Photo.Intent });

            //RED ADD
            redflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma_2.GenerateEnemyAbility(true),
                photosynthesize.GenerateEnemyAbility(true),
                loveu.GenerateEnemyAbility(true),
            });
            redflower.AddEnemy(true, true);

            //BLUEFLOWER
            Enemy blueflower = new Enemy("Glowing Flower", "BlueFlower_EN")
            {
                Health = 32,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("BlueFlowerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BlueFlowerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BlueFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Mung_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Mung_EN").deathSound,
            };
            blueflower.PrepareEnemyPrefab("assets/group4/BlueFlower/BlueFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/BlueFlower/BlueFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            blueflower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            blueflower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //BLUE SPECIAL
            Ability cryu = new Ability("Cry for You", "Cry4U_A")
            {
                Description = "Heal the Opposing party member a Little health. Instantly kill the Opposing party member if they were not healed. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 3, Targeting.Slot_Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Front, BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Rain"),
                AnimationTarget = Slots.Front
            };
            cryu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Heal_1_4.ToString(), IntentType_GameIDs.Damage_Death.ToString() });
            cryu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { Photo.Intent });

            //BLUE ADD
            blueflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma_2.GenerateEnemyAbility(false),
                photosynthesize.GenerateEnemyAbility(false),
                cryu.GenerateEnemyAbility(true),
            });
            blueflower.AddEnemy(true, true);

            //YELLOWFLOWER
            Enemy yellowflower = new Enemy("Sunny Flower", "YellowFlower_EN")
            {
                Health = 24,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("YellowFlowerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("YellowFlowerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("YellowFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").deathSound,
            };
            yellowflower.PrepareEnemyPrefab("assets/group4/YellowFlower/YellowFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/YellowFlower/YellowFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            yellowflower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            yellowflower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //YELLOW SPECIAL
            TargettingRandomUnit randoEnemy = ScriptableObject.CreateInstance<TargettingRandomUnit>();
            randoEnemy.getAllies = false;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            Ability smileu = new Ability("Smile for You", "Smile4U_A")
            {
                Description = "Apply Spotlight on the Opposing party member. Apply 1 Muted to a random party member. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, randoEnemy),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Smile"),
                AnimationTarget = Targeting.Slot_Front
            };
            smileu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Spotlight.ToString() });
            smileu.AddIntentsToTarget(allEnemy, new string[] { Muted.Intent });
            smileu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { Photo.Intent });

            //YELLOW ADD
            yellowflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma_1.GenerateEnemyAbility(false),
                photosynthesize.GenerateEnemyAbility(false),
                smileu.GenerateEnemyAbility(true),
            });
            yellowflower.AddEnemy(true, true);

            //PURPLEFLOWER
            Enemy purpleflower = new Enemy("Rotten Flower", "PurpleFlower_EN")
            {
                Health = 24,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("PurpleFlowerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PurpleFlowerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PurpleFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound,
            };
            purpleflower.PrepareEnemyPrefab("assets/group4/PurpleFlower/PurpleFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/PurpleFlower/PurpleFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            purpleflower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            purpleflower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //PURPLE SPECIAL
            AddPassiveEffect confuse = ScriptableObject.CreateInstance<AddPassiveEffect>();
            confuse._passiveToAdd = Passives.Confusion;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Ability lieu = new Ability("Lie for You", "Lie4U_A")
            {
                Description = "Apply Confusion as a passive on the Opposing party member. If Confusion was applied, apply 12 Shield to all party member positions, otherwise, produce 4 Purple Pigment. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(confuse, 1, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 12, Targeting.GenerateSlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), didThat),
                            Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Purple), 4, Targeting.Slot_SelfSlot, BasicEffects.DidThat(false, 2)),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Whisper"),
                AnimationTarget = Targeting.Slot_Front
            };
            lieu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });
            lieu.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            lieu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString(), Photo.Intent });

            //PURPLEADD
            purpleflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma_1.GenerateEnemyAbility(false),
                photosynthesize.GenerateEnemyAbility(false),
                lieu.GenerateEnemyAbility(true),
            });
            purpleflower.AddEnemy(true, true);
        }
    }
}
