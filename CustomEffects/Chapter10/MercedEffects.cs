using BrutalAPI;
using FMODUnity;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;

//call PreservedHandler.Setup() in awake
//call CountFibonacci.Add() in awake
//make sure Merced's Preserved m_Passive_ID = "Merced_Preserved_PA"

//when setting up merced, make sure UnitTypes = new List<string> { "FemaleID" }

namespace SaltEnemies_Reseasoned
{
    public static class PreservedHandler
    {
        public static string Type => "Merced_Preserved_PA";
        public static int WillApplyDamage(Func<EnemyCombat, int, IUnit, int> orig, EnemyCombat self, int amount, IUnit targetUnit)
        {
            int ret = orig(self, amount, targetUnit);
            if (targetUnit.ContainsPassiveAbility(Type) && !targetUnit.IsUnitCharacter)
            {
                Debug.LogError("PreservedHandler: MAKE SURE THIS IS LOADING AN EXISTING SPRITE");
                CombatManager.Instance.AddSubAction(new ShowPassiveInformationUIAction(targetUnit.ID, targetUnit.IsUnitCharacter, "Well Preserved", ResourceLoader.LoadSprite("preserve.png")));
                return 0;
            }
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.WillApplyDamage), ~BindingFlags.Default), typeof(PreservedHandler).GetMethod(nameof(WillApplyDamage), ~BindingFlags.Default));
        }
    }
    public class WellPreservedCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.directDamage) return false;
                hitBy.AddModifier(new ImmZeroMod());
            }
            return true;
        }
    }
    public class DamageTargetsBySubTargetMissingHealthEffect : DamageEffect
    {
        public BaseCombatTargettingSO Sub;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Sub != null)
            {
                foreach (TargetSlotInfo target in Sub.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
                {
                    if (target.HasUnit && target.Unit.CurrentHealth > 0)
                    {
                        if (exitAmount <= 0) exitAmount = target.Unit.MaximumHealth - target.Unit.CurrentHealth;
                        else if (exitAmount > target.Unit.MaximumHealth - target.Unit.CurrentHealth) exitAmount = target.Unit.MaximumHealth - target.Unit.CurrentHealth;
                    }
                }
            }
            if (exitAmount > 0)
                return base.PerformEffect(stats, caster, targets, areTargetSlots, exitAmount, out int exi);
            return false;

        }
    }
    public class EngravingsEffect : EffectSO
    {
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public AnimationVisualsEffect Shank;
        public ShowEngravingsAttackInfoEffect Text;
        public PseudoEngravingsEffect Pseudo;

        public static bool Engraving = false;
        public static List<IUnit> Engravers = new List<IUnit>();

        public void RunSecondaryEngravings(CombatStats stats)
        {
            List<IUnit> killers = new List<IUnit>(Engravers);
            Engravers.Clear();
            foreach (IUnit caster in killers)
            {
                Text.PerformEffect(stats, caster, Targeting.Slot_SelfSlot.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Targeting.Slot_SelfSlot.AreTargetSlots, 2, out int ex1);
                Shank.PerformEffect(stats, caster, Targeting.Slot_SelfSlot.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Targeting.Slot_SelfSlot.AreTargetSlots, 2, out int ex2);
                Pseudo.PerformEffect(stats, caster, Targeting.Slot_AllySides.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Targeting.Slot_AllySides.AreTargetSlots, 2, out int ex3);
            }
            if (Engravers.Count > 0) RunSecondaryEngravings(stats);
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            Engravers = new List<IUnit>();
            if (Text == null) Text = ScriptableObject.CreateInstance<ShowEngravingsAttackInfoEffect>();
            if (Shank == null) Shank = BasicEffects.GetVisuals("Salt/Claws", true, Targeting.Slot_AllySides);
            if (Pseudo == null) Pseudo = ScriptableObject.CreateInstance<PseudoEngravingsEffect>();

            exitAmount = 0;
            bool flag = false;
            int survived = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }
                    targetSlotInfo.Unit.ApplyStatusEffect(StatusField.Focused, 0);

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;

                    if (targetSlotInfo.Unit.CurrentHealth > 0 && damageInfo.damageAmount > 0)
                    {
                        Engravers.Add(targetSlotInfo.Unit);
                    }
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            RunSecondaryEngravings(stats);


            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }


            return flag;
        }
    }
    public class ShowEngravingsAttackInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Blood Engravings"));
            return true;
        }
    }
    public class PseudoEngravingsEffect : EffectSO
    {
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }
                    targetSlotInfo.Unit.ApplyStatusEffect(StatusField.Focused, 0);

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;

                    if (targetSlotInfo.Unit.CurrentHealth > 0 && damageInfo.damageAmount > 0)
                    {
                        EngravingsEffect.Engravers.Add(targetSlotInfo.Unit);
                    }
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
    }
    public class AllTargetsTouchingFrontSingleSizeOnly : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            TargetSlotInfo[] connect = Targeting.Slot_Front.GetTargets(slots, casterSlotID, isCasterCharacter);
            bool frontHas = connect[0].HasUnit;
            if (!frontHas) return connect;
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>() { connect[0] };
            int start = connect[0].SlotID;
            //int min = start - 1;
            for (int min = start - 1; min >= 0; min--)
            {
                bool cont = false;
                foreach (TargetSlotInfo target in source)
                {
                    if (target.SlotID == min && target.HasUnit)
                    {
                        ret.Add(target);
                        cont = true;
                        break;
                    }
                }
                if (!cont) break;
            }
            for (int max = start + 1; max < 5; max++)
            {
                bool cont = false;
                foreach (TargetSlotInfo target in source)
                {
                    if (target.SlotID == max && target.HasUnit)
                    {
                        ret.Add(target);
                        cont = true;
                        break;
                    }
                }
                if (!cont) break;
            }
            return ret.ToArray();
        }
    }
    public class AllEnemyMaxHealthExitCollectEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                exitAmount += enemy.CurrentHealth;
            }
            return true;
        }
    }
    public class DivideUpDamageExitValueEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<IUnit> guys = new List<IUnit>();
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) guys.Add(target.Unit);
            if (guys.Count > 0)
            {
                float num = base.PreviousExitValue;
                IUnit[] units = guys.ToArray();
                List<int> kill = new List<int>();
                while (guys.Count > 0 && num > 0f)
                {
                    int num2 = Mathf.CeilToInt(num / (float)guys.Count);
                    int index = UnityEngine.Random.Range(0, guys.Count);
                    IUnit unit = guys[index];
                    guys.RemoveAt(index);
                    kill.Add(num2);
                    num -= (float)num2;
                }
                for (int i = 0; i < units.Length && i < kill.Count; i++)
                {
                    int amount = caster.WillApplyDamage(kill[i], units[i]);
                    DamageInfo info = units[i].Damage(amount, caster, DeathType_GameIDs.Basic.ToString(), -1, addHealthMana: true, directDamage: true, ignoresShield: false);
                    exitAmount += info.damageAmount;
                }
            }
            if (exitAmount > 0) caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }
    public class CountAllStatusEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit != caster && target.Unit is IStatusEffector effector)
                {
                    List<IStatusEffect> statuses = new List<IStatusEffect>(effector.StatusEffects);
                    for (int i = 0; i < statuses.Count; i++)
                    {
                        IStatusEffect toCopy = statuses[i];
                        int amount = toCopy.StatusContent + (toCopy.Restrictor * 4);
                        bool hasNum = toCopy.DisplayText != "";
                        int final = hasNum ? toCopy.StatusContent : 0;
                        exitAmount += Math.Max(final, 1);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class DamageIfFailDeal1Effect : EffectSO
    {
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            try
            {
                if (_usePreviousExitValue)
                {
                    entryVariable *= base.PreviousExitValue;
                }

                exitAmount = 0;
                bool flag = false;
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                        int amount = entryVariable;
                        DamageInfo damageInfo;
                        CombatManager.Instance.AddUIAction(new TickFibonacciShowTextUIAction(targetSlotInfo.Unit.ID, targetSlotInfo.Unit.IsUnitCharacter, ""));
                        if (_indirect)
                        {
                            damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                        }
                        else
                        {
                            amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                            damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                        }

                        flag |= damageInfo.beenKilled;
                        exitAmount += damageInfo.damageAmount;
                    }
                }

                if (!_indirect && exitAmount > 0)
                {
                    caster.DidApplyDamage(exitAmount);
                }

                if (!_returnKillAsSuccess)
                {
                    return exitAmount > 0;
                }

                return flag;
            }
            catch (Exception g)
            {
                Debug.LogError("Merced big damage number mega failed");
                Debug.LogError(g + g.StackTrace);
                UnityEngine.Diagnostics.Utils.ForceCrash(~ForcedCrashCategory.Abort);
            }
            exitAmount = 0;
            return false;
        }
    }
    public static class CountFibonacci
    {
        public static List<int> list = new List<int>() { 0, 1, 1 };
        public static int Get(int index)
        {
            if (index < list.Count) return list[index];
            else
            {
                for (int i = list.Count; i <= index; i++)
                {
                    int pick = 0;
                    pick += list[list.Count - 1];
                    pick += list[list.Count - 2];
                    list.Add(pick);
                }
                return list[index];
            }
        }
        public static string click = "";
        public static string type = "Dmg_Fibonacci";

        public static void Add()
        {
            TMP_ColorGradient white = ScriptableObject.CreateInstance<TMP_ColorGradient>();
            UnityEngine.Color32 whitecolor = Color.white;
            white.bottomLeft = whitecolor;
            white.bottomRight = whitecolor;
            white.topLeft = whitecolor;
            white.topRight = whitecolor;
            //note: this is the color of Pale damage in lobotomy corporation. it MUST be this color bc im autistic like that. feel free to change the sounds though
            if (LoadedDBsHandler.CombatDB.m_TxtColorPool.ContainsKey(type)) LoadedDBsHandler.CombatDB.m_TxtColorPool[type] = white;
            else LoadedDBsHandler.CombatDB.AddNewTextColor(type, white);
            if (LoadedDBsHandler.CombatDB.m_SoundPool.ContainsKey(type)) LoadedDBsHandler.CombatDB.m_SoundPool[type] = click;
            else LoadedDBsHandler.CombatDB.AddNewSound(type, click);
        }
    }
    public class TickFibonacciShowTextUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;

        public TickFibonacciShowTextUIAction(int id, bool isUnitCharacter, string attackName)
        {
            _id = id;
            _isUnitCharacter = isUnitCharacter;
            _attackName = attackName;
            CharacterCombat c;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            CountFibonacci.click = stats.audioController.uiSelect;
            if (stats.combatUI._charactersInCombat.TryGetValue(_id, out var value))
                for (int i = 0; i < 42; i++)
                {
                    Vector3 characterPosition = stats.combatUI._characterZone.GetCharacterPosition(value.FieldID);
                    stats.combatUI._popUpHandler3D.StartDamageShowcase(isFieldText: false, characterPosition, CountFibonacci.Get(i), CountFibonacci.type);
                    RuntimeManager.PlayOneShot(CountFibonacci.click, characterPosition);
                    for (int j = 0; j < 6; j++) yield return null;
                }
        }
    }
}
