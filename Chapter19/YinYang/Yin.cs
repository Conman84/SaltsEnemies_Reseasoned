﻿using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Yin
    {
        public static void Add()
        {
            Enemy yin = new Enemy("Yin", "Yin_EN")
            {
                Health = 35,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("YinIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("YinWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("YinDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noi3e/YinHit",
                DeathSound = "event:/Hawthorne/Noi3e/YinDie",
            };
            yin.PrepareEnemyPrefab("Assets/enem3/Yin_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Yin_Gibs.prefab").GetComponent<ParticleSystem>());

            //harmony
            ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
            ExtraAttackPassiveAbility transform = ScriptableObject.CreateInstance<ExtraAttackPassiveAbility>();
            transform.conditions = baseExtra.conditions;
            transform.passiveIcon = baseExtra.passiveIcon;
            transform.specialStoredData = baseExtra.specialStoredData;
            transform.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
            transform.m_PassiveID = baseExtra.m_PassiveID;
            transform._extraAbility = new ExtraAbilityInfo();
            transform._extraAbility.rarity = baseExtra._extraAbility.rarity;
            transform._extraAbility.cost = baseExtra._extraAbility.cost;
            transform._passiveName = "Harmony";
            transform._enemyDescription = "This enemy will perforn the extra ability \"Harmony\" each turn.";
            transform._characterDescription = baseExtra._characterDescription;
            transform._triggerOn = baseExtra._triggerOn;
            Ability bonus = new Ability("Harmony_A");
            bonus.Name = "Harmony";
            bonus.Description = "Transform into Yang, maintaining current health.\n\"Now you become the sky, while I become the land.\"";
            bonus.Priority = Priority.ExtremelySlow;
            CasterTransformByStringEffect yang = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            yang.enemy = "Yang_EN";
            yang._maintainMaxHealth = true;
            yang._fullyHeal = false;
            yang._maintainTimelineAbilities = true;
            bonus.Effects = [Effects.GenerateEffect(yang), Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>())];
            bonus.Visuals = CustomVisuals.GetVisuals("Salt/YinYang");
            bonus.AnimationTarget = Slots.Self;
            Intents.CreateAndAddCustom_Basic_IntentToPool("Yang_Yin", ResourceLoader.LoadSprite("YangYinIntent.png"), Color.white);
            bonus.AddIntentsToTarget(Slots.Self, ["Yang_Yin"]);
            AbilitySO ability = bonus.GenerateEnemyAbility(false).ability;
            transform._extraAbility.ability = ability;


            //splatter
            PerformEffectPassiveAbility splatter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            splatter._passiveName = "Splatter (2)";
            splatter.passiveIcon = ResourceLoader.LoadSprite("splatter.png");
            splatter._enemyDescription = "On death, produce 2 pigment of this enemy's health color.";
            splatter._characterDescription = "On death, produce 2 pigment of this character's health color.";
            splatter.m_PassiveID = "Splatter_PA";
            splatter.doesPassiveTriggerInformationPanel = true;
            splatter._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            splatter.effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 2, Targeting.Slot_SelfSlot) };

            //addpassives
            yin.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, Passives.Transfusion, Passives.Leaky3, Passives.Unstable, Passives.Slippery, Passives.Infantile, Violent.Generate(7), transform });
            yin.AddUnitType("Female_ID");

            //cruel
            Ability cruel = new Ability("Cruel Games", "CruelGames_A");
            cruel.Description = "Deal an Agonizing amount of damage to this enemy, this damage is fully blocked by Shield.\nIf no damage is dealt, inflict 2 Frail on all party members.";
            cruel.Rarity = Rarity.CreateAndAddCustomRarityToPool("yin2", 2);
            cruel.Effects = new EffectInfo[2];
            cruel.Effects[0] = Effects.GenerateEffect(BasicEffects.ShieldBlocked, 10, Slots.Self);
            cruel.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, Targetting.Everything(false), BasicEffects.DidThat(false));
            cruel.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_7_10.ToString()]);
            cruel.AddIntentsToTarget(Targetting.Everything(false), [IntentType_GameIDs.Status_Frail.ToString()]);
            cruel.Visuals = CustomVisuals.GetVisuals("Salt/StarBomb");
            cruel.AnimationTarget = Slots.Self;

            //overthrown
            Ability over = new Ability("Overthrown", "Overthrown_A");
            over.Description = "Deal an Agonizing amount of damage to this enemy, this damage is fully blocked by Shield.\nIf no damage is dealt, Curse the Opposing party member.";
            over.Rarity = Rarity.CreateAndAddCustomRarityToPool("yin8", 8);
            over.Effects = new EffectInfo[2];
            over.Effects[0] = cruel.Effects[0];
            over.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Front, BasicEffects.DidThat(false));
            over.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_7_10.ToString()]);
            over.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Status_Cursed.ToString()]);
            over.Visuals = CustomVisuals.GetVisuals("Salt/Door");
            over.AnimationTarget = Slots.Self;


            //ADD ENEMY
            yin.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                over.GenerateEnemyAbility(true),
                cruel.GenerateEnemyAbility(true),
            });
            yin.AddEnemy(true, true);
        }
    }
}
