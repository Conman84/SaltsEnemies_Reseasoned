using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class RYBPEcstasy
    {
        public static void Add()
        {
            PerformEffectPassiveAbility overdose = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            overdose.name = "Overdose_PA";
            overdose._passiveName = "Overdose";
            overdose.m_PassiveID = "Overdose_PA";
            overdose.passiveIcon = ResourceLoader.LoadSprite("OverdosePassive.png");
            overdose._enemyDescription = "On being directly damaged, transform into a random other Ecstasy.";
            overdose._characterDescription = "On being directly damaged, probably transform into Agon i think.";
            overdose._triggerOn = [TriggerCalls.OnDirectDamaged];
            overdose.conditions = Passives.Slippery.conditions;

            CheckPassiveAbilityEffect stained = ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>();
            stained.m_PassiveID = "Heterochromia_PA";
            RandomTransformationNotSelfEffect overdose_effect = ScriptableObject.CreateInstance<RandomTransformationNotSelfEffect>();
            overdose_effect._maintainMaxHealth = true;
            overdose_effect._fullyHeal = false;
            overdose_effect._maintainTimelineAbilities = true;
            AddPassiveEffect stain = ScriptableObject.CreateInstance<AddPassiveEffect>();
            stain._passiveToAdd = LoadedAssetsHandler.GetEnemy("GlassedSun_EN").passiveAbilities[2];

            overdose.effects = [
                Effects.GenerateEffect(stained, 1, Slots.Self),
                Effects.GenerateEffect(overdose_effect, 1, Slots.Self),
                Effects.GenerateEffect(stain, 1, Slots.Self, BasicEffects.DidThat(true, 2)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FixCasterTimelineIntentsEffect>())
                ];

            Ability psychadelics = new Ability("Psychadelic Roulette", "PsychadelicRoulette_A");
            psychadelics.Description = "Gain 1 Constricted.\nIf the Opposing party member shares this enemy's health color, deal an Agonizing amount of damage to them.\nOtherwise, change their health color to match this enemy's.";
            psychadelics.Rarity = Rarity.GetCustomRarity("rarity5");
            psychadelics.Effects = new EffectInfo[4];
            psychadelics.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Self);
            psychadelics.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetIsCasterHealthColorEffect>(), 1, Slots.Front);
            psychadelics.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front, BasicEffects.DidThat(true));
            psychadelics.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeHealthColorByCasterColorEffect>(), 1, Slots.Front, BasicEffects.DidThat(false, 2));
            psychadelics.AddIntentsToTarget(Slots.Self, ["Field_Constricted"]);
            psychadelics.AddIntentsToTarget(Slots.Front, ["Damage_7_10", "Mana_Modify"]);
            psychadelics.Visuals = CustomVisuals.GetVisuals("Salt/Cube");
            psychadelics.AnimationTarget = Slots.Front;

            Ability bubble = new Ability("Bubble Blowing", "BubbleBlowing_A");
            bubble.Description = "Move Left or Right.\nIf the Opposing party member shares this enemy's health color, gain 1 Constricted.\nOtherwise, deal a Painful amount of damage to them.";
            bubble.Rarity = Rarity.GetCustomRarity("rarity5");
            bubble.Effects = new EffectInfo[5];
            bubble.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            bubble.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Pop", false, Slots.Front));
            bubble.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<TargetIsCasterHealthColorEffect>(), 1, Slots.Front);
            bubble.Effects[3] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.Self, BasicEffects.DidThat(true));
            bubble.Effects[4] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.Front, BasicEffects.DidThat(false, 2));
            bubble.AddIntentsToTarget(Slots.Self, ["Swap_Sides", "Field_Constricted"]);
            bubble.AddIntentsToTarget(Slots.Front, ["Damage_3_6"]);
            bubble.Visuals = null;
            bubble.AnimationTarget = Slots.Self;

            EnemyAbilityInfo psy = psychadelics.GenerateEnemyAbility(true);
            EnemyAbilityInfo bub = bubble.GenerateEnemyAbility(true);
        }
        public static void Add_Enemy(BasePassiveAbilitySO passive, ManaColorSO color, string name, string type, EnemyAbilityInfo[] abilities)
        {
            Enemy template = new Enemy(name, "Ecstasy_" + type + "_EN")
            {
                Health = 22,
                HealthColor = color,
                CombatSprite = ResourceLoader.LoadSprite(type + "EcstasyIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite(type + "EcstasyWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite(type + "EcstasyDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Hauntling_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Hauntling_EN").deathSound,
            };
            template.PrepareEnemyPrefab("Assets/Siren/Ecstasy_" + type + "_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Siren/Ecstasy_" + type + "_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { passive, Passives.Inanimate, Passives.Forgetful, Passives.DecayGenerator(LoadedAssetsHandler.GetEnemy("ImaginaryDemon_EN")) });

            //ADD ENEMY
            template.AddEnemyAbilities(abilities);
            template.AddEnemy(true, true);
        }
    }
}
