using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class FleetingValue
    {
        public static string Intent => "Passive_Fleeting";
        public static BasePassiveAbilitySO Fleeting(int amount)
        {
            FleetingPassiveAbility baseParent = Passives.Fleeting3 as FleetingPassiveAbility;
            FleetingPassiveAbility flee = ScriptableObject.Instantiate<FleetingPassiveAbility>(baseParent);
            flee._passiveName = "Fleeting (" + amount.ToString() + ")";
            flee._characterDescription = "After " + amount.ToString() + " rounds this party member will flee... Coward.";
            flee._enemyDescription = "After " + amount.ToString() + " rounds this enemy will flee.";
            flee._turnsBeforeFleeting = amount;
            return flee;
        }
        public static void Setup()
        {
            UnitStoreData_ModIntSO fleeting = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            fleeting.m_Text = "Fleeting Count: {0}";
            fleeting._UnitStoreDataID = UnitStoredValueNames_GameIDs.FleetingPA.ToString();
            fleeting.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor;
            fleeting.m_CompareDataToThis = -1;
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(UnitStoredValueNames_GameIDs.FleetingPA.ToString()))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[UnitStoredValueNames_GameIDs.FleetingPA.ToString()] = fleeting;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(fleeting._UnitStoreDataID, fleeting);

            try
            {
                NotificationHook.AddAction(InstantiateFleeting);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }

            Intents.CreateAndAddCustom_Basic_IntentToPool(Intent, Passives.Fleeting1.passiveIcon, Color.white);
        }
        public static void InstantiateFleeting(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnRoundFinished.ToString())
            {
                try
                {
                    UnitStoreData_BasicSO value = null;
                    try
                    {
                        value = LoadedDBsHandler.MiscDB.GetUnitStoreData(UnitStoredValueNames_GameIDs.FleetingPA.ToString());
                    }
                    catch (Exception ex)
                    {
                        Debug.LogWarning("Didnt get fleeting stored value from DB");
                        Debug.LogWarning(ex.ToString());
                        UnitStoreData_ModIntSO fleeting = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
                        fleeting.m_Text = "Fleeting Count: {0}";
                        fleeting._UnitStoreDataID = UnitStoredValueNames_GameIDs.FleetingPA.ToString();
                        fleeting.m_TextColor = (LoadedDBsHandler.MiscDB.GetUnitStoreData("TearsA") as UnitStoreData_IntSO).m_TextColor;
                        fleeting.m_CompareDataToThis = -1;
                        value = fleeting;
                    }
                    if (sender is CharacterCombat chara)
                    {
                        foreach (BasePassiveAbilitySO passive in chara.PassiveAbilities)
                        {
                            if (passive is FleetingPassiveAbility && (passive.specialStoredData == null || passive.specialStoredData.Equals(null))) passive.specialStoredData = value;
                        }
                    }
                    if (sender is EnemyCombat enemy)
                    {
                        foreach (BasePassiveAbilitySO passive in enemy.PassiveAbilities)
                        {
                            if (passive is FleetingPassiveAbility && (passive.specialStoredData == null || passive.specialStoredData.Equals(null))) passive.specialStoredData = value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogWarning("Fleeting Stored Value Setup error again sigh i have no fucking clue whats going on");
                    Debug.LogError(ex.ToString());
                }
            }
        }
    }
}