using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Sinker
    {
        public static void Add()
        {
            Enemy sinker = new Enemy("Sinker", "Sinker_EN")
            {
                Health = 18,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("SinkerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinkerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinkerDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Clive_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Clive_CH").deathSound,
            };
            sinker.PrepareEnemyPrefab("assets/enemie/Sinker_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Sinker_Gibs.prefab").GetComponent<ParticleSystem>());

            //lonely
            PerformEffectPassiveAbility lonely = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            lonely._passiveName = "Lonely";
            lonely.m_PassiveID = "Lonely_PA";
            lonely.passiveIcon = ResourceLoader.LoadSprite("LonelyIcon.png");
            lonely._enemyDescription = "On any enemy moving, dying, or fleeing, if this enemy is not next to another enemy attempt to move until it is next to one, unless there are no other enemies in combat.";
            lonely._characterDescription = lonely._enemyDescription;
            lonely.doesPassiveTriggerInformationPanel = true;
            lonely.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<LonelyEffect>(), 1, Slots.Self).SelfArray();
            lonely._triggerOn = [LonelySubAction.Trigger];
            lonely.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<LonelyCondition>() };

            sinker.AddPassives(new BasePassiveAbilitySO[] { lonely, Passives.Dying });

            //NAILING
            Ability nailing = new Ability("Nailing_A")
            {
                Name = "Nailing",
                Description = "Deal an Agonizing amount of damage to the Opposing party member and inflict 2 Ruptured and 2 Constricted on them.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, Slots.Front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Nailing"),
                AnimationTarget = Slots.Front,
            };
            nailing.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Field_Constricted.ToString()]);

            //gulp
            EnemyAbilityInfo gulp = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Gulp_A"),
                rarity = nailing.Rarity
            };

            //ALARM
            Ability alarm = new Ability("SinkerAlarm_A")
            {
                Name = "Alarm",
                Description = "30% chance to spawn a random single tile Fish(?) enemy, doubles this chance if this is the only enemy in combat.\nIf this fails, give this enemy another action.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnFishEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<AlarmCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, Slots.Self, BasicEffects.DidThat(false)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Alarm"),
                AnimationTarget = Slots.Self,
            };
            alarm.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Misc.ToString()]);

            //ADD ENEMY
            sinker.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                nailing.GenerateEnemyAbility(true),
                gulp,
                alarm.GenerateEnemyAbility(true)
            });
            sinker.AddEnemy(true, true);
        }
    }
}
