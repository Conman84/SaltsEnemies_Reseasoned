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
                CombatSprite = ResourceLoader.LoadSprite("MegalaniaIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MegalaniaIcon.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MegalaniaIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy(Enemies.Camera).damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy(Enemies.Camera).deathSound,
            };
            template.PrepareEnemyPrefab("Assets/Bosses/Tv/Megalania_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Bosses/Tv/Megalania_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate.m_Data.m_Renderer = template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").GetComponent<SpriteRenderer>();

            //radical
            PerformEffectPassiveAbility radical = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            radical._passiveName = "Radical";
            radical.passiveIcon = ResourceLoader.LoadSprite("RadicalPassive.png");
            radical.m_PassiveID = "Radical_PA";
            radical._enemyDescription = "On being damaged, Adjust All Lights.";
            radical._characterDescription = "On being damaged, Adjust All Lights.";
            radical.doesPassiveTriggerInformationPanel = true;
            radical.effects = new EffectInfo[] {
                Effects.GenerateEffect(CasterRootActionEffect.Create(new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeLightsEffects>(), 1, MultiTargetting.Create(Targetting.Everything(true), Targetting.Everything(false))),
                    Effects.GenerateEffect(BasicEffects.SetStoreValue("Radical_PA"), 0, Slots.Self)
                }
            )) };
            radical._triggerOn = [TriggerCalls.OnDirectDamaged];
            radical.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { StoredValueEffectorCondition.Create("Radical_PA", true, true) }.ToArray();

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, radical, Passives.MultiAttack2 });
            AbilitySelector_Bots isolate = ScriptableObject.CreateInstance<AbilitySelector_Bots>();
            isolate.Isolate = ["Tv_Propaganda_A"];
            template.AbilitySelector = isolate;

            Ability wreck = new Ability("Wreck", "Tv_Wreck_A");
            wreck.Description = "Deal an Agonizing amount of damage to the Opposing party member.\nInflict 1 Slip on the Opposing position.";
            wreck.Rarity = Rarity.GetCustomRarity("rarity5");
            wreck.Effects = new EffectInfo[2];
            wreck.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front);
            wreck.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Front);
            wreck.AddIntentsToTarget(Slots.Front, ["Damage_7_10", Slip.Intent]);
            wreck.Visuals = CustomVisuals.GetVisuals("Salt/Cannon");
            wreck.AnimationTarget = Slots.Front;

            HotspotTargetting hst = ScriptableObject.CreateInstance<HotspotTargetting>();
            hst.getAllies = false;
            hst.getAllUnitSlots = true;

            Ability hotspot = new Ability("Hotspot", "Tv_Hotspot_A");
            hotspot.Description = "Deal a Barely Painful amount of damage to all party members in the same Light color as this enemy.";
            hotspot.Rarity = Rarity.GetCustomRarity("rarity5");
            hotspot.Effects = new EffectInfo[1];
            hotspot.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<HotspotEffect>(), 3, Slots.SlotTarget([-4, -3, -2, -1, 0, 1, 2, 3, 4], false));
            hotspot.AddIntentsToTarget(Slots.SlotTarget([-4, -3, -2, -1, 0, 1, 2, 3, 4], false), ["Damage_3_6"]);
            hotspot.Visuals = CustomVisuals.GetVisuals("Salt/StageLights");
            hotspot.AnimationTarget = hst;

            GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            random.possibleMana = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple];
            Ability ambiance = new Ability("Ambiance", "Tv_Ambiance_A");
            ambiance.Description = "Generate 5 random Pigment.";
            ambiance.Rarity = Rarity.GetCustomRarity("rarity5");
            ambiance.Effects = new EffectInfo[1];
            ambiance.Effects[0] = Effects.GenerateEffect(random, 5, Slots.Self);
            ambiance.AddIntentsToTarget(Slots.Self, ["Mana_Generate", "Mana_Generate", "Mana_Generate", "Mana_Generate", "Mana_Generate"]);
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

            Ability propaganda = new Ability("Propaganda", "Tv_Propaganda_A");
            propaganda.Description = "Shift the Pigment costs of the abilities of all party members.";
            propaganda.Rarity = Rarity.GetCustomRarity("rarity5");
            propaganda.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ShiftCostsEffect>(), 1, Targeting.Unit_AllOpponents)];
            propaganda.AddIntentsToTarget(propaganda.Effects[0].targets, [IntentType_GameIDs.Mana_Modify.ToString()]);
            propaganda.Visuals = CustomVisuals.GetVisuals("Salt/Propaganda");
            propaganda.AnimationTarget = Slots.Self;
            propaganda.Priority = Priority.Slow;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                wreck.GenerateEnemyAbility(true),
                hotspot.GenerateEnemyAbility(true),
                ambiance.GenerateEnemyAbility(true),
                future.GenerateEnemyAbility(true),
                propaganda.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true);
        }
    }
}
