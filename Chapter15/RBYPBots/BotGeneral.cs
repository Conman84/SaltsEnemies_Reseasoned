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
            pillar.AddToPassiveDatabase();

            Ability petrify = new Ability("Bot_Petrify_A")
            {
                Name = "Petrify",
                Description = "Deal a Painful amount of damage to the Opposing party member and move Left. \nChange the Right enemy's health color to this enemy's health color and inflict 2 Pimples on them.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("bot8", 8),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GoLeft, 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, Targeting.Slot_AllyRight),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 2, Targeting.Slot_AllyRight)
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
                Description = "Deal a Painful amount of damage to the Opposing party member and move Right. \nChange the Left enemy's health color to this enemy's health color and inflict 2 Pimples on them.",
                Rarity = Rarity.GetCustomRarity("bot8"),
                Effects = new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front),
                    Effects.GenerateEffect(BasicEffects.GoRight, 1, Slots.Self),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, Targeting.Slot_AllyLeft),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 2, Targeting.Slot_AllyLeft)
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                AnimationTarget = Slots.Front,
            };
            partition.AddIntentsToTarget(Slots.Front, IntentType_GameIDs.Damage_3_6.ToString().SelfArray());
            partition.AddIntentsToTarget(Slots.Self, IntentType_GameIDs.Swap_Right.ToString().SelfArray());
            partition.AddIntentsToTarget(Targeting.Slot_AllyLeft, new string[] { IntentType_GameIDs.Mana_Modify.ToString(), Pimples.Intent });
            Right = partition.GenerateEnemyAbility(true);

            //construct that works on enemies
            RandomAbilityPassive construct = ScriptableObject.CreateInstance<RandomAbilityPassive>();
            construct._passiveName = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._passiveName;
            construct.passiveIcon = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].passiveIcon;
            construct.m_PassiveID = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].m_PassiveID;
            construct._enemyDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._enemyDescription;
            construct._characterDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._characterDescription;
            construct._triggerOn = new TriggerCalls[]
            {
                (TriggerCalls) 889532//old zensuke trigger
            };
            AddPassiveWithDisplayEffect gain = ScriptableObject.CreateInstance<AddPassiveWithDisplayEffect>();
            gain.passive = construct;
            RemovePassiveWithDisplayEffect lose = ScriptableObject.CreateInstance<RemovePassiveWithDisplayEffect>();
            lose.passive = construct;

            ApplyPimplesEffect rando = ScriptableObject.CreateInstance<ApplyPimplesEffect>();
            rando._RandomBetweenPrevious = true;
            Ability postular = new Ability("Bot_Postular_A")
            {
                Name = "Postular",
                Description = "Inflict 2 Pimples on all enemies with this enemy's health color.\nIf all enemies have Pimples, gain Construct, otherwise, lose Construct.",
                Rarity = Rarity.CreateAndAddCustomRarityToPool("bot3", 3),
                Priority = Priority.ExtremelySlow,
                Effects = new EffectInfo[]
                {
                            Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 2, TargettingBySameHealthColor.Create(true, false)),
                            Effects.GenerateEffect(BasicEffects.Empty, 1, Slots.Self, ScriptableObject.CreateInstance<AllAlliesPimplesEffectCondition>()),
                            Effects.GenerateEffect(gain, 1, Slots.Self, BasicEffects.DidThat(true)),
                            Effects.GenerateEffect(lose, 1, Slots.Self, BasicEffects.DidThat(false, 2))
                },
                Visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                AnimationTarget = TargettingBySameHealthColor.Create(true, false),
            };
            postular.AddIntentsToTarget(TargettingBySameHealthColor.Create(true, false), Pimples.Intent.SelfArray());
            postular.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.PA_Construct.ToString()]);
            Middle = postular.GenerateEnemyAbility(true);

            Selector = ScriptableObject.CreateInstance<AbilitySelector_Bots>();
            Selector.Isolate = new string[] { "Bot_Petrify_A", "Bot_Partition_A" };
            Selector.NoAlone = "Bot_Postular_A";

        }
        static bool Set;
    }
}
