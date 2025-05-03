using BrutalAPI;
using UnityEngine;
using SaltEnemies_Reseasoned;
using System.Collections.Generic;

namespace SaltsEnemies_Reseasoned
{
    public static class SemiRealisticTank
    {
        public static void Add()
        {
            Enemy template = new Enemy("Semi-Realistic Tank", "RealisticTank_EN")
            {
                Health = 42,
                HealthColor = Pigments.Red,
                Size = 2,
                CombatSprite = ResourceLoader.LoadSprite("TankIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TankDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TankWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/TankHit",
                DeathSound = "event:/Hawthorne/Die/TankDie",
            };
            template.PrepareEnemyPrefab("assets/group4/Tank/Tank_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Tank/Tank_Gibs.prefab").GetComponent<ParticleSystem>());

            //COLD BLOOD
            FireNoReduce.Setup();
            PerformEffectPassiveAbility cold = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            cold._passiveName = "Cold-Blooded";
            cold.passiveIcon = ResourceLoader.LoadSprite("cold.png");
            cold.m_PassiveID = FireNoReduce.PassiveID;
            cold._characterDescription = "All Fire damage received by this character is multiplied by -1. This damage cannot set this character's health above their maximum health. \nFire on this party member's position does not decrease.";
            cold._enemyDescription = "All Fire damage received by this enemy is multiplied by -1. This damage cannot set this enemy's health above their maximum health. \nFire on this enemy's position does not decrease.";
            cold.doesPassiveTriggerInformationPanel = false;
            cold._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
            cold.conditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<ColdHealCondition>()
            };
            cold.effects = new EffectInfo[0];
            //AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("cold.png"), "Cold-Blooded", cold._enemyDescription);

            //WARNING
            PerformEffectPassiveAbility warn = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            warn._passiveName = "Warning";
            warn.m_PassiveID = "Tank_Warning_PA";
            warn.passiveIcon = ResourceLoader.LoadSprite("WarningPassive.png");
            warn._enemyDescription = "On taking any damage, inflict 1 random Negative Status Effect on all party members.";
            warn._characterDescription = "On taking any damage, inflict 1 random Negative Status Effect on all enemies.";
            warn.doesPassiveTriggerInformationPanel = true;
            warn.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomNegativeStatusEffect>(), 1, Targetting.AllEnemy) };
            warn._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDamaged };
            warn.conditions = Passives.Slippery.conditions;
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("WarningPassive.png"), "Warning", warn._enemyDescription);

            //backlash
            PerformEffectPassiveAbility backlash = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            backlash._passiveName = "Backlash";
            backlash.m_PassiveID = "Backlash_PA";
            backlash.passiveIcon = ResourceLoader.LoadSprite("BacklashPassive.png");
            backlash._enemyDescription = "On taking direct damage, apply Shield to this unit's position for the amount of damage taken.";
            backlash._characterDescription = backlash._enemyDescription;
            backlash.doesPassiveTriggerInformationPanel = false;
            backlash.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<BacklashCondition>() }.ToArray();
            backlash._triggerOn = [TriggerCalls.OnDirectDamaged];
            backlash.effects = [];
            

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Forgetful, warn, backlash });

            //BLOAT
            Ability bloat = new Ability("Salt_Bloat_A")
            {
                Name = "Bloat",
                Description = "Apply 6 Shield to this enemy's positions.\nReset the Fleeting counter on all enemies.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tank_10", 10),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, Targeting.Slot_SelfAll),
                    Effects.GenerateEffect(SetStoreValueTargetEffect.Create(UnitStoredValueNames_GameIDs.FleetingPA.ToString(), true), 0, Targetting.AllAlly),
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals,
                AnimationTarget = Targeting.Slot_SelfAll,
            };
            bloat.AddIntentsToTarget(Targeting.Slot_SelfAll, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            bloat.AddIntentsToTarget(Targetting.AllAlly, new string[] { IntentType_GameIDs.PA_Fleeting.ToString() });

            //GROSS
            Ability gross = new Ability("Salt_Gross_A")
            {
                Name = "Gross",
                Description = "Deal an Agonizing amount of damage to the Left and Right party member positions. \nInflict 1 Ruptured on the Opposing party members.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Targeting.Slot_OpponentSides),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targeting.Slot_OpponentSides),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                AnimationTarget = Targeting.Slot_OpponentSides,
            };
            gross.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            gross.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });

            //COARSE
            DamageEffect ignore = ScriptableObject.CreateInstance<DamageEffect>();
            ignore._ignoreShield = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            Ability coarse = new Ability("Salt_Coarse_A")
            {
                Name = "Coarse",
                Description = "Deal a Painful amount of damage to this enemy. Inflict 6 Oil-Slicked on all party members.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tank_1", 1),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 6, allEnemy)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                AnimationTarget = TargettingSelf_NotSlot.Create(),
            };
            coarse.AddIntentsToTarget(TargettingSelf_NotSlot.Create(), new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            coarse.AddIntentsToTarget(allEnemy, new string[] {IntentType_GameIDs.Status_OilSlicked.ToString() });

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                bloat.GenerateEnemyAbility(true),
                gross.GenerateEnemyAbility(true),
                coarse.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }
}
