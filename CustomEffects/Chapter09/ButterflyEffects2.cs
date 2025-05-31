using FMODUnity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class ButterflyHitHandler
    {
        public static void NotifCheck(string notifname, object sender, object args)
        {
            if (notifname == TriggerCalls.OnDamaged.ToString() && sender is EnemyCombat enemy)
            {
                if (Check.EnemyExist("Spectre_EN") && enemy.Enemy == LoadedAssetsHandler.GetEnemy("Spectre_EN"))
                {
                    Vector3 loc = CombatManager.Instance._stats.combatUI._enemyZone._enemies[enemy.FieldID].FieldEntity.Position;
                    RuntimeManager.PlayOneShot("event:/Hawthorne/Boowomp", loc);
                }
            }
        }
        public static void Setup() => NotificationHook.AddAction(NotifCheck);
    }
}
