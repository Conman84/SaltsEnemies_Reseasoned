using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using Yarn;
using Yarn.Unity;

namespace SaltsEnemies_Reseasoned
{
    public static class DialogueFunctions
    {
        public static OverworldManagerBG World;
        public static void Setup(DialogueRunner runner, OverworldManagerBG world)
        {
            runner.AddCommandHandler("ChangeCurrentBoss", SwapCurrentZoneBossByDialogue);
            runner.AddCommandHandler("GiftShopItem", GenerateItemPresent);
            runner.AddFunction("IsBlueSky", 0, (Value[] parameters) => CheckCurrentBossIsBlueSky());
        }
        public static void SwapCurrentZoneBossByDialogue(string[] info)
        {
            if (info.Length < 1)
            {
                return;
            }
            string text = info[0];
            RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
            if (run.CurrentZoneID >= run.zoneData.Count)
            {
                return;
            }
            RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
            ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
            if (zoneDataBaseSO == null || zoneDataBaseSO.Equals(null))
            {
                return;
            }
            EnemyCombatBundle[] bossBundleArray = runZoneData.BossBundleArray;
            if (bossBundleArray.Length == 0)
            {
                return;
            }
            EnemyCombatBundle enemyCombatBundle = bossBundleArray[bossBundleArray.Length - 1];
            if (!(text == enemyCombatBundle.BossID))
            {
                EnemyCombatBundle enemyCombatBundle2 = zoneDataBaseSO.TryGenerateBossBundle(text);
                if (enemyCombatBundle2 != null)
                {
                    runZoneData.SwapBossBundle(bossBundleArray.Length - 1, enemyCombatBundle2);
                }
            }
        }
        public static void GenerateItemPresent(string[] info)
        {
            World.StartCoroutine(World.ProcessBronzoPresent(BronzoPresentType.ShopItem));
        }
        public static bool CheckCurrentBossIsBlueSky()
        {
            RunDataSO run = LoadedDBsHandler.InfoHolder.Run;
            if (run.CurrentZoneID >= run.zoneData.Count)
            {
                return false;
            }
            RunZoneData runZoneData = run.zoneData[run.CurrentZoneID];
            ZoneDataBaseSO zoneDataBaseSO = runZoneData.LoadZoneDB();
            if (zoneDataBaseSO == null || zoneDataBaseSO.Equals(null))
            {
                return false;
            }
            EnemyCombatBundle[] bossBundleArray = runZoneData.BossBundleArray;
            if (bossBundleArray.Length == 0)
            {
                return false;
            }
            EnemyCombatBundle enemyCombatBundle = bossBundleArray[bossBundleArray.Length - 1];
            return "BlueSky_BOSS" == enemyCombatBundle.BossID;
        }
    }
}


//commands to use
//Unlock
//SetGameBoolData
//GetGameBoolData
//SaveProgress