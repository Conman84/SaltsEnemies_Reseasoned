using System;
using System.Collections.Generic;
using BrutalAPI;
using TMPro;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class Pale
    {
        public static string DamageType => "Dmg_Pale";
        public static string StatusID => "Pale_ID";
        public static string Intent => "Status_Pale";
        public static PaleSE_SO Object;
        public static void Add()
        {
            TMP_ColorGradient PaleGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            UnityEngine.Color32 paleColor = new UnityEngine.Color32(63, 205, 189, 255);
            PaleGradient.bottomLeft = paleColor;
            PaleGradient.bottomRight = paleColor;
            PaleGradient.topLeft = paleColor;
            PaleGradient.topRight = paleColor;
            //note: this is the color of Pale damage in lobotomy corporation. it MUST be this color bc im autistic like that. feel free to change the sounds though
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_TxtColorPool[DamageType] = PaleGradient;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(DamageType, PaleGradient);

            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(DamageType)) LoadedDBsHandler.CombatDB.m_SoundPool[DamageType] = LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Linked.ToString()];
            else LoadedDBsHandler.CombatDB.AddNewSound(DamageType, LoadedDBsHandler.CombatDB.m_SoundPool[CombatType_GameIDs.Dmg_Linked.ToString()]);

            StatusEffectInfoSO PaleInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
            PaleInfo.icon = ResourceLoader.LoadSprite("Pale.png");
            PaleInfo._statusName = "Pale";
            PaleInfo._description = "Upon receiving indirect damage, take damage equal to Pale% of this unit's maximum health, ignoring damage prevention. \nPale triggers on enemies even if indirect damage received was 0.";
            PaleInfo._applied_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo._applied_SE_Event;
            PaleInfo._removed_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo.RemovedSoundEvent;
            PaleInfo._updated_SE_Event = LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusField_GameIDs.Linked_ID.ToString()]._EffectInfo.UpdatedSoundEvent;

            PaleSE_SO PaleSO = ScriptableObject.CreateInstance<PaleSE_SO>();
            PaleSO._StatusID = StatusID;
            PaleSO._EffectInfo = PaleInfo;
            Object = PaleSO;
            if (LoadedDBsHandler.StatusFieldDB._StatusEffects.ContainsKey(StatusID)) LoadedDBsHandler.StatusFieldDB._StatusEffects[StatusID] = PaleSO;
            else LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(PaleSO);

            IntentInfoBasic intentinfo = new IntentInfoBasic();
            intentinfo._color = Color.white;
            intentinfo._sprite = ResourceLoader.LoadSprite("Pale.png");
            if (LoadedDBsHandler.IntentDB.m_IntentBasicPool.ContainsKey(Intent)) LoadedDBsHandler.IntentDB.m_IntentBasicPool[Intent] = intentinfo;
            else LoadedDBsHandler.IntentDB.AddNewBasicIntent(Intent, intentinfo);
        }
    }
    public class PaleSE_SO : StatusEffect_SO
    {
        public override bool IsPositive => false;
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
        }

        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(holder.OnEventTriggered_01, TriggerCalls.OnBeingDamaged.ToString(), caller);
        }

        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            int Amount = holder.m_ContentMain + holder.Restrictor;

            if (args is DamageReceivedValueChangeException hitBy && hitBy.directDamage == false)
            {
                if (sender is IUnit unit)
                {
                    if (hitBy.damageTypeID == Pale.DamageType)
                    {
                        hitBy.AddModifier(new ImmZeroMod());
                        hitBy.AddModifier((IntValueModifier)new RemainSameTrigger(hitBy.amount));

                        RemoveStatusEffectEffect removeSelf = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                        removeSelf._status = this;
                        EffectInfo removeSelfEffect = Effects.GenerateEffect(removeSelf, 1, Targeting.Slot_SelfAll);
                        CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { removeSelfEffect }, unit));
                        return;
                    }



                    int maxHP = unit.MaximumHealth;
                    int currentHP = unit.CurrentHealth;
                    decimal gapMax = (decimal)maxHP;
                    int amount = Amount;
                    decimal gapThis = (decimal)amount;
                    gapMax *= gapThis;
                    gapMax /= 100;
                    decimal gapCeiling = Math.Ceiling(gapMax);
                    int hitting = (int)gapCeiling;
                    int newHP = currentHP - hitting;
                    IStatusEffector effector = sender as IStatusEffector;
                    if (unit is CharacterCombat)
                        hitBy.AddModifier((IntValueModifier)new PaleTrigger(newHP, this, effector, Amount));
                    else
                    {
                        EffectInfo soulHit = Effects.GenerateEffect(ScriptableObject.CreateInstance<PaleHarmEffect>(), Amount, Targeting.Slot_SelfAll);
                        CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { soulHit }, unit));
                    }

                }
            }

        }
    }
    public class ImmZeroMod : IntValueModifier
    {
        public readonly int amount;

        public ImmZeroMod()
            : base(5)
        {

        }

        public override int Modify(int value)
        {
            return 0;
        }
    }
    public class RemainSameTrigger : IntValueModifier
    {
        public readonly int amount;

        public RemainSameTrigger(
            int amount)
            : base(1000)
        {
            this.amount = amount;
        }

        public override int Modify(int value)
        {
            return amount;
        }
    }
    public class PaleTrigger : IntValueModifier
    {
        public readonly int newHP;
        public readonly PaleSE_SO paleSE;
        public readonly IStatusEffector effector;
        public readonly int amount;

        public PaleTrigger(
            int newHP,
            PaleSE_SO paleSE,
            IStatusEffector effector,
            int amount)
            : base(888)
        {
            this.newHP = newHP;
            this.paleSE = paleSE;
            this.effector = effector;
            this.amount = amount;
        }

        public override int Modify(int value)
        {
            if (value > 0 && this.effector is IUnit unit)
            {
                EffectInfo soulHit = Effects.GenerateEffect(ScriptableObject.CreateInstance<PaleHarmEffect>(), this.amount, Targeting.Slot_SelfAll);
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { soulHit }, unit));
            }
            return value;
        }
    }
    public class PaleHarmEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;

            int maxHP = caster.MaximumHealth;
            int currentHP = caster.CurrentHealth;
            decimal gapMax = (decimal)maxHP;
            int amount = entryVariable;
            decimal gapThis = (decimal)amount;
            gapMax *= gapThis;
            gapMax /= 100;
            decimal gapCeiling = Math.Ceiling(gapMax);
            decimal gapFloor = Math.Floor(gapMax);
            int hitMax = (int)gapCeiling;
            int hitMin = (int)gapFloor;
            int hitting = UnityEngine.Random.Range(hitMin, hitMax + 1);
            exitAmount += hitting;
            int newHP = currentHP - hitting;
            if (hitting > currentHP)
            {
                hitting = currentHP;
            }
            caster.Damage(hitting, null, DeathType_GameIDs.Basic.ToString(), -1, false, false, true, Pale.DamageType);


            return exitAmount > 0;
        }
    }
    public class ApplyPaleEffect : StatusEffect_Apply_Effect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            _Status = Pale.Object;
            if (Pale.Object == null || Pale.Object.Equals(null)) Debug.LogError("CALL \"Pale.Add();\" IN YOUR AWAKE");
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}