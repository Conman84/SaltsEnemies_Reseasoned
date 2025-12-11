using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class WhaleEffect : SetCasterAnimationParameterEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            _parameterName = "Position";
            int amount = caster.SimpleGetStoredValue(WhaleCondition.value);
            if (amount <= 2) _parameterValue = 1;
            if (amount <= 1) _parameterValue = 2;
            if (amount <= 0) return false;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }

    public class WhaleCondition : EffectConditionSO
    {
        public static string value => "Whale_Descent_A";
        public static string enable => "Whale_EnableDescent";
        public static UnitStoreData_BasicSO Reader
        {
            get
            {
                if (!set)
                {
                    set = true;
                    UnitStoreData_ModIntSO value_descent = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
                    value_descent.m_Text = "Descent in: {0}";
                    value_descent._UnitStoreDataID = value;
                    value_descent.m_TextColor = Misc.GetInGame_UITextColor(Misc.UITextColorIDs.Positive);
                    value_descent.m_CompareDataToThis = -1;
                    if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(value))
                        LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[value] = value_descent;
                    else
                        LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_descent._UnitStoreDataID, value_descent);
                }
                return LoadedDBsHandler.MiscDB.GetUnitStoreData(value);
            }
        }
        static bool set;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.SimpleGetStoredValue(enable) <= 0)
            {
                caster.SimpleSetStoredValue(enable, 1);
                caster.SimpleSetStoredValue(value, 3);
            }

            caster.SimpleSetStoredValue(value, Math.Max(0, caster.SimpleGetStoredValue(value) - 1));
            if (caster.SimpleGetStoredValue(value) <= 0) return true;
            return false;
        }
    }

    public class WhaleEnterEffect : EffectSO
    {
        static bool set;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (!set)
            {
                UnitStoreData_BasicSO a = WhaleCondition.Reader;
            }
            caster.SimpleSetStoredValue(WhaleCondition.value, 3);
            caster.SimpleSetStoredValue(WhaleCondition.enable, 1);
            exitAmount = 0;
            return true;
        }
    }
}
