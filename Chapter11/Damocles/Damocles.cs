using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Damocles
    {
        public static void Add()
        {
            Enemy sword = new Enemy("Damocles", "Damocles_EN")
            {
                Health = 30,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("DamoclesIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DamoclesWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DamoclesDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound,
            };
            sword.PrepareEnemyPrefab("assets/group4/Damocles/Damocles_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Damocles/Damocles_Gibs.prefab").GetComponent<ParticleSystem>());
            sword.enemy.enemyTemplate.m_Data.m_Renderer = sword.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Moon").GetComponent<SpriteRenderer>();


            //FALL
            PerformEffectPassiveAbility damocles = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            damocles._passiveName = "Closure";
            damocles.passiveIcon = ResourceLoader.LoadSprite("DamoclesPasive.png");
            damocles.m_PassiveID = "Closure_PA";
            damocles._enemyDescription = "On taking any amount of damage, there is a 50% chance that this enemy instantly dies then deals the amount of damage taken to the Opposing party member.";
            damocles._characterDescription = "On taking any amount of damage, there is a 50% chance that this party member instantly dies then deals the amount of damage taken to the Opposing enemy.";
            damocles.doesPassiveTriggerInformationPanel = false;
            damocles.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<DamoclesCondition>() };
            damocles._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDamaged };

            //decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            decay._enemyDescription = "Upon dying, this enemy decays into 2 copies of itself.";
            decay._characterDescription = "On dying, nothing happens. This effect won't work on party members. Be glad it doesnt break the game.";
            decay.doesPassiveTriggerInformationPanel = true;
            decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            DeathReferenceDetectionEffectorCondition detectWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            detectWither._witheringDeath = false;
            detectWither._useWithering = true;
            decay.conditions = new EffectorConditionSO[]
            {
                detectWither
            };
            DelayRespawnEffect spawn = ScriptableObject.CreateInstance<DelayRespawnEffect>();
            decay.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(spawn, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(spawn, 1, Targeting.Slot_SelfSlot),
            };

            sword.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, damocles, Passives.Withering, decay });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            sword.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            sword.AddEnemy(true, true);
        }
    }
}
