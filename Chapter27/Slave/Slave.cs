using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Slave
    {
        public static void Add()
        {
            Enemy slave = new Enemy("Slave", "Slave_EN")
            {
                Health = 38,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SlaveIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SlaveWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SlaveDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy(Jumble.Yellow).damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy(Jumble.Yellow).deathSound,
            };
            slave.PrepareEnemyPrefab("Assets/ch_27/Slave_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_27/Slave_Gibs.prefab").GetComponent<ParticleSystem>());


            //schizic
            PerformEffectPassiveAbility schizic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            schizic._passiveName = "Neurotic";
            schizic.name = "Neurotic_PA";
            schizic.passiveIcon = ResourceLoader.LoadSprite("SchizophrenicPassive.png");
            schizic.m_PassiveID = "Neurotic_PA";
            schizic._enemyDescription = "Upon any party member manually moving, reroll one of this enemy's actions on the timeline.";
            schizic._characterDescription = "wont work lol";
            schizic.conditions = [];
            schizic.doesPassiveTriggerInformationPanel = true;
            schizic.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ReRollTargetTimelineAbilityEffect>(), 1, Slots.Self)];
            schizic._triggerOn = [JitteryHandler.Call];

            PerformEffectImmediaterPassiveAbility grasp = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            grasp._passiveName = "Grasping";
            grasp.passiveIcon = ResourceLoader.LoadSprite("GraspingPassive.png");
            grasp.m_PassiveID = "Grasping_PA";
            grasp._enemyDescription = "When a party member moves in front of this enemy, attempt to exhaust their movement.";
            grasp._characterDescription = "wont work";
            grasp.doesPassiveTriggerInformationPanel = true;
            grasp.conditions = [];
            grasp.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ExhaustMovementEffect>(), 1, Slots.Front)];
            grasp._triggerOn = [(TriggerCalls)AmbushManager.Patiently];

            //diviner
            PerformEffectPassiveAbility escape = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            escape.name = "Diviner_PA";
            escape._passiveName = "Diviner";
            escape.passiveIcon = ResourceLoader.LoadSprite("DivinerPassive.png");
            escape.m_PassiveID = "Diviner_PA";
            escape._enemyDescription = "On being directly damaged, even if the damage was fatal, move to a random unoccupied position if possible.";
            escape._characterDescription = escape._enemyDescription;
            escape._triggerOn = [TriggerCalls.OnDirectDamaged];
            escape.conditions = [];
            escape.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToRandomEmptyTileEffect>(), 1, Slots.Self)];

            slave.AddPassives(new BasePassiveAbilitySO[] { schizic, Passives.Formless, grasp, escape });

            Ability sac = new Ability("Ritualistic Sacrifice", "Slave_Sac_A");
            sac.Description = "Deal a Lethal amount of damage to the Opposing party member.";
            sac.Rarity = Rarity.Common;
            sac.Priority = Priority.VerySlow;
            sac.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 17, Slots.Front)];
            sac.AddIntentsToTarget(Slots.Front, ["Damage_16_20"]);
            sac.Visuals = Visuals.Quills;
            sac.AnimationTarget = Slots.Front;

            Ability flavor = new Ability("Grape Flavor Aid", "Slave_Grape_A");
            flavor.Description = "Loom over the Left and Right enemy positions.\nMoves Left or Right.";
            flavor.Rarity = Rarity.GetCustomRarity("rarity5");
            flavor.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLoomingSlotEffect>(), 2, Slots.Sides),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                ];
            flavor.AddIntentsToTarget(Slots.Sides, [Looming.Intent]);
            flavor.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            flavor.Visuals = Visuals.Providence;
            flavor.AnimationTarget = Slots.Sides;

            Ability fam = new Ability("The Family", "Slave_Family_A");
            fam.Description = "Loom over the Left and Right party member positions.\nMoves Left or Right.";
            fam.Rarity = Rarity.GetCustomRarity("rarity5");
            fam.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLoomingSlotEffect>(), 2, Slots.LeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                ];
            fam.AddIntentsToTarget(Slots.LeftRight, [Looming.Intent]);
            fam.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            fam.Visuals = Visuals.Providence;
            fam.AnimationTarget = Slots.LeftRight;

            Ability oca = new Ability("Oxford Capacity Analysis", "Slave_OCA_A");
            oca.Description = "Moves Left, Right, or stays in place.\nLoom over the Opposing position.";
            oca.Rarity = Rarity.GetCustomRarity("rarity5");
            oca.Priority = Priority.VeryFast;
            oca.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self, Effects.ChanceCondition(60)),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Keyhole", false, Slots.Front)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLoomingSlotEffect>(), 5, Slots.Front),
                ];
            oca.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            oca.AddIntentsToTarget(Slots.Front, [Looming.Intent]);
            oca.AnimationTarget = Slots.Front;

            //ADD ENEMY
            slave.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                sac.GenerateEnemyAbility(true),
                flavor.GenerateEnemyAbility(true),
                fam.GenerateEnemyAbility(true),
                oca.GenerateEnemyAbility(true),
            });
            slave.AddEnemy(true, true);
            slave.enemy.AddToSynodPool();
            slave.enemy.AddToEcstasyPool();
            slave.enemy.AddToToysPool();
        }
    }
}
