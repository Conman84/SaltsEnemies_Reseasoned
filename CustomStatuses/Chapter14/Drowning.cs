﻿using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace SaltEnemies_Reseasoned
{
    public static class Drowning
    {
        public static string StatusID => "Drowning_ID";
        public static string Intent => "Status_Drowning";
        public static DrowningSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO DrowningInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            DrowningInfo.icon = ResourceLoader.LoadSprite("Drowning.png");
            DrowningInfo._statusName = "Drowning";
            DrowningInfo._description = "All healing is reduced by the amount of Drowning. \nAt the end of each turn, if not in Deep Water decrease Drowning by 1. Afterwards, if Drowning is 10 or higher halve this unit's current health.";
            DrowningInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            DrowningInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            DrowningInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            DrowningSE_SO DrowningSO = ScriptableObject.CreateInstance<DrowningSE_SO>();
            DrowningSO._StatusID = StatusID;
            DrowningSO._EffectInfo = DrowningInfo;
            Object = DrowningSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = DrowningSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(DrowningSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Drowning.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }

    public class DrowningSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingHealed.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingHealed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            int Amount = holder.m_ContentMain + holder.Restrictor;
            if (args is HealingReceivedValueChangeException healBy)
            {
                healBy.AddModifier(new DrowningValueModifier(Amount));
                return;
            }
            ReduceDuration(holder, sender as IStatusEffector);
        }
        public override void ReduceDuration(StatusEffect_Holder holder, IStatusEffector effector)
        {
            if (Water.InWater(CombatManager.Instance._stats, effector as IUnit)) return;
            base.ReduceDuration(holder, effector);
            int Amount = holder.m_ContentMain + holder.Restrictor;
            if (Amount >= 10 && effector is IUnit unit)
            {
                float c = unit.CurrentHealth;
                c /= 2;
                int r = (int)Math.Floor(c);
                if (r > 0) unit.SetHealthTo(r);
                else unit.DirectDeath(null);
            }
        }
    }
    public class DrowningValueModifier : IntValueModifier
    {
        public readonly int toAdd;

        public DrowningValueModifier(int amount)
            : base(70)
        {
            this.toAdd = amount;
        }

        public override int Modify(int value)
        {
            if (value <= 0) return value;
            return Math.Max(0, value - toAdd);
        }
    }
    public class ApplyDrowningEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Drowning.Object;
            if (Drowning.Object == null || Drowning.Object.Equals(null)) Drowning.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
