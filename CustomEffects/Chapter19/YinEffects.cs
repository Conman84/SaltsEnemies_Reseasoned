using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class IfCursedReturnFalseEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.ContainsStatusEffect(StatusField_GameIDs.Cursed_ID.ToString())) continue;
                    target.Unit.ApplyStatusEffect(StatusField.Cursed, 1);
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class DamageByFieldAmountBlockedByFieldEffect : DamageFieldEffectBlockedEffect
    {
        public string FieldID;
        public bool Opposing;
        public bool includeRestrictor;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                int amount = StatusExtensions.GetFieldAmountFromID(target.SlotID, Opposing ? !target.IsTargetCharacterSlot : target.IsTargetCharacterSlot, FieldID, includeRestrictor);
                if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable * amount, out int exi)) exitAmount += exi;
            }
            return exitAmount > 0;
        }
        public static DamageByFieldAmountBlockedByFieldEffect Create(FieldEffect_SO blocked, string field, bool opposing, bool includerestrictor = false)
        {
            DamageByFieldAmountBlockedByFieldEffect ret = ScriptableObject.CreateInstance<DamageByFieldAmountBlockedByFieldEffect>();
            ret._Field = blocked;
            ret.FieldID = field;
            ret.Opposing = opposing;
            ret.includeRestrictor = includerestrictor;
            return ret;
        }
    }
}
