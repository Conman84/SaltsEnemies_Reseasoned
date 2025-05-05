using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class TraitorCondition : EffectorConditionSO
    {
        static Sprite _icon;
        public static Sprite Icon
        {
            get
            {
                if (_icon == null) _icon = ResourceLoader.LoadSprite("TraitorPassive.png");
                return _icon;
            }
        }
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is bool allies)
            {
                if (!allies)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(PriorityRootActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<TraitorPassiveEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Sides)
                    }), 1, Slots.Self) }, effector as IUnit));
                }
                else
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { Effects.GenerateEffect(PriorityRootActionEffect.Create(new EffectInfo[]
                    {
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<TraitorPassiveEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Slots.Front)
                    }), 1, Slots.Self) }, effector as IUnit));
                }
            }
            return false;
        }
    }
    public static class TraitorHandler
    {
        public static TriggerCalls Call => (TriggerCalls)7383904;
        public static string Type => "Traitor_PA";
        public static DamageInfo EnemyCombat_Damage(Func<EnemyCombat, int, IUnit, string, int, bool, bool, bool, string, DamageInfo> orig, EnemyCombat self, int amount, IUnit killer, string deathTypeID, int targetSlotOffset, bool addHealthMana, bool directDamage, bool ignoresShield, string specialDamage)
        {
            DamageInfo ret = orig(self, amount, killer, deathTypeID, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
            if (killer != null && ret.damageAmount > 0 && self.CurrentHealth > 0)
            {
                CombatManager.Instance.PostNotification(Call.ToString(), self, self.IsUnitCharacter == killer.IsUnitCharacter);
            }
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(TraitorHandler).GetMethod(nameof(EnemyCombat_Damage), ~BindingFlags.Default));
        }
    }
    public class TraitorPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Traitor", TraitorCondition.Icon));
            exitAmount = 0;
            return true;
        }
    }
    public class HasInfestationEffectCondition : EffectConditionSO
    {
        public bool ShouldHave;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString()) == ShouldHave;
        }
        public static HasInfestationEffectCondition Create(bool shouldHave)
        {
            HasInfestationEffectCondition ret = ScriptableObject.CreateInstance<HasInfestationEffectCondition>();
            ret.ShouldHave = shouldHave;
            return ret;
        }
    }
    public class AddInfestationEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Infestation", Passives.Infestation1.passiveIcon));
                    if (target.Unit.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString())) target.Unit.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.InfestationPA.ToString(), target.Unit.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.InfestationPA.ToString()) + 1);
                    else target.Unit.AddPassiveAbility(Passives.Infestation1);
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class ChanceZeroDamageEffect : DamageEffect
    {
        public float Chance;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, UnityEngine.Random.Range(0f, 1f) < Chance ? 0 : entryVariable, out int exi))
                    exitAmount += exi;
            }
            return exitAmount > 0;
        }
        public static ChanceZeroDamageEffect Create(float chance)
        {
            ChanceZeroDamageEffect ret = ScriptableObject.CreateInstance<ChanceZeroDamageEffect>();
            ret.Chance = chance;
            return ret;
        }
    }
}
