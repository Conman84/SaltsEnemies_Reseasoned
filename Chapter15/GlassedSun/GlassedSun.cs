using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace SaltsEnemies_Reseasoned
{
    public static class GlassedSun
    {
        public static void Add()
        {
            Enemy glass = new Enemy("Glassed Sun", "GlassedSun_EN")
            {
                Health = 60,
                HealthColor = Pigments.Yellow,
                CombatSprite = ResourceLoader.LoadSprite("SunIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("SunWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("SunDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound,
                DeathSound = "event:/Hawthorne/Sound/StarlessDie",
            };
            glass.PrepareEnemyPrefab("assets/Sun/Sun_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Sun/Sun_Gibs.prefab").GetComponent<ParticleSystem>());

            //HETEROCHROMIA
            PerformEffectPassiveAbility colors = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            colors._passiveName = "Heterochromia";
            colors.m_PassiveID = "Heterochromia_PA";
            colors.passiveIcon = ResourceLoader.LoadSprite("Hemochromia.png");
            colors._enemyDescription = "Upon receiving any kind of damage, randomize this enemy's health colour.";
            colors._characterDescription = "Upon receiving any kind of damage, randomize this party member's health colour.";
            ChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
                        Pigments.Blue,
                        Pigments.Red,
                        Pigments.Yellow,
                        Pigments.Purple
            };
            colors.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect((EffectSO) randomize, 1, Slots.Self)
            };
            colors._triggerOn = new TriggerCalls[]
            {
                        TriggerCalls.OnDamaged
            };


            //SUN
            PriorityPerformEffectPassiveAbility stain = ScriptableObject.CreateInstance<PriorityPerformEffectPassiveAbility>();
            stain._passiveName = "Stained";
            stain.m_PassiveID = "Stained_PA";
            stain.passiveIcon = ResourceLoader.LoadSprite("StainedPassive.png");
            stain._enemyDescription = "At the end of each round, transform into a random color enemy of this enemy's health color.";
            stain._characterDescription = "literally doesnt work";
            GlassedSunEffect g = ScriptableObject.CreateInstance<GlassedSunEffect>();
            GlassedSunEffect.Instance = g;
            AddPassiveEffect p = ScriptableObject.CreateInstance<AddPassiveEffect>();
            p._passiveToAdd = stain;
            stain.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect(g, 1, Slots.Self),
                        Effects.GenerateEffect(p, 1, Slots.Self),
            };
            stain._triggerOn = new TriggerCalls[]
            {
                        TriggerCalls.TimelineEndReached, TriggerCalls.CanChangeHealthColor
            };
            stain.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<SunColorCondition>() };

            glass.AddPassives(new BasePassiveAbilitySO[] { colors, Passives.Formless, stain });
            glass.CombatEnterEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(randomize, 1, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SunColorEffect>(), 1, Slots.Self),
            };

            //neon
            Ability neon = new Ability("Neon", "Neon_A");
            neon.Description = "Deal a Little damage and inflict 1 Scar on this enemy.\nApply 10 Shield to this enemy's position.";
            neon.Rarity = Rarity.GetCustomRarity("rarity5");
            neon.Effects = new EffectInfo[3];
            neon.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            neon.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Slots.Self);
            neon.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, Slots.Self);
            neon.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Scars.ToString(), IntentType_GameIDs.Field_Shield.ToString()]);
            neon.Visuals = CustomVisuals.GetVisuals("Salt/Spotlight");
            neon.AnimationTarget = Slots.Self;

            //reflections
            Ability reflect = new Ability("Reflections", "Reflections_A");
            reflect.Description = "Deal an Agonizing amount of damage to the Opposing party member and to this enemy.\nChange this enemy's health color to match the Opposing party member's.";
            reflect.Rarity = Rarity.GetCustomRarity("rarity5");
            reflect.Effects = new EffectInfo[2];
            reflect.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, MultiTargetting.Create(Slots.Front, Slots.Self));
            reflect.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterChangeHealthColorForTargetEffect>(), 1, Slots.Front);
            reflect.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_7_10.ToString()]);
            reflect.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Mana_Modify.ToString()]);
            reflect.Visuals = CustomVisuals.GetVisuals("Salt/Insta/Shatter");
            reflect.AnimationTarget = MultiTargetting.Create(Slots.Front, Slots.Self);

            //ADD ENEMY
            glass.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                neon.GenerateEnemyAbility(true),
                reflect.GenerateEnemyAbility(true)
            });
            glass.AddEnemy(true, true);
        }
    }
}
