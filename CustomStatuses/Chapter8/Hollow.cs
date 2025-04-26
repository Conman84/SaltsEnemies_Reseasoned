using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Hollow
    {
        public static string StatusID => "Hollow_ID";
        public static string Intent => "Status_Hollow";
        public static HollowSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO HollowInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            HollowInfo.icon = ResourceLoader.LoadSprite("HollowIcon.png");
            HollowInfo._statusName = "Hollow";
            HollowInfo._description = "This enemy's turns in the timeline will be hidden. Hollow decreases by 1 at the end of each round it's active.\nHollow has no effect on party members.";
            HollowInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Frail_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            HollowInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            HollowInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            HollowSE_SO HollowSO = ScriptableObject.CreateInstance<HollowSE_SO>();
            HollowSO._StatusID = StatusID;
            HollowSO._EffectInfo = HollowInfo;
            Object = HollowSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = HollowSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(HollowSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("HollowIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class HollowSE_SO : StatusEffect_SO
    {
        public static bool Loading;
        public bool SkipTick;
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (!caller.IsStatusEffectorCharacter && !CombatManager.Instance._stats.IsPlayerTurn) SkipTick = true;
            else if (!caller.IsStatusEffectorCharacter & !Loading)
            {
                Loading = true;
                CombatManager.Instance.AddRootAction(new HollowAction());
            }
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.CanTurnShowInTimeline.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.CanTurnShowInTimeline.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is BooleanReference reference) reference.value = false;
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            if (SkipTick) SkipTick = false;
            else ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class ApplyHollowEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Hollow.Object;
            if (Hollow.Object == null || Hollow.Object.Equals(null)) Hollow.Add();
            HollowSE_SO.Loading = false;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class HollowAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            TurnUIInfo[] roundTurnUIInfo = stats.timeline.RoundTurnUIInfo;
            if (roundTurnUIInfo != null)
            {
                CombatManager.Instance.AddUIAction(new PopulateTimelineUIAction(roundTurnUIInfo));
                CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(stats.timeline.CurrentTurn));
            }
            HollowSE_SO.Loading = false;
            yield break;
        }
    }
}
