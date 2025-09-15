using BrutalAPI;
using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class Items
    {
        public static bool Test = true;
        public static void Add()
        {
            Basic_Item choco = new Basic_Item("Salt_ChocolateCoin_TW");
            choco.Name = "Chocolate Coin";
            choco.Flavour = "\"Reduced value.\"";
            choco.Description = "While this item is in your inventory, decrease the price of all items in the shop by 20%.";
            choco.Icon = ResourceLoader.LoadSprite("Item_ChocolateCoin.png");
            choco.EquippedModifiers = [];
            choco.TriggerOn = TriggerCalls.Count;
            choco.DoesPopUpInfo = false;
            choco.Conditions = [];
            choco.DoesActionOnTriggerAttached = false;
            choco.ConsumeOnTrigger = TriggerCalls.Count;
            choco.ConsumeOnUse = false;
            choco.ConsumeConditions = [];
            choco.ShopPrice = 0;
            choco.IsShopItem = false;
            choco.StartsLocked = true;
            choco.OnUnlockUsesTHE = true;
            choco.UsesSpecialUnlockText = false;
            choco.SpecialUnlockID = UILocID.None;
            choco.item.AddItem("Locked_ChocolateCoin.png", AchivementIDs.Shiny, Test);
            
        }
    }
}
