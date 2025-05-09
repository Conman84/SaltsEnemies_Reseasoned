using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class SpawnEnemyFromAreaEffect : SpawnEnemyInSlotFromEntryEffect
    {
        public static EnemyCombatBundle GetRandomBundle()
        {
            ZoneBGDataBaseSO garden = CombatManager.Instance._informationHolder.Run.CurrentZoneDB as ZoneBGDataBaseSO;
            EnemyEncounterSelectorSO selector = null;
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 0:
                    selector = garden.EnemyEncounterData.m_EasySelector;
                    break;
                case 2:
                    selector = garden.EnemyEncounterData.m_HardSelector;
                    break;
                default:
                    selector = garden.EnemyEncounterData.m_MediumSelector;
                    break;
            }
            return selector.GetEnemyBundle();
        }
        public static EnemySO GetRandomEnemy()
        {
            EnemyCombatBundle bundle = GetRandomBundle();
            List<EnemySO> lists = new List<EnemySO>();
            foreach (EnemyBundleData data in bundle.Enemies)
            {
                if (data.enemy.size == 1) lists.Add(data.enemy);
            };
            if (lists.Count <= 0) return GetRandomEnemy();
            EnemySO ret = lists.GetRandom();
            if (ret == null) return GetRandomEnemy();
            return ret;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            _spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            foreach (TargetSlotInfo target in targets)
            {
                enemy = GetRandomEnemy();
                base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out exitAmount);
            }
            return true;
        }
    }
}
