using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Firebird
    {
        public static void Add()
        {
            Enemy firebird = new Enemy("The Firebird", "Firebird_EN")
            {
                Health = 35,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("FirebirdIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("FirebirdWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("FirebirdDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Firebird>()
            };
            firebird.PrepareEnemyPrefab("assets/group4/Firebird/Firebird_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Firebird/Firebird_Gibs.prefab").GetComponent<ParticleSystem>());

            //rejuvination
            RejuvinationPassiveAbility pheonix = ScriptableObject.CreateInstance<RejuvinationPassiveAbility>();
            pheonix._passiveName = "Rejuvination (4)";
            pheonix.passiveIcon = ResourceLoader.LoadSprite("rejuvination.png");
            pheonix.m_PassiveID = "Rejuvination_PA";
            pheonix._enemyDescription = "On death, if this enemy is above 4 maximum health, Resurrect it at half its maximum health.";
            pheonix._characterDescription = "idkkk mannnn";
            pheonix.doesPassiveTriggerInformationPanel = false;
            pheonix._triggerOn = new TriggerCalls[] { TriggerCalls.CanDie };

            //burning
            PerformEffectPassiveAbility burning = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            burning._passiveName = "Burning (1)";
            burning.passiveIcon = ResourceLoader.LoadSprite("burningIcon.png");
            burning.m_PassiveID = "Burning_PA";
            burning._enemyDescription = "On receiving direct damage, inflict 1 Fire on this position and the Opposing position.";
            burning._characterDescription = burning._enemyDescription;
            burning.doesPassiveTriggerInformationPanel = true;
            burning.effects = [Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, MultiTargetting.Create(Targeting.Slot_SelfAll, Slots.Front))
            }), 1, Slots.Self)];
            burning._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };

            //combative
            CombativePassiveAbility combative = ScriptableObject.CreateInstance<CombativePassiveAbility>();
            combative._turnsBeforeFleeting = 3;
            combative._passiveName = "Combative (3)";
            combative.passiveIcon = ResourceLoader.LoadSprite("CombativePassive.png");
            combative.m_PassiveID = Passives.FleetingGenerator(3).m_PassiveID;
            combative._enemyDescription = Passives.FleetingGenerator(3)._enemyDescription + "\nOn dealing or receiving damage, reset this enemy's Fleeting counter.";
            combative._characterDescription = Passives.FleetingGenerator(3)._characterDescription + "\nOn dealing or receiving damage, reset this party member's Fleeting counter.";
            combative.doesPassiveTriggerInformationPanel = Passives.FleetingGenerator(3).doesPassiveTriggerInformationPanel;
            combative.conditions = Passives.FleetingGenerator(3).conditions;
            combative._triggerOn = Passives.FleetingGenerator(3)._triggerOn;
            combative.specialStoredData = Passives.Fleeting3.specialStoredData;
            combative.fleeting_USD = "FleetingPA";

            firebird.AddPassives(new BasePassiveAbilitySO[] { pheonix, burning, combative, Passives.Skittish });
            firebird.AddUnitType("Bird");

            //singeing claws
            Ability claws = new Ability("SingeingClaws_A")
            {
                Name = "Singeing Claws",
                Description = "Deal a Painful amount of damage to the Opposing party member. Inflict Fire on the Opposing position for the amount of damage not dealt.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SingeClawsEffect>(), 5, Slots.Front),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals,
                AnimationTarget = Slots.Front,
            };
            claws.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Field_Fire.ToString()]);

            //fiery veins
            Ability veins = new Ability("Fiery Veins", "FieryVeins_A");
            veins.Description = "If this enemy is standing in fire, deal an Agonizing amount of damage to the Left and Right party members.";
            veins.Rarity = claws.Rarity;
            veins.Effects = new EffectInfo[2];
            veins.Effects[0] = Effects.GenerateEffect(BasicEffects.GetVisuals("Sear_1_A", true, Slots.LeftRight), 0, null, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.OnFire_ID.ToString(), 0, true, true));
            veins.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.LeftRight, HasFieldAmountEffectCondition.Create(StatusField_GameIDs.OnFire_ID.ToString(), 0, true, true));
            veins.AddIntentsToTarget(Targeting.Slot_SelfAll, [IntentType_GameIDs.Misc_Hidden.ToString()]);
            veins.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Damage_3_6.ToString()]);
            veins.Visuals = null;
            veins.AnimationTarget = Slots.Self;

            //flaming death
            ApplyFireSlotEffect random = ScriptableObject.CreateInstance<ApplyFireSlotEffect>();
            random._UseRandomBetweenPrevious = true;
            Ability death = new Ability("FlamingDeath_A")
            {
                Name = "Flaming Death",
                Description = "Instantly kill this enemy. Inflict 1-2 Fire on every party member position. This ability can only be selected if this enemy is below it's original health value.",
                Priority = Priority.VeryFast,
                Rarity = Rarity.CreateAndAddCustomRarityToPool("firebirdHigh", 8),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1),
                    Effects.GenerateEffect(random, 2, Targeting.GenerateSlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Ash"),
                AnimationTarget = Slots.Self,
            };
            death.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);
            death.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), [IntentType_GameIDs.Field_Fire.ToString()]);


            //ADD ENEMY
            firebird.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                claws.GenerateEnemyAbility(true),
                veins.GenerateEnemyAbility(true),
                death.GenerateEnemyAbility(true)
            });
            firebird.AddEnemy(true, true);
        }
    }
}
