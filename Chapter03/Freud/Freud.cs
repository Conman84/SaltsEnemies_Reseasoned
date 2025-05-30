using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Freud
    {
        public static void Add()
        {
            //Don't Touch Me
            OnClickPassiveAbility noTouch = ScriptableObject.CreateInstance<OnClickPassiveAbility>();
            noTouch._passiveName = "Don't Touch Me";
            noTouch.m_PassiveID = "DontTouchMe_PA";
            noTouch.passiveIcon = ResourceLoader.LoadSprite("DontTouchMe.png");
            noTouch._characterDescription = "whoops";
            noTouch._enemyDescription = "Upon being clicked, gain an additional ability on the timeline.";
            noTouch.doesPassiveTriggerInformationPanel = false;
            noTouch._triggerOn = new TriggerCalls[] { OnClickPassiveAbility.Trigger };
            

            //Enemy Code
            Enemy Freud = new Enemy("Freud", "Freud_EN")
            {
                Health = 28,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("TouchIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("TouchDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("TouchIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Sound/FreudHit",
                DeathSound = "event:/Hawthorne/Sound/FreudDie",
            };
            Freud.PrepareEnemyPrefab("assets/DontTouchMe/DontTouchMe_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/DontTouchMe/DontTouchMe_Gibs.prefab").GetComponent<ParticleSystem>());

            Freud.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Skittish,
                noTouch
            });

            AbilitySelector_Freud selector = ScriptableObject.CreateInstance<AbilitySelector_Freud>();
            selector.unlocking = "Salt_Unlocking_A";
            Freud.AbilitySelector = selector;

            Freud.CombatEnterEffects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<FreudEnterEffect>(), 1, Targeting.Slot_SelfSlot),
            };

            //LookatMe
            Ability LookatMe = new Ability("Look at Me", "Salt_LookatMe_A");
            LookatMe.Description = "Inflict 3 Frail on the opposing party member. \nIf no Frail was applied, give this enemy another action.";
            LookatMe.Rarity = Rarity.GetCustomRarity("rarity5");
            LookatMe.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot, BasicEffects.DidThat(false)),
            };
            LookatMe.Visuals = CustomVisuals.GetVisuals("Salt/Keyhole");
            LookatMe.AnimationTarget = Targeting.Slot_Front;
            LookatMe.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Status_Frail"
            });
            LookatMe.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Misc"
            });

            //Cuts and Scratches
            Ability CutsandScratches = new Ability("Cuts and Scratches", "Salt_CutsandScratches_A");
            CutsandScratches.Description = "Deal a little bit of damage to the Opposing party member. \nIf damage was dealt, give this enemy another action.";
            CutsandScratches.Rarity = Rarity.GetCustomRarity("rarity5");
            CutsandScratches.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, Targeting.Slot_SelfSlot, BasicEffects.DidThat(true)),
            };
            CutsandScratches.Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            CutsandScratches.AnimationTarget = Targeting.Slot_Front;
            CutsandScratches.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
               "Damage_1_2"
            });
            CutsandScratches.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
               "Misc"
            });

            //Pummel
            Ability Pummel = new Ability("Pummel", "Salt_Pummel_A");
            Pummel.Description = "Move to the Left or Right. Deal an Agonizing amount of damage to the Opposing party member.";
            Pummel.Rarity = Rarity.GetCustomRarity("rarity5");
            Pummel.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Four", false, Targeting.Slot_Front), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Targeting.Slot_Front),
            };
            Pummel.Visuals = null;
            Pummel.AnimationTarget = Targeting.Slot_SelfSlot;
            Pummel.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Sides"
            });
            Pummel.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_7_10"
            });

            //Unlocking
            Ability Unlocking = new Ability("Unlocking", "Salt_Unlocking_A");
            Unlocking.Description = "Decrease 'Unlocking' by 1. \nIf 'Unlocking' is 0, give all enemies up to 3 additional actions.";
            Unlocking.Rarity = Rarity.GetCustomRarity("rarity5");
            Unlocking.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(BasicEffects.GetVisuals("Salt/Unlock", false, Targeting.Slot_SelfSlot), 1, Targeting.Slot_SelfSlot, ScriptableObject.CreateInstance<UnlockingEffectCondition>()),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<UnlockingEffect>(), 1, Targeting.Unit_AllAllies, BasicEffects.DidThat(true)),
            };
            Unlocking.Visuals = null;
            Unlocking.AnimationTarget = Targeting.Slot_SelfSlot;
            Unlocking.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                UnlockingEffectCondition.value
            });
            Unlocking.UnitStoreData = FreudEnterEffect.Reader;

            //Add
            Freud.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                LookatMe.GenerateEnemyAbility(true),
                CutsandScratches.GenerateEnemyAbility(true),
                Pummel.GenerateEnemyAbility(true),
                Unlocking.GenerateEnemyAbility(true),
            });
            Freud.AddEnemy(true, true, false);
        }
    }
}
