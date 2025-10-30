using DG.Tweening;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using MonoMod.RuntimeDetour;

namespace SaltsEnemies_Reseasoned
{
    public class UntitledEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            //int bundle = stats.InfoHolder.Run.CurrentZoneData.GetCard(stats.InfoHolder.Run.CurrentCardID).IDInfo;

            UntitledHandler.Warp();
            CombatManager.Instance.StartCoroutine(LoadCombatScene(stats.InfoHolder, stats));

            exitAmount = 0;
            return true;
        }

        public IEnumerator LoadCombatScene(GameInformationHolder _informationHolder, CombatStats stats)
        {
            OverworldCombatSharedDataSO combatData = _informationHolder.CombatData;
            combatData.IsGameARun = true;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CombatScene");
            asyncLoad.allowSceneActivation = false;
            RoarData roarReference = combatData.enemyBundle.RoarReference;
            string bossID = combatData.enemyBundle.BossID;
            VsBossData data = LoadedDBsHandler._VSAnimDB.GetData(bossID);
            if (data != null)
            {
                //i dont think i'd be able to get this working sadly.
                /*_bossVSHandler.SetInformation(combatData.CharactersData);
                _bossVSHandler.PlayBossAnimation(bossID, data);
                _soundManager.ProcessRoar(roarReference);
                float initialTime = Time.time;
                _bossVSAnimationIsActive = true;
                while (_bossVSAnimationIsActive && Time.time - initialTime < data.roarTime)
                {
                    yield return null;
                }
                if (!_bossVSAnimationIsActive)
                {
                    stats.audioController.TryTerminateRoar();
                }
                _bossVSAnimationIsActive = false;*/
            }
            else
            {
                stats.audioController.ProcessRoar(roarReference);
            }
            CombatManager.Instance._fadeHandler.FadeInBlackScreen();
            while (CombatManager.Instance._fadeHandler.IsBlackScreenInTransition)
            {
                yield return null;
            }
            while (asyncLoad.progress < 0.9f)
            {
                yield return null;
            }
            stats.audioController.SetPauseData(pauseOpen: false, dialogueOpen: false, settingsOpen: false);
            DOTween.KillAll();
            asyncLoad.allowSceneActivation = true;
        }
    }

    public static class UntitledHandler
    {
        public static int Warped = 0;

        public static void Setup()
        {
            //NotificationHook.AddAction(NotifCheck);
            MainMenuException.AddAction(OnMenu);

            IDetour hook = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.FullSaveInCombatGame), ~BindingFlags.Default), typeof(UntitledHandler).GetMethod(nameof(CombatManager_FullSaveInCombatGame), ~BindingFlags.Default));
        }
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnCombatEnd.ToString()) Warped = 0;
        }
        public static void OnMenu()
        {
            Warped = 0;
        }
        public static void Warp() => Warped++;

        public static void CombatManager_FullSaveInCombatGame(Action<CombatManager> orig, CombatManager self)
        {
            try
            {
                if (CombatManager.Instance._stats.IsPassiveLocked("Aprils_Untitled_PA"))
                {
                    orig(self);
                    return;
                }

                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.ContainsPassiveAbility("Aprils_Untitled_PA")) return;
                }

                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.ContainsPassiveAbility("Aprils_Untitled_PA")) return;
                }
            }
            catch (Exception ex)
            {
                orig(self);
            }
        }
    }

    public class UntitledSongEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Warped", UntitledHandler.Warped > 0 ? 1 : 0);

            return true;
        }
    }
    public class DontRunGameEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance._isGameRun = false;
            return true;
        }
    }
}
