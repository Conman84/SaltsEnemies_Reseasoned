using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class CasterRandomizeNameEnemyEffect : EffectSO
    {
        public string[] PossibleNames;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            if (caster is EnemyCombat enemy)
            {
                enemy._currentName = PossibleNames.GetRandom();

                foreach (EnemyCombatUIInfo enemyInfo in stats.combatUI._enemiesInCombat.Values)
                {
                    if (enemyInfo.SlotID == enemy.SlotID)
                    {
                        enemyInfo.Name = enemy._currentName;
                    }
                }
            }

            return true;
        }
    }
    public class InvertTargetHealthEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int temp = target.Unit.MaximumHealth - target.Unit.CurrentHealth;

                    exitAmount += Math.Abs(temp - target.Unit.CurrentHealth);

                    if (temp <= 0) target.Unit.DirectDeath(caster);
                    else if (temp != target.Unit.CurrentHealth) target.Unit.SetHealthTo(temp);
                }
            }
            return exitAmount > 0;
        }
    }
}
