using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class SnatchEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Snatch") });
            }
            return true;
        }
    }
    public class ObserverPassive : ExtraAttackPassiveAbility
    {
        public override void TriggerPassive(object sender, object args)
        {
            if (sender is EnemyCombat enemy)
            {
                CombatManager.Instance._stats.timeline.AddExtraEnemyTurns([enemy], [enemy.GetLastAbilityIDFromName(_extraAbility.ability?.name)]);
            }
        }
    }
}
