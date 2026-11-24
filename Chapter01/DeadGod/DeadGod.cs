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
            desperate._passiveName = "Desperate (2)";
            desperate.name = "Desparate_2_PA";
            desperate.m_PassiveID = "Desperate_PA";
            desperate.passiveIcon = ResourceLoader.LoadSprite("Desperate.png");
            desperate._characterDescription = "On being directy damaged, gain 2 Determined.";
            desperate._enemyDescription = "On being directly damaged, gain 2 Determined.";
            desperate.doesPassiveTriggerInformationPanel = true;
            desperate.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 2, Targeting.Slot_SelfSlot),
            };
            desperate._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            desperate.AddToPassiveDatabase();

            //Enemy Code
            Enemy DeadGod = new Enemy("Embers of a Dead God", "EmbersofaDeadGod_EN")
            {
                Health = 150,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("DeadGodIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DeadGodDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DeadGodIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Surround/DGHit",
                DeathSound = "event:/Hawthorne/Surround/DGDie",
            };
            DeadGod.PrepareEnemyPrefab("assets/TheShitter/DeadGod_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/TheShitter/DeadGod_Gibs.prefab").GetComponent<ParticleSystem>());

            DeadGod.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Inferno, 
                Passives.MultiAttack3,
                unmask,
                desperate
            });

            DeadGod.AddLootData(new EnemyLootItemProbability[] { new EnemyLootItemProbability() { isItemTreasure = false, amount = 3, probability = 100 } });

            AddPassiveEffect confuse = ScriptableObject.CreateInstance<AddPassiveEffect>();
            confuse._passiveToAdd = Passives.Confusion;

            //Faith
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;

            Ability faith = new Ability("Forgotten Faith", "Salt_ForgottenFaith_A");
            faith.Description = "Apply 1-2 Power to this enemy.\nGain \"Confusion\" as a passive.";
            faith.Rarity = Rarity.Common;
            faith.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(66)),
                Effects.GenerateEffect(confuse, 1, Slots.Self),
            };
            faith.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            faith.AnimationTarget = Targeting.Slot_SelfSlot;
            faith.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Power", IntentType_GameIDs.PA_Confusion.ToString(),
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
            left.Description = "Move left and apply 1 Power to this enemy. Deal a Little damage to the right party member.";
            left.Rarity = Rarity.CreateAndAddCustomRarityToPool("DG_15", 15);
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
            right.Description = "Move right and deal a Painful amount of damage to the left party member. If damage was dealt, apply 1 Power to this enemy.";
            right.Rarity = Rarity.GetCustomRarity("DG_15");
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
            promised.Description = "Apply 1-2 Power to self. Deal a Little damage to the opposing party member, this attack is fully blocked by Shield. \nRupture this enemy.";
            promised.Rarity = Rarity.Common;
            promised.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(60)),
                Effects.GenerateEffect(BasicEffects.ShieldBlocked, 2, Targeting.Slot_Front),
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
            apparition.Description = "Move to a random position. Inflict 1 Fire on this enemy, and 1-10 Fire on the Opposing position. \nInflict 2 Frail on this enemy and gain \"Confusion\" as a Passive.";
            apparition.Rarity = Rarity.CreateAndAddCustomRarityToPool("DG_5", 5);
            apparition.Priority = Priority.Slow;
            apparition.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CustomApplyFireSlotEffect>(), 1, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(confuse, 1, Slots.Self)
            };
            apparition.AnimationTarget = Targeting.Slot_SelfSlot;
            apparition.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Mass",
            });
            apparition.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Field_Fire",
            });
            apparition.AddIntentsToTarget(Slots.Self, ["Status_Frail", IntentType_GameIDs.PA_Confusion.ToString()]);

            //World
            StatusEffectCheckerEffect has_det = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            has_det._status = Determined.Object;
            has_det._allTargetsHaveStatusEffect = false;
            Ability world = new Ability("A Godless World", "Salt_AGodlessWorld_A");
            world.Description = "If this enemy is Determined, deal Almost No damage to all party members, this damage is fully blocked by Shield.\nInflict 1-2 Scars on this enemy and gain \"Confusion\" as a Passive.";
            world.Rarity = Rarity.GetCustomRarity("DG_5");
            world.Priority = Priority.ExtremelySlow;
            world.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(has_det, 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Clobber_1_A", true, Targeting.Unit_AllOpponents), 0, null, BasicEffects.DidThat(true)),
                Effects.GenerateEffect(BasicEffects.ShieldBlocked, 1, Targeting.Unit_AllOpponents, BasicEffects.DidThat(true, 2)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self, Effects.ChanceCondition(50)),
                Effects.GenerateEffect(confuse, 1, Slots.Self)
            };
            world.AnimationTarget = Targeting.Slot_SelfSlot;
            world.Visuals = null;
            world.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Damage_1_2"]);
            world.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Scars",
                IntentType_GameIDs.PA_Confusion.ToString(),
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
                left.GenerateEnemyAbility(true),
                faith.GenerateEnemyAbility(true),
                right.GenerateEnemyAbility(true),
                promised.GenerateEnemyAbility(true),
                apparition.GenerateEnemyAbility(true),
                world.GenerateEnemyAbility(true),
                //blind.GenerateEnemyAbility(true),
            });
            DeadGod.AddEnemy(true);
        }
    }
}
