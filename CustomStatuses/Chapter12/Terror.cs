using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Terror
    {
        public static string StatusID => "Terror_ID";
        public static string Intent => "Status_Terror";
        public static string Trigger => "Terror_Applied";
        public static TerrorSE_SO Object;
        public static void Add()
        {
            StatusEffectInfoSO TerrorInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            TerrorInfo.icon = ResourceLoader.LoadSprite("terror.png");
            TerrorInfo._statusName = "Terror";
            TerrorInfo._description = "At the end of each turn, if this unit is facing another unit, decrease their maximum health by 1. \nOnly one unit may have Terror at a time.";
            TerrorInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            TerrorInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            TerrorInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Cursed_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            TerrorSE_SO TerrorSO = ScriptableObject.CreateInstance<TerrorSE_SO>();
            TerrorSO._StatusID = StatusID;
            TerrorSO._EffectInfo = TerrorInfo;
            Object = TerrorSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = TerrorSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(TerrorSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("terror.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class TerrorSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override bool TryUseNumberOnPopUp => false;
        public override int MinimumRequiredToApply => 0;
        public override StatusEffect_Holder GenerateHolder(int content, int restrictor)
        {
            return new StatusEffect_Holder(this);
        }
        public override int GetStatusContent(StatusEffect_Holder holder)
        {
            return 1;
        }
        public override bool CanBeRemoved(StatusEffect_Holder holder)
        {
            return true;
        }
        public override string DisplayText(StatusEffect_Holder holder)
        {
            string text = "";
            if (holder.Restrictor > 0)
            {
                text = text + "(" + holder.Restrictor + ")";
            }

            return text;
        }
        public override bool TryAddContent(StatusEffect_Holder holder, int content, int restrictor)
        {
            return false;
        }
        public override bool TryIncreaseContent(StatusEffect_Holder holder, int amount)
        {
            return false;
        }
        public override int JustRemoveAllContent(StatusEffect_Holder holder)
        {
            return 0;
        }
        public override void DettachRestrictor(StatusEffect_Holder holder, IStatusEffector effector)
        {
        }
        public override bool TryRemoveStatusEffect(StatusEffect_Holder holder, IStatusEffector effector)
        {
            return false;
        }

        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.PostNotification(Terror.Trigger, null, null);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, Terror.Trigger, null);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, Terror.Trigger, null);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
        }
        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (sender is IUnit unit)
            {
                CombatManager.Instance.AddSubAction(new EffectAction(Effects.GenerateEffect(MaxHealth.Decrease, 1, Slots.Self, IsFrontTargetCondition.Create(true)).SelfArray(), unit));
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            (sender as IStatusEffector).RemoveStatusEffect(holder.StatusID);
        }
    }
    public class ApplyTerrorEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Terror.Object;
            if (Terror.Object == null || Terror.Object.Equals(null)) Terror.Add();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class ApplyTerrorIfNoneEffect : ApplyTerrorEffect
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;

            bool anybody = false;
            if (caster.IsUnitCharacter)
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.ContainsStatusEffect(Terror.StatusID)) anybody = true;
                }
            }
            else
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (chara.ContainsStatusEffect(Terror.StatusID)) anybody = true;
                }
            }
            if (anybody) return false;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
