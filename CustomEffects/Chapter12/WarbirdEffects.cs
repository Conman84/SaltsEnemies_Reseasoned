using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

//call RepressionPassiveAbility.Setup() in awake

namespace SaltEnemies_Reseasoned
{
    public class RepressionPassiveAbility : BasePassiveAbilitySO
    {
        [Header("IntegerSetter Data")]
        [SerializeField]
        public bool _isItAdditive;

        [SerializeField]
        public int integerValue;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = null;
            if (sender is IUnit unit) caster = unit;
            else
            {
                Debug.LogError("sender not iunit");
                return;
            }
            int extraTurns = caster.SimpleGetStoredValue(bonusTurns);
            if (caster.SimpleGetStoredValue(store) <= 0)
            {
                extraTurns++;
                caster.SimpleSetStoredValue(bonusTurns, extraTurns);
            }
            caster.SimpleSetStoredValue(store, 0);
            if (args is IntegerReference integerReference)
            {
                if (_isItAdditive)
                {
                    integerReference.value += extraTurns;
                }
                else
                {
                    integerReference.value = extraTurns;
                }
            }
        }

        public static string bonusTurns => "Repression_PA";
        public string store => PainCondition.Pain;

        public override void OnPassiveConnected(IUnit unit)
        {
            unit.SimpleSetStoredValue(bonusTurns, 0);
            unit.SimpleSetStoredValue(store, 1);
            CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.OnDamaged.ToString(), unit);
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.OnDamaged.ToString(), unit);
            unit.SimpleSetStoredValue(bonusTurns, 0);
            unit.SimpleSetStoredValue(store, 0);
        }

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is IntegerReference reff && reff.value > 0 && sender is IUnit unit) unit.SimpleSetStoredValue(store, unit.SimpleGetStoredValue(store) + reff.value);
        }
        public void OnStatusTick(object sender, object args)
        {
            if (sender is IUnit unit) unit.SimpleSetStoredValue(store, 0);
        }
        public static void Setup()
        {
            UnitStoreData_ModIntSO value_count = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_count.m_Text = "Repression x{0}";
            value_count._UnitStoreDataID = bonusTurns;
            value_count.m_TextColor = new Color32(63, 205, 189, 255);
            value_count.m_CompareDataToThis = 0;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(bonusTurns))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[bonusTurns] = value_count;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_count._UnitStoreDataID, value_count);
        }
    }
}
