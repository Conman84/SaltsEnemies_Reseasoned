using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class PierceShieldHandler
    {
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnBeingDamaged.ToString() && args is DamageReceivedValueChangeException value)
            {
                if (value.possibleSourceUnit != null && value.possibleSourceUnit.HasUsableItem && value.possibleSourceUnit.HeldItem.IsItemType("PierceShield"))
                {
                    if ((sender as IUnit).ContainsFieldEffect("Shield_ID")) value.possibleSourceUnit.ShowItem();
                    value.ignoreShield = true;
                }
            }
        }
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck, true);
        }
    }

    public class CasterCloneItemEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.HasUsableItem)
            {
                for (int i = 0; i < entryVariable; i++)
                    stats.AddExtraLootAddition(caster.HeldItem.name);
                exitAmount = entryVariable;
            }
            return exitAmount > 0;
        }
    }
    public class RerollTargetConstructEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) target.Unit.TriggerNotification(((TriggerCalls)889532).ToString(), null);
            return true;
        }
    }
}
