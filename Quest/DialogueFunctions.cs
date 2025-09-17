using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;
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
            World = UnityEngine.Object.FindObjectOfType<OverworldManagerBG>();
            World.StartCoroutine(ProcessPresent(BronzoPresentType.ShopItem));
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

        public static IEnumerator ProcessPresent(BronzoPresentType type)
        {
            yield return null;
            World.SaveProgress(saveRunToo: false);
            BaseWearableSO item = null;
            RunDataSO run = World._informationHolder.Run;
            ItemPoolDataBase itemPoolDB = LoadedDBsHandler.ItemPoolDB;
            switch (type)
            {
                case BronzoPresentType.TreasureItem:
                    item = itemPoolDB.TryGetPrizeItem(run.PrizesInRun, World._informationHolder.Game);
                    break;
                case BronzoPresentType.ShopItem:
                    item = itemPoolDB.TryGetShopItem(run.ShopItemsInRun, World._informationHolder.Game);
                    break;
            }
            if (type == BronzoPresentType.Combat)
            {
                string uIData = LocUtils.GameLoc.GetUIData(UILocID.PrizeGetLabel);
                string uIData2 = LocUtils.GameLoc.GetUIData(UILocID.ContinueButton);
                ConfirmDialogReference dialogReference = new ConfirmDialogReference(uIData, uIData2, "", null);
                NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference);
                while (dialogReference.result == DialogResult.Abort)
                {
                    yield return null;
                    NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference);
                }
                int currentZoneID = run.CurrentZoneID;
                int max = run.zoneData.Count - 1;
                int bronzoZoneChance = DataUtils.GetBronzoZoneChance();
                bronzoZoneChance = Mathf.Clamp(bronzoZoneChance, currentZoneID, max);
                World.AddSpecialPileEnemy(SignType_GameIDs.BronzoEnemy.ToString(), bronzoZoneChance);
                World._informationHolder.Run.inGameData.SetBoolData(DataUtils.bronzoIsGiftCombatVar, variable: true);
                while (dialogReference.result == DialogResult.None)
                {
                    yield return null;
                }
            }
            else if (item != null)
            {
                bool hasItemSpace = run.playerData.HasItemSpace;
                StringTrioData itemLocData = item.GetItemLocData();
                string text = string.Format(LocUtils.GameLoc.GetUIData(UILocID.PrizeGetLabel), itemLocData.text);
                if (!hasItemSpace)
                {
                    text = text + "\n" + LocUtils.GameLoc.GetUIData(UILocID.ItemNotEnoughSpace);
                }
                string uIData3 = LocUtils.GameLoc.GetUIData(UILocID.ContinueButton);
                ConfirmDialogReference dialogReference = new ConfirmDialogReference(text, uIData3, "", item.wearableImage, itemLocData.description);
                NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference);
                while (dialogReference.result == DialogResult.Abort)
                {
                    yield return null;
                    NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference);
                }
                World._soundManager.PlayOneshotSound(World._soundManager.itemGet);
                while (dialogReference.result == DialogResult.None)
                {
                    yield return null;
                }
                if (hasItemSpace)
                {
                    run.playerData.AddNewItem(item);
                }
                else
                {
                    World._extraItemMenuIsOpen = true;
                    World._extraUIHandler.OpenItemExchangeMenu(new BaseWearableSO[1] { item });
                    while (World._extraItemMenuIsOpen)
                    {
                        yield return null;
                    }
                }
            }
            else
            {
                int prize = DataUtils.GetBronzoMoney(type);
                string dialog = string.Format(LocUtils.GameLoc.GetUIData(UILocID.BronzoMoneyGetLabel), prize);
                string uIData4 = LocUtils.GameLoc.GetUIData(UILocID.ContinueButton);
                Sprite coinSprite = World._spritesDB.GetCoinSprite(prize);
                ConfirmDialogReference dialogReference = new ConfirmDialogReference(dialog, uIData4, "", coinSprite);
                NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference);
                while (dialogReference.result == DialogResult.Abort)
                {
                    yield return null;
                    NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference);
                }
                run.playerData.AddCurrency(prize);
                while (dialogReference.result == DialogResult.None)
                {
                    yield return null;
                }
                if (World._informationHolder.UnlockableManager.TryProcessSingleUnlockableFromID(UnlockableID.Over100Coins, World._informationHolder))
                {
                    World.StartCoroutine(World.ProcessOverworldAchievements());
                }
            }
            World._informationHolder.Run.inGameData.SetBoolData(DataUtils.bronzoTimeTravelVar, variable: false);
            World.SaveProgress(saveRunToo: true);
        }
    }
}


//commands to use
//Unlock
//SetGameBoolData
//GetGameBoolData
//SaveProgress