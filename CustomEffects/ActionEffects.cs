using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;



namespace SaltsEnemies_Reseasoned
{
    public class CasterRootActionEffect : EffectSO
    {
        public EffectInfo[] effects;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] effectInfoArray = effects;
            exitAmount = 0;
            CombatManager.Instance.AddRootAction(new EffectAction(effectInfoArray, caster, 0));
            return true;
        }
        public static CasterRootActionEffect Create(EffectInfo[] e)
        {
            CasterRootActionEffect instance = CreateInstance<CasterRootActionEffect>();
            instance.effects = e;
            return instance;
        }
    }
    public class CasterSubActionEffect : EffectSO
    {
        public EffectInfo[] effects;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] effectInfoArray = effects;
            exitAmount = 0;
            CombatManager.Instance.AddSubAction(new EffectAction(effectInfoArray, caster, 0));
            return true;
        }
        public static CasterSubActionEffect Create(EffectInfo[] e)
        {
            CasterSubActionEffect instance = CreateInstance<CasterSubActionEffect>();
            instance.effects = e;
            return instance;
        }
    }
    public class RootActionEffect : EffectSO
    {
        public EffectInfo[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] effectInfoArray = effects;
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddRootAction(new EffectAction(effectInfoArray, target.Unit, 0));
                    ++exitAmount;
                }
            }
            return exitAmount > 0;
        }

        public static RootActionEffect Create(EffectInfo[] e)
        {
            RootActionEffect instance = CreateInstance<RootActionEffect>();
            instance.effects = e;
            return instance;
        }
    }
    public class SubActionEffect : EffectSO
    {
        public EffectInfo[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] effectInfoArray = effects;
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(effectInfoArray, target.Unit, 0));
                    ++exitAmount;
                }
            }
            return exitAmount > 0;
        }

        public static SubActionEffect Create(EffectInfo[] e)
        {
            SubActionEffect instance = CreateInstance<SubActionEffect>();
            instance.effects = e;
            return instance;
        }
    }
    public class RootActionAction : CombatAction
    {
        public CombatAction ex;
        public RootActionAction(CombatAction a) => ex = a;

        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddRootAction(ex);
            yield return null;
        }
    }
    public class SubActionAction : CombatAction
    {
        public CombatAction ex;

        public SubActionAction(CombatAction a) => ex = a;

        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddSubAction(ex);
            yield return null;
        }
    }
    public class CarryExitValueEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = PreviousExitValue;
            return true;
        }
    }
}
