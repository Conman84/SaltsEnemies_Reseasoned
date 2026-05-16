using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
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

            ExtraAbility_Wearable_SMS temp = new ExtraAbility_Wearable_SMS();
            temp._extraAbility = self.GenerateCharacterAbility();

            remove = ScriptableObject.CreateInstance<CasterAddOrRemoveExtraAbilityEffect>();
            remove._removeExtraAbility = true;
            remove._extraAbility = temp;

            return ret;
        }
    }
}
