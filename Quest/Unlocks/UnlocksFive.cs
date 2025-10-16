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

            RandomizeAllManaEffect randomize = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
            randomize.manaRandomOptions = [Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple];

            ExtraPassiveAbility_Wearable_SMS unstable = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            unstable._extraPassiveAbility = Passives.Unstable;

            PerformEffect_Item rubber = new PerformEffect_Item("Salt_RubberKnife_SW", [Effects.GenerateEffect(randomize, 1, Slots.Self)]);
            rubber.Name = "Rubber Knife";
            rubber.Flavour = "\"Wibbly Wobbly\"";
            rubber.Description = "This party member has \"Unstable\" as a passive.\nOn using an ability, randomize all pigment.";
            rubber.Icon = ResourceLoader.LoadSprite("item_rubberknife.png");
            rubber.TriggerOn = TriggerCalls.OnAbilityUsed;
            rubber.EquippedModifiers = [unstable];
            rubber.DoesPopUpInfo = true;
            rubber.Conditions = [];
            rubber.DoesActionOnTriggerAttached = false;
            rubber.ConsumeOnTrigger = TriggerCalls.Count;
            rubber.ConsumeOnUse = false;
            rubber.ConsumeConditions = [];
            rubber.ShopPrice = 2;
            rubber.IsShopItem = true;
            rubber.StartsLocked = true;
            rubber.OnUnlockUsesTHE = true;
            rubber.UsesSpecialUnlockText = false;
            rubber.SpecialUnlockID = UILocID.None;
            rubber.item._ItemTypeIDs = ["Knife"];
            rubber.item.AddBlueSkyUnlock("Rhys_CH", "locked_rubberknife.png", "ach_rubberknife.png");

            PerformEffect_Item boot = new PerformEffect_Item("Salt_MuddyBoot_SW", [Effects.GenerateEffect(BasicEffects.Empty, 2), Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 3, Slots.Self), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Self)]);
            boot.Name = "Muddy Boot";
            boot.Flavour = "\"Splish Splash\"";
            boot.Description = "At the end of each turn, heal 2-3 health and gain 2 Slip.";
            boot.Icon = ResourceLoader.LoadSprite("item_muddyboot.png");
            boot.TriggerOn = TriggerCalls.OnTurnFinished;
            boot.EquippedModifiers = [];
            boot.DoesPopUpInfo = true;
            boot.Conditions = [];
            boot.DoesActionOnTriggerAttached = false;
            boot.ConsumeOnTrigger = TriggerCalls.Count;
            boot.ConsumeOnUse = false;
            boot.ConsumeConditions = [];
            boot.ShopPrice = 4;
            boot.IsShopItem = true;
            boot.StartsLocked = true;
            boot.OnUnlockUsesTHE = true;
            boot.UsesSpecialUnlockText = false;
            boot.SpecialUnlockID = UILocID.None;
            boot.item._ItemTypeIDs = ["Fabric"];
            boot.item.AddBlueSkyUnlock("Kraus_CH", "locked_muddyboot.png", "ach_muddyboot.png");
        }
    }
}
