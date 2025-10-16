using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public class HealingReceivedCondition : EffectorConditionSO
    {
        public int percent;
        public bool increase;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingReceivedValueChangeException reference)
            {
                (effector as IUnit).ShowItem();
                reference.AddModifier(new PercentageValueModifier(false, percent, increase));
            }
            return true;
        }

        public static HealingReceivedCondition Create(int percent, bool increase)
        {
            HealingReceivedCondition ret = ScriptableObject.CreateInstance<HealingReceivedCondition>();
            ret.increase = increase;
            ret.percent = percent;
            return ret;
        }
    }
    public class BigMosquitoCondition : EffectorConditionSO
    {
        public static string value => "BigMosquito_SW";
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference reference)
            {
                (effector as IUnit).SimpleSetStoredValue(value, (effector as IUnit).SimpleGetStoredValue(value) + reference.value);

                if ((effector as IUnit).SimpleGetStoredValue(value) < 21)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction([
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterShowItemEffect>()),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), reference.value, Slots.Self)
                        ], effector as IUnit));
                }
                else
                {
                    CombatManager.Instance.AddSubAction(new EffectAction([
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Slots.Self),
                        Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), reference.value, Slots.Self)
                        ], effector as IUnit));
                }
            }
            return true;
        }
    }
    public class HealMoreNonPurpleCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException reference && reference.healingUnit != null)
            {
                if (reference.healingUnit.HealthColor.pigmentTypes.Count > 1 || !reference.healingUnit.HealthColor.SharesPigmentColor(Pigments.Purple))
                {
                    (effector as IUnit).ShowItem();
                    reference.AddModifier(new PercentageValueModifier(true, 60, true));
                }
            }
            return true;
        }
    }
    public class HealMoreInSlipCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException reference && reference.healingUnit != null)
            {
                if (reference.healingUnit.ContainsFieldEffect(Slip.FieldID))
                {
                    (effector as IUnit).ShowItem();
                    reference.AddModifier(new PercentageValueModifier(true, 75, true));
                }
            }
            return false;
        }
    }
    public class SandDialCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference value)
            {
                (effector as IUnit).ShowItem();
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    enemy.ApplyStatusEffect(Entropy.Object, value.value);
                }
            }

            return false;
        }
    }
}
