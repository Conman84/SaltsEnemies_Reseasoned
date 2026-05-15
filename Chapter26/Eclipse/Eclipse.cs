using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Eclipse
    {

        public static void Add()
        {
            Enemy eclipse = new Enemy("Eclipse Rising", "EclipseRising_EN")
            {
                Health = 31,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("RisingIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("RisingWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("RisingDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Yang_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Yang_EN").deathSound,
            };
            eclipse.PrepareEnemyPrefab("assets/group4/Rising/Rising_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Rising/Rising_Gibs.prefab").GetComponent<ParticleSystem>());

            //JITERRY
            PerformEffectPassiveAbility jitter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jitter._passiveName = "Jittery";
            jitter.m_PassiveID = "Jittery_PA";
            jitter.passiveIcon = ResourceLoader.LoadSprite("JitteryPassive.png");
            jitter._enemyDescription = "On any party member manually moving, move to the Left or Right.";
            jitter._characterDescription = jitter._enemyDescription;
            jitter.doesPassiveTriggerInformationPanel = true;
            jitter.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self).SelfArray();
            jitter._triggerOn = new TriggerCalls[] { JitteryHandler.Call };
            jitter.conditions = new EffectorConditionSO[0];
            //scary
            PerformEffectPassiveAbility scary = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            scary._passiveName = "Scary";
            scary.passiveIcon = ResourceLoader.LoadSprite("ScaryPassive.png");
            scary.m_PassiveID = "Scary_PA";
            scary._enemyDescription = "On being directly damaged, Curse the Opposing party member.";
            scary._characterDescription = "On being directly damaged, Curse the Opposing enemy.";
            scary.doesPassiveTriggerInformationPanel = true;
            scary.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front).SelfArray();
            scary._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            eclipse.AddPassives(new BasePassiveAbilitySO[] { jitter, scary });

            CasterAddExtraAbilitySetFromPreviousEffect random_set = ScriptableObject.CreateInstance<CasterAddExtraAbilitySetFromPreviousEffect>();
            IntListWrapper a = new IntListWrapper() { list = { } };
            IntListWrapper b = new IntListWrapper() { list = { 0 } };
            IntListWrapper c = new IntListWrapper() { list = { 0, 0 } };
            IntListWrapper d = new IntListWrapper() { list = { 0, 0, 0 } };
            IntListWrapper e = new IntListWrapper() { list = { 0, 0, 0, 0 } };
            IntListWrapper f = new IntListWrapper() { list = { 0, 0, 0, 0, 0 } };
            random_set._AbilitySets = [ a, b, c, d, e, f ];

            Ability fate = new Ability("Invisible Fates", "InvisibleFate_A");
            fate.Description = "If the Opposing party member is Cursed, deal an Agonizing amount of damage to them.";
            fate.Rarity = Rarity.CreateAndAddCustomRarityToPool("knight_20", 20);
            fate.Priority = Priority.Fast;
            StatusEffectCheckerEffect has_curse = ScriptableObject.CreateInstance<StatusEffectCheckerEffect>();
            has_curse._status = StatusField.Cursed;
            fate.Effects = [Effects.GenerateEffect(has_curse, 1, Slots.Front), Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(true))];
            fate.AddIntentsToTarget(Slots.Front, ["Misc_Hidden", "Damage_7_10"]);
            fate.AnimationTarget = Slots.Front;
            fate.Visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;


            //ADD ENEMY
            eclipse.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                fate.GenerateEnemyAbility(true),
            });
            eclipse.AddEnemy(true, true);
        }
    }
}
