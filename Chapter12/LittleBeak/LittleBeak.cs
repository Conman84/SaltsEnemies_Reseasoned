using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.Random;

namespace SaltsEnemies_Reseasoned
{
    public static class LittleBeak
    {
        public static void Add()
        {
            Enemy beak = new Enemy("Little Beak", "LittleBeak_EN")
            {
                Health = 16,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("BeakIcon.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("BeakWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("BeakDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Keko_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Keko_EN").deathSound,
                AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Nervous>()
            };
            beak.PrepareEnemyPrefab("assets/group4/Beak/Beak_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Beak/Beak_Gibs.prefab").GetComponent<ParticleSystem>());
            beak.enemy.enemyTemplate.m_Data.m_Renderer = beak.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();

            //nervous
            PerformEffectPassiveAbility nervous = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            nervous._passiveName = "Nervous";
            nervous.passiveIcon = ResourceLoader.LoadSprite("panic.png");
            nervous.m_PassiveID = "Nervous_PA";
            nervous._enemyDescription = "On moving, gain another action. This action cannot be \"Light Scratches.\"";
            nervous._characterDescription = "won't work. oops!";
            nervous.doesPassiveTriggerInformationPanel = true;
            nervous.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.SetStoreValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()), 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.SetStoreValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()), 0, Slots.Self)
                }), 0, Slots.Self)
            };
            nervous._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };

            //addpassives
            beak.AddPassives(new BasePassiveAbilitySO[] { nervous });
            beak.UnitTypes = new List<string> { "Bird" };

            //beak
            Ability point = new Ability("PointedBeak_A")
            {
                Name = "Pointed Beak",
                Description = "Deal a Painful amount of damage to the Opposing party member, this attack is fully blocked by Shields.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("beak6", 6),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(BasicEffects.ShieldBlocked, 4, Slots.Front),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Needle"),
                AnimationTarget = Slots.Front,
            };
            point.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());

            //scry
            Ability scry = new Ability("Scry_A")
            {
                Name = "Scry",
                Description = "Inflict 2 Frail on the Left and Right party members.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("beak3", 3),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Slots.LeftRight),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                AnimationTarget = Slots.LeftRight,
            };
            scry.AddIntentsToTarget(Slots.LeftRight, IntentType_GameIDs.Status_Frail.ToString().SelfArray());

            //ight scratches
            Ability scratch = new Ability("LightScratches_A")
            {
                Name = "Light Scratches",
                Description = "Remove all Shield from the Opposing position, then move to the Left or Right.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllShieldsEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals,
                AnimationTarget = Slots.Front,
            };
            scratch.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Rem_Field_Shield.ToString().SelfArray());
            scratch.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Swap_Sides.ToString()]);

            //gaze
            Ability stare = new Ability("HollowGaze_A")
            {
                Name = "Hollow Gaze",
                Description = "This enemy wastes its turn staring at you. 50% chance to produce 1 Yellow Pigment.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("beak1", 1),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 2, Slots.Self),
                    Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Yellow), 1, Slots.Self, Effects.ChanceCondition(50))
                },
                Visuals = null,
                AnimationTarget = Slots.Self,
            };
            stare.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Mana_Generate.ToString()]);

            //ADD ENEMY
            beak.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                point.GenerateEnemyAbility(true),
                scry.GenerateEnemyAbility(true),
                stare.GenerateEnemyAbility(true),
                scratch.GenerateEnemyAbility(true)
            });
            beak.AddEnemy(true, true);
        }
    }
}
