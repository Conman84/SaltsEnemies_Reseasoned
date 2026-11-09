using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

namespace SaltsEnemies_Reseasoned
{
    public class InSlipDamageEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> ret = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (areTargetSlots)
                {
                    if (stats.combatSlots.UnitInSlotContainsFieldEffect(target.SlotID, target.IsTargetCharacterSlot, Slip.FieldID))
                        ret.Add(target);
                }
                else if (target.Unit.ContainsFieldEffect(Slip.FieldID))
                    ret.Add(target);
            }

            return base.PerformEffect(stats, caster, ret.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public static class ExtraAbilityExtensions
    {
        public static ExtraAbilityInfo ExtraAbility(this Ability self, out CasterAddOrRemoveExtraAbilityEffect remove)
        {
            ExtraAbilityInfo ret = new ExtraAbilityInfo()
            {
                ability = self.ability,
                rarity = self.Rarity,
                cost = self.Cost,
            };

            ExtraAbility_Wearable_SMS temp = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            temp._extraAbility = self.GenerateCharacterAbility();

            remove = ScriptableObject.CreateInstance<CasterRemoveExtraAbilityEffect>();
            remove._removeExtraAbility = true;
            remove._extraAbility = temp;
            (remove as CasterRemoveExtraAbilityEffect).abil = ret;

            return ret;
        }
    }

    public class CasterRemoveExtraAbilityEffect : CasterAddOrRemoveExtraAbilityEffect
    {
        public ExtraAbilityInfo abil;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                for (int num2 = enemy.Abilities.Count - 1; num2 >= 0; num2--)
                {
                    if (!(enemy.Abilities[num2].ability != abil.ability) && !(enemy.Abilities[num2].rarity != abil.rarity))
                    {
                        //num2

                        //update timeline ids
                        List<int> turns_removed = [];

                        for (int i = stats.timeline.Round.Count - 1; i > stats.timeline.CurrentTurn; i--)
                        {
                            if (stats.timeline.Round[i].isPlayer) continue;

                            if (stats.timeline.Round[i].turnUnit == enemy)
                            {
                                if (stats.timeline.Round[i].abilitySlot == num2)
                                {
                                    stats.timeline.Round.RemoveAt(i);
                                    enemy.TurnsInTimeline--;
                                    turns_removed.Add(i);
                                }
                                else if (stats.timeline.Round[i].abilitySlot > num2)
                                {
                                    TurnInfo turn = stats.timeline.Round[i];
                                    turn.abilitySlot -= entryVariable;
                                    stats.timeline.Round[i] = turn;

                                    TimelineInfo timeline = stats.combatUI._TimelineHandler.TimelineSlotInfo[i];
                                    timeline.abilitySlotID = turn.abilitySlot;
                                    stats.combatUI._TimelineHandler.TimelineSlotInfo[i] = timeline;
                                }
                            }
                        }

                        CombatManager.Instance.AddUIAction(new RemoveSlotTimelineUIAction(turns_removed.ToArray()));
                        CombatManager.Instance.AddUIAction(new UpdateTimelinePointerUIAction(stats.timeline.CurrentTurn));

                        break;
                    }
                }
            }
            caster.TryRemoveExtraAbility(abil);
            return true;
        }
    }
}
