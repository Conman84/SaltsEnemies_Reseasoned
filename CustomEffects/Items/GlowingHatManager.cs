using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class GlowingHatManager
    {
        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck, true);
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnBeingDamaged.ToString() && sender is IUnit unit)
            {
                if (unit.HasUsableItem && unit.HeldItem.name.Contains("Salt_GlowingHat"))
                {
                    unit.ShowItem();
                    unit.ApplyStatusEffect(BrutalAPI.StatusField.Spotlight, 1);
                }
            }
        }
    }
}
