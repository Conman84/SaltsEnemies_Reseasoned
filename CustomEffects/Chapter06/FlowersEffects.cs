using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//Make sure you spell Photosynthesize correct for the ability name

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_PigmentFlower : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string photsynthesize = "Flowers_Photosynthesize_A";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            bool hasFleeting = unit.ContainsPassiveAbility(PassiveType_GameIDs.Fleeting.ToString());
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else if (this.MustBeUsed(abilities[index], unit))
                {
                    return index;
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
            string name = ability.ability.name;
            int pigs = 0;
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == unit.HealthColor) pigs++;
            }
            return pigs <= 0 && name == photsynthesize;
        }
        public bool MustBeUsed(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability.name;
            int pigs = 0;
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == unit.HealthColor) pigs++;
            }
            return pigs > 4 && name == photsynthesize;
        }
    }
    public class ApplySpotlightEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = StatusField.Spotlight;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class RandomizeAllOverflowEffect : EffectSO
    {
        public ManaColorSO[] manaRandomOptions;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (manaRandomOptions == null || manaRandomOptions.Length <= 0) return false;
            if (stats.overflowMana.StoredSlots == null || stats.overflowMana.StoredSlots.Count <= 0) return false;
            List<ManaColorSO> ret = new List<ManaColorSO>();
            for (int i = 0; i < stats.overflowMana.StoredSlots.Count; i++)
            {
                ManaColorSO mana = stats.overflowMana.StoredSlots[i];
                ManaColorSO pick = manaRandomOptions[UnityEngine.Random.Range(0, manaRandomOptions.Length)];
                if (mana == pick)
                {
                    ret.Add(mana);
                    exitAmount++;
                    continue;
                }
                ret.Add(pick);
                exitAmount++;
            }
            stats.overflowMana.StoredSlots = ret;
            stats.combatUI._manaOverflow.StoredSlots = stats.overflowMana.StoredSlots;
            stats.combatUI._manaOverflow.UpdateExposedSlots();
            return exitAmount > 0;
        }
    }
    public class MultiTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO first;
        public BaseCombatTargettingSO second;
        public override bool AreTargetAllies => first.AreTargetAllies && second.AreTargetAllies;
        public override bool AreTargetSlots => first.AreTargetSlots && second.AreTargetSlots;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] one = first.GetTargets(slots, casterSlotID, isCasterCharacter);
            TargetSlotInfo[] two = second.GetTargets(slots, casterSlotID, isCasterCharacter);
            TargetSlotInfo[] ret = new TargetSlotInfo[one.Length + two.Length];
            Array.Copy(one, ret, one.Length);
            Array.Copy(two, 0, ret, one.Length, two.Length);
            return ret;
        }

        public static MultiTargetting Create(BaseCombatTargettingSO first, BaseCombatTargettingSO second)
        {
            MultiTargetting ret = ScriptableObject.CreateInstance<MultiTargetting>();
            ret.first = first;
            ret.second = second;
            return ret;
        }
    }
}
