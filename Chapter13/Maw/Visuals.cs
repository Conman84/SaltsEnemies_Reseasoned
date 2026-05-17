using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Visual
    {
        public static void Add()
        {
            Enemy visuals = new Enemy("Visual", "Visual_EN")
            {
                Health = 2,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("VisualsIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("VisualsWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("VisualsDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound,
            };
            visuals.PrepareEnemyPrefab("Assets/Guhhhh/Visuals_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Guhhhh/Visuals_Gibs.prefab").GetComponent<ParticleSystem>());

            //JITERRY
            PerformEffectPassiveAbility jitter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jitter._passiveName = "Jittery";
            jitter.m_PassiveID = "Jittery_PA";
            jitter.passiveIcon = ResourceLoader.LoadSprite("JitteryPassive.png");
            jitter._enemyDescription = "On any party member manually moving, move to the Left or Right.";
            jitter._characterDescription = jitter._enemyDescription;
            jitter.doesPassiveTriggerInformationPanel = true;
            jitter.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self).SelfArray();
            jitter._triggerOn = new TriggerCalls[] { JitteryHandler.Call };
            jitter.conditions = new EffectorConditionSO[0];

            //RUPTURE
            StatusEffectPassiveAbility rupture = ScriptableObject.CreateInstance<StatusEffectPassiveAbility>();
            //Connection_PerformEffectPassiveAbility rupture = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            rupture._passiveName = "Enruptured";
            rupture.passiveIcon = ResourceLoader.LoadSprite("enrupture");
            rupture.m_PassiveID = "Enruptured_PA";
            rupture._enemyDescription = "Permanently applies Ruptured to this enemy.";
            rupture._characterDescription = "Permanently applies Ruptured to this character.";
            rupture.doesPassiveTriggerInformationPanel = true;
            //rupture.connectionEffects = Effects.GenerateEffect(CasterSubActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentRupturedEffect>(), 1, Slots.Self).SelfArray()), 1, Slots.Self).SelfArray();
            //rupture.disconnectionEffects = new EffectInfo[0];
            rupture._Status = StatusField.Ruptured;
            rupture._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            //fluid dynamics
            PerformEffectPassiveAbility fluids = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fluids._passiveName = "Fluid Dynamics (1)";
            fluids.name = "FluidDynamics_1_PA";
            fluids.passiveIcon = ResourceLoader.LoadSprite("FluidDynamicsPassive.png");
            fluids.m_PassiveID = "FluidDynamics_PA";
            fluids._enemyDescription = "On death, inflict 1 Slip to the Opposing position.";
            fluids._characterDescription = fluids._enemyDescription;
            fluids.doesPassiveTriggerInformationPanel = true;
            fluids.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front)];
            fluids.conditions = [];
            fluids._triggerOn = [TriggerCalls.OnDeath];

            visuals.AddPassives(new BasePassiveAbilitySO[] { jitter, rupture, fluids, Passives.Withering });

            SpawnEnemyByStringNameEffect spawn = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            spawn.enemyName = "Visual_EN";
            spawn._spawnTypeID = "Spawn_Basic";

            Ability clone = new Ability("Salt_WatchesYou_A");
            clone.Name = "Hurts You and Watches You";
            clone.Description = "Deal an Agonizing amount of damage to the Opposing party member.\nSpawn as many Visuals as possible.";
            clone.Rarity = Rarity.Common;
            clone.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front), Effects.GenerateEffect(spawn, 5)];
            clone.AddIntentsToTarget(Slots.Front, ["Damage_7_10"]);
            clone.AddIntentsToTarget(Slots.Self, ["Other_Spawn"]);
            clone.AnimationTarget = Slots.Self;
            clone.Visuals = null;

            //ADD ENEMY
            visuals.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                clone.GenerateEnemyAbility(true)
            });
            visuals.AddEnemy(true, true, true);
            visuals.enemy.AddToToysPool();
            visuals.enemy.AddToEcstasyPool();
        }
    }
}
