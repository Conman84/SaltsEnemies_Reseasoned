using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Determined
    {
        public static string HealType => "";
        public static string StatusID => "Determined_ID";
        public static string Intent => "Status_Determined";
        public static DeterminedSE_SO Object;
        public static void Add()
        {
            //Debug.LogWarning("Determined.Add. I've left some leftover code for the damage color setting in case you want to use it, for the heal color you'd just copy the code and change DamageType --> HealType");
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
            StatusEffectInfoSO DeterminedInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            DeterminedInfo.icon = ResourceLoader.LoadSprite("Determined.png");
            DeterminedInfo._statusName = "Determined";
            DeterminedInfo._description = "Upon dying, prevent death and heal this character however many stacks of Determined they have. Remove all Determined. Decreases by 1 at the start of each turn. Does not work on Cursed, Dying or Inanimate units.";
            DeterminedInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo._applied_SE_Event;
            DeterminedInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            DeterminedInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            DeterminedSE_SO DeterminedSO = ScriptableObject.CreateInstance<DeterminedSE_SO>();
            DeterminedSO._StatusID = StatusID;
            DeterminedSO._EffectInfo = DeterminedInfo;
            Object = DeterminedSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = DeterminedSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(DeterminedSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Determined.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class DeterminedSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.CanDie.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.CanDie.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                if (unit.ContainsPassiveAbility(PassiveType_GameIDs.Dying.ToString()) || unit.ContainsPassiveAbility(PassiveType_GameIDs.Inanimate.ToString()) || unit.ContainsStatusEffect(StatusField_GameIDs.Cursed_ID.ToString())) return;
            }
            BooleanReference reference = args as BooleanReference;
            if (reference == null)
                return;
            reference.value = false;//THIS SPECIFIC TO MY STATUS EFFECT; YOU DONT NEED IT
            CombatManager.Instance.AddSubAction(new PerformStatusEffectAction(holder, sender, args, false));
            //PUT THE ABOVE LINE IN YOUR IF STATEMENT
        }
        public override void OnSubActionTrigger(StatusEffect_Holder holder, object sender, object args, bool stateCheck)
        {
            int Amount = holder.m_ContentMain + holder.Restrictor;
            int restoreVal = Amount;
            (sender as IUnit).Heal(restoreVal, null, true, Determined.HealType);//THIS STUFF IS SPECIFIC TO MY STATUS EFFECT
            (sender as IStatusEffector).RemoveStatusEffect(holder.StatusID);//THIS IS THE DELETE DURATION LINE
            if ((sender as IUnit).CurrentHealth <= 0) (sender as IUnit).DirectDeath(null);
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            this.ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class ApplyDeterminedEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Determined.Object;
            if (Determined.Object == null || Determined.Object.Equals(null)) Debug.LogError("CALL \"Determined.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}