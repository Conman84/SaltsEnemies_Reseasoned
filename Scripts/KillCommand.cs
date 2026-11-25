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
        public static List<BasePassiveAbilitySO> EvilPassives = [];
        public static int ThisValue1;

        public static DebugCommand KILL;
        public static DebugCommand CHANGEBOSS;
        public static DebugCommand RESETFLEETING;
        public static DebugCommand HEAL;

        public static DebugCommand ADDEASYENEMY;
        public static DebugCommand ADDMEDIUMENEMY;
        public static DebugCommand ADDHARDENEMY;

        public static DebugCommand ADDENCOUNTERRANDOM;
        public static DebugCommand ADDENCOUNTERSUITE;

        public static DebugCommand TESTINGCOMMAND;
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

            HEAL = new DebugCommand("fullheal", "set health max all party members.", new List<DebugCommandArgument>()
            {
                //new BoolCommandArgumnt("do", true)
            }, delegate (List<FilledCommandArgument> args)
            {
                int val = LoadedDBsHandler.InfoHolder.Run.inGameData.GetIntData("youareafuckingTROGLODITE!!!!!");
                ThisValue1++;
                val++;
                bool amount = ThisValue1 <= 4 && val <= 8;
                LoadedDBsHandler.InfoHolder.Run.inGameData.SetIntData("youareafuckingTROGLODITE!!!!!", val);
                //if (args[0].TryRead<bool>(out bool input)) amount = input;

                LockedInPassiveAbility locked = ScriptableObject.CreateInstance<LockedInPassiveAbility>();
                locked._passiveName = "Locked In";
                locked.passiveIcon = ResourceLoader.LoadSprite("NoMenu.png");
                locked._enemyDescription = "The Pause Menu can no longer be accessed.";
                locked._characterDescription = "The Pause Menu can no longer be accessed.";
                locked.m_PassiveID = "NoPause_PA";
                locked.doesPassiveTriggerInformationPanel = false;
                locked._triggerOn = new TriggerCalls[] { TriggerCalls.Count };

                if (CombatManager._instance == null || CombatManager._instance.Equals(null))
                {
                    if (!amount) DebugController.Instance.WriteLine("FUCK YOU");
                    else DebugController.Instance.WriteLine("fulheal party");
                        //make it get overworld party data

                    foreach (CharacterInGameData chara in LoadedDBsHandler.InfoHolder.Run.playerData._characterList)
                    {
                        if (chara == null || chara.Equals(null)) continue;
                        if (chara.Character == null || chara.Character.Equals(null)) continue;

                        chara.CurrentHealth = chara.MaxHealth;

                        if (!amount)
                        {
                            chara.WearableModifiers.AddExtraPassive(locked);
                            chara.WearableModifiers.AddExtraPassive(Passives.Slippery);
                            chara.WearableModifiers.AddExtraPassive(Passives.Skittish);
                            chara.WearableModifiers.AddExtraPassive(Passives.Inferno);
                            chara.WearableModifiers.AddExtraPassive(Passives.Dying);
                            chara.WearableModifiers.AddExtraPassive(Passives.Delicate);
                            chara.WearableModifiers.AddExtraPassive(Passives.Leaky3);
                            chara.WearableModifiers.AddExtraPassive(Passives.Confusion);
                            chara.WearableModifiers.AddExtraPassive(Passives.Enfeebled);
                            chara.WearableModifiers.AddExtraPassive(Passives.Immortal);
                            chara.WearableModifiers.AddExtraPassive(Passives.Anointed2);
                            chara.WearableModifiers.AddExtraPassive(Passives.FleetingGenerator(10));
                            chara.WearableModifiers.AddExtraPassive(Passives.Absorb);
                            chara.WearableModifiers.AddExtraPassive(Violent.Generate(3));

                            foreach (BasePassiveAbilitySO passive in EvilPassives) chara.WearableModifiers.AddExtraPassive(passive);

                            chara.UpdateCurrentPassives();
                        }
                    }

                    return;
                }
                CombatManager.Instance.AddPriorityRootAction(new PerformDelegateAction(delegate (CombatStats x)
                {
                    if (!amount)
                    {
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                        {
                            chara.AddPassiveAbility(locked);
                            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(chara.ID, chara.IsUnitCharacter, locked._passiveName, locked.passiveIcon));
                        }
                        foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.CharacterSlots)
                        {
                            slot.ApplyFieldEffect(StatusField.OnFire, 99, 0);
                            slot.ApplyFieldEffect(StatusField.Constricted, 99, 0);
                            slot.ApplyFieldEffect(Slip.Object, 99, 0);
                        }
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                        {
                            chara.ApplyStatusEffect(StatusField.Ruptured, 99);
                            chara.ApplyStatusEffect(Acid.Object, 99);
                            chara.ApplyStatusEffect(Pimples.Object, 99);
                            chara.ApplyStatusEffect(StatusField.OilSlicked, 99);
                            chara.ApplyStatusEffect(StatusField.Frail, 99);
                            chara.ApplyStatusEffect(Entropy.Object, 99);
                            chara.ApplyStatusEffect(Left.Object, 99);
                            chara.ApplyStatusEffect(Drowning.Object, 99);
                        }
                    }

                    foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                    {
                        chara.SetHealthTo(chara.MaximumHealth);
                    }
                }));
                if (amount) DebugController.Instance.WriteLine("fullheal party.");
                else DebugController.Instance.WriteLine("lol");
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
                if (CombatManager._instance == null)
                {
                    DebugController.Instance.WriteLine("NOT IN COMBAT.");
                    return;
                }
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

            TESTINGCOMMAND = new DebugCommand("saltenemiestesting", "debug command for testing shit. i dun gotta explain nuthin to yah", new List<DebugCommandArgument>()
            {
                new NumericalCommandArgument("value1", null, null, true)
            }, delegate (List<FilledCommandArgument> args)
            {
                int amount = -1;
                if (args[0].TryRead<int>(out int input)) amount = input;

                if (amount == -1)
                {
                    Debug.Log("CURRENT SAVE FILE SLOTID: " + SaveDataManager_2024.CURRENTSLOTID);
                    Debug.Log("CURRENT SAVE FILE SLOT NUM: " + SaveDataManager_2024.SaveSlot.ToString());
                }

                if (amount == 65) LoadedDBsHandler.InfoHolder.Run.inGameData.SetBoolData(ShinyHandler.InRunData, false);

                if (amount == 99) Legacy.Update();

                if (amount == 301) NeverMind.ForceCensor(false);
                if (amount == 300) NeverMind.ForceCensor(true);

                if (amount == 365)
                {
                    SolitaireHandler.DreamScanner = 0;
                    CombatManager.Instance._informationHolder.Run.inGameData.SetIntData("DreamScanner", 0);
                }

                if (CombatManager._instance == null)
                {
                    Debug.LogWarning("You blew it.");

                    return;
                }

                CombatManager.Instance.AddPriorityRootAction(new PerformDelegateAction(delegate (CombatStats stats)
                {
                    if (amount == 66)
                    {
                        foreach (stats.combatSlots.EnemySlots) slot.ApplyFieldEffect(Looming.EnemyObject, 1, 0);
                        foreach (stats.combatSlots.CharacterSlots) slot.ApplyFieldEffect(Looming.CharaObject, 1, 0);
                    }
                }));
                DebugController.Instance.WriteLine("the command ran.");
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
            DebugController.Commands.children.Add(TESTINGCOMMAND);
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
