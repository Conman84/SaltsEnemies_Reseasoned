using BrutalAPI;
using MonoMod.RuntimeDetour;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Chocolate
    {
        public static Dictionary<string, int> realPrices = new Dictionary<string, int>();
        public static void SetInformation(Action<ShopMenuUIHandler, int> orig, ShopMenuUIHandler self, int ShopID)
        {
            foreach (ItemInGameData itemData in LoadedDBsHandler.InfoHolder.Run.playerData._itemList)
            {
                if (itemData != null)
                {
                    if (itemData.Item.name.Contains("ChocolateCoin"))
                    {
                        if (realPrices == null) realPrices = new Dictionary<string, int>();

                        foreach (RunZoneData zone in LoadedDBsHandler.InfoHolder.Run.zoneData)
                        {
                            foreach (ShopContentData shopData in zone._zoneShopData)
                            {
                                foreach (ShopItemData shopItem in shopData.shopItems)
                                {
                                    if (realPrices.ContainsKey(shopItem.item.name)) continue;

                                    realPrices.Add(shopItem.item.name, shopItem.item.shopPrice);

                                    float newPrice = shopItem.item.shopPrice;
                                    newPrice *= 0.8f;
                                    int gap = (int)Math.Floor(newPrice);
                                    shopItem.item.shopPrice = gap;
                                }
                            }
                        }

                        break;
                    }

                }
            }
            orig(self, ShopID);
        }
        public static void HideMenu(Action<ShopMenuUIHandler> orig, ShopMenuUIHandler self)
        {
            orig(self);

            foreach (string key in realPrices.Keys)
            {
                LoadedAssetsHandler.GetWearable(key).shopPrice = realPrices[key];
            }

            realPrices.Clear();
        }
        public static void Hook()
        {
            IDetour shopOpenedIDetour = (IDetour)new Hook((MethodBase)typeof(ShopMenuUIHandler).GetMethod("SetInformation", ~BindingFlags.Default), typeof(Chocolate).GetMethod("SetInformation", ~BindingFlags.Default));
            IDetour shopClosedIDetour = (IDetour)new Hook((MethodBase)typeof(ShopMenuUIHandler).GetMethod("HideMenu", ~BindingFlags.Default), typeof(Chocolate).GetMethod("HideMenu", ~BindingFlags.Default));
        }
        public static bool added = false;
    }

    public class NotEnemyOnSlotIDEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return !CombatManager.Instance._stats.combatSlots.EnemySlots[effector.SlotID].HasUnit;
        }
    }

    public class AddPassiveWithDisplayEffect : EffectSO
    {
        public BasePassiveAbilitySO passive;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<int> ids = [];
            List<bool> ischars = [];
            List<string> passives = [];
            List<Sprite> sprites = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.AddPassiveAbility(passive))
                {
                    exitAmount++;
                    ids.Add(target.Unit.ID);
                    ischars.Add(target.Unit.IsUnitCharacter);
                    passives.Add(passive.GetPassiveLocData().text + " Added");
                    sprites.Add(passive.passiveIcon);
                }
            }

            CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(ids.ToArray(), ischars.ToArray(), passives.ToArray(), sprites.ToArray()));

            return exitAmount > 0;
        }
    }
    public class RemovePassiveWithDisplayEffect : EffectSO
    {
        public BasePassiveAbilitySO passive;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<int> ids = [];
            List<bool> ischars = [];
            List<string> passives = [];
            List<Sprite> sprites = [];
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.TryRemovePassiveAbility(passive.m_PassiveID))
                {
                    exitAmount++;
                    ids.Add(target.Unit.ID);
                    ischars.Add(target.Unit.IsUnitCharacter);
                    passives.Add(passive.GetPassiveLocData().text + " Removed");
                    sprites.Add(passive.passiveIcon);
                }
            }

            CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(ids.ToArray(), ischars.ToArray(), passives.ToArray(), sprites.ToArray()));

            return exitAmount > 0;
        }
    }
}
