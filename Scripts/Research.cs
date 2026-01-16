using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Tools;
using Yarn.Unity;
using Yarn;

namespace SaltsEnemies_Reseasoned
{
    public static class Research
    {
        public static void Setup()
        {
            if (!SaltsReseasoned.Testing) return;

            IDetour hook1 = new Hook(typeof(UnboxOnNoEnemies_UUH).GetMethod(nameof(UnboxOnNoEnemies_UUH.CanBeUnboxed), ~BindingFlags.Default), typeof(Research).GetMethod(nameof(UnboxOnNoEnemies_UUH_CanUnbox), ~BindingFlags.Default));


            //IDetour hook2 = new Hook(typeof(DialogueHandler).GetMethod(nameof(DialogueHandler.DataInitialization), ~BindingFlags.Default), typeof(Research).GetMethod(nameof(DialogueHandler_DataInitialization), ~BindingFlags.Default));
            //IDetour hook3 = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(Research).GetMethod(nameof(OverworldManagerBG_Awake), ~BindingFlags.Default));
            //IDetour hook4 = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.GenerateZoneWorld), ~BindingFlags.Default), typeof(Research).GetMethod(nameof(OverworldManagerBG_GenerateZoneWorld), ~BindingFlags.Default));
        }

        public static bool UnboxOnNoEnemies_UUH_CanUnbox(Func<UnboxOnNoEnemies_UUH, CombatStats, BoxedUnit, object, bool> orig, UnboxOnNoEnemies_UUH self, CombatStats stats, BoxedUnit unit, object senderData)
        {
            foreach (TriggerCalls call in self.UnboxConditions) Debug.Log(call);
            return orig(self, stats, unit, senderData);
        }

        public static IEnumerator MainMenuController_LoadNextScene(Func<MainMenuController, string, IEnumerator> orig, MainMenuController self, string nextSceneName)
        {
            Debug.Log("loadnextscene " + nextSceneName); 
            
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
            asyncLoad.allowSceneActivation = false;

            Debug.Log("prepare tween");

            Tween t = self._blackScreen.FadeInBlackScreen(-1f);
            yield return t.WaitForCompletion();

            Debug.Log("waited for tween");

            while (asyncLoad.progress < 0.9f)
            {
                yield return null;
            }

            Debug.Log("loadprogress > 90%");

            asyncLoad.allowSceneActivation = true;

            Debug.Log("done");
        }
        public static void OverworldManagerBG_Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            Debug.Log("in");
            orig(self);
            Debug.Log("out");
            return;


            RunDataSO run = self._informationHolder.Run;
            if (run == null || run.Equals(null))
            {
                SceneManager.LoadScene(self._mainMenuSceneName);
                return;
            }

            Debug.Log("hi");

            self.InitializeNotifications();

            Debug.Log("initialize notifs");

            self._locManager.UpdateAllTexts();

            Debug.Log("loc manager update texts");

            switch (run.zoneLoadingType)
            {
                case ZoneLoadingType.ZoneStart:
                    Debug.Log("right before start courotuine");
                    self.StartCoroutine(self.GenerateZoneWorld());
                    break;
                case ZoneLoadingType.MainMenu:
                    self.StartCoroutine(self.LoadOverworld(manageEndLoading: true));
                    break;
                case ZoneLoadingType.Combat:
                    self.StartCoroutine(self.LoadAfterCombat());
                    break;
            }

            Debug.Log("started zoneloading");

            run.zoneLoadingType = ZoneLoadingType.MainMenu;
        }
        public static IEnumerator OverworldManagerBG_GenerateZoneWorld(Func<OverworldManagerBG, IEnumerator> orig, OverworldManagerBG self)
        {
            Debug.Log("hi");
            return orig(self);

            /*Debug.Log("hi");

            RunDataSO run = self._informationHolder.Run;
            run.ResetZoneData();

            Debug.Log("reset zone data");

            ZoneDataBaseSO currentZoneDB = run.CurrentZoneDB;
            self.SaveProgress(saveRunToo: true);

            Debug.Log("saveprogress a");

            SaveDataManager_2024.SaveCachedSaveFile();

            Debug.Log("saveprogress b");

            OverworldEnvironmentTransitionHandler overworldEnvironmentPrefab = currentZoneDB.GetOverworldEnvironmentPrefab();
            self._OwEnvHandler = UnityEngine.Object.Instantiate(overworldEnvironmentPrefab);

            Debug.Log("create room");

            self._OwEnvHandler.InitializeOWEnvironment(self._informationHolder.Game, self._characterVisuals);

            Debug.Log("initialize room");

            self._mainUIHandler.InitializeMenuData(run.CurrentZoneData, run.playerData, currentZoneDB.MaxLevelUpRank);
            Debug.Log("hi1");
            self._extraUIHandler.InitializeMenuData(run.playerData);
            Debug.Log("hi2");
            self._dialogueHandler.DataInitialization(self, self._informationHolder.Game, run, run.playerData, run.inGameData);
            Debug.Log("hi3");
            self._overworldUIHandler.Initialize(LoadedDBsHandler.Options.TimerActive);
            Debug.Log("hi4");

            Debug.Log("initialize data");

            self.SetUpPileData(playSound: false);

            Debug.Log("set pile data");

            bool pileButtonState = !run.IsCurrentCardType(CardType.Boss) && run.IsCurrentCardSolved();
            self._overworldUIHandler.SetPileButtonState(pileButtonState);

            Debug.Log("set pile ui");

            self._overworldUIHandler.UpdatePlayerCurrency(run.playerData.PlayerCurrency);

            Debug.Log("coin ui");

            self._characterVisuals.InitializeManager(currentZoneDB.ZoneStepSounds);
            self.UpdateCharacterVisuals(null, null);

            Debug.Log("charatervisuals");

            BaseRoomHandler currentRoomInstance = run.GetCurrentRoomInstance();
            //string ambienceEventID = currentZoneDB.AmbienceEventID;
            //string ambienceVariableID = currentZoneDB.RestAmbVarID;
            OverworldRoomState overworldMapState = OverworldRoomState.None;
            if (currentRoomInstance != null)
            {
                if (currentRoomInstance.HasRoomAmbience)
                {
                    //ambienceVariableID = currentRoomInstance.AmbienceVarID;
                }

                overworldMapState = currentRoomInstance.GetRoomState;
            }

            Debug.Log("ambiance");

            //self._soundManager.ForceSetAmbience(ambienceEventID, ambienceVariableID);
            self._soundManager.ForceSetOverworldMusicTrack(currentZoneDB.OverworldMusicEvent);
            self._soundManager.SetOverworldMapState(overworldMapState);

            Debug.Log("sound manager");

            self._fadeSystem.FadeOutBlackScreen();
            self._overworldInitialized = true;

            Debug.Log("should appear");

            self._inputManager.SetEscapeToggle(enabled: true);

            Debug.Log("set up escape");

            yield return self._achievementGetterHandler.ProcessUnlockedAchievements(self._informationHolder.UnlockableManager);

            Debug.Log("achievements");

            if (self._informationHolder.ExperiencedBadEnding)
            {
                NtfUtils.notifications.PostNotification(Tutorial_TriggerCalls.OW_AfterBadEasyEnding.ToString());
                self._informationHolder.DisableBadEndingExperience();
            }

            Debug.Log("done");*/
        }
        public static void DialogueHandler_DataInitialization(Action<DialogueHandler, IDialogueManagerData, IGameDialogueData, IRunDialogueData, IPlayerPartyData, IInGameRunData> orig, DialogueHandler self, IDialogueManagerData manager, IGameDialogueData game, IRunDialogueData run, IPlayerPartyData playerData, IInGameRunData dialogueData)
        {
            Debug.Log("in dialogue data init");

            self._playerData = playerData;
            self._dialogueData = dialogueData;

            Debug.Log("set");

            self._dialogueData.InitializeDialogueFunctions(self._dialogueRunner, run);

            Debug.Log("self initialize funcs");

            game.InitializeDialogueFunctions(self._dialogueRunner);

            Debug.Log("game initialize funcs");

            manager.InitializeDialogueFunctions(self._dialogueRunner);

            Debug.Log("manager initialize funcs");

            self._dialogueRunner.textLanguage = LocUtils.GameLoc.LocID;

            Debug.Log("load lang");

            if (self.debugDialogue)
            {
                self.StartConversation(self.program, self.startNode);
            }

            Debug.Log("done");
        }

    }
}
