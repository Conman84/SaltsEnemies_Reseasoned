using BrutalAPI;
using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TMPro;
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
            EntropyInfo._statusName = "Entropy";
            EntropyInfo._description = "Every 30 seconds, this unit receives 1 indirect damage; ignores Scars. \nUpon activation, speed up by 3-9 seconds and decrease Entropy by 1.";
            EntropyInfo._applied_SE_Event = "event:/Hawthorne/Misc/EntropyApply";
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
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);

            AddDamageType();

            Setup();
        }

        public static string DamageType => "Dmg_Entropy";
        public static void AddDamageType()
        {
            TMP_ColorGradient gradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            UnityEngine.Color32 color = Color.white;
            gradient.bottomLeft = color;
            gradient.bottomRight = color;
            gradient.topLeft = color;
            gradient.topRight = new Color32(225, 225, 225, 255);

            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[DamageType] = gradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(DamageType, gradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_SoundPool[DamageType] = "event:/Hawthorne/Misc/EntropyDmg";
            else LoadedDBsHandler.CombatDB.AddNewSound(DamageType, "event:/Hawthorne/Misc/EntropyDmg");
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(ScarsSE_SO).GetMethod(nameof(ScarsSE_SO.OnEventCall_01), ~System.Reflection.BindingFlags.Default), typeof(Entropy).GetMethod(nameof(ScarsSE_SO_OnEventCall_01), ~System.Reflection.BindingFlags.Default));
        }
        public static void ScarsSE_SO_OnEventCall_01(Action<ScarsSE_SO, StatusEffect_Holder, object, object> orig, ScarsSE_SO self, StatusEffect_Holder holder, object sender, object args)
        {
            if (args is DamageReceivedValueChangeException value && value.damageTypeID == Entropy.DamageType) return;
            orig(self, holder, sender, args);
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
            CombatManager.Instance.AddSubAction(new TriggerEntropyAction(this, holder, sender, args));
            return;
            if (sender is IUnit && (sender as IUnit).IsAlive && (sender as IUnit).CurrentHealth > 0)
            {
                (sender as IUnit).Damage(1, null, DeathType_GameIDs.None.ToString(), -1, false, false, true, Entropy.DamageType);
                int reduction = UnityEngine.Random.Range(3, 10);
                int timing = (sender as IUnit).SimpleGetStoredValue(Entropy.Limit) - reduction;
                int time = Math.Max(timing, 1);
                (sender as IUnit).SimpleSetStoredValue(Entropy.Limit, time);
                Thread timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
                timerThread.Start(sender as IUnit);
                if ((sender as IUnit).ContainsStatusEffect(holder.StatusID)) ReduceDuration(holder, sender as IStatusEffector);
            }
        }
        public class TriggerEntropyAction : CombatAction
        {
            public EntropySE_SO self;
            public StatusEffect_Holder holder;
            public object sender;
            public object args;
            public TriggerEntropyAction(EntropySE_SO self, StatusEffect_Holder holder, object sender, object args)
            {
                this.self = self;
                this.holder = holder;
                this.sender = sender;
                this.args = args;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                if (sender is IUnit && (sender as IUnit).IsAlive && (sender as IUnit).CurrentHealth > 0)
                {
                    self.ReduceDuration(holder, sender as IStatusEffector);
                    (sender as IUnit).Damage(1, null, DeathType_GameIDs.None.ToString(), -1, false, false, true, Entropy.DamageType);
                    if (!(sender as IUnit).ContainsStatusEffect(Entropy.StatusID)) yield break;
                    int reduction = UnityEngine.Random.Range(3, 10);
                    int timing = (sender as IUnit).SimpleGetStoredValue(Entropy.Limit) - reduction;
                    int time = Math.Max(timing, 1);
                    (sender as IUnit).SimpleSetStoredValue(Entropy.Limit, time);
                    Thread timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
                    timerThread.Start(sender as IUnit);
                }
            }
        }
        public static void AddTurnsThread(object obj)
        {
            if (CombatManager._instance == null || CombatManager._instance.Equals(null)) return;
            if (obj is IUnit unit)
            {
                if (!unit.Equals(null) && unit.IsAlive)
                {
                    int timing = unit.SimpleGetStoredValue(Entropy.Limit);
                    for (int i = 0; i < timing; i++)
                    {
                        Thread.Sleep(1000);
                        if (CombatManager._instance == null || CombatManager._instance.Equals(null)) return;
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
