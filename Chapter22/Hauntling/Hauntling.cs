using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Hauntling
    {
        public static SpawnEnemyAnywhereEffect Spawn;
        public static void Add()
        {
            Enemy hauntling = new Enemy("Hauntling", "Hauntling_EN")
            {
                Health = 11,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("HauntlingIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("HauntlingWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("HauntlingDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Soisenay/HauntlingHit",
                DeathSound = "event:/Hawthorne/Soisenay/HauntlingDie",
            };
            hauntling.PrepareEnemyPrefab("Assets/Item/Hauntling_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Item/Hauntling_Gibs.prefab").GetComponent<ParticleSystem>());

            //Don't Touch Me
            OnClickPassiveAbility noTouch = ScriptableObject.CreateInstance<OnClickPassiveAbility>();
            noTouch._passiveName = "Don't Touch Me";
            noTouch.m_PassiveID = "DontTouchMe_PA";
            noTouch.passiveIcon = ResourceLoader.LoadSprite("DontTouchMe.png");
            noTouch._characterDescription = "whoops";
            noTouch._enemyDescription = "Upon being clicked, gain an additional ability on the timeline.";
            noTouch.doesPassiveTriggerInformationPanel = false;
            noTouch._triggerOn = new TriggerCalls[] { OnClickPassiveAbility.Trigger };

            hauntling.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Slippery, Passives.Masochism1, noTouch, Passives.Infantile, Passives.Leaky3 });

            Ability antisoftlock = new Ability("Antisoftlock", "Antisoftlock_A");
            antisoftlock.Description = "Inflict 11 Entropy to the Opposing party member and this enemy.";
            antisoftlock.Rarity = Rarity.Common;
            antisoftlock.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 11, MultiTargetting.Create(Slots.Front, Slots.Self))];
            antisoftlock.AddIntentsToTarget(Slots.Front, [Entropy.Intent]);
            antisoftlock.AddIntentsToTarget(Slots.Self, [Entropy.Intent]);
            antisoftlock.Visuals = CustomVisuals.GetVisuals("Salt/Nailing");
            antisoftlock.AnimationTarget = Slots.Front;

            Ability twice = new Ability("Twice Twice", "TwiceTwice_A");
            twice.Description = "Instantly kill the Opposing party member.\nAttempt to revive a random party member in the Opposing position at the health of the killed target if succesful.";
            twice.Rarity = Rarity.Common;
            twice.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathWithExitValueEffect>(), 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ExitOrOneMaxEffect>()),
                Effects.GenerateEffect(CasterPriorityRootActionByExitEffect.Create([
                    Effects.GenerateEffect(CarryExitPastEffect.Create(BasicEffects.GetVisuals("Salt/Hunt", false, Slots.Front)), 1, Slots.Front),
                    Effects.GenerateEffect(UseExitAsEntryEffect.Create(ScriptableObject.CreateInstance<ResurrectEffect>()), 1, Slots.Front),
                    ]), 1, Slots.Self, BasicEffects.DidThat(true, 2))
                ];
            twice.AddIntentsToTarget(Slots.Front, ["Damage_Death", IntentType_GameIDs.Other_Resurrect.ToString()]);
            twice.Visuals = CustomVisuals.GetVisuals("Salt/Hunt");
            twice.AnimationTarget = Slots.Front;

            Ability test = new Ability("Crashes Your Game", "CrashesYourGame_A");
            test.Description = "Curse the Left, Right, and Opposing party members. Low chance to crash your game.\n\"I'm done messing around.\"";
            test.Rarity = Rarity.Common;
            test.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.FrontLeftRight),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<CrashesYourGameEffect>(), 1, Slots.Self, Effects.ChanceCondition(0))];
            test.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_Cursed"]);
            test.AddIntentsToTarget(Slots.Self, ["Misc"]);
            test.Visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals;
            test.AnimationTarget = Slots.Self;

            //ADD ENEMY
            hauntling.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                antisoftlock.GenerateEnemyAbility(true),
                twice.GenerateEnemyAbility(true),
                test.GenerateEnemyAbility(),
            });
            hauntling.AddEnemy(true, true, true);

            Spawn = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            Spawn.enemy = LoadedAssetsHandler.GetEnemy("Hauntling_EN");
            Spawn._spawnTypeID = "Spawn_Basic";
        }
    }
}
