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
        public static BasePassiveAbilitySO Passive;
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
            ecstasy.enemy.enemyTemplate.m_Data.m_Renderer = ecstasy.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").GetChild(1).GetComponent<SpriteRenderer>();

            PerformEffectPassiveAbility missdose = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            missdose.name = "MissDose_PA";
            missdose._passiveName = "Miss-Dose";
            missdose.m_PassiveID = "MissDose_PA";
            missdose.passiveIcon = ResourceLoader.LoadSprite("MissDosePassive.png");
            missdose._enemyDescription = "This enemy is always itself.\nOn being directly damaged, assume the properties of a random enemy.";
            missdose._characterDescription = "wonr work";
            missdose.doesPassiveTriggerInformationPanel = false;
            missdose._triggerOn = [TriggerCalls.OnDirectDamaged];
            missdose.conditions = Passives.Slippery.conditions;
            missdose.effects = [
                Effects.GenerateEffect(CasterRootActionEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowMissDosePassiveEffect>(), 0, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TransformRandomEnemyEffect>(), 99, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateNewEnemyTurnEffect>(), 0, Slots.Self, BasicEffects.DidThat(true))
                    ]))
                ];
            Passive = missdose;

            ecstasy.AddPassives(new BasePassiveAbilitySO[] { missdose });

            Ability bless = new Ability("1000 Blessings", "1000Blessings_A");
            bless.Description = "Invert the health of all party members.";
            bless.Rarity = Rarity.GetCustomRarity("rarity5");
            bless.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<InvertTargetHealthEffect>(), 0, Targeting.Unit_AllOpponents)];
            bless.AddIntentsToTarget(Targeting.Unit_AllOpponents, [IntentType_GameIDs.Other_MaxHealth_Alt.ToString()]);
            bless.Visuals = Visuals.Providence;
            bless.AnimationTarget = Targeting.Unit_AllOpponents;

            AnimationVisualsEffect hit = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            hit._animationTarget = Slots.FrontLeftRight;
            hit._visuals = Visuals.Scales;

            Ability pray = new Ability("1000 Prayers", "1000Prayers_A");
            pray.Description = "Revive as many party members as possible at 1 health.\nDeal an Impossible amount of damage to the Left, Right, and Opposing party members.";
            pray.Rarity = Rarity.GetCustomRarity("rarity5");
            pray.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ResurrectEffect>(), 1, Targetting.Everything(false)),
                Effects.GenerateEffect(hit, 0, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1000, Slots.FrontLeftRight),
                ];
            pray.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.Other_Resurrect.ToString()]);
            pray.AddIntentsToTarget(Slots.FrontLeftRight, ["Damage_Death"]);

            //ADD ENEMY
            ecstasy.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bless.GenerateEnemyAbility(true),
                pray.GenerateEnemyAbility(true),
            });
            ecstasy.SilentAddEnemy(true, true);
            ecstasy.enemy.AddToSynodPool();
        }
    }
}
