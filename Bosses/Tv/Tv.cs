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
                CombatSprite = ResourceLoader.LoadSprite("TvWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TvWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TvWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            //template.PrepareEnemyPrefab("assets/group4/Tv/Tv_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Tv/Tv_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Solitaire_EN").enemyTemplate;

            //radical
            PerformEffectPassiveAbility radical = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            radical._passiveName = "Radical";
            radical.passiveIcon = ResourceLoader.LoadSprite("RadicalPassive.png");
            radical.m_PassiveID = "Radical_PA";
            radical._enemyDescription = "On being damaged, Adjust All Lights.";
            radical._characterDescription = "On being damaged, Adjust All Lights.";
            radical.doesPassiveTriggerInformationPanel = true;
            radical.effects = new EffectInfo[] { Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[] 
            {
                Effects.GenerateEffect(CasterSubActionEffect.Create([
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Targetting.Everything(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, Targetting.Everything(false)),
                    ]))
            })) };
            radical._triggerOn = [TriggerCalls.OnDirectDamaged];

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, radical, Passives.MultiAttack2 });

            Ability wreck = new Ability("Wreck", "Tv_Wreck_A");
            wreck.Description = "Deal an Agonizing amount of damage to the Opposing party member.\nInflict 1 Slip on the Opposing position.";
            wreck.Rarity = Rarity.GetCustomRarity("rarity5");
            wreck.Effects = new EffectInfo[2];
            wreck.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front);
            wreck.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front);
            wreck.AddIntentsToTarget(Slots.Front, ["Damage_7_10", Slip.Intent]);
            wreck.Visuals = CustomVisuals.GetVisuals("Salt/Cannon");
            wreck.AnimationTarget = Slots.Front;

            Ability hotspot = new Ability("Hotspot", "Tv_Hotspot_A");
            hotspot.Description = "Deal a Barely Painful amount of damage to all party members in the same Light color as this enemy.";
            hotspot.Rarity = Rarity.GetCustomRarity("rarity5");
            hotspot.Effects = new EffectInfo[1];
            hotspot.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<HotspotEffect>(), 3, Slots.SlotTarget([-4, -3, -2, -1, 0, 1, 2, 3, 4], false));
            hotspot.AddIntentsToTarget(Slots.SlotTarget([-4, -3, -2, -1, 0, 1, 2, 3, 4], false), ["Damage_3_6"]);
            hotspot.Visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;
            hotspot.AnimationTarget = Slots.Self;

            GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            random.possibleMana = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple];
            Ability ambiance = new Ability("Ambiance", "Tv_Ambiance_A");
            ambiance.Description = "Generate 4 random Pigment.";
            ambiance.Rarity = Rarity.GetCustomRarity("rarity5");
            ambiance.Effects = new EffectInfo[1];
            ambiance.Effects[0] = Effects.GenerateEffect(random, 4, Slots.Self);
            ambiance.AddIntentsToTarget(Slots.Self, ["Mana_Generate"]);
            ambiance.Visuals = CustomVisuals.GetVisuals("Salt/Unlock");
            ambiance.AnimationTarget = Slots.Self;

            Ability future = new Ability("Future", "Tv_Future_A");
            future.Description = "Deal a Painful amount of damage to the Opposing party member and move Left or Right.";
            future.Rarity = Rarity.GetCustomRarity("rarity5");
            future.Effects = new EffectInfo[2];
            future.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            future.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            future.AddIntentsToTarget(Slots.Front, ["Damage_3_6"]);
            future.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            future.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            future.AnimationTarget = Slots.Front;

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
