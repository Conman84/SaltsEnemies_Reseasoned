using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class RusticJumbleGuts
    {
        public static void Add()
        {
            //Enemy Code
            Enemy RusticJumbleGuts = new Enemy("Rustic Jumbleguts", "RusticJumbleguts_EN")
            {
                Health = 6,
                HealthColor = Pigments.Grey,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("GJumbIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GJumbDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GJumbIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Nois2/RusticHurt",
                DeathSound = "event:/Hawthorne/Nois2/RusticDeath",
            };
            RusticJumbleGuts.PrepareEnemyPrefab("assets/greyShit/GreyGuts_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/greyShit/GreyGuts_Gibs.prefab").GetComponent<ParticleSystem>());
            RusticJumbleGuts.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_GreyJumble>();

            RusticJumbleGuts.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Dying, 
                Passives.Transfusion, 
                Passives.Slippery, 
                Passives.Pure
            });

            //Melt
            Ability melt = new Ability("Melting Point", "Salt_MeltingPoint_A");
            melt.Description = "Deal 11 damage to the opposing enemy.";
            melt.Rarity = Rarity.GetCustomRarity("rarity5");
            melt.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 11, Targeting.Slot_Front),
            };
            melt.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            melt.AnimationTarget = Targeting.Slot_Front;
            melt.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_11_15"
            });

            //Monsoon
            Ability flood = new Ability("Monsoon Season", "Salt_MonsoonSeason_A");
            flood.Description = "Increase the Lucky Pigment Percentage by 30%.";
            flood.Rarity = Rarity.GetCustomRarity("rarity5");
            flood.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<IncreaseLuckyBluePercentageEffect>(), 30, Targeting.Slot_SelfSlot),
            };
            flood.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            flood.AnimationTarget = Targeting.Slot_SelfSlot;
            flood.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc"
            });

            //Dust
            Ability dust = new Ability("Dust to Dust", "Salt_DusttoDust_A");
            dust.Description = "Deal 1 direct damage to this enemy. Give this enemy another action. Cannot be Dust to Dust.";
            dust.Rarity = Rarity.GetCustomRarity("rarity3");
            dust.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(BasicEffects.SetStoreValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(BasicEffects.SetStoreValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()), 0, Targeting.Slot_SelfSlot),
            };
            dust.Visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            dust.AnimationTarget = Targeting.Slot_SelfSlot;
            dust.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Damage_1_2",
                "Misc"
            });

            //Add
            RusticJumbleGuts.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                melt.GenerateEnemyAbility(true),
                flood.GenerateEnemyAbility(true),
                dust.GenerateEnemyAbility(true),
            });
            RusticJumbleGuts.AddEnemy(true, true, false);
        }
    }
}
