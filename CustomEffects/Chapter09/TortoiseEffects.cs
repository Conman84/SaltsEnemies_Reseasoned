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
                if (!stats.combatSlots.UnitInSlotContainsFieldEffect(SlotID, character, StatusField_GameIDs.Shield_ID.ToString()))
                {
                    Debug.LogError("ArmorAction: MAKE SURE THIS IS LOADING THE RIGHT SPRITE");
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(UnitID, character, "Heavily Armored (10)", ResourceLoader.LoadSprite("heavily_armored")));
                    stats.combatSlots.ApplyFieldEffect(SlotID, character, StatusField.Shield, 10);
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
                if ((effector as IUnit).SimpleGetStoredValue(Pain) < 20) return false;

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
        static bool Set;
        public static void Setup()
        {
            if (Set) return;
            Set = true;
            UnitStoreData_ModIntSO value_count = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_count.m_Text = "Damage Taken This Turn: {0}";
            value_count._UnitStoreDataID = Pain;
            value_count.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            value_count.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Pain))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Pain] = value_count;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_count._UnitStoreDataID, value_count);
        }
    }
}
