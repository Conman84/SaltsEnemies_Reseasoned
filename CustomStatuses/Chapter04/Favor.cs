using BrutalAPI;
using TMPro;
using UnityEngine;

//call Favor.Add() in awake

namespace SaltEnemies_Reseasoned
{
    public static class Favor
    {
        public static string StatusID => "Favor_ID";
        public static string Intent => "Status_Favor";
        public static string HealType => "Heal_Favor";
        public static string Trigger => "Favor_Applied";
        public static FavorSE_SO Object;
        public static void Add()
        {
            TMP_ColorGradient FavorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            Color32 paleColor = new Color32(136, 0, 255, 255);
            FavorGradient.bottomLeft = paleColor;
            FavorGradient.bottomRight = paleColor;
            FavorGradient.topLeft = paleColor;
            FavorGradient.topRight = paleColor;
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(HealType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[HealType] = FavorGradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(HealType, FavorGradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(HealType)) LoadedDBsHandler.CombatDB.m_SoundPool[HealType] = LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Heal_Linked.ToString()];
            else LoadedDBsHandler.CombatDB.AddNewSound(HealType, LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Heal_Linked.ToString()]);


            StatusEffectInfoSO LeftInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            LeftInfo.icon = ResourceLoader.LoadSprite("Favor.png");
            LeftInfo._statusName = "Favor";
            LeftInfo._description = "At the end of each turn, heal this unit 1-2. If this unit is healed from any other source than this status effect, Curse them, and deal an Agonizing amount of indirect damage to them. Only one unit may be Favoured at a time.";
            LeftInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.AppliedSoundEvent;
            LeftInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            LeftInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.DivineProtection_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            FavorSE_SO FavorSO = ScriptableObject.CreateInstance<FavorSE_SO>();
            FavorSO._StatusID = StatusID;
            FavorSO._EffectInfo = LeftInfo;
            Object = FavorSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = FavorSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(FavorSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Favor.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class FavorSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => true;
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
            CombatManager.Instance.PostNotification(Favor.Trigger, null, null);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_02, Favor.Trigger, caller);
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_02, Favor.Trigger, caller);
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_03, TriggerCalls.OnTurnFinished.ToString(), caller);
        }
        public bool selfHealing;
        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            if (!selfHealing)
            {
                DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
                indirect._indirect = true;
                EffectInfo effort1 = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Targeting.Slot_SelfSlot);
                EffectInfo effort2 = Effects.GenerateEffect(indirect, UnityEngine.Random.Range(7, 11), Targeting.Slot_SelfSlot);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { effort1, effort2 }, sender as IUnit));
                (sender as IStatusEffector).RemoveStatusEffect(holder.StatusID);
            }
        }
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {

            (sender as IStatusEffector).RemoveStatusEffect(holder.StatusID);
        }
        public override void OnEventCall_03(StatusEffect_Holder holder, object sender, object args)
        {
            selfHealing = true;
            (sender as IUnit).Heal(UnityEngine.Random.Range(1, 3), null, true, Favor.HealType);
            selfHealing = false;
        }
    }
    public class ApplyFavorEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Favor.Object;
            if (Favor.Object == null || Favor.Object.Equals(null)) Debug.LogError("CALL \"Favor.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class ApplyFavorSingleEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Favor.Object;
            _JustOneRandomTarget = true;
            if (Favor.Object == null || Favor.Object.Equals(null)) Debug.LogError("CALL \"Favor.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
