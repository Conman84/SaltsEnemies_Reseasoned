using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{

    public static class DivineSacrifice
    {
        public static string StatusID => "DivineSacrifice_ID";
        public static string Intent => "Status_DivineSacrifice";
        public static DivineSacrificeSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO DivineSacrificeInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            DivineSacrificeInfo.icon = ResourceLoader.LoadSprite("DivineSacrifice.png");
            DivineSacrificeInfo._statusName = "Divine Sacrifice";
            DivineSacrificeInfo._description = "Triple all Divine Protection damage this character takes. This character is temporarily immune to Divine Protection. Reduce by 1 at the end of each turn.";
            DivineSacrificeInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            DivineSacrificeInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            DivineSacrificeInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            DivineSacrificeSE_SO DivineSacrificeSO = ScriptableObject.CreateInstance<DivineSacrificeSE_SO>();
            DivineSacrificeSO._StatusID = StatusID;
            DivineSacrificeSO._EffectInfo = DivineSacrificeInfo;
            Object = DivineSacrificeSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = DivineSacrificeSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(DivineSacrificeSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("DivineSacrifice.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class DivineSacrificeSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            caller.RemoveStatusEffect(StatusField_GameIDs.DivineProtection_ID.ToString());
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.CanApplyStatusEffect.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.CanApplyStatusEffect.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.damageTypeID == CombatType_GameIDs.Dmg_DivineProtection.ToString())
                {
                    hitBy.AddModifier(new DSValueModifier());
                }
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is StatusFieldApplication status)
            {
                if (status.statusID == StatusField_GameIDs.DivineProtection_ID.ToString())
                {
                    status.canBeApplied = false;
                }
            }
        }
        public override void OnEventCall_03(StatusEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class DSValueModifier : IntValueModifier
    {


        public DSValueModifier()
            : base(70)
        {

        }

        public override int Modify(int value)
        {
            return value * 3;
        }
    }
    public class ApplyDivineSacrificeEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = DivineSacrifice.Object;
            if (DivineSacrifice.Object == null || DivineSacrifice.Object.Equals(null)) Debug.LogError("CALL \"DivineSacrifice.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
