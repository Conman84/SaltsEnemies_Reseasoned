using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Pinano
    {
        public static void Add()
        {
            Enemy pinano = new Enemy("Pinano", "Pinano_EN")
            {
                Health = 12,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("PinanoIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("PinanoWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("PinanoDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("MudLung_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("MudLung_EN").deathSound,
            };
            pinano.PrepareMultiEnemyPrefab("assets/Pinano/Pinano_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Pinano/Pinano_Gibs.prefab").GetComponent<ParticleSystem>());
            (pinano.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                pinano.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                pinano.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
            };

            //DECAY
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = PassiveType_GameIDs.Decay.ToString();
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay._enemyDescription = "On death, 40% chance to spawn a Minana.";
            decay._characterDescription = decay._enemyDescription;
            decay.doesPassiveTriggerInformationPanel = true;
            PercentageEffectorCondition p40 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            p40.triggerPercentage = 40;
            decay.conditions = new EffectorConditionSO[] { p40 };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            SpawnEnemyInSlotFromEntryStringNameEffect si = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
            si.en = "Minana_EN";
            si.trySpawnAnywhereIfFail = true;
            decay.effects = Effects.GenerateEffect(si, 0, Slots.Self).SelfArray();

            //add passives
            pinano.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, Violent.Generate(3), decay });
            pinano.UnitTypes = new List<string> { "Fish" };

            Ability burp = new Ability("Pinano_Burp_A")
            {
                Name = "Burp",
                Description = "Produce 2 Yellow Pigment.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Yellow), 2, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                AnimationTarget = Slots.Self,
            };
            burp.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Mana_Generate.ToString().SelfArray());

            //flail
            Ability flail = new Ability("Pinano_Flail_A")
            {
                Name = "Flail",
                Description = "Move to the Left or Right.\nMove the Opposing party member to the Left or Right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Priority = Priority.Slow,
                Effects = new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front)
                        },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                AnimationTarget = Slots.Self,
            };
            flail.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());
            flail.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());

            //chomp
            EnemyAbilityInfo chomp = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Chomp_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //ADD ENEMY
            pinano.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                chomp,
                burp.GenerateEnemyAbility(true),
                flail.GenerateEnemyAbility(true)
            });
            pinano.AddEnemy(true, true);
        }
    }
}
