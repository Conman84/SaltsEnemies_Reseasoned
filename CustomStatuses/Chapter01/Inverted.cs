using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Inverted
    {
        public static string DamageType => "";
        public static string HealType => "";
        public static string StatusID => "Inverted_ID";
        public static string Intent => "Status_Inverted";
        public static InvertedSE_SO Object;
        public static void Add()
        {
            //Debug.LogWarning("Inverted.Add. I've left some leftover code for the damage color setting in case you want to use it, for the heal color you'd just copy the code and change DamageType --> HealType");
            /*TMP_ColorGradient PaleGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            UnityEngine.Color32 paleColor = new UnityEngine.Color32(63, 205, 189, 255);
            PaleGradient.bottomLeft = paleColor;
            PaleGradient.bottomRight = paleColor;
            PaleGradient.topLeft = paleColor;
            PaleGradient.topRight = paleColor;
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[DamageType] = PaleGradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(DamageType, PaleGradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_SoundPool[DamageType] = LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Linked.ToString()];
            else LoadedDBsHandler.CombatDB.AddNewSound(DamageType, LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Linked.ToString()]);
            */
            StatusEffectInfoSO InvertedInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            InvertedInfo.icon = ResourceLoader.LoadSprite("Inverted.png");
            InvertedInfo._statusName = "Inverted";
            InvertedInfo._description = "All direct damage dealt to this unit is converted into indirect healing. All direct healing received by this unit is converted into indirect damage. Reduce by 1 at the start of each turn.";
            InvertedInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo._applied_SE_Event;
            InvertedInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            InvertedInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            InvertedSE_SO InvertedSO = ScriptableObject.CreateInstance<InvertedSE_SO>();
            InvertedSO._StatusID = StatusID;
            InvertedSO._EffectInfo = InvertedInfo;
            Object = InvertedSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = InvertedSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(InvertedSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Inverted.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class InvertedSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                if (args is DamageReceivedValueChangeException hitBy)
                {
                    if (hitBy.directDamage == true)
                    {
                        if (unit.ContainsStatusEffect(StatusField_GameIDs.DivineProtection_ID.ToString()))
                        {
                            hitBy.AddModifier(new ImmZeroMod());
                            unit.Heal(hitBy.amount, null, false, Inverted.HealType);
                        }
                        else
                        {
                            hitBy.AddModifier(new InvertedDamageModifier(unit));
                        }
                    }
                }
                if (args is CanHealReference healing)
                {
                    if (healing.directHeal == true)
                    {
                        healing.value = false;
                        unit.Damage(healing.healAmount, null, DeathType_GameIDs.Basic.ToString(), -1, false, false, true, Inverted.DamageType);
                    }
                }
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            this.ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class InvertedDamageModifier : IntValueModifier
    {
        public readonly int amount;
        public readonly IUnit unit;
        public InvertedDamageModifier(IUnit unit)
            : base(77)
        {
            this.unit = unit;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                unit.Heal(value, null, false, Inverted.HealType);
            }
            return 0;
        }
    }
    public class ApplyInvertedEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Inverted.Object;
            if (Inverted.Object == null || Inverted.Object.Equals(null)) Debug.LogError("CALL \"Inverted.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}