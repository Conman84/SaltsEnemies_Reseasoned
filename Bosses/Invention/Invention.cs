using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SaltsEnemies_Reseasoned
{
    public static class Invention
    {
        public static void Add()
        {
            Enemy template = new Enemy("Invention", "Invention_BOSS")
            {
                Health = 180,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("InventionWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("InventionWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("InventionWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Blackwater/Noise/InventionHit",
                DeathSound = "event:/Blackwater/Noise/InventionDie",
                Size = 5
            };
            template.PrepareEnemyPrefab("Assets/Bosses/Invention/Invention_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Bosses/Invention/Invention_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate.m_Data.m_Renderer = template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").Find("Outline").GetComponent<SpriteRenderer>();
            template.AddUnitType("Robot");

            //template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Wall_EN").enemyTemplate;

            //maintain
            GenerateRandomManaBetweenEffect randomize = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
            randomize.possibleMana = new ManaColorSO[]
            {
                Pigments.Blue,
                Pigments.Yellow,
                Pigments.Purple
            };

            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility maintain = ScriptableObject.CreateInstance<ExtraAttackPassiveAbility>();
            maintain.conditions = baseExtra.conditions;
            maintain.passiveIcon = baseExtra.passiveIcon;
            maintain.specialStoredData = baseExtra.specialStoredData;
            maintain.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
            maintain.m_PassiveID = baseExtra.m_PassiveID;
            maintain._extraAbility = new ExtraAbilityInfo();
            maintain._extraAbility.rarity = baseExtra._extraAbility.rarity;
            maintain._extraAbility.cost = baseExtra._extraAbility.cost;
            maintain._passiveName = "Maintenance";
            maintain._enemyDescription = "This enemy will perforn the extra ability \"Maintenance\" each turn.";
            maintain._characterDescription = baseExtra._characterDescription;
            maintain._triggerOn = baseExtra._triggerOn;
            Ability bonus = new Ability("Maintenance_A");
            bonus.Name = "Maintenance";
            bonus.Description = "Deal a Lethal amount of damage to the Central party member position.\nProduce 3 random non-Red Pigment.";
            bonus.Rarity = Rarity.Impossible;
            bonus.Effects = new EffectInfo[2];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 16, Targeting.GenerateGenericTarget([2]));
            bonus.Effects[1] = Effects.GenerateEffect(randomize, 3, Slots.Self);
            bonus.AddIntentsToTarget(Targeting.GenerateGenericTarget([2]), ["Damage_16_20"]);
            bonus.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), ["Mana_Generate"]);
            bonus.Visuals = CustomVisuals.GetVisuals("Salt/Crush");
            bonus.AnimationTarget = Targeting.GenerateGenericTarget([2]);
            AbilitySO ability = bonus.GenerateEnemyAbility(false).ability;
            maintain._extraAbility.ability = ability;
            maintain._extraAbility.rarity = Rarity.GetCustomRarity("rarity5");

            PerformEffectPassiveAbility systemic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            systemic.name = "Systemic_Repeater_PA";
            systemic._passiveName = "Repeater (3)";
            systemic.passiveIcon = ResourceLoader.LoadSprite("SystemicPassive.png");
            systemic._enemyDescription = "Every 3 times this enemy is damaged, queue the ability \"Repeater\".";
            systemic.m_PassiveID = "Systemic_PA";
            systemic.conditions = [SystemicCondition.Create(3, "Repeater_PA")];
            systemic.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<RepeaterEffect>())];
            systemic.specialStoredData = UnitStoreData.CreateAndAdd_IntTooltip_UnitStoreDataToPool("Repeater_PA", "Repeater: {0}", Color.magenta, true, -1);
            systemic._triggerOn = [TriggerCalls.OnDirectDamaged];

            Ability repeat = new Ability("Repeater", "Repeater_A");
            repeat.Description = "Scramble the Costs and Abilities of all party members.";
            repeat.Rarity = Rarity.Impossible;
            repeat.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ScrambleAllAbilitiesEffect>())];
            repeat.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc"]);//custom intent maybe?
            repeat.Visuals = CustomVisuals.GetVisuals("Salt/DiamondBreak");
            repeat.AnimationTarget = TargettingSelf_NotSlot.Create();

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, maintain, systemic });


            TargetingUnit_NotManuallyMoved targeting_ability = ScriptableObject.CreateInstance<TargetingUnit_NotManuallyMoved>();
            targeting_ability.getAllies = false;
            targeting_ability.getAllUnitSlots = false;
            Ability encroach = new Ability("Encroach", "Encroach_A")
            {
                Description = "Deal an Agonizing amount of damage to a random party member that did not manually use an ability this turn.\nIf every party member manually used an ability, deal a Little of damage to this enemy.",
                Rarity = Rarity.Common,
                Visuals = CustomVisuals.GetVisuals("Salt/Insta/Shatter"),
                AnimationTarget = targeting_ability,
            };
            encroach.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageTargetRandomEffect>(), 10, targeting_ability),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self, ScriptableObject.CreateInstance<EverybodyAbilityCondition>())];
            encroach.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            encroach.AddIntentsToTarget(targeting_ability, ["Damage_7_10"]);
            encroach.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Damage_1_2"]);

            TargetingUnit_NotManuallyMoved targeting_both = ScriptableObject.CreateInstance<TargetingUnit_NotManuallyMoved>();
            targeting_both.getAllies = false;
            targeting_both.getAllUnitSlots = false;
            Ability series = new Ability("Series", "Series_A");
            series.Description = "Consume all random Pigment.\nInflict 3 Frail on all party members that both manually moved or manually used an ability.";
            series.Rarity = Rarity.GetCustomRarity("rarity5");
            series.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllManaEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, targeting_both)
            };
            series.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            series.AnimationTarget = targeting_both;
            series.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), new string[]
            {
                "Mana_Consume",
            });
            series.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            series.AddIntentsToTarget(targeting_both, ["Status_Frail"]);

            DamageByStoredValueEffect limitdamage = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
            limitdamage._increaseDamage = false;
            limitdamage.m_unitStoredDataID = "Limit_A";
            CasterSetStoredValueEffect resetlimit = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            resetlimit._valueName = "Limit_A";

            TargetingUnit_NotManuallyMoved targeting_moved = ScriptableObject.CreateInstance<TargetingUnit_NotManuallyMoved>();
            targeting_moved.getAllies = false;
            targeting_moved.getAllUnitSlots = false;
            Ability limit = new Ability("Limit", "Limit_A")
            {
                Description = "Deal a Painful amount of damage to all party members that did not manually move this turn.\nIf every party member manually moved, deal a Painful amount of damage to this enemy.",
                Rarity = Rarity.Common,
                Visuals = CustomVisuals.GetVisuals("Salt/Drill"),
                AnimationTarget = targeting_moved,
            };
            limit.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, targeting_moved),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Slots.Self, ScriptableObject.CreateInstance<EverybodyMovedCondition>())];
            limit.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            limit.AddIntentsToTarget(targeting_moved, ["Damage_3_6"]);
            limit.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Damage_3_6"]);

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                encroach.GenerateEnemyAbility(true),
                series.GenerateEnemyAbility(true),
                limit.GenerateEnemyAbility(true),
                repeat.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true);
        }
    }
}
