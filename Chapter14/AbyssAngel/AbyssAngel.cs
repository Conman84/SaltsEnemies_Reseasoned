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
            Enemy cliome = new Enemy("Abyss Angel", "Clione_EN")
            {
                Health = 20,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("ClioneIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ClioneWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ClioneDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound,
            };
            cliome.PrepareEnemyPrefab("assets/group4/Clione/Clione_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Clione/Clione_Gibs.prefab").GetComponent<ParticleSystem>());

            PerformEffectPassiveAbility waves = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            waves._passiveName = "Waves (2)";
            waves.m_PassiveID = "Waves_PA";
            waves.passiveIcon = ResourceLoader.LoadSprite("WavesPassive.png");
            waves._enemyDescription = "On moving, inflict 2 Deep Water on the Opposing position.";
            waves._characterDescription = waves._enemyDescription;
            waves.doesPassiveTriggerInformationPanel = true;
            waves.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 2, Slots.Front).SelfArray();
            waves._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };

            cliome.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, waves });
            cliome.UnitTypes = new List<string> { "Fish", "Angel" };

            Ability underwater = new Ability("HoldMeUnderwater_A")
            {
                Name = "Hold Me Underwater",
                Description = "Inflict 2 Constricted and 3 Deep Water on the Opposing position.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 3, Slots.Front)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                AnimationTarget = Slots.Front,
            };
            underwater.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Field_Constricted.ToString(), Water.Intent]);

            Ability love = new Ability("LostWithoutYourLove_A")
            {
                Name = "Lost without Your Love",
                Description = "Inflict 4 Deep Water on the Opposing position. \nIf there is no Opposing party member, move to the Left or Right, then apply 3 Deep Water on self.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<IsUnitEffect>(), 0, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Mend_1_A", true, Slots.Front), 2, Slots.Front, BasicEffects.DidThat(true)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 4, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1,  Slots.Self, BasicEffects.DidThat(false, 3)),
                    Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Wheel", true, Slots.Self), 2, Slots.Self, BasicEffects.DidThat(false, 4)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 3, Slots.Self, BasicEffects.DidThat(false, 5))
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            love.AddIntentsToTarget(Slots.Front, [Water.Intent, IntentType_GameIDs.Misc_Hidden.ToString()]);
            love.AddIntentsToTarget(Slots.Self, ["Swap_Sides", Water.Intent]);

            Ability tail = new Ability("TailToHead_A")
            {
                Name = "Tail to Head",
                Description = "Remove all Deep Water from the Opposing position. Inflict half the amount to every other party member tile.\nMove the Opposing party member to the Left or Right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllWaterEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyWaterLastExitEffect>(), 2, Targeting.GenerateSlotTarget(new int[]{4, 3, 2, 1, -1, -2, -3, -4}, false)),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Front)
                },
                Visuals = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.visuals,
                AnimationTarget = Slots.Front,
            };
            tail.AddIntentsToTarget(Slots.Front, Water.Rem_Intent.SelfArray());
            tail.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { 4, 3, 2, 1, -1, -2, -3, -4 }, false), Water.Intent.SelfArray());
            tail.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Swap_Sides.ToString().SelfArray());

            //ADD ENEMY
            cliome.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                underwater.GenerateEnemyAbility(true),
                love.GenerateEnemyAbility(true),
                tail.GenerateEnemyAbility(true)
            });
            cliome.AddEnemy(true, true);
        }
    }
}
