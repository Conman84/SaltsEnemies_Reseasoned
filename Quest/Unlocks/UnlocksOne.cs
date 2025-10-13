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

            PerformEffect_Item cog = new PerformEffect_Item("Aprils_Cog_SW", [Effects.GenerateEffect(cogEffect)]);
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
        }
    }
}
