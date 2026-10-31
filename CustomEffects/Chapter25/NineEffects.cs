using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SaltEnemies_Reseasoned;
using HarmonyLib;
using System.Data.Common;

namespace SaltsEnemies_Reseasoned
{
    public class RandomTriggerPassive : PerformEffectPassiveAbility
    {
        public TriggerCalls UniqueCall;
        public float _min;
        public float _max;

        public Dictionary<IUnit, Coroutine> Coroutines;

        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            CombatManager.Instance.AddRootAction(new StartTimerAction(unit, this));
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            base.OnPassiveDisconnected(unit);
            if (Coroutines.ContainsKey(unit))
            {
                CombatManager.Instance.StopCoroutine(Coroutines[unit]);
                Coroutines.Remove(unit);
            }
        }

        public static IEnumerator RandomTimer(IUnit unit, float min, float max, TriggerCalls call)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(Random.Range(min, max));
                CombatManager.Instance.PostNotification(call.ToString(), unit, null);
            }
        }

        public class StartTimerAction : CombatAction
        {
            public IUnit Unit;
            public RandomTriggerPassive Passive;

            public StartTimerAction(IUnit unit, RandomTriggerPassive passive)
            {
                Unit = unit;
                Passive = passive;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                Coroutine added = CombatManager.Instance.StartCoroutine(RandomTimer(Unit, Passive._min, Passive._max, Passive.UniqueCall));
                if (Passive.Coroutines.ContainsKey(Unit))
                {
                    CombatManager.Instance.StopCoroutine(Passive.Coroutines[Unit]);
                }
                Passive.Coroutines[Unit] = added;
                yield break;
            }
        }
    }

    public class CasterSwapToSidesUpToEntryVariableEffect : SwapToOneSideEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            _swapRight = UnityEngine.Random.Range(0, 100) < 50;
            if (caster.SlotID == 0) _swapRight = true;
            if (caster.SlotID + caster.Size >= 5) _swapRight = false;

            int times = UnityEngine.Random.Range(1, entryVariable + 1);

            for (int i = 0; i < times; i++)
            {
                if (base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out exitAmount))
                    exitAmount++;
            }

            return exitAmount > 0;
        }
    }
    public class AddToMusicParameterEffect : EffectSO
    {
        public string ParameterName;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            float init = 0f;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName(ParameterName, out init) == FMOD.RESULT.OK)
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName(ParameterName, init + entryVariable);
            else return false;
            return true;
        }
    }

    public class NineConnectionEffect : EffectSO
    {
        public bool Connect;

        public void Function(object sender, object args)
        {
            CombatManager.Instance.AddUIAction(new IncNineSongAction());
        }
        public class IncNineSongAction : CombatAction
        {
            public override IEnumerator Execute(CombatStats stats)
            {
                float init = 0f;
                if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Nine", out init) == FMOD.RESULT.OK)
                    CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Nine", Mathf.Clamp(init + 1, 0.0f, 12.0f));
                yield return null;
            }
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(Function, TriggerCalls.OnDamaged.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnDamaged.ToString(), caster);
            return true;
        }

        public static NineConnectionEffect Create(bool connection)
        {
            NineConnectionEffect ret = ScriptableObject.CreateInstance<NineConnectionEffect>();
            ret.Connect = connection;
            return ret;
        }

    }
}
