using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Android;

namespace SaltsEnemies_Reseasoned
{
    public static class Butterfly
    {
        public static void Add()
        {
            Enemy butterfly = new Enemy("Spectre Witch's Familiar", "Spectre_EN")
            {
                Health = 16,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("ButterflyIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("ButterflyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("ButterflyDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Boowomp",
                DeathSound = "",
            };
            butterfly.PrepareMultiEnemyPrefab("assets/group4/Butterfly/Butterfly_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Butterfly/Butterfly_Gibs.prefab").GetComponent<ParticleSystem>());
            (butterfly.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                butterfly.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                butterfly.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
            };

            //ETHEREAL
            PerformEffectPassiveAbility ethereal = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            ethereal._passiveName = "Ethereal";
            ethereal.passiveIcon = ResourceLoader.LoadSprite("Ethereal.png");
            ethereal._enemyDescription = "On taking any damage, instantly flee. When fleeing, this enemy will return at the end of the timeline if combat hasn't ended.";
            ethereal._characterDescription = "On taking any damage, instantly flee. When fleeing, this character will return at the end of the timeline if combat hasn't ended.";
            ethereal.m_PassiveID = ButterflyUnboxer.ButterflyPassive;
            ethereal.doesPassiveTriggerInformationPanel = true;
            ethereal._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged };
            ethereal.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IfAliveCondition>() };
            ethereal.effects = new EffectInfo[]
            {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IfAliveEffectCondition>())
            };

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

            //addpassives
            butterfly.AddPassives(new BasePassiveAbilitySO[] { colors, ethereal });
            butterfly.CombatExitEffects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<IsDieCondition>()).SelfArray();
            //SaltsReseasoned.PCall(ButterflyHitHandler.Setup);

            //DISSOLVER
            Ability dissolver = new Ability("Witch_Dissolver_A")
            {
                Name = "Dissolver",
                Description = "Deal an Agonizing amount of damage to the Left and Right party members and apply 3 Anesthetics to them.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.LeftRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyAcidEffect>(), 3, Slots.LeftRight)
                },
                Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals,
                AnimationTarget = Slots.LeftRight,
            };
            dissolver.AddIntentsToTarget(Slots.LeftRight, new string[] { IntentType_GameIDs.Damage_7_10.ToString(), Acid.Intent });

            //fadeout
            Ability fade = new Ability("Witch_Fade_A")
            {
                Name = "Fade Out",
                Description = "Make the Opposing party member instantly flee. This enemy flees as well.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Class"),
                AnimationTarget = MultiTargetting.Create(Slots.Self, Slots.Front),
            };
            fade.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.PA_Fleeting.ToString().SelfArray());
            fade.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.PA_Fleeting.ToString().SelfArray());

            //phase
            Ability phase = new Ability("Witch_Phase_A")
            {
                Name = "Phase In",
                Description = "Instanty flee this enemy and spawn a copy of it.",
                Rarity = Rarity.GetCustomRarity("rarity5"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self),
                    Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                        {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawnSelfEnemyAnywhereEffect>(), 1, Slots.Self)
                        }), 1, Slots.Self)
                    }), 1, Slots.Self)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Door"),
                AnimationTarget = Slots.Self,
            };
            phase.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.PA_Fleeting.ToString(), IntentType_GameIDs.Other_Spawn.ToString() });

            //ADD ENEMY
            butterfly.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                dissolver.GenerateEnemyAbility(true),
                fade.GenerateEnemyAbility(true),
                phase.GenerateEnemyAbility(true),
            });
            butterfly.AddEnemy(true, true, true);
        }
    }
}
