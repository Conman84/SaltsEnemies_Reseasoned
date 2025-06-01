using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Debugger
    {
        //ZoneBGDataBaseSO
        public static BaseRoomHandler RunDataSO_PopulateRoomInstance(Func<RunDataSO, Card, BaseRoomHandler> orig, RunDataSO self, Card card)
        {
            try
            {
                return orig(self, card);
            }
            catch (Exception ex)
            {
                Debug.LogWarning("run data SO load card fail: " + card.RoomPrefabName);
                Debug.LogWarning("loading postmodern's room as a failsafe?");

                TalkingEntityContentData newEntity = new TalkingEntityContentData(PostmodernHandler.Dialogue);
                int idInfo = self.CurrentZoneData.AddDialoguePathData(newEntity);
                Card newCard = new Card(self.CurrentZoneData.CardCount, idInfo, CardType.Flavour, card.PilePosition, PostmodernHandler.Sign, PostmodernHandler.RoomPrefab);

                return orig(self, newCard);
                //throw ex;
            }
        }
        public static void ZoneBGDataBaseSO_TryGenerateNewCard(Action<ZoneBGDataBaseSO, CardInfo> orig, ZoneBGDataBaseSO self, CardInfo info)
        {
            orig(self, info);
            try
            {
                List<int> remove = new List<int>();
                for (int i = self._zoneData.ZoneCards.Length - 1; i >= 0; i--)
                {
                    Card card = self._zoneData.ZoneCards[i];
                    if (card.RoomPrefabName == "")
                    {
                        Debug.LogWarning("empty room prefab! For signID: " + card.SignID + " ; It is being removed.");
                        remove.Add(i);
                    }
                }
                foreach (int num in remove)
                {
                    self._zoneData._zoneCards.RemoveAt(num);
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning("ZoneBGDataBaseSO_TryGenerateNewCard failsafer failed?");
                Debug.Log(ex.ToString());
            }
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(RunDataSO).GetMethod(nameof(RunDataSO.PopulateRoomInstance), ~BindingFlags.Default), typeof(Debugger).GetMethod(nameof(RunDataSO_PopulateRoomInstance), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(ZoneBGDataBaseSO).GetMethod(nameof(ZoneBGDataBaseSO.TryGenerateNewCard), ~BindingFlags.Default), typeof(Debugger).GetMethod(nameof(ZoneBGDataBaseSO_TryGenerateNewCard), ~BindingFlags.Default));
        }
    }
}
