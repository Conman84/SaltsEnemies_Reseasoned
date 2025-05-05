using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Tripod
    {
        public static void Add()
        {
            Enemy tripod = new Enemy("Ipnopidae", "Tripod_EN")
            {
                Health = 30,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("TripodIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TripodWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TripodDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Tripod>()
            };
            tripod.PrepareEnemyPrefab("assets/group4/Tripod/Tripod_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Tripod/Tripod_Gibs.prefab").GetComponent<ParticleSystem>());

            //unmasking
            UnmaskPassiveAbility unmasking = ScriptableObject.CreateInstance<UnmaskPassiveAbility>();
            unmasking._passiveName = "Unmasking (6)";
            unmasking.passiveIcon = ResourceLoader.LoadSprite("Unmasking.png");
            unmasking.m_PassiveID = "Unmasking_PA";
            unmasking._enemyDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this enemy.";
            unmasking._characterDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this character.";
            unmasking.doesPassiveTriggerInformationPanel = false;
            unmasking._floorVal = 6;
            unmasking._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            tripod.AddPassives(new BasePassiveAbilitySO[] { unmasking });
            tripod.AddUnitType("Fish");

            Ability longSlice = new Ability("LongSlice_A")
            {
                Name = "Long Slice",
                Description = "If this enemy has Confusion as a passive, deal an Agonizing amount of damage to the far far Left and far far Right party members. This attack is fully blocked by Shield. \nOtherwise, give this enemy another action.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tripod10", 10),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Decapitate", false, Targeting.GenerateSlotTarget(new int[] {-3, 3}, false)), 1, Targeting.GenerateSlotTarget(new int[] {-3, 3 }, false), HasConfusionCondition.Create(true)),
                    Effects.GenerateEffect(BasicEffects.ShieldBlocked, 10, Targeting.GenerateSlotTarget(new int[] {-3, 3}, false), HasConfusionCondition.Create(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, HasConfusionCondition.Create(false)),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            longSlice.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -3, 3 }, false), [IntentType_GameIDs.Damage_7_10.ToString()]);
            longSlice.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc_Hidden.ToString(), IntentType_GameIDs.Misc_Additional.ToString()]);

            Ability foggyLens = new Ability("FoggyLens_A")
            {
                Name = "Foggy Lens",
                Description = "Apply Confusion as a passive to this enemy. \nIf this enemy already had Confusion, give this enemy Spotlight.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tripod3", 3),
                Priority = Priority.ExtremelySlow,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, Slots.Self, HasConfusionCondition.Create(true)),
                    Effects.GenerateEffect(BasicEffects.AddPassive(Passives.Confusion), 1, Slots.Self, HasConfusionCondition.Create(false))
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Fog"),
                AnimationTarget = Slots.Self,
            };
            foggyLens.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.PA_Confusion.ToString(), IntentType_GameIDs.Status_Spotlight.ToString()]);

            Ability shortStomp = new Ability("ShortStomp_A")
            {
                Name = "Short Stomp",
                Description = "If this enemy does not Confusion as a Passive, heal it a Moderate amount health. \nOtherwise, deal a Painful amount of damage to the Opposing party member and inflict 2 Ruptured upon them, then move this enemy 3 spaces Left or Right.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tripod8", 8),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("FallingSkies_A", false, Slots.Self), 1, Slots.Self, HasConfusionCondition.Create(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 10, Slots.Self, HasConfusionCondition.Create(false)),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("FallingSkies_A", false, Slots.Front), 0, Slots.Front, HasConfusionCondition.Create(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front, HasConfusionCondition.Create(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front, HasConfusionCondition.Create(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ShortStompEffect>(), 1, Slots.Self, HasConfusionCondition.Create(true)),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            shortStomp.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Heal_5_10.ToString(), IntentType_GameIDs.Misc_Hidden.ToString()]);
            shortStomp.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Ruptured.ToString()]);
            shortStomp.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);

            //ADD ENEMY
            tripod.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                longSlice.GenerateEnemyAbility(true),
                foggyLens.GenerateEnemyAbility(true),
                shortStomp.GenerateEnemyAbility(true)
            });
            tripod.AddEnemy(true, true);
        }
    }
}
