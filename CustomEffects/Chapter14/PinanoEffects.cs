using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class ShowViolentPassiveEffect : EffectSO
    {
        public Sprite image;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Violent (" + entryVariable.ToString() + ")", image));
            return true;
        }
    }
    public class HasHealthEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return ScriptableObject.CreateInstance<IsAliveEffectorCondition>().MeetCondition(caster as IEffectorChecks, null);
            return caster.CurrentHealth > 0;
        }
    }
    public static class Violent
    {
        public static BasePassiveAbilitySO Generate(int amount)
        {
            LateTriggerHandler.Setup();
            PerformEffectPassiveAbility vil = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            vil._passiveName = "Violent (" + amount.ToString() + ")";
            vil.passiveIcon = ResourceLoader.LoadSprite("ViolentPassive.png");
            vil._enemyDescription = "On receiving direct damage, deal " + amount.ToString() + " damage to the Opposing position.\nThis passive does not trigger if the damage received kills.";
            vil._characterDescription = vil._enemyDescription;
            vil.m_PassiveID = "Violent_PA";
            vil.name = "Violent_" + amount.ToString() + "_PA";
            vil.doesPassiveTriggerInformationPanel = false;
            vil._triggerOn = new TriggerCalls[] { LateTriggerHandler.LateDamaged };
            ShowViolentPassiveEffect e = ScriptableObject.CreateInstance<ShowViolentPassiveEffect>();
            e.image = vil.passiveIcon;
            vil.effects = new EffectInfo[]
            {
                    Effects.GenerateEffect(CasterSubActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(e, amount, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>()),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), amount, Slots.Front, ScriptableObject.CreateInstance<HasHealthEffectCondition>())
                    }), 1, Slots.Self)
            };
            vil.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsAliveCondition>() };
            if (!LoadedAssetsHandler.LoadedPassives.ContainsKey(vil.name)) vil.AddToPassiveDatabase();
            return vil;
        }
    }

    public static class LateTriggerHandler
    {
        public static TriggerCalls LateDamaged => (TriggerCalls)2985611;
        static bool _set;
        public static void Setup()
        {
            if (_set) return;
            _set = true;
            NotificationHook.AddAction(NotifCheck);
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnDirectDamaged.ToString())
            {
                CombatManager.Instance.PostNotification(LateDamaged.ToString(), sender, args);
            }
        }
    }
}
