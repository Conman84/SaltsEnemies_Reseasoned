using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//call Haste.Add() in awake

namespace SaltEnemies_Reseasoned
{
    public static class Haste
    {
        public static string StatusID => "Haste_ID";
        public static string Intent => "Status_Haste";
        public static HasteSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO HasteInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            HasteInfo.icon = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Haste.Add. put the right sprite here");
            HasteInfo._statusName = "Haste";
            HasteInfo._description = "Get the description";
            Debug.LogError("Haste.Add. get the status description");
            HasteInfo._applied_SE_Event = "event:/Hawthorne/Misc/Haste";
            HasteInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            HasteInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            HasteSE_SO HasteSO = ScriptableObject.CreateInstance<HasteSE_SO>();
            HasteSO._StatusID = StatusID;
            HasteSO._EffectInfo = HasteInfo;
            Object = HasteSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = HasteSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(HasteSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Haste.Add. set the right sprite for the intent also");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class HasteSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter) CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.AttacksPerTurn.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter) CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.AttacksPerTurn.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is CharacterCombat chara)
            {
                chara.RefreshAbilityUse();
                ReduceDuration(holder, sender as IStatusEffector);
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is IntegerReference integerReference)
                integerReference.value += 1;
            ReduceDuration(holder, sender as IStatusEffector);
        }
        public override void ReduceDuration(StatusEffect_Holder holder, IStatusEffector effector)
        {
            if (CanReduceDuration || effector.IsStatusEffectorCharacter)
            {
                int contentMain = holder.m_ContentMain;
                holder.m_ContentMain = Mathf.Max(0, contentMain - 1);
                if (!TryRemoveStatusEffect(holder, effector) && contentMain != holder.m_ContentMain)
                {
                    effector.StatusEffectValuesChanged(_StatusID, holder.m_ContentMain - contentMain, doesPopUp: true);
                }
            }
        }
    }
    public class ApplyHasteEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Haste.Object;
            if (Haste.Object == null || Haste.Object.Equals(null)) Haste.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
