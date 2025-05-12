using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class AbilitySelector_Dragon : BaseAbilitySelectorSO
    {

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
            if (unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()) > 0)
            {
                return (name == "Phosphate Fumes" || name == "Chomp" || name == "Norimimi");
            }
            return false;
        }
    }
    public class DragonOnceCondition : EffectorConditionSO
    {
        public static string Value => "DragonOnceCondition_IDK";
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.SimpleGetStoredValue(Value) <= 0)
                {
                    unit.SimpleSetStoredValue(Value, 1);
                    return true;
                }
            }
            return false;
        }
    }
    public class TargettingSelf_NotSlot : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            getAllies = true;
            foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
            {
                if (target.HasUnit && target.Unit.SlotID == casterSlotID) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingSelf_NotSlot Create()
        {
            TargettingSelf_NotSlot ret = ScriptableObject.CreateInstance<TargettingSelf_NotSlot>();
            ret.getAllUnitSlots = false;
            ret.getAllies = true;
            return ret;
        }
    }
}
