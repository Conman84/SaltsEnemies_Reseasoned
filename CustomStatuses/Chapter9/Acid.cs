using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class Acid
    {
        public static string DamageType => "Dmg_Acid";
        public static string StatusID => "Acid_ID";
        public static string Intent => "Status_Acid";
        public static AcidSE_SO Object;
        public static void Add()
        {
            TMP_ColorGradient acidGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            Color32 secondcolor = new Color32(81, 209, 81, 255);
            Color32 firstcolor = new Color32(46, 155, 46, 255);
            acidGradient.bottomLeft = secondcolor;
            acidGradient.bottomRight = firstcolor;
            acidGradient.topLeft = firstcolor;
            acidGradient.topRight = secondcolor;
            //note: this is the color of Pale damage in lobotomy corporation. it MUST be this color bc im autistic like that. feel free to change the sounds though
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[DamageType] = acidGradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(DamageType, acidGradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_SoundPool[DamageType] = LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Linked.ToString()];
            else LoadedDBsHandler.CombatDB.AddNewSound(DamageType, LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Ruptured.ToString()]);

            StatusEffectInfoSO AcidInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            AcidInfo.icon = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Acid.Add. put the right sprite here");
            AcidInfo._statusName = "Acid";
            AcidInfo._description = "On using an ability, take 3 indirect damage. Reduce Acid by 1 at the end of each turn.";
            Debug.LogError("Acid.Add. get the status description");
            AcidInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo._applied_SE_Event;
            AcidInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            AcidInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Ruptured_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            AcidSE_SO AcidSO = ScriptableObject.CreateInstance<AcidSE_SO>();
            AcidSO._StatusID = StatusID;
            AcidSO._EffectInfo = AcidInfo;
            Object = AcidSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = AcidSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(AcidSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("idk.png");
            Debug.LogError("Acid.Add. set the right sprite for the intent also");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class AcidSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public static string SkipTick => "Acid_SkipTick_SE";
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            if (CombatManager.Instance._stats.IsPlayerTurn && caller.IsStatusEffectorCharacter)
            {
                (caller as IUnit).SimpleSetStoredValue(SkipTick, 1);
                CombatManager.Instance.AddRootAction(new RootActionAction(new AcidSkipTickAction()));
            }
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if ((sender as IUnit).SimpleGetStoredValue(SkipTick) > 0)
            {
                (sender as IUnit).SimpleSetStoredValue(SkipTick, 0);
                return;
            }
            CombatManager.Instance.AddSubAction(new AcidDamageAction(sender as IUnit));
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            ReduceDuration(holder, sender as IStatusEffector);
        }
    }
    public class AcidDamageAction : CombatAction
    {
        public IUnit victim;
        public AcidDamageAction(IUnit _victim)
        {
            victim = _victim;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            victim.Damage(3, null, DeathType_GameIDs.Basic.ToString(), -1, false, false, true, Acid.DamageType);
            yield return null;
        }
    }
    public class AcidSkipTickAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            foreach (CharacterCombat chara in stats.CharactersOnField.Values) chara.SimpleSetStoredValue(AcidSE_SO.SkipTick, 0);
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values) enemy.SimpleSetStoredValue(AcidSE_SO.SkipTick, 0);
            yield return null;
        }
    }
    public class ApplyAcidEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Acid.Object;
            if (Acid.Object == null || Acid.Object.Equals(null)) Debug.LogError("CALL \"Acid.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
