using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class WallConnectionEffect : EffectSO
    {
        public bool Connect;

        public static void RunEffect(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (caster.IsUnitCharacter || !caster.IsAlive) return;
            CombatManager.Instance._stats.TryTransformEnemy(caster.ID, LoadedAssetsHandler.GetEnemy("Wall_2_EN"), false, true, true, false);
            if (CombatManager.Instance._stats.timeline.IsConfused) return;
            CombatManager.Instance.AddUIAction(new FixCasterTImelineIntentsUIAction(caster));
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(RunEffect, TriggerCalls.OnDirectDamaged.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(RunEffect, TriggerCalls.OnDirectDamaged.ToString(), caster);
            return true;
        }

        public static WallConnectionEffect Create(bool connect)
        {
            WallConnectionEffect ret = ScriptableObject.CreateInstance<WallConnectionEffect>();
            ret.Connect = connect;
            return ret;
        }
    }
}
