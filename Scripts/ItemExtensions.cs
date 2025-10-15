using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class ItemExtensions
    {
        public static void AddItem(this BaseWearableSO item, string lockedSprite, string linkedACH, bool test = false)
        {
            if (test)
            {
                item.name += "_TEST";
                item.startsLocked = false;
            }

            if (item.isShopItem)
            {
                ItemUtils.AddItemToShopStatsCategoryAndGamePool(item, new ItemModdedUnlockInfo(item.name, ResourceLoader.LoadSprite(lockedSprite), linkedACH));
            }
            else
            {
                ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(item, new ItemModdedUnlockInfo(item.name, ResourceLoader.LoadSprite(lockedSprite), linkedACH));
            }
        }
        public static void AddFishItem(this BaseWearableSO item, int rarity, string lockedSprite, string linkedACH, bool test = false)
        {
            if (test)
            {
                item.name += "_TEST";
                item.startsLocked = false;
            }

            ItemUtils.AddItemFishingRodPool(item, rarity, item.startsLocked);
            ItemUtils.AddItemCanOfWormsPool(item, rarity, item.startsLocked);

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
        public static void ShowItem(this IUnit self)
        {
            if (self.IsUnitCharacter)
            {
                CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(self.ID, self.HeldItem.GetItemLocData().text, false, self.HeldItem.wearableImage));
            }
        }

        public static PercentageEffectorCondition Chance(int chance)
        {
            PercentageEffectorCondition ret = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            ret.triggerPercentage = chance;
            return ret;
        }
        public static EffectorConditionSO Damage(int percent, bool increase, bool ispercent = true)
        {
            if (!ispercent)
            {
                DamageIncreaseCondition dam = ScriptableObject.CreateInstance<DamageIncreaseCondition>();
                if (!increase) percent *= -1;
                dam.amount = percent;
                return dam;
            }

            DamageIncreasePercentCondition ret = ScriptableObject.CreateInstance<DamageIncreasePercentCondition>();
            ret.percentage = percent;
            ret.increase = increase;
            return ret;
        }
        public static EffectorConditionSO Heal(int percent, bool increase, bool ispercent = true)
        {
            if (!ispercent)
            {
                HealIncreaseCondition dam = ScriptableObject.CreateInstance<HealIncreaseCondition>();
                if (!increase) percent *= -1;
                dam.amount = percent;
                return dam;
            }

            HealIncreasePercentCondition ret = ScriptableObject.CreateInstance<HealIncreasePercentCondition>();
            ret.percentage = percent;
            ret.increase = increase;
            return ret;
        }
        public static EffectorConditionSO Defense(int percent, bool increase, bool direct)
        {
            DefenseCondition ret = ScriptableObject.CreateInstance<DefenseCondition>();
            ret.percentage = percent;
            ret.increase = increase;
            ret.directOnly = direct;
            return ret;
        }
    }

    public class DamageIncreasePercentCondition : EffectorConditionSO
    {
        public int percentage;
        public bool increase;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new PercentageValueModifier(true, percentage, increase));
            }
            return true;
        }
    }
    public class HealIncreasePercentCondition : EffectorConditionSO
    {
        public int percentage;
        public bool increase;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new PercentageValueModifier(true, percentage, increase));
            }
            return true;
        }
    }
    public class DamageIncreaseCondition : EffectorConditionSO
    {
        public int amount;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new AdditionValueModifier(true, amount));
            }
            return true;
        }
    }
    public class HealIncreaseCondition : EffectorConditionSO
    {
        public int amount;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is HealingDealtValueChangeException value)
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new AdditionValueModifier(true, amount));
            }
            return true;
        }
    }
    public class DefenseCondition : EffectorConditionSO
    {
        public int percentage;
        public bool increase;
        public bool directOnly;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException value && (value.directDamage || !directOnly))
            {
                (effector as IUnit).ShowItem();
                value.AddModifier(new PercentageValueModifier(false, percentage, increase));
            }
            return true;
        }
    }
}
