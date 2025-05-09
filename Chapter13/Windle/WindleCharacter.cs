using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class WindleCharacter
    {
        public static void Add()
        {
            Character windle = new Character("Windle", "Windle_CH")
            {
                HealthColor = Pigments.Purple,
                UsesBasicAbility = false,
                MovesOnOverworld = true,
                UsesAllAbilities = true,
                FrontSprite = ResourceLoader.LoadSprite("WindleFront", new Vector2(0.5f, 0f)),
                BackSprite = ResourceLoader.LoadSprite("WindleBack", new Vector2(0.5f, 0f)),
                OverworldSprite = ResourceLoader.LoadSprite("WindleWorld", new Vector2(0.5f, 0f)),
                DamageSound = LoadedAssetsHandler.GetCharacter("Doll_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound,
                DialogueSound = LoadedAssetsHandler.GetCharacter("Doll_CH").dxSound,
                UnitTypes = new List<string>() { "Fish", "Sandwich_Fish" }
            };

            //automated
            PerformEffectPassiveAbility auto = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            auto._passiveName = "Automated";
            auto.passiveIcon = ResourceLoader.LoadSprite("WindlePassive.png");
            auto.m_PassiveID = "Automated_PA";
            auto._enemyDescription = "idk";
            auto._characterDescription = "At the end of each turn, if this party member has not manually performed an ability, perform a random ability.";
            auto.doesPassiveTriggerInformationPanel = true; auto._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
            ManuallyActionDoneEffectorCondition m = ScriptableObject.CreateInstance<ManuallyActionDoneEffectorCondition>();
            m._resultShouldBe = false;
            m._justCheckAbility = true;
            auto.conditions = new EffectorConditionSO[] { m };
            auto.effects = Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, Slots.Self).SelfArray();

            windle.AddPassive(auto);
            windle.AddPassive(Passives.Slippery);

            //lv1
            Ability j0 = new Ability("Shod_1_A");
            j0.Name = "Crappy Shod";
            ManaColorSO rp = Pigments.Grey;
            j0.Cost = new ManaColorSO[] { rp, rp, rp, rp, rp, rp };
            j0.Description = "Deal 2 damage to this party member.\nDeal 2 damage to the Opposing enemy.\nDeal 2 damage to the Left and Right party members.";
            j0.Rarity = Rarity.GetCustomRarity("rarity5");
            j0.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            j0.AnimationTarget = MultiTargetting.Create(Slots.Front, Slots.SlotTarget(new int[] { -1, 0, 1 }, true));
            j0.Effects = new EffectInfo[3];
            j0.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self);
            j0.Effects[1] = Effects.GenerateEffect(j0.Effects[0].effect, 2, Slots.Front);
            j0.Effects[2] = Effects.GenerateEffect(j0.Effects[0].effect, 2, Slots.Sides);
            j0.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_1_2.ToString()]);
            j0.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_1_2.ToString()]);
            j0.AddIntentsToTarget(Slots.Sides, [IntentType_GameIDs.Damage_1_2.ToString()]);
            j0.GenerateEnemyAbility();

            Ability j1 = new Ability(j0.ability, "Shod_2_A", j0.Cost, j0.Rarity);
            j1.Name = "Scruffled Shod";
            j1.Description = "Deal 2 damage to this party member.\nDeal 4 damage to the Opposing enemy.\nDeal 3 damage to the Left and Right party members.";
            j1.Effects[1].entryVariable = 4;
            j1.Effects[2].entryVariable = 3;
            j1.EffectIntents[1].intents = [IntentType_GameIDs.Damage_3_6.ToString()];
            j1.EffectIntents[2].intents = [IntentType_GameIDs.Damage_3_6.ToString()];
            j1.GenerateEnemyAbility();

            Ability j2 = new Ability(j1.ability, "Shod_3_A", j0.Cost, j0.Rarity);
            j2.Name = "Meaningless Shod";
            j2.Description = "Deal 2 damage to this party member.\nDeal 6 damage to the Opposing enemy.\nDeal 4 damage to the Left and Right party members.";
            j2.Effects[1].entryVariable = 6;
            j2.Effects[2].entryVariable = 4;
            j2.GenerateEnemyAbility();

            Ability j3 = new Ability("Shod_4_A");
            j3.Name = "Almost Ironic Shod";
            j3.Description = "Deal 20 damage to the Opposing enemy.\nDeal 10 damage to the Left and Right party members.\nInstantly kill this party member.";
            j3.Cost = j0.Cost;
            j3.Rarity = j0.Rarity;
            j3.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            j3.AnimationTarget = MultiTargetting.Create(Slots.Front, Slots.SlotTarget(new int[] { -1, 0, 1 }, true));
            j3.Effects = new EffectInfo[3];
            j3.Effects[0] = Effects.GenerateEffect(j0.Effects[0].effect, 20, Slots.Front);
            j3.Effects[1] = Effects.GenerateEffect(j0.Effects[0].effect, 10, Slots.Sides);
            j3.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self);
            j3.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Damage_16_20.ToString()]);
            j3.AddIntentsToTarget(Slots.Sides, [IntentType_GameIDs.Damage_7_10.ToString()]);
            j3.AddIntentsToTarget(Slots.Self, [IntentType_GameIDs.Damage_Death.ToString()]);
            j3.GenerateEnemyAbility();

            windle.AddLevelData(12, [j0]);
            windle.AddLevelData(15, [j1]);
            windle.AddLevelData(18, [j2]);
            windle.AddLevelData(19, [j3]);
            windle.AddCharacter(false, true);
        }
    }
}
