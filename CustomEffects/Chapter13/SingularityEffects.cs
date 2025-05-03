using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class IsPlayerTurnEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return CombatManager.Instance._stats.IsPlayerTurn;
        }
    }
    public class IsPlayerTurnEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return CombatManager.Instance._stats.IsPlayerTurn;
        }
    }
    public class ApplyPermenantRupturedCustomEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (!target.Unit.ContainsStatusEffect(StatusField_GameIDs.Ruptured_ID.ToString())) exitAmount++;
                    target.Unit.ApplyStatusEffect(StatusField.Ruptured, 0, 1);
                }
            }
            return exitAmount > 0;
        }
    }
}
