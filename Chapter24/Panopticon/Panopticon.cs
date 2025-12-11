using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Panopticon
    {
        public static void Add()
        {
            Enemy panopticon = new Enemy("The Panopticon", "ThePanopticon_EN")
            {
                Health = 36,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("PanopticonIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PanopticonWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PanopticonDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").deathSound,
            };
            panopticon.PrepareEnemyPrefab("Assets/wip5/Panopticon_Wip_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/wip5/Panopticon_Wip_Gibs.prefab").GetComponent<ParticleSystem>());

            //HETEROCHROMIA
            PerformEffectPassiveAbility colors = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            colors._passiveName = "Heterochromia";
            colors.m_PassiveID = "Heterochromia_PA";
            colors.passiveIcon = ResourceLoader.LoadSprite("Hemochromia.png");
            colors._enemyDescription = "Upon receiving any kind of damage, randomize this enemy's health colour.";
            colors._characterDescription = "Upon receiving any kind of damage, randomize this party member's health colour.";
            ChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
                        Pigments.Blue,
                        Pigments.Red,
                        Pigments.Yellow,
                        Pigments.Purple
            };
            colors.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect((EffectSO) randomize, 1, Slots.Self)
            };
            colors._triggerOn = new TriggerCalls[]
            {
                        TriggerCalls.OnDamaged
            };

            //commissioner
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
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstCasterActionEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(CasterSubActionEffect.Create([
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveFirstCasterActionEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self)
                    ]), 0, Slots.Self, BasicEffects.DidThat(true))
                ];
            commissioner.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<HasTurnsCondition>() }.ToArray();

            //escapist
            PerformEffectPassiveAbility escape = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            escape.name = "Escapist_PA";
            escape._passiveName = "Escapist";
            escape.passiveIcon = ResourceLoader.LoadSprite("EscapistPassive.png");
            escape.m_PassiveID = "Escapist_PA";
            escape._enemyDescription = "On using an ability, move to a random unoccupied position.";
            escape._characterDescription = escape._enemyDescription;
            escape._triggerOn = [TriggerCalls.OnAbilityUsed];
            escape.conditions = [];
            escape.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveToRandomEmptyTileEffect>(), 1, Slots.Self)];
            escape.AddToPassiveDatabase();

            panopticon.AddPassives([colors, commissioner, escape]);


            Ability descent = new Ability("Descent", "Panopticon_Descent_A");
            descent.Name = "Descent";
            descent.Description = "If this ability is used 3 or more times, deal a Painful amount of damage to all party members.";
            descent.Rarity = Rarity.CreateAndAddCustomRarityToPool("whale_high", 20);
            descent.Effects = [
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Anchoring", false, Targetting.Everything(false)), 0, Slots.Self, ScriptableObject.CreateInstance<PanopticonCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targetting.Everything(false), BasicEffects.DidThat(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<PanopticonEffect>())
                ];
            descent.AddIntentsToTarget(Slots.Self, ["Misc_Hidden"]);
            descent.AddIntentsToTarget(Targetting.Everything(false), ["Damage_3_6"]);
            descent.Visuals = null;
            descent.AnimationTarget = Slots.Self;

            //ADD ENEMY
            panopticon.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                descent.GenerateEnemyAbility(true),
            });
            panopticon.AddEnemy(true, true);
        }
    }
}
