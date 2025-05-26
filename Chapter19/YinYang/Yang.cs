using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Yang
    {
        public static void Add()
        {
            Enemy yang = new Enemy("Yang", "Yang_EN")
            {
                Health = 30,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("YangIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("YangWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("YangDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Noi3e/YangHit",
                DeathSound = "event:/Hawthorne/Noi3e/YangDie",
            };
            yang.PrepareEnemyPrefab("Assets/enem3/Yang_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/gib3/Yang_Gibs.prefab").GetComponent<ParticleSystem>());

            //backlash
            PerformEffectPassiveAbility backlash = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            backlash._passiveName = "Backlash";
            backlash.m_PassiveID = "Backlash_PA";
            backlash.passiveIcon = ResourceLoader.LoadSprite("BacklashPassive.png");
            backlash._enemyDescription = "On taking direct damage, apply Shield to this unit's position for the amount of damage taken.";
            backlash._characterDescription = backlash._enemyDescription;
            backlash.doesPassiveTriggerInformationPanel = false;
            backlash.conditions = new List<EffectorConditionSO>(Passives.Slippery.conditions) { ScriptableObject.CreateInstance<BacklashCondition>() }.ToArray();
            backlash._triggerOn = [TriggerCalls.OnDirectDamaged];
            backlash.effects = [];

            //discord
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
            transform._passiveName = "Discord";
            transform._enemyDescription = "This enemy will perforn the extra ability \"Discord\" each turn.";
            transform._characterDescription = baseExtra._characterDescription;
            transform._triggerOn = baseExtra._triggerOn;
            Ability bonus = new Ability("Discord_A");
            bonus.Name = "Discord";
            bonus.Description = "Transform into Yin, maintaining current health.\n\"But the world is more than dark and light.\"";
            bonus.Priority = Priority.ExtremelySlow;
            CasterTransformByStringEffect yin = ScriptableObject.CreateInstance<CasterTransformByStringEffect>();
            yin.enemy = "Yin_EN";
            yin._maintainMaxHealth = true;
            yin._fullyHeal = false;
            yin._maintainTimelineAbilities = true;
            bonus.Effects = [Effects.GenerateEffect(yin), Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>())];
            bonus.Visuals = CustomVisuals.GetVisuals("Salt/YinYang");
            bonus.AnimationTarget = Slots.Self;
            Intents.CreateAndAddCustom_Basic_IntentToPool("Yin_Yang", ResourceLoader.LoadSprite("YinYangIntent.png"), Color.white);
            bonus.AddIntentsToTarget(Slots.Self, ["Yin_Yang"]);
            AbilitySO ability = bonus.GenerateEnemyAbility(false).ability;
            transform._extraAbility.ability = ability;

            //addpassives
            yang.AddPassives(new BasePassiveAbilitySO[] { backlash, transform });

            //judge
            Ability judge = new Ability("Judiciary", "Judiciary_A");
            judge.Description = "Curse the Opposing party member.\nIf the Opposing party member is already Cursed, deal an Agonizing amount of damage to them.";
            judge.Rarity = Rarity.GetCustomRarity("rarity5");
            judge.Effects = new EffectInfo[2];
            judge.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<IfCursedReturnFalseEffect>(), 1, Slots.Front);
            judge.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(false));
            judge.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Status_Cursed.ToString(), IntentType_GameIDs.Misc_Hidden.ToString(), IntentType_GameIDs.Damage_7_10.ToString()]);
            judge.Visuals = CustomVisuals.GetVisuals("Salt/Piano");
            judge.AnimationTarget = Slots.Front;

            //equals
            Ability equals = new Ability("Equality", "Equality_A");
            equals.Description = "Deal damage to the Opposing party member equal to the amount of Shield this enemy is defended by.";
            equals.Rarity = judge.Rarity;
            equals.Effects = Effects.GenerateEffect(DamageByFieldAmountEffect.Create(StatusField_GameIDs.Shield_ID.ToString(), true, true), 1, Slots.Front).SelfArray();
            equals.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_11_15.ToString()]);
            equals.Visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            equals.AnimationTarget = Slots.Front;
            
            //ADD ENEMY
            yang.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                judge.GenerateEnemyAbility(true),
                equals.GenerateEnemyAbility(true)
            });
            yang.AddEnemy(true, true);
        }
    }
}
