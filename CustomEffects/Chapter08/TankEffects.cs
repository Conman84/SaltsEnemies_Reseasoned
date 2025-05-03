using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

/*I DID THIS*/
//call FireNoReduce.Setup() in awake

/*I DO ALL THIS TOO*/
//When creating the ColdBlooded passive for the tank, make sure the m_PassiveID = FireNoReduce.PassiveID
//also remove Steel from the tank it sucks as a passive
//The original code calls TankHandler.BadStatus as an effect. just instantiate RandomNegativeStatusEffect instead

//Make its health red

namespace SaltEnemies_Reseasoned
{
    public static class FireNoReduce
    {
        public static string PassiveID => "Salt_Moon_PA";
        public static void Setup()
        {
            IDetour MoonIdetour = new Hook(typeof(FieldEffect_SO).GetMethod(nameof(FieldEffect_SO.ReduceDuration), ~BindingFlags.Default), typeof(FireNoReduce).GetMethod(nameof(ReduceDuration), ~BindingFlags.Default));
        }
        public static void ReduceDuration(Action<FieldEffect_SO, FieldEffect_Holder> orig, FieldEffect_SO self, FieldEffect_Holder holder)
        {
            if (holder.Effector is CombatSlot slot && slot.HasUnit && self is OnFireFE_SO)
            {
                if (slot.Unit.ContainsPassiveAbility(PassiveID))
                {
                    return;
                }
            }
            orig(self, holder);
        }
    }
    public class ColdHealCondition : EffectorConditionSO
    {
        [SerializeField]
        public bool _passIfTrue = false;

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.damageTypeID == CombatType_GameIDs.Dmg_Fire.ToString())
                {
                    hitBy.AddModifier(new ColdFireHealMod(effector as IUnit));
                    return true;
                }
            }
            return false;

        }
    }
    public class ColdFireHealMod : IntValueModifier
    {
        public readonly IUnit unit;

        public ColdFireHealMod(IUnit unit)
          : base(800)
        {
            this.unit = unit;
        }

        public override int Modify(int value)
        {
            value *= -1;
            if (this.unit.CurrentHealth - value > this.unit.MaximumHealth)
            {
                value = this.unit.CurrentHealth - this.unit.MaximumHealth;
            }
            return value;
        }
    }
    public class ApplyRandomNegativeStatus : StatusEffect_Apply_Effect
    {
        public bool UsePreviousExitValueForNewEntry;
        public StatusEffect_SO GrabRand()
        {
            List<StatusEffect_SO> ret = new List<StatusEffect_SO>();
            foreach (StatusEffect_SO status in LoadedDBsHandler.StatusFieldDB._StatusEffects.Values)
            {
                if (!status.IsPositive) ret.Add(status);
            }
            if (ret.Count <= 0) return null;
            return ret.GetRandom();
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int effectsRan = 0;
            foreach (TargetSlotInfo target in targets)
            {
                for (int i = 0; i < entryVariable; i++)
                {
                    try
                    {
                        _Status = GrabRand();
                        if (_Status != null && !_Status.Equals(null))
                        {
                            int num = 1;
                            if (_Status.StatusID == Pale.StatusID) num *= 10;
                            if (base.PerformEffect(stats, caster, new TargetSlotInfo[] { target }, areTargetSlots, UsePreviousExitValueForNewEntry ? PreviousExitValue : num, out int exi))
                                exitAmount += exi;
                            effectsRan++;
                        }
                    }
                    catch
                    {
                        Debug.LogError("of course its fucking this");
                    }
                }
            }
            return effectsRan > 0;
        }
    }
    public class RandomNegativeStatusEffect : EffectSO
    {
        static ApplyOilSlickedEffect _oil;
        public static ApplyOilSlickedEffect Oil
        {
            get
            {
                if (_oil == null)
                {
                    _oil = ScriptableObject.CreateInstance<ApplyOilSlickedEffect>();
                }
                return _oil;
            }
        }
        static ApplyLeftEffect _left;
        public static ApplyLeftEffect Left
        {
            get
            {
                if (_left == null)
                {
                    _left = ScriptableObject.CreateInstance<ApplyLeftEffect>();
                }
                return _left;
            }
        }//moves you left once on moving
        static ApplyFrailEffect _frail;
        public static ApplyFrailEffect Frail
        {
            get
            {
                if (_frail == null)
                {
                    _frail = ScriptableObject.CreateInstance<ApplyFrailEffect>();
                }
                return _frail;
            }
        }
        static ApplyScarsEffect _scar;
        public static ApplyScarsEffect Scar
        {
            get
            {
                if (_scar == null)
                {
                    _scar = ScriptableObject.CreateInstance<ApplyScarsEffect>();
                }
                return _scar;
            }
        }
        static ApplyCursedEffect _cursed;
        public static ApplyCursedEffect Cursed
        {
            get
            {
                if (_cursed == null)
                {
                    _cursed = ScriptableObject.CreateInstance<ApplyCursedEffect>();
                }
                return _cursed;
            }
        }
        static ApplyPaleByTenEffect _pale;
        public static ApplyPaleByTenEffect Pale
        {
            get
            {
                if (_pale == null)
                {
                    _pale = ScriptableObject.CreateInstance<ApplyPaleByTenEffect>();
                }
                return _pale;
            }
        }
        static ApplyInvertedEffect _inverted;
        public static ApplyInvertedEffect Inverted
        {
            get
            {
                if (_inverted == null)
                {
                    _inverted = ScriptableObject.CreateInstance<ApplyInvertedEffect>();
                }
                return _inverted;
            }
        }//direct healing --> indirect damage; direct damge --> indirect healing
        static ApplyRupturedEffect _rupture;
        public static ApplyRupturedEffect Rupture
        {
            get
            {
                if (_rupture == null)
                {
                    _rupture = ScriptableObject.CreateInstance<ApplyRupturedEffect>();
                }
                return _rupture;
            }
        }
        static ApplyAcidEffect _acid;
        public static ApplyAcidEffect Acid
        {
            get
            {
                if (_acid == null)
                {
                    _acid = ScriptableObject.CreateInstance<ApplyAcidEffect>();
                }
                return _acid;
            }
        }
        static ApplyMutedEffect _muted;
        public static ApplyMutedEffect Muted
        {
            get
            {
                if (_muted == null)
                {
                    _muted = ScriptableObject.CreateInstance<ApplyMutedEffect>();
                }
                return _muted;
            }
        }
        static ApplyDivineSacrificeEffect _ds;
        public static ApplyDivineSacrificeEffect DS
        {
            get
            {
                if (_ds == null)
                {
                    _ds = ScriptableObject.CreateInstance<ApplyDivineSacrificeEffect>();
                }
                return _ds;
            }
        }
        static ApplyDrowningEffect _drown;
        public static ApplyDrowningEffect Drown
        {
            get
            {
                if (_drown == null)
                {
                    _drown = ScriptableObject.CreateInstance<ApplyDrowningEffect>();
                }
                return _drown;
            }
        }
        static ApplyTerrorEffect _terror;
        public static ApplyTerrorEffect Terror
        {
            get
            {
                if (_terror == null)
                {
                    _terror = ScriptableObject.CreateInstance<ApplyTerrorEffect>();
                }
                return _terror;
            }
        }
        static ApplyPimplesEffect _pimples;
        public static ApplyPimplesEffect Pimples
        {
            get
            {
                if (_pimples == null)
                {
                    _pimples = ScriptableObject.CreateInstance<ApplyPimplesEffect>();
                }
                return _pimples;
            }
        }
        static ApplyLinkedEffect _linked;
        public static ApplyLinkedEffect Linked
        {
            get
            {
                if (_linked == null)
                {
                    _linked = ScriptableObject.CreateInstance<ApplyLinkedEffect>();
                }
                return _linked;
            }
        }
        public static EffectSO[] Array => new EffectSO[] { Oil, Left, Frail, Scar, Cursed, Pale, Inverted, Rupture, Acid, Muted, DS, /*Drown, Terror, Pimples,*/ Linked };//pimples,,, salted, paranoia

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                List<EffectSO> list = new List<EffectSO>(Array);
                int picking = UnityEngine.Random.Range(0, list.Count);
                EffectSO first = list[picking];
                int choosing = UnityEngine.Random.Range(0, list.Count);
                while (choosing == picking)
                {
                    choosing = UnityEngine.Random.Range(0, list.Count);
                }
                EffectSO second = list[choosing];
                first.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 1, out int exiting);
                exitAmount += exiting;
            }
            return exitAmount > 0;
        }
    }
    public class ShowBacklashPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Backlash", ResourceLoader.LoadSprite("BacklashPassive.png")));
            return true;
        }
    }
    public class BacklashCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference reference)
            {
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[]
                {
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowBacklashPassiveEffect>()),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), reference.value, Targeting.Slot_SelfAll)
                }, effector as IUnit));
            }
            return false;
        }
    }
    public class SetStoreValueTargetEffect : EffectSO
    {
        public string value;
        public bool removeIfHasnt;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (entryVariable == 0 && removeIfHasnt) if (!target.Unit.TryGetStoredData(value, out var holder, false)) continue;
                    target.Unit.SimpleSetStoredValue(value, entryVariable);
                }
            }
            return true;
        }
        public static SetStoreValueTargetEffect Create(string value, bool removeIfHasnt = false)
        {
            SetStoreValueTargetEffect ret = ScriptableObject.CreateInstance<SetStoreValueTargetEffect>();
            ret.value = value;
            ret.removeIfHasnt = removeIfHasnt;
            return ret;
        }
    }
}
