using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class AbyssAngel
    {
        public static void Add()
        {
            Enemy template = new Enemy("Abyss Angel", "Clione_EN")
            {
                Health = 20,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("ClioneIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ClioneWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ClioneDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound,
            };
            template.PrepareEnemyPrefab("assets/group4/Clione/Clione_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Clione/Clione_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectPassiveAbility waves = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            waves._passiveName = "Waves";
            waves.m_PassiveID = "Waves_PA";
            waves.passiveIcon = ResourceLoader.LoadSprite("WavesPassive.png");
            waves._enemyDescription = "On moving, inflict 2 Deep Water on the Opposing position.";
            waves._characterDescription = waves._enemyDescription;
            waves.doesPassiveTriggerInformationPanel = true;
            waves.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 2, Slots.Front).SelfArray();
            waves._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, waves });

            Ability underwater = new Ability()
            {
                Name = "Hold Me Underwater",
                Description = "Inflict 2 Constricted and 3 Deep Water on the Opposing position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, IntentType.Field_Constricted, Slots.Front),
                    new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 3, CustomIntentIconSystem.GetIntent("Water"), Slots.Front)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                AnimationTarget = Slots.Front,
            };

            Ability test = new Ability("Test_A");

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                test.GenerateEnemyAbility(true),
            });
            template.AddEnemy(true, true);
        }
    }
}
