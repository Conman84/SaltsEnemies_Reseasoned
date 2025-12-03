using BrutalAPI;
using BrutalAPI.Items;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoneds;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksSix
    {
        public static void Add()
        {
            PerformEffect_Item hammer = new PerformEffect_Item("Salt_KindnessHammer_SW", []);
            hammer.Name = "Kindness Hammer";
            hammer.Flavour = "\"So generous...\"";
            hammer.Description = "Deal 25% more damage.\nHeal targets 4 health before damaging them.";
            hammer.Icon = ResourceLoader.LoadSprite("item_kindnesshammer.png");
            hammer.TriggerOn = TriggerCalls.OnWillApplyDamage;
            hammer.EquippedModifiers = [];
            hammer.DoesPopUpInfo = false;
            hammer.Conditions = [ScriptableObject.CreateInstance<KindnessHammerCondition>()];
            hammer.DoesActionOnTriggerAttached = false;
            hammer.ConsumeOnTrigger = TriggerCalls.Count;
            hammer.ConsumeOnUse = false;
            hammer.ConsumeConditions = [];
            hammer.ShopPrice = 4;
            hammer.IsShopItem = false;
            hammer.StartsLocked = true;
            hammer.OnUnlockUsesTHE = true;
            hammer.UsesSpecialUnlockText = false;
            hammer.SpecialUnlockID = UILocID.None;
            hammer.item._ItemTypeIDs = [];
            hammer.item.AddBlueSkyUnlock("Ham_CH", "locked_kindnesshammer.png", "ach_kindnesshammer.png");

            PerformEffect_Item pylon = new PerformEffect_Item("Salt_Pylon_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, Slots.Self), Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 10, Slots.Self)]);
            pylon.Name = "Pylon";
            pylon.Flavour = "\"Plastic Power\"";
            pylon.Description = "At the start of each turn, gain Focused and 10 Slip.";
            pylon.Icon = ResourceLoader.LoadSprite("item_pylon.png");
            pylon.TriggerOn = TriggerCalls.OnTurnStart;
            pylon.EquippedModifiers = [];
            pylon.DoesPopUpInfo = true;
            pylon.Conditions = [];
            pylon.DoesActionOnTriggerAttached = false;
            pylon.ConsumeOnTrigger = TriggerCalls.Count;
            pylon.ConsumeOnUse = false;
            pylon.ConsumeConditions = [];
            pylon.ShopPrice = 3;
            pylon.IsShopItem = true;
            pylon.StartsLocked = true;
            pylon.OnUnlockUsesTHE = true;
            pylon.UsesSpecialUnlockText = false;
            pylon.SpecialUnlockID = UILocID.None;
            pylon.item._ItemTypeIDs = [];
            pylon.item.AddBlueSkyUnlock("Knotty_CH", "locked_pylon.png", "ach_pylon.png");

            RemoveStatusEffectEffect rem_curse = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            rem_curse._status = StatusField.Cursed;

            MultiPerformEffectItem staff = new MultiPerformEffectItem("Salt_PharaohScepter_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, Slots.Self)]);
            staff.Name = "Pharaoh's Scepter";
            staff.Flavour = "\"The Pharaoh's Curse!!!\"";
            staff.Description = "On being directly damaged, become Cursed.\nOn using an ability while Cursed, remove Cursed and refresh this party member's ability usage.";
            staff.Icon = ResourceLoader.LoadSprite("item_pharaohscepter.png");
            staff.TriggerOn = TriggerCalls.OnDirectDamaged;
            staff.EquippedModifiers = [];
            staff.DoesPopUpInfo = true;
            staff.Conditions = [];
            staff.DoesActionOnTriggerAttached = false;
            staff.ConsumeOnTrigger = TriggerCalls.Count;
            staff.ConsumeOnUse = false;
            staff.ConsumeConditions = [];
            staff.ShopPrice = 7;
            staff.IsShopItem = false;
            staff.StartsLocked = true;
            staff.OnUnlockUsesTHE = true;
            staff.UsesSpecialUnlockText = false;
            staff.SpecialUnlockID = UILocID.None;
            staff.item._ItemTypeIDs = ["Magic"];
            staff.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(rem_curse, 1, Slots.Self), Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>())], [TriggerCalls.OnAbilityUsed], [ScriptableObject.CreateInstance<IsCursedEffectorCondition>()]));
            staff.item.AddBlueSkyUnlock("Serpent_CH", "locked_pharaohscepter.png", "ach_pharaohscepter.png");

            PerformEffect_Item scalpel = new PerformEffect_Item("Salt_Scalpel_SW", []);
            scalpel.Name = "Scalpel";
            scalpel.Flavour = "\"Be careful with that!\"";
            scalpel.Description = "Reduce negative status effects on healed targets by 2.";
            scalpel.Icon = ResourceLoader.LoadSprite("item_scalpel.png");
            scalpel.TriggerOn = TriggerCalls.OnWillApplyHeal;
            scalpel.EquippedModifiers = [];
            scalpel.DoesPopUpInfo = false;
            scalpel.Conditions = [ScriptableObject.CreateInstance<ReduceNegStatusOnHealTargetsEffectorCondition>()];
            scalpel.DoesActionOnTriggerAttached = false;
            scalpel.ConsumeOnTrigger = TriggerCalls.Count;
            scalpel.ConsumeOnUse = false;
            scalpel.ConsumeConditions = [];
            scalpel.ShopPrice = 7;
            scalpel.IsShopItem = true;
            scalpel.StartsLocked = true;
            scalpel.OnUnlockUsesTHE = true;
            scalpel.UsesSpecialUnlockText = false;
            scalpel.SpecialUnlockID = UILocID.None;
            scalpel.item._ItemTypeIDs = ["Knife"];
            scalpel.item.AddBlueSkyUnlock("WormWoomb_CH", "locked_scalpel.png", "ach_scalpel.png");








        }
    }
}
