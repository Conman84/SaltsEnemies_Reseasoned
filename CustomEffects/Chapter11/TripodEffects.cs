using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using BrutalAPI;

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_Tripod : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string longslice = "Slice";
        [SerializeField]
        public string shortstomp = "Stomp";
        [SerializeField]
        public string lens = "Lens";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            bool hasconfus = unit.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString());
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            bool name = ability.ability._abilityName.Contains(longslice);
            bool other = ability.ability._abilityName.Contains(lens);
            return ((name && (!unit.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString()))) || (other && unit.ContainsStatusEffect(StatusField_GameIDs.Spotlight_ID.ToString()) && unit.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString())));
        }
        public int ValueWithoutConfuse(CombatAbility ability, IUnit unit)
        {
            bool name = !ability.ability._abilityName.Contains(shortstomp);
            if (name || unit.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString())) return ability.rarity.rarityValue;
            else return 1;
        }
        public int ValueWithConfuse(CombatAbility ability, IUnit unit)
        {
            bool name = !ability.ability._abilityName.Contains(lens);
            if (name || (!unit.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString()))) return ability.rarity.rarityValue;
            else return 1;
        }
    }
    public class HasConfusionCondition : EffectConditionSO
    {
        public bool returnTrue;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.ContainsPassiveAbility(PassiveType_GameIDs.Confusion.ToString()) == returnTrue;
        }
        public static HasConfusionCondition Create(bool returntrue)
        {
            HasConfusionCondition ret = ScriptableObject.CreateInstance<HasConfusionCondition>();
            ret.returnTrue = returntrue;
            return ret;
        }
    }
    public class ShortStompEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            if (caster.Size >= 5) return false;
            SwapToOneSideEffect left = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            left._swapRight = false;
            SwapToOneSideEffect right = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            right._swapRight = true;
            EffectInfo LeftEffect = Effects.GenerateEffect(left, 1, Slots.Self);
            EffectInfo RightEffect = Effects.GenerateEffect(right, 1, Slots.Self);
            EffectInfo[] lefting = new EffectInfo[] { LeftEffect, LeftEffect, LeftEffect };
            EffectInfo[] righting = new EffectInfo[] { RightEffect, RightEffect, RightEffect };
            if (caster.SlotID == 0) CombatManager.Instance.AddSubAction(new EffectAction(righting, caster));
            else if (caster.SlotID + caster.Size == 4 || UnityEngine.Random.Range(0, 100) < 50) CombatManager.Instance.AddSubAction(new EffectAction(lefting, caster));
            else CombatManager.Instance.AddSubAction(new EffectAction(righting, caster));
            return true;
        }
    }
}
