using BrutalAPI;
using HarmonyLib;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class GreyFlower
    {
        public static void Add()
        {
            //PASSIVES
            PerformEffectPassiveAbility splatter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            splatter._passiveName = "Splatter";
            splatter.passiveIcon = ResourceLoader.LoadSprite("splatter.png");
            splatter._enemyDescription = "On death, produce 4 pigment of this enemy's health color.";
            splatter._characterDescription = "On death, produce 4 pigment of this character's health color.";
            splatter.m_PassiveID = "Splatter_PA";
            splatter.doesPassiveTriggerInformationPanel = true;
            splatter._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            splatter.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 4, Targeting.Slot_SelfSlot) };

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

            //enemy
            Enemy greyFlower = new Enemy("Glowing Flower", "GreyFlower_EN")
            {
                Health = 40,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("GreyFlowerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GreyFlowerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GreyFlowerWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound,
            };
            greyFlower.PrepareEnemyPrefab("assets/group4/GreyFlower/GreyFlower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/GreyFlower/GreyFlower_Gibs.prefab").GetComponent<ParticleSystem>());

            greyFlower.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, splatter, grow });
            greyFlower.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();

            //DIE4U
            GenerateRandomManaBetweenEffect allpig = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            allpig.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow,
                        Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Green,
                        Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue,
                        Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, };
            RandomizeAllManaEffect alltray = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            alltray.manaRandomOptions = new ManaColorSO[] { Pigments.Grey };
            RandomizeAllOverflowEffect allflow = ScriptableObject.CreateInstance<RandomizeAllOverflowEffect>();
            allflow.manaRandomOptions = new ManaColorSO[] { Pigments.Grey };

            Ability dieu = new Ability("Die4U_A")
            {
                Name = "Die for You",
                Description = "Deal a Lethal amount of damage to this enemy and generate 12 random pigment. Turn all pigment in the tray and in overflow grey. \nApply 1 Photosynthesis to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 16, Slots.Self),
                            Effects.GenerateEffect(allpig, 12, Slots.Self),
                            Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(alltray, 1, Slots.Self),
                                Effects.GenerateEffect(allflow, 1, Slots.Self),
                            }), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Hung"),
                AnimationTarget = Slots.Self
            };
            dieu.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_16_20.ToString(), IntentType_GameIDs.Mana_Generate.ToString(), IntentType_GameIDs.Mana_Randomize.ToString(), Photo.Intent]);

            //basic flower abilities
            EnemyAbilityInfo aroma = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Flower_Aroma_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            EnemyAbilityInfo photo = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Flowers_Photosynthesize_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //addenemy
            greyFlower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                aroma,
                photo,
                dieu.GenerateEnemyAbility(true),
            });
            greyFlower.AddEnemy(true, true);
        }
    }
}
