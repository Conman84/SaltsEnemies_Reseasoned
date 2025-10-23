using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using SaltEnemies_Reseasoned;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksFive
    {
        public static void Add()
        {
            CrowbarHandler.Setup();

            Basic_Item crowbar = new Basic_Item("Salt_Crowbar_SW");
            crowbar.Name = "Crowbar";
            crowbar.Flavour = "\"Melee of choice.\"";
            crowbar.Description = "On attempting to deal damage to a target with Shield, inflict 1 Frail on them.";
            crowbar.Icon = ResourceLoader.LoadSprite("item_crowbar.png");
            crowbar.EquippedModifiers = [];
            crowbar.TriggerOn = TriggerCalls.Count;
            crowbar.DoesPopUpInfo = false;
            crowbar.Conditions = [];
            crowbar.DoesActionOnTriggerAttached = false;
            crowbar.ConsumeOnTrigger = TriggerCalls.Count;
            crowbar.ConsumeOnUse = false;
            crowbar.ConsumeConditions = [];
            crowbar.ShopPrice = 4;
            crowbar.IsShopItem = true;
            crowbar.StartsLocked = true;
            crowbar.OnUnlockUsesTHE = true;
            crowbar.UsesSpecialUnlockText = false;
            crowbar.SpecialUnlockID = UILocID.None;
            crowbar.item._ItemTypeIDs = ["Knife"];
            crowbar.item.AddBlueSkyUnlock("Pepper_CH", "locked_crowbar.png", "ach_crowbar.png");

            PerformEffect_Item complex = new PerformEffect_Item("Salt_ComplexityAlgorithm_SW", []);
            complex.Name = "Complexity Algorithm";
            complex.Flavour = "\"You must answer this question: Is this divine intellect?\"";
            complex.Description = "Heal 40% more to targets on even positions.\nHeal 20% less to targets on odd positions.";
            complex.Icon = ResourceLoader.LoadSprite("item_complexityalgorithm.png");
            complex.TriggerOn = TriggerCalls.OnWillApplyHeal;
            complex.EquippedModifiers = [];
            complex.DoesPopUpInfo = false;
            complex.Conditions = [ScriptableObject.CreateInstance<ComplexityAlgorithmCondition>()];
            complex.DoesActionOnTriggerAttached = false;
            complex.ConsumeOnTrigger = TriggerCalls.Count;
            complex.ConsumeOnUse = false;
            complex.ConsumeConditions = [];
            complex.ShopPrice = 4;
            complex.IsShopItem = true;
            complex.StartsLocked = true;
            complex.OnUnlockUsesTHE = true;
            complex.UsesSpecialUnlockText = false;
            complex.SpecialUnlockID = UILocID.None;
            complex.item._ItemTypeIDs = [];
            complex.item.AddBlueSkyUnlock("Horrigan_CH", "locked_complexityalgorithm.png", "ach_complexityalgorithm.png");

            PerformEffect_Item sawblade = new PerformEffect_Item("Salt_Sawblade_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, Slots.Self, ScriptableObject.CreateInstance<NotRupturedCondition>()), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.Self)]);
            sawblade.Name = "Sawblade";
            sawblade.Flavour = "\"Don't scare me with that!\"";
            sawblade.Description = "On using an ability, if this party member is not Ruptured refresh their ability usage.\nGain 1 Ruptured on using an ability.";
            sawblade.Icon = ResourceLoader.LoadSprite("item_sawblade.png");
            sawblade.TriggerOn = TriggerCalls.OnAbilityUsed;
            sawblade.EquippedModifiers = [];
            sawblade.DoesPopUpInfo = true;
            sawblade.Conditions = [];
            sawblade.DoesActionOnTriggerAttached = false;
            sawblade.ConsumeOnTrigger = TriggerCalls.Count;
            sawblade.ConsumeOnUse = false;
            sawblade.ConsumeConditions = [];
            sawblade.ShopPrice = 4;
            sawblade.IsShopItem = true;
            sawblade.StartsLocked = true;
            sawblade.OnUnlockUsesTHE = true;
            sawblade.UsesSpecialUnlockText = false;
            sawblade.SpecialUnlockID = UILocID.None;
            sawblade.item._ItemTypeIDs = ["Knife"];
            sawblade.item.AddBlueSkyUnlock("BAB_CH", "locked_sawblade.png", "ach_sawblade.png");

            MultiPerformEffectItem blood = new MultiPerformEffectItem("Salt_BloodSword_SW", []);
            blood.Name = "Blood Sword";
            blood.Flavour = "\"Hurts a lot to use.\"";
            blood.Description = "Deal 25% more damage while at full health.\nThis item is destroyed on death.";
            blood.Icon = ResourceLoader.LoadSprite("item_bloodsword.png");
            blood.TriggerOn = TriggerCalls.OnWillApplyDamage;
            blood.EquippedModifiers = [];
            blood.DoesPopUpInfo = false;
            blood.Conditions = [ScriptableObject.CreateInstance<FullHealthEffectorCondition>(), ItemExtensions.Damage(25, true)];
            blood.DoesActionOnTriggerAttached = false;
            blood.ConsumeOnTrigger = TriggerCalls.Count;
            blood.ConsumeOnUse = false;
            blood.ConsumeConditions = [];
            blood.ShopPrice = 4;
            blood.IsShopItem = true;
            blood.StartsLocked = true;
            blood.OnUnlockUsesTHE = true;
            blood.UsesSpecialUnlockText = false;
            blood.SpecialUnlockID = UILocID.None;
            blood.item._ItemTypeIDs = ["Knife", "Meat"];
            blood.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Slots.Self)], [TriggerCalls.OnDeath], [], false));
            blood.item.AddBlueSkyUnlock("Otto_CH", "locked_bloodsword.png", "ach_bloodsword.png");

            PerformEffect_Item tacks = new PerformEffect_Item("Salt_BluntTacks_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Sides)]);
            tacks.Name = "Blunt Tacks";
            tacks.Flavour = "\"You could maybe hurt someone with these if you tried really really hard\"";
            tacks.Description = "At the start of each turn, inflict 1 Slip on the Left and Right allied positions.\nHeal 75% more to units in Slip.";
            tacks.Icon = ResourceLoader.LoadSprite("item_blunttacks.png");
            tacks.TriggerOn = TriggerCalls.OnTurnStart;
            tacks.EquippedModifiers = [];
            tacks.DoesPopUpInfo = true;
            tacks.Conditions = [];
            tacks.DoesActionOnTriggerAttached = false;
            tacks.ConsumeOnTrigger = TriggerCalls.OnWillApplyHeal;
            tacks.ConsumeOnUse = false;
            tacks.ConsumeConditions = [ScriptableObject.CreateInstance<HealMoreInSlipCondition>()];
            tacks.ShopPrice = 5;
            tacks.IsShopItem = false;
            tacks.StartsLocked = true;
            tacks.OnUnlockUsesTHE = true;
            tacks.UsesSpecialUnlockText = false;
            tacks.SpecialUnlockID = UILocID.None;
            tacks.item._ItemTypeIDs = [];
            tacks.item.AddBlueSkyUnlock("Class1_CH", "locked_blunttacks.png", "ach_blunttacks.png");

            PerformEffect_Item tears = new PerformEffect_Item("Salt_TearDrops_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<DecreaseLuckyBluePercentageEffect>(), 3, Slots.Self)]);
            tears.Name = "Tear Drops";
            tears.Flavour = "\"Fake it till you make it\"";
            tears.Description = "Increase healing dealt by the amount of Blue pigment in the pigment tray.\nReduce the Lucky Pigment chance percentage by 3 on using an ability.";
            tears.Icon = ResourceLoader.LoadSprite("item_teardrops.png");
            tears.EquippedModifiers = [];
            tears.TriggerOn = TriggerCalls.OnAbilityUsed;
            tears.DoesPopUpInfo = true;
            tears.Conditions = [];
            tears.DoesActionOnTriggerAttached = false;
            tears.ConsumeOnTrigger = TriggerCalls.OnWillApplyHeal;
            tears.ConsumeOnUse = false;
            tears.ConsumeConditions = [ScriptableObject.CreateInstance<HealMoreByBlueCondition>()];
            tears.ShopPrice = 4;
            tears.IsShopItem = true;
            tears.StartsLocked = true;
            tears.OnUnlockUsesTHE = true;
            tears.UsesSpecialUnlockText = false;
            tears.SpecialUnlockID = UILocID.None;
            tears.item._ItemTypeIDs = [];
            tears.item.AddBlueSkyUnlock("Carpy_CH", "locked_teardrops.png", "ach_teardrops.png");

            PerformEffect_Item spurs = new PerformEffect_Item("Salt_HorseSpurs_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, Slots.Self)]);
            spurs.Name = "Horse Spurs";
            spurs.Flavour = "\"You are the horse.\"";
            spurs.Description = "On receiving any damage, restore this party member's movement usage.";
            spurs.Icon = ResourceLoader.LoadSprite("item_horsespurs.png");
            spurs.EquippedModifiers = [];
            spurs.TriggerOn = TriggerCalls.OnDamaged;
            spurs.DoesPopUpInfo = false;
            spurs.Conditions = [];
            spurs.DoesActionOnTriggerAttached = false;
            spurs.ConsumeOnTrigger = TriggerCalls.Count;
            spurs.ConsumeOnUse = false;
            spurs.ConsumeConditions = [];
            spurs.ShopPrice = 2;
            spurs.IsShopItem = true;
            spurs.StartsLocked = true;
            spurs.OnUnlockUsesTHE = true;
            spurs.UsesSpecialUnlockText = false;
            spurs.SpecialUnlockID = UILocID.None;
            spurs.item._ItemTypeIDs = ["Fabric"];
            spurs.item.AddBlueSkyUnlock("Wiwi_CH", "locked_horsespurs.png", "ach_horsespurs.png");
        }
    }
}
