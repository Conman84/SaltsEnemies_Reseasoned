using BrutalAPI;
using BrutalAPI.Items;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksOne
    {
        public static void Add()
        {
            PassiveLockingEffect cogEffect = ScriptableObject.CreateInstance<PassiveLockingEffect>();
            cogEffect.m_PassiveIDs = [
                PassiveType_GameIDs.Skittish.ToString(), PassiveType_GameIDs.Slippery.ToString(), PassiveType_GameIDs.Constricting.ToString(), PassiveType_GameIDs.Anchored.ToString(),
                "Jumpy_PA", "Lightweight_PA", "Scramble_PA", "Evasive_PA", "Turbulent_PA", "CCTV_PA", "Jittery_PA", "Fluttery_PA", WarpingHandler.Type,
                "Lonely_PA", "Melancholy_PA", "Gluttony_PA", "Rotary_PA", MarchingHandler.Passive, "Hiding_PA", "Seeking_PA"
                ];

            PerformEffect_Item cog = new PerformEffect_Item("Salt_Cog_SW", [Effects.GenerateEffect(cogEffect)]);
            cog.Name = "The Cog";
            cog.Flavour = "\"it's a metaphor.\"";
            cog.Description = "Disable most movement passives.";
            cog.Icon = ResourceLoader.LoadSprite("item_cog.png");
            cog.EquippedModifiers = [];
            cog.TriggerOn = TriggerCalls.OnBeforeCombatStart;
            cog.DoesPopUpInfo = false;
            cog.Conditions = [];
            cog.DoesActionOnTriggerAttached = false;
            cog.ConsumeOnTrigger = TriggerCalls.Count;
            cog.ConsumeOnUse = false;
            cog.ConsumeConditions = [];
            cog.ShopPrice = 4;
            cog.IsShopItem = true;
            cog.StartsLocked = true;
            cog.OnUnlockUsesTHE = false;
            cog.UsesSpecialUnlockText = false;
            cog.SpecialUnlockID = UILocID.None;
            cog.item._ItemTypeIDs = [];
            cog.item.AddBlueSkyUnlock("Gospel_CH", "locked_cog.png", "ach_cog.png");

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

            MultiPerformEffectItem nail = new MultiPerformEffectItem("Salt_LeftNail_TW", [Effects.GenerateEffect(Hauntling.Spawn, 1, Slots.Self)]);
            nail.Name = "Nail of the Left Eye";
            nail.Flavour = "\"It hates you so much\"";
            nail.Description = "Deal 30% more damage. \nOn taking direct damage, spawn something else.";
            nail.Icon = ResourceLoader.LoadSprite("item_leftnail.png");
            nail.EquippedModifiers = [];
            nail.TriggerOn = TriggerCalls.OnDirectDamaged;
            nail.DoesPopUpInfo = true;
            nail.Conditions = [];
            nail.DoesActionOnTriggerAttached = false;
            nail.ConsumeOnTrigger = TriggerCalls.Count;
            nail.ConsumeOnUse = false;
            nail.ConsumeConditions = [ItemExtensions.Chance(30)];
            nail.ShopPrice = 4;
            nail.IsShopItem = false;
            nail.StartsLocked = true;
            nail.OnUnlockUsesTHE = true;
            nail.UsesSpecialUnlockText = false;
            nail.SpecialUnlockID = UILocID.None;
            nail.item._ItemTypeIDs = ["Knife"];
            EffectTrigger nail_second = new EffectTrigger([], [TriggerCalls.OnWillApplyDamage], [ItemExtensions.Damage(30, true)], false);
            nail.AddEffectTrigger(nail_second);
            nail.item.AddBlueSkyUnlock("Fennec_CH", "locked_leftnail.png", "ach_leftnail.png");

            PerformEffect_Item play = new PerformEffect_Item("Salt_ThePlay_SW", [], true);
            play.Name = "The Play";
            play.Flavour = "\"Your role isn't done yet.\"";
            play.Description = "On death, prevent it and heal 1 health.\nThis item is destroyed upon taking any damage.";
            play.Icon = ResourceLoader.LoadSprite("item_theplay.png");
            play.EquippedModifiers = [];
            play.TriggerOn = TriggerCalls.CanDie;
            play.DoesPopUpInfo = true;
            play.Conditions = [ScriptableObject.CreateInstance<TinCanCondition>()];
            play.DoesActionOnTriggerAttached = false;
            play.ConsumeOnTrigger = TriggerCalls.OnDamaged;
            play.ConsumeOnUse = false;
            play.ConsumeConditions = [];
            play.ShopPrice = 4;
            play.IsShopItem = true;
            play.StartsLocked = true;
            play.OnUnlockUsesTHE = false;
            play.UsesSpecialUnlockText = false;
            play.SpecialUnlockID = UILocID.None;
            play.item._ItemTypeIDs = [];
            play.item.AddBlueSkyUnlock("Agon_CH", "locked_theplay.png", "ach_theplay.png");

            PerformEffect_Item match = new PerformEffect_Item("Salt_LittleMatchbox_SW", [], true);
            match.Name = "Little Matchbox";
            match.Flavour = "\"Warm forever.\"";
            match.Description = "Fire no longer decreases on this party member's position.\nThis party member receives -100% Fire damage.";
            match.Icon = ResourceLoader.LoadSprite("item_littlematchbox.png");
            match.EquippedModifiers = [];
            match.TriggerOn = TriggerCalls.OnBeingDamaged;
            match.DoesPopUpInfo = true;
            match.Conditions = [ScriptableObject.CreateInstance<ColdHealCondition>()];
            match.DoesActionOnTriggerAttached = false;
            match.ConsumeOnTrigger = TriggerCalls.Count;
            match.ConsumeOnUse = false;
            match.ConsumeConditions = [];
            match.ShopPrice = 8;
            match.IsShopItem = true;
            match.StartsLocked = true;
            match.OnUnlockUsesTHE = true;
            match.UsesSpecialUnlockText = false;
            match.SpecialUnlockID = UILocID.None;
            match.item._ItemTypeIDs = [];
            match.item.AddBlueSkyUnlock("Kleiver_CH", "locked_littlematchbox.png", "ach_littlematchbox.png");

            PerformEffect_Item inkwell = new PerformEffect_Item("Salt_Inkwell_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.Front)]);
            inkwell.Name = "Ink Well";
            inkwell.Flavour = "\"Gets messy fast\"";
            inkwell.Description = "On using an ability, apply 2 Slip to the Opposing position.";
            inkwell.Icon = ResourceLoader.LoadSprite("item_inkwell.png");
            inkwell.EquippedModifiers = [];
            inkwell.TriggerOn = TriggerCalls.OnAbilityUsed;
            inkwell.DoesPopUpInfo = true;
            inkwell.Conditions = [];
            inkwell.DoesActionOnTriggerAttached = false;
            inkwell.ConsumeOnTrigger = TriggerCalls.Count;
            inkwell.ConsumeOnUse = false;
            inkwell.ConsumeConditions = [];
            inkwell.ShopPrice = 2;
            inkwell.IsShopItem = true;
            inkwell.StartsLocked = true;
            inkwell.OnUnlockUsesTHE = true;
            inkwell.UsesSpecialUnlockText = false;
            inkwell.SpecialUnlockID = UILocID.None;
            inkwell.item._ItemTypeIDs = [];
            inkwell.item.AddBlueSkyUnlock("Hans_CH", "locked_inkwell.png", "ach_inkwell.png");

            PostFireEffect.Setup();
            Ability postfire = new Ability("Post-Fire", "PostFire_A");
            postfire.Description = "Deal 6-9 damage to the last enemy this party member dealt damage to.";
            postfire.Cost = [Pigments.Red, Pigments.Red];
            postfire.Rarity = Rarity.GetCustomRarity("rarity5");
            postfire.AbilitySprite = ResourceLoader.LoadSprite("ability_postfire.png");
            postfire.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<PostFireEffect>(), 6, Targeting.Unit_AllOpponents)];
            postfire.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Misc_Hidden", "Damage_7_10"]);
            postfire.Visuals = null;
            postfire.AnimationTarget = Slots.Self;

            ExtraAbility_Wearable_SMS add_postfire = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            add_postfire._extraAbility = postfire.GenerateCharacterAbility(true);

            Basic_Item receiver = new Basic_Item("Salt_Receiver_SW");
            receiver.Name = "Receiver";
            receiver.Flavour = "\"Voice from beyond\"";
            receiver.Description = "Adds the extra ability \"Post-Fire,\", a cheap long range damage ability.";
            receiver.Icon = ResourceLoader.LoadSprite("item_receiver.png");
            receiver.EquippedModifiers = [add_postfire];
            receiver.TriggerOn = TriggerCalls.Count;
            receiver.DoesPopUpInfo = false;
            receiver.Conditions = [];
            receiver.DoesActionOnTriggerAttached = false;
            receiver.ConsumeOnTrigger = TriggerCalls.Count;
            receiver.ConsumeOnUse = false;
            receiver.ConsumeConditions = [];
            receiver.ShopPrice = 5;
            receiver.IsShopItem = true;
            receiver.StartsLocked = true;
            receiver.OnUnlockUsesTHE = true;
            receiver.UsesSpecialUnlockText = false;
            receiver.SpecialUnlockID = UILocID.None;
            receiver.item._ItemTypeIDs = [];
            receiver.item.AddBlueSkyUnlock("Rags_CH", "locked_receiver.png", "ach_receiver.png");

            PerformEffect_Item scope = new PerformEffect_Item("Salt_HexedScope_TW", []);
            scope.Name = "Hexed Scope";
            scope.Flavour = "\"Sin of Sloth\"";
            scope.Description = "Deal 15% less damage.\nDeal 50% more damage instead if this is the first ability used this turn.";
            scope.Icon = ResourceLoader.LoadSprite("item_hexedscope.png");
            scope.EquippedModifiers = [];
            scope.TriggerOn = TriggerCalls.OnWillApplyDamage;
            scope.DoesPopUpInfo = false;
            scope.Conditions = [ScriptableObject.CreateInstance<HexedScopeCondition>()];
            scope.DoesActionOnTriggerAttached = false;
            scope.ConsumeOnTrigger = TriggerCalls.Count;
            scope.ConsumeOnUse = false;
            scope.ConsumeConditions = [];
            scope.ShopPrice = 5;
            scope.IsShopItem = false;
            scope.StartsLocked = true;
            scope.OnUnlockUsesTHE = true;
            scope.UsesSpecialUnlockText = false;
            scope.SpecialUnlockID = UILocID.None;
            scope.item._ItemTypeIDs = [];
            scope.item.AddBlueSkyUnlock("Hare_CH", "locked_hexedscope.png", "ach_hexedscope.png");

            PerformEffect_Item plug = new PerformEffect_Item("Salt_ThePlug_SW", []);
            plug.Name = "The Plug";
            plug.Flavour = "\"Hole In The Wall\"";
            plug.Description = "Damaged targets gain 10 Pale.";
            plug.Icon = ResourceLoader.LoadSprite("item_theplug.png");
            plug.EquippedModifiers = [];
            plug.TriggerOn = AdvancedDamageTrigger.Dealt;
            plug.DoesPopUpInfo = false;
            plug.Conditions = [DamageTargetEffectsCondition.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 1, Slots.Self)], true)];
            plug.DoesActionOnTriggerAttached = false;
            plug.ConsumeOnTrigger = TriggerCalls.Count;
            plug.ConsumeOnUse = false;
            plug.ConsumeConditions = [];
            plug.ShopPrice = 5;
            plug.IsShopItem = true;
            plug.StartsLocked = true;
            plug.OnUnlockUsesTHE = false;
            plug.UsesSpecialUnlockText = false;
            plug.SpecialUnlockID = UILocID.None;
            plug.item._ItemTypeIDs = [];
            plug.item.AddBlueSkyUnlock("Saturn_CH", "locked_theplug.png", "ach_theplug.png");

            PerformEffect_Item time = new PerformEffect_Item("Salt_MarchOfTime_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageByTurnsEffect>(), 1, Slots.Front)]);
            time.Name = "March of Time";
            time.Flavour = "\"Two by Two\"";
            time.Description = "At the end of each turn, deal damage to the Opposing enemy equal to the amount of turns passed.";
            time.Icon = ResourceLoader.LoadSprite("item_marchoftime.png");
            time.EquippedModifiers = [];
            time.TriggerOn = TriggerCalls.OnTurnFinished;
            time.DoesPopUpInfo = true;
            time.Conditions = [];
            time.DoesActionOnTriggerAttached = false;
            time.ConsumeOnTrigger = TriggerCalls.Count;
            time.ConsumeOnUse = false;
            time.ConsumeConditions = [];
            time.ShopPrice = 3;
            time.IsShopItem = false;
            time.StartsLocked = true;
            time.OnUnlockUsesTHE = true;
            time.UsesSpecialUnlockText = false;
            time.SpecialUnlockID = UILocID.None;
            time.item._ItemTypeIDs = [];
            time.item.AddBlueSkyUnlock("Esther_CH", "locked_marchoftime.png", "ach_marchoftime.png");
        }
    }
}
