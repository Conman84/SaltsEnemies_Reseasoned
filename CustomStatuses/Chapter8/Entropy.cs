using BrutalAPI;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Entropy
    {
        public static string StatusID => "Salt_Entropy_ID";
        public static string Intent => "Status_Salt_Entropy";
        public static string Limit => "Salt_Entropy_SE_Internal";
        public static string TriggerCall => "Entropy_Trigger";
        public static EntropySE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO EntropyInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            EntropyInfo.icon = ResourceLoader.LoadSprite("EntropyIcon.png");
            Debug.LogWarning("Entropy.Add. put the right sprite here");
            EntropyInfo._statusName = "Entropy";
            EntropyInfo._description = "Get the description";
            Debug.LogWarning("Entropy.Add. get the status description");
            EntropyInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Gutted_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            EntropyInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Gutted_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            EntropyInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Gutted_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            EntropySE_SO EntropySO = ScriptableObject.CreateInstance<EntropySE_SO>();
            EntropySO._StatusID = StatusID;
            EntropySO._EffectInfo = EntropyInfo;
            Object = EntropySO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = EntropySO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(EntropySO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("EntropyIcon.png");
            Debug.LogWarning("Entropy.Add. set the right sprite for the intent also");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class EntropySE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            (caller as IUnit).SimpleSetStoredValue(Entropy.Limit, 30);
            Thread timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
            timerThread.Start(caller as IUnit);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, Entropy.TriggerCall, caller);
        }
        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, Entropy.TriggerCall, caller);
        }
        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if ((sender as IUnit).IsAlive && (sender as IUnit).CurrentHealth > 0)
            {
                (sender as IUnit).Damage(1, null, DeathType_GameIDs.None.ToString(), -1, false, false, true);
                int reduction = UnityEngine.Random.Range(3, 10);
                int timing = (sender as IUnit).SimpleGetStoredValue(Entropy.Limit) - reduction;
                int time = Math.Max(timing, 1);
                (sender as IUnit).SimpleSetStoredValue(Entropy.Limit, time);
                Thread timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
                timerThread.Start(sender as IUnit);
                ReduceDuration(holder, sender as IStatusEffector);
            }
        }
        public static void AddTurnsThread(object obj)
        {
            if (obj is IUnit unit)
            {
                int timing = unit.SimpleGetStoredValue(Entropy.Limit);
                Debug.Log(timing);
                if (!unit.Equals(null) && unit.IsAlive)
                {
                    for (int i = 0; i < timing; i++)
                    {
                        Thread.Sleep(1000);
                    }
                    if (!unit.Equals(null) && unit.IsAlive && unit.ContainsStatusEffect(Entropy.StatusID))
                    {
                        CombatManager.Instance.PostNotification(Entropy.TriggerCall, unit, null);
                    }

                }
            }
        }
    }
    public class ApplyEntropyEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Entropy.Object;
            if (Entropy.Object == null || Entropy.Object.Equals(null)) Entropy.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
