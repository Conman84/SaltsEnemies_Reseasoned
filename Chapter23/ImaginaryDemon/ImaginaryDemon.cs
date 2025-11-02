using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class ImaginaryDemon
    {
        public static void Add()
        {
            Enemy demon = new Enemy("Imaginary Demon", "ImaginaryDemon_EN")
            {
                Health = 12,
                HealthColor = Pigments.Grey,
                CombatSprite = ResourceLoader.LoadSprite("DemonIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("DemonWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("DemonDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy(Enemies.Skinning).damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy(Enemies.Skinning).deathSound,
            };
            demon.PrepareEnemyPrefab("Assets/Siren/Demon_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Siren/Demon_Gibs.prefab").GetComponent<ParticleSystem>());

            demon.AddPassives(new BasePassiveAbilitySO[] { Passives.Anchored, Passives.Forgetful, Passives.Withering });

            Ability freed = new Ability("FREEEEED!!!", "Freed_A");
            freed.Description = "Low chance to deal an Agonizing amount of damage to each party member.";
            freed.Rarity = Rarity.GetCustomRarity("rarity5");
            freed.Effects = [Effects.GenerateEffect(ChanceZeroDamageEffect.Create(0.91f), 10, Targeting.Unit_AllOpponents)];
            freed.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Damage_7_10"]);
            freed.Visuals = Visuals.Decimate;
            freed.AnimationTarget = Slots.Self;

            Ability bleed = new Ability("Might Bleed", "MightBleed_A");
            bleed.Description = "Inflict 0-6 Ruptured to the Opposing party member.\nTake 2 damage.";
            bleed.Rarity = Rarity.GetCustomRarity("rarity5");
            bleed.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front, Effects.ChanceCondition(80)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front, Effects.ChanceCondition(50)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front, Effects.ChanceCondition(30)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front, Effects.ChanceCondition(15)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front, Effects.ChanceCondition(10)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Front, Effects.ChanceCondition(5)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self)
                ];
            bleed.AddIntentsToTarget(Slots.Front, ["Status_Ruptured"]);
            bleed.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            bleed.Visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            bleed.AnimationTarget = Slots.Front;

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
            //burning
            PerformEffectPassiveAbility burning = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            burning._passiveName = "Burning (1)";
            burning.passiveIcon = ResourceLoader.LoadSprite("burningIcon.png");
            burning.m_PassiveID = "Burning_PA";
            burning.name = "Burning_1_PA";
            burning._enemyDescription = "On receiving direct damage, inflict 1 Fire on this position and the Opposing position.";
            burning._characterDescription = burning._enemyDescription;
            burning.doesPassiveTriggerInformationPanel = true;
            burning.effects = [Effects.GenerateEffect(RootActionEffect.Create(new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, MultiTargetting.Create(Targeting.Slot_SelfAll, Slots.Front))
            }), 1, Slots.Self)];
            burning._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };

            AddRandomPassiveEffect passives = ScriptableObject.CreateInstance<AddRandomPassiveEffect>();
            passives.Passives = [
                Passives.TwoFaced,
                Passives.Leaky3, 
                Violent.Generate(5),
                scary,
                Passives.Infantile,
                Passives.Unstable,
                burning
                ];

            Ability unchainer = new Ability("Unchainer", "Unchainer_A");
            unchainer.Description = "Gain a random of a selection of \"On-Hit\" passives.";
            unchainer.Rarity = Rarity.Common;
            unchainer.Effects = [Effects.GenerateEffect(passives, 1, Slots.Self)];
            unchainer.AddIntentsToTarget(Slots.Self, ["Misc_Hidden"]);
            unchainer.Visuals = Visuals.Crush;
            unchainer.AnimationTarget = Slots.Self;

            //ADD ENEMY
            demon.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                freed.GenerateEnemyAbility(true),
                bleed.GenerateEnemyAbility(true),
                unchainer.GenerateEnemyAbility(true)
            });
            demon.AddEnemy(true, true);
        }
    }
}
