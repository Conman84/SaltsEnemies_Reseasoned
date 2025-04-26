using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//raise Shua's fleeting to 4 instead of 3

//note: SaltEnemies.CursedNoise = "event:/Combat/StatusEffects/SE_Cursed_Apl"

//when setting up shua, make sure UnitTypes = new List<string> { "FemaleID" }

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_Shua : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string wanderlust = "Wanderlust";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()) == 1 && name == this.wanderlust;
        }
    }
}
