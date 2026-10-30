using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaltEnemies_Reseasoned
{
    public class MawCheckAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            BadDogHandler.RunCheckFunction(true);
            yield return null;
        }
    }
    public class ExhaustMovementEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.IsTargetCharacterSlot)
                {
                    if (!(targetSlotInfo.Unit as CharacterCombat).CanSwap) continue;
                    (targetSlotInfo.Unit as CharacterCombat).CanSwap = false;
                    CombatManager.Instance.AddUIAction(new CharacterUpdateVolatilesUIAction((targetSlotInfo.Unit as CharacterCombat).ID, (targetSlotInfo.Unit as CharacterCombat).CanSwapNoTrigger, (targetSlotInfo.Unit as CharacterCombat).CanUseAbilitiesNoTrigger, shouldPopUp: true));
                    return true;
                }
            }
            return false;
        }
    }

    public class CasterGainTurnIfNoTurnsEnemyEffect : AddTurnCasterToTimelineEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                if (CombatManager.Instance._stats.IsPlayerTurn && enemy.TurnsInTimeline > 0)
                    return false;

                for (int i = stats.timeline.CurrentTurn + (stats.IsPlayerTurn ? 0 : 1); i < stats.timeline.Round.Count; i++)
                {
                    if (stats.timeline.Round[i].isPlayer) continue;

                    if (stats.timeline.Round[i].turnUnit == enemy)
                    {
                        return false;
                    }
                }
            }
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
