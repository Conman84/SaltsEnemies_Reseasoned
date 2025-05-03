using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    //make pimples DONE
    //make ability selector DONE
    //make override color effect. but dont make it override actually just make the damn bots not pure. which they arent?? lol
    //make specials
    public class AbilitySelector_Bots : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string[] Isolate = new string[0];

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
                {
                    if (Isolate.Contains(abilities[index].ability.name)) unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString(), 1);
                    else unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString(), 0);
                    return index;
                }
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                {
                    if (Isolate.Contains(abilities[index].ability.name)) unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString(), 1);
                    else unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString(), 0);
                    return index;
                }
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability.name;
            return unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.DemonCoreW.ToString()) == 1 && Isolate.Contains(name);
        }
    }
    public class RandomizeTargetHealthColorsNotSameEffect : EffectSO
    {
        public List<ManaColorSO> options;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (options == null)
            {
                options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            }
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.SlotID != caster.SlotID && target.Unit.HealthColor == caster.HealthColor)
                {
                    List<ManaColorSO> list = new List<ManaColorSO>(options);
                    if (list.Contains(target.Unit.HealthColor)) list.Remove(target.Unit.HealthColor);

                    if (target.Unit.ChangeHealthColor(list.GetRandom())) exitAmount++;
                }
            }
            return exitAmount > 0;
        }
        public static RandomizeTargetHealthColorsNotSameEffect Create(bool grey = false)
        {
            RandomizeTargetHealthColorsNotSameEffect ret = ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotSameEffect>();
            ret.options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            if (grey) ret.options.Add(Pigments.Grey);
            return ret;
        }
    }
    public class TargettingBySameHealthColor : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            CombatSlot self = null;
            if (isCasterCharacter)
            {
                foreach (CombatSlot slot in slots.CharacterSlots) if (slot.SlotID == casterSlotID)
                    {
                        self = slot;
                        break;
                    }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots) if (slot.SlotID == casterSlotID)
                    {
                        self = slot;
                        break;
                    }
            }
            if (self == null) return new TargetSlotInfo[0];
            if (!self.HasUnit) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.HealthColor == self.Unit.HealthColor) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingBySameHealthColor Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingBySameHealthColor ret = ScriptableObject.CreateInstance<TargettingBySameHealthColor>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class ChangeHealthColorEffect : EffectSO
    {
        public ManaColorSO color;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && targets[i].Unit.ChangeHealthColor(color))
                {
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }

        public static ChangeHealthColorEffect Create(ManaColorSO color)
        {
            ChangeHealthColorEffect ret = ScriptableObject.CreateInstance<ChangeHealthColorEffect>();
            ret.color = color;
            return ret;
        }
    }
    public class ChangeTargetHealthColorCasterHealthColorEffect : ChangeHealthColorEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            color = caster.HealthColor;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class TargettingByUsedBlue : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (PigmentUsedCollector.UsedBlue == null) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && PigmentUsedCollector.UsedBlue.Contains(target.Unit.ID)) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingByUsedBlue Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingByUsedBlue ret = ScriptableObject.CreateInstance<TargettingByUsedBlue>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class TargettingByUsedYellow : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (PigmentUsedCollector.UsedYellow == null) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && PigmentUsedCollector.UsedYellow.Contains(target.Unit.ID)) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingByUsedYellow Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingByUsedYellow ret = ScriptableObject.CreateInstance<TargettingByUsedYellow>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class RandomizeAllPurpleAndNonPurpleEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ManaColorSO[] options = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow };
            List<int> list = new List<int>();
            List<ManaColorSO> list2 = new List<ManaColorSO>();
            ManaBarSlot[] manaBarSlots = stats.MainManaBar.ManaBarSlots;
            foreach (ManaBarSlot manaBarSlot in manaBarSlots)
            {
                if (!manaBarSlot.IsEmpty && manaBarSlot.ManaColor == Pigments.Purple)
                {
                    int num = UnityEngine.Random.Range(0, options.Length);
                    manaBarSlot.SetMana(options[num]);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(options[num]);
                }
                else if (!manaBarSlot.IsEmpty && manaBarSlot.ManaColor != Pigments.Purple)
                {
                    manaBarSlot.SetMana(Pigments.Purple);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(Pigments.Purple);
                }
            }

            if (list.Count > 0)
            {
                CombatManager.Instance.AddUIAction(new ModifyManaSlotsUIAction(stats.MainManaBar.ID, list.ToArray(), list2.ToArray()));
            }
            exitAmount = list.Count;
            return exitAmount > 0;
        }
    }
}
