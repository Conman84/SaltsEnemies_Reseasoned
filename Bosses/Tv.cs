using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoneds;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Tv
    {
        public static void Add()
        {
            Enemy template = new Enemy("MEGALANIA", "Megalania_BOSS")
            {
                Health = 180,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ReplaceIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ReplaceWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ReplaceDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Solitaire_EN").enemyTemplate;

            //radical
            Connection_PerformEffectPassiveAbility radical = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            radical._passiveName = "Radical";
            radical.passiveIcon = ResourceLoader.LoadSprite("RadicalPassive.png");
            radical.m_PassiveID = "Radical_PA";
            radical._enemyDescription = "On entering combat, Adjust All Lights.";
            radical._characterDescription = "On entering combat, Adjust All Lights.";
            radical.doesPassiveTriggerInformationPanel = false;
            radical.connectionEffects = new EffectInfo[] { Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[] 
            { 
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Targetting.Everything(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Targetting.Everything(false)),
            })) };
            radical.disconnectionEffects = new EffectInfo[] { Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveLightsEffects>(), 1, Targetting.Everything(true)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveLightsEffects>(), 1, Targetting.Everything(false)),
            })) };
            radical._triggerOn = [TriggerCalls.Count];

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, radical, Passives.Constricting });

            Ability wreck = new Ability("Wreck", "Tv_Wreck_A");
            wreck.Description = "Inflict 4 Oil-Slicked and deal a Lethal amount of damage to the Opposing enemy.\nDeal a Painful amount of damage to this enemy.";
            wreck.Rarity = Rarity.GetCustomRarity("rarity5");
            wreck.Effects = new EffectInfo[3];
            wreck.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, Slots.Front);
            wreck.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 20, Slots.Front);
            wreck.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Self);
            wreck.AddIntentsToTarget(Slots.Front, ["Status_OilSlicked", "Damage_16_20"]);
            wreck.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);
            wreck.Visuals = CustomVisuals.GetVisuals("Salt/Cannon");
            wreck.AnimationTarget = Slots.Front;

            Ability hotspot = new Ability("Hotspot", "Tv_Hotspot_A");
            hotspot.Description = "Inflict 1 Fire on all enemy and party member positions.\nAdjust All Lights.";
            hotspot.Rarity = Rarity.GetCustomRarity("rarity5");
            hotspot.Effects = new EffectInfo[4];
            hotspot.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targetting.Everything(true));
            hotspot.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targetting.Everything(false));
            hotspot.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Targetting.Everything(true));
            hotspot.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Targetting.Everything(false));
            hotspot.AddIntentsToTarget(Targetting.Everything(true), [IntentType_GameIDs.Field_Fire.ToString()]);
            hotspot.AddIntentsToTarget(Targetting.Everything(false), ["Field_Fire"]);
            hotspot.AddIntentsToTarget(Targetting.Everything(true), [IntentType_GameIDs.PA_Unstable.ToString()]);
            hotspot.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.PA_Unstable.ToString()]);
            hotspot.Visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;
            hotspot.AnimationTarget = Slots.Front;

            Ability ambiance = new Ability("Ambiance", "Tv_Ambiance_A");
            ambiance.Description = "Inflict 4 Oil-Slicked and deal a Painful amount of damage to the Left and Right party members. Adjust The Lights on the Left and Right party member positions.\nDeal a Painful amount of damage to this enemy.";
            ambiance.Rarity = Rarity.GetCustomRarity("rarity5");
            ambiance.Effects = new EffectInfo[4];
            ambiance.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, Slots.LeftRight);
            ambiance.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.LeftRight);
            ambiance.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Slots.LeftRight);
            ambiance.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 5, Slots.Self);
            ambiance.AddIntentsToTarget(Slots.LeftRight, ["Status_OilSlicked", "Damage_3_6", "PA_Unstable"]);
            ambiance.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);
            ambiance.Visuals = CustomVisuals.GetVisuals("Salt/Unlock");
            ambiance.AnimationTarget = Slots.LeftRight;

            Ability future = new Ability("Future", "Tv_Future_A");
            future.Description = "Move Left or Right 3 times.\nInflict 4 Oil-Slicked and deal a Painful amount of damage to the Opposing party member.\nAdjust The Lights on the Opposing positions.";
            future.Rarity = Rarity.GetCustomRarity("rarity5");
            future.Effects = new EffectInfo[7];
            future.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            future.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            future.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            future.Effects[3] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Sign", false, Slots.Front));
            future.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, Slots.Front);
            future.Effects[5] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            future.Effects[6] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Slots.Front);
            future.AddIntentsToTarget(Slots.Self, ["Swap_Sides", "Swap_Sides", "Swap_Sides"]);
            future.AddIntentsToTarget(Slots.Front, ["Status_OilSlicked", "Damage_3_6", "PA_Unstable"]);
            future.Visuals = null;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                wreck.GenerateEnemyAbility(true),
                hotspot.GenerateEnemyAbility(true),
                ambiance.GenerateEnemyAbility(true),
                future.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true);
        }
    }
}
