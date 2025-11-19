using BrutalAPI;

/*---------------------------------INSTRUCTIONS---------------------------------
 
- change the namespace. 
- when adding the item, you can call Item.item.AddBlueSkyUnlock() instead of the normal additem shenanignans. example below.
- the script auto generates everything from setting the pearl on the menu character, generating the achievement, having the item be unlocked on beating the boss etc

    PerformEffect_Item sword = new PerformEffect_Item("Salt_PaperSword_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Slots.Front)]);
    sword.Name = "Paper Sword";
    sword.Flavour = "\"As sharp as it is feeble\"";
    sword.Description = "On dealing damage, inflict 2 Ruptured on the Opposing enemy.";
    sword.Icon = ResourceLoader.LoadSprite("item_papersword.png");
    sword.EquippedModifiers = [];
    sword.TriggerOn = TriggerCalls.OnDidApplyDamage;
    sword.DoesPopUpInfo = true;
    sword.Conditions = [];
    sword.DoesActionOnTriggerAttached = false;
    sword.ConsumeOnTrigger = TriggerCalls.Count;
    sword.ConsumeOnUse = false;
    sword.ConsumeConditions = [];
    sword.ShopPrice = 2;
    sword.IsShopItem = true;
    sword.StartsLocked = true;
    sword.OnUnlockUsesTHE = true;
    sword.UsesSpecialUnlockText = false;
    sword.SpecialUnlockID = UILocID.None;
    sword.item._ItemTypeIDs = ["Knife"];
    sword.item.AddBlueSkyUnlock("Boyle_CH", "locked_papersword.png", "ach_papersword.png");

- note: to add a fish item, you'd call like, sword.item.AddBlueSkyUnlock("etc_CH", "etc.png", "etc2.png", 5)
- where 5 would be like, the weight of the fish item, you'd change it as you want it to be. idk what the average weights for fish are though, sorry

misc details:
- this script doesnt add the pearl if it doesnt exist. if you want to add the pearl even if the user doesnt have saltenemies, you'll have to do that separately. personally though i'd be against it anyway for, well, personal reasons. 
- the unlock achievements are hidden if you dont have saltenemies installed. and if you do, they are hidden if you havent achieved them and havent finished the salt enemies collect my pages quest. this is for lore reasons. if it bothers you that much, you can modify the script yourself.
- with all that said, the items themselves will still be added and properly unlocked and everything even if you dont have saltenemies install.

---------------------------------------------------------------------------------------------*/


namespace YourNamespace
{
    public static class BlueSkyUnlockExtensions
    {
        public static void AddBlueSkyUnlock(this BaseWearableSO item, string charID, string lockedSprite, string achSprite, int fish = 0, bool ifFishAddFishCategory = true)
        {
            if (LoadedAssetsHandler.LoadedCharacters.ContainsKey(charID) || LoadedAssetsHandler.LoadCharacter(charID) != null)
            {
                string ACH = charID + "_BlueSky_ACH";

                if (fish <= 0) item.AddItem(lockedSprite, ACH);
                else item.AddFishItem(fish, lockedSprite, ACH, ifFishAddFishCategory);
                GenerateBlueSkyUnlock(charID, item.name, charID + "_BlueSky_Unlock", ACH);
                GenerateBlueSkyAchievement(item._itemName, ACH, achSprite);
                AddSinglePearl(charID, ACH);
            }
        }

        public static void GenerateBlueSkyUnlock(string characterID, string itemID, string unlock, string ACH)
        {
            Unlocks.GetOrCreateUnlock_CustomFinalBoss("BlueSky_BOSS").AddUnlockData(LoadedAssetsHandler.GetCharacter(characterID).entityID, Unlocks.GenerateUnlockData(unlock, ACH, "", "", [itemID]));
        }
        public static void GenerateBlueSkyAchievement(string itemName, string ACH, string achSprite)
        {
            ModdedAchievements madeAch = new ModdedAchievements(itemName, "Unlocked a new item.", ResourceLoader.LoadSprite(achSprite), ACH);
            if (LoadedAssetsHandler.LoadedEnemies.ContainsKey("BlueSky_BOSS")) madeAch.AddNewAchievementToCUSTOMCategory("BlueSky_BOSS", "The Dreamer");
            else madeAch.AddHiddenAchievement();
        }
        public static void AddSinglePearl(string charID, string ACH)
        {
            LoadedAssetsHandler.GetCharacter(charID).m_BossAchData.Add(new CharFinalBossAchData("BlueSky_BOSS", ACH));
        }
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
        public static void AddFishItem(this BaseWearableSO item, int rarity, string lockedSprite, string linkedACH, bool addFishCategory = true)
        {
            ItemUtils.AddItemFishingRodPool(item, rarity, item.startsLocked);
            ItemUtils.AddItemCanOfWormsPool(item, rarity, item.startsLocked);

            if (addFishCategory) ItemUtils.AddItemToCustomStatsCategoryAndGamePool(item, "Fish", "Fish", new ItemModdedUnlockInfo(item.name, ResourceLoader.LoadSprite(lockedSprite), linkedACH));
        }
        public static void AddHiddenAchievement(this ModdedAchievements self)
        {
            LoadedDBsHandler.AchievementDB._steamAchievements.TryAddModdedAchievement(self.achievement);
        }
    }
}
