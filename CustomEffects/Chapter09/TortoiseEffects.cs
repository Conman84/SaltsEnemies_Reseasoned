using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using SaltsEnemies_Reseasoned;

//call ArmorManager.Setup() in awake

namespace SaltEnemies_Reseasoned
{
    public static class ArmorManager
    {
        public static string Armor = "Tortoise_Armor_PA";
        public static bool RemoveSlotStatusEffect(Func<CombatSlot, string, bool> orig, CombatSlot self, string type)
        {
            bool ret = orig(self, type);
            if (type == StatusField_GameIDs.Shield_ID.ToString() && self.HasUnit && self.Unit.ContainsPassiveAbility(Armor))
            {
                CombatManager.Instance.AddRootAction(new ArmorAction(self.SlotID, self.IsCharacter, self.Unit.ID));
            }
            AnglerHandler.Check();
            return ret;
        }
        public static int TryRemoveSlotStatusEffect(Func<CombatSlot, string, int> orig, CombatSlot self, string type)
        {
            int ret = orig(self, type);
            if (type == StatusField_GameIDs.Shield_ID.ToString() && self.HasUnit && self.Unit.ContainsPassiveAbility(Armor))
            {
                CombatManager.Instance.AddRootAction(new ArmorAction(self.SlotID, self.IsCharacter, self.Unit.ID));
            }
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatSlot).GetMethod(nameof(CombatSlot.RemoveFieldEffect), ~BindingFlags.Default), typeof(ArmorManager).GetMethod(nameof(RemoveSlotStatusEffect), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(CombatSlot).GetMethod(nameof(CombatSlot.TryRemoveFieldEffect), ~BindingFlags.Default), typeof(ArmorManager).GetMethod(nameof(TryRemoveSlotStatusEffect), ~BindingFlags.Default));
        }
    }
    public class ArmorAction : CombatAction
    {
        public readonly int SlotID;
        public readonly bool character;
        public readonly int UnitID;

        public ArmorAction(int SlotID, bool character, int UnitID)
        {
            this.SlotID = SlotID;
            this.character = character;
            this.UnitID = UnitID;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo g = stats.combatSlots.GetEnemyTargetSlot(SlotID, 0);
            if (character) g = stats.combatSlots.GetCharacterTargetSlot(SlotID, 0);
            if (g.HasUnit && g.Unit.ContainsPassiveAbility(ArmorManager.Armor))
            {
                int amount = 6;
                if (g.Unit is EnemyCombat enemy && enemy.TryGetPassiveAbility(ArmorManager.Armor, out BasePassiveAbilitySO passive) && passive is HeavilyArmoredPassive armor) amount = armor.Amount;
                else if (g.Unit is CharacterCombat chara && chara.TryGetPassiveAbility(ArmorManager.Armor, out BasePassiveAbilitySO passi) && passi is HeavilyArmoredPassive armor2) amount = armor2.Amount;
                if (!stats.combatSlots.UnitInSlotContainsFieldEffect(SlotID, character, StatusField_GameIDs.Shield_ID.ToString()))
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(UnitID, character, "Heavily Armored (" + amount.ToString() + ")", ResourceLoader.LoadSprite("heavily_armored.png")));
                    stats.combatSlots.ApplyFieldEffect(SlotID, character, StatusField.Shield, amount);
                }
            }
            yield return null;
        }
    }
    public class ArmorEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsPassiveAbility(ArmorManager.Armor))
                {
                    CombatManager.Instance.AddSubAction(new ArmorAction(target.SlotID, target.IsTargetCharacterSlot, caster.ID));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class PainCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            Setup();
            if (args is IntegerReference skinteger)
            {
                (effector as IUnit).SimpleSetStoredValue(Pain, (effector as IUnit).SimpleGetStoredValue(Pain) + skinteger.value);
                if ((effector as IUnit).SimpleGetStoredValue(Pain) + (effector as IUnit).SimpleGetStoredValue(Modifier) < 20) return false;

            }
            else
            {
                (effector as IUnit).SimpleSetStoredValue(Pain, 0);
                return false;
            }
            if (!effector.IsAlive || effector.CurrentHealth <= 0) return false;
            return true;
        }
        public static string Pain = "Algophobia_Value_PA";
        public static string Modifier = "Algophobia_Threshold_PA";
        static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            UnitStoreData_ModIntSO value = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value.m_Text = "Damage Taken This Turn: {0}";
            value._UnitStoreDataID = Pain;
            value.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            value.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Pain))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Pain] = value;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value._UnitStoreDataID, value);

            UnitStoreData_ModIntSO threshold = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            threshold.m_Text = "Algophobia -{0}";
            threshold._UnitStoreDataID = Modifier;
            threshold.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            threshold.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Modifier))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Modifier] = threshold;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(threshold._UnitStoreDataID, threshold);
        }
    }
    public class DamageByFieldAmountEffect : DamageEffect
    {
        public string FieldID;
        public bool Opposing;
        public bool includeRestrictor;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                int amount = StatusExtensions.GetFieldAmountFromID(target.SlotID, Opposing ? !target.IsTargetCharacterSlot : target.IsTargetCharacterSlot, FieldID, includeRestrictor);
                if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable * amount, out int exi)) exitAmount += exi;
            }
            return exitAmount > 0;
        }
        public static DamageByFieldAmountEffect Create(string field, bool opposing, bool includerestrictor = false)
        {
            DamageByFieldAmountEffect ret = ScriptableObject.CreateInstance<DamageByFieldAmountEffect>();
            ret.FieldID = field;
            ret.Opposing = opposing;
            ret.includeRestrictor = includerestrictor;
            return ret;
        }
    }
    public class HasFieldAmountEffectCondition : EffectConditionSO
    {
        public string FieldID;
        public int AmountExclusive;
        public bool Greater;
        public bool includeRestrictor;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int ret = 0;
            foreach (TargetSlotInfo target in Targeting.Slot_SelfAll.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
            {
                ret += target.GetFieldAmount(FieldID, includeRestrictor);
            }
            if (ret > AmountExclusive) return Greater;
            else return !Greater;
        }
        public static HasFieldAmountEffectCondition Create(string field, int amountexclusive, bool greater, bool includeRestrictor = false)
        {
            HasFieldAmountEffectCondition ret = ScriptableObject.CreateInstance<HasFieldAmountEffectCondition>();
            ret.FieldID = field;
            ret.AmountExclusive = amountexclusive;
            ret.Greater = greater;
            ret.includeRestrictor = includeRestrictor;
            return ret;
        }
    }
    public class HeavilyArmoredPassive : PerformEffectPassiveAbility
    {
        public int Amount;
    }
}
