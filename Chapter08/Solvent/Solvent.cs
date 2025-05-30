using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Solvent
    {
        public static void Add()
        {
            Enemy solvent = new Enemy("Living Solvent", "LivingSolvent_EN")
            {
                Health = 12,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SolventIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SolventDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SolventWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").deathSound,
            };
            solvent.PrepareEnemyPrefab("assets/group4/Solvent/Solvent_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Solvent/Solvent_Gibs.prefab").GetComponent<ParticleSystem>());

            //SURVIVAL
            AnimationVisualsEffect core = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            core._visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
            core._animationTarget = Targeting.Slot_SelfSlot;
            PerformEffectImmediatePassiveAbility survival = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
            survival._passiveName = "Survival Instinct";
            survival.passiveIcon = ResourceLoader.LoadSprite("survival.png");
            survival._enemyDescription = "On death, instantly kill the lowest health party member. \nDoes not trigger on Withering.";
            survival._characterDescription = "On death, instantly kill the lowest health enemy. \nDoes not trigger on Withering";
            survival.m_PassiveID = "Survival_Instinct_PA";
            survival.doesPassiveTriggerInformationPanel = true;
            survival._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            DeathReferenceDetectionEffectorCondition noWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            noWither._useWithering = true;
            noWither._witheringDeath = false;
            survival.conditions = new EffectorConditionSO[]
            {
                noWither
            };
            survival.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect(core, 1, Targeting.Slot_SelfSlot),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targetting.LowestEnemy)
            };

            //FLITHERING
            PerformEffectPassiveAbility flither = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            flither._passiveName = "Flithering";
            flither.passiveIcon = ResourceLoader.LoadSprite("FlitheringIcon.png");
            flither.m_PassiveID = FlitheringHandler.Flithering;
            flither._enemyDescription = "On any enemy dying, if there are no other enemies without \"Withering\" or \"Flithering\" as passives, instantly flee.\n" +
                "At the start and end of the enemies' turn, if there are no other enemies without \"Cowardice\" or \"Flithering\" as passives, instantly flee.";
            flither._characterDescription = "doesnt work";
            flither.doesPassiveTriggerInformationPanel = false;
            flither.effects = new EffectInfo[] { Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CowardEffect>(), 1, Slots.Self)
            }), 1, Slots.Self) };
            flither._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnRoundFinished };
            flither.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<CowardCondition>()
            };

            //INTIMIDATED
            DelayedAttackManager.Setup();
            PerformEffectPassiveAbility fear = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fear._passiveName = "Intimidated";
            fear.passiveIcon = ResourceLoader.LoadSprite("intimidated.png");
            fear.m_PassiveID = "Intimidated_PA";
            fear._enemyDescription = "When a party member moves in front of this enemy, reroll one of this enemy's actions.";
            fear._characterDescription = "wotn workn...";
            fear.doesPassiveTriggerInformationPanel = true;
            fear.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ReRollTargetTimelineAbilityEffect>(), 1, Targeting.Slot_SelfSlot) };
            fear._triggerOn = new TriggerCalls[1] { (TriggerCalls)AmbushManager.Patiently };
            

            //ADD PASSIVES
            solvent.AddPassives(new BasePassiveAbilitySO[] { survival, fear, Passives.FleetingGenerator(5), flither, Passives.Dying });

            //BLOODLETTING
            Ability bloodletting = new Ability("Salt_Bloodletting_A")
            {
                Name = "Bloodletting",
                Description = "Clumsily deals a Little damage and inflict 1 Ruptured to this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<FakeOneRupturedEffect>(), 2, Targeting.Slot_SelfSlot)
                        },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals,
                AnimationTarget = Targeting.Slot_SelfSlot
            };
            bloodletting.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });

            //Camouflage
            Ability camo = new Ability("Salt_Camo_A")
            {
                Name = "Camouflage",
                Description = "Copy the Status Effects from the Left and Right enemies onto this enemy.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Priority = Priority.Slow,
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, Targeting.Slot_AllySides),
                        },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals,
                AnimationTarget = Targeting.GenerateSlotTarget(new int[] { -1, 0, 1 }, true)
            };
            camo.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });
            camo.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });

            //RUNAWAY
            IsFrontTargetCondition front = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
            front.returnTrue = true;
            Ability runaway = new Ability("Salt_Runaway_A")
            {
                Name = "Runaway",
                Description = "Move to the Left or Right. If there is an Opposing party member, inflict one Frail to this enemy then move Left or Right again.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Priority = Priority.Fast,
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(BasicEffects.PlaySound(LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals.audioReference), 1, Targeting.Slot_SelfSlot),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<FakeOneFrailEffect>(), 2, Targeting.Slot_SelfSlot),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot)
                            }), 1, Targeting.Slot_Front, front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Door"),
                AnimationTarget = Targeting.Slot_SelfSlot
            };
            runaway.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            runaway.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });
            runaway.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Swap_Sides.ToString() });

            //ADD ENEMY
            solvent.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bloodletting.GenerateEnemyAbility(true),
                camo.GenerateEnemyAbility(true),
                runaway.GenerateEnemyAbility(true)
            });
            solvent.AddEnemy(true, false, true);

            PassivesToCamera();
        }

        public static void PassivesToCamera()
        {
            CameraEffects.AddPassive("Splatter_PA");
            CameraEffects.AddPassive("Flowers_Overgrowth_PA");
            CameraEffects.AddPassive("Salt_Asphyxiation_PA");
            CameraEffects.AddPassive(DrowningManager.Saline);
            CameraEffects.AddPassive("PostModern_PA");
            CameraEffects.AddPassive("NoPause_PA");
            CameraEffects.AddPassive("Survival_Instinct_PA");
            CameraEffects.AddPassive(FireNoReduce.PassiveID);
            CameraEffects.AddPassive("Tank_Warning_PA");
        }
    }
}
