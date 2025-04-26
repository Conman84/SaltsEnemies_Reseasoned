using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using System.Threading;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public static class ClockTowerManager
    {
        public static System.Threading.Thread timer;
        public static int _timeSpent;
        public static int TimeLeft
        {
            get
            {
                return 60 - _timeSpent;
            }
        }
        public static void CountTo45()
        {
            _timeSpent = 0;
            for (int i = 0; i < 61; i++)
            {
                _timeSpent = i;
                System.Threading.Thread.Sleep(1000);
                if (CombatManager.Instance._pauseMenuIsOpen) i--;
                if (!PlayerTurn || !InCombat) break;
            }
            if (!PlayerTurn || !InCombat) return;
            UnityEngine.Debug.Log("Time's Up!");
            foreach (EnemyCombat en in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                try { CombatManager.Instance.PostNotification(Call.ToString(), en, null); }
                catch (Exception ex)
                {
                    UnityEngine.Debug.LogError("Clock tower failed once");
                    UnityEngine.Debug.LogError(ex.Message);
                    UnityEngine.Debug.LogError(ex.StackTrace);
                    try { CombatManager.Instance.AddSubAction(new ClockTowerNotifAction(en, Call)); }
                    catch (Exception ex2)
                    {
                        UnityEngine.Debug.LogError("Clock tower failed twice");
                        UnityEngine.Debug.LogError(ex2.Message);
                        UnityEngine.Debug.LogError(ex2.StackTrace);
                    }
                }
            }
        }
        public class ClockTowerNotifAction : CombatAction
        {
            public IUnit unit;
            public TriggerCalls call;
            public ClockTowerNotifAction(IUnit Unit, TriggerCalls Call)
            {
                this.unit = Unit;
                this.call = Call;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                try { CombatManager.Instance.PostNotification(call.ToString(), unit, null); }
                catch (Exception ex)
                {
                    UnityEngine.Debug.LogError("Clock tower sub action failed");
                    UnityEngine.Debug.LogError(ex.Message);
                    UnityEngine.Debug.LogError(ex.StackTrace);
                }
                yield return null;
            }
        }

        public static bool PlayerTurn;
        public static bool InCombat;
        public static TriggerCalls Call = (TriggerCalls)3867920;
        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            PlayerTurn = true;
            if (timer != null) timer.Abort();
            timer = new System.Threading.Thread(CountTo45);
            timer.Start();
        }
        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            PlayerTurn = false;
            if (timer != null) timer.Abort();
            _timeSpent = 0;
        }
        public static void FinalizeCombat(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            InCombat = false;
            if (timer != null) timer.Abort();
        }
        public static void UIInitialization(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            InCombat = true;
        }
        public static string Acceleration => "ClockTower_Acceleration_PA";
        public static void Setup()
        {
            IDetour CombatEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.FinalizeCombat), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(FinalizeCombat), ~BindingFlags.Default));
            IDetour CombatStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.UIInitialization), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(UIInitialization), ~BindingFlags.Default));
            IDetour TurnStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour TurnEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
            UnitStoreData_ClockTowerTimeSO value_clock = ScriptableObject.CreateInstance<UnitStoreData_ClockTowerTimeSO>();
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Acceleration))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Acceleration] = value_clock;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_clock._UnitStoreDataID, value_clock);
            CrackingHandler.Setup();
        }
    }
    public class ClockTowerPassive : PerformEffectPassiveAbility
    {
        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            unit.SimpleSetStoredValue(ClockTowerManager.Acceleration, 1);
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            base.OnPassiveDisconnected(unit);
            unit.SimpleSetStoredValue(ClockTowerManager.Acceleration, 0);
        }
    }
    public static class CrackingHandler
    {
        public static Sprite Face = ResourceLoader.LoadSprite("ClockFace.png");
        public class ThreadHandler
        {
            public int ID;
            public System.Threading.Thread Timer;
            public ThreadHandler(int ID)
            {
                this.ID = ID;
                Timer = new System.Threading.Thread(CountTo75);
                Timer.Start();
            }
            public int TimeLeft
            {
                get
                {
                    return 150 - _timeSpent;
                }
            }
            public int _timeSpent;
            public void CountTo75()
            {
                _timeSpent = 0;
                for (int i = 0; i < 151; i++)
                {
                    _timeSpent = i;
                    System.Threading.Thread.Sleep(1000);
                    if (CombatManager.Instance._pauseMenuIsOpen) i--;
                    if (!ClockTowerManager.InCombat) break;
                }
                if (!ClockTowerManager.InCombat) return;
                CombatStats stats = CombatManager.Instance._stats;
                TargetSlotInfo[] targets = ScriptableObject.CreateInstance<TargettingRandomUnit>().GetTargets(stats.combatSlots, -1, false);
                List<int> IDs = new List<int>();
                List<bool> chara = new List<bool>();
                List<string> cracking = new List<string>();
                List<Sprite> face = new List<Sprite>();
                foreach (TargetSlotInfo target in targets)
                {
                    if (target.HasUnit)
                    {
                        IDs.Add(target.Unit.ID);
                        chara.Add(target.Unit.IsUnitCharacter);
                        cracking.Add("Cracking");
                        face.Add(Face);
                    }
                }
                if (IDs.Count > 0) CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(IDs.ToArray(), chara.ToArray(), cracking.ToArray(), face.ToArray()));
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationNoCasterAction(CustomVisuals.GetVisuals("Salt/Alarm"), targets));
                CombatManager.Instance.AddPrioritySubAction(new Apply12EntropyAction(targets));
                CrackingHandler.Threads.Remove(ID);
            }
            public void End()
            {
                if (Timer != null) Timer.Abort();
            }
        }

        public static Dictionary<int, ThreadHandler> Threads = new Dictionary<int, ThreadHandler>();
        public static void Clear()
        {
            foreach (ThreadHandler threads in Threads.Values)
            {
                threads.End();
            }
            Threads.Clear();
        }
        public static void Remove(int ID)
        {
            if (Threads.Keys.Contains(ID))
                Threads[ID].End();
        }
        public static void SetTimer(int ID)
        {
            if (Threads.Keys.Contains(ID))
            {
                Threads[ID].End();
                Threads[ID] = new ThreadHandler(ID);
            }
            else
            {
                Threads.Add(ID, new ThreadHandler(ID));
            }
        }

        public static string Cracking = "ClockTower_Cracking_A";
        public static void Setup()
        {
            Debug.LogError("CrackingHandler.Setup: MAKE SURE PUBLIC STATIC SPRITE \"Face\' IS LOADING THE CORRECT SPRITE");
            UnitStoreData_CrackingTimeSO value_clock = ScriptableObject.CreateInstance<UnitStoreData_CrackingTimeSO>();
            if (LoadedDBsHandler.MiscDB.m_UnitStoreDataPool.ContainsKey(Cracking))
                LoadedDBsHandler.MiscDB.m_UnitStoreDataPool[Cracking] = value_clock;
            else
                LoadedDBsHandler.MiscDB.AddNewUnitStoreData(value_clock._UnitStoreDataID, value_clock);
        }
    }
    public class AbilitySelector_ClockTower : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string cracking = "Cracking";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return CrackingHandler.Threads.TryGetValue(unit.ID, out var variable) && name == this.cracking;
        }
    }
    public class CrackingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CrackingHandler.SetTimer(caster.ID);
            caster.SimpleSetStoredValue(CrackingHandler.Cracking, caster.ID + 1000);
            return true;
        }
    }
    public class ClockTowerExitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CrackingHandler.Remove(caster.ID);
            return true;
        }
    }
    public class PlayAbilityAnimationNoCasterAction : CombatAction
    {
        public TargetSlotInfo[] _targets;

        public AttackVisualsSO _visuals;

        public PlayAbilityAnimationNoCasterAction(AttackVisualsSO visuals, TargetSlotInfo[] targets)
        {
            _visuals = visuals;
            _targets = targets;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.PlayAbilityAnimation(_visuals, _targets, true);
        }
    }
    public class UnitStoreData_ClockTowerTimeSO : UnitStoreData_BasicSO
    {
        public override bool TryGetUnitStoreDataToolTip(UnitStoreDataHolder holder, out string result)
        {
            result = GenerateString(holder.m_MainData);
            return result != "";
        }

        public string GenerateString(int value)
        {
            string text = "Time Left: " + ClockTowerManager.TimeLeft.ToString();
            string text2 = ColorUtility.ToHtmlStringRGB(Color.green);
            string text3 = "<color=#" + text2 + ">";
            string text4 = "</color>";
            return text3 + text + text4;
        }
    }
    public class UnitStoreData_CrackingTimeSO : UnitStoreData_BasicSO
    {
        public override bool TryGetUnitStoreDataToolTip(UnitStoreDataHolder holder, out string result)
        {
            result = GenerateString(holder.m_MainData);
            return result != "";
        }
        public string GenerateString(int value)
        {
            if (value <= 0)
            {
                return "";
            }
            else if (CrackingHandler.Threads.TryGetValue(value - 1000, out CrackingHandler.ThreadHandler thread))
            {
                string text = "Cracking in: " + thread.TimeLeft.ToString();
                string text2 = ColorUtility.ToHtmlStringRGB(Color.magenta);
                string text3 = "<color=#" + text2 + ">";
                string text4 = "</color>";
                return text3 + text + text4;
            }
            return "";
        }
    }
    public class Apply12EntropyAction : CombatAction
    {
        public TargetSlotInfo[] _targets;
        public Apply12EntropyAction(TargetSlotInfo[] targets)
        {
            _targets = targets;
        }
        public int ApplyStatusEffect(StatusEffect_SO _Status, IUnit unit, int entryVariable)
        {
            int num =  entryVariable;
            if (num < _Status.MinimumRequiredToApply)
            {
                return 0;
            }

            if (!unit.ApplyStatusEffect(_Status, num))
            {
                return 0;
            }

            return Mathf.Max(1, num);
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo[] targets = _targets;
            StatusEffect_SO entropy = Entropy.Object;
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    ApplyStatusEffect(entropy, targets[index].Unit, 12);
                }
            }
            yield return null;
        }
    }
}
