using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Nine
    {
        public static void Add()
        {
            Enemy nine = new Enemy("NINE", "Nine_EN")
            {
                Health = 9,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("NineIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("NineWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("NineDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Hauntling_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Hauntling_EN").deathSound,
            };
            nine.PrepareEnemyPrefab("Assets/Abyss/Nine_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Abyss/Nine_Gibs.prefab").GetComponent<ParticleSystem>());

            //control
            RandomTriggerPassive control = ScriptableObject.CreateInstance<RandomTriggerPassive>();
            control.name = "Control_PA";
            control._passiveName = "Control";
            control.m_PassiveID = "Control_PA";
            control.passiveIcon = ResourceLoader.LoadSprite("ControlPassive.png");
            control._enemyDescription = "This enemy decides when it gets to move.";
            control._characterDescription = "This party member randomly moves Left or Right.";
            control.UniqueCall = (TriggerCalls)2658153;
            control._triggerOn = [control.UniqueCall];
            control.doesPassiveTriggerInformationPanel = true;
            control.conditions = [];
            control.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterSwapToSidesUpToEntryVariableEffect>(), 4, Slots.Self)];
            control._min = 4f;
            control._max = 12f;
            control.Coroutines = [];

            //SURVIVAL
            AnimationVisualsEffect core = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            core._visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
            core._animationTarget = Targeting.Slot_SelfSlot;
            PerformEffectImmediatePassiveAbility survival = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
            survival._passiveName = "Survival Instinct (9)";
            survival.passiveIcon = ResourceLoader.LoadSprite("survival.png");
            survival._enemyDescription = "On death, deal an Agonizing amount of damage to all party members. \nDoes not trigger on Withering.";
            survival._characterDescription = "On death, deal 9 damage to all enemies. \nDoes not trigger on Withering";
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
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 9, Targeting.Unit_AllOpponents)
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

            nine.AddPassives(new BasePassiveAbilitySO[] { control, survival, flither });

            Targetting_ByUnit_Side_Empty fools = ScriptableObject.CreateInstance<Targetting_ByUnit_Side_Empty>();
            fools.getAllUnitSlots = true;
            fools.getAllies = false;

            Targetting_ByUnit_Side_Empty enemies = ScriptableObject.CreateInstance<Targetting_ByUnit_Side_Empty>();
            fools.getAllUnitSlots = true;
            fools.getAllies = true;

            Ability mines = new Ability("Minesweeper", "Nine_Minsweeper_A");
            mines.Description = "Apply 1 Slip to every unoccupied party member and enemy position.";
            mines.Rarity = Rarity.Common;
            mines.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, enemies),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, fools),
                ];
            mines.AddIntentsToTarget(enemies, [Slip.Intent]);
            mines.AddIntentsToTarget(fools, [Slip.Intent]);
            mines.AnimationTarget = Slots.Self;
            mines.Visuals = null;

            Ability plus = new Ability("Plus", "Nine_Plus_A");
            plus.Description = "Take Almost No damage.";
            plus.Rarity = Rarity.Uncommon;
            plus.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.Self)];
            plus.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            plus.AnimationTarget = Slots.Self;
            plus.Visuals = null;

            //ADD ENEMY
            nine.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                mines.GenerateEnemyAbility(true),
                plus.GenerateEnemyAbility(true),
            });
            nine.AddEnemy();
        }
    }
}
