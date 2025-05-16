using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Singularity
    {
        public static void Add()
        {
            Enemy blackhole = new Enemy("Singularity", "Singularity_EN")
            {
                Health = 50,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SingularityIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SingularityWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SingularityDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound,
            };
            blackhole.PrepareEnemyPrefab("assets/group4/Singularity/Singularity_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Singularity/Singularity_Gibs.prefab").GetComponent<ParticleSystem>());

            //jumpy
            PerformEffectPassiveAbility jumpy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jumpy._passiveName = "Jumpy";
            jumpy.m_PassiveID = "Jumpy_PA";
            jumpy.passiveIcon = ResourceLoader.LoadSprite("Jumpy.png");
            jumpy._characterDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
            jumpy._enemyDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
            jumpy.doesPassiveTriggerInformationPanel = true;
            jumpy.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
            };
            jumpy._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged, TriggerCalls.OnAbilityUsed };

            //addpassives
            blackhole.AddPassives(new BasePassiveAbilitySO[] { jumpy, Passives.Unstable, Passives.Constricting });
            blackhole.AddLootData(new EnemyLootItemProbability[] { new EnemyLootItemProbability() { isItemTreasure = false, amount = 2, probability = 100 } });

            BlackHoleEffect add = ScriptableObject.CreateInstance<BlackHoleEffect>();
            add.Add = true;
            BlackHoleEffect minu = ScriptableObject.CreateInstance<BlackHoleEffect>();
            minu.Add = false;
            blackhole.CombatEnterEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsPlayerTurnEffectCondition>()),
                Effects.GenerateEffect(add)
            };
            blackhole.CombatExitEffects = Effects.GenerateEffect(minu).SelfArray();

            Ability gravity = new Ability("Gravity_A")
            {
                Name = "Gravity",
                Description = "Move All party members towards this enemy. Permenantly Rupture the Opposing party member.\nIf the Opposing party member already had Ruptured, Curse them.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Targeting.GenerateSlotTarget(new int[]{-1, -2, -3, -4}, false)),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Targeting.GenerateSlotTarget(new int[]{1, 2, 3, 4}, false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermenantRupturedCustomEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front, BasicEffects.DidThat(false))
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                AnimationTarget = Slots.Self,
            };
            gravity.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -1, -2, -3, -4 }, false), IntentType_GameIDs.Swap_Right.ToString().SelfArray());
            gravity.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { 1, 2, 3, 4 }, false), IntentType_GameIDs.Swap_Left.ToString().SelfArray());
            gravity.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Status_Cursed.ToString() });

            //ADD ENEMY
            blackhole.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                gravity.GenerateEnemyAbility(true)
            });
            blackhole.AddEnemy(true, true);
        }
    }
}
