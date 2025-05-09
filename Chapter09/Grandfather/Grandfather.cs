using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Grandfather
    {
        public static void Add()
        {
            Enemy coffin = new Enemy("Grandfather", "Grandfather_EN")
            {
                Health = 18,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CoffinIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CoffinWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CoffinDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound,
            };
            coffin.PrepareEnemyPrefab("assets/group4/Coffin/Coffin_Enemy.prefab", SaltsReseasoned.Group4, SaltsReseasoned.Group4.LoadAsset<GameObject>("assets/group4/Coffin/Coffin_Gibs.prefab").GetComponent<ParticleSystem>());

            //DISABLED
            PerformEffectPassiveAbility disabled = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            disabled._passiveName = "Disabled (2)";
            disabled.passiveIcon = ResourceLoader.LoadSprite("DisabledIcon.png");
            disabled._enemyDescription = "On receiving any damage over 2, cancel one of this enemy's moves.";
            disabled._characterDescription = "wont work, lol?";
            disabled.m_PassiveID = "Disabled_PA";
            disabled.doesPassiveTriggerInformationPanel = true;
            disabled._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged };
            disabled.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<DisabledCondition>() };
            disabled.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 1, Slots.Self).SelfArray();

            //RUPTURE
            Connection_PerformEffectPassiveAbility rupture = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            rupture._passiveName = "Enruptured";
            rupture.passiveIcon = ResourceLoader.LoadSprite("enrupture");
            rupture.m_PassiveID = "Enruptured_PA";
            rupture._enemyDescription = "Permanently applies Ruptured to this enemy.";
            rupture._characterDescription = "Permanently applies Ruptured to this character.";
            rupture.doesPassiveTriggerInformationPanel = true;
            rupture.connectionEffects = Effects.GenerateEffect(CasterSubActionEffect.Create(Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPermanentRupturedEffect>(), 1, Slots.Self).SelfArray()), 1, Slots.Self).SelfArray();
            rupture.disconnectionEffects = new EffectInfo[0];
            rupture._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

            coffin.AddPassives(new BasePassiveAbilitySO[] { disabled, Passives.LeakyGenerator(8), rupture });

            //Rot
            Ability rot = new Ability("Rot", "Grandfather_Rot_A");
            rot.Description = "Deal almost no damage to the Opposing party member and inflict 8 Ruptured on them.\nIf there is no Opposing party member, inflict 2 Ruptured on every party member.";
            rot.Rarity = Rarity.GetCustomRarity("rarity5");
            rot.Visuals = CustomVisuals.GetVisuals("Salt/Claws");
            rot.AnimationTarget = Slots.Front;
            rot.Effects = new EffectInfo[3];
            rot.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Slots.Front);
            rot.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 8, Slots.Front);
            rot.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Targeting.Unit_AllOpponents, ScriptableObject.CreateInstance<IsFrontTargetCondition>());
            rot.AddIntentsToTarget(Slots.Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });
            rot.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Misc_Hidden.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });

            //Sink
            Ability sink = new Ability("Sink", "Grandfather_Sink_A");
            sink.Description = "Deal a Little damage to every party member with Ruptured.";
            sink.Rarity = rot.Rarity;
            sink.Visuals = CustomVisuals.GetVisuals("Salt/Claws");
            sink.AnimationTarget = Slots.Self;
            sink.Effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, TargettingByStatusEffect.Create(Targeting.Unit_AllOpponents, StatusField_GameIDs.Ruptured_ID.ToString())).SelfArray();
            sink.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });
            sink.AddIntentsToTarget(TargettingByStatusEffect.Create(Targeting.Unit_AllOpponents, StatusField_GameIDs.Ruptured_ID.ToString()), IntentType_GameIDs.Damage_1_2.ToString().SelfArray());

            //writhe
            Ability writhe = new Ability("Writhe", "Grandfather_Write_A");
            writhe.Description = "Deal a Little damage to this enemy twice.";
            writhe.Rarity = rot.Rarity;
            writhe.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            writhe.AnimationTarget = Slots.Self;
            writhe.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self),
            };
            writhe.AddIntentsToTarget(Slots.Self, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });

            //ADD ENEMY
            coffin.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                rot.GenerateEnemyAbility(true),
                sink.GenerateEnemyAbility(true),
                writhe.GenerateEnemyAbility(true)
            });
            coffin.AddEnemy(true, true);
        }
    }
}
