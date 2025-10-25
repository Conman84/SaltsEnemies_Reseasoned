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
            bonus.Description = "Inflict 2 Scars on the Central party member and generate 3 random non-Red Pigment.\nIf there is no Central party member, inflict 1 Scar on all party members.";
            bonus.Rarity = Rarity.Common;
            bonus.Effects = new EffectInfo[3];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, Targeting.GenerateGenericTarget([2]));
            bonus.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Unit_AllOpponents, HasCentralPartyMemberCondition.Create(false));
            bonus.Effects[2] = Effects.GenerateEffect(randomize, 3, Slots.Self);
            bonus.AddIntentsToTarget(Targetting.Everything(false), ["Status_Scars"]);
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

            TargetingUnit_NotManuallyMoved allenemy = ScriptableObject.CreateInstance<TargetingUnit_NotManuallyMoved>();
            allenemy.getAllies = false;
            allenemy.getAllUnitSlots = false;

            Ability repeat = new Ability("Repeater", "Repeater_A");
            repeat.Description = "Deal a Painful amount of damage to a random party member that did not manually move this turn.\nIf every party member manually moved, deal a Painful amount of damage to this enemy.";
            repeat.Rarity = Rarity.Impossible;
            repeat.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageTargetRandomEffect>(), 5, allenemy),
            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Self, ScriptableObject.CreateInstance<EverybodyMovedCondition>())];
            repeat.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            repeat.AddIntentsToTarget(allenemy, ["Damage_3_6"]);
            repeat.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);
            repeat.Visuals = CustomVisuals.GetVisuals("Salt/Insta/Shatter");
            repeat.AnimationTarget = TargettingSelf_NotSlot.Create();

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, maintain, systemic });

            Ability encroach = new Ability("Encroach", "Encroach_A")
            {
                Description = "Inflict 1 Ruptured on every party member who moved since the start of the last turn.\nIf no party members moved last turn, deal a Little damage to all party members.",
                Rarity = Rarity.Common,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targetting_By_Moved.Create(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Unit_AllOpponents, ScriptableObject.CreateInstance<NobodyMovedCondition>())
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Class"),
                AnimationTarget = Targetting_By_Moved.Create(false),
            };
            encroach.AddIntentsToTarget(Targetting.Everything(false), ["Misc_Hidden", "Status_Ruptured", "Damage_1_2"]);

            Ability series = new Ability("Series", "Series_A");
            series.Description = "Consume 3 random Pigment.\nDouble the maximum health of all party members";
            series.Rarity = Rarity.GetCustomRarity("rarity5");
            series.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 3, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DoubleMaxHealthTargetEffect>(), 1, Targeting.Unit_AllOpponents)
            };
            series.Visuals = CustomVisuals.GetVisuals("Salt/Cube");
            series.AnimationTarget = TargettingSelf_NotSlot.Create();
            series.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), new string[]
            {
                "Mana_Consume",
            });
            series.AddIntentsToTarget(Targeting.Unit_AllOpponents, [IntentType_GameIDs.Other_MaxHealth_Alt.ToString()]);

            DamageByStoredValueEffect limitdamage = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
            limitdamage._increaseDamage = false;
            limitdamage.m_unitStoredDataID = "Limit_A";
            CasterSetStoredValueEffect resetlimit = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            resetlimit._valueName = "Limit_A";

            Ability limit = new Ability("Limit", "Limit_A");
            limit.Description = "Deal an Agonizing amount of damage to the Center position.\nCurse the highest health party member if there is no Central Opposing party member.";
            limit.Rarity = Rarity.Common;
            limit.Effects = [
                Effects.GenerateEffect(limitdamage, 10, Targeting.GenerateGenericTarget([2])),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Targetting.HighestEnemy, HasCentralPartyMemberCondition.Create(false))
                ];
            limit.AddIntentsToTarget(Targeting.GenerateGenericTarget([2]), ["Damage_7_10"]);
            limit.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Status_Cursed"]);
            limit.Visuals = CustomVisuals.GetVisuals("Salt/Drill");
            limit.AnimationTarget = Targeting.GenerateGenericTarget([2]);
            limit.UnitStoreData = UnitStoreData.CreateAndAdd_IntTooltip_UnitStoreDataToPool("Limit_A", "Limit -{0}", Misc.GetInGame_UITextColor(Misc.UITextColorIDs.Negative));


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
