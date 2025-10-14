using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AllyTriggersHandler
    {
        public static TriggerCalls AllyDirectDamaged => (TriggerCalls)972815615;

        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnDirectDamaged.ToString() && sender is IUnit unit1)
            {
                if (unit1.IsUnitCharacter)
                {
                    foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                    {
                        chara.TriggerNotification(AllyDirectDamaged.ToString(), args);
                    }
                }
                else
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        enemy.TriggerNotification(AllyDirectDamaged.ToString(), args);
                    }
                }
            }
        }

        public static void Setup()
        {
            NotificationHook.AddAction(NotifCheck);
        }
    }
}
