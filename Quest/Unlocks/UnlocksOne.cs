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
                PassiveType_GameIDs.Skittish.ToString(), PassiveType_GameIDs.Slippery.ToString(), PassiveType_GameIDs.Constricting.ToString(),
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

            MultiPerformEffectItem nail = new MultiPerformEffectItem("Salt_LeftNail_TW", []);
            nail.Name = "Nail of the Left Eye";
            nail.Flavour = "\"It hates you so much\"";
            nail.Description = "Deal 30% more damage. \nOn taking damage, attempt to give the attacker another action and 30% chance to destroy this item.";
            nail.Icon = ResourceLoader.LoadSprite("item_leftnail.png");
            nail.EquippedModifiers = [];
            nail.TriggerOn = AdvancedDamageTrigger.Received;
            nail.DoesPopUpInfo = true;
            nail.Conditions = [DamageTargetEffectsCondition.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterGainActionEffect>(), 1, Slots.Self)], false)];
            nail.DoesActionOnTriggerAttached = false;
            nail.ConsumeOnTrigger = TriggerCalls.Count;
            nail.ConsumeOnUse = true;
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
            play.ShopPrice = 5;
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
        }
    }
}
