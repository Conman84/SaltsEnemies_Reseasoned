using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class MarchingHandler
    {
        public static string Passive => "Marching_PA";
        public static TriggerCalls Call => (TriggerCalls)2039765;
        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname == TriggerCalls.OnMoved.ToString())
            {
                if (sender is IUnit unit && !unit.ContainsPassiveAbility(Passive))
                {
                    if (unit.IsUnitCharacter) 
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                            CombatManager.Instance.PostNotification(Call.ToString(), chara, sender);
                    else 
                        foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                            CombatManager.Instance.PostNotification(Call.ToString(), enemy, sender);
                }
            }
        }
        public static void Setup() => NotificationHook.AddAction(NotifCheck);
    }
    public class AbilitySelector_Foxtrot : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string _hasPassive = "";

        [SerializeField]
        public string _hasntPassive = "";

        [SerializeField]
        public string _passive = "";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            int num2 = 0;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            bool hasFleeting = unit.ContainsPassiveAbility(_passive);
            for (int i = 0; i < abilities.Count; i++)
            {
                if (ShouldBeIgnored(abilities[i], hasFleeting))
                {
                    num2 += abilities[i].rarity.rarityValue;
                    list2.Add(i);
                }
                else
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            int num3 = UnityEngine.Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num3 < num)
                {
                    return item;
                }
            }

            num3 = UnityEngine.Random.Range(0, num2);
            num2 = 0;
            foreach (int item2 in list2)
            {
                num2 += abilities[item2].rarity.rarityValue;
                if (num3 < num2)
                {
                    return item2;
                }
            }

            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, bool has)
        {
            string text = ability.ability.name;
            if (has && text == _hasntPassive)
            {
                return true;
            }

            if (!has && text == _hasPassive)
            {
                return true;
            }

            return false;
        }
    }
    public class MarchingRemovedEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, false, "Marching Removed", ResourceLoader.LoadSprite("MarchingPassive.png")));
            exitAmount = 0;
            return true;
        }
    }
    public class MarchingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, false, "Marching (" + entryVariable.ToString() + ")", ResourceLoader.LoadSprite("MarchingPassive.png")));
            exitAmount = 0;
            return true;
        }
    }

    public class TriggerPerTurnEffectorCondition : EffectorConditionSO
    {
        public string TurnKeep = "Marching_Turn_PA";
        public string TimesTriggered = "Marching_Trigger_PA";

        public int cap = 6;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.SimpleGetStoredValue(TurnKeep) == CombatManager.Instance._stats.TurnsPassed)
                {
                    int num = unit.SimpleGetStoredValue(TimesTriggered);
                    if (num >= cap) return false;
                    num++;
                    unit.SimpleSetStoredValue(TimesTriggered, num);
                    return true;
                }
                else
                {
                    unit.SimpleSetStoredValue(TurnKeep, CombatManager.Instance._stats.TurnsPassed);
                    int num = 0;
                    if (num >= cap) return false;
                    num++;
                    unit.SimpleSetStoredValue(TimesTriggered, num);
                    return true;
                }
            }
            return false;
        }
    }
}
