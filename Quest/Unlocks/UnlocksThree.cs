using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using SaltEnemies_Reseasoned;

namespace SaltsEnemies_Reseasoned
{
    public static class UnlocksThree
    {
        public static void Add()
        {
            ApplyEntropyEffect entropy_btw = ScriptableObject.CreateInstance<ApplyEntropyEffect>();
            entropy_btw._RandomBetweenPrevious = true;

            MultiPerformEffectItem crown = new MultiPerformEffectItem("Salt_HerCrown_TW", []);
            crown.Name = "Her Crown";
            crown.Flavour = "\"Worth less than nothing.\"";
            crown.Description = "Inflict Entropy equal to damage dealt to targets.\nOn dealing damage, gain 3-5 Entropy.";
            crown.Icon = ResourceLoader.LoadSprite("item_hercrown.png");
            crown.EquippedModifiers = [];
            crown.TriggerOn = AdvancedDamageTrigger.Dealt;
            crown.DoesPopUpInfo = false;
            crown.Conditions = [EntropyToTargetsCondition.Create()];
            crown.DoesActionOnTriggerAttached = false;
            crown.ConsumeOnTrigger = TriggerCalls.Count;
            crown.ConsumeOnUse = false;
            crown.ConsumeConditions = [];
            crown.ShopPrice = 4;
            crown.IsShopItem = false;
            crown.StartsLocked = true;
            crown.OnUnlockUsesTHE = false;
            crown.UsesSpecialUnlockText = false;
            crown.SpecialUnlockID = UILocID.None;
            crown.item._ItemTypeIDs = [];
            crown.AddEffectTrigger(new EffectTrigger([Effects.GenerateEffect(BasicEffects.Empty, 3), Effects.GenerateEffect(entropy_btw, 5, Slots.Self)], [TriggerCalls.OnDidApplyDamage], [], false));
            crown.item.AddBlueSkyUnlock("Arnold_CH", "locked_hercrown.png", "ach_hercrown.png");

            PerformEffect_Item propaganda = new PerformEffect_Item("Salt_BlatantPropaganda_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<DoubleMaxHealthTargetEffect>(), 1, Slots.Self)], true);
            propaganda.Name = "Blatant Propaganda";
            propaganda.Flavour = "\"Not even trying to hide it, huh...\"";
            propaganda.Description = "Increase healing dealt by 4.\nDouble maximum health on healing targets.";
            propaganda.Icon = ResourceLoader.LoadSprite("item_blatantpropaganda.png");
            propaganda.EquippedModifiers = [];
            propaganda.TriggerOn = TriggerCalls.OnWillApplyHeal;
            propaganda.DoesPopUpInfo = false;
            propaganda.Conditions = [ItemExtensions.Heal(4, true, false)];
            propaganda.DoesActionOnTriggerAttached = false;
            propaganda.ConsumeOnTrigger = TriggerCalls.Count;
            propaganda.ConsumeOnUse = false;
            propaganda.ConsumeConditions = [];
            propaganda.ShopPrice = 4;
            propaganda.IsShopItem = true;
            propaganda.StartsLocked = true;
            propaganda.OnUnlockUsesTHE = false;
            propaganda.UsesSpecialUnlockText = false;
            propaganda.SpecialUnlockID = UILocID.None;
            propaganda.item._ItemTypeIDs = [];
            propaganda.item.AddBlueSkyUnlock("Griffin_CH", "locked_blatantpropaganda.png", "ach_blatantpropaganda.png");

            PerformEffect_Item roger = new PerformEffect_Item("Salt_UnloadedRogers_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)]);
            roger.Name = "Unloaded Roger's";
            roger.Flavour = "\"It's not actually a gun, it's just a rock.\"";
            roger.Description = "Inflict Entropy equal to damage dealt to targets.\nOn any party member manually moving, move Left or Right.";
            roger.Icon = ResourceLoader.LoadSprite("item_unloadedrogers.png");
            roger.EquippedModifiers = [];
            roger.TriggerOn = JitteryHandler.Ally;
            roger.DoesPopUpInfo = true;
            roger.Conditions = [];
            roger.DoesActionOnTriggerAttached = false;
            roger.ConsumeOnTrigger = AdvancedDamageTrigger.Dealt;
            roger.ConsumeOnUse = false;
            roger.Conditions = [EntropyToTargetsCondition.Create()];
            roger.ShopPrice = 4;
            roger.IsShopItem = true;
            roger.StartsLocked = true;
            roger.OnUnlockUsesTHE = true;
            roger.UsesSpecialUnlockText = false;
            roger.SpecialUnlockID = UILocID.None;
            roger.item._ItemTypeIDs = [];
            roger.item.AddBlueSkyUnlock("Wtmiyr_CH", "locked_unloadedrogers.png", "ach_unloadedrogers.png");
        }
    }
}
