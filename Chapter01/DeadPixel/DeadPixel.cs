using BrutalAPI;
using HarmonyLib;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


namespace SaltsEnemies_Reseasoned
{
    public class DeadPixel
    {
        public static void Add()
        {
            //Jumpy
            PerformEffectPassiveAbility jumpy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jumpy._passiveName = "Jumpy";
            jumpy.m_PassiveID = "Jumpy_PA";
            jumpy.passiveIcon = ResourceLoader.LoadSprite("Jumpy.png");
            jumpy._characterDescription = "Upon being damaged, move to a random position. Upon performing an ability, move to a random position.";
            jumpy._enemyDescription = "Upon being damaged, move to a random position. Upon performing an ability, move to a random position.";
            jumpy.doesPassiveTriggerInformationPanel = true;
            jumpy.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
            };
            jumpy._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged, TriggerCalls.OnAbilityUsed };
            

            //Numb
            PerformEffectPassiveAbility numb = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            numb._passiveName = "Numb (1)";
            numb.m_PassiveID = "Numb_PA";
            numb.passiveIcon = ResourceLoader.LoadSprite("Anesthetics.png");
            numb._enemyDescription = "Apply 1 Anesthetics to this enemy at the start of each turn.";
            numb._characterDescription = "Apply 1 Anesthetics to this character at the start of each turn.";
            numb.doesPassiveTriggerInformationPanel = true;
            numb.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            numb._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Anesthetics.png"), "Numb", "Apply a certain amount of Anesthetics to this enemy at the start of each turn.");

            //Enemy Code
            Enemy DeadPixel = new Enemy("Dead Pixel", "DeadPixel_EN")
            {
                Health = 9,
                HealthColor = Pigments.Grey,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("deadPixel_iconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("deadPixel_dead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("deadPixel_icon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/DeadPixelHurt",
                DeathSound = "event:/Hawthorne/Die/DeadPixelDie",
            };
            DeadPixel.PrepareEnemyPrefab("assets/PissShitFartCum/Pixel_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Pixel_Gibs.prefab").GetComponent<ParticleSystem>());

            DeadPixel.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Forgetful,
                jumpy,
                numb,
                Passives.Fleeting6,
            });

            //Enter Effects
            DeadPixel.CombatEnterEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<NumbPassiveInfoEffect>(), 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, Targeting.Slot_SelfSlot),
                }), 1, Targeting.Slot_SelfAll)      
            };

            //Static
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability theStatic = new Ability("Static", "Salt_Static_A");
            theStatic.Description = "Turn a random non-grey enemy grey. If that enemy had Pure as a passive, remove it.";
            theStatic.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity4", 4);
            theStatic.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TurnGreyTargetRandomEffect>(), 4, allAlly),
            };
            theStatic.Visuals = null;
            theStatic.AnimationTarget = Targeting.Slot_SelfSlot;
            theStatic.AddIntentsToTarget(allAlly, new string[]
            {
                "Misc"
            });
            

            //Multicolors
            CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
                Pigments.Red,
                Pigments.Blue,
                Pigments.Yellow,
                Pigments.Purple
            };
            
            Ability multicolors = new Ability("Multicolors", "Salt_Multicolors_A");
            multicolors.Description = "Deal a Painful amount of damage to the Opposing party member. Fill the pigment bar with random pigment colors and randomize this enemy's health color.";
            multicolors.Rarity = Rarity.GetCustomRarity("rarity6");
            multicolors.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateFullBarManaEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(randomize, 1, Targeting.Slot_SelfSlot),
            };
            multicolors.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            multicolors.AnimationTarget = Targeting.Slot_SelfSlot;
            multicolors.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_3_6"
            });
            multicolors.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Mana_Generate",
                "Misc"
            });

            //interference
            IncreaseStatusEffectsEffect increaseAllStatus = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus._increasePositives = true;
            IncreaseStatusEffectsEffect increaseAllStatus2 = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus2._increasePositives = false;
            Ability interference = new Ability("Signal Interference", "Salt_SignalInterference_A");
            interference.Description = "Increase the status and field effects of all enemies and party members by 1. Apply 1-2 randomly selected negative status effects to all party members.";
            interference.Rarity = Rarity.GetCustomRarity("rarity3");
            interference.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(increaseAllStatus, 1, allAlly),
                Effects.GenerateEffect(increaseAllStatus, 1, allEnemy),
                Effects.GenerateEffect(increaseAllStatus2, 1, allAlly),
                Effects.GenerateEffect(increaseAllStatus2, 1, allEnemy),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomStatusEffect>(), 1, allEnemy),
            };
            interference.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            interference.AnimationTarget = MultiTargetting.Create(Targeting.GenerateSlotTarget(new int[] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, true), Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false));
            interference.AddIntentsToTarget(allAlly, new string[]
            {
                "Misc",
            });
            interference.AddIntentsToTarget(allEnemy, ["Misc"]);
            interference.AddIntentsToTarget(allEnemy, new string[]
            {
                FallColor.Intent,
                "Status_Cursed",
                "Status_Scars",
                "Status_Frail",
                "Status_OilSlicked",
                "Status_Inverted",
                "Status_Left",
                "Status_Pale",
            });

            //Add
            DeadPixel.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                theStatic.GenerateEnemyAbility(true),
                multicolors.GenerateEnemyAbility(true),
                interference.GenerateEnemyAbility(true),
            });
            DeadPixel.AddEnemy(true, true, true);
        }
    }
}
