using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Starless
    {
        public static void Add()
        {
            Enemy starless = new Enemy("Starless", "Starless_EN")
            {
                Health = 40,
                HealthColor = Pigments.Blue,
                CombatSprite = ResourceLoader.LoadSprite("StarlessIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("StarlessWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("StarlessDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound/StarlessHit",
                DeathSound = "event:/Hawthorne/Sound/StarlessDie",
            };
            starless.PrepareEnemyPrefab("Assets/enem3/Starless_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Starless_Gibs.prefab").GetComponent<ParticleSystem>());
            //roar: event:/Hawthorne/Sound/StarlessRoar

            //melancholy
            PerformEffectPassiveAbility melancholy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            melancholy._passiveName = "Melancholy";
            melancholy.passiveIcon = ResourceLoader.LoadSprite("MelancholyPassive.png");
            melancholy.m_PassiveID = "Melancholy_PA";
            melancholy._enemyDescription = "On taking direct damage, apply 1 Left on this enemy and the Opposing party member.";
            melancholy._characterDescription = "On taking direct damage, apply 1 Left on this party member and the Opposing enemy.";
            melancholy.conditions = Passives.Slippery.conditions;
            melancholy.doesPassiveTriggerInformationPanel = true;
            melancholy._triggerOn = TriggerCalls.OnDirectDamaged.SelfArray();
            melancholy.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 1, MultiTargetting.Create(Slots.Self, Slots.Front)).SelfArray();

            //all seeing
            StarlessPassiveAbility.Setup();
            CasterTransformByStringEffect eyeless = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            eyeless.enemy = "Eyeless_EN";
            eyeless._maintainTimelineAbilities = true;
            eyeless._fullyHeal = false;
            eyeless._maintainMaxHealth = true;
            StarlessPassiveAbility rightmost = ScriptableObject.CreateInstance<StarlessPassiveAbility>();
            rightmost._passiveName = "All-Seeing";
            rightmost.passiveIcon = ResourceLoader.LoadSprite("AllSeeingPassive.png");
            rightmost.m_PassiveID = "AllSeeing_PA";
            rightmost._enemyDescription = "On ending the round on the Rightmost tile, deal an Agonizing amount of damage to all party members and transform into Eyeless.";
            rightmost._characterDescription = "On ending the round on the Rightmost tile, deal an Agonizing amount of damage to all enemies.";
            rightmost.doesPassiveTriggerInformationPanel = false;
            rightmost.conditions = ScriptableObject.CreateInstance<RightMostCondition>().SelfArray();
            rightmost._triggerOn = new TriggerCalls[] { StarlessPassiveAbility.Call };
            rightmost.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<StarlessPassiveEffect>()),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/StarBomb", false, Targeting.GenerateSlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false))),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Targeting.GenerateSlotTarget(new int[]{4, 3, 2, 1, 0, -1, -2, -3, -4}, false)),
                Effects.GenerateEffect(eyeless),
                //Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>())
            };

            starless.AddPassives(new BasePassiveAbilitySO[] { melancholy, rightmost });

            AbilitySelector_Starless selector = ScriptableObject.CreateInstance<AbilitySelector_Starless>();
            selector._stagger = "Starless_Stagger_A";
            starless.AbilitySelector = selector;

            //flow
            Ability flow = new Ability("Starless_Flow_A");
            flow.Name = "Flow";
            flow.Description = "Move Right.";
            flow.Rarity = Rarity.GetCustomRarity("rarity5");
            flow.Effects = Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self).SelfArray();
            flow.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Right.ToString().SelfArray());
            flow.Visuals = CustomVisuals.GetVisuals("Salt/Swirl");
            flow.AnimationTarget = Slots.Self;

            //follow
            Ability follow = new Ability("Follow", "Starless_Follow_A");
            follow.Description = "If there is a Far Right party member, move Right twice.\nDeal a Painful amount of damage to the Opposing party member position.";
            follow.Rarity = Rarity.GetCustomRarity("rarity5");
            follow.Effects = new EffectInfo[5];
            follow.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<HasUnitEffect>(), 0, Targeting.Slot_OpponentFarRight);
            follow.Effects[1] = Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self, BasicEffects.DidThat(true));
            follow.Effects[2] = Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self, BasicEffects.DidThat(true, 2));
            follow.Effects[3] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Wheel", false, Slots.Front));
            follow.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front);
            follow.AddIntentsToTarget(Targeting.Slot_OpponentFarRight, IntentType_GameIDs.Misc_Hidden.ToString().SelfArray());
            follow.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.Swap_Right.ToString(), IntentType_GameIDs.Swap_Right.ToString() });
            follow.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            follow.Visuals = null;
            follow.AnimationTarget = Targeting.Slot_OpponentFarRight;

            //stagger
            Ability stagger = new Ability("Stagger", "Starless_Stagger_A");
            stagger.Description = "Move Right twice.\nDeal a Little bit of damage to this enemy twice.";
            stagger.Rarity = Rarity.GetCustomRarity("rarity5");
            stagger.Effects = new EffectInfo[5];
            stagger.Effects[0] = Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self);
            stagger.Effects[1] = Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self);
            stagger.Effects[2] = Effects.GenerateEffect(BasicEffects.GetVisuals("Wriggle_A", false, Slots.Self));
            stagger.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            stagger.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            stagger.AddIntentsToTarget(Slots.Self, new string[]
            {
                IntentType_GameIDs.Swap_Right.ToString(),
                IntentType_GameIDs.Swap_Right.ToString(),
                IntentType_GameIDs.Damage_1_2.ToString(),
                IntentType_GameIDs.Damage_1_2.ToString()
            });
            stagger.Visuals = null;
            stagger.AnimationTarget = Slots.Self;

            //apathy
            RemoveStatusEffectEffect noLeft = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            noLeft._status = Left.Object;
            MoveCasterByLastExitEffect righting = ScriptableObject.CreateInstance<MoveCasterByLastExitEffect>();
            righting._swapRight = true;
            Intents.CreateAndAddCustom_Basic_IntentToPool("Rem_Status_Left", Left.Object.EffectInfo.icon, Intents.GetInGame_IntentInfo(IntentType_GameIDs.Rem_Status_Frail)._color);
            Ability apathy = new Ability("Apathy", "Starless_Apathy_A");
            apathy.Description = "Remove all Left from this enemy. Move Right once for each Left removed.";
            apathy.Rarity = Rarity.GetCustomRarity("rarity5");
            apathy.Effects = new EffectInfo[2];
            apathy.Effects[0] = Effects.GenerateEffect(noLeft, 1, Slots.Self);
            apathy.Effects[1] = Effects.GenerateEffect(righting, 1, Slots.Self);
            apathy.AddIntentsToTarget(Slots.Self, new string[] { "Rem_Status_Left", IntentType_GameIDs.Swap_Right.ToString() });
            apathy.Visuals = CustomVisuals.GetVisuals("Salt/Rose");
            apathy.AnimationTarget = Slots.Self;

            //ADD ENEMY
            starless.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                flow.GenerateEnemyAbility(true),
                follow.GenerateEnemyAbility(true),
                stagger.GenerateEnemyAbility(true),
                apathy.GenerateEnemyAbility(true)
            });
            starless.AddEnemy(true, true);
        }
    }
}
