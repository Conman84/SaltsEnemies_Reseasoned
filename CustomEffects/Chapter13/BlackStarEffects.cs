using SaltsEnemies_Reseasoned;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class SpawnEnemyInSlotFromEntryStringNameEffect : EffectSO
    {
        public string en;

        public bool givesExperience;

        public bool trySpawnAnywhereIfFail;

        [SerializeField]
        public string _spawnType = CombatType_GameIDs.Spawn_Basic.ToString();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Check.EnemyExist(en)) return false;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(en);
            for (int num = targets.Length - 1; num >= 0; num--)
            {
                int preferredSlot = entryVariable + targets[num].SlotID;
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, preferredSlot, givesExperience, trySpawnAnywhereIfFail, _spawnType));
            }

            exitAmount = targets.Length;
            return true;
        }
    }
    public class GeneratePigmentAllEnemies : GenerateColorManaEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                mana = enemy.HealthColor;
                if (base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi)) exitAmount += exi;
            }
            return exitAmount > 0;
        }
    }
}
