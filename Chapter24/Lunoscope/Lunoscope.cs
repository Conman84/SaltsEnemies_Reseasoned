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
                DamageSound = LoadedAssetsHandler.GetEnemy(Enemies.Tank).damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy(Enemies.Tank).deathSound,
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
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstActionEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, BasicEffects.DidThat(true))
                ];
            commissioner.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<HasTurnsCondition>() }.ToArray();


            lunoscope.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, Passives.Withering });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            lunoscope.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            lunoscope.AddEnemy(true, true);
        }
    }
}
