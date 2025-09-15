using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class ItemExtensions
    {
        public static void AddItem(this BaseWearableSO item, string lockedSprite, string linkedACH)
        {
            if (item.isShopItem)
            {
                ItemUtils.AddItemToShopStatsCategoryAndGamePool(item, new ItemModdedUnlockInfo(item.name, ResourceLoader.LoadSprite(lockedSprite), linkedACH));
            }
            else
            {
                ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(item, new ItemModdedUnlockInfo(item.name, ResourceLoader.LoadSprite(lockedSprite), linkedACH));
            }
        }
        public static void AddFishItem(this BaseWearableSO item, int rarity, string lockedSprite, string linkedACH)
        {
            ItemUtils.AddItemFishingRodPool(item, rarity, true);
            ItemUtils.AddItemCanOfWormsPool(item, rarity, true);

            ItemUtils.AddItemToCustomStatsCategoryAndGamePool(item, "Fish", "Fish", new ItemModdedUnlockInfo(item.name, ResourceLoader.LoadSprite(lockedSprite), linkedACH));
        }
        public static void AddItemData(ItemModdedUnlockInfo unlockInfo, string categoryID)
        {
            bool flag = false;
            foreach (ModdedItemCategory moddedItemCategory2 in LoadedDBsHandler.ItemUnlocksDB._ModdedItemCategories)
            {
                if (moddedItemCategory2.HasSameID(categoryID))
                {
                    flag = true;
                    moddedItemCategory2.lockedItemNames.Add(unlockInfo);
                }
            }

            if (!flag)
            {
                ModdedItemCategory moddedItemCategory = new ModdedItemCategory(categoryID, categoryID);
                moddedItemCategory.lockedItemNames.Add(unlockInfo);

                LoadedDBsHandler.ItemUnlocksDB._ModdedItemCategories.Add(moddedItemCategory);
            }
        }
    }
}
