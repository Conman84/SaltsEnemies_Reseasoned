using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class GlassConnectionEffect : CasterChangeNameEnemyEffect
    {
        public bool Connect;

        public void Function(object sender, object args)
        {
            //Debug.Log("hi");
            base.PerformEffect(CombatManager.Instance._stats, sender as IUnit, [], false, 0, out int exi);
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(Function, TriggerCalls.OnAnyAbilityUsed.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnAnyAbilityUsed.ToString(), caster);
            return true;
        }

        public static GlassConnectionEffect Create(bool connection)
        {
            GlassConnectionEffect ret = ScriptableObject.CreateInstance<GlassConnectionEffect>();
            ret.Connect = connection;
            return ret;
        }

    }

    public class AbilitySelector_GlassFigurine : BaseAbilitySelectorSO
    {

        [SerializeField]
        public string _WoodChipsAbility = "WoodChips_A";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < abilities.Count; i++)
            {
                if (!ShouldBeIgnored(abilities[i]))
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            if (list.Count <= 0)
            {
                return -1;
            }

            int num2 = UnityEngine.Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num2 < num)
                {
                    return item;
                }
            }

            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability)
        {
            if (ability.ability.name != _WoodChipsAbility)
            {
                return false;
            }

            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (chara.CurrentHealth <= 9) return false;
            }

            //Debug.Log("glass: should be ignored");
            return true;
        }
    }
}
