using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public class NoDamageThisCombatCondition : EffectorConditionSO
    {
        public static string Damaged => "NoDamageConditionSO";
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return (effector as IUnit).SimpleGetStoredValue(Damaged) <= 0;
        }

        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnDamaged.ToString() && sender is IUnit unit) unit.SimpleSetStoredValue(Damaged, 1);
        }
    }

    public static class CrowbarHandler
    {
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnWillApplyDamage.ToString() && sender is IUnit unit && args is DamageDealtValueChangeException value)
            {
                if (value.damagedUnit != null && value.damagedUnit.ContainsFieldEffect("Shield_ID") && unit.HasUsableItem && unit.HeldItem.name == "Salt_Crowbar_SW")
                {
                    unit.ShowItem();
                    value.damagedUnit.ApplyStatusEffect(StatusField.Frail, 1);
                }
            }
        }
    }

    public class ComplexityAlgorithmCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                for (int i = value.healingUnit.SlotID; i < value.healingUnit.SlotID + value.healingUnit.Size; i++)
                {
                    if ((i + 1) % 2 == 0) value.AddModifier(new PercentageValueModifier(true, 40, true));
                    else value.AddModifier(new PercentageValueModifier(true, 20, false));
                }
            }
            return true;
        }
    }

    public class FullHealthEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return effector.CurrentHealth >= effector.MaximumHealth;
        }
    }
    public class NotRupturedCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return !caster.ContainsStatusEffect("Ruptured_ID");
        }
    }

    public class KaleidoscopeCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is CascadeSpecialBooleanReference reference)
            {
                if (reference.Info.Target.HealthColor.SharesPigmentColor(Pigments.Red)) return false;
                (effector as IUnit).ShowItem();
                reference.value = true;
            }
            return true;
        }
    }
}
