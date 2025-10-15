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
        }
    }
}
