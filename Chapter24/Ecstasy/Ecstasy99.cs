using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Ecstasy99
    {
        public static void Add()
        {
            Enemy ecstasy = new Enemy("ECSTASY99", Ecstasy.Gray)
            {
                Health = 36,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("GrayEcstasyIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GrayEcstasyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GrayEcstasyDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy(Ecstasy.Yellow).damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy(Ecstasy.Yellow).deathSound,
            };
            ecstasy.PrepareEnemyPrefab("Assets/enem5/Ecstasy_Gray_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/enem5/Ecstasy_Gray_Gibs.prefab").GetComponent<ParticleSystem>());
            PerformEffectPassiveAbility overdose = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            overdose.name = "MissDose_PA";
            overdose._passiveName = "Miss-Dose";
            overdose.m_PassiveID = "MissDose_PA";
            overdose.passiveIcon = ResourceLoader.LoadSprite("MissDosePassive.png");
            overdose._enemyDescription = "This enemy is always itself.\nOn being directly damaged, assume the properties of a random enemy.";
            overdose._characterDescription = "wonr work";
            overdose.doesPassiveTriggerInformationPanel = false;
            overdose._triggerOn = [TriggerCalls.OnDirectDamaged];
            overdose.conditions = Passives.Slippery.conditions;
            overdose.effects = [
                Effects.GenerateEffect(CasterRootActionEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowMissDosePassiveEffect>(), 0, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TransformRandomEnemyEffect>(), 0, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateNewEnemyTurnEffect>(), 0, Slots.Self, ScriptableObject.CreateInstance <HasHealthEffectCondition>())
                    ]))
                ];

            ecstasy.AddPassives(new BasePassiveAbilitySO[] { overdose });

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            ecstasy.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            ecstasy.SilentAddEnemy(true, true);
            ecstasy.enemy.AddToSynodPool();
        }
    }
}
