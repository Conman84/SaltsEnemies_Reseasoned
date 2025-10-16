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
            rubber.item.AddBlueSkyUnlock("Dimitri_CH", "locked_rubberknife.png", "ach_rubberknife.png");

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

            MultiPerformEffectItem sound = new MultiPerformEffectItem("Salt_SoundGun_SW", []);
            sound.Name = "Sound Gun";
            sound.Flavour = "\"Noisy.\"";
            sound.Description = "Damage dealt spreads indirectly left and right.\nApply Focused to directly damaged targets.";
            sound.Icon = ResourceLoader.LoadSprite("item_soundgun.png");
            sound.TriggerOn = CascadingDamageItemHandler.Call;
            sound.EquippedModifiers = [];
            sound.DoesPopUpInfo = false;
            sound.Conditions = [BooleanSetterCondition.Create(true, true, false)];
            sound.DoesActionOnTriggerAttached = false;
            sound.ConsumeOnTrigger = TriggerCalls.Count;
            sound.ConsumeOnUse = false;
            sound.ConsumeConditions = [];
            sound.ShopPrice = 6;
            sound.IsShopItem = true;
            sound.StartsLocked = true;
            sound.OnUnlockUsesTHE = true;
            sound.UsesSpecialUnlockText = false;
            sound.SpecialUnlockID = UILocID.None;
            sound.item._ItemTypeIDs = [];
            sound.AddEffectTrigger(new EffectTrigger([], [AdvancedDamageTrigger.Dealt], [DamageTargetEffectsCondition.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Slots.Self)], true)], false));
            sound.item.AddBlueSkyUnlock("Joy_CH", "locked_soundgun.png", "ach_soundgun.png");

            MultiPerformEffectItem challenger = new MultiPerformEffectItem("Salt_Challenger_SW", []);
            challenger.Name = "Challenger";
            challenger.Flavour = "\"1986\"";
            challenger.Description = "Deal 60% more healing.\nGain 2 Slip on manually moving.";
            challenger.Icon = ResourceLoader.LoadSprite("item_challenger.png");
            challenger.TriggerOn = TriggerCalls.OnWillApplyHeal;
            challenger.EquippedModifiers = [];
            challenger.DoesPopUpInfo = false;
            challenger.Conditions = [ItemExtensions.Heal(60, true)];
            challenger.DoesActionOnTriggerAttached = false;
            challenger.ConsumeOnTrigger = TriggerCalls.Count;
            challenger.ConsumeOnUse = false;
            challenger.ConsumeConditions = [];
            challenger.ShopPrice = 6;
            challenger.IsShopItem = true;
            challenger.StartsLocked = true;
            challenger.OnUnlockUsesTHE = true;
            challenger.UsesSpecialUnlockText = false;
            challenger.SpecialUnlockID = UILocID.None;
            challenger.item._ItemTypeIDs = [];
            challenger.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Self)], [TriggerCalls.OnSwapTo], []));
            challenger.item.AddBlueSkyUnlock("Hangman_CH", "locked_challenger.png", "ach_challenger.png");

            PerformEffect_Item rations = new PerformEffect_Item("Salt_RadioactiveRations_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 1, Slots.Self)]);
            rations.Name = "Radioactive Rations";
            rations.Flavour = "\"Not safe for, I mean, maybe safe for consumption.\"";
            rations.Description = "Heal 1 health on any ability being used.\nConsume this item at the end of combat if at full health.";
            rations.Icon = ResourceLoader.LoadSprite("item_radioactiverations.png");
            rations.TriggerOn = TriggerCalls.OnAnyAbilityUsed;
            rations.EquippedModifiers = [];
            rations.DoesPopUpInfo = true;
            rations.Conditions = [];
            rations.DoesActionOnTriggerAttached = false;
            rations.ConsumeOnTrigger = TriggerCalls.OnCombatEnd;
            rations.ConsumeOnUse = false;
            rations.ConsumeConditions = [ScriptableObject.CreateInstance<FullHealthEffectorCondition>()];
            rations.ShopPrice = 8;
            rations.IsShopItem = true;
            rations.StartsLocked = true;
            rations.OnUnlockUsesTHE = true;
            rations.UsesSpecialUnlockText = false;
            rations.SpecialUnlockID = UILocID.None;
            rations.item._ItemTypeIDs = [];
            rations.item.AddBlueSkyUnlock("Cranes_CH", "locked_radioactiverations.png", "ach_radioactiverations.png");

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

            PerformEffect_Item kaleidoscope = new PerformEffect_Item("Salt_Kaleidoscope_TW", []);
            kaleidoscope.Name = "Kaleidoscope";
            kaleidoscope.Flavour = "\"Transmutate the world\"";
            kaleidoscope.Description = "Damage dealt to non-Red enemies spreads indirectly left and right.";
            kaleidoscope.Icon = ResourceLoader.LoadSprite("item_kaleidoscope.png");
            kaleidoscope.TriggerOn = CascadingDamageItemHandler.Call;
            kaleidoscope.EquippedModifiers = [];
            kaleidoscope.DoesPopUpInfo = false;
            kaleidoscope.Conditions = [ScriptableObject.CreateInstance<KaleidoscopeCondition>()];
            kaleidoscope.DoesActionOnTriggerAttached = false;
            kaleidoscope.ConsumeOnTrigger = TriggerCalls.Count;
            kaleidoscope.ConsumeOnUse = false;
            kaleidoscope.ConsumeConditions = [];
            kaleidoscope.ShopPrice = 5;
            kaleidoscope.IsShopItem = false;
            kaleidoscope.StartsLocked = true;
            kaleidoscope.OnUnlockUsesTHE = true;
            kaleidoscope.UsesSpecialUnlockText = false;
            kaleidoscope.SpecialUnlockID = UILocID.None;
            kaleidoscope.item._ItemTypeIDs = [];
            kaleidoscope.item.AddBlueSkyUnlock("Jebrick_CH", "locked_kaleidoscope.png", "ach_kaleidoscope.png");

        }
    }
}
