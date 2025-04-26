using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class ManFish
    {
        public static void Add()
        {
            //Fishing
            UnmungPassiveAbility fishing = ScriptableObject.CreateInstance<UnmungPassiveAbility>();
            fishing._passiveName = "Fishing ";
            fishing.m_PassiveID = "Fishing_PA";
            fishing.passiveIcon = ResourceLoader.LoadSprite("Fishing.png");
            fishing._characterDescription = "Upon taking direct damage, spawn a \"Fish.\" The weight of the fish spawned increases upon taking more damage.";
            fishing._enemyDescription = "Upon taking direct damage, spawn a \"Fish.\" The weight of the fish spawned increases upon taking more damage.";
            fishing.doesPassiveTriggerInformationPanel = false;
            fishing._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Fishing.png"), "Fishing", fishing._enemyDescription);

            //Enemy Code
            Enemy ManFish = new Enemy("Teach a Man to Fish", "TeachaMantoFish_EN")
            {
                Health = 20,
                HealthColor = Pigments.Purple,
                Priority = BrutalAPI.Priority.CreateAndAddCustomPriorityToPool("priority-1", -1),
                CombatSprite = ResourceLoader.LoadSprite("ManFishIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ManFishDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ManFishIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Nowak_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Nowak_CH").deathSound,
            };
            ManFish.PrepareEnemyPrefab("assets/Senis2/Fish_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis2/Fish_Gibs.prefab").GetComponent<ParticleSystem>());
            
            ManFish.AddPassives(new BasePassiveAbilitySO[]
            {
                fishing
            });
            ManFish.UnitTypes = new List<string>()
            {
                "Fish"
            };

            //Slap
            Ability slap = new Ability("Slap", "Salt_Slap_A");
            slap.Description = "Deal 1 damage to the opposing party member.";
            slap.Rarity = Rarity.GetCustomRarity("rarity8");
            slap.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_Front),
            };
            slap.Visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            slap.AnimationTarget = Targeting.Slot_Front;
            slap.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_1_2"
            });

            //Nibble
            Ability nibble = new Ability("Nibble", "Salt_Nibble_A");
            nibble.Description = "Deals a little bit of damage to the opposing party member.";
            nibble.Rarity = Rarity.GetCustomRarity("rarity5");
            nibble.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_Front),
            };
            nibble.Visuals = LoadedAssetsHandler.GetEnemyAbility("Nibble_A").visuals;
            nibble.AnimationTarget = Targeting.Slot_Front;
            nibble.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_1_2"
            });

            //Weep
            GenerateColorManaEffect blueMana = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            blueMana.mana = Pigments.Blue;

            Ability weep = new Ability("Weep", "Salt_Weep_A");
            weep.Description = "Produces 3 Blue Pigment.";
            weep.Rarity = Rarity.GetCustomRarity("rarity5");
            weep.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(blueMana, 3, Targeting.Slot_SelfSlot),
            };
            weep.Visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            weep.AnimationTarget = Targeting.Slot_SelfSlot;
            weep.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Mana_Generate"
            });

            //Agony
            Ability agony = new Ability("Blissful Agony", "Salt_BlissfulAgony_A");
            agony.Description = "Clumsily deals a little of damage to this enemy. Inflicts 1 scar to this enemy.";
            agony.Rarity = Rarity.GetCustomRarity("rarity6");
            agony.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            agony.Visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals;
            agony.AnimationTarget = Targeting.Slot_SelfSlot;
            agony.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Damage_1_2",
                "Status_Scars",
            });

            //Add
            ManFish.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                slap.GenerateEnemyAbility(true),
                nibble.GenerateEnemyAbility(true),
                weep.GenerateEnemyAbility(true),
                agony.GenerateEnemyAbility(true)
            });
            ManFish.AddEnemy(true, true, false);
        }
    }
}
