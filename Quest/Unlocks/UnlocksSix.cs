using BrutalAPI;
using BrutalAPI.Items;
using SaltEnemies_Reseasoned;
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
            CopyAndSpawnCustomCharacterAnywhereEffect spawn_six = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            spawn_six._characterCopy = "Six_CH";
            spawn_six._permanentSpawn = true;

            PerformEffect_Item six = new PerformEffect_Item("Salt_Six_EW", [Effects.GenerateEffect(spawn_six, 1, Slots.Self)]);
            six.Name = "Six";
            six.Flavour = "\"Hi I'm Six!\"";
            six.Description = "On combat start, destroy this item and spawn Six.";
            six.Icon = ResourceLoader.LoadSprite("item_six.png");
            six.TriggerOn = TriggerCalls.OnCombatStart;
            six.EquippedModifiers = [];
            six.DoesPopUpInfo = true;
            six.Conditions = [];
            six.DoesActionOnTriggerAttached = false;
            six.ConsumeOnTrigger = TriggerCalls.Count;
            six.ConsumeOnUse = true;
            six.ConsumeConditions = [];
            six.ShopPrice = 7;
            six.IsShopItem = false;
            six.StartsLocked = true;
            six.OnUnlockUsesTHE = true;
            six.UsesSpecialUnlockText = false;
            six.SpecialUnlockID = UILocID.None;
            six.item._ItemTypeIDs = [];
            six.item.AddBlueSkyUnlock("Six_CH", "locked_six.png", "ach_six.png", 1);

            MultiPerformEffectItem manual = new MultiPerformEffectItem("Salt_DissectionManual_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<GainPlayerCurrencyEffect>(), 5, Slots.Self)]);
            manual.Name = "Dissection Manual";
            manual.Flavour = "\"Follow precise instructions.\"";
            manual.Description = "On getting a kill, gain 5 coins.\nOn using an ability, lose 3 coins.";
            manual.Icon = ResourceLoader.LoadSprite("item_dissectionmanual.png");
            manual.TriggerOn = TriggerCalls.OnKill;
            manual.EquippedModifiers = [];
            manual.DoesPopUpInfo = true;
            manual.Conditions = [];
            manual.DoesActionOnTriggerAttached = false;
            manual.ConsumeOnTrigger = TriggerCalls.Count;
            manual.ConsumeOnUse = false;
            manual.ConsumeConditions = [];
            manual.ShopPrice = 5;
            manual.IsShopItem = true;
            manual.StartsLocked = true;
            manual.OnUnlockUsesTHE = true;
            manual.UsesSpecialUnlockText = false;
            manual.SpecialUnlockID = UILocID.None;
            manual.item._ItemTypeIDs = [];
            manual.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 3, Slots.Self)], [TriggerCalls.OnAbilityWillBeUsed], []));
            manual.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(ScriptableObject.CreateInstance<ShowPlayerCurrencyEffect>(), 1, Slots.Self)], [TriggerCalls.OnCombatStart], [], false));
            manual.item.AddBlueSkyUnlock("Leviat_CH", "locked_dissectionmanual.png", "ach_dissectionmanual.png");

            ApplyFoundFieldEffect spikes = ScriptableObject.CreateInstance<ApplyFoundFieldEffect>();
            spikes.useField = "Spikes_ID";

            PerformEffect_Item dmz = new PerformEffect_Item("Salt_DMZ_TW", [Effects.GenerateEffect(spikes, 1, Slots.Self), Effects.GenerateEffect(spikes, 4, Slots.Front)]);
            dmz.Name = "Demilitarized Zone";
            dmz.Flavour = "\"The whole thing.\"";
            dmz.Description = "On manually moving, gain 1 Spikes and inflict 4 Spikes on the Opposing position.";
            dmz.Icon = ResourceLoader.LoadSprite("item_dmz.png");
            dmz.TriggerOn = TriggerCalls.OnSwapTo;
            dmz.EquippedModifiers = [];
            dmz.DoesPopUpInfo = true;
            dmz.Conditions = [];
            dmz.DoesActionOnTriggerAttached = false;
            dmz.ConsumeOnTrigger = TriggerCalls.Count;
            dmz.ConsumeOnUse = false;
            dmz.ConsumeConditions = [];
            dmz.ShopPrice = 3;
            dmz.IsShopItem = false;
            dmz.StartsLocked = true;
            dmz.OnUnlockUsesTHE = true;
            dmz.UsesSpecialUnlockText = false;
            dmz.SpecialUnlockID = UILocID.None;
            dmz.item._ItemTypeIDs = [];
            dmz.item.AddBlueSkyUnlock("Bingo_CH", "locked_dmz.png", "ach_dmz.png");

            PerformEffect_Item blood = new PerformEffect_Item("Salt_BloodSword_SW", []);
            blood.Name = "Blood Sword";
            blood.Flavour = "\"Hurts a lot to use.\"";
            blood.Description = "Deal 25% more damage while at full health.\nThis item is destroyed on death.";
            blood.Icon = ResourceLoader.LoadSprite("item_bloodsword.png");
            blood.TriggerOn = TriggerCalls.OnWillApplyDamage;
            blood.EquippedModifiers = [];
            blood.DoesPopUpInfo = false;
            blood.Conditions = [ScriptableObject.CreateInstance<FullHealthEffectorCondition>(), ItemExtensions.Damage(25, true)];
            blood.DoesActionOnTriggerAttached = false;
            blood.ConsumeOnTrigger = TriggerCalls.OnDeath;
            blood.ConsumeOnUse = false;
            blood.ConsumeConditions = [];
            blood.ShopPrice = 4;
            blood.IsShopItem = true;
            blood.StartsLocked = true;
            blood.OnUnlockUsesTHE = true;
            blood.UsesSpecialUnlockText = false;
            blood.SpecialUnlockID = UILocID.None;
            blood.item._ItemTypeIDs = ["Knife", "Meat"];
            blood.item.AddBlueSkyUnlock("Otto_CH", "locked_bloodsword.png", "ach_bloodsword.png");

            PerformEffect_Item ring = new PerformEffect_Item("Salt_TheRing_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 1, Slots.Front)]);
            ring.Name = "The Ring";
            ring.Flavour = "\"For whom?\"";
            ring.Description = "On moving, inflict 10 Pale on the Opposing enemy.";
            ring.Icon = ResourceLoader.LoadSprite("item_ring.png");
            ring.TriggerOn = TriggerCalls.OnMoved;
            ring.EquippedModifiers = [];
            ring.DoesPopUpInfo = true;
            ring.Conditions = [];
            ring.DoesActionOnTriggerAttached = false;
            ring.ConsumeOnTrigger = TriggerCalls.Count;
            ring.ConsumeOnUse = false;
            ring.ConsumeConditions = [];
            ring.ShopPrice = 6;
            ring.IsShopItem = false;
            ring.StartsLocked = true;
            ring.OnUnlockUsesTHE = false;
            ring.UsesSpecialUnlockText = false;
            ring.SpecialUnlockID = UILocID.None;
            ring.item._ItemTypeIDs = ["Magic"];
            ring.item.AddBlueSkyUnlock("Saea_CH", "locked_ring.png", "ach_ring.png");
        }
    }
}
