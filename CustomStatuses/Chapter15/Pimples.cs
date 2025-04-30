using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Pimples
    {
        public static string StatusID => "Pimples_ID";
        public static string Intent => "Status_Pimples";
        public static PimplesSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO PimplesInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            PimplesInfo.icon = ResourceLoader.LoadSprite("PimplesIcon.png");
            Debug.LogError("Pimples.Add. put the right sprite here");
            PimplesInfo._statusName = "Pimples";
            PimplesInfo._description = "On a unit moving in front of this unit, generate 1 pigment of this unit's health color.\nReduce by 1 on turn end.";
            PimplesInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            PimplesInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            PimplesInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            PimplesSE_SO PimplesSO = ScriptableObject.CreateInstance<PimplesSE_SO>();
            PimplesSO._StatusID = StatusID;
            PimplesSO._EffectInfo = PimplesInfo;
            Object = PimplesSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = PimplesSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(PimplesSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("PimplesIcon.png");
            Debug.LogError("Drowning.Add. set the right sprite for the intent also");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }

    public class PimplesSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, AmbushManager.Patiently.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, AmbushManager.Patiently.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit) unit.GenerateHealthMana(1);
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class ApplyPimplesEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Pimples.Object;
            if (Pimples.Object == null || Pimples.Object.Equals(null)) Pimples.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
