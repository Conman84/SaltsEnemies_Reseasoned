using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Postmodern
    {
        public static void Add()
        {
            NoiseHandler.Setup();
            PostmodernHandler.Setup();

            Enemy postmodern = new Enemy("Postmodern", "Postmodern_EN")
            {
                Health = 10000,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("PostmodernIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PostmodernWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PostmodernDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Hurt/PhoneSound",
                DeathSound = LoadedAssetsHandler.GetCharacter("Rags_CH").deathSound,
            };
            postmodern.PrepareEnemyPrefab("assets/group4/Postmodern/Postmodern_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Postmodern/Postmodern_Gibs.prefab").GetComponent<ParticleSystem>());

            postmodern.AddUnitType("FemaleID");
            postmodern.AddLootData(new EnemyLootItemProbability[]
            {
                new EnemyLootItemProbability() { isItemTreasure = true, amount = 1, probability = 100 },
                new EnemyLootItemProbability() { isItemTreasure = false, amount = 2, probability = 100 }
            });

            //passive
            Debug.LogError("make sure these are the right passive sprites");
            PostModernPassiveAbility passive = ScriptableObject.CreateInstance<PostModernPassiveAbility>();
            passive._passiveName = "Post-Modern";
            passive.passiveIcon = ResourceLoader.LoadSprite("PostmodernPassive.png");
            passive.m_PassiveID = "PostModern_PA";
            passive._enemyDescription = "All damage this enemy receives is set to 999.";
            passive._characterDescription = "why two kay";
            passive.doesPassiveTriggerInformationPanel = false;
            passive._triggerOn = new TriggerCalls[]
            {
                TriggerCalls.OnBeingDamaged
            };
            passive.DoScreenFuck = false;

            //parental
            TargetStoredValueChangeEffect incNoise = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            incNoise._valueName = NoiseHandler.Noise;
            ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
            ParentalPassiveAbility pathetic = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
            pathetic._passiveName = "Parental";
            pathetic._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Pathetic Cry\" in retribution.";
            Ability parental = new Ability("Postmodern_Cry_A");
            parental.Name = "Pathetic Cry";
            parental.Description = "Increase Noise on all party members by 1.";
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;
            parental.Effects = new EffectInfo[1];
            parental.Effects[0] = Effects.GenerateEffect(incNoise, 1, allEnemy);
            parental.AddIntentsToTarget(allEnemy, new string[] { IntentType_GameIDs.Misc.ToString() });
            parental.Visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            parental.AnimationTarget = allEnemy;
            AbilitySO ability = parental.GenerateEnemyAbility(true).ability;
            pathetic._parentalAbility.ability = ability;

            //LOCK IN
            LockedInHandler.Setup();
            LockedInPassiveAbility lockedIn = ScriptableObject.CreateInstance<LockedInPassiveAbility>();
            lockedIn._passiveName = "Locked In";
            lockedIn.passiveIcon = ResourceLoader.LoadSprite("NoMenu.png");
            lockedIn._enemyDescription = "The Pause Menu can no longer be accessed.";
            lockedIn._characterDescription = "The Pause Menu can no longer be accessed.";
            lockedIn.m_PassiveID = "NoPause_PA";
            lockedIn.doesPassiveTriggerInformationPanel = false;
            lockedIn._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            //addpassives
            postmodern.AddPassives(new BasePassiveAbilitySO[] { passive, Passives.Infantile, pathetic, lockedIn });

            //SPRAY BLOOD
            Ability spray = new Ability("Spray_Blood_A")
            {
                Name = "Spray Blood",
                Description = "Deal a Painful amount of damage to the Left and Right party members. Increase Noise on the Opposing party member by 2.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentSides),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>(), 2, Targeting.Slot_Front)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Censor"),
                AnimationTarget = Targeting.Slot_OpponentSides,
            };
            spray.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            spray.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString() });

            //SPLIT BLOOD
            Ability split = new Ability("Split_Blood_A")
            {
                Name = "Split Blood",
                Description = "Move this enemy to the left or right, then increase the Noise on the Left and Right party members by 3.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("InhumanRoar_A", false, Targeting.Slot_OpponentSides), 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>(), 3, Targeting.Slot_OpponentSides)
                },
                Visuals = null,
                AnimationTarget = Targeting.Slot_SelfSlot,
            };
            split.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            split.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Misc.ToString() });

            //SPLATTER BLOOD
            Ability splatter = new Ability("Splatter_Blood_A")
            {
                Name = "Splatter Blood",
                Description = "Inflict 2 Ruptured on the Left, Right, and Opposing party members and increase their Noise by 1. Move this enemy to the left or right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targeting.Slot_FrontAndSides),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>(), 1, Targeting.Slot_FrontAndSides),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Class"),
                AnimationTarget = Targeting.Slot_FrontAndSides,
            };
            splatter.AddIntentsToTarget(Targeting.Slot_FrontAndSides, new string[] { IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Misc.ToString() });
            splatter.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });

            //ADDENEMY
            postmodern.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                spray.GenerateEnemyAbility(true),
                split.GenerateEnemyAbility(true),
                splatter.GenerateEnemyAbility(true),
            });
            postmodern.AddEnemy(true);
        }
    }
}
