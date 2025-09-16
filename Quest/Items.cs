using BrutalAPI;
using BrutalAPI.Items;
using HarmonyLib;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Items
    {
        public static bool Test = true;
        public static void AddFirst()
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
            choco.item.AddItem("Locked_ChocolateCoin.png", AchievementIDs.Shiny, Test);

            PerformEffect_Item sign = new PerformEffect_Item("Salt__CardboardSign_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, Slots.Self)], true);
            sign.Name = "Cardboard Sign";
            sign.Flavour = "\"Barely fooled me.\"";
            sign.Description = "On an enemy moving in front of this party member, gain 5 Shield.";
            sign.Icon = ResourceLoader.LoadSprite("Item_WoodSign.png");
            sign.EquippedModifiers = [];
            sign.TriggerOn = (TriggerCalls)AmbushManager.Patiently;
            sign.DoesPopUpInfo = true;
            sign.Conditions = [];
            sign.DoesActionOnTriggerAttached = false;
            sign.ConsumeOnTrigger = TriggerCalls.Count;
            sign.ConsumeOnUse = false;
            sign.ConsumeConditions = [];
            sign.ShopPrice = 8;
            sign.IsShopItem = true;
            sign.StartsLocked = true;
            sign.OnUnlockUsesTHE = true;
            sign.UsesSpecialUnlockText = false;
            sign.SpecialUnlockID = UILocID.None;
            sign.item.AddItem("Locked_WoodSign.png", AchievementIDs.SnakeGod, Test);

            PerformEffect_Item pom = new PerformEffect_Item("Salt_PomPoms_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Slots.Sides)]);
            pom.Name = "Pom-Poms";
            pom.Flavour = "\"It's the thought that counts.\"";
            pom.Description = "On dealing damage, apply 1 Power to the Left and Right allies.";
            pom.Icon = ResourceLoader.LoadSprite("Item_PomPom.png");
            pom.EquippedModifiers = [];
            pom.TriggerOn = TriggerCalls.OnDidApplyDamage;
            pom.DoesPopUpInfo = true;
            pom.Conditions = [];
            pom.DoesActionOnTriggerAttached = false;
            pom.ConsumeOnTrigger = TriggerCalls.Count;
            pom.ConsumeOnUse = false;
            pom.ConsumeConditions = [];
            pom.ShopPrice = 5;
            pom.IsShopItem = true;
            pom.StartsLocked = true;
            pom.OnUnlockUsesTHE = true;
            pom.UsesSpecialUnlockText = false;
            pom.SpecialUnlockID = UILocID.None;
            pom.item.AddItem("Locked_PomPom.png", AchievementIDs.Chapter1, Test);

            Basic_Item silver = new Basic_Item("Salt_SilverBullet_SW");
            silver.Name = "Silver Bullet";
            silver.Flavour = "\"Blessed death.\"";
            silver.Description = "On dealing damage to an enemy without Determined, apply 3 Determined to them.\nDeal double damage to enemies with Determined.";
            silver.Icon = ResourceLoader.LoadSprite("Item_SilverBullet.png");
            silver.EquippedModifiers = [];
            silver.TriggerOn = TriggerCalls.Count;
            silver.DoesPopUpInfo = false;
            silver.Conditions = [];
            silver.DoesActionOnTriggerAttached = false;
            silver.ConsumeOnTrigger = TriggerCalls.Count;
            silver.ConsumeOnUse = false;
            silver.ConsumeConditions = [];
            silver.ShopPrice = 2;
            silver.IsShopItem = true;
            silver.StartsLocked = true;
            silver.OnUnlockUsesTHE = true;
            silver.UsesSpecialUnlockText = false;
            silver.SpecialUnlockID = UILocID.None;
            silver.item._ItemTypeIDs = ["Magic"];
            silver.item.AddItem("Locked_SilverBullet.png", AchievementIDs.Chapter2, Test);

            PerformEffect_Item dues = new PerformEffect_Item("Salt_Dues_SW");
            dues.Name = "Dues";
            dues.Flavour = "\"You'll never catch me!\"";
            dues.Description = "At the start of the third turn, cancel all enemy abilities.";
            dues.Icon = ResourceLoader.LoadSprite("Item_Dues.png");
            dues.EquippedModifiers = [];
            dues.TriggerOn = TriggerCalls.OnTurnStart;
            dues.DoesPopUpInfo = true;
            dues.Conditions = [TurnPassedCondition.Create(3)];
            dues.DoesActionOnTriggerAttached = false;
            dues.ConsumeOnTrigger = TriggerCalls.Count;
            dues.ConsumeOnUse = false;
            dues.ConsumeConditions = [];
            dues.ShopPrice = 5;
            dues.IsShopItem = true;
            dues.StartsLocked = true;
            dues.OnUnlockUsesTHE = false;
            dues.UsesSpecialUnlockText = false;
            dues.SpecialUnlockID = UILocID.None;
            dues.item.AddItem("Locked_Dues.png", AchievementIDs.Chapter3, Test);

            Ability replicate = new Ability("Replicate", "Salt_Replicate_A");
            replicate.Description = "Perform the last ability used.";
            replicate.Rarity = Rarity.GetCustomRarity("rarity5");
            replicate.Cost = [Pigments.Purple];
            replicate.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<CopyLastAbilityEffect>(), 1, Slots.Self)];
            replicate.AddIntentsToTarget(Slots.Self, ["Misc"]);
            replicate.Visuals = null;
            replicate.GenerateEnemyAbility();
            ExtraAbility_Wearable_SMS add_replicate = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            add_replicate._extraAbility = replicate.GenerateCharacterAbility();

            Basic_Item cheat = new Basic_Item("Salt_CheatingMaterials_TW");
            cheat.Name = "Cheating Materials";
            cheat.Flavour = "\"...It's for single digit arithmatic.\"";
            cheat.Description = "Adds the extra ability \"Replicate\", which copies the last ability used.";
            cheat.Icon = ResourceLoader.LoadSprite("Item_CheatingMaterials.png");
            cheat.EquippedModifiers = [add_replicate];
            cheat.TriggerOn = TriggerCalls.Count;
            cheat.DoesPopUpInfo = false;
            cheat.Conditions = [];
            cheat.DoesActionOnTriggerAttached = false;
            cheat.ConsumeOnTrigger = TriggerCalls.Count;
            cheat.ConsumeOnUse = false;
            cheat.ConsumeConditions = [];
            cheat.ShopPrice = 5;
            cheat.IsShopItem = false;
            cheat.StartsLocked = true;
            cheat.OnUnlockUsesTHE = true;
            cheat.UsesSpecialUnlockText = false;
            cheat.SpecialUnlockID = UILocID.None;
            cheat.item.AddItem("Locked_CheatingMaterials.png", AchievementIDs.Chapter4, Test);

            //passive fruit we'll have to think about this one later. because.you know.
            AddPassiveEffect addWhimsy = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addWhimsy._passiveToAdd = Passives.GetCustomPassive("Whimsy");

            PerformEffect_Item scary = new PerformEffect_Item("Salt_Passivefruit_TW", [Effects.GenerateEffect(addWhimsy, 1, Slots.Front)]);
            scary.Name = "Passivefruit";
            scary.Flavour = "\"Scary.\"";
            scary.Description = "At the start of combat, add \"Whimsy\" as a passive to the Opposing enemy.";
            scary.Icon = ResourceLoader.LoadSprite("Item_Passivefruit.png");
            scary.EquippedModifiers = [];
            scary.TriggerOn = TriggerCalls.OnCombatStart;
            scary.DoesPopUpInfo = true;
            scary.Conditions = [];
            scary.DoesActionOnTriggerAttached = false;
            scary.ConsumeOnTrigger = TriggerCalls.Count;
            scary.ConsumeOnUse = false;
            scary.ConsumeConditions = [];
            scary.ShopPrice = 3;
            scary.IsShopItem = false;
            scary.StartsLocked = true;
            scary.OnUnlockUsesTHE = true;
            scary.UsesSpecialUnlockText = false;
            scary.SpecialUnlockID = UILocID.None;
            scary.item._ItemTypeIDs = ["Magic"];
            scary.item.AddItem("Locked_Passivefruit.png", AchievementIDs.Chapter5, Test);

            PerformEffect_Item fossil = new PerformEffect_Item("Salt_UnknownFossil_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 3, Targetting.Everything(false))]);
            fossil.Name = "Unknown Fossil";
            fossil.Flavour = "\"Relic of meaningless value.\"";
            fossil.Description = "At the start of every other turn, inflict 3 Roots on every enemy position.";
            fossil.Icon = ResourceLoader.LoadSprite("Item_UnknownFossil.png");
            fossil.EquippedModifiers = [];
            fossil.TriggerOn = TriggerCalls.OnTurnStart;
            fossil.DoesPopUpInfo = true;
            fossil.Conditions = [ScriptableObject.CreateInstance<EvenTurnCondition>()];
            fossil.DoesActionOnTriggerAttached = false;
            fossil.ConsumeOnTrigger = TriggerCalls.Count;
            fossil.ConsumeOnUse = false;
            fossil.ConsumeConditions = [];
            fossil.ShopPrice = 4;
            fossil.IsShopItem = false;
            fossil.StartsLocked = true;
            fossil.OnUnlockUsesTHE = true;
            fossil.UsesSpecialUnlockText = false;
            fossil.SpecialUnlockID = UILocID.None;
            fossil.item.AddItem("Locked_UnknownFossil.png", AchievementIDs.Chapter6, Test);

            PerformEffect_Item can = new PerformEffect_Item("Salt_TinCan_EW", [], true);
            can.Name = "Tin Can";
            can.Flavour = "\"You caught a... tin can!\"";
            can.Description = "On death, prevent it and heal 1 health.\nThis item is destroyed on activation and at the end of combat.";
            can.Icon = ResourceLoader.LoadSprite("Item_TinCan.png");
            can.EquippedModifiers = [];
            can.TriggerOn = TriggerCalls.CanDie;
            can.DoesPopUpInfo = false;
            can.Conditions = [ScriptableObject.CreateInstance<TinCanCondition>()];
            can.DoesActionOnTriggerAttached = false;
            can.ConsumeOnTrigger = TriggerCalls.OnCombatEnd;
            can.ConsumeOnUse = true;
            can.ConsumeConditions = [];
            can.ShopPrice = 3;
            can.IsShopItem = false;
            can.StartsLocked = true;
            can.OnUnlockUsesTHE = true;
            can.UsesSpecialUnlockText = true;
            can.SpecialUnlockID = UILocID.ItemFishLocationLabel;
            can.item.AddFishItem(2, "Locked_TinCan.png", AchievementIDs.Chapter7, Test);

            TrackIntegerReferenceCondition track = ScriptableObject.CreateInstance<TrackIntegerReferenceCondition>();
            track.StoredValue = "Echo_TW";
            
            MultiPerformEffectItem echo = new MultiPerformEffectItem("Salt_Echo_TW", []);
            echo.Name = "Echo";
            echo.Flavour = "\"Mediocre shot\"";
            echo.Description = "On dealing any damage, deal it again to the same position at the start of the next turn.\nTake all damage taken this combat at the end of each turn, from no one.";
            echo.Icon = ResourceLoader.LoadSprite("Item_Echo.png");
            echo.EquippedModifiers = [];
            echo.TriggerOn = TriggerCalls.OnDamaged;
            echo.DoesPopUpInfo = false;
            echo.Conditions = [track];
            echo.DoesActionOnTriggerAttached = false;
            echo.ConsumeOnTrigger = TriggerCalls.Count;
            echo.ConsumeOnUse = false;
            echo.ConsumeConditions = [];
            echo.ShopPrice = 8;
            echo.IsShopItem = false;
            echo.StartsLocked = true;
            echo.OnUnlockUsesTHE = true;
            echo.UsesSpecialUnlockText = false;
            echo.SpecialUnlockID = UILocID.None;
            EffectTrigger echo_second = new EffectTrigger([Effects.GenerateEffect(DamageByStoredValueFromNoOneEffect.Create("Echo_TW"), 1, Slots.Self)], [TriggerCalls.OnTurnFinished], [StoredValueCondition.Create("Echo_TW")]);
            echo.AddEffectTrigger(echo_second);
            echo.item._ItemTypeIDs = ["Magic"];
            echo.item.AddItem("Locked_Echo.png", AchievementIDs.Miriam, Test);

            PerformEffect_Item bell = new PerformEffect_Item("Salt_LittleBell_TW", [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, Targetting.HighestEnemy),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, Targetting.HighestAlly)
                ]);
            bell.Name = "Little Bell";
            bell.Flavour = "\"When it rings we all go to hell.\"";
            bell.Description = "At the start of each turn, inflict 10 Pale on the highest health enemy and party member.";
            bell.Icon = ResourceLoader.LoadSprite("Item_LittleBell.png");
            bell.EquippedModifiers = [];
            bell.TriggerOn = TriggerCalls.OnTurnStart;
            bell.DoesPopUpInfo = true;
            bell.Conditions = [];
            bell.DoesActionOnTriggerAttached = false;
            bell.ConsumeOnTrigger = TriggerCalls.Count;
            bell.ConsumeOnUse = false;
            bell.ConsumeConditions = [];
            bell.ShopPrice = 5;
            bell.IsShopItem = false;
            bell.StartsLocked = true;
            bell.OnUnlockUsesTHE = true;
            bell.UsesSpecialUnlockText = false;
            bell.SpecialUnlockID = UILocID.None;
            bell.item._ItemTypeIDs = ["Magic"];
            bell.item.AddItem("Locked_LittleBell.png", AchievementIDs.Chapter11, Test);

            PerformEffect_Item frenzy = new PerformEffect_Item("Salt_FeedingFrenzy_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 1, Targeting.AllUnits)]);
            frenzy.Name = "Feeding Frenzy";
            frenzy.Flavour = "\"Blood excitement.\"";
            frenzy.Description = "On getting a kill, apply 1 Haste to all party members and enemies.";
            frenzy.Icon = ResourceLoader.LoadSprite("Item_FeedingFrenzy.png");
            frenzy.EquippedModifiers = [];
            frenzy.TriggerOn = TriggerCalls.OnDeath;
            frenzy.DoesPopUpInfo = true;
            frenzy.Conditions = [];
            frenzy.DoesActionOnTriggerAttached = false;
            frenzy.ConsumeOnTrigger = TriggerCalls.Count;
            frenzy.ConsumeOnUse = false;
            frenzy.ConsumeConditions = [];
            frenzy.ShopPrice = 7;
            frenzy.IsShopItem = false;
            frenzy.StartsLocked = true;
            frenzy.OnUnlockUsesTHE = false;
            frenzy.UsesSpecialUnlockText = false;
            frenzy.SpecialUnlockID = UILocID.None;
            frenzy.item.AddItem("Locked_FeedingFrenzy.png", AchievementIDs.Chapter8, Test);

            PerformEffect_Item ear = new PerformEffect_Item("Salt_SpareEar_SW", [
                Effects.GenerateEffect(BasicEffects.GenPigment(Pigments.Red), 2, Slots.Self),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, Slots.Self)
                ]);
            ear.Name = "Spare Ear";
            ear.Flavour = "\"Too old to be reattached.\"";
            ear.Description = "On taking any damage, produce 2 Red pigment and gain 6 Shield.";
            ear.Icon = ResourceLoader.LoadSprite("Item_SpareEar.png");
            ear.EquippedModifiers = [];
            ear.TriggerOn = TriggerCalls.OnDamaged;
            ear.DoesPopUpInfo = true;
            ear.Conditions = [];
            ear.DoesActionOnTriggerAttached = false;
            ear.ConsumeOnTrigger = TriggerCalls.Count;
            ear.ConsumeOnUse = false;
            ear.ConsumeConditions = [];
            ear.ShopPrice = 1;
            ear.IsShopItem = true;
            ear.StartsLocked = true;
            ear.OnUnlockUsesTHE = false;
            ear.UsesSpecialUnlockText = false;
            ear.SpecialUnlockID = UILocID.None;
            ear.item.AddItem("Locked_SpareEar.png", AchievementIDs.Chapter9, Test);

            PerformEffect_Item feather = new PerformEffect_Item("Salt_FeatherGun_TW", []);
            feather.Name = "Feather Gun";
            feather.Flavour = "\"The weapon imbues the wielder with the eternal hatred of the little crow.\"";
            feather.Description = "Deal 15% more damage.\nDeal 100% more damage if the target is a Bird.";
            feather.Icon = ResourceLoader.LoadSprite("Item_FeatherGun.png");
            feather.EquippedModifiers = [];
            feather.TriggerOn = TriggerCalls.OnWillApplyDamage;
            feather.DoesPopUpInfo = false;
            feather.Conditions = [];
            feather.DoesActionOnTriggerAttached = false;
            feather.ConsumeOnTrigger = TriggerCalls.Count;
            feather.ConsumeOnUse = false;
            feather.ConsumeConditions = [];
            feather.ShopPrice = 9;
            feather.IsShopItem = false;
            feather.StartsLocked = true;
            feather.OnUnlockUsesTHE = true;
            feather.UsesSpecialUnlockText = false;
            feather.SpecialUnlockID = UILocID.None;
            feather.item.AddItem("Locked_FeatherGun.png", AchievementIDs.Chapter12, Test);

            PerformEffect_Item stage = new PerformEffect_Item("Salt_StageFright_SW", []);
            stage.Name = "Stage Fright";
            stage.Flavour = "\"Imagine them all as potatoes.\"";
            stage.Description = "If there is no Opposing enemy deal 30% more damage.";
            stage.Icon = ResourceLoader.LoadSprite("Item_StageFreight.png");
            stage.EquippedModifiers = [];
            stage.TriggerOn = TriggerCalls.OnWillApplyDamage;
            stage.DoesPopUpInfo = false;
            stage.Conditions = [ScriptableObject.CreateInstance<StageFrightCondition>()];
            stage.DoesActionOnTriggerAttached = false;
            stage.ConsumeOnTrigger = TriggerCalls.Count;
            stage.ConsumeOnUse = false;
            stage.ConsumeConditions = [];
            stage.ShopPrice = 5;
            stage.IsShopItem = true;
            stage.StartsLocked = true;
            stage.OnUnlockUsesTHE = false;
            stage.UsesSpecialUnlockText = false;
            stage.SpecialUnlockID = UILocID.None;
            stage.item.AddItem("Locked_StageFreight.png", AchievementIDs.Chapter13, Test);

            PercentageEffectorCondition fish_fifteen = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            fish_fifteen.triggerPercentage = 15;

            PerformEffect_Item fish = new PerformEffect_Item("Salt_Coelacanth_EW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Slots.Self)]);
            fish.Name = "Coelacanth";
            fish.Flavour = "\"You caught a... coelacanth! 150cm.\"";
            fish.Description = "On taking any damage, heal 2 health. 15% chance to be destroyed on activation.";
            fish.Icon = ResourceLoader.LoadSprite("Item_Coelocanth.png");
            fish.EquippedModifiers = [];
            fish.TriggerOn = TriggerCalls.OnDamaged;
            fish.DoesPopUpInfo = true;
            fish.Conditions = [];
            fish.DoesActionOnTriggerAttached = false;
            fish.ConsumeOnTrigger = TriggerCalls.Count;
            fish.ConsumeOnUse = true;
            fish.ConsumeConditions = [fish_fifteen];
            fish.ShopPrice = 3;
            fish.IsShopItem = false;
            fish.StartsLocked = true;
            fish.OnUnlockUsesTHE = true;
            fish.UsesSpecialUnlockText = true;
            fish.SpecialUnlockID = UILocID.ItemFishLocationLabel;
            fish.item.AddItem("Locked_Coelocanth.png", AchievementIDs.Chapter14, Test);

            PerformEffect_Item gas = new PerformEffect_Item("Salt_HormoneGasses_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 2, Slots.Front), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, Slots.Front, Effects.ChanceCondition(50))]);
            gas.Name = "Hormone Gasses";
            gas.Flavour = "\"Untested for side effects.\"";
            gas.Description = "On using an ability, inflict 2-3 Pimples on the Opposing enemy.";
            gas.Icon = ResourceLoader.LoadSprite("Item_HormoneGasses.png");
            gas.EquippedModifiers = [];
            gas.TriggerOn = TriggerCalls.OnAbilityUsed;
            gas.DoesPopUpInfo = true;
            gas.Conditions = [];
            gas.DoesActionOnTriggerAttached = false;
            gas.ConsumeOnTrigger = TriggerCalls.Count;
            gas.ConsumeOnUse = false;
            gas.ConsumeConditions = [];
            gas.ShopPrice = 2;
            gas.IsShopItem = true;
            gas.StartsLocked = true;
            gas.OnUnlockUsesTHE = true;
            gas.UsesSpecialUnlockText = false;
            gas.SpecialUnlockID = UILocID.None;
            gas.item.AddItem("Locked_HormoneGasses.png", AchievementIDs.Chapter15, Test);

            Basic_Item hat = new Basic_Item("Salt_GlowingHat_SW");
            hat.Name = "Glowing Hat";
            hat.Flavour = "\"Makes you visible to those in the dark.\"";
            hat.Description = "Before taking any damage, gain Spotlight.";
            hat.Icon = ResourceLoader.LoadSprite("Item_GlowingHat.png");
            hat.EquippedModifiers = [];
            hat.TriggerOn = TriggerCalls.Count;
            hat.DoesPopUpInfo = false;
            hat.Conditions = [];
            hat.DoesActionOnTriggerAttached = false;
            hat.ConsumeOnTrigger = TriggerCalls.Count;
            hat.ConsumeOnUse = false;
            hat.ConsumeConditions = [];
            hat.ShopPrice = 4;
            hat.IsShopItem = true;
            hat.StartsLocked = true;
            hat.OnUnlockUsesTHE = true;
            hat.UsesSpecialUnlockText = false;
            hat.SpecialUnlockID = UILocID.None;
            hat.item.AddItem("Locked_GlowingHat.png", AchievementIDs.Chapter16, Test);

            PerformEffect_Item wings = new PerformEffect_Item("Salt_ItsWings_TW", [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 5, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 10, Slots.Self, BasicEffects.DidThat(true))
                ]);
            wings.Name = "Its Wings";
            wings.Flavour = "\"As it spreads its wings for an old god, a heaven just for you burrows its way.\"";
            wings.Description = "At the start of combat, apply 5 Power to the Opposing enemy.\nIf successful, gain 10 Power.";
            wings.Icon = ResourceLoader.LoadSprite("Item_ItsWings.png");
            wings.EquippedModifiers = [];
            wings.TriggerOn = TriggerCalls.OnCombatStart;
            wings.DoesPopUpInfo = true;
            wings.Conditions = [];
            wings.DoesActionOnTriggerAttached = false;
            wings.ConsumeOnTrigger = TriggerCalls.Count;
            wings.ConsumeOnUse = false;
            wings.ConsumeConditions = [];
            wings.ShopPrice = 7;
            wings.IsShopItem = false;
            wings.StartsLocked = true;
            wings.OnUnlockUsesTHE = false;
            wings.UsesSpecialUnlockText = false;
            wings.SpecialUnlockID = UILocID.None;
            wings.item._ItemTypeIDs = ["Magic"];
            wings.item.AddItem("Locked_ItsWings.png", AchievementIDs.DeadGod, Test);

            PerformEffect_Item water = new PerformEffect_Item("Salt_DeepWater_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 2, Slots.Self)]);
            water.Name = "Deep Waters";
            water.Flavour = "\"So blue it's pitch black.\"";
            water.Description = "On taking any damage, gain 2 Anesthetics.";
            water.Icon = ResourceLoader.LoadSprite("Item_DeepWater.png");
            water.EquippedModifiers = [];
            water.TriggerOn = TriggerCalls.OnDamaged;
            water.DoesPopUpInfo = true;
            water.Conditions = [];
            water.DoesActionOnTriggerAttached = false;
            water.ConsumeOnTrigger = TriggerCalls.Count;
            water.ConsumeOnUse = false;
            water.ConsumeConditions = [];
            water.ShopPrice = 6;
            water.IsShopItem = false;
            water.StartsLocked = true;
            water.OnUnlockUsesTHE = true;
            water.UsesSpecialUnlockText = false;
            water.SpecialUnlockID = UILocID.None;
            water.item.AddItem("Locked_DeepWater.png", AchievementIDs.Deep, Test);

            LockedInPassiveAbility lockedIn = ScriptableObject.CreateInstance<LockedInPassiveAbility>();
            lockedIn._passiveName = "Locked In";
            lockedIn.passiveIcon = ResourceLoader.LoadSprite("NoMenu.png");
            lockedIn._enemyDescription = "The Pause Menu can no longer be accessed.";
            lockedIn._characterDescription = "The Pause Menu can no longer be accessed.";
            lockedIn.m_PassiveID = "NoPause_PA";
            lockedIn.doesPassiveTriggerInformationPanel = false;
            lockedIn._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
            AddPassiveEffect add_locked = ScriptableObject.CreateInstance<AddPassiveEffect>();
            add_locked._passiveToAdd = lockedIn;

            AnimationVisualsEffect visuals = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            visuals._visuals = ((LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").passiveAbilities[0] as ExtraAttackPassiveAbility)._extraAbility.ability.effects[0].effect as AnimationVisualsIfUnitEffect)._visuals;
            visuals._animationTarget = Slots.Self;
            DoubleEffectCondition awaken_double = ScriptableObject.CreateInstance<DoubleEffectCondition>();
            awaken_double.first = BasicEffects.DidThat(true);
            awaken_double.second = Effects.ChanceCondition(50);
            MultiPreviousEffectCondition awaken_prev = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            awaken_prev.previousAmount = [1, 2];
            awaken_prev.wasSuccessful = [false, true];
            Ability awaken = new Ability("Awaken", "Salt_Awaken_A");
            awaken.Description = "10% chance to kill either a random enemy or this party member.";
            awaken.Cost = [Pigments.Purple];
            awaken.Effects = new EffectInfo[3];
            awaken.Effects[0] = Effects.GenerateEffect(visuals, 1, Slots.Self, Effects.ChanceCondition(10));
            awaken.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Slots.Self, awaken_double);
            awaken.Effects[2] = Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targetting.Random(false), awaken_prev);
            awaken.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Damage_Death"]);
            awaken.AddIntentsToTarget(Slots.Self, ["Damage_Death"]);
            awaken.Visuals = null;
            awaken.GenerateEnemyAbility();
            ExtraAbility_Wearable_SMS awaken_a = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            awaken_a._extraAbility = awaken.GenerateCharacterAbility();

            PerformEffect_Item nine = new PerformEffect_Item("Salt_NineKey_TW", [Effects.GenerateEffect(add_locked, 1, Targeting.Unit_AllAllies)]);
            nine.Name = "Nine Key";
            nine.Flavour = "\"It's all just a dream.\"";
            nine.Description = "Adds the extra ability \"Awaken\", which has a chance to kill either them or a random enemy.\nAdds \"Locked In\" as a passive to all party members on combat start.";
            nine.Icon = ResourceLoader.LoadSprite("Item_NineKey.png");
            nine.EquippedModifiers = [];
            nine.TriggerOn = TriggerCalls.OnCombatStart;
            nine.DoesPopUpInfo = false;
            nine.Conditions = [];
            nine.DoesActionOnTriggerAttached = false;
            nine.ConsumeOnTrigger = TriggerCalls.Count;
            nine.ConsumeOnUse = false;
            nine.ConsumeConditions = [];
            nine.ShopPrice = 4;
            nine.IsShopItem = false;
            nine.StartsLocked = true;
            nine.OnUnlockUsesTHE = true;
            nine.UsesSpecialUnlockText = false;
            nine.SpecialUnlockID = UILocID.None;
            nine.item._ItemTypeIDs = ["Magic"];
            nine.item.AddItem("Locked_NineKey.png", AchievementIDs.Postmodern, Test);


            //abandoned artifact
            //as usual
            //Magic

            //torturepedia (10)

            //imperfect lullaby (19)
            //Magic

            //angel (18)

            //karmic offloading (20)
            //Magic

            //glue eye (21)

            //strepnut (17)

            //boss items








        }
    }
}
