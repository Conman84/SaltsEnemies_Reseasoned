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
                Health = 25,
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
            burning.name = "Burning_1_PA";
            burning._enemyDescription = "On receiving direct damage, inflict 1 Fire on this position and the Opposing position.";
            burning._characterDescription = burning._enemyDescription;
            burning.doesPassiveTriggerInformationPanel = true;
            burning.effects = [Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, MultiTargetting.Create(Targeting.Slot_SelfAll, Slots.Front))
            }), 1, Slots.Self)];
            burning._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            burning.AddToPassiveDatabase();

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

            firebird.AddPassives(new BasePassiveAbilitySO[] { pheonix, burning, Passives.FleetingGenerator(2), Passives.Slippery, });
            firebird.AddUnitType("Bird");

            //singeing claws
            Ability claws = new Ability("SingeingClaws_A")
            {
                Name = "Singeing Claws",
                Description = "Move Left, Right, or stay in place, then inflict 3 Fire on the Opposing position.\nIf there is no Opposing party member, instantly die.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self, Effects.ChanceCondition(60)),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Talons_A", false, Slots.Front), 0, null, IsFrontTargetCondition.Create(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ash", false, Slots.Self), 0, null, IsFrontTargetCondition.Create(false)),
                    Effects.GenerateEffect(BasicEffects.Die(), 1, Slots.Self, IsFrontTargetCondition.Create(false))
                },
                Visuals = null,
                AnimationTarget = Slots.Front,
            };
            claws.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            claws.AddIntentsToTarget(Slots.Front, ["Field_Fire"]);
            claws.AddIntentsToTarget(Slots.Self, ["Damage_Death"]);

            Targeting_ByField_Side fire_enemies = ScriptableObject.CreateInstance<Targeting_ByField_Side>();
            fire_enemies.getAllies = false;
            Targeting_ByField_Side fire_allies = ScriptableObject.CreateInstance<Targeting_ByField_Side>();
            fire_allies.getAllies = true;
            Targeting_ByField_Side fire_all = ScriptableObject.CreateInstance<Targeting_ByField_Side>();
            fire_all.getAllSides = true;

            //fiery veins
            Ability veins = new Ability("Fiery Veins", "FieryVeins_A");
            veins.Description = "Deals a Painful amount of damage to all party members and enemies in Fire.\nIf any damage was dealt, instantly dies.";
            veins.Rarity = claws.Rarity;
            veins.Effects = new EffectInfo[3];
            veins.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, fire_all);
            veins.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Ash", false, Slots.Self), 0, null, ScriptableObject.CreateInstance<NoFireAnywhereCondition>());
            veins.Effects[2] = Effects.GenerateEffect(BasicEffects.Die(), 1, Slots.Self, ScriptableObject.CreateInstance<NoFireAnywhereCondition>());
            veins.AddIntentsToTarget(Targetting.Everything(false), ["Damage_3_6"]);
            veins.AddIntentsToTarget(Targetting.Everything(true), ["Damage_3_6"]);
            veins.AddIntentsToTarget(Slots.Self, ["Damage_Death"]);
            veins.Visuals = Visuals.Burn;
            veins.AnimationTarget = fire_all;

            //flaming death
            ApplyFireSlotEffect random = ScriptableObject.CreateInstance<ApplyFireSlotEffect>();
            random._UseRandomBetweenPrevious = true;
            Ability death = new Ability("FlamingDeath_A")
            {
                Name = "Flaming Death",
                Description = "Inflict 1 Fire on all party member positions.\nIf this enemy is not at full health, it instantly dies.",
                Priority = Priority.VeryFast,
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<NotAtFullHealthEffectCondition>()),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Ash"),
                AnimationTarget = Slots.Self,
            };
            death.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), [IntentType_GameIDs.Field_Fire.ToString()]);
            death.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);


            //ADD ENEMY
            firebird.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                claws.GenerateEnemyAbility(true),
                veins.GenerateEnemyAbility(true),
                death.GenerateEnemyAbility(true)
            });
            firebird.AddEnemy(true);
            firebird.enemy.AddToSynodPool();
            firebird.enemy.AddToEcstasyPool();
        }
    }
}
