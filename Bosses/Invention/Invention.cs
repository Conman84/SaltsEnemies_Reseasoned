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
            Enemy template = new Enemy("Invention (ITS SIZE FIVE EVEN IF IT DOESNT LOOK IT)", "Invention_BOSS")
            {
                Health = 150,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("InventionWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("InventionWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("InventionWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
                Size = 5
            };
            //template.PrepareEnemyPrefab("assets/group4/Replace/Replace_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Replace/Replace_Gibs.prefab").GetComponent<ParticleSystem>());
            template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("Wall_EN").enemyTemplate;

            //maintain
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
            bonus.Description = "Inflict 1 Scar on the Opposing party member.\nIf there is no Opposing party member, inflict 1 Scar on all party members.";
            bonus.Rarity = Rarity.GetCustomRarity("rarity5");
            bonus.Effects = new EffectInfo[2];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Front);
            bonus.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Unit_AllOpponents, IsFrontTargetCondition.Create(false));
            bonus.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Status_Scars"]);
            bonus.Visuals = CustomVisuals.GetVisuals("Salt/Crush");
            bonus.AnimationTarget = Slots.Front;
            AbilitySO ability = bonus.GenerateEnemyAbility(false).ability;
            maintain._extraAbility.ability = ability;

            PerformEffectPassiveAbility systemic = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            systemic.name = "Systemic_Repeater_PA";
            systemic._passiveName = "Repeater";
            systemic._enemyDescription = "Every 3 times this enemy is damaged, queue the ability \"Repeater\".";
            systemic.m_PassiveID = "Systemic_PA";
            systemic.conditions = [SystemicCondition.Create(3, "Repeater_PA")];
            systemic.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<RepeaterEffect>())];
            systemic.specialStoredData = UnitStoreData.CreateAndAdd_IntTooltip_UnitStoreDataToPool("Repeater_PA", "Repeater: {0}", Color.magenta, false);
            systemic._triggerOn = [TriggerCalls.OnDirectDamaged];

            Ability repeat = new Ability("Repeater", "Repeater_A");
            repeat.Description = "Deal a Painful amount of damage to a random party member or enemy.";
            repeat.Rarity = Rarity.Impossible;
            repeat.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageTargetRandomEffect>(), 5, Targeting.AllUnits)];
            repeat.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Damage_3_6"]);
            repeat.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Damage_3_6"]);
            repeat.Visuals = CustomVisuals.GetVisuals("Salt/Insta/Shatter");
            repeat.AnimationTarget = TargettingSelf_NotSlot.Create();

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Formless, maintain, systemic });

            Ability encroach = new Ability("Encroach", "Encroach_A")
            {
                Description = "Inflict 1 Ruptured on every party member who moved since the start of the last turn.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targetting_By_Moved.Create(false)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Class"),
                AnimationTarget = Targetting_By_Moved.Create(false),
            };
            encroach.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.Misc_Hidden.ToString()]);
            encroach.AddIntentsToTarget(Targetting_By_Moved.Create(false), [IntentType_GameIDs.Status_Ruptured.ToString()]);

            CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
                Pigments.Red,
                Pigments.Blue,
                Pigments.Yellow,
                Pigments.Purple
            };

            Ability series = new Ability("Series", "Series_A");
            series.Description = "Fill the pigment bar with random pigment colors.";
            series.Rarity = Rarity.GetCustomRarity("rarity5");
            series.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateFullBarManaEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            series.Visuals = CustomVisuals.GetVisuals("Salt/Cube");
            series.AnimationTarget = Targeting.Slot_SelfSlot;
            series.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Mana_Generate",
            });

            DamageByStoredValueEffect limitdamage = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
            limitdamage._increaseDamage = false;
            limitdamage.m_unitStoredDataID = "Limit_A";
            CasterSetStoredValueEffect resetlimit = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            resetlimit._valueName = "Limit_A";

            Ability limit = new Ability("Limit", "Limit_A");
            limit.Description = "Deal an Agonizing amount of damage to the Center position.\nReduce this ability's damage by the damage dealt.\nReset if no damage is dealt.";
            limit.Rarity = Rarity.GetCustomRarity("rarity5");
            limit.Effects = [
                Effects.GenerateEffect(limitdamage, 10, Targeting.GenerateGenericTarget([2])),
                Effects.GenerateEffect(ChanageValueByPreviousEffect.Create("Limit_A", true), 1, Slots.Self),
                Effects.GenerateEffect(resetlimit, 0, Slots.Self, BasicEffects.DidThat(false, 2))
                ];
            limit.AddIntentsToTarget(Targeting.GenerateGenericTarget([2]), ["Damage_7_10", "Misc"]);
            limit.Visuals = CustomVisuals.GetVisuals("Salt/Censor");
            limit.AnimationTarget = Targeting.GenerateGenericTarget([2]);
            limit.UnitStoreData = UnitStoreData.CreateAndAdd_IntTooltip_UnitStoreDataToPool("Limit_A", "Limit -{0}", Color.red);


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
