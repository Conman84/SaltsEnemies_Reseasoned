using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{

    public class StalkerConnectionEffect : EffectSO
    {
        public bool Connect;

        public void Function(object sender, object args)
        {
            if (sender is IUnit unit && unit.IsUnitCharacter)
            {
                CombatManager.Instance.AddRootAction(new CharacterWitheringAction());
            }
            else
                CombatManager.Instance.AddRootAction(new EnemyWitheringAction());
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(Function, TriggerCalls.OnFleetingEnd.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnFleetingEnd.ToString(), caster);
            return true;
        }

        public static StalkerConnectionEffect Create(bool connection)
        {
            StalkerConnectionEffect ret = ScriptableObject.CreateInstance<StalkerConnectionEffect>();
            ret.Connect = connection;
            return ret;
        }

    }
}
