using BrutalAPI;
using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class AmalgaHandler
    {
        public static TriggerCalls call => (TriggerCalls)3301159;
        public static void NotifCheck(string name, object sender, object args)
        {
            if (name == TriggerCalls.OnAbilityUsed.ToString())
            {
                if (sender is IUnit unit)
                {
                    if (unit.IsUnitCharacter)
                    {
                        foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                            CombatManager.Instance.PostNotification(call.ToString(), enemy, unit);
                    }
                    else
                    {
                        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                            CombatManager.Instance.PostNotification(call.ToString(), chara, unit);
                    }
                }
            }
        }
        public static void Setup() => NotificationHook.AddAction(NotifCheck);
    }
    public class AmalgaSongEffect : EffectSO
    {
        public static int Amount = 0;
        public static void Reset() => Amount = 0;
        public bool Add = true;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool GOING = Amount > 0;
            if (Add) Amount++;
            else Amount--;
            if ((Amount > 0) == GOING) return Amount > 0;
            if (Amount > 0)
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("amalga thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(GO);
                changeMusic.Start();
            }
            else
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("amalga thread failed to shut down."); }
                }
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Amalga", 0);
            }
            return Amount > 0;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Amalga", out float num) == FMOD.RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100 && Amount > 0; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Amalga", i);
                System.Threading.Thread.Sleep(20);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
    public class AmalgaDropFishEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.CurrentHealth > 0) return false;
            if (LoadedDBsHandler.ItemPoolDB.TryGetItemLootListEffect(PoolList_GameIDs.FishingRod.ToString(), out ExtraLootListEffect fish))
            {
                return fish.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
            }
            return false;
        }
    }
    public class AmalgaWallConnectionEffect : EffectSO
    {
        public bool Connect;

        public static void RunEffect(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (caster.IsUnitCharacter || !caster.IsAlive) return;
            CombatManager.Instance._stats.TryTransformEnemy(caster.ID, LoadedAssetsHandler.GetEnemy("Amalga_EN"), true, false, false, false);
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (Connect) CombatManager.Instance.AddObserver(RunEffect, TriggerCalls.OnDamaged.ToString(), caster);
            else CombatManager.Instance.RemoveObserver(RunEffect, TriggerCalls.OnDamaged.ToString(), caster);
            return true;
        }

        public static AmalgaWallConnectionEffect Create(bool connect)
        {
            AmalgaWallConnectionEffect ret = ScriptableObject.CreateInstance<AmalgaWallConnectionEffect>();
            ret.Connect = connect;
            return ret;
        }
    }
}
