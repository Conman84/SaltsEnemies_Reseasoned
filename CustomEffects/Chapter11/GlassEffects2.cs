using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class GlassConnectionEffect : CasterChangeNameEnemyEffect
    {
        public bool Connect;

        public void Function(object sender, object args)
        {
            base.PerformEffect(CombatManager.Instance._stats, sender as IUnit, [], false, 0, out int exi);
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(Function, TriggerCalls.OnAnyAbilityUsed.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(Function, TriggerCalls.OnAnyAbilityUsed.ToString(), caster);
            return true;
        }

        public static GlassConnectionEffect Create(bool connection)
        {
            GlassConnectionEffect ret = ScriptableObject.CreateInstance<GlassConnectionEffect>();
            ret.Connect = connection;
            return ret;
        }

    }
}
