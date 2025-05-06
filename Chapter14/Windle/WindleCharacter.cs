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
        }
    }
}
