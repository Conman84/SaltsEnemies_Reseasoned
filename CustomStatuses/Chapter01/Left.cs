using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Left
    {
        public static string StatusID => "Left_ID";
        public static string Intent => "Status_Left";
        public static LeftSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO LeftInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            LeftInfo.icon = ResourceLoader.LoadSprite("Left.png");
            LeftInfo._statusName = "Left";
            LeftInfo._description = "On moving, move left and reduce this effect by 1.";
            LeftInfo._applied_SE_Event = "event:/Hawthorne/Misc/Left";
            LeftInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Frail_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            LeftInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Frail_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            LeftSE_SO LeftSO = ScriptableObject.CreateInstance<LeftSE_SO>();
            LeftSO._StatusID = StatusID;
            LeftSO._EffectInfo = LeftInfo;
            Object = LeftSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = LeftSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(LeftSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Left.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class LeftSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnMoved.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnMoved.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                this.ReduceDuration(holder, sender as IStatusEffector);
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = false;
                EffectInfo left = Effects.GenerateEffect(goLeft, 1, Targeting.Slot_SelfAll);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { left }, unit));
            }
        }
    }
    public class ApplyLeftEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Left.Object;
            if (Left.Object == null || Left.Object.Equals(null)) Debug.LogError("CALL \"Left.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}