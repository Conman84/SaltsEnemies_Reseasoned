using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class HandOfGod
    {
        public static void Add()
        {
            Enemy hand = new Enemy("#800 The Hand Of God", "HandOfGod_EN")
            {
                Health = 50,
                HealthColor = Pigments.Red,
                Size = 2,
                CombatSprite = ResourceLoader.LoadSprite("HandOfGodIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HandOfGodWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HandOfGodDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound,
            };
            hand.PrepareEnemyPrefab("Assets/Abyss/HandOfGod_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Abyss/HandOfGod_Gibs.prefab").GetComponent<ParticleSystem>());

            //acting
            PerformEffectPassiveAbility acting = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            acting.name = "Acting_PA";
            acting._passiveName = "Acting";
            acting.passiveIcon = ResourceLoader.LoadSprite("ActingPassive.png");
            acting._enemyDescription = "On being damaged, perform this enemy's next ability on the timeline and queue another one.";
            acting._characterDescription = "White Woman";
            acting.m_PassiveID = "Acting_PA";
            acting.doesPassiveTriggerInformationPanel = true;
            acting._triggerOn = [TriggerCalls.OnDirectDamaged];
            acting.effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetForceFirstActionEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, BasicEffects.DidThat(true))
                ];
            acting.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<HasTurnsCondition>() }.ToArray();

            hand.AddPassives(new BasePassiveAbilitySO[] { Passives.Infantile, acting });

            BaseCombatTargettingSO left = Targeting.BigEnemy_Front_Offset_0;
            BaseCombatTargettingSO right = Targeting.BigEnemy_Front_Offset_1;

            BaseCombatTargettingSO self = TargettingSelf_NotSlot.Create();

            //DamageByMissingHealthEffect

            Ability apple = new Ability("The Apple Falls, The Tree Falls", "HandOfGod1_A");
            apple.Description = "Damage the Left Opposing party member by this enemy's missing health.\nApply 3 Determined to the Right Opposing party member.";
            apple.Rarity = Rarity.Common;
            apple.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageByMissingHealthEffect>(), 1, left),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 3, right),
                ];
            apple.AddIntentsToTarget(left, ["Damage_21"]);
            apple.AddIntentsToTarget(right, [Determined.Intent]);
            apple.Visuals = Visuals.Clobber_Left;
            apple.AnimationTarget = left;

            Ability cards = new Ability("The Cards Crumbles Falls Cookies", "HandOfGod_2_A");
            cards.Description = "Apply 3 Determined to the Left Opposing party member.\nDamage the Right Opposing party member by this enemy's missing health.";
            cards.Rarity = Rarity.Common;
            cards.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 3, left),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageByMissingHealthEffect>(), 1, right),
                ];
            cards.AddIntentsToTarget(left, [Determined.Intent]);
            cards.AddIntentsToTarget(right, ["Damage_21"]);
            cards.Visuals = Visuals.Clobber_Right;
            cards.AnimationTarget = right;

            DamageEffect damage_exit = ScriptableObject.CreateInstance<DamageEffect>();
            damage_exit._usePreviousExitValue = true;
            Ability hunter = new Ability("The Hunter Has Become The Hunter", "HandOfGod_3_A");
            hunter.Description = "Apply 5 Determined to both Opposing party members.\nDamage this enemy by the amount of Determined applied.";
            hunter.Rarity = Rarity.Uncommon;
            hunter.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 5, Slots.Front),
                Effects.GenerateEffect(damage_exit, 1, self)
                ];
            hunter.AddIntentsToTarget(left, [Determined.Intent]);
            hunter.AddIntentsToTarget(right, [Determined.Intent]);
            hunter.AddIntentsToTarget(self, ["Damage_7_10"]);
            hunter.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            hunter.AnimationTarget = Slots.Front;

            SpawnEnemyWithHealthEntryEffect puppet = ScriptableObject.CreateInstance<SpawnEnemyWithHealthEntryEffect>();
            puppet._enemyName = "AbandonedPuppet_EN";
            puppet._spawnTypeID = "Spawn_Basic";
            puppet._usePrevious = true;

            Ability god = new Ability("Do You Believe In God?", "HandOfGod_4_A");
            god.Description = "Spawn an Abandoned Puppet with health equal to this enemy's missing health.";
            god.Rarity = Rarity.Rare;
            god.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SetExitCasterMissingEffect>()),
                Effects.GenerateEffect(puppet, 1),
                ];
            god.AddIntentsToTarget(self, ["Other_Spawn"]);
            god.AnimationTarget = self;
            god.Visuals = Visuals.Innocence;

            //ADD ENEMY
            hand.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                apple.GenerateEnemyAbility(true),
                cards.GenerateEnemyAbility(true),
                hunter.GenerateEnemyAbility(true),
                god.GenerateEnemyAbility(true)
            });
            hand.AddEnemy(true, true);
            hand.enemy.AddToSynodPool()
        }
    }
}
