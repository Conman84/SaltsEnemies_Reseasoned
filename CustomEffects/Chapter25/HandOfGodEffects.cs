using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class SpawnEnemyWithHealthEntryEffect : SpawnEnemyAnywhereEffect
    {
        public string _enemyName;
        public bool _usePrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (enemy == null || enemy.Equals(null))
                enemy = LoadedAssetsHandler.GetEnemy(_enemyName);

            if (_usePrevious) entryVariable *= PreviousExitValue;

            exitAmount = 0;
            if (entryVariable <= 0) return false;

            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnTypeID, entryVariable));

            exitAmount = entryVariable;
            return true;
        }
    }
    public class SetExitCasterMissingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = caster.MaximumHealth - caster.CurrentHealth;
            return exitAmount > 0;
        }
    }
}
