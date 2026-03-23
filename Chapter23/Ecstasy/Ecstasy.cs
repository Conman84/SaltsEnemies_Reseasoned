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
            stained.m_PassiveID = "Stained_PA";
            RandomTransformationNotSelfEffect overdose_effect = ScriptableObject.CreateInstance<RandomTransformationNotSelfEffect>();
            overdose_effect._maintainMaxHealth = true;
            overdose_effect._fullyHeal = false;
            overdose_effect._maintainTimelineAbilities = true;
            AddPassiveEffect stain = ScriptableObject.CreateInstance<AddPassiveEffect>();
            stain._passiveToAdd = LoadedAssetsHandler.GetEnemy("GlassedSun_EN").passiveAbilities[2];

            overdose.effects = [
                Effects.GenerateEffect(stained, 1, Slots.Self),
                Effects.GenerateEffect(overdose_effect, 1, Slots.Self),
                Effects.GenerateEffect(CasterSubActionEffect.Create([Effects.GenerateEffect(stain, 1, Slots.Self)]), 1, Slots.Self, BasicEffects.DidThat(true, 2)),
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
            psychadelics.Visuals = CustomVisuals.GetVisuals("Salt/Class");
            psychadelics.AnimationTarget = Slots.Front;
            psychadelics.Priority = Priority.Fast;

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

            Ability special_base = new Ability("Art Of", "ArtOf_A");
            special_base.Description = "Attempt to move Left or Right.\nIf this movement failed, ";
            special_base.Rarity = Rarity.GetCustomRarity("rarity5");
            special_base.Priority = Priority.Slow;
            special_base.Effects = new EffectInfo[3];
            special_base.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self);
            special_base.AddIntentsToTarget(Slots.Self, ["Swap_Sides", "Misc_Hidden"]);
            special_base.Visuals = null;
            special_base.AnimationTarget = Slots.Self;

            Ability agony = new Ability(special_base.ability, "ArtOfAgony_A", [], Rarity.GetCustomRarity("rarity5"));
            agony.Name = "Art Of Agony";
            agony.ability._description += "inflict 4 Ruptured to the Left, Right, and Opposing party members.";
            agony.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Quills_1_A", true, Slots.FrontLeftRight), 0, null, BasicEffects.DidThat(false));
            agony.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 4, Slots.FrontLeftRight, BasicEffects.DidThat(false, 2));
            agony.AddIntentsToTarget(Slots.FrontLeftRight, ["Status_Ruptured"]);

            Ability fantasy = new Ability(special_base.ability, "ArtOfFantasy_A", [], Rarity.GetCustomRarity("rarity5"));
            fantasy.Name = "Art Of Fantasy";
            fantasy.ability._description += "inflict 3 Fire to the Left, Right, and Opposing party members.";
            fantasy.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Class", false, Slots.FrontLeftRight), 0, null, BasicEffects.DidThat(false));
            fantasy.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, Slots.FrontLeftRight, BasicEffects.DidThat(false, 2));
            fantasy.AddIntentsToTarget(Slots.FrontLeftRight, [IntentType_GameIDs.Field_Fire.ToString()]);

            Ability industry = new Ability(special_base.ability, "ArtOfIndustry_A", [], Rarity.GetCustomRarity("rarity5"));
            industry.Name = "Art Of Industry";
            industry.ability._description += "deal a Painful amount of damage to the Left, Right, and Opposing party members.";
            industry.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Gears", false, Slots.FrontLeftRight), 0, null, BasicEffects.DidThat(false));
            industry.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Slots.FrontLeftRight, BasicEffects.DidThat(false, 2));
            industry.AddIntentsToTarget(Slots.FrontLeftRight, ["Damage_3_6"]);

            Ability philosophy = new Ability(special_base.ability, "ArtOfPhilosophy_A", [], Rarity.GetCustomRarity("rarity5"));
            philosophy.Name = "Art Of Philosophy";
            philosophy.ability._description += "inflict 1-2 Slip to the Left, Right, and Opposing party members.";
            philosophy.Effects[1] = Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Cube", false, Slots.FrontLeftRight), 0, null, BasicEffects.DidThat(false));
            philosophy.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipUpToPlusOneEffect>(), 1, Slots.FrontLeftRight, BasicEffects.DidThat(false, 2));
            philosophy.AddIntentsToTarget(Slots.FrontLeftRight, [Slip.Intent]);

            Add_Enemy(overdose, Pigments.Red, "ECSTASY13", "Red", [psy, bub, agony.GenerateEnemyAbility(true)]);
            Add_Enemy(overdose, Pigments.Blue, "ECSTASY09", "Blue", [psy, bub, fantasy.GenerateEnemyAbility(true)]);
            Add_Enemy(overdose, Pigments.Yellow, "ECSTASY02", "Yellow", [psy, bub, industry.GenerateEnemyAbility(true)]);
            Add_Enemy(overdose, Pigments.Purple, "ECSTASY87", "Purple", [psy, bub, philosophy.GenerateEnemyAbility(true)]);

            LoadedAssetsHandler.GetEnemy(Ecstasy.Blue).AddToToysPool();
            LoadedAssetsHandler.GetEnemy(Ecstasy.Yellow).unitTypes = ["Robot"];

            overdose_effect._allTransforms = new List<TransformOption>()
            {
                new TransformOption(LoadedAssetsHandler.GetEnemy(Ecstasy.Red)),
                new TransformOption(LoadedAssetsHandler.GetEnemy(Ecstasy.Red)),
                new TransformOption(LoadedAssetsHandler.GetEnemy(Ecstasy.Blue)),
                new TransformOption(LoadedAssetsHandler.GetEnemy(Ecstasy.Yellow)),
                new TransformOption(LoadedAssetsHandler.GetEnemy(Ecstasy.Purple)),
            };
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
                DamageSound = "event:/Hawthorne/Sound3/" + type + "EcHit",
                DeathSound = "event:/Hawthorne/Sound3/" + type + "EcDie",
            };
            template.PrepareEnemyPrefab("Assets/Siren/Ecstasy_" + type + "_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Siren/Ecstasy_" + type + "_Gibs.prefab").GetComponent<ParticleSystem>());

            template.AddPassives(new BasePassiveAbilitySO[] { passive, Passives.Inanimate, Passives.Forgetful, Passives.DecayGenerator(LoadedAssetsHandler.GetEnemy("ImaginaryDemon_EN")) });

            //ADD ENEMY
            template.AddEnemyAbilities(abilities);
            template.AddEnemy(true, true);
            template.enemy.AddToSynodPool();
        }
    }
}
