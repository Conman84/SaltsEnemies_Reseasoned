using System;
using System.Collections.Generic;
using System.Text;
using SaltsEnemies_Reseasoned;

namespace SaltEnemies_Reseasoned
{
    public class SpawnEnemyByStringNameEffect : SpawnEnemyAnywhereEffect
    {
        public string enemyName;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (Check.EnemyExist(enemyName))
            {
                base.enemy = LoadedAssetsHandler.GetEnemy(enemyName);
            }
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class DefenderCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.CurrentHealth <= 12;
        }
    }
}
