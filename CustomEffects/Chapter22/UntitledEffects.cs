using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;
using Yarn;

namespace SaltsEnemies_Reseasoned
{
    public class UntitledEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            //int bundle = stats.InfoHolder.Run.CurrentZoneData.GetCard(stats.InfoHolder.Run.CurrentCardID).IDInfo;

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
}
