using UnityEngine;
using BrutalAPI;

namespace SaltEnemies_Reseasoned
{
    public static class Power
    {
        public static string StatusID => "Power_ID";
        public static string Intent => "Status_Power";
        public static PowerSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO PowerInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            PowerInfo.icon = ResourceLoader.LoadSprite("Power");
            PowerInfo._statusName = "Power";
            PowerInfo._description = "Increase direct damage dealth by the amount of Power. 50% chance to decrease by 2-3 on activation.";//note: i changed it. cuz the old way it decreased sucked
            PowerInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo._applied_SE_Event;
            PowerInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            PowerInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Focused_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            PowerSE_SO PowerSO = ScriptableObject.CreateInstance<PowerSE_SO>();
            PowerSO._StatusID = StatusID;
            PowerSO._EffectInfo = PowerInfo;
            Object = PowerSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = PowerSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(PowerSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Power");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class PowerSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnWillApplyDamage.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnWillApplyDamage.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            int Amount = holder.m_ContentMain + holder.Restrictor;
            (args as DamageDealtValueChangeException).AddModifier((IntValueModifier)new PowerValueModifier(Amount));
            ReduceDuration(holder, sender as IStatusEffector);
        }
        public override void ReduceDuration(StatusEffect_Holder holder, IStatusEffector effector)
        {
            if (Random.Range(0f, 1f) < 0.5f) return;
            if (CanReduceDuration)
            {
                int contentMain = holder.m_ContentMain;
                holder.m_ContentMain = Mathf.Max(0, contentMain - Random.Range(2, 4));
                if (!TryRemoveStatusEffect(holder, effector) && contentMain != holder.m_ContentMain)
                {
                    effector.StatusEffectValuesChanged(_StatusID, holder.m_ContentMain - contentMain, doesPopUp: true);
                }
            }
        }
    }
    public class PowerValueModifier : IntValueModifier
    {
        public readonly int toPow;

        public PowerValueModifier(int toPow)
          : base(69)
        {
            this.toPow = toPow;
        }

        public override int Modify(int value)
        {
            //if (value > 0)

            return value + this.toPow;

            //return value;
        }
    }
    public class ApplyPowerEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Power.Object;
            if (Power.Object == null || Power.Object.Equals(null)) Debug.LogError("CALL \"Power.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class ApplyPowerRangePlusOneEffect : ApplyPowerEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _RandomBetweenPrevious = true;
            PreviousExitValue = entryVariable;
            entryVariable++;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class ApplyPowerRangePlusThreeEffect : ApplyPowerEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _RandomBetweenPrevious = true;
            PreviousExitValue = entryVariable;
            entryVariable += 3;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
