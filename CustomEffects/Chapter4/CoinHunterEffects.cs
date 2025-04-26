using BrutalAPI;
using MonoMod.RuntimeDetour;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public static class ShinyHandler
    {
        public static bool added = false;
        public static bool enteredCombat = false;
        public static void Setup()
        {
            IDetour ForOnTurnStartIDetour = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(ShinyHandler).GetMethod(nameof(ForOnTurnStart), ~BindingFlags.Default));
        }

        public static int chance()
        {
            int ret = 0;
            try
            {
                if (CombatManager.Instance._stats.TurnsPassed > 1) ret += 4;
                if (CombatManager.Instance._stats.TurnsPassed > 2) ret /= 2;
                if (CombatManager.Instance._stats.TurnsPassed > 4) ret /= 2;
                if (CombatManager.Instance._stats.TurnsPassed > 8) return 0;
            }
            catch
            {
                Debug.LogError("not in combat");
                return 0;
            }
            return Math.Max(0, ret);
        }
        public static void ForOnTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            if (!self.InfoHolder.HardMode) return;
            //Debug.Log("entered");
            if (UnityEngine.Random.Range(0, 100) < chance() && ((CombatManager.Instance._stats.PlayerCurrency >= 32 && UnityEngine.Random.Range(0f, 1f) < 0.5f) || CombatManager.Instance._stats.PlayerCurrency >= 99) && !enteredCombat)
            {
                //Debug.Log("a");
                foreach (ItemInGameData itemData in CombatManager.Instance._informationHolder.Run.playerData._itemList)
                {
                    //Debug.Log("item");
                    if (itemData != (object)null)
                    {
                        if (itemData.Item != (object)null)
                        {
                            //Debug.Log("not null");
                            if (itemData.Item == LoadedAssetsHandler.GetWearable("ChocolateCoin_EW"))
                            {
                                enteredCombat = true;
                                return;
                            }
                        }
                    }
                }
                //Debug.Log("b");
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = false;
                allEnemy.getAllUnitSlots = true;
                EffectInfo effort1 = Effects.GenerateEffect(ScriptableObject.CreateInstance<SpawmShinyEffect>(), 1, Targeting.GenerateSlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false));
                CombatManager.Instance.AddSubAction(new EffectAction(new EffectInfo[] { effort1 }, CombatManager.Instance._stats.CharactersOnField.First().Value));
            }
        }
    }
    public class SpawmShinyEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;

            if (stats.BundleDifficulty == BundleDifficulty.Boss)
            {
                return false;
            }

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.MaximumHealth >= 80)
                    {
                        return false;
                    }
                    if (target.Unit is EnemyCombat enemy)
                    {
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo1_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo2_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo3_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo4_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo5_EN"))
                            return false;
                    }
                }
            }

            //Debug.Log("effect");
            foreach (TargetSlotInfo target in targets)
            {
                //Debug.Log("slot");
                if (!target.HasUnit)
                {
                    //Debug.Log("empty");
                    //ShinyHandler.Add();
                    CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("CoinHunter_EN"), -1, false, trySpawnAnyways: false, CombatType_GameIDs.Spawn_Basic.ToString()));
                    ShinyHandler.enteredCombat = true;
                    return true;
                }
            }

            return false;
        }
    }
}
