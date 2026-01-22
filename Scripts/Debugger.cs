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
                self.CurrentZoneData._zoneCards[self.CurrentCardID] = newCard;

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
        static EnemyCombat b;
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(RunDataSO).GetMethod(nameof(RunDataSO.PopulateRoomInstance), ~BindingFlags.Default), typeof(Debugger).GetMethod(nameof(RunDataSO_PopulateRoomInstance), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(ZoneBGDataBaseSO).GetMethod(nameof(ZoneBGDataBaseSO.TryGenerateNewCard), ~BindingFlags.Default), typeof(Debugger).GetMethod(nameof(ZoneBGDataBaseSO_TryGenerateNewCard), ~BindingFlags.Default));

            return;
            
            if (SaltsReseasoned.DebugVer)
            {
                Debug.LogWarning("this will throw an error. this doesnt mean anything is broken im intentionally throwing an error to make sure the method that protects against errors is working.");
                Debug.Log(b.Name);
            }
        }
    }

    public class DebugNPCRoom : NPCRoomHandler
    {
        public override void PrepareRoom()
        {
            if (SaltsReseasoned.Testing)
            {
                Debug.Log("talking entity data is gone: " + _entityData.IsGone);
                Debug.Log(RoomSelectables.Length);
                foreach (BaseRoomItem item in RoomSelectables)
                {
                    Debug.Log("item "+ item.transform.parent.name);
                }
            }
            base.PrepareRoom();
        }
    }
}
