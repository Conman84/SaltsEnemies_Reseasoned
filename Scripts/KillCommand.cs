using BepInEx.Logging;
using BrutalAPI;
using HarmonyLib;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class KillCommand
    {
        public static DebugCommand KILL;
        public static DebugCommand CHANGEBOSS;
        public static DebugCommand RESETFLEETING;
        public static DebugCommand HEAL;

        public static DebugCommand ADDEASYENEMY;
        public static DebugCommand ADDMEDIUMENEMY;
        public static DebugCommand ADDHARDENEMY;

        public static DebugCommand ADDENCOUNTERRANDOM;
        public static DebugCommand ADDENCOUNTERSUITE;
        public static void Add()
        {
            KILL = new DebugCommand("kill", "Instantly kill all enemies.", new List<DebugCommandArgument>(), delegate
            {
                CombatManager.Instance.AddPriorityRootAction(new PerformDelegateAction(delegate (CombatStats x)
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        enemy.GenericDirectDeath(null);
                    }
                }));
                DebugController.Instance.WriteLine("Killing all enemies.");
            });

            HEAL = new DebugCommand("fullheal", "set health max all party members.", new List<DebugCommandArgument>(), delegate
            {
                if (CombatManager._instance == null || CombatManager._instance.Equals(null))
                {
                    DebugController.Instance.WriteLine("FUCK YOU");
                    //make it get overworld party data
                }
                CombatManager.Instance.AddPriorityRootAction(new PerformDelegateAction(delegate (CombatStats x)
                {
                    foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                    {
                        chara.SetHealthTo(chara.MaximumHealth);
                    }
                }));
                DebugController.Instance.WriteLine("fullheal party.");
            });

            CHANGEBOSS = new DebugCommand("changezoneboss", "Replaces the THIS area's boss. Can only replace the boss with bosses that can normally appear in the THIS area.", new List<DebugCommandArgument>
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
                else if (run.CurrentZoneID >= run.zoneData.Count)
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

            ADDEASYENEMY = new DebugCommand("addeasyenemyencounter", "Add an easy enemy encounter to the end of the zone.", new List<DebugCommandArgument>
            {
                new StringCommandArgument("enemybundle", new AutocompletionGroup(LoadEnemiesEasy))
            }, delegate (List<FilledCommandArgument> args)
            {
                string text6 = args[0].Read<string>();
                RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
                if (run == null)
                {
                    DebugController.Instance.WriteLine("No active run.", LogLevel.Error);
                }
                else if (run.CurrentZoneID >= run.zoneData.Count)
                {
                    DebugController.Instance.WriteLine("No zone.", LogLevel.Error);
                }
                else
                {
                    RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
                    ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
                    if (zoneDataBaseSO is ZoneBGDataBaseSO zone)
                    {
                        zone._zoneData = runZoneData;
                        zone.GenerateSpecificEnemyCard("easy", text6);
                    }
                    else
                    {
                        DebugController.Instance.WriteLine("Invalid zone.", LogLevel.Error);
                    }
                }
            });
            ADDMEDIUMENEMY = new DebugCommand("addmediumenemyencounter", "Add a medium enemy encounter to the end of the zone.", new List<DebugCommandArgument>
            {
                new StringCommandArgument("enemybundle", new AutocompletionGroup(LoadEnemiesMed))
            }, delegate (List<FilledCommandArgument> args)
            {
                string text6 = args[0].Read<string>();
                RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
                if (run == null)
                {
                    DebugController.Instance.WriteLine("No active run.", LogLevel.Error);
                }
                else if (run.CurrentZoneID >= run.zoneData.Count)
                {
                    DebugController.Instance.WriteLine("No zone.", LogLevel.Error);
                }
                else
                {
                    RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
                    ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
                    if (zoneDataBaseSO is ZoneBGDataBaseSO zone)
                    {
                        zone._zoneData = runZoneData;
                        zone.GenerateSpecificEnemyCard("medium", text6);
                    }
                    else
                    {
                        DebugController.Instance.WriteLine("Invalid zone.", LogLevel.Error);
                    }
                }
            });
            ADDHARDENEMY = new DebugCommand("addhardenemyencounter", "Add a hard enemy encounter to the end of the zone.", new List<DebugCommandArgument>
            {
                new StringCommandArgument("enemybundle", new AutocompletionGroup(LoadEnemiesHard))
            }, delegate (List<FilledCommandArgument> args)
            {
                string text6 = args[0].Read<string>();
                RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
                if (run == null)
                {
                    DebugController.Instance.WriteLine("No active run.", LogLevel.Error);
                }
                else if (run.CurrentZoneID >= run.zoneData.Count)
                {
                    DebugController.Instance.WriteLine("No zone.", LogLevel.Error);
                }
                else
                {
                    RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
                    ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
                    if (zoneDataBaseSO is ZoneBGDataBaseSO zone)
                    {
                        zone._zoneData = runZoneData;
                        zone.GenerateSpecificEnemyCard("hard", text6);
                    }
                    else
                    {
                        DebugController.Instance.WriteLine("Invalid zone.", LogLevel.Error);
                    }
                }
            });
            ADDENCOUNTERRANDOM = new DebugCommand("addrandomencounter", "Add a random enemy enocunter of difficulty 0 to 2", new List<DebugCommandArgument>
            {
                new NumericalCommandArgument("difficulty", 0, 2)
            }, delegate(List<FilledCommandArgument> args)
            {
                int difficulty = args[0].Read<int>();
                RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
                if (run == null)
                {
                    DebugController.Instance.WriteLine("No active run.", LogLevel.Error);
                }
                else if (run.CurrentZoneID >= run.zoneData.Count)
                {
                    DebugController.Instance.WriteLine("No zone.", LogLevel.Error);
                }
                else if (difficulty < 0 || difficulty > 2)
                {
                    DebugController.Instance.WriteLine("Out of bounds difficulty: use 0, 1, or 2", LogLevel.Error);
                }
                else
                {
                    RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
                    ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
                    if (zoneDataBaseSO is ZoneBGDataBaseSO zone)
                    {
                        zone._zoneData = runZoneData;
                        zone.GenerateRandomEnemyCard(difficulty);
                    }
                    else
                    {
                        DebugController.Instance.WriteLine("Invalid zone.", LogLevel.Error);
                    }
                }
            });
            ADDENCOUNTERSUITE = new DebugCommand("addrandomencountersuite", "Adds a number of random enemy encounters (default of 6)", new List<DebugCommandArgument>()
            {
                new NumericalCommandArgument("amount", 0, null, true)
            }, delegate (List<FilledCommandArgument> args)
            {
                int amount = 6;
                if (args[0].TryRead<int>(out int input)) amount = input;
                RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
                if (run == null)
                {
                    DebugController.Instance.WriteLine("No active run.", LogLevel.Error);
                }
                else if (run.CurrentZoneID >= run.zoneData.Count)
                {
                    DebugController.Instance.WriteLine("No zone.", LogLevel.Error);
                }
                else
                {
                    RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
                    ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
                    if (zoneDataBaseSO is ZoneBGDataBaseSO zone)
                    {
                        zone._zoneData = runZoneData;

                        for (int i = 0; i < amount; i++)
                        {
                            int dif = UnityEngine.Random.Range(0, 6);
                            switch (dif)
                            {
                                case 0:
                                    zone.GenerateRandomEnemyCard(0);
                                    break;
                                case 1:
                                    zone.GenerateRandomEnemyCard(1);
                                    break;
                                case 2:
                                    goto case 1;
                                case 3:
                                    goto case 1;
                                case 4:
                                    zone.GenerateRandomEnemyCard(2);
                                    break;
                                case 5:
                                    goto case 4;
                            }
                        }
                    }
                    else
                    {
                        DebugController.Instance.WriteLine("Invalid zone.", LogLevel.Error);
                    }
                }
            });

            RESETFLEETING = new DebugCommand("resetfleeting", "Reset fleeting on all enemies.", new List<DebugCommandArgument>(), delegate
            {
                CombatManager.Instance.AddPriorityRootAction(new PerformDelegateAction(delegate (CombatStats x)
                {
                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                    {
                        if (enemy.TryGetStoredData(UnitStoredValueNames_GameIDs.FleetingPA.ToString(), out UnitStoreDataHolder holder, false))
                            holder.m_MainData = 0;
                    }
                }));
                DebugController.Instance.WriteLine("resetfleeting all enemies.");
            });

            DebugController.Commands.children.Add(KILL);
            DebugController.Commands.children.Add(HEAL);
            DebugController.Commands.children.Add(CHANGEBOSS);
            DebugController.Commands.children.Add(ADDEASYENEMY);
            DebugController.Commands.children.Add(ADDMEDIUMENEMY);
            DebugController.Commands.children.Add(ADDHARDENEMY);
            DebugController.Commands.children.Add(ADDENCOUNTERRANDOM);
            DebugController.Commands.children.Add(ADDENCOUNTERSUITE);
            DebugController.Commands.children.Add(RESETFLEETING);
        }

        public static IEnumerable<string> LoadEnemiesEasy()
        {
            List<string> processed = new List<string>();

            if (LoadedDBsHandler.InfoHolder.Run == null || LoadedDBsHandler.InfoHolder.Run.CurrentZoneDB == null) yield break;

            ZoneBGDataBaseSO currentZone = LoadedDBsHandler.InfoHolder.Run.CurrentZoneDB as ZoneBGDataBaseSO;

            if (currentZone.EnemyEncounterData.m_EasySelector != null)
            {
                foreach (EnemyEncounter item in currentZone.EnemyEncounterData.m_EasySelector._enemyEncounters)
                {
                    if (item != null && !string.IsNullOrEmpty(item.BundleName))
                    {
                        BaseBundleGeneratorSO bundl = LoadedAssetsHandler.GetEnemyBundle(item.BundleName);
                        if (!(bundl == null) && !string.IsNullOrEmpty(item.BundleName) && !processed.Contains(item.BundleName))
                        {
                            if (!BundleEnabledCheck(item.BundleName)) continue;

                            yield return item.BundleName;
                            processed.Add(item.BundleName);
                        }
                    }
                }
            }
        }
        public static IEnumerable<string> LoadEnemiesMed()
        {
            List<string> processed = new List<string>();

            if (LoadedDBsHandler.InfoHolder.Run == null || LoadedDBsHandler.InfoHolder.Run.CurrentZoneDB == null) yield break;

            ZoneBGDataBaseSO currentZone = LoadedDBsHandler.InfoHolder.Run.CurrentZoneDB as ZoneBGDataBaseSO;

            if (currentZone.EnemyEncounterData.m_MediumSelector != null)
            {
                foreach (EnemyEncounter item in currentZone.EnemyEncounterData.m_MediumSelector._enemyEncounters)
                {
                    if (item != null && !string.IsNullOrEmpty(item.BundleName))
                    {
                        BaseBundleGeneratorSO bundl = LoadedAssetsHandler.GetEnemyBundle(item.BundleName);
                        if (!(bundl == null) && !string.IsNullOrEmpty(item.BundleName) && !processed.Contains(item.BundleName))
                        {
                            if (!BundleEnabledCheck(item.BundleName)) continue;

                            yield return item.BundleName;
                            processed.Add(item.BundleName);
                        }
                    }
                }
            }
        }
        public static IEnumerable<string> LoadEnemiesHard()
        {
            List<string> processed = new List<string>();

            if (LoadedDBsHandler.InfoHolder.Run == null || LoadedDBsHandler.InfoHolder.Run.CurrentZoneDB == null) yield break;

            ZoneBGDataBaseSO currentZone = LoadedDBsHandler.InfoHolder.Run.CurrentZoneDB as ZoneBGDataBaseSO;

            if (currentZone.EnemyEncounterData.m_HardSelector != null)
            {
                foreach (EnemyEncounter item in currentZone.EnemyEncounterData.m_HardSelector._enemyEncounters)
                {
                    if (item != null && !string.IsNullOrEmpty(item.BundleName))
                    {
                        BaseBundleGeneratorSO bundl = LoadedAssetsHandler.GetEnemyBundle(item.BundleName);
                        if (!(bundl == null) && !string.IsNullOrEmpty(item.BundleName) && !processed.Contains(item.BundleName))
                        {
                            if (!BundleEnabledCheck(item.BundleName)) continue;

                            yield return item.BundleName;
                            processed.Add(item.BundleName);
                        }
                    }
                }
            }
        }

        public static bool BundleEnabledCheck(string bundle)
        {
            if (DataManager.VersionCompatability.Contains(bundle)) return Legacy.Check;
            if (DataManager.Insiders.Contains(bundle)) return April.Custom;
            if (DataManager.KonamiMode.Contains(bundle)) return KonamiHandler.Solved;
            if (DataManager.Invisible.Contains(bundle)) return false;
            return true;
        }

        public static void GenerateSpecificEnemyCard(this ZoneBGDataBaseSO self, string difficulty, string bundleName)
        {
            if (self._zoneData == null) Debug.LogWarning("zonedata null");
            else if (self._zoneData.ZonePiles == null) Debug.LogWarning("zonepiles null");
            if (self._zoneData.ZonePiles.Length <= 0) return;

            EnemyCombatBundle enemyBundle = LoadedAssetsHandler.GetEnemyBundle(bundleName).GetEnemyBundle(difficulty == "easy" ? BundleDifficulty.Easy : difficulty == "medium" ? BundleDifficulty.Medium : BundleDifficulty.Hard, difficulty == "easy" ? self.EnemyEncounterData.m_EasySelector._defaultRoomPrefab : difficulty == "medium" ? self.EnemyEncounterData.m_MediumSelector._defaultRoomPrefab : self.EnemyEncounterData.m_HardSelector._defaultRoomPrefab);

            int idInfo = self._zoneData.AddEnemyBundle(enemyBundle);
            Card card = new Card(self._zoneData.CardCount, idInfo, difficulty == "easy" ? CardType.EnemyEasy : difficulty == "medium" ? CardType.EnemyMedium : CardType.EnemyHard, PilePositionType.Any, enemyBundle.SignID, enemyBundle.RoomPrefabName);
            self._zoneData.AddCard(card);

            int pileID = UnityEngine.Random.Range(0, self._zoneData.ZonePiles.Length);
            Card[] pile = self._zoneData.ZonePiles[pileID]._cards;
            List<Card> temp = new List<Card>();
            bool added = false;
            foreach (Card item in pile)
            {
                if (item.PilePosition != PilePositionType.End)
                {
                    temp.Add(item);
                }
                else
                {
                    if (!added) temp.Add(card);
                    added = true;
                    temp.Add(item);
                }
            }
            self._zoneData.ZonePiles[pileID]._cards = temp.ToArray();
            DebugController.Instance.WriteLine("Added enemy encounter " + bundleName);
        }
        public static void GenerateRandomEnemyCard(this ZoneBGDataBaseSO self, int difficulty)
        {
            if (self._zoneData == null) Debug.LogWarning("zonedata null");
            else if (self._zoneData.ZonePiles == null) Debug.LogWarning("zonepiles null");
            if (self._zoneData.ZonePiles.Length <= 0) return;

            EnemyEncounterSelectorSO selector = null;
            switch (difficulty)
            {
                case 0:
                    selector = self.EnemyEncounterData.m_EasySelector;
                    break;
                case 2:
                    selector = self.EnemyEncounterData.m_HardSelector;
                    break;
                default:
                    selector = self.EnemyEncounterData.m_MediumSelector;
                    break;
            }
            if (selector == null)
            {
                Debug.LogWarning("area has no enemy selectors?");
            }
            EnemyCombatBundle enemyBundle = selector.GetEnemyBundle();

            int idInfo = self._zoneData.AddEnemyBundle(enemyBundle);
            Card card = new Card(self._zoneData.CardCount, idInfo, difficulty == 0 ? CardType.EnemyEasy : difficulty == 2 ? CardType.EnemyHard : CardType.EnemyMedium, PilePositionType.Any, enemyBundle.SignID, enemyBundle.RoomPrefabName);
            self._zoneData.AddCard(card);

            int pileID = UnityEngine.Random.Range(0, self._zoneData.ZonePiles.Length);
            Card[] pile = self._zoneData.ZonePiles[pileID]._cards;
            List<Card> temp = new List<Card>();
            bool added = false;
            foreach (Card item in pile)
            {
                if (item.PilePosition != PilePositionType.End)
                {
                    temp.Add(item);
                }
                else
                {
                    if (!added) temp.Add(card);
                    added = true;
                    temp.Add(item);
                }
            }
            self._zoneData.ZonePiles[pileID]._cards = temp.ToArray();
            DebugController.Instance.WriteLine("Added random enemy encounter of difficulty " + difficulty.ToString());
        }
        /*public static EnemyCombatBundle GetZoneEnemyBundle(this ZoneBGDataBaseSO self, string difficulty, string bundleName)
        {
            EnemyCombatBundle ret = LoadedAssetsHandler.GetEnemyBundle(bundleName).GetEnemyBundle(difficulty == "easy" ? BundleDifficulty.Easy : difficulty == "medium" ? BundleDifficulty.Medium : BundleDifficulty.Hard, difficulty == "easy" ? self.EnemyEncounterData.m_EasySelector._defaultRoomPrefab : difficulty == "medium" ? self.EnemyEncounterData.m_MediumSelector._defaultRoomPrefab : self.EnemyEncounterData.m_HardSelector._defaultRoomPrefab);

            for (int i = 0; i < 999; i++)
            {
                foreach (EnemyBundleData enemy in ret._enemies)
                {
                    RandomEnemyBundleSO
                    if (!Check.EnemyExist(enemy.enemy)) continue;
                }
            }
        }*/
    }
}
