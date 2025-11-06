using BrutalAPI;
using MonoMod.RuntimeDetour;
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

                if (fish <= 0) item.AddItem(lockedSprite, ACH);
                else item.AddFishItem(fish, lockedSprite, ACH);
                GenerateBlueSkyUnlock(charID, item.name, charID + "_BlueSky_Unlock", ACH);
                GenerateBlueSkyAchievement(item._itemName, ACH, achSprite);
                AddSinglePearl(charID, ACH);

                if (Test) Debug.Log("added skies unlock: " + item._itemName);
            }
            else if (Test) Debug.LogWarning("character: " + charID + " does not exist!");
        }

        public static void GenerateBlueSkyUnlock(string characterID, string itemID, string unlock, string ACH)
        {
            //Unlocks.GetOrCreateUnlock_CustomFinalBoss("BlueSky_BOSS").AddUnlockData(characterID, Unlocks.GenerateUnlockData(unlock, ACH, "", "", [itemID]));
            Unlocks.GetOrCreateUnlock_CustomFinalBoss("BlueSky_BOSS").AddUnlockData(LoadedAssetsHandler.GetCharacter(characterID).entityID, Unlocks.GenerateUnlockData(unlock, ACH, "", "", [itemID]));
        }
        public static void GenerateBlueSkyAchievement(string itemName, string ACH, string achSprite)
        {
            new ModdedAchievements(itemName, "Unlocked a new item.", ResourceLoader.LoadSprite(achSprite), ACH).AddNewAchievementToCUSTOMCategory("BlueSky_BOSS", "The Dreamer");
        }
        public static void AddSinglePearl(string charID, string ACH)
        {
            LoadedAssetsHandler.GetCharacter(charID).m_BossAchData.Add(new CharFinalBossAchData("BlueSky_BOSS", ACH));
        }


        public static void Setup()
        {
            IDetour hook = new Hook(typeof(UnlockedAchievementsUIHandler).GetMethod(nameof(UnlockedAchievementsUIHandler.PopulateModdedList), ~System.Reflection.BindingFlags.Default), typeof(BlueSkyUnlockExtensions).GetMethod(nameof(UnlockedAchievementsUIHandler_PopulateModdedList), ~System.Reflection.BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(UnlockedAchievementsUIHandler).GetMethod(nameof(UnlockedAchievementsUIHandler.OnIconEnter), ~System.Reflection.BindingFlags.Default), typeof(BlueSkyUnlockExtensions).GetMethod(nameof(UnlockedAchievementsUIHandler_OnIconEnter), ~System.Reflection.BindingFlags.Default));
        }
        public static void UnlockedAchievementsUIHandler_PopulateModdedList(Action<UnlockedAchievementsUIHandler, int, AchievementModdedCategory> orig, UnlockedAchievementsUIHandler self, int id, AchievementModdedCategory modded)
        {
            if (modded._CategoryLocID == "BlueSky_BOSS")
            {
                int count = modded.achievementNames.Count;
                List<Sprite> list = new List<Sprite>();
                for (int i = 0; i < count; i++)
                {
                    AchievementBase_t moddedAchievementInfo = self._achievementDB.GetModdedAchievementInfo(modded.achievementNames[i]);

                    if (!moddedAchievementInfo.m_bAchieved && !moddedAchievementInfo.m_offlinebAchieved && !LoadedDBsHandler.InfoHolder.Game.DidCompleteQuest("Defacer_Quest")) continue;

                    list.Add((moddedAchievementInfo.m_offlinebAchieved ? moddedAchievementInfo.m_unlockedSprite : ((moddedAchievementInfo.m_specialLockedSprite != null) ? moddedAchievementInfo.m_specialLockedSprite : self._achievementDB.LockedAchSprite)));
                }
                
                if (list.Count > 0)
                {
                    UnlockCategoryUIPanel unlockCategoryUIPanel = UnityEngine.Object.Instantiate(self._categoryTemplate, self._categoryTemplate.GetParent);
                    self._ActiveCategories.Add(unlockCategoryUIPanel);
                    unlockCategoryUIPanel.TryInitializeUnlockableAchievements(id, self, list.ToArray(), modded._CategoryName, modded._CategoryLocID);
                }
            }
            else
            {
                orig(self, id, modded);
            }
        }

        public static void UnlockedAchievementsUIHandler_OnIconEnter(Action<UnlockedAchievementsUIHandler, int, int> orig, UnlockedAchievementsUIHandler self, int listID, int id)
        {
            AchievementCategory[] achievementCategories = self._achievementDB.AchievementCategories;
            List<AchievementModdedCategory> moddedAchievementCategories = self._achievementDB.ModdedAchievementCategories;
            if (listID >= 0 && listID < self._ActiveCategories.Count)
            {
                if (listID < achievementCategories.Length || moddedAchievementCategories[listID]._CategoryLocID != "BlueSky_BOSS")
                {
                    orig(self, listID, id);
                    return;
                }


                AchievementBase_t achievementBase_t = self.GetBlueSkyAchievementData(id, moddedAchievementCategories[listID]);
                if (achievementBase_t != null)
                {
                    Sprite sprite = (achievementBase_t.m_offlinebAchieved ? achievementBase_t.m_unlockedSprite : ((achievementBase_t.m_specialLockedSprite != null) ? achievementBase_t.m_specialLockedSprite : self._achievementDB.LockedAchSprite));
                    self._extraPanel.SetAchievementInformation(achievementBase_t, sprite);
                    self._achExtraPanel.TryOpenAchievementExtraMenu(achievementBase_t.m_extraInfoType);
                }
            }
            else
            {
                orig(self, listID, id);
            }
        }

        public static AchievementBase_t GetBlueSkyAchievementData(this UnlockedAchievementsUIHandler self, int id, AchievementModdedCategory modded)
        {
            int count = modded.achievementNames.Count;
            if (id < 0)
            {
                return null;
            }

            if (id < count)
            {
                List<string> real = [..modded.achievementNames];

                if (!LoadedDBsHandler.InfoHolder.Game.DidCompleteQuest("Defacer_Quest"))
                {
                    for (int i = real.Count - 1; i >= 0; i--)
                    {
                        if (!self._achievementDB.GetModdedAchievementInfo(real[i]).m_bAchieved && !self._achievementDB.GetModdedAchievementInfo(real[i]).m_offlinebAchieved)
                        {
                            real.RemoveAt(i);
                        }
                    }
                }

                if (id < real.Count)
                {
                    return self._achievementDB.GetModdedAchievementInfo(real[id]);
                }
            }

            return null;
        }
    }
}

