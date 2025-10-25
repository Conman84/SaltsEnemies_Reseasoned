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
        public static DebugCommand CHANGEBOSS;
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

            CHANGEBOSS = new DebugCommand("changezoneboss", "Replaces the THIS area's boss. Can only replace the boss with bosses that can normally appear in the next area.", new List<DebugCommandArgument>
            {
                new StringCommandArgument("boss", DebugController.BossAutocomplete)
            }, delegate (List<FilledCommandArgument> args)
            {
                string text6 = args[0].Read<string>();
                RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
                if (run == null)
                {
                    DebugController.Instance.WriteLine("No active run.", LogLevel.Error);
                }
                else if (run.CurrentZoneID + 1 >= run.zoneData.Count)
                {
                    DebugController.Instance.WriteLine("No zone.", LogLevel.Error);
                }
                else
                {
                    RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
                    ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
                    if (zoneDataBaseSO == null || zoneDataBaseSO.Equals(null))
                    {
                        DebugController.Instance.WriteLine("Invalid zone.", LogLevel.Error);
                    }
                    else
                    {
                        EnemyCombatBundle[] bossBundleArray = runZoneData.BossBundleArray;
                        if (bossBundleArray.Length == 0)
                        {
                            DebugController.Instance.WriteLine("CURRENT zone has no boss.", LogLevel.Error);
                        }
                        else
                        {
                            EnemyCombatBundle enemyCombatBundle = bossBundleArray[bossBundleArray.Length - 1];
                            if (text6 == enemyCombatBundle.BossID)
                            {
                                DebugController.Instance.WriteLine("Successfully swapped the CURRENT zone's boss to " + text6);
                            }
                            else
                            {
                                EnemyCombatBundle enemyCombatBundle2 = zoneDataBaseSO.TryGenerateBossBundle(text6);
                                if (enemyCombatBundle2 == null)
                                {
                                    DebugController.Instance.WriteLine("Invalid boss \"" + text6 + "\"", LogLevel.Error);
                                }
                                else
                                {
                                    runZoneData.SwapBossBundle(bossBundleArray.Length - 1, enemyCombatBundle2);
                                    DebugController.Instance.WriteLine("Successfully swapped the THIS zone's boss to " + text6);
                                }
                            }
                        }
                    }
                }
            });

            DebugController.Commands.children.Add(KILL);
            DebugController.Commands.children.Add(CHANGEBOSS);
        }
    }
}
