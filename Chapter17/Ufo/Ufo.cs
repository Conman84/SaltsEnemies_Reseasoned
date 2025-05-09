using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Ufo
    {
        public static void Add()
        {
            Enemy ufo = new Enemy("Toy UFO", "ToyUfo_EN")
            {
                Health = 13,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("UFOIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("UFOWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("UFODead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noisy/UFO_Hit",
                DeathSound = "event:/Hawthorne/Noisy/UFO_Death",
            };
            ufo.PrepareEnemyPrefab("assets/enemie/UFO_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/UFO_Gibs.prefab").GetComponent<ParticleSystem>());

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

            ufo.AddPassives(new BasePassiveAbilitySO[] { jitter, Passives.Leaky1 });

            //laser
            Ability laser = new Ability("UFO_Laser_A")
            {
                Name = "Laser",
                Description = "Deal an Agonizing amount of damage to the Opposing position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.Front),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals,
                AnimationTarget = Slots.Front,
            };
            laser.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_7_10.ToString().SelfArray());

            //trappings
            Ability trappings = new Ability("UFO_Trappings_A")
            {
                Name = "Trappings",
                Description = "Move to the Left or Right and inflict 2 Constricted on the Opposing position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Cube", false, Slots.Front), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, Slots.Front),
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            trappings.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());
            trappings.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Field_Constricted.ToString().SelfArray());

            //wheeling
            Ability wheeling = new Ability("UFO_Wheeling_A")
            {
                Name = "Wheeling",
                Description = "Move to the Left or Right twice, then deal a Little damage to the Opposing party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Wheel", false, Slots.Front)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Front)
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            wheeling.AddIntentsToTarget(Slots.Self, new string[] { "Swap_Sides", "Swap_Sides" });
            wheeling.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_1_2.ToString().SelfArray());

            //ADD ENEMY
            ufo.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                laser.GenerateEnemyAbility(true),
                trappings.GenerateEnemyAbility(true),
                wheeling.GenerateEnemyAbility(true)
            });
            ufo.AddEnemy(true, true);
        }
    }
}
