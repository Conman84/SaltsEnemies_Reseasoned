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
            vil._characterDescription = "On receiving direct damage, deal " + amount.ToString() + " damage to the Opposing position.\nThis passive does not trigger if the damage was fatal.";
            string word = "a Painful amount of";
            switch (amount)
            {
                case 0:
                    word = "No";
                    break;
                case 1:
                    word = "Almost No";
                    break;
                case 2:
                    word = "A Little";
                    break;
                case 3:
                    break;
                case 4:
                    goto case 3;
                case 5:
                    goto case 3;
                case 6:
                    goto case 3;
                case 7:
                    word = "an Agonizing amount of";
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    goto case 7;
                case 11:
                    word = "a Deadly amount of";
                    break;
                case 12:
                    goto case 11;
                case 13:
                    goto case 11;
                case 14:
                    goto case 11;
                case 15:
                    goto case 11;
                case 16:
                    word = "a Lethal amount of";
                    break;
                case 17:
                    goto case 16;
                case 18:
                    goto case 16;
                case 19:
                    goto case 16;
                case 20:
                    goto case 16;
                default:
                    word = "a Mortal amount of";
                    break;
            }
            vil._characterDescription = "On receiving direct damage, deal " + word + " damage to the Opposing position.\nThis passive does not trigger if the damage was fatal.";
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
                    }), 1, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>())
            };
            vil.conditions = Passives.Slippery.conditions;
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
