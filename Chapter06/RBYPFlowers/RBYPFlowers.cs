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
            Debug.LogError("make sure the correct sprites are being loaded");

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
            Ability aroma = new Ability("Flower_Aroma_A")
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
            aroma.AddIntentsToTarget(Targeting.Slot_OpponentLeft, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            aroma.AddIntentsToTarget(Targeting.Slot_OpponentRight, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            aroma.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), Roots.Intent });

            //PHOTOSYNTHESIZE
            HealEffect prevExit = ScriptableObject.CreateInstance<HealEffect>();
            prevExit.usePreviousExitValue = true;
            Ability photosynthesize = new Ability("Photosynthesize", "Flowers_Photosynthesize_A")
            {
                Description = "Consume all Pigment of this enemy's health color and apply double the amount of Pigment consumed as Roots, distributed among all occupied party member positions. \nApply 1 Photosynthesis to this enemy. \nThis ability cannot be selected if there is no Pigment of this enemy's health color in the tray, and must be selected if there is over 5 Pigment of the health color.",
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
                OverworldDeadSprite = ResourceLoader.LoadSprite("RedFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RedFlowerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound,
            };
            redflower.PrepareEnemyPrefab("assets/group4/RedFlower/RedFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/RedFlower/RedFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            redflower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            redflower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //RED SPECIAL
            Ability loveu = new Ability("Love for You", "Love4U_A")
            {
                Description = "Apply 4 Power on the Opposing party member. Apply 20 Shield to this enemy's position, and 5 to it's Let and Right. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 4, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 20, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, Targeting.Slot_AllySides),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Snap"),
                AnimationTarget = Targeting.Slot_Front
            };
            loveu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { Power.Intent });
            loveu.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            loveu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { Photo.Intent });

            //RED ADD
            redflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma.GenerateEnemyAbility(true),
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
                OverworldDeadSprite = ResourceLoader.LoadSprite("BlueFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BlueFlowerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Mung_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Mung_EN").deathSound,
            };
            blueflower.PrepareEnemyPrefab("assets/group4/BlueFlower/BlueFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/BlueFlower/BlueFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            blueflower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            blueflower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //BLUE SPECIAL
            Ability cryu = new Ability("Cry for You", "Cry4U_A")
            {
                Description = "Heal the Opposing party member a Little health. Attempt to change the closest Left and Right enemies' health color to Blue and heal them. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 3, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeHealthColorByCasterColorEffect>(), 1, Targetting.Closer(true, true)),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 5, Targetting.Closer(true, true)),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Rain"),
                AnimationTarget = MultiTargetting.Create(Targeting.Slot_Front, Targetting.Closer(true, true))
            };
            cryu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Heal_1_4.ToString(), });
            cryu.AddIntentsToTarget(Targetting.Closer(true, true), new string[] { IntentType_GameIDs.Mana_Randomize.ToString(), IntentType_GameIDs.Heal_5_10.ToString() });
            cryu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { Photo.Intent });

            //BLUE ADD
            blueflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma.GenerateEnemyAbility(false),
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
                OverworldDeadSprite = ResourceLoader.LoadSprite("YellowFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("YellowFlowerDead.png", new Vector2(0.5f, 0f), 32),
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
                Description = "Apply Spotlight on the Opposing party member. Apply 1 Stunned to a random party member. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, Targeting.Slot_Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, randoEnemy),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Smile"),
                AnimationTarget = Targeting.Slot_Front
            };
            smileu.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Spotlight.ToString() });
            smileu.AddIntentsToTarget(allEnemy, new string[] { IntentType_GameIDs.Status_Stunned.ToString() });
            smileu.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { Photo.Intent });

            //YELLOW ADD
            yellowflower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma.GenerateEnemyAbility(false),
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
                OverworldDeadSprite = ResourceLoader.LoadSprite("PurpleFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PurpleFlowerDead.png", new Vector2(0.5f, 0f), 32),
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
                aroma.GenerateEnemyAbility(false),
                photosynthesize.GenerateEnemyAbility(false),
                lieu.GenerateEnemyAbility(true),
            });
            purpleflower.AddEnemy(true, true);
        }
    }
}
