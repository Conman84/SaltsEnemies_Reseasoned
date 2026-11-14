using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Melder
    {
        public static void Add()
        {
            Enemy melder = new Enemy("Melder", "Melder_EN")
            {
                Health = 30,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("MelderIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("MelderWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("MelderDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Snound1/MelderHit",
                DeathSound = "event:/Hawthorne/Snound1/MelderDie",
                UnitTypes = ["Alien"]
            };
            melder.PrepareEnemyPrefab("Assets/ch_26/Melder_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/ch_26/Melder_Gibs.prefab").GetComponent<ParticleSystem>());

            //melder text
            UnitStoreData_MelderTargetSO target = ScriptableObject.CreateInstance<UnitStoreData_MelderTargetSO>();
            target._UnitStoreDataID = "Melded_PA";
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey("Melded_PA"))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool["Melded_PA"] = target;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(target._UnitStoreDataID, target);

            //JITERRY
            PerformEffectPassiveAbility jitter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jitter._passiveName = "Jittery";
            jitter.m_PassiveID = "Jittery_PA";
            jitter.passiveIcon = ResourceLoader.LoadSprite("JitteryPassive.png");
            jitter._enemyDescription = "On any party member manually moving, move to the Left or Right.";
            jitter._characterDescription = jitter._enemyDescription;
            jitter.doesPassiveTriggerInformationPanel = true;
            jitter.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self).SelfArray();
            jitter._triggerOn = new TriggerCalls[] { JitteryHandler.Call };
            jitter.conditions = new EffectorConditionSO[0];

            melder.AddPassives(new BasePassiveAbilitySO[] { Passives.Fleeting3, Passives.Forgetful, jitter });


            Intents.CreateAndAddCustom_Basic_IntentToPool("Melded_PA", ResourceLoader.LoadSprite("MeldedPassive.png"), Color.white);

            //drama
            Ability drama = new Ability("Melder_Dramaturgy_A")
            {
                Name = "Dramaturgy",
                Description = "If the Opposing party member has the least maximum health between them and the Left and Right party members, Meld with them.\nOtherwise, shuffle the Left, Right, and Opposing party member positions.",
                Rarity = Rarity.Common,
                Priority = Priority.Slow,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FrontIsWeakestOfTargetsEffect>(), 1, Slots.FrontLeftRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterMeldTargetEffect>(), 1, Slots.Front, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Slots.FrontLeftRight, BasicEffects.DidThat(false))
                },
                Visuals = Visuals.Bellow,
                AnimationTarget = Slots.Front,
            };
            drama.AddIntentsToTarget(Slots.FrontLeftRight, ["Misc_Hidden"]);
            drama.AddIntentsToTarget(Slots.Front, ["Melded_PA"]);
            drama.AddIntentsToTarget(Slots.FrontLeftRight, [IntentType_GameIDs.Swap_Mass.ToString()]);
            drama.AddIntentsToTarget(Slots.Self, ["Damage_3_6"]);

            CheckPassiveAbilityEffect melding = ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>();
            melding.m_PassiveID = "Melded_PA";


            //metal
            Ability metal = new Ability("Melder_Metallurgy_A")
            {
                Name = "Metallurgy",
                Description = "If this enemy is not Melded with any targets, reset it's Fleeting.\nDeal an Agonizing amount of damage to the Opposing party member if they are at full health.\nTake a Painful amount of damage.",
                Rarity = Rarity.Rare,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(melding, 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetFleetingEffect>(), 0, Slots.Self, BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Purify_1_A", true, Slots.Front)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FullHealthDamageEffect>(), 8, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Self),
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            metal.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.PA_Fleeting.ToString()]);
            metal.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_7_10"]);

            

            //thauma
            Ability thauma = new Ability("Melder_Thaumaturgy_A")
            {
                Name = "Thaumaturgy",
                Description = "If this enemy is not Melded with any targets, reset it's Fleeting.\nAll enemies generate 1 Red Pigment.\nReduce the maximum healths of the Left, Right, and Opposing party members to their current healths.",
                Rarity = Rarity.Uncommon,
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(melding, 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetFleetingEffect>(), 0, Slots.Self, BasicEffects.DidThat(false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetGeneratePigmentEffect>(), 1, Targeting.Unit_AllAllies),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ribbon", false, Slots.FrontLeftRight)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<MaxToCurrentEffect>(), 0, Slots.FrontLeftRight)
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            thauma.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.PA_Fleeting.ToString()]);
            thauma.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Mana_Generate"]);
            thauma.AddIntentsToTarget(Slots.FrontLeftRight, [IntentType_GameIDs.Other_MaxHealth.ToString()]);

            melder.CombatExitEffects = [Effects.GenerateEffect(BasicEffects.SetStoreValue("Melded_PA"), 0, Slots.Self)];

            //ADD ENEMY
            melder.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                drama.GenerateEnemyAbility(true),
                metal.GenerateEnemyAbility(true),
                thauma.GenerateEnemyAbility(true),
            });
            melder.SilentAddEnemy(true, true);//SILENT!!
            melder.enemy.AddToToysPool();
            melder.enemy.AddToEcstasyPool();
        }
    }
}
