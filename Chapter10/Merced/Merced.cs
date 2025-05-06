using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Merced
    {
        public static void Add()
        {
            Enemy template = new Enemy("Merced", "Merced_EN")
            {
                Health = 1,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("MercedIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MercedWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MercedDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/MercedScream",
                DeathSound = "event:/Hawthorne/Die/MercedDie",
            };
            template.PrepareEnemyPrefab("assets/group4/Merced/Merced_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Merced/Merced_Gibs.prefab").GetComponent<ParticleSystem>());

            //well preserved
            //PreservedHandler.Setup();
            PerformEffectPassiveAbility preserve = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            preserve._passiveName = "Well Preserved";
            preserve.passiveIcon = ResourceLoader.LoadSprite("WellPreservedPassive.png");
            preserve._enemyDescription = "This enemy is immune to indirect damage and damage from other enemies.";
            preserve._characterDescription = "This party member is immune to indirect damage.";
            preserve.m_PassiveID = PreservedHandler.Type;
            preserve.doesPassiveTriggerInformationPanel = true;
            preserve._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
            preserve.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<WellPreservedCondition>() };
            preserve.effects = new EffectInfo[0];

            template.AddPassives(new BasePassiveAbilitySO[] { preserve, Passives.Skittish });

            RaritySO rarity = Rarity.GetCustomRarity("rarity5");
            RaritySO low = Rarity.CreateAndAddCustomRarityToPool("mercedLow", 3);
            RaritySO lower = Rarity.CreateAndAddCustomRarityToPool("mercedLower", 1);

            //shreddings
            Ability _shredding = new Ability("Merced_Shreddings_A")
            {
                Name = "Shreddings",
                Description = "Deal a Painful amount of damage to the Opposing party member. \nDeal damage to the Left and Right party members based on the amount of damage dealt to the Opposing party member. \nDeal damage to the Far Left and Far Right party members based on the amount of damage dealt to the Left and Right party members. \nContinue this pattern as long as possible.",
                Rarity = rarity,
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Front),
                            Effects.GenerateEffect(BasicEffects.ExitDamage, 1, Slots.LeftRight),
                            Effects.GenerateEffect(BasicEffects.ExitDamage, 1, Slots.SlotTarget(new int[]{-2, 2 }, false)),
                            Effects.GenerateEffect(BasicEffects.ExitDamage, 1, Slots.SlotTarget(new int[]{-3, 3 }, false)),
                            Effects.GenerateEffect(BasicEffects.ExitDamage, 1, Slots.SlotTarget(new int[]{-4, 4 }, false)),
                        },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals,
                AnimationTarget = Targetting.Everything(false),
            };
            _shredding.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            _shredding.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Damage_3_6.ToString()]);
            _shredding.AddIntentsToTarget(Targeting.Slot_OpponentFarSides, [IntentType_GameIDs.Damage_3_6.ToString()]);
            _shredding.AddIntentsToTarget(Slots.SlotTarget(new int[] { -3, 3 }, false), [IntentType_GameIDs.Damage_3_6.ToString()]);
            _shredding.AddIntentsToTarget(Slots.SlotTarget(new int[] { -4, 4 }, false), [IntentType_GameIDs.Damage_3_6.ToString()]);

            //binders
            DamageTargetsBySubTargetMissingHealthEffect hit = ScriptableObject.CreateInstance<DamageTargetsBySubTargetMissingHealthEffect>();
            hit.Sub = Slots.Front;
            AliveFrontTargetCondition front = ScriptableObject.CreateInstance<AliveFrontTargetCondition>();
            Ability _binder = new Ability("Merced_Binder_A")
            {
                Name = "Binder",
                Description = "If there is an Opposing party member, deal damage equal to their missing health to the Opposing party member.\nIf there is an Opposing party member, deal damage equal to their missing health to the Left, Opposing, and Right party members. \nIf there is an Opposing party member, deal damage equal to their missing health to the Far Left, Left, Opposing, Right, and Far Right party members.\nContinue this pattern as long as possible.",
                Rarity = low,
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(hit, 1, Slots.Front),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ribbon", false, Slots.FrontLeftRight), 1, Slots.Front, front),
                            Effects.GenerateEffect(hit, 1, Slots.FrontLeftRight),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ribbon", false, Slots.SlotTarget(new int[]{-2, -1, 0, 1, 2 }, false)), 1, Slots.Front, front),
                            Effects.GenerateEffect(hit, 1, Slots.SlotTarget(new int[]{-2, -1, 0, 1, 2 }, false)),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ribbon", false, Slots.SlotTarget(new int[]{-3, -2, -1, 0, 1, 2, 3 }, false)), 1, Slots.Front, front),
                            Effects.GenerateEffect(hit, 1, Slots.SlotTarget(new int[]{-3, -2, -1, 0, 1, 2, 3 }, false)),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ribbon", false, Targetting.Everything(false)), 1, Slots.Front, front),
                            Effects.GenerateEffect(hit, 1, Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Ribbon"),
                AnimationTarget = Slots.Front,
            };
            _binder.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_16_20.ToString()]);
            _binder.AddIntentsToTarget(Slots.FrontLeftRight, [IntentType_GameIDs.Damage_16_20.ToString()]);
            _binder.AddIntentsToTarget(Slots.SlotTarget(new int[] { -2, -1, 0, 1, 2 }, false), [IntentType_GameIDs.Damage_16_20.ToString()]);
            _binder.AddIntentsToTarget(Slots.SlotTarget(new int[] { -3, -2, -1, 0, 1, 2, 3 }, false), [IntentType_GameIDs.Damage_16_20.ToString()]);
            _binder.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.Damage_16_20.ToString()]);

            //engravings
            Ability _engravings = new Ability("Merced_BloodEngravings_A")
            {
                Name = "Blood Engravings",
                Description = "Deal a Little bit of damage and apply Focused to the Opposing party member. \nIf damage was dealt and the Opposing party member survives, force the Opposing party member to use this ability on their Left and Right allies.",
                Rarity = rarity,
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<EngravingsEffect>(), 2, Slots.Front),
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                AnimationTarget = Slots.Front,
            };
            _engravings.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Focused.ToString()]);

            //press
            Ability _press = new Ability("Merced_WeightedPress_A")
            {
                Name = "Weighted Press",
                Description = "Deal damage equal to the total health of all enemies divided amongst all party members connected to the Opposing party member.",
                Rarity = low,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AllEnemyMaxHealthExitCollectEffect>(), 1, Targetting.AllAlly),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DivideUpDamageExitValueEffect>(), 1, ScriptableObject.CreateInstance<AllTargetsTouchingFrontSingleSizeOnly>())
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                AnimationTarget = ScriptableObject.CreateInstance<AllTargetsTouchingFrontSingleSizeOnly>(),
            };
            _press.AddIntentsToTarget(Targetting.AllAlly, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            _press.AddIntentsToTarget(ScriptableObject.CreateInstance<AllTargetsTouchingFrontSingleSizeOnly>(), new string[] { FallColor.Intent, IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Damage_11_15.ToString(), IntentType_GameIDs.Damage_16_20.ToString(), IntentType_GameIDs.Damage_21.ToString() });

            Ability _descriptions = new Ability("Merced_Depictions_A")
            {
                Name = "Depiction",
                Description = "Copy all Status Effects from all enemies and party members onto this enemy. \nThen, copy all Status Effects from all enemies and party members onto the Opposing party member. \nThen, deal damage to the Opposing party member for the amount of Status Effects on all enemies and party members. \n1 Restrictor of a Status counts as 4 stacks.",
                Rarity = lower,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.Empty, 1, Targetting.AllEnemy),
                    Effects.GenerateEffect(BasicEffects.Empty, 1, Targetting.AllAlly),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, MultiTargetting.Create(Targetting.AllEnemy, Targetting.AllAlly)),
                    Effects.GenerateEffect(SubActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, MultiTargetting.Create(Targetting.AllEnemy, Targetting.AllAlly))
                    }), 1, Slots.Front),
                    Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Bullet", false, Slots.Front), 1, Slots.Front),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<CountAllStatusEffect>(), 1, MultiTargetting.Create(Targetting.AllEnemy, Targetting.AllAlly)),
                        Effects.GenerateEffect(BasicEffects.ExitDamage, 1, Slots.Front)
                    }), 1, Slots.Front)
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            _descriptions.AddIntentsToTarget(Targetting.AllEnemy, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            _descriptions.AddIntentsToTarget(Targetting.AllAlly, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            _descriptions.AddIntentsToTarget(Slots.Front, new string[] { FallColor.Intent, IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Damage_11_15.ToString(), IntentType_GameIDs.Damage_16_20.ToString(), IntentType_GameIDs.Damage_21.ToString() });

            //indexing
            Ability _indexing = new Ability("Merced_Indexing_A")
            {
                Name = "Indexing",
                Description = "Deal " + CountFibonacci.Get(42) + " damage to the Opposing party member. \nIf this would cause an error, crash the game.",
                Rarity = lower,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageIfFailDeal1Effect>(), CountFibonacci.Get(42), Slots.Front),
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            _indexing.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_Death.ToString()]);

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                _shredding.GenerateEnemyAbility(true),
                _binder.GenerateEnemyAbility(true),
                _engravings.GenerateEnemyAbility(true),
                _press.GenerateEnemyAbility(true),
                _descriptions.GenerateEnemyAbility(true),
                _indexing.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }
}
