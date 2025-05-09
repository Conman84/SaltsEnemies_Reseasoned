using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class MidnightTrafficLight
    {
        public static void Add()
        {
            Enemy train = new Enemy("Midnight Traffic Light", "Stoplight_EN")
            {
                Health = 50,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("TrainIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TrainDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TrainWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound/TrainHit",
                DeathSound = "event:/Hawthorne/Sound/TrainDie",
            };
            train.PrepareMultiEnemyPrefab("assets/train/Train_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/train/Train_Gibs.prefab").GetComponent<ParticleSystem>());
            (train.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                train.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").GetComponent<SpriteRenderer>(),
            };

            //ability selector
            AbilitySelector_Heaven selector = ScriptableObject.CreateInstance<AbilitySelector_Heaven>();
            selector._ComeHomeAbility = "Train_Flip_A";
            selector._useAfterTurns = 2;
            train.AbilitySelector = selector;

            //PRACTICAL
            PerformEffectPassiveAbility prac = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            prac._passiveName = "Practical";
            prac.m_PassiveID = TrainHandler.Practical;
            prac.passiveIcon = ResourceLoader.LoadSprite("PracticalPassive.png");
            prac._enemyDescription = "On taking direct damage, shift one Light phase backwards. " +
                "\nOn any ability being used other than by this enemy, 50% chance to toggle the Crosswalk phase.";
            prac._characterDescription = prac._enemyDescription;
            prac.doesPassiveTriggerInformationPanel = false;
            prac.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<TrainEffect>(), -1, Slots.Self) };
            prac._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            //TROLLEY
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            InstantiateExtraAttackPassiveAbility trolley = ScriptableObject.CreateInstance<InstantiateExtraAttackPassiveAbility>();
            trolley.conditions = baseExtra.conditions;
            trolley.passiveIcon = baseExtra.passiveIcon;
            trolley.specialStoredData = baseExtra.specialStoredData;
            trolley.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
            trolley.m_PassiveID = baseExtra.m_PassiveID;
            trolley._extraAbility = new ExtraAbilityInfo();
            trolley._extraAbility.rarity = baseExtra._extraAbility.rarity;
            trolley._extraAbility.cost = baseExtra._extraAbility.cost;
            trolley._passiveName = "Trolley";
            trolley._enemyDescription = "This enemy will perforn an extra ability \"Trolley\" each turn.";
            trolley._characterDescription = baseExtra._characterDescription;
            trolley._triggerOn = baseExtra._triggerOn;
            Ability bonus = new Ability("Trolley_Problem_A");
            bonus.Name = "Trolley";
            bonus.Description = "If the Light phase is Green, deal maybe a Little or a Lot of damage to either all enemies or all party members.";
            bonus.Effects = new EffectInfo[4];
            bonus.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Train", false, TrainTargetting.Create(false)), 0, TrainTargetting.Create(true), ScriptableObject.CreateInstance<SecondTrainCondition>());
            bonus.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, TrainTargetting.Create(true));
            bonus.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 20, TrainTargetting.Create(true), ScriptableObject.CreateInstance<SecondTrainCondition>());
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<TrainSongEffect>(), 1, TrainTargetting.Create(true), ScriptableObject.CreateInstance<SecondTrainCondition>());
            bonus.Visuals = null;
            bonus.AnimationTarget = Slots.Self;
            bonus.AddIntentsToTarget(TrainTargetting.Create(true), new string[] { FallColor.Intent, IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Damage_11_15.ToString(), IntentType_GameIDs.Damage_16_20.ToString() });
            AbilitySO ability = bonus.GenerateEnemyAbility(false).ability;
            trolley._extraAbility.ability = ability;

            //ADDPASSIVES
            train.AddPassives(new BasePassiveAbilitySO[] { prac, trolley });

            //CHECK
            Ability check = new Ability("Train_Check_A")
            {
                Name = "Check",
                Description = "If the Light phase is not Green, shift the Light phase up by one.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Notif", false, Slots.Self), 1, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TrainEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_TrainUp", ResourceLoader.LoadSprite("TrainUpIntent.png"), Color.white);
            check.AddIntentsToTarget(Slots.Self, new string[] { "Misc_TrainUp" });

            //BACK
            Ability back = new Ability("Train_BackUp_A")
            {
                Name = "Back Up",
                Description = "If the Light phase is not Green, shift the Light phase down by one.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Stop", false, Slots.Self), 1, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TrainEffect>(), -1, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_TrainDown", ResourceLoader.LoadSprite("TrainDownIntent.png"), Color.white);
            back.AddIntentsToTarget(Slots.Self, new string[] { "Misc_TrainDown" });

            //FLIP
            Ability flip = new Ability("Train_Flip_A");
            flip.Name = "Flip";
            flip.Description = "If the Light phase is Green, shift the Light phase to Red and deal an Agonizing amount of damage to the Opposing party member.\nOtherwise, shift the Light phase to Green.";
            flip.Rarity = Rarity.GetCustomRarity("rarity5");
            flip.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Sign", false, Slots.Front), 1, Slots.Self, ScriptableObject.CreateInstance<SecondTrainCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, ScriptableObject.CreateInstance<SecondTrainCondition>()),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Notif", false, Slots.Self), 1, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TrainSetterEffect>(), 0, Slots.Self, ScriptableObject.CreateInstance<SecondTrainCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<TrainSetterEffect>(), 2, Slots.Self, BasicEffects.DidThat(false)),
            };
            Intents.CreateAndAddCustom_Basic_IntentToPool("Misc_TrainFlip", ResourceLoader.LoadSprite("TrainFlipIntent.png"), Color.white);
            flip.AddIntentsToTarget(Slots.Self, new string[] { "Misc_TrainFlip" });
            flip.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });

            //ADD ENEMY
            train.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                check.GenerateEnemyAbility(false),
                back.GenerateEnemyAbility(false),
                flip.GenerateEnemyAbility(false)
            });
            train.AddEnemy(true, true);
        }
    }
}
