using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Shua
    {
        public static void Add()
        {
            Enemy shua = new Enemy("Shua", "Shua_EN")
            {
                Health = 28,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ShuaIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ShuaWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ShuaDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Shua>()
            };
            shua.PrepareEnemyPrefab("assets/group4/Shua/Shua_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Shua/Shua_Gibs.prefab").GetComponent<ParticleSystem>());

            //INCOMPREHENSIBLE
            PerformEffectPassiveAbility incomprehend = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            incomprehend._passiveName = "Incomprehensible";
            incomprehend.passiveIcon = ResourceLoader.LoadSprite("Incomprehensible.png");
            incomprehend.m_PassiveID = "Incomprehensible_PA";
            incomprehend._enemyDescription = "When a party member moves in front of this enemy, inflict 1 Muted on them.";
            incomprehend._characterDescription = "When an enemy moves in front of this party member, inflict 1 Muted on them.";
            incomprehend.doesPassiveTriggerInformationPanel = true;
            incomprehend.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, Slots.Front).SelfArray();
            incomprehend._triggerOn = new TriggerCalls[1] { (TriggerCalls)AmbushManager.Patiently };

            //combative
            CombativePassiveAbility combative = ScriptableObject.CreateInstance<CombativePassiveAbility>();
            combative._turnsBeforeFleeting = 4;
            combative._passiveName = "Combative (4)";
            combative.passiveIcon = ResourceLoader.LoadSprite("CombativePassive.png");
            combative.m_PassiveID = Passives.Fleeting4.m_PassiveID;
            combative._enemyDescription = Passives.Fleeting4._enemyDescription + "\nOn receiving any damage, reset this enemy's Fleeting counter.";
            combative._characterDescription = Passives.Fleeting4._characterDescription + "\nOn receiving any damage, reset this party member's Fleeting counter.";
            combative.doesPassiveTriggerInformationPanel = Passives.Fleeting4.doesPassiveTriggerInformationPanel;
            combative.conditions = Passives.Fleeting4.conditions;
            combative._triggerOn = Passives.Fleeting4._triggerOn;

            //add pasives
            shua.AddPassives(new BasePassiveAbilitySO[] { incomprehend, combative });
            shua.UnitTypes = new List<string> { "FemaleID" };

            //whisper
            Ability whisper = new Ability("Whisperings_A")
            {
                Name = "Whisperings",
                Description = "Apply 1 Constricted on the Opposing party member position. Deal a Painful amount of damage to the Opposing party member.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Front),
                            Effects.GenerateEffect(BasicEffects.PlaySound("event:/Combat/StatusEffects/SE_Cursed_Apl"), 1, Slots.Front),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front),
                        },
                Visuals = CustomVisuals.GetVisuals("Salt/Whisper"),
                AnimationTarget = Slots.Self,
            };
            whisper.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Damage_3_6.ToString()]);

            //wanderlust
            Ability wander = new Ability("Wanderlust_A")
            {
                Name = "Wanderlust",
                Description = "Deal a Painful amount of damage to the Opposing party member. If there is no Opposing party member, give this enemy another action and move to the Left or Right, this ability cannot give this enemy \"Wanderlust\" again.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, Slots.Front),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Door", false, Slots.Front), 1, Slots.Front, BasicEffects.DidThat(true)),
                            Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Door", false, Slots.Self), 1, Slots.Front, BasicEffects.DidThat(false, 2)),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front),
                            Effects.GenerateEffect(BasicEffects.SetStoreValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsFrontTargetCondition>()),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self, BasicEffects.DidThat(true)),
                            Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(BasicEffects.SetStoreValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()), 0, Slots.Self),
                            }), 1, Slots.Self)
                        },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            wander.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            wander.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Swap_Sides.ToString()]);

            //waver
            EffectSO ads = BasicEffects.GetVisuals("Salt/Censor", false, Slots.Front);
            IsFrontTargetCondition yeah = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
            yeah.returnTrue = true;
            Ability waver = new Ability("Waver_A")
            {
                Name = "Waver",
                Description = "Move the Opposing party member to the Left or Right. Repeat this.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front),
                            Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                            {
                                Effects.GenerateEffect(ads, 1, Slots.Front, yeah),
                                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front),
                            }), 1, Slots.Front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Censor"),
                AnimationTarget = Slots.Front,
            };
            waver.AddIntentsToTarget(Slots.Front, ["Swap_Sides", "Swap_Sides"]);

            //ADD ENEMY
            shua.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                whisper.GenerateEnemyAbility(true),
                wander.GenerateEnemyAbility(true),
                waver.GenerateEnemyAbility(true)
            });
            shua.AddEnemy(true, true);
        }
    }
}
