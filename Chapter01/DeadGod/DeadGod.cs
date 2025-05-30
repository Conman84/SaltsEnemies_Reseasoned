using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class DeadGod
    {
        public static void Add()
        {
            //Unmasking
            UnmaskPassiveAbility unmask = ScriptableObject.CreateInstance<UnmaskPassiveAbility>();
            unmask._passiveName = "Unmasking (10)";
            unmask.m_PassiveID = "Unmasking_PA";
            unmask.passiveIcon = ResourceLoader.LoadSprite("Unmasking.png");
            unmask._characterDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this character.";
            unmask._enemyDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this enemy.";
            unmask.doesPassiveTriggerInformationPanel = false;
            unmask._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            

            //Desperate
            PerformEffectImmediatePassiveAbility desperate = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
            desperate._passiveName = "Desperate (3)";
            desperate.m_PassiveID = "Desperate_PA";
            desperate.passiveIcon = ResourceLoader.LoadSprite("Desperate.png");
            desperate._characterDescription = "On taking any damage, 33% chance to apply 3 Determined to self.";
            desperate._enemyDescription = "On taking any damage, 33% chance to apply 3 Determined to self.";
            desperate.doesPassiveTriggerInformationPanel = true;
            PercentageEffectorCondition desperateChance = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            desperateChance.triggerPercentage = 33;
            desperate.conditions = new EffectorConditionSO[1]
            {
                desperateChance
            };
            desperate.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 3, Targeting.Slot_SelfSlot),
            };
            desperate._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };

            //Enemy Code
            Enemy DeadGod = new Enemy("Embers of a Dead God", "EmbersofaDeadGod_EN")
            {
                Health = 150,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("DeadGodIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DeadGodDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DeadGodIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound,
            };
            DeadGod.PrepareEnemyPrefab("assets/TheShitter/DeadGod_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/TheShitter/DeadGod_Gibs.prefab").GetComponent<ParticleSystem>());

            DeadGod.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Inferno, 
                Passives.MultiAttack3,
                unmask,
                desperate
            });

            //Faith
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;

            Ability faith = new Ability("Forgotten Faith", "Salt_ForgottenFaith_A");
            faith.Description = "Apply 1-2 Power to this enemy.";
            faith.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity8", 8);
            faith.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(66)),
            };
            faith.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            faith.AnimationTarget = Targeting.Slot_SelfSlot;
            faith.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Power"
            });

            //Left Hand
            AnimationVisualsEffect rightExtrusion = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            rightExtrusion._animationTarget = Targeting.Slot_OpponentRight;
            rightExtrusion._visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            DamageEffect directHit = ScriptableObject.CreateInstance<DamageEffect>();
            directHit._ignoreShield = false;
            directHit._indirect = false;
            directHit._returnKillAsSuccess = false;
            directHit._usePreviousExitValue = false;

            Ability left = new Ability("Left Hand", "Salt_LeftHand_A");
            left.Description = "Move left and apply 1 Power to this enemy. Deal a little bit of damage to the right party member.";
            left.Rarity = Rarity.GetCustomRarity("rarity7");
            left.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(goLeft, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(rightExtrusion, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(directHit, 2, Targeting.Slot_OpponentRight),
            };
            left.Visuals = null;
            left.AnimationTarget = Targeting.Slot_SelfSlot;
            left.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Left",
                "Status_Power",
            });
            left.AddIntentsToTarget(Targeting.Slot_OpponentRight, new string[]
            {
                "Damage_1_2",
            });

            //Right Hand
            AnimationVisualsEffect pepTalk = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            pepTalk._animationTarget = Targeting.Slot_OpponentLeft;
            pepTalk._visuals = LoadedAssetsHandler.GetCharacterAbility("PepTalk_1_A").visuals;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability right = new Ability("Right Hand", "Salt_RightHand_A");
            right.Description = "Move right and deal a painful amount of damage to the left party member. If damage was dealt, apply 1 Power to this enemy.";
            right.Rarity = Rarity.GetCustomRarity("rarity8");
            right.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(goRight, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(pepTalk, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(directHit, 3, Targeting.Slot_OpponentLeft),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot, didThat),
            };
            right.Visuals = null;
            right.AnimationTarget = Targeting.Slot_SelfSlot;
            right.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Right",
            });
            right.AddIntentsToTarget(Targeting.Slot_OpponentLeft, new string[]
            {
                "Damage_3_6",
            });
            right.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Power",
            });

            //Promise
            DamageEffect shieldPierce = ScriptableObject.CreateInstance<DamageEffect>();
            shieldPierce._ignoreShield = true;
            shieldPierce._indirect = false;

            Ability promised = new Ability("Broken Promise", "Salt_BrokenPromise_A");
            promised.Description = "Apply 1-2 Power to self. Deal a little bit of damage to the opposing party member. This attack ignores shield. Apply 3 Ruptured to this enemy.";
            promised.Rarity = Rarity.GetCustomRarity("rarity7");
            promised.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(60)),
                Effects.GenerateEffect(shieldPierce, 2, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, Targeting.Slot_SelfSlot),
            };
            promised.Visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
            promised.AnimationTarget = Targeting.Slot_Front;
            promised.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Power",
                "Status_Ruptured",
            });
            promised.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_1_2",
            });

            //Apparition
            Ability apparition = new Ability("Divine Apparition", "Salt_DivineApparition_A");
            apparition.Description = "Move to a random position. Apply 1 fire to self, and 1-10 fire to the opposing party member. 33% chance to apply 1 Frail to self.";
            apparition.Rarity = Rarity.GetCustomRarity("rarity3");
            apparition.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CustomApplyFireSlotEffect>(), 1, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(33)),
            };
            apparition.AnimationTarget = Targeting.Slot_SelfSlot;
            apparition.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Mass",
                "Status_Frail",
            });
            apparition.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Field_Fire",
            });

            //World
            Ability world = new Ability("A Godless World", "Salt_AGodlessWorld_A");
            world.Description = "70% chance to give this enemy an additional turn. Apply 1 Power and 1 Scar to this enemy.";
            world.Rarity = Rarity.GetCustomRarity("rarity4");
            world.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CustomAddTurnToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            world.AnimationTarget = Targeting.Slot_SelfSlot;
            world.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc",
                "Status_Scars",
                "Status_Power",
            });

            //Blind
            AddPassiveEffect obscureIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            obscureIt._passiveToAdd = Passives.Confusion;

            Ability blind = new Ability("Blind Trust", "Salt_BlindTrust_A");
            blind.Description = "Apply Confusion as a passive to this enemy.";
            blind.Rarity = Rarity.GetCustomRarity("rarity3");
            blind.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(obscureIt, 1, Targeting.Slot_SelfSlot),
            };
            blind.Visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
            blind.AnimationTarget = Targeting.Slot_SelfSlot;
            blind.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc",
            });

            //Add
            DeadGod.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                faith.GenerateEnemyAbility(true),
                left.GenerateEnemyAbility(true),
                right.GenerateEnemyAbility(true),
                promised.GenerateEnemyAbility(true),
                apparition.GenerateEnemyAbility(true),
                world.GenerateEnemyAbility(true),
                blind.GenerateEnemyAbility(true),
            });
            DeadGod.AddEnemy(true);
        }
    }
}
