using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

/*I DO THIS*/
//call DrowningManager.Setup() in awake

namespace SaltEnemies_Reseasoned
{
    public static class DrowningManager
    {
        public static string Saline = "Deep_SalinePA";
        public static string Leaky = "Deep_LeakyPA";
        public static void Setup()
        {
            UnitStoreData_ModIntSO value_count = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_count.m_Text = "Leaky +{0}";
            value_count._UnitStoreDataID = Leaky;
            value_count.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            value_count.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Leaky))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Leaky] = value_count;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_count._UnitStoreDataID, value_count);

            UnitStoreData_ModIntSO value_wait = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_wait.m_Text = "Salinity +{0}";
            value_wait._UnitStoreDataID = Saline;
            value_wait.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor;
            value_wait.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Saline))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Saline] = value_wait;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_wait._UnitStoreDataID, value_wait);
        }
    }
    public class GenerateColorManaStoreValueEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public ManaColorSO mana = Pigments.Blue;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable += caster.SimpleGetStoredValue(DrowningManager.Saline);

            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = entryVariable;
            CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(mana, entryVariable, caster.IsUnitCharacter, caster.ID));
            return true;
        }
    }
    public class GenerateCasterColorManaStoreValueEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable += caster.SimpleGetStoredValue(DrowningManager.Leaky);
            ManaColorSO mana = caster.HealthColor;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = entryVariable;
            CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(mana, entryVariable, caster.IsUnitCharacter, caster.ID));
            return true;
        }
    }
    public class AsphyxiationPassiveAbility : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => true;

        public int ManaCap;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public static class AsphyxiationManager
    {
        public static AsphyxiationPassiveAbility GetPassive(IPassiveEffector effector)
        {
            foreach (BasePassiveAbilitySO passive in effector.PassiveAbilities)
                if (passive is AsphyxiationPassiveAbility pasi) return pasi;
            return null;
        }
        public static bool CheckAsphyxiations(CombatStats stats)
        {
            bool flag = true;
            if (stats.overflowMana.OverflowManaAmount <= 0) return flag;
            List<int> IDs = new List<int>();
            List<bool> IsChar = new List<bool>();
            List<string> passi = new List<string>();
            List<Sprite> images = new List<Sprite>();
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                AsphyxiationPassiveAbility passive = GetPassive(enemy);
                if (passive != null)
                {
                    if (stats.overflowMana.OverflowManaAmount < passive.ManaCap)
                    {
                        IDs.Add(enemy.ID);
                        IsChar.Add(enemy.IsUnitCharacter);
                        passi.Add(passive._passiveName);
                        images.Add(passive.passiveIcon);
                        flag = false;
                    }
                }
            }
            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                AsphyxiationPassiveAbility passive = GetPassive(chara);
                if (passive != null)
                {
                    if (stats.overflowMana.OverflowManaAmount < passive.ManaCap)
                    {
                        IDs.Add(chara.ID);
                        IsChar.Add(chara.IsUnitCharacter);
                        passi.Add(passive._passiveName);
                        images.Add(passive.passiveIcon);
                        flag = false;
                    }
                }
            }
            CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(IDs.ToArray(), IsChar.ToArray(), passi.ToArray(), images.ToArray()));
            return flag;
        }
        public static void CalculateOverflow(Action<PlayerTurnEndSecondPartAction, CombatStats> orig, PlayerTurnEndSecondPartAction self, CombatStats stats)
        {
            if (CheckAsphyxiations(stats)) orig(self, stats);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(PlayerTurnEndSecondPartAction).GetMethod(nameof(PlayerTurnEndSecondPartAction.CalculateOverflow), ~BindingFlags.Default), typeof(AsphyxiationManager).GetMethod(nameof(CalculateOverflow), ~BindingFlags.Default));
        }
    }
}
