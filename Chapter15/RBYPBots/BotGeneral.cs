using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BotGeneral
    {
        public static PerformEffectPassiveAbility Pillar;
        public static EnemyAbilityInfo Left;
        public static EnemyAbilityInfo Right;
        public static EnemyAbilityInfo Middle;
        public static AbilitySelector_Bots Selector;

        public static void Add()
        {
            if (Set) return;
            Set = true;
            PerformEffectPassiveAbility pillar = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            pillar._passiveName = "Pillar";
            pillar.m_PassiveID = "Pillar_PA";
            pillar.passiveIcon = ResourceLoader.LoadSprite("PillarPassive.png");
            pillar._enemyDescription = "On death, randomize the health color of all enemies sharing this enemy's health color.";
            pillar._characterDescription = "On death, randomize the health color of all party members sharing this party member's health color.";
            pillar.doesPassiveTriggerInformationPanel = true;
            pillar.effects = Effects.GenerateEffect(RandomizeTargetHealthColorsNotSameEffect.Create(true), 1, Targetting.AllAlly).SelfArray();
            pillar._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            Pillar = pillar;

            Ability petrify = new Ability("Bot_Petrify_A")
            {
                Name = "Petrify",
                Description = "Deal a Painful amount of damage to the Opposing party member. \nMove Left, and change the Right enemy's health color to this enemy's health color and inflict 1 Pimples on them.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("bot8", 8),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, Targeting.Slot_AllyRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, Targeting.Slot_AllyRight)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                AnimationTarget = Slots.Front,
            };
            petrify.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            petrify.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Left.ToString().SelfArray());
            petrify.AddIntentsToTarget(Targeting.Slot_AllyRight, new string[] { IntentType_GameIDs.Mana_Modify.ToString(), Pimples.Intent });
            Left = petrify.GenerateEnemyAbility(true);

            Ability partition = new Ability("Bot_Partition_A")
            {
                Name = "Partition",
                Description = "Deal a Painful amount of damage to the Opposing party member. \nMove Right, and change the Left enemy's health color to this enemy's health color and inflict 1 Pimples on them.",
                Rarity = Rarity.GetCustomRarity("bot8"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, Targeting.Slot_AllyLeft),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, Targeting.Slot_AllyLeft)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                AnimationTarget = Slots.Front,
            };
            partition.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            partition.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Right.ToString().SelfArray());
            partition.AddIntentsToTarget(Targeting.Slot_AllyLeft, new string[] { IntentType_GameIDs.Mana_Modify.ToString(), Pimples.Intent });
            Right = partition.GenerateEnemyAbility(true);

            ApplyPimplesEffect rando = ScriptableObject.CreateInstance<ApplyPimplesEffect>();
            rando._RandomBetweenPrevious = true;
            Ability postular = new Ability("Bot_Postular_A")
            {
                Name = "Postular",
                Description = "Inflict 1-2 Pimple on all other enemies with this enemy's health color.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("bot3", 3),
                Priority = Priority.ExtremelySlow,
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, TargettingBySameHealthColor.Create(true, false, true)),
                            Effects.GenerateEffect(rando, 2, TargettingBySameHealthColor.Create(true, false, true)),
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                AnimationTarget = TargettingBySameHealthColor.Create(true, false, true),
            };
            postular.AddIntentsToTarget(TargettingBySameHealthColor.Create(true, false, true), Pimples.Intent.SelfArray());
            Middle = postular.GenerateEnemyAbility(true);

            Selector = ScriptableObject.CreateInstance<AbilitySelector_Bots>();
            Selector.Isolate = new string[] { "Bot_Petrify_A", "Bot_Partition_A" };
            Selector.NoAlone = "Bot_Postular_A";

        }
        static bool Set;
    }
}
