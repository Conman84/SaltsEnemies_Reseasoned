using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace SaltsEnemies_Reseasoned
{
    public class DirectDeathWithExitValueEffect : EffectSO
    {
        public bool _obliterationDeath;

        public bool _killUnderMaxHealth;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int num = targets[i].Unit.CurrentHealth;

                    if ((!_killUnderMaxHealth || targets[i].Unit.MaximumHealth < entryVariable) && targets[i].Unit.DirectDeath(caster, _obliterationDeath))
                    {
                        exitAmount += num;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class CasterRootActionByExitEffect : EffectSO
    {
        public EffectInfo[] effects;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] effectInfoArray = effects;
            exitAmount = 0;
            CombatManager.Instance.AddRootAction(new EffectAction(effectInfoArray, caster, base.PreviousExitValue));
            return true;
        }
        public static CasterRootActionByExitEffect Create(EffectInfo[] e)
        {
            CasterRootActionByExitEffect instance = CreateInstance<CasterRootActionByExitEffect>();
            instance.effects = e;
            return instance;
        }
    }
    public class CarryExitPastEffect : EffectSO
    {
        public EffectSO effect;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool ret = effect.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi);
            exitAmount = base.PreviousExitValue;
            return ret;
        }

        public static CarryExitPastEffect Create(EffectSO e)
        {
            CarryExitPastEffect ret = ScriptableObject.CreateInstance<CarryExitPastEffect>();
            ret.effect = e;
            return ret;
        }
    }
    public class UseExitAsEntryEffect : EffectSO
    {
        public EffectSO effect;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return effect.PerformEffect(stats, caster, targets, areTargetSlots, base.PreviousExitValue, out exitAmount);
        }

        public static UseExitAsEntryEffect Create(EffectSO e)
        {
            UseExitAsEntryEffect ret = ScriptableObject.CreateInstance<UseExitAsEntryEffect>();
            ret.effect = e;
            return ret;
        }
    }
    public class CrashesYourGameEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            UnityEngine.Diagnostics.Utils.ForceCrash(~ForcedCrashCategory.Abort);
            return true;
        }
    }
}
