using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

namespace SaltsEnemies_Reseasoned
{
    public class DelayToSelfCondition : EffectorConditionSO
    {
        public BaseCombatTargettingSO targetting;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference damaged)
            {
                foreach (TargetSlotInfo target in targetting.GetTargets(CombatManager.Instance._stats.combatSlots, effector.SlotID, effector.IsUnitCharacter)
                {
                    new DelayedAttack(damaged.value, target, null).Add();
                }
                return true;
            }
            return false;
        }

        public static DelayToSelfCondition Create(BaseCombatTargettingSO targets)
        {
            DelayToSelfCondition ret = ScriptableObject.CreateInstance<DelayToSelfCondition>();
            ret.targetting = targets;
            return ret;
        }
    }
    public class AddDelayedAttackNullCasterEffect : EffectSO
    {
        public bool _usePreviousExit;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_usePreviousExit) entryVariable *= PreviousExitValue;
            foreach (TargetSlotInfo target in targets)
            {
                new DelayedAttack(entryVariable, target, null).Add();
                exitAmount += entryVariable;
            }
            return exitAmount > 0;
        }
    }
}
