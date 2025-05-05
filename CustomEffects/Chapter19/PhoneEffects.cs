using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class AbilitySelector_Wednesday : BaseAbilitySelectorSO
    {
        [Header("Come Home Data")]
        [SerializeField]
        public int _useAfterSelections = 1;

        [SerializeField]
        public string _lockedAbility = "";

        public string Value => "WednesdayAbilities_A";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int num = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < abilities.Count; i++)
            {
                if (!ShouldBeIgnored(abilities[i], unit))
                {
                    num += abilities[i].rarity.rarityValue;
                    list.Add(i);
                }
            }

            if (list.Count <= 0)
            {
                return -1;
            }

            int num2 = Random.Range(0, num);
            num = 0;
            foreach (int item in list)
            {
                num += abilities[item].rarity.rarityValue;
                if (num2 < num)
                {
                    unit.SimpleSetStoredValue(Value, unit.SimpleGetStoredValue(Value) + 1);
                    return item;
                }
            }

            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            if (ability.ability.name != _lockedAbility)
            {
                return false;
            }

            int num = unit.SimpleGetStoredValue(Value);

            return num < _useAfterSelections;
        }
        public static AbilitySelector_Wednesday Create(string ability, int turns = 1)
        {
            AbilitySelector_Wednesday ret = ScriptableObject.CreateInstance<AbilitySelector_Wednesday>();
            ret._lockedAbility = ability;
            ret._useAfterSelections = turns;
            return ret;
        }
    }
}
