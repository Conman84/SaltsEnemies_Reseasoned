using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class GreyBot
    {
        public static void Add()
        {
            Enemy grey = new Enemy("Auditory Apparatus", "GreyBot_EN")
            {
                Health = 26,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("GreyBotIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GreyBotWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GreyBotDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/ApparatusHit",
                DeathSound = "event:/Hawthorne/Noise/ApparatusDie",
            };
            grey.PrepareEnemyPrefab("assets/bot/GreyBot_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/bot/GreyBot_Gibs.prefab").GetComponent<ParticleSystem>());

            //CCTV
            PerformEffectPassiveAbility cctv = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            cctv._passiveName = "C.C.T.V.";
            cctv.passiveIcon = ResourceLoader.LoadSprite("CCTVPassive.png");
            cctv.m_PassiveID = "CCTV_PA";
            cctv._enemyDescription = "On any party member manually moving or using an ability, move 1 space closer to them.";
            cctv._characterDescription = "On any enemy moving or using an ability, move 1 space closer to them.";
            cctv.conditions = ScriptableObject.CreateInstance<CCTVCondition>().SelfArray();
            cctv.doesPassiveTriggerInformationPanel = true;
            cctv._triggerOn = new TriggerCalls[] { CCTVHandler.Trigger, JitteryHandler.Call };
            cctv.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveTowardsNearestEnemyEffect>(), 1, Slots.Self).SelfArray();

            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility cannon = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
            cannon._passiveName = "Sound Cannon";
            cannon._enemyDescription = "This enemy will perforn the extra ability \"Sound Cannon\" each turn.";
            Ability bonus = new Ability("SoundCannon_A");
            bonus.Name = "Sound Cannon";
            bonus.Description = "Deal an Deadly amount of damage to the Opposing party member.";
            bonus.Priority = Priority.VeryFast;
            bonus.Effects = new EffectInfo[2];
            bonus.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 11, Slots.Self);
            bonus.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 15, Targeting.Slot_Front);
            bonus.Visuals = CustomVisuals.GetVisuals("Salt/Cannon");
            bonus.AnimationTarget = Targeting.Slot_Front;
            bonus.AddIntentsToTarget(Targeting.Slot_Front, IntentType_GameIDs.Damage_11_15.ToString().SelfArray());
            AbilitySO ability = bonus.GenerateEnemyAbility(true).ability;
            cannon._extraAbility.ability = ability;

            grey.AddPassives(new BasePassiveAbilitySO[] { cctv, BotGeneral.Pillar, cannon });

            IsFrontTargetCondition hasFront = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
            hasFront.returnTrue = true;

            Ability huntsman = new Ability("Huntsman", "Huntsman_A");
            huntsman.Description = "Move 1 space towards the closest party member. \nIf there is an Opposing party member, inflict 1 Constricted on their position.";
            huntsman.Rarity = Rarity.GetCustomRarity("rarity5");
            huntsman.Effects = new EffectInfo[2];
            huntsman.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveTowardsNearestEnemyEffect>(), 1, Slots.Self);
            huntsman.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Front, hasFront);
            huntsman.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());
            huntsman.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Field_Constricted.ToString().SelfArray());
            huntsman.Visuals = CustomVisuals.GetVisuals("Salt/Reload");
            huntsman.AnimationTarget = Slots.Self;

            Ability rush = new Ability("Blind Rush", "BlindRush_A");
            rush.Description = "Move all the way to the Left or to the Right.";
            rush.Rarity = Rarity.GetCustomRarity("rarity5");
            rush.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<MoveAllTheWayOneSideEffect>(), 1, Slots.Self).SelfArray();
            rush.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());
            rush.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            rush.AnimationTarget = Slots.Self;

            Ability sweepers = new Ability("Sweepers", "Sweepers_A");
            sweepers.Description = "Deal a Painful amount of damage to the Opposing party member.\nMove Left or Right.";
            sweepers.Rarity = Rarity.CreateAndAddCustomRarityToPool("sweepers4", 4);
            sweepers.Priority = Priority.VeryFast;
            sweepers.Effects = new EffectInfo[2];
            sweepers.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front);
            sweepers.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            sweepers.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            sweepers.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());
            sweepers.Visuals = CustomVisuals.GetVisuals("Salt/Gunshot");
            sweepers.AnimationTarget = Slots.Front;

            //ADD ENEMY
            grey.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                huntsman.GenerateEnemyAbility(true),
                rush.GenerateEnemyAbility(true),
                sweepers.GenerateEnemyAbility(true)
            });
            grey.AddEnemy(true, true);
        }
    }
}
