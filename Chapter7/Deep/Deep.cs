using BrutalAPI;
using FMODUnity;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Deep
    {
        public static void Add()
        {
            Enemy deep = new Enemy("The Deep", "TheDeep_EN")
            {
                Health = 300,
                Size = 3,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("DeepIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DeepWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DeepDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound,
            };
            deep.PrepareEnemyPrefab("assets/group4/Deep/Deep_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Deep/Deep_Gibs.prefab").GetComponent<ParticleSystem>());

            deep.AddUnitType(UnitType_GameIDs.Fish.ToString());
            deep.AddLootData(new EnemyLootItemProbability[] { new EnemyLootItemProbability() { isItemTreasure = false, amount = 3, probability = 100 } });

            //SALINITY
            DrowningManager.Setup();
            Debug.LogError("make sure these are the right sprites");
            PerformEffectPassiveAbility salinity = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            salinity._passiveName = "Salinity (1)";
            salinity.passiveIcon = ResourceLoader.LoadSprite("saltwater.png");
            salinity._enemyDescription = "On receiving direct damage, produce 1 Blue Pigment.";
            salinity._characterDescription = "On receiving direct damage, produce 1 Blue Pigment.";
            salinity.m_PassiveID = DrowningManager.Saline;
            salinity.doesPassiveTriggerInformationPanel = true;
            salinity._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            salinity.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateColorManaStoreValueEffect>(), 1, Targeting.Slot_SelfSlot)
            };
            salinity.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(DrowningManager.Saline);

            //ASPHYXIATION
            AsphyxiationManager.Setup();
            AsphyxiationPassiveAbility noOver = ScriptableObject.CreateInstance<AsphyxiationPassiveAbility>();
            noOver._passiveName = "Asphyxiation (50)";
            noOver.passiveIcon = ResourceLoader.LoadSprite("Joeverflow.png");
            noOver.m_PassiveID = "Salt_Asphyxiation_PA";
            noOver._enemyDescription = "Overflow under 50 will not trigger.";
            noOver._characterDescription = "Overflow under 50 will not trigger.";
            noOver.doesPassiveTriggerInformationPanel = false;
            noOver._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
            noOver.ManaCap = 50;

            //PRESSURE
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility pressure = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            pressure._passiveName = "Deep Pressure";
            pressure._enemyDescription = "The Deep will perforn an extra ability \"Deep Pressure\" each turn.";
            Ability bonus = new Ability("Deep_Pressure_A");
            bonus.Name = "Deep Pressure";
            bonus.Description = "Produce 1 Pigment of each of the Opposing party member's health colors. Deal a Little bit of damage to each of them.";
            bonus.Effects = new EffectInfo[2];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 1, Targeting.Slot_Front);
            bonus.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front);
            bonus.Visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
            bonus.AnimationTarget = Targeting.Slot_Front;
            bonus.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Mana_Generate.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            pressure._extraAbility.ability = ability;

            //ADD PASSIVES
            deep.AddPassives(new BasePassiveAbilitySO[] { salinity, noOver, pressure });

            //DESCENT
            Ability descent = new Ability("Deep_Descent_A")
            {
                Name = "Bloating Descent",
                Description = "Produce 2 Blue Pigment and increase Saline by 1. Increase the Lucky Pigment percent by 15.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Blue), 2, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<IncreaseLuckyBluePercentageEffect>(), 15, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            descent.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString(), IntentType_GameIDs.Misc.ToString() });

            //PRESENCE
            Ability presence = new Ability("Deep_Presence_A")
            {
                Name = "Unnerving Presence",
                Description = "Inflict 2 Frail on all party members. Increase Saline by 1.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Targetting.AllEnemy),
                    Effects.GenerateEffect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.visuals,
                AnimationTarget = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.animationTarget,
            };
            presence.AddIntentsToTarget(Targetting.AllEnemy, new string[] { IntentType_GameIDs.Status_Frail.ToString() });
            presence.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });

            //ATTRACT
            PerformEffectPassiveAbility leaky = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            leaky._passiveName = "Leaky (1)";
            leaky.passiveIcon = Passives.Leaky1.passiveIcon;
            leaky._enemyDescription = "Upon receiving direct damage, this enemy generates an extra pigment of its health color.";
            leaky._characterDescription = "Upon receiving direct damage, this character generates an extra pigment of its health color.";
            leaky.m_PassiveID = Passives.Leaky1.m_PassiveID;
            leaky.doesPassiveTriggerInformationPanel = true;
            leaky._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            leaky.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterColorManaStoreValueEffect>(), 1, Targeting.Slot_SelfSlot)
            };
            leaky.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(DrowningManager.Leaky);
            IntentInfoBasic addleaky = new IntentInfoBasic();
            addleaky._sprite = Passives.Leaky1.passiveIcon;
            addleaky.id = "Passive_Leaky";
            Intents.AddCustom_Basic_IntentToPool("Passive_Leaky", addleaky);
            Ability attract = new Ability("Deep_Attract_A")
            {
                Name = "Blood Attraction",
                Description = "Give this enemy Leaky as a passive. If this enemy already had Leaky, increase it by 1. \nIncrease Saline by 1.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.AddPassive(leaky), 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(BasicEffects.ChangeValue(DrowningManager.Leaky, true), 1, Targeting.Slot_SelfSlot, BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("WrigglingWrath_A").visuals,
                AnimationTarget = Targetting.AllSelfSlots,
            };
            attract.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "Passive_Leaky", IntentType_GameIDs.Misc.ToString() });

            //ABYSS
            Ability abyss = new Ability("Deep_Abyss_A")
            {
                Name = "Dark Abyss",
                Description = "Inflict 1 Stunned on all party members not in front of an enemy. Increase Saline by 1.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, ScriptableObject.CreateInstance<TargettingByFacingTarget>()),
                    Effects.GenerateEffect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals,
                AnimationTarget = ScriptableObject.CreateInstance<TargettingByFacingTarget>(),
            };
            abyss.AddIntentsToTarget(ScriptableObject.CreateInstance<TargettingByFacingTarget>(), new string[] { IntentType_GameIDs.Status_Stunned.ToString() });
            abyss.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });

            //ADDENEMY
            deep.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                descent.GenerateEnemyAbility(true),
                presence.GenerateEnemyAbility(true), 
                attract.GenerateEnemyAbility(true),
                abyss.GenerateEnemyAbility(true)
            });
            deep.AddEnemy(true);
        }
    }
}
