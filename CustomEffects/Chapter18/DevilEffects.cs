using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class TryTriggerPaleEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.ContainsStatusEffect(Pale.StatusID, 100))
                    {
                        (target.Unit as IStatusEffector).RemoveStatusEffect(Pale.StatusID);
                        EffectInfo soulHit = Effects.GenerateEffect(ScriptableObject.CreateInstance<PaleHarmEffect>(), 100, Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { soulHit }, target.Unit));
                        exitAmount++;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
}
