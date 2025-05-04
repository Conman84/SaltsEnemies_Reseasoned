using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class TheEndOfTime
    {
        public static void Add()
        {
            Enemy clock = new Enemy("The End of Time", "ClockTower_EN")
            {
                Health = 44,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("ClockTowerIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ClockTowerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ClockTowerWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound/ClockHit",
                DeathSound = "event:/Hawthorne/Sound/ClockDie",
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ClockTower>()
            };
            clock.PrepareEnemyPrefab("assets/group4/ClockTower/ClockTower_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/ClockTower/ClockTower_Gibs.prefab").GetComponent<ParticleSystem>());
            //roar: event:/Hawthorne/Noi3e/PawnRoar


            //ACCELERATION
            ClockTowerManager.Setup();
            ClockTowerPassive acceleration = ScriptableObject.CreateInstance<ClockTowerPassive>();
            acceleration._passiveName = "Acceleration";
            acceleration.passiveIcon = ResourceLoader.LoadSprite("ParanoidSpeed.png");
            acceleration._enemyDescription = "If the player's portion of the turn takes longer than 60 seconds, apply 6 Entropy to all party members.";
            acceleration._characterDescription = "Doesn't work. I didnt bother setting up the hooks for this.";
            acceleration.m_PassiveID = ClockTowerManager.Acceleration;
            acceleration.doesPassiveTriggerInformationPanel = true;
            acceleration._triggerOn = new TriggerCalls[] { ClockTowerManager.Call };
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            acceleration.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Alarm", false, Targeting.Slot_SelfSlot), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 6, allEnemy)
            };
            acceleration.specialStoredData = UnitStoreData.GetCustom_UnitStoreData(ClockTowerManager.Acceleration);
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("ParanoidSpeed.png"), "Acceleration", acceleration._enemyDescription);

            //ADDPASSIVES
            clock.AddPassives(new BasePassiveAbilitySO[] { Passives.OverexertGenerator(12), acceleration });
            clock.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ClockTowerExitEffect>(), 1, Targeting.Slot_SelfSlot) };

            //CRIPPLE
            TargettingByHealthUnits lowest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
            lowest.Lowest = true;
            lowest.getAllies = false;
            Ability cripple = new Ability("Clock_Cripple_A")
            {
                Name = "Cripple",
                Description = "Inflict 3 Frail and 1 Scar on the lowest health party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, lowest),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, lowest)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Needle"),
                AnimationTarget = lowest,
            };
            cripple.AddIntentsToTarget(lowest, new string[] { IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Status_Scars.ToString() });
            cripple.AddIntentsToTarget(allEnemy, new string[] { IntentType_GameIDs.Misc.ToString() });

            //CRUCIFY
            TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
            highest.Lowest = false;
            highest.getAllies = false;
            Ability crucify = new Ability("Clock_Crucify_A")
            {
                Name = "Crucify",
                Description = "Inflict 4 Ruptured on the highest health party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 4, highest),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals,
                AnimationTarget = highest,
            };
            crucify.AddIntentsToTarget(highest, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            crucify.AddIntentsToTarget(allEnemy, new string[] { IntentType_GameIDs.Misc.ToString() });
            
            //CRACKING
            Ability cracking = new Ability("Clock_Cracking_A")
            {
                Name = "Cracking",
                Description = "Start a 150 second timer. If this enemy is still alive at the end of the timer, apply 12 Entropy on a random party member.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("Clock_10", 10),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<CrackingEffect>(), 12, allEnemy),
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals,
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            cracking.AddIntentsToTarget(allEnemy, new string[] { Entropy.Intent });

            //ADD ENEMY
            clock.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                cripple.GenerateEnemyAbility(true),
                crucify.GenerateEnemyAbility(true),
                cracking.GenerateEnemyAbility(true),
            });
            clock.AddEnemy(true, true);
        }
    }
}
