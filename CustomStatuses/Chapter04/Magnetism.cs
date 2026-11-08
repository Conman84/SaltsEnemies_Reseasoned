using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Magnetism
    {
        public static string StatusID => "Magnetism_ID";
        public static string Intent => "Status_Magnetism";
        public static StatusEffect_SO Object;

        public static string DamageType => "Damage_Magnetism";

        public static void Add()
        {
            TMP_ColorGradient gradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            gradient.bottomLeft = new Color32(172, 50, 50, 255);//brightred
            gradient.bottomRight = new Color32(75, 18, 18, 255);//darkred
            gradient.topRight = new Color32(107, 107, 164, 255);//brightblue
            gradient.topLeft = new Color32(23, 23, 48, 255);//darkblue
            //note: this is the color of Pale damage in lobotomy corporation. it MUST be this color bc im autistic like that. feel free to change the sounds though
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[DamageType] = gradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(DamageType, gradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_SoundPool[DamageType] = "event:/Hawthorne/Misc3/KarmaDamage";
            else LoadedDBsHandler.CombatDB.AddNewSound(DamageType, "event:/Hawthorne/Misc3/KarmaDamage");

            StatusEffectInfoSO magnetismInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            magnetismInfo.icon = ResourceLoader.LoadSprite("MagnetismIcon.png");
            magnetismInfo._statusName = "Magnetism";
            magnetismInfo._description = "At the end of the player's turn, take direct damage equal to Magnetism.\nAll Magnetism is transferred to the target upon attacking.\nAll Magnetism is transferred ot the attacker upon being damaged, if the attacker did not already have Magnetism.";
            magnetismInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo._applied_SE_Event;
            magnetismInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            magnetismInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            MagnetismSE_SO magnetismSO = ScriptableObject.CreateInstance<MagnetismSE_SO>();
            magnetismSO._StatusID = StatusID;
            magnetismSO._EffectInfo = magnetismInfo;
            Object = magnetismSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = magnetismSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(magnetismSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("MagnetismIcon.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }

    public class MagnetismSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter) CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
            else CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnPlayerTurnEnd_ForEnemy.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_03, TriggerCalls.OnDirectDamaged.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter) CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnTurnFinished.ToString(), caller);
            else CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnPlayerTurnEnd_ForEnemy.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_03, TriggerCalls.OnDirectDamaged.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            CombatManager.Instance.AddSubAction(new MagnetismDamageAction(sender as IUnit, holder.m_ContentMain + holder.Restrictor));
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is DamageDealtValueChangeException var && var.amount > 0)
            {
                if (var.casterUnit != null && var.damagedUnit != null)
                {
                    CombatManager.Instance.AddSubAction(new TransferMagnetismAction(var.damagedUnit, var.casterUnit, holder.m_ContentMain));
                }
            }
        }
        public override void OnEventCall_03(StatusEffect_Holder holder, object sender, object args)
        {
            if (args is IntegerReference_Damage var && var.value > 0)
            {
                if (var.possibleSourceUnit != null && var.directDamage && var.damagedUnit != null)
                {
                    if (var.possibleSourceUnit.ContainsStatusEffect(Magnetism.StatusID)) return;

                    int num = var.damagedUnit.TryRemoveStatusEffect(Magnetism.StatusID);

                    CombatManager.Instance.AddSubAction(new ApplyMagnetismByAmtAction(var.possibleSourceUnit, num));
                }
            }
        }
    }
    public class TransferMagnetismAction : CombatAction
    {
        public IUnit target;
        public IUnit source;
        public int amt;
        public TransferMagnetismAction(IUnit target, IUnit source, int amt)
        {
            this.target = target;
            this.source = source;
            this.amt = amt;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            source.TryRemoveStatusEffect(Magnetism.StatusID);
            target.ApplyStatusEffect(Magnetism.Object, amt);
            yield return null;
        }
    }
    public class ApplyMagnetismByAmtAction : CombatAction
    {
        public IUnit target;
        public int amt;
        public ApplyMagnetismByAmtAction(IUnit target, int amount)
        {
            this.target = target;
            amt = amount;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            target.ApplyStatusEffect(Magnetism.Object, amt);
            yield return null;
        }
    }
    public class MagnetismDamageAction : CombatAction
    {
        public IUnit victim;
        public int amt;
        public MagnetismDamageAction(IUnit _victim, int _amt)
        {
            victim = _victim;
            amt = _amt;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            victim.Damage(amt, null, "Magnetism", -1, true, true, false, Magnetism.DamageType);
            yield return null;
        }
    }
    public class ApplyMagnetismEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Magnetism.Object;
            if (Magnetism.Object == null || Magnetism.Object.Equals(null)) Debug.LogError("CALL \"Pale.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
