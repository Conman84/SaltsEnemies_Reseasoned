using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Eyeless
    {
        public static void Add()
        {
            Enemy eyeless = new Enemy("Eyeless", "Eyeless_EN")
            {
                Health = 40,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("EyelessIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("EyelessWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("EyelessDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound/EyelessHit",
                DeathSound = "event:/Hawthorne/Sound/EyelessDie",
            };
            eyeless.PrepareEnemyPrefab("Assets/enem3/Eyeless_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/EyelessGibs.prefab").GetComponent<ParticleSystem>());
            //use death soudn as roar

            //gluttony
            PerformEffectPassiveAbility gluttony = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            gluttony._passiveName = "Gluttony";
            gluttony.passiveIcon = ResourceLoader.LoadSprite("GluttonyPassive.png");
            gluttony.m_PassiveID = "Gluttony_PA";
            gluttony._characterDescription = "On receiving direct damage, move Left and deal a Painful amount of damage to the Opposing enemy.";
            gluttony._enemyDescription = "On receiving direct damage, move Left and deal a Painful amount of damage to the Opposing party member.";
            gluttony.conditions = Passives.Slippery.conditions;
            gluttony.doesPassiveTriggerInformationPanel = true;
            gluttony._triggerOn = TriggerCalls.OnDirectDamaged.SelfArray();
            gluttony.effects = new EffectInfo[2];
            gluttony.effects[0] = Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self);
            gluttony.effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);

            //all knowing
            CasterTransformByStringEffect starless = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            starless.enemy = "Starless_EN";
            starless._maintainTimelineAbilities = true;
            starless._fullyHeal = false;
            starless._maintainMaxHealth = true;
            PerformEffectPassiveAbility leftmost = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            leftmost._passiveName = "All-Knowing";
            leftmost.passiveIcon = ResourceLoader.LoadSprite("AllKnowingPassive.png");
            leftmost.m_PassiveID = "AllKnowing_PA";
            leftmost._enemyDescription = "On moving to the Leftmost position, transform into Starless.";
            leftmost._characterDescription = "Does nothing i think";
            leftmost.conditions = ScriptableObject.CreateInstance<LeftMostCondition>().SelfArray();
            leftmost.doesPassiveTriggerInformationPanel = true;
            leftmost._triggerOn = TriggerCalls.OnMoved.SelfArray();
            leftmost.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(starless),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>())
            };

            eyeless.AddPassives(new BasePassiveAbilitySO[] { gluttony, leftmost });

            AbilitySelector_Eyeless selector = ScriptableObject.CreateInstance<AbilitySelector_Eyeless>();
            selector._killAbility = "Starless_Despair_A";
            eyeless.AbilitySelector = selector;

            eyeless.CombatEnterEffects = Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Starless"), 1).SelfArray();
            eyeless.CombatExitEffects = Effects.GenerateEffect(SetMusicParameterByStringEffect.Create("Starless"), -1).SelfArray();

            Ability despair = new Ability("Despair", "Starless_Despair_A");
            despair.Description = "If the Opposing party member is below 50% of their maximum health, instantly kill them.\nOtherwise, inflict 50 Pale on them.";
            despair.Rarity = Rarity.GetCustomRarity("rarity5");
            despair.Effects = new EffectInfo[2];
            despair.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<KillIfBelowPercentEffect>(), 50, Slots.Front);
            despair.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 5, Slots.Front, BasicEffects.DidThat(false));
            despair.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Damage_Death.ToString(), Pale.Intent });
            despair.Visuals = CustomVisuals.GetVisuals("Salt/Hung");
            despair.AnimationTarget = Slots.Front;

            //other
            EnemyAbilityInfo flow = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Starless_Flow_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            EnemyAbilityInfo follow = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Starless_Follow_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };
            EnemyAbilityInfo stagger = new EnemyAbilityInfo()
            {
                ability = LoadedAssetsHandler.GetEnemyAbility("Starless_Stagger_A"),
                rarity = Rarity.GetCustomRarity("rarity5")
            };

            //ADD ENEMY
            eyeless.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                flow,
                follow,
                stagger,
                despair.GenerateEnemyAbility(true),
            });
            eyeless.AddEnemy(true, true);
        }
    }
}
