using System;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class SpawnEnemyFromAreaEffect : SpawnEnemyInSlotFromEntryEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out exitAmount);
            }
            return true;
        }
    }
}
