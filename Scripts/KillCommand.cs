using BepInEx.Logging;
using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class KillCommand
    {
        public static DebugCommand KILL;
        public static void Add()
        {
            KILL = new DebugCommand("kill", "Instantly kill all enemies.", new List<DebugCommandArgument>(), delegate
            {
                CombatManager.Instance.AddPriorityRootAction(new PerformDelegateAction(delegate (CombatStats x)
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        enemy.DirectDeath(null);
                    }
                }));
                DebugController.Instance.WriteLine("Killing all enemies.");
            });

            DebugController.Commands.children.Add(KILL);
        }
    }
}
