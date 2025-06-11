using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class YellowAngel
    {
        public static void Add()
        {
            Enemy yellow = new Enemy("Yellow Angel", "YellowAngel_EN")
            {
                Health = 42,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("HarpoonIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HarpoonWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HarpoonDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noisy/YA_Hit",
                DeathSound = "event:/Hawthorne/Noisy/YA_Death",
            };
            yellow.PrepareEnemyPrefab("assets/enemie/YellowAngel_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/YellowAngel_Gibs.prefab").GetComponent<ParticleSystem>());

            //fluttery
            PerformEffectPassiveAbility flutter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            flutter._passiveName = "Fluttery";
            flutter.m_PassiveID = "Fluttery_PA";
            flutter.passiveIcon = FlutteryCondition.Icon;
            flutter._enemyDescription = "On moving, move again in the same direction.";
            flutter._characterDescription = flutter._enemyDescription;
            flutter.doesPassiveTriggerInformationPanel = false;
            flutter.effects = new EffectInfo[0];
            flutter._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };
            flutter.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<FlutteryCondition>() };

            //RUPTURE
            Connection_PerformEffectPassiveAbility rupture = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            rupture._passiveName = "Enruptured";
            rupture.passiveIcon = ResourceLoader.LoadSprite("enrupture");
            rupture.m_PassiveID = "Enruptured_PA";
            rupture._enemyDescription = "Permanently applies Ruptured to this enemy.";
            rupture._characterDescription = "Permanently applies Ruptured to this character.";
            rupture.doesPassiveTriggerInformationPanel = true;
            rupture.connectionEffects = Effects.GenerateEffect(CasterSubActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentRupturedEffect>(), 1, Slots.Self).SelfArray()), 1, Slots.Self).SelfArray();
            rupture.disconnectionEffects = new EffectInfo[0];
            rupture._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            yellow.AddPassives(new BasePassiveAbilitySO[] { flutter, rupture });
            yellow.AddUnitType("Angel");

            AbilitySelector_Yellow selector = ScriptableObject.CreateInstance<AbilitySelector_Yellow>();
            selector.NoIfCenter = ["OnSight_A", "MarkThem_A"];
            yellow.AbilitySelector = selector;

            //sight
            Ability sight = new Ability("OnSight_A")
            {
                Name = "On Sight",
                Description = "If the Far Far Left or Far Far Right party members have either manually moved or used an ability last turn, deal an Agonizing amount of damage to them and move them to the Left or Right if damage was dealt.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<OnSightEffect>(), 7, Targeting.GenerateSlotTarget(new int[]{-3, 3}, false)),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-3, 3}, false), BasicEffects.DidThat(true))
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                AnimationTarget = Targeting.GenerateSlotTarget(new int[] { -3, 3 }, false),
            };
            sight.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -3, 3 }, false), [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);

            Ability track = new Ability("TrackThePrints_A")
            {
                Name = "Track the Prints",
                Description = "Apply 0-2 Slip to every party member position. \nMove Left or Right and gain another action.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("yellow_3", 3),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<MaybeApplySlipUpToEntryEffect>(), 2, Targeting.GenerateSlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                AnimationTarget = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false),
            };
            track.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), Slip.Intent.SelfArray());
            track.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Misc.ToString()]);

            //mark
            Ability mark = new Ability("MarkThem_A")
            {
                Name = "Mark Them",
                Description = "If the Far Far Left or Far Far Right party members are Frailed, deal an Agonizing amount of damage to them.\nIf no party members have Frail, inflict 3 Frail on the highest and lowest health party members.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<MarkThemEffect>(), 10, Targeting.GenerateSlotTarget(new int[]{-3, 3}, false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, MultiTargetting.Create(Targetting.HighestEnemy, Targetting.LowestEnemy), AnyHasFrailEffectCondition.Create(false, false)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Gunshot"),
                AnimationTarget = Targeting.GenerateSlotTarget(new int[] { -3, 3 }, false),
            };
            mark.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -3, 3 }, false), IntentType_GameIDs.Damage_7_10.ToString().SelfArray());
            mark.AddIntentsToTarget(Targeting.Unit_AllOpponents, IntentType_GameIDs.Status_Frail.ToString().SelfArray());

            //ADD ENEMY
            yellow.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                sight.GenerateEnemyAbility(true),
                track.GenerateEnemyAbility(true),
                mark.GenerateEnemyAbility(true)
            });
            yellow.AddEnemy(true, true);
        }
    }
}
