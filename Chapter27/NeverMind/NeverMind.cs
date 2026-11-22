using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class NeverMind
    {
        public static EnemySO Self;
        public static void ForceCensor(bool Do)
        {
            if (!Do)
            {
                Self.enemySprite = ResourceLoader.LoadSprite("NeverMindIcon.png");
                Self.enemyOverworldSprite = ResourceLoader.LoadSprite("NeverMindWorld.png", new Vector2(0.5f, 0f), 32);
                Self.enemyOWCorpseSprite = ResourceLoader.LoadSprite("NeverMindDead.png", new Vector2(0.5f, 0f), 32);
                LoadedDBsHandler.PortalDB.m_PortalData["Salt_NeverMindEncounter_Sign"].portalIcon = ResourceLoader.LoadSprite("NeverMindWorld.png");

                //Debug.Log("icons");

                Self.enemyTemplate.m_Data.m_Locator.transform.parent.Find("Censor").gameObject.SetActive(false);
                Self.enemyTemplate.m_Data.m_Locator.transform.parent.Find("AltCensor").gameObject.SetActive(false);
                Self.enemyTemplate.m_Data.m_Locator.transform.parent.Find("ThirdAltCensor").gameObject.SetActive(false);

                //Debug.Log("prefab");

                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("Censor_Front").gameObject.SetActive(false);
                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("Censor_Back").gameObject.SetActive(false);
                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("CensorMain").gameObject.SetActive(false);
                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("CensorFloor").gameObject.SetActive(false);

                //Debug.Log("gibs");
            }
            else
            {
                Self.enemySprite = ResourceLoader.LoadSprite("CensorIcon.png");
                Self.enemyOverworldSprite = ResourceLoader.LoadSprite("CensorWorld.png", new Vector2(0.5f, 0f), 32);
                Self.enemyOWCorpseSprite = ResourceLoader.LoadSprite("CensorDead.png", new Vector2(0.5f, 0f), 32);
                LoadedDBsHandler.PortalDB.m_PortalData["Salt_NeverMindEncounter_Sign"].portalIcon = ResourceLoader.LoadSprite("CensorWorld.png");

                //Debug.Log("icons");

                Self.enemyTemplate.m_Data.m_Locator.transform.parent.Find("Censor").gameObject.SetActive(true);
                Self.enemyTemplate.m_Data.m_Locator.transform.parent.Find("AltCensor").gameObject.SetActive(true);
                Self.enemyTemplate.m_Data.m_Locator.transform.parent.Find("ThirdAltCensor").gameObject.SetActive(true);

                //Debug.Log("prefab");

                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("Censor_Front").gameObject.SetActive(true);
                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("Censor_Back").gameObject.SetActive(true);
                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("CensorMain").gameObject.SetActive(true);
                Self.enemyTemplate.m_Data.m_Gibs.transform.Find("CensorFloor").gameObject.SetActive(true);

                //Debug.Log("gibs");
            }
        }
        public static void Add()
        {
            Portals.AddPortalSign("Salt_NeverMindEncounter_Sign", ResourceLoader.LoadSprite("NeverMindWorld.png"), Portals.EnemyIDColor);

            Enemy nevermind = new Enemy("Never-Mind", "NeverMind_EN")
            {
                Health = 301,
                HealthColor = Pigments.Red,
                Priority = Priority.Slow,
                CombatSprite = ResourceLoader.LoadSprite("NeverMindIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("NeverMindWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("NeverMindDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("LostSheep_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("LostSheep_EN").deathSound,
            };
            nevermind.PrepareEnemyPrefab("Assets/ch_27/NeverMind_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_27/NeverMind_Gibs.prefab").GetComponent<ParticleSystem>());
            Self = nevermind.enemy;
            ForceCensor(GeneralConfig.PossibleNeverMindArachnophobiaCensor.Value);

            //empty
            PerformEffectPassiveAbility emptiness = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            emptiness.name = "Emptiness_PA";
            emptiness._passiveName = "Emptiness Emptiness Emptiness";
            emptiness.m_PassiveID = "Emptiness_PA";
            emptiness.passiveIcon = ResourceLoader.LoadSprite("EmptinessPassive.png");
            emptiness._characterDescription = "On being directly damaged, swap missing healths with the attacker.";
            emptiness._enemyDescription = "On being directly damaged, swap missing healths with the attacker.";
            EmptinessPassiveEffectorCondition swap = ScriptableObject.CreateInstance<EmptinessPassiveEffectorCondition>();
            swap.passive = emptiness;
            emptiness.conditions = [swap];
            emptiness.doesPassiveTriggerInformationPanel = false;
            emptiness._triggerOn = [TriggerCalls.OnDirectDamaged];
            emptiness.effects = [];

            //Revenge
            PerformEffectPassiveAbility revenge = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            revenge._passiveName = "Revenge";
            revenge.m_PassiveID = "Revenge_PA";
            revenge.passiveIcon = ResourceLoader.LoadSprite("Revenge.png");
            revenge._characterDescription = "On taking direct damage, give this enemy another ability.";
            revenge._enemyDescription = "On taking direct damage, give this enemy another action.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            revenge._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            revenge.conditions = Passives.Slippery.conditions;

            //vivacious
            PerformEffectPassiveAbility viv = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            viv.name = "Vivacious_1_PA";
            viv._passiveName = "Vivacious (1)";
            viv.m_PassiveID = "Vivacious_PA";
            viv.passiveIcon = ResourceLoader.LoadSprite("VivaciousPassive.png");
            viv._characterDescription = "At the end of each round, move Left or Right.";
            viv._enemyDescription = viv._characterDescription;
            viv.conditions = [];
            viv._triggerOn = [TriggerCalls.OnRoundFinished];
            viv.effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                ];


            //parental
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility unfeeling = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            unfeeling._passiveName = "Parental";
            unfeeling._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Unfeeling\" in retribution.";
            Ability parental = new Ability("NM_Unfeeling_A");
            parental.Name = "Unfeeling";
            parental.Description = "Randomize this enemy's health color.";
            parental.Rarity = Rarity.Impossible;
            parental.Effects = [
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Whisper", false, Slots.Self)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorEffect>(), 1, Slots.Self),
                ];
            parental.AddIntentsToTarget(Slots.Self, ["Mana_Modify"]);
            parental.AnimationTarget = Slots.Self;
            parental.Visuals = null;

            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            unfeeling._parentalAbility.ability = ability;

            nevermind.AddPassives(new BasePassiveAbilitySO[] { emptiness, revenge, viv, unfeeling });

            DamageByAmountsEffect low = ScriptableObject.CreateInstance<DamageByAmountsEffect>();
            low.Amounts = [1, 2, 3, 4, 4, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 9, 11];
            DamageByAmountsEffect high = ScriptableObject.CreateInstance<DamageByAmountsEffect>();
            high.Amounts = [1, 3, 4, 4, 5, 5, 5, 8, 8, 8, 8, 9, 9, 9, 13, 16];

            Ability unthoughts = new Ability("Unthoughts", "NM_Unthoughts_A");
            unthoughts.Description = "Halve this enemy's current and maximum health.\nIncrease the maximum healths of the Left, Right, and Opposing party members by 35% and apply Favor to one of them.\nDeal 1, 2, 3, 4, 5, 6, 7, 9, or 11 damage to the Opposing party member.";
            unthoughts.Rarity = Rarity.Common;
            unthoughts.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HalveCurrentAndMaxHealthEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Boil_A", false, Slots.FrontLeftRight)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ScaleMaxHealthTargetEffect>(), 35, Slots.FrontLeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFavorSingleEffect>(), 1, Slots.FrontLeftRight),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Wrath_1_A", true, Slots.Front)),
                Effects.GenerateEffect(low, 1, Slots.Front),
                ];
            unthoughts.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Other_MaxHealth_Alt.ToString()]);
            unthoughts.AddIntentsToTarget(Slots.FrontLeftRight, [IntentType_GameIDs.Other_MaxHealth.ToString(), Favor.Intent]);
            unthoughts.AddIntentsToTarget(Slots.Front, [
                FallColor.Intent, 
                "Damage_1_2",
                "Damage_3_6",
                "Damage_7_10",
                "Damage_11_15",
            ]);
            unthoughts.AnimationTarget = Slots.Front;
            unthoughts.Visuals = null;

            TargettingUnitsWithStatusEffectSide muted = ScriptableObject.CreateInstance<TargettingUnitsWithStatusEffectSide>();
            muted.getAllies = false;
            muted.targetStatus = Muted.StatusID;
            Intents.CreateAndAddCustom_Basic_IntentToPool("Slap_A", LoadedAssetsHandler.GetCharacterAbility("Slap_A").abilitySprite, UnityEngine.Color.white);
            ApplyMutedMoreMaxHealthCasterTargetsEffect onlyIfNone = ScriptableObject.CreateInstance<ApplyMutedMoreMaxHealthCasterTargetsEffect>();
            onlyIfNone.OnlyIfNone = true;

            Ability unbothered = new Ability("Unbothered", "NM_Unbothered_A");
            unbothered.Description = "Halve this enemy's current and maximum health.\nInflict 1 Muted on all party members with more maximum health than this enemy if they have no Muted. Force all Muted party members to perform \"Slap.\"";
            unbothered.Rarity = Rarity.GetCustomRarity("rarity5");
            unbothered.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HalveCurrentAndMaxHealthEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Unlock", false, Slots.Self)),
                Effects.GenerateEffect(onlyIfNone, 1, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ForceTargetsUseSlapEffect>(), 1, muted),
                ];
            unbothered.AddIntentsToTarget(Slots.Self, ["Other_MaxHealth_Alt"]);
            unbothered.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden", Muted.Intent, "Slap_A"]);
            unbothered.Visuals = null;
            unbothered.AnimationTarget = Slots.Self;

            TargettingUnitsMaxHealth mostest = ScriptableObject.CreateInstance<TargettingUnitsMaxHealth>();
            mostest.GetAllUnits = true;
            mostest.Lowest = false;
            mostest.getAllies = false;
            TargettingUnitsMaxHealth other = ScriptableObject.CreateInstance<TargettingUnitsMaxHealth>();
            other.GetAllUnits = true;
            other.Lowest = false;
            other.getAllies = true;
            other.OnlyReturnEnemySide = true;
            TargettingUnitsMaxHealth other2 = ScriptableObject.CreateInstance<TargettingUnitsMaxHealth>();
            other2.GetAllUnits = true;
            other2.Lowest = false;
            other2.getAllies = false;
            other2.OnlyReturnCharaSide = true;

            Ability unpersons = new Ability("Unpersons", "NM_Unpersons_A");
            unpersons.Description = "Halve this enemy's current and maximum health.\nDeal 1, 3, 4, 5, 8, 9, 13, or 16 damage to the enemy or party member with the most maximum health.\nInstantly kill all enemies and party members with over a thousand maximum health.";
            unpersons.Rarity = Rarity.Uncommon;
            unpersons.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HalveCurrentAndMaxHealthEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Censor", false, mostest)),
                Effects.GenerateEffect(high, 1, mostest),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<KillAllTargetsMaxHealthThresholdEffect>(), 1000, Targeting.AllUnits)
                ];
            unpersons.AddIntentsToTarget(Slots.Self, ["Other_MaxHealth_Alt"]);
            unpersons.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Misc_Hidden"]);
            unpersons.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden"]);
            unpersons.AddIntentsToTarget(other2, [
                FallColor.Intent,
                "Damage_1_2",
                "Damage_3_6",
                "Damage_7_10",
                "Damage_11_15",
                "Damage_16_20",
                "Damage_Death",
            ]);
            unpersons.AddIntentsToTarget(other, [
                FallColor.Intent,
                "Damage_1_2",
                "Damage_3_6",
                "Damage_7_10",
                "Damage_11_15",
                "Damage_16_20",
                "Damage_Death",
            ]);
            unpersons.Visuals = null;
            unpersons.AnimationTarget = mostest;


            //ADD ENEMY
            nevermind.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                unthoughts.GenerateEnemyAbility(true),
                unbothered.GenerateEnemyAbility(true),
                unpersons.GenerateEnemyAbility(true),
            });
            nevermind.SilentAddEnemy(true);
            nevermind.enemy.AddToSynodPool();
            nevermind.enemy.AddToEcstasyPool();
        }
    }
}
