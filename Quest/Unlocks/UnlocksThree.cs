using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using SaltEnemies_Reseasoned;
using System.Runtime.Versioning;

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
            roger.ConsumeConditions = [EntropyToTargetsCondition.Create()];
            roger.ShopPrice = 4;
            roger.IsShopItem = true;
            roger.StartsLocked = true;
            roger.OnUnlockUsesTHE = true;
            roger.UsesSpecialUnlockText = false;
            roger.SpecialUnlockID = UILocID.None;
            roger.item._ItemTypeIDs = [];
            roger.item.AddBlueSkyUnlock("Wtmiyr_CH", "locked_unloadedrogers.png", "ach_unloadedrogers.png");

            Basic_Item spores = new Basic_Item("Salt_BlueSpores_TW");
            spores.Name = "Blue Spores";
            spores.Flavour = "\"Glows in the night\"";
            spores.Description = "All damage dealt by this party member ignores Shield.";
            spores.Icon = ResourceLoader.LoadSprite("item_bluespores.png");
            spores.EquippedModifiers = [];
            spores.TriggerOn = TriggerCalls.Count;
            spores.DoesPopUpInfo = false;
            spores.Conditions = [];
            spores.DoesActionOnTriggerAttached = false;
            spores.ConsumeOnTrigger = TriggerCalls.Count;
            spores.ConsumeOnUse = false;
            spores.ConsumeConditions = [];
            spores.ShopPrice = 6;
            spores.IsShopItem = false;
            spores.StartsLocked = true;
            spores.OnUnlockUsesTHE = true;
            spores.UsesSpecialUnlockText = false;
            spores.SpecialUnlockID = UILocID.None;
            spores.item._ItemTypeIDs = ["PierceShield"];
            spores.item.AddBlueSkyUnlock("Didion_CH", "locked_bluespores.png", "ach_bluespores.png");

            PerformEffect_Item lens = new PerformEffect_Item("Salt_StalkingLens_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterCloneItemEffect>(), 2)]);
            lens.Name = "Stalking Lens";
            lens.Flavour = "\"See through the dark\"";
            lens.Description = "All damage dealt by this party member ignores Shield.\nOn taking any damage, destroy this item and produce 2 copies of it.";
            lens.Icon = ResourceLoader.LoadSprite("item_stalkinglens.png");
            lens.EquippedModifiers = [];
            lens.TriggerOn = TriggerCalls.OnDamaged;
            lens.DoesPopUpInfo = true;
            lens.Conditions = [];
            lens.DoesActionOnTriggerAttached = false;
            lens.ConsumeOnTrigger = TriggerCalls.Count;
            lens.ConsumeOnUse = true;
            lens.ConsumeConditions = [];
            lens.ShopPrice = 6;
            lens.IsShopItem = true;
            lens.StartsLocked = true;
            lens.OnUnlockUsesTHE = true;
            lens.UsesSpecialUnlockText = false;
            lens.SpecialUnlockID = UILocID.None;
            lens.item._ItemTypeIDs = ["PierceShield"];
            lens.item.AddBlueSkyUnlock("Rose_CH", "locked_stalkinglens.png", "ach_stalkinglens.png");

            RandomAbilityPassive construct = ScriptableObject.CreateInstance<RandomAbilityPassive>();
            construct._passiveName = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._passiveName;
            construct.passiveIcon = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].passiveIcon;
            construct.m_PassiveID = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0].m_PassiveID;
            construct._enemyDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._enemyDescription;
            construct._characterDescription = LoadedAssetsHandler.GetCharacter("Doll_CH").passiveAbilities[0]._characterDescription;
            construct._triggerOn = new TriggerCalls[]
            {
                (TriggerCalls) 889532//old zensuke trigger
            };

            ExtraPassiveAbility_Wearable_SMS add_construct = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            add_construct._extraPassiveAbility = construct;

            PerformEffect_Item halo = new PerformEffect_Item("Salt_SteelHalo_TW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<RerollTargetConstructEffect>(), 1, Slots.Self)]);
            halo.Name = "Steel Halo";
            halo.Flavour = "\"Artificial Angel\"";
            halo.Description = "This party member has \"Construct\" as a passive.\nOn taking any damage, reroll this party member's Construct ability.";
            halo.Icon = ResourceLoader.LoadSprite("item_steelhalo.png");
            halo.EquippedModifiers = [add_construct];
            halo.TriggerOn = TriggerCalls.OnDamaged;
            halo.DoesPopUpInfo = true;
            halo.Conditions = [];
            halo.DoesActionOnTriggerAttached = false;
            halo.ConsumeOnTrigger = TriggerCalls.Count;
            halo.ConsumeOnUse = false;
            halo.ConsumeConditions = [];
            halo.ShopPrice = 5;
            halo.IsShopItem = false;
            halo.StartsLocked = true;
            halo.OnUnlockUsesTHE = true;
            halo.UsesSpecialUnlockText = false;
            halo.SpecialUnlockID = UILocID.None;
            halo.item._ItemTypeIDs = ["Angel"];
            halo.item.AddBlueSkyUnlock("Burnout_CH", "locked_steelhalo.png", "ach_steelhalo.png");

            MultiPerformEffectItem charcoal = new MultiPerformEffectItem("Salt_Charcoal_SW", [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, Slots.Self)]);
            charcoal.Name = "Charcoal";
            charcoal.Flavour = "\"Leftover fire\"";
            charcoal.Description = "On moving, gain 1 Fire.\nTake 50% less direct damage.";
            charcoal.Icon = ResourceLoader.LoadSprite("item_charcoal.png");
            charcoal.EquippedModifiers = [];
            charcoal.TriggerOn = TriggerCalls.OnMoved;
            charcoal.DoesPopUpInfo = true;
            charcoal.Conditions = [];
            charcoal.DoesActionOnTriggerAttached = false;
            charcoal.ConsumeOnTrigger = TriggerCalls.Count;
            charcoal.ConsumeOnUse = false;
            charcoal.ConsumeConditions = [];
            charcoal.ShopPrice = 4;
            charcoal.IsShopItem = true;
            charcoal.StartsLocked = true;
            charcoal.OnUnlockUsesTHE = true;
            charcoal.UsesSpecialUnlockText = false;
            charcoal.SpecialUnlockID = UILocID.None;
            charcoal.item._ItemTypeIDs = [];
            charcoal.AddEffectTrigger(new EffectTrigger([], [TriggerCalls.OnBeingDamaged], [ItemExtensions.Defense(0, false, true)], false));
            charcoal.item.AddBlueSkyUnlock("Ash_CH", "locked_charcoal.png", "ach_charcoal.png");

            PerformEffect_Item gloves = new PerformEffect_Item("Salt_Antigloves_SW", []);
            gloves.Name = "Antigloves";
            gloves.Flavour = "\"From Antiworld.\"";
            gloves.Description = "Apply 1 Slip to damaged targets.";
            gloves.Icon = ResourceLoader.LoadSprite("item_antigloves.png");
            gloves.EquippedModifiers = [];
            gloves.TriggerOn = AdvancedDamageTrigger.Dealt;
            gloves.DoesPopUpInfo = false;
            gloves.Conditions = [DamageTargetEffectsCondition.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 1, Slots.Self)], true)];
            gloves.DoesActionOnTriggerAttached = false;
            gloves.ConsumeOnTrigger = TriggerCalls.Count;
            gloves.ConsumeOnUse = false;
            gloves.ConsumeConditions = [];
            gloves.ShopPrice = 2;
            gloves.IsShopItem = true;
            gloves.StartsLocked = true;
            gloves.OnUnlockUsesTHE = true;
            gloves.UsesSpecialUnlockText = false;
            gloves.SpecialUnlockID = UILocID.None;
            gloves.item._ItemTypeIDs = ["Fabric"];
            gloves.item.AddBlueSkyUnlock("Macy_CH", "locked_antigloves.png", "ach_antigloves.png");

            MultiPerformEffectItem smile = new MultiPerformEffectItem("Salt_SmileMask_TW", []);
            smile.Name = "Smile Mask";
            smile.Flavour = "\"People like you better this way.\"";
            smile.Description = "Deal 50% more damage.\nApply 3 Anesthetics to damaged targets.";
            smile.Icon = ResourceLoader.LoadSprite("item_smilemask.png");
            smile.EquippedModifiers = [];
            smile.TriggerOn = TriggerCalls.OnWillApplyDamage;
            smile.DoesPopUpInfo = false;
            smile.Conditions = [ItemExtensions.Damage(50, true)];
            smile.DoesActionOnTriggerAttached = false;
            smile.ConsumeOnTrigger = TriggerCalls.Count;
            smile.ConsumeOnUse = false;
            smile.ConsumeConditions = [];
            smile.ShopPrice = 5;
            smile.IsShopItem = false;
            smile.StartsLocked = true;
            smile.OnUnlockUsesTHE = true;
            smile.UsesSpecialUnlockText = false;
            smile.SpecialUnlockID = UILocID.None;
            smile.item._ItemTypeIDs = ["Face"];
            smile.AddEffectTrigger(new EffectTrigger([], [AdvancedDamageTrigger.Dealt], [DamageTargetEffectsCondition.Create([Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 3, Slots.Self)], true)], false));
            smile.item.AddBlueSkyUnlock("Mordrake_CH", "locked_smilemask.png", "ach_smilemask.png");

            CopyAndSpawnCustomCharacterAnywhereEffect windle = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            windle._characterCopy = "Windle_CH";
            windle._permanentSpawn = true;
            windle._extraModifiers = [];

            PerformEffect_Item key = new PerformEffect_Item("Salt_WindleKey_TW", [Effects.GenerateEffect(windle, 1)]);
            key.Name = "Windle Key";
            key.Flavour = "\"The key to my mechanical heart.\"";
            key.Description = "On taking any damage, spawn a Windle.";
            key.Icon = ResourceLoader.LoadSprite("item_windlekey.png");
            key.EquippedModifiers = [];
            key.TriggerOn = TriggerCalls.OnDamaged;
            key.DoesPopUpInfo = true;
            key.Conditions = [];
            key.DoesActionOnTriggerAttached = false;
            key.ConsumeOnTrigger = TriggerCalls.Count;
            key.ConsumeOnUse = false;
            key.ConsumeConditions = [];
            key.ShopPrice = 10;
            key.IsShopItem = false;
            key.StartsLocked = true;
            key.OnUnlockUsesTHE = true;
            key.UsesSpecialUnlockText = false;
            key.SpecialUnlockID = UILocID.None;
            key.item._ItemTypeIDs = [];
            key.item.AddBlueSkyUnlock("Kafka_CH", "locked_windlekey.png", "ach_windlekey.png");

        }
    }
}
