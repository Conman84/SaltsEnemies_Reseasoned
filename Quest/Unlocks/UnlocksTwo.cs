using BrutalAPI;
using BrutalAPI.Items;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksTwo
    {
        public static void Add()
        {
            MultiPerformEffectItem friend = new MultiPerformEffectItem("Salt_FriendshipBriefcase_SW", []);
            friend.Name = "Friendship Briefcase";
            friend.Flavour = "\"Friends everywhere you look!\"";
            friend.Description = "Deal 2 additional damage and healing.\n20% chance to be destroyed on dealing damage.";
            friend.Icon = ResourceLoader.LoadSprite("item_friendshipbriefcase.png");
            friend.EquippedModifiers = [];
            friend.TriggerOn = TriggerCalls.OnWillApplyHeal;
            friend.DoesPopUpInfo = false;
            friend.Conditions = [ItemExtensions.Heal(2, true, false)];
            friend.DoesActionOnTriggerAttached = false;
            friend.ConsumeOnTrigger = TriggerCalls.OnDidApplyDamage;
            friend.ConsumeOnUse = false;
            friend.ConsumeConditions = [ItemExtensions.Chance(20)];
            friend.ShopPrice = 5;
            friend.IsShopItem = true;
            friend.StartsLocked = true;
            friend.OnUnlockUsesTHE = true;
            friend.UsesSpecialUnlockText = false;
            friend.SpecialUnlockID = UILocID.None;
            friend.item._ItemTypeIDs = [];
            friend.AddEffectTrigger(new EffectTrigger([], [TriggerCalls.OnWillApplyDamage], [ItemExtensions.Damage(2, true, false)], false));
            friend.item.AddBlueSkyUnlock("LongLiver_CH", "locked_friendshipbriefcase.png", "ach_friendshipbriefcase.png");

            PerformEffect_Item war = new PerformEffect_Item("Salt_AbstractWar_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 1, Slots.Self)]);
            war.Name = "Abstract War";
            war.Flavour = "\"Depictions of Violence\"";
            war.Description = "On any party member receiving direct damage, gain 1 Determined.";
            war.Icon = ResourceLoader.LoadSprite("item_abstractwar.png");
            war.EquippedModifiers = [];
            war.TriggerOn = AllyTriggersHandler.AllyDirectDamaged;
            war.DoesPopUpInfo = true;
            war.Conditions = [];
            war.DoesActionOnTriggerAttached = false;
            war.ConsumeOnTrigger = TriggerCalls.Count;
            war.ConsumeOnUse = false;
            war.ConsumeConditions = [];
            war.ShopPrice = 6;
            war.IsShopItem = true;
            war.StartsLocked = true;
            war.OnUnlockUsesTHE = true;
            war.UsesSpecialUnlockText = false;
            war.SpecialUnlockID = UILocID.None;
            war.item._ItemTypeIDs = [];
            war.item.AddBlueSkyUnlock("Anton_CH", "locked_abstractwar.png", "ach_abstractwar.png");

            PerformEffect_Item photo = new PerformEffect_Item("Salt_RedPhoto_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, Slots.Self)]);
            photo.Name = "Red Photo";
            photo.Flavour = "\"Abstract Violence\"";
            photo.Description = "On any party member receiving direct damage, gain 1 Power.";
            photo.Icon = ResourceLoader.LoadSprite("item_redphoto.png");
            photo.EquippedModifiers = [];
            photo.TriggerOn = AllyTriggersHandler.AllyDirectDamaged;
            photo.DoesPopUpInfo = true;
            photo.Conditions = [];
            photo.DoesActionOnTriggerAttached = false;
            photo.ConsumeOnTrigger = TriggerCalls.Count;
            photo.ConsumeOnUse = false;
            photo.ConsumeConditions = [];
            photo.ShopPrice = 6;
            photo.IsShopItem = true;
            photo.StartsLocked = true;
            photo.OnUnlockUsesTHE = true;
            photo.UsesSpecialUnlockText = false;
            photo.SpecialUnlockID = UILocID.None;
            photo.item._ItemTypeIDs = [];
            photo.item.AddBlueSkyUnlock("Thype_CH", "locked_redphoto.png", "ach_redphoto.png");

            ApplyFoundStatusEffect wildcard = ScriptableObject.CreateInstance<ApplyFoundStatusEffect>();
            wildcard.useStatus = "WildCard_ID";

            MultiPerformEffectItem entropy = new MultiPerformEffectItem("Salt_EntropicAnalysis_TW", [Effects.GenerateEffect(wildcard, 2, Slots.Self)]);
            entropy.Name = "Entropic Analysis";
            entropy.Flavour = "\"Are you truly ready to pay the debt this machine has incurred?\"";
            entropy.Description = "At the start of each turn, gain 2 Wild Card.\nAt the end of each turn, give the Opposing enemy 2 Wild Card.";
            entropy.Icon = ResourceLoader.LoadSprite("item_entropicanalysis.png");
            entropy.EquippedModifiers = [];
            entropy.TriggerOn = TriggerCalls.OnTurnStart;
            entropy.DoesPopUpInfo = true;
            entropy.Conditions = [];
            entropy.DoesActionOnTriggerAttached = false;
            entropy.ConsumeOnTrigger = TriggerCalls.Count;
            entropy.ConsumeOnUse = false;
            entropy.ConsumeConditions = [];
            entropy.ShopPrice = 4;
            entropy.IsShopItem = false;
            entropy.StartsLocked = true;
            entropy.OnUnlockUsesTHE = true;
            entropy.UsesSpecialUnlockText = false;
            entropy.SpecialUnlockID = UILocID.None;
            entropy.item._ItemTypeIDs = [];
            entropy.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(wildcard, 2, Slots.Front)], [TriggerCalls.OnTurnFinished], []));
            entropy.item.AddBlueSkyUnlock("Andy_CH", "locked_entropicanalysis.png", "ach_entropicanalysis.png");

            PerformEffect_Item death = new PerformEffect_Item("Salt_DeathCertificate_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<FullHealEffect>(), 1, Slots.Self), Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Slots.Self)]);
            death.Name = "Death Certificate";
            death.Flavour = "\"Who's in that grave!?\"";
            death.Description = "On taking any damage, fully heal this party member and instantly flee.";
            death.Icon = ResourceLoader.LoadSprite("item_deathcertificate.png");
            death.EquippedModifiers = [];
            death.TriggerOn = TriggerCalls.OnDamaged;
            death.DoesPopUpInfo = true;
            death.Conditions = [];
            death.DoesActionOnTriggerAttached = false;
            death.ConsumeOnTrigger = TriggerCalls.Count;
            death.ConsumeOnUse = false;
            death.ConsumeConditions = [];
            death.ShopPrice = 4;
            death.IsShopItem = true;
            death.StartsLocked = true;
            death.OnUnlockUsesTHE = true;
            death.UsesSpecialUnlockText = false;
            death.SpecialUnlockID = UILocID.None;
            death.item._ItemTypeIDs = [];
            death.item.AddBlueSkyUnlock("SmokeStacks_CH", "locked_deathcertificate.png", "ach_deathcertificate.png");
        }
    }
}
