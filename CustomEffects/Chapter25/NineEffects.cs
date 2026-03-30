using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SaltEnemies_Reseasoned;
using HarmonyLib;

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

            int times = UnityEngine.Random.Range(1, entryVariable + 1);

            for (int i = 0; i < times; i++)
            {
                if (base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, entryVariable, out exitAmount))
                    exitAmount++;
            }

            return exitAmount > 0;
        }
    }
}
