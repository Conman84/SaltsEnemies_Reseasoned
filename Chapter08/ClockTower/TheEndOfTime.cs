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
            

            //ADDPASSIVES
            clock.AddPassives(new BasePassiveAbilitySO[] { Passives.OverexertGenerator(12), acceleration });

            EffectTargetsByManualUseEffect abilities = ScriptableObject.CreateInstance<EffectTargetsByManualUseEffect>();
            abilities.RunEffect = ScriptableObject.CreateInstance<ApplyEntropyEffect>();
            abilities.check_ability = true;
            abilities.damage_if_used = false;

            EffectTargetsByManualUseEffect movement = ScriptableObject.CreateInstance<EffectTargetsByManualUseEffect>();
            movement.RunEffect = ScriptableObject.CreateInstance<ApplyEntropyEffect>();
            movement.check_swap = true;
            movement.damage_if_used = false;

            Ability cbt = new Ability("Cognitive Behavioral Therapy", "Salt_CBT_A");
            cbt.Description = "Inflict 6 Entropy on all party members that did not manually use an ability this turn.\nIf unsuccessful, gain 12 Entropy.\nGenerate 3 Red Pigment.";
            cbt.Rarity = Rarity.GetCustomRarity("rarity5");
            cbt.Effects = [
                Effects.GenerateEffect(abilities, 6, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 12, Slots.Self, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 3)
                ];
            cbt.AddIntentsToTarget(Targeting.Unit_AllOpponents, [IntentType_GameIDs.Other_Refresh.ToString(), Entropy.Intent]);
            cbt.AddIntentsToTarget(Slots.Self, [Entropy.Intent, "Mana_Generate"]);
            cbt.Visuals = Visuals.Scales;
            cbt.AnimationTarget = Slots.Self;

            Ability prb = new Ability("Physical Rehabilitation Therapy", "Salt_PRB_A");
            prb.Description = "Inflict 6 Entropy on all party members that did not manually use their movement this turn.\nIf unsuccessful, gain 12 Entropy.\nGenerate 3 Red Pigment.";
            prb.Rarity = Rarity.GetCustomRarity("rarity5");
            prb.Effects = [
                Effects.GenerateEffect(movement, 6, Targeting.Unit_AllOpponents),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 12, Slots.Self, BasicEffects.DidThat(false)),
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 3)
                ];
            prb.AddIntentsToTarget(Targeting.Unit_AllOpponents, [IntentType_GameIDs.Swap_Mass.ToString(), Entropy.Intent]);
            prb.AddIntentsToTarget(Slots.Self, [Entropy.Intent, "Mana_Generate"]);
            prb.Visuals = Visuals.Scales;
            prb.AnimationTarget = Slots.Self;

            TargettingByStatusEffect has_entropy = ScriptableObject.CreateInstance<TargettingByStatusEffect>();
            has_entropy.HasStatus = true;
            has_entropy.Type = Entropy.StatusID;
            has_entropy.origin = Targeting.Unit_AllOpponents;

            Ability teb = new Ability("Trauma Exposure Therapy", "Salt_TEB_A");
            teb.Description = "Inflict 12 Entropy on the Opposing party member.\nIf there is no Opposing party member, inflict 6 Entropy on all party members with Entropy.\nGain 12 Entropy.";
            teb.Rarity = Rarity.CreateAndAddCustomRarityToPool("clock_low", 3);
            teb.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 12, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 6, has_entropy, IsFrontTargetCondition.Create(false)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 12, Slots.Self),
                ];
            teb.AddIntentsToTarget(Slots.Front, [Entropy.Intent]);
            teb.AddIntentsToTarget(Targeting.Unit_AllOpponents, [Entropy.Intent]);
            teb.AddIntentsToTarget(Slots.Self, [Entropy.Intent]);
            teb.Visuals = Visuals.Womb;
            teb.AnimationTarget = Slots.Front;


            //ADD ENEMY
            clock.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                cbt.GenerateEnemyAbility(true),
                prb.GenerateEnemyAbility(true),
                teb.GenerateEnemyAbility(true)
            });
            clock.AddEnemy(true, true);
            clock.enemy.AddToSynodPool();
        }
    }
}
