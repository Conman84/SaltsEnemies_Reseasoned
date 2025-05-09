using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class GlassFigurine
    {
        public static void Add()
        {
            Enemy glass = new Enemy("Glass Figurine", "GlassFigurine_EN")
            {
                Health = 17,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("GlassIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("GlassWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("GlassDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound,
            };
            glass.PrepareMultiEnemyPrefab("assets/group4/Glass/Glass_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Glass/Glass_Gibs.prefab").GetComponent<ParticleSystem>());
            (glass.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetChild(0).GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetChild(1).GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                glass.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
            };

            //DISORIENTING
            PerformEffectPassiveAbility disorient = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            disorient._passiveName = "Disorienting";
            disorient.passiveIcon = ResourceLoader.LoadSprite("DisorientingPassive.png");
            disorient.m_PassiveID = "Disorienting_PA";
            disorient._enemyDescription = "On taking direct damage, randomize all party member ability costs.";
            disorient._characterDescription = "wont work loll";
            disorient._triggerOn = [TriggerCalls.OnDirectDamaged];
            disorient.effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomizeCostsEffect>(), 1, Targeting.Unit_AllOpponents)];

            glass.AddPassives(new BasePassiveAbilitySO[] { Passives.Unstable, disorient, Passives.Obscure });

            //dreams
            Ability dreams = new Ability("Psychokinetic Dreams", "PsychokineticDreams_A");
            dreams.Description = "Deal damage to the Opposing party member equal to this enemy's missing health.";
            dreams.Rarity = Rarity.GetCustomRarity("rarity5");
            dreams.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageByMissingHealthEffect>(), 1, Slots.Front)];
            dreams.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_16_20.ToString()]);
            dreams.Visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
            dreams.AnimationTarget = Slots.Front;

            //waves
            Ability waves = new Ability("Glass Waves", "GlassWaves_A");
            waves.Description = "Produce 5 Blue pigment.";
            waves.Rarity = Rarity.CreateAndAddCustomRarityToPool("glass4", 4);
            waves.Effects = Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Blue), 5, Slots.Self).SelfArray();
            waves.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Mana_Generate.ToString().SelfArray());
            waves.Visuals = CustomVisuals.GetVisuals("Salt/Swirl");
            waves.AnimationTarget = Slots.Self;

            Ability chips = new Ability("Wood Chips", "WoodChips_A");
            chips.Description = "\"The closer to death, the closer to god\"";
            chips.Rarity = waves.Rarity;
            chips.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<WoodChipsEffect>(), 1, Targetting.AllEnemy).SelfArray();
            chips.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Other_Spawn.ToString().SelfArray());
            chips.Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;
            chips.AnimationTarget = TargettingUnitsUnderHealth.Create(9, false);

            Ability pain = new Ability("Pain Star", "PainStar_A");
            pain.Description = "\"The ocean washed open your grave\"";
            if (UnityEngine.Random.Range(0f, 1f) < 0.5f) pain.Description = "\"The ocean washed open your grave\"";
            pain.Rarity = Rarity.CreateAndAddCustomRarityToPool("glass3", 3);
            pain.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<PainStarEffect>()).SelfArray();
            pain.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);
            pain.Visuals = CustomVisuals.GetVisuals("Salt/StarBomb");
            pain.AnimationTarget = Slots.Self;

            //ADD ENEMY
            glass.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                dreams.GenerateEnemyAbility(true),
                waves.GenerateEnemyAbility(true),
                chips.GenerateEnemyAbility(true),
                pain.GenerateEnemyAbility(true)
            });
            glass.AddEnemy(true, true);
        }
    }
}
