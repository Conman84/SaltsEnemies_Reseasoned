using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using SaltEnemies_Reseasoned;
using System.Runtime.Versioning;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksThree
    {
        public static void Add()
        {
            NoDamageThisCombatCondition.Setup();

            PerformEffect_Item house = new PerformEffect_Item("Salt_GlassHouse_TW", []);
            house.Name = "Glass House";
            house.Flavour = "\"Those in the stone house | Should not throw glass.\"";
            house.Description = "Increase damage dealt by 50% if this party member has not taken damage this combat.";
            house.Icon = ResourceLoader.LoadSprite("item_glasshouse.png");
            house.EquippedModifiers = [];
            house.TriggerOn = TriggerCalls.OnWillApplyDamage;
            house.DoesPopUpInfo = false;
            house.Conditions = [ScriptableObject.CreateInstance<NoDamageThisCombatCondition>(), ItemExtensions.Damage(50, true)];
            house.DoesActionOnTriggerAttached = false;
            house.ConsumeOnTrigger = TriggerCalls.Count;
            house.ConsumeOnUse = false;
            house.ConsumeConditions = [];
            house.ShopPrice = 6;
            house.IsShopItem = false;
            house.StartsLocked = true;
            house.OnUnlockUsesTHE = true;
            house.UsesSpecialUnlockText = false;
            house.SpecialUnlockID = UILocID.None;
            house.item._ItemTypeIDs = [];
            house.item.AddBlueSkyUnlock("Julios_CH", "locked_glasshouse.png", "ach_glasshouse.png");
        }
    }
}
