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
                OverworldAliveSprite = ResourceLoader.LoadSprite("SinkerWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SinkerDead.png", new Vector2(0.5f, 0f), 32),
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
            sinker.AddUnitType("Fish");

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

            ApplyShieldSlotEffect exit_shield = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>();
            exit_shield._UsePreviousExitValueAsMultiplier = true;
            SpawnEnemyByStringNameEffect danglers = ScriptableObject.CreateInstance<SpawnEnemyByStringNameEffect>();
            danglers.enemyName = "Dangler_EN";
            //inchoking
            Ability inchoking = new Ability("SinkerInchoking_A");
            inchoking.Name = "Inchoking";
            inchoking.Description = "Take a Painful amount of damage and apply an equivalent amount of Shield to the Left and Right enemy positions.\nIf this is the only enemy in combat, attempt to spawn as many Danglers as possible.";
            inchoking.Rarity = Rarity.GetCustomRarity("rarity5");
            inchoking.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Self),
                Effects.GenerateEffect(exit_shield, 1, Slots.Sides),
                Effects.GenerateEffect(danglers, 5, Slots.Self, ScriptableObject.CreateInstance<NewAlarmCondition>())
                ];
            inchoking.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);
            inchoking.AddIntentsToTarget(Slots.Sides, ["Field_Shield"]);
            inchoking.AddIntentsToTarget(Slots.Self, ["Other_Spawn"]);
            inchoking.Visuals = Visuals.Gulp;
            inchoking.AnimationTarget = Slots.Self;

            //ALARM
            Ability alarm = new Ability("SinkerAlarm_A")
            {
                Name = "Alarm",
                Description = "Inflict 1 Ruptured on the Left, Right, and Opposing party members.\nIf this is the only enemy in combat, deal a Painful amount of damage to them as well.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.FrontLeftRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.FrontLeftRight, ScriptableObject.CreateInstance<NewAlarmCondition>())
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Gears"),
                AnimationTarget = Slots.FrontLeftRight,
            };
            alarm.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_Ruptured"]);
            alarm.AddIntentsToTarget(Slots.Self, ["Misc_Hidden"]);
            alarm.AddIntentsToTarget(Slots.FrontLeftRight, ["Damage_3_6"]);

            //ADD ENEMY
            sinker.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                nailing.GenerateEnemyAbility(true),
                inchoking.GenerateEnemyAbility(true),
                alarm.GenerateEnemyAbility(true)
            });
            sinker.AddEnemy(true, true);
            sinker.enemy.AddToSynodPool();
        }
    }
}
