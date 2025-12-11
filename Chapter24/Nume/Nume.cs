using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoneds
{
    public static class Nume
    {
        public static void Add()
        {
            Enemy nume = new Enemy("Nume", "Nume_EN")
            {
                Health = 25,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("NumeIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("NumeWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("NumeDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Enigma_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Enigma_EN").deathSound,
            };
            nume.PrepareEnemyPrefab("Assets/wip5/Nume_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Nume_Wip_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectImmediaterPassiveAbility causality = ScriptableObject.CreateInstance<PerformEffectImmediaterPassiveAbility>();
            causality.name = "Causality_3_PA";
            causality._passiveName = "Causality (3)";
            causality.m_PassiveID = "Causality_PA";
            causality.passiveIcon = ResourceLoader.LoadSprite("CausalityPassive.png");
            causality._enemyDescription = "On moving, deal a Barely Painful amount of damage to the current Opposing party member position at the start of the next turn.";
            causality._characterDescription = "On moving, deal a Barely Painful amount of damage to the current Opposing enemy position at the start of the next turn.";
            causality._triggerOn = [TriggerCalls.OnMoved];
            causality.conditions = [];
            causality.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, Slots.Front)];
            causality.AddToPassiveDatabase();

            //Revenge
            PerformEffectPassiveAbility revenge = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            revenge._passiveName = "Revenge";
            revenge.m_PassiveID = "Revenge_PA";
            revenge.passiveIcon = ResourceLoader.LoadSprite("Revenge.png");
            revenge._characterDescription = "On taking direct damage, give this enemy another ability.";
            revenge._enemyDescription = "On taking direct damage, give this enemy another action.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            revenge._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            revenge.conditions = Passives.Slippery.conditions;

            nume.AddPassives(new BasePassiveAbilitySO[] { causality, revenge, Passives.Skittish });

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
            geo.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.LeftRight),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)];
            geo.AddIntentsToTarget(Slots.LeftRight, [Slip.Intent]);
            geo.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            geo.Visuals = Visuals.Wriggle;
            geo.AnimationTarget = Slots.LeftRight;

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
            nume.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                tele.GenerateEnemyAbility(true),
                geo.GenerateEnemyAbility(true),
                taylor.GenerateEnemyAbility(true)
            });
            nume.AddEnemy(true, true);
        }
    }
}
