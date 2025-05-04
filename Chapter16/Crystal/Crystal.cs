using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Crystal
    {
        public static void Add()
        {
            Enemy crystal = new Enemy("Crystaline Corpse Eater", "Crystal_EN")
            {
                Health = 35,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("CrystalIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CrystalWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CrystalDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noise/CrystalHit",
                DeathSound = "event:/Hawthorne/Noise/CrystalDie",
            };
            crystal.PrepareEnemyPrefab("assets/16/Crystal_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/16/Crystal_Gibs.prefab").GetComponent<ParticleSystem>());

            //SWEETS
            PerformEffectPassiveAbility tooth = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            tooth._passiveName = "Sweet Tooth";
            tooth.m_PassiveID = "SweethTooth_PA";
            tooth.passiveIcon = ResourceLoader.LoadSprite("SweetTooth.png");
            tooth._enemyDescription = "On dealing damage, gain an equivalent amount of Power.";
            tooth._characterDescription = tooth._enemyDescription;
            tooth.doesPassiveTriggerInformationPanel = true;
            tooth.effects = new EffectInfo[0];
            tooth._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDidApplyDamage };
            tooth.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<PowerByDamageCondition>() };

            //decay
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = PassiveType_GameIDs.Decay.ToString();
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay._enemyDescription = "On death, spawn a Candy Stone.\nTransfer all Power from this enemy to the Candy Stone.";
            decay._characterDescription = decay._enemyDescription;
            decay.doesPassiveTriggerInformationPanel = true;
            decay.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<CrystalDecayCondition>() };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            decay.effects = new EffectInfo[0];

            //ppassive
            crystal.AddPassives(new BasePassiveAbilitySO[] { tooth, Passives.Slippery, Passives.Forgetful, decay });

            //mar
            Ability mar = new Ability("CrystalMar_A")
            {
                Name = "Mar",
                Description = "Deal a barely Painful amount of damage to the Left and Right party members. \nIf either attack misses, gain 1 Scar per missed attack.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageScarIfMissEffect>(), 3, Slots.LeftRight),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals,
                AnimationTarget = Slots.LeftRight,
            };
            mar.AddIntentsToTarget(Slots.LeftRight, [IntentType_GameIDs.Damage_3_6.ToString()]);
            mar.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Status_Scars.ToString()]);

            //torture
            Ability torture = new Ability("CrystalTorture_A")
            {
                Name = "Torture",
                Description = "Deal a Little damage to this enemy twice. Consume 3 random pigment.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("crystal10", 10),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 3, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals,
                AnimationTarget = Slots.Self,
            };
            torture.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Mana_Consume.ToString() });

            //overbite
            Ability overbite = new Ability("CrystalOverbite_A")
            {
                Name = "Overbite",
                Description = "Deal a Barely Painful amount of damage to the Opposing party member. If damage is not dealt, deal it to this enemy instead.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("crystal12", 12),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Self, BasicEffects.DidThat(false)),
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals,
                AnimationTarget = Slots.Front,
            };
            overbite.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_3_6.ToString()]);
            overbite.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_3_6.ToString()]);

            //sugar
            Ability sugar = new Ability("ShardOfSugar_A")
            {
                Name = "Shard of Sugar",
                Description = "Deal a Barely Painful amount of damage to this enemy and add Violent (1) as a passive to this enemy.\nRemove this ability from this enemy.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("crystal1", 1),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.AddPassive(Violent.Generate(1)), 1, Slots.Self),
                },
                Visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals,
                AnimationTarget = Slots.Self,
            };
            Intents.CreateAndAddCustom_Basic_IntentToPool("Violent_PA", Violent.Generate(1).passiveIcon, Color.white);
            sugar.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_3_6.ToString(), "Violent_PA"]);

            ExtraAbilityInfo shard = new ExtraAbilityInfo();
            shard.ability = sugar.GenerateEnemyAbility(true).ability;
            shard.rarity = sugar.Rarity;
            CasterExtraAbilityEffect addSugar = ScriptableObject.CreateInstance<CasterExtraAbilityEffect>();
            addSugar._extraAbility = shard;
            addSugar._removeExtraAbility = false;
            CasterExtraAbilityEffect removeSugar = ScriptableObject.CreateInstance<CasterExtraAbilityEffect>();
            removeSugar._extraAbility = shard;
            removeSugar._removeExtraAbility = true;
            shard.ability.effects = new List<EffectInfo>(shard.ability.effects) { Effects.GenerateEffect(removeSugar) }.ToArray();

            //entereffect
            crystal.CombatEnterEffects = [Effects.GenerateEffect(addSugar)];

            //ADD ENEMY
            crystal.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                mar.GenerateEnemyAbility(true),
                torture.GenerateEnemyAbility(true),
                overbite.GenerateEnemyAbility(true),
            });
            crystal.AddEnemy(true, true);
        }
    }
}
