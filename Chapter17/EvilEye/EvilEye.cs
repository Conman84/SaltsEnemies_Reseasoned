using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltEnemies_Reseasoned.SendingOver17;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Evileye
    {
        public static void Add()
        {
            Enemy evileye = new Enemy("Evileye", "Evileye_EN")
            {
                Health = 30,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("EyeballIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("EyeballWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("EyeballDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noisy/Eye_Hit",
                DeathSound = "event:/Hawthorne/Noisy/Eye_Die",
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_EvilEye>()
            };
            evileye.PrepareEnemyPrefab("assets/enemie/Eyeball_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("assets/giblets/Eyeball_Gibs.prefab").GetComponent<ParticleSystem>());

            //jumpy
            PerformEffectPassiveAbility jumpy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jumpy._passiveName = "Jumpy";
            jumpy.m_PassiveID = "Jumpy_PA";
            jumpy.passiveIcon = ResourceLoader.LoadSprite("Jumpy.png");
            jumpy._characterDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
            jumpy._enemyDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
            jumpy.doesPassiveTriggerInformationPanel = true;
            jumpy.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
            };
            jumpy._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged, TriggerCalls.OnAbilityUsed };

            //cyclical
            PerformEffectPassiveAbility cyclical = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            cyclical._passiveName = "Cyclical";
            cyclical.m_PassiveID = "Cyclical_PA";
            cyclical.passiveIcon = ResourceLoader.LoadSprite("CyclicalPassive.png");
            cyclical._enemyDescription = "This enemy performs all of its abilities in numeric order.";
            cyclical._characterDescription = "Does nothing.";
            cyclical.doesPassiveTriggerInformationPanel = false;
            cyclical.effects = [];
            cyclical._triggerOn = [TriggerCalls.Count];

            //addpassives
            evileye.AddPassives(new BasePassiveAbilitySO[] { Passives.Leaky1, jumpy, cyclical });

            //ONE
            GenericTargetting_BySlot_Index targetOne = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            targetOne.getAllies = false;
            targetOne.slotPointerDirections = new int[] { 4 };
            Ability eyeOne = new Ability("SlaughterOne_A")
            {
                Name = "Slaughter One",
                Description = "Deal a Painful amount of damage to the Rightmost position. Gain 2 Power.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, targetOne),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                AnimationTarget = targetOne,
            };
            eyeOne.AddIntentsToTarget(targetOne, ["Damage_3_6"]);
            eyeOne.AddIntentsToTarget(Slots.Self, [Power.Intent]);

            //TWO
            GenericTargetting_BySlot_Index targetTwo = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            targetTwo.getAllies = false;
            targetTwo.slotPointerDirections = new int[] { 3 };
            Ability eyeTwo = new Ability("SlaughterTwo_A")
            {
                Name = "Slaughter Two",
                Description = "Deal a Painful amount of damage to the Center Right position. Gain 2 Power.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, targetTwo),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                AnimationTarget = targetTwo,
            };
            eyeTwo.AddIntentsToTarget(targetTwo, ["Damage_3_6"]);
            eyeTwo.AddIntentsToTarget(Slots.Self, [Power.Intent]);

            //THREE
            GenericTargetting_BySlot_Index targetThree = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            targetThree.getAllies = false;
            targetThree.slotPointerDirections = new int[] { 2 };
            Ability eyeThree = new Ability("SlaughterThree_A")
            {
                Name = "Slaughter Three",
                Description = "Deal a Painful amount of damage to the Central position. Gain 2 Power.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, targetThree),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                AnimationTarget = targetThree,
            };
            eyeThree.AddIntentsToTarget(targetThree, ["Damage_3_6"]);
            eyeThree.AddIntentsToTarget(Slots.Self, [Power.Intent]);

            //FOUR
            GenericTargetting_BySlot_Index targetFour = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            targetFour.getAllies = false;
            targetFour.slotPointerDirections = new int[] { 1 };
            Ability eyeFour = new Ability("SlaughterFour_A")
            {
                Name = "Slaughter Four",
                Description = "Deal a Painful amount of damage to the Center Left position. Gain 2 Power.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, targetFour),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                AnimationTarget = targetFour,
            };
            eyeFour.AddIntentsToTarget(targetFour, ["Damage_3_6"]);
            eyeFour.AddIntentsToTarget(Slots.Self, [Power.Intent]);

            //FIVE
            GenericTargetting_BySlot_Index targetFive = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            targetFive.getAllies = false;
            targetFive.slotPointerDirections = new int[] { 0 };
            Ability eyeFive = new Ability("SlaughterFive_A")
            {
                Name = "Slaughter Five",
                Description = "Deal a Painful amount of damage to the Leftmost position. Gain 2 Power.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, targetFive),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, Slots.Self),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                AnimationTarget = targetFive,
            };
            eyeFive.AddIntentsToTarget(targetFive, ["Damage_3_6"]);
            eyeFive.AddIntentsToTarget(Slots.Self, [Power.Intent]);

            //ADD ENEMY
            evileye.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                eyeOne.GenerateEnemyAbility(true),
                eyeTwo.GenerateEnemyAbility(true),
                eyeThree.GenerateEnemyAbility(true),
                eyeFour.GenerateEnemyAbility(true),
                eyeFive.GenerateEnemyAbility(true)
            });
            evileye.AddEnemy(true, true);
        }
    }
}
