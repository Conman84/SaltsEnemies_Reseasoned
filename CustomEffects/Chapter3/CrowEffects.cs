using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class CrowIntents
    {
        public static string Count => "Crow_Count";
        public static string Wait => "Crow_Wait";
        public static void Add()
        {
            IntentInfoBasic count = new IntentInfoBasic();
            count._color = Color.white;
            count._sprite = ResourceLoader.LoadSprite("counticon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Count)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Count] = count;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Count, count);

            IntentInfoBasic wait = new IntentInfoBasic();
            wait._color = Color.white;
            wait._sprite = ResourceLoader.LoadSprite("waiticon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Wait)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Wait] = wait;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Wait, wait);

            UnitStoreData_ModIntSO value_count = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_count.m_Text = "Count: {0}";
            value_count._UnitStoreDataID = Count;
            value_count.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.BusterA.ToString()) as UnitStoreData_IntSO).m_TextColor;
            value_count.m_CompareDataToThis = -1;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Count))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Count] = value_count;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_count._UnitStoreDataID, value_count);

            UnitStoreData_ModIntSO value_wait = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            value_wait.m_Text = "Wait: {0}";
            value_wait._UnitStoreDataID = Wait;
            value_wait.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor;
            value_wait.m_CompareDataToThis = -1;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Wait))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Wait] = value_wait;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_wait._UnitStoreDataID, value_wait);
        }
    }
    public class TargettingByStatusEffect : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO origin;
        public override bool AreTargetAllies => origin.AreTargetAllies;
        public override bool AreTargetSlots => origin.AreTargetSlots;
        public bool HasStatus = true;
        public string Type = StatusField_GameIDs.Cursed_ID.ToString();
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = origin.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit)
                {
                    if (HasStatus && target.Unit.ContainsStatusEffect(Type))
                    {
                        ret.Add(target);
                    }
                    else if (!HasStatus && !target.Unit.ContainsStatusEffect(Type))
                    {
                        ret.Add(target);
                    }
                }
            }
            return ret.ToArray();
        }
        public static TargettingByStatusEffect Create(BaseCombatTargettingSO gru, string statusType, bool hasit = true)
        {
            TargettingByStatusEffect ret = ScriptableObject.CreateInstance<TargettingByStatusEffect>();
            ret.origin = gru;
            ret.Type = statusType;
            ret.HasStatus = hasit;
            return ret;
        }
    }
    public class CountCountEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int checkThis = caster.SimpleGetStoredValue("Crow_Count");
            checkThis++;
            if (checkThis >= 3)
            {
                caster.SimpleSetStoredValue("Crow_Count", 0);
                return true;
            }
            caster.SimpleSetStoredValue("Crow_Count", checkThis);
            return false;
        }
    }
    public class WaitCountEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int checkThis = caster.SimpleGetStoredValue("Crow_Wait");
            checkThis++;
            if (checkThis >= 2)
            {
                caster.SimpleSetStoredValue("Crow_Wait", 0);
                return true;
            }
            caster.SimpleSetStoredValue("Crow_Wait", checkThis);
            return false;
        }
    }
    public class SerenityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SimpleSetStoredValue("Crow_Count", caster.SimpleGetStoredValue("Crow_Count") + 1);
            caster.SimpleSetStoredValue("Crow_Wait", caster.SimpleGetStoredValue("Crow_Wait") + 1);
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            return true;
        }
    }
    public class ExitValueSetterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            return exitAmount > 0;
        }
    }
}
