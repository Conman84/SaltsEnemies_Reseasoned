using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Anesthetics
    {
        public static string StatusID => "Anesthetics_ID";
        public static string Intent => "Status_Anesthetics";
        public static AnestheticsSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO AnestheticsInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            AnestheticsInfo.icon = ResourceLoader.LoadSprite("Anesthetics.png");
            AnestheticsInfo._statusName = "Anesthetics";
            AnestheticsInfo._description = "All damage received will be decreased by 1 for each Anesthetic. Decreases by 1 at the start of each turn.";
            AnestheticsInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo._applied_SE_Event;
            AnestheticsInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            AnestheticsInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Scars_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            AnestheticsSE_SO AnestheticsSO = ScriptableObject.CreateInstance<AnestheticsSE_SO>();
            AnestheticsSO._StatusID = StatusID;
            AnestheticsSO._EffectInfo = AnestheticsInfo;
            Object = AnestheticsSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = AnestheticsSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(AnestheticsSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Anesthetics.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class AnestheticsSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            int Amount = holder.m_ContentMain + holder.Restrictor;

            if ((args as DamageReceivedValueChangeException).amount < Amount)
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new AnestheticsValueModifier((args as DamageReceivedValueChangeException).amount));
            }
            if ((args as DamageReceivedValueChangeException).amount >= Amount)
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new AnestheticsValueModifier(Amount));
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            this.ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class AnestheticsValueModifier : IntValueModifier
    {
        public readonly int toNumb;

        public AnestheticsValueModifier(int toNumb)
          : base(70)
        {
            this.toNumb = toNumb;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                return Math.Max(value - this.toNumb, 0);
            }
            return Math.Max(value, 0);
        }
    }
    public class ApplyAnestheticsEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Anesthetics.Object;
            if (Anesthetics.Object == null || Anesthetics.Object.Equals(null)) Debug.LogError("CALL \"Anesthetics.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
