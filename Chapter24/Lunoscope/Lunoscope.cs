using BrutalAPI;
using SaltEnemies_Reseasoned;
using System.Collections.Generic;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Lunoscope
    {
        public static void Add()
        {
            Enemy lunoscope = new Enemy("Lunoscope", "Lunoscope_EN")
            {
                Health = 43,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("LunoscopeIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("LunoscopeWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("LunoscopeDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sund/LunoHit",
                DeathSound = "event:/Hawthorne/Sund/LunoDie",
            };
            lunoscope.PrepareEnemyPrefab("Assets/wip5/Lunoscope_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Lunoscope_Wip_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectImmediaterPassiveAbility causality = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            causality.name = "Causality_5_PA";
            causality._passiveName = "Causality (5)";
            causality.m_PassiveID = "Causality_PA";
            causality.passiveIcon = ResourceLoader.LoadSprite("CausalityPassive.png");
            causality._enemyDescription = "On moving, deal a Painful amount of damage to the current Opposing party member position at the start of the next turn.";
            causality._characterDescription = "On moving, deal a Painful amount of damage to the current Opposing enemy position at the start of the next turn.";
            causality._triggerOn = [TriggerCalls.OnMoved];
            causality.conditions = [];
            causality.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, Slots.Front)];
            causality.AddToPassiveDatabase();

            PerformEffectPassiveAbility commissioner = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            commissioner.name = "Commissioner_PA";
            commissioner._passiveName = "Commissioner";
            commissioner.passiveIcon = ResourceLoader.LoadSprite("ComissionerPassive.png");
            commissioner._enemyDescription = "On being damaged, force the Opposing party member to perform this enemy's first action.\nIf successful, remove that action and give this enemy another one.";
            //ch desc
            commissioner.m_PassiveID = "Commissioner_PA";
            commissioner.doesPassiveTriggerInformationPanel = true;
            commissioner._triggerOn = [TriggerCalls.OnDirectDamaged];
            commissioner.effects = [
                Effects.GenerateEffect(ComissionerEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveFirstCasterActionEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self)
                    ]), 1, Slots.Front),
                ];
            commissioner.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<HasTurnsCondition>() }.ToArray();
            commissioner.AddToPassiveDatabase();

            lunoscope.AddPassives(new BasePassiveAbilitySO[] { causality, commissioner });

            Ability tele = new Ability("TelescopingSeries_A");
            tele.Name = "Telescoping Series";
            tele.Description = "Move the Opposing party member Left twice or Right twice.\nGain 2 Slip.";
            tele.Rarity = Rarity.GetCustomRarity("rarity5");
            tele.Effects = [
                Effects.GenerateEffect(SubActionEffect.Create([
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self)
                    ]), 1, Slots.Front, Effects.ChanceCondition(50)),
                Effects.GenerateEffect(SubActionEffect.Create([
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self)
                    ]), 1, Slots.Front, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Self),
                ];
            tele.AddIntentsToTarget(Slots.Front, ["Swap_Left", "Swap_Left", "Swap_Right", "Swap_Right"]);
            tele.AddIntentsToTarget(Slots.Self, [Slip.Intent]);
            tele.Visuals = CustomVisuals.GetVisuals("Salt/Door");
            tele.AnimationTarget = Slots.Front;

            Ability geo = new Ability("GeometricSequence_A");
            geo.Name = "Geometric Sequence";
            geo.Description = "Apply 1 Slip to the Left and Right party member positions.\nMove Left or Right.";
            geo.Rarity = Rarity.GetCustomRarity("rarity5");
            geo.Effects = [Effects.GenerateEffect(BasicEffects.GetNormalVisuals("Wriggle_A", false), 0, Slots.LeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.LeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)];
            geo.AddIntentsToTarget(Slots.LeftRight, [Slip.Intent]);
            geo.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            //geo.Visuals = Visuals.Wriggle;
            //geo.AnimationTarget = Slots.LeftRight;

            Ability taylor = new Ability("TaylorPolynomial_A");
            taylor.Name = "Taylor Polynomial";
            taylor.Description = "At the start of the next turn, deal an Agonizing amount of damage to this enemy's current Opposing position.\nInflict 2 Oil-Slicked on the Opposing party member.";
            taylor.Rarity = Rarity.GetCustomRarity("rarity5");
            taylor.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 7, Slots.Front),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, Slots.Front)];
            taylor.AddIntentsToTarget(Slots.Front, ["Damage_7_10", "Damage_Delay", "Status_OilSlicked"]);
            taylor.Visuals = CustomVisuals.GetVisuals("Salt/Reload");
            taylor.AnimationTarget = Slots.Front;

            //ADD ENEMY
            lunoscope.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                tele.GenerateEnemyAbility(true),
                geo.GenerateEnemyAbility(true),
                taylor.GenerateEnemyAbility(true)
            });
            lunoscope.SilentAddEnemy(true, true);
            lunoscope.enemy.AddToSynodPool();
        }
    }
}
