using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class BlueSkyUnlockExtensions
    {
        public static bool Test => SaltsReseasoned.DebugVer;
        public static void AddBlueSkyUnlock(this BaseWearableSO item, string charID, string lockedSprite, string achSprite, int fish = 0)
        {
            if (LoadedAssetsHandler.LoadedCharacters.ContainsKey(charID) || LoadedAssetsHandler.LoadCharacter(charID) != null)
            {
                string ACH = charID + "_BlueSky_ACH";

                if (fish >= 0) item.AddItem(lockedSprite, ACH);
                else item.AddFishItem(fish, lockedSprite, ACH);
                GenerateBlueSkyUnlock(charID, item.name, charID + "_BlueSky_Unlock", ACH);
                GenerateBlueSkyAchievement(item._itemName, ACH, achSprite);
                AddSinglePearl(charID, ACH);
            }
            if (Test) Debug.Log("added skies unlock: " + item._itemName);
        }

        public static void GenerateBlueSkyUnlock(string characterID, string itemID, string unlock, string ACH)
        {
            Unlocks.GetOrCreateUnlock_CustomFinalBoss("BlueSky_BOSS").AddUnlockData(characterID, Unlocks.GenerateUnlockData(unlock, ACH, "", "", [itemID]));
        }
        public static void GenerateBlueSkyAchievement(string itemName, string ACH, string achSprite)
        {
            new ModdedAchievements(itemName, "Unlocked a new item.", ResourceLoader.LoadSprite(achSprite), ACH).AddNewAchievementToCUSTOMCategory("BlueSky_BOSS", "The Dreamer");
        }
        public static void AddSinglePearl(string charID, string ACH)
        {
            LoadedAssetsHandler.GetCharacter(charID).m_BossAchData.Add(new CharFinalBossAchData("BlueSky_BOSS", ACH));
        }
    }
}

