using BrutalAPI;
using UnityEngine;
using SaltEnemies_Reseasoned;

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
                OverworldDeadSprite = ResourceLoader.LoadSprite("TankWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TankDead.png", new Vector2(0.5f, 0f), 32),
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

            //WARNING
            PerformEffectPassiveAbility warn = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            warn._passiveName = "Warning";
            warn.m_PassiveID = "Tank_Warning_PA";
            warn.passiveIcon = ResourceLoader.LoadSprite("WarningPassive.png");
            warn._enemyDescription = "On taking direct damage, inflict 1 random Negative Status Effect on all party members.";
            warn._characterDescription = "On taking direct damage, inflict 1 random Negative Status Effect on all enemies.";
            warn.doesPassiveTriggerInformationPanel = true;
            warn.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomNegativeStatusEffect>(), 1, Targetting.AllEnemy) };
            warn._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
            warn.conditions = Passives.Slippery.conditions;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Forgetful, cold, warn });

            //BLOAT
            Ability bloat = new Ability("Salt_Bloat_A")
            {
                Name = "Bloat",
                Description = "Apply 10 Shield and 2 Fire to this enemy's position.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tank_10", 10),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, Targetting.AllSelfSlots),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, Targetting.AllSelfSlots)
                        },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals,
                AnimationTarget = Targetting.AllSelfSlots,
            };
            bloat.AddIntentsToTarget(Targetting.AllSelfSlots, new string[] { IntentType_GameIDs.Field_Shield.ToString(), IntentType_GameIDs.Field_Fire.ToString() });

            //GROSS
            Ability gross = new Ability("Salt_Gross_A")
            {
                Name = "Gross",
                Description = "Deal an Agonizing amount of damage and apply 1 Fire to the left and right party member positions.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Targeting.Slot_OpponentSides),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targeting.Slot_OpponentSides)
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                AnimationTarget = Targeting.Slot_OpponentSides,
            };
            gross.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Field_Fire.ToString() });

            //COARSE
            DamageEffect ignore = ScriptableObject.CreateInstance<DamageEffect>();
            ignore._ignoreShield = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            Ability coarse = new Ability("Salt_Coarse_A")
            {
                Name = "Coarse",
                Description = "Deal a Painful amount of Shield-Piercing damage to this enemy. Apply 6 Oil-Slicked on all party members.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Tank_1", 1),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ignore, 6, Targeting.Slot_SelfSlot),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 6, allEnemy)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            coarse.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
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
