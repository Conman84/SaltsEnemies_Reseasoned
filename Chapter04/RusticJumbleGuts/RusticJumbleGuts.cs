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
            Enemy RusticJumbleGuts = new Enemy("Rustic Jumble Guts", "RusticJumbleguts_EN")
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

            RusticJumbleGuts.enemy.enemyTemplate.m_Data.m_Renderer = RusticJumbleGuts.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("skullFront").GetComponent<SpriteRenderer>();

            RusticJumbleGuts.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_GreyJumble>();

            RusticJumbleGuts.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Transfusion, 
                Passives.Slippery, 
            });
            RusticJumbleGuts.CombatEnterEffects = Effects.GenerateEffect(RootActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMagnetismEffect>(), 1, Slots.Self).SelfArray()), 1, Slots.Self).SelfArray();

            RusticJumbleGuts.AddUnitType("Robot");

            //Melt
            Ability melt = new Ability("Melting Point", "Salt_MeltingPoint_A");
            melt.Description = "\"Deal 11 damage to the opposing enemy.\"\n(Deals a Deadly amount of damage to the Opposing party member.)";
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
            flood.Description = "Double the Pigment in the tray.";
            flood.Rarity = Rarity.GetCustomRarity("rarity5");
            flood.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<GeneratePigmentTrayEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            flood.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            flood.AnimationTarget = Targeting.Slot_SelfSlot;
            flood.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Mana_Generate"
            });

            //Dust
            Ability dust = new Ability("Dust to Dust", "Salt_DusttoDust_A");
            dust.Description = "Gain 1 Magnetism.\nIf this enemy already had Magnetism, deal a Little damage to all party members.";
            dust.Rarity = Rarity.CreateAndAddCustomRarityToPool("rustic_7", 7);
            StatusEffectCheckerEffect hasmagnet = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            hasmagnet._status = Magnetism.Object;
            dust.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(hasmagnet, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyMagnetismEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Unit_AllOpponents, BasicEffects.DidThat(true, 2))
            };
            dust.Visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            dust.AnimationTarget = Targeting.Slot_SelfSlot;
            dust.AddIntentsToTarget(Slots.Self, [Magnetism.Intent, "Misc_Hidden"]);
            dust.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Damage_1_2"]);

            //Add
            RusticJumbleGuts.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                melt.GenerateEnemyAbility(true),
                flood.GenerateEnemyAbility(true),
                dust.GenerateEnemyAbility(true),
            });
            RusticJumbleGuts.AddEnemy(true, true, false);
            RusticJumbleGuts.enemy.AddToSynodPool();
            RusticJumbleGuts.enemy.AddToToysPool();
            RusticJumbleGuts.enemy.AddToEcstasyPool();
        }
    }
}
