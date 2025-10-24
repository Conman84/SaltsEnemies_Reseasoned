using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class Insider
    {
        public static void Add()
        {
            Enemy insider = new Enemy("Insider", "Insider_EN")
            {
                Health = 29,
                HealthColor = Pigments.Purple,
                CombatSprite = ResourceLoader.LoadSprite("InsiderIcon.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("InsiderWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("InsiderDead.png", new Vector2(0.5f, 0f), 32),
                DamageSound = "event:/Hawthorne/Soisenay/InsiderHit",
                DeathSound = "event:/Hawthorne/Soisenay/InsiderDie",
            };
            insider.PrepareEnemyPrefab("Assets/Item/Insider_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/TestSprites/Test_Gibs.prefab").GetComponent<ParticleSystem>());

            //HETEROCHROMIA
            PerformEffectPassiveAbility colors = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            colors._passiveName = "Heterochromia";
            colors.m_PassiveID = "Heterochromia_PA";
            colors.passiveIcon = ResourceLoader.LoadSprite("Hemochromia.png");
            colors._enemyDescription = "Upon receiving any kind of damage, randomize this enemy's health colour.";
            colors._characterDescription = "Upon receiving any kind of damage, randomize this party member's health colour.";
            ChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
                        Pigments.Blue,
                        Pigments.Red,
                        Pigments.Yellow,
                        Pigments.Purple
            };
            colors.effects = new EffectInfo[]
            {
                        Effects.GenerateEffect((EffectSO) randomize, 1, Slots.Self)
            };
            colors._triggerOn = new TriggerCalls[]
            {
                        TriggerCalls.OnDamaged
            };

            insider.AddPassives(new BasePassiveAbilitySO[] { colors, Passives.Forgetful });

            CasterRandomizeNameEnemyEffect inside = ScriptableObject.CreateInstance<CasterRandomizeNameEnemyEffect>();
            inside.PossibleNames = [
                "Wayne Marshall",
                "Ideas Vampire",
                "Wiz Ars",
                "With Homophobia In Its Passives :Heart:",
                "Sleve McDichael Onson Sweemey Darryl Archideld Anatoli Smorin Rey McSriff Glenallen Mixon Mario McRlwain Raul Chamgerlain Kevin Nogilny Tony Smehrik Bobson Dugnutt Willie Dustice Jeromy Gride Scott Dourque Shown Furcotte Dean Wesrey Mike Truk Dwigt Rortugal Tim Sandaele Karl Dandleton Mike Sernandez Todo Bonzalez",
                "Bartholomew",
                "Untitled",
                "Hmnker",
                "Corpse-chan"
                ];

            insider.CombatEnterEffects = [Effects.GenerateEffect(inside)];

            AnimationVisualsEffect punch = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            punch._visuals = Visuals.Extrusion;
            punch._animationTarget = Slots.Front;

            //first
            Ability alpha = new Ability("Insider", "InsiderA_A");
            alpha.Description = "Move Left or Right.\nDeal an Agonizing amount of damage to the Opposing party member.";
            alpha.Rarity = Rarity.Common;
            alpha.Effects = [
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self),
                Effects.GenerateEffect(punch, 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Slots.Front)
                ];
            alpha.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            alpha.AddIntentsToTarget(Slots.Front, ["Damage_7_10"]);
            alpha.Visuals = null;
            alpha.AnimationTarget = Slots.Self;

            //beta
            Ability beta = new Ability("Insider", "InsiderB_A");
            beta.Description = "Apply 2 Slip to the Left, Right, and Opposing party member positions.";
            beta.Rarity = Rarity.Uncommon;
            beta.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, Slots.FrontLeftRight)];
            beta.AddIntentsToTarget(Slots.FrontLeftRight, [Slip.Intent]);
            beta.Visuals = CustomVisuals.GetVisuals("Salt/Door");
            beta.AnimationTarget = Slots.FrontLeftRight;

            //gamma
            Ability gamma = new Ability("Insider", "InsiderC_A");
            gamma.Description = "Invert the Opposing party member's health.";
            gamma.Rarity = Rarity.Uncommon;
            gamma.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<InvertTargetHealthEffect>(), 1, Slots.Front)];
            gamma.AddIntentsToTarget(Slots.Front, [IntentType_GameIDs.Other_MaxHealth_Alt.ToString()]);
            gamma.Visuals = Visuals.Mitosis;
            gamma.AnimationTarget = Slots.Front;

            //delta
            Ability delta = new Ability("Insider", "InsiderD_A");
            delta.Description = "Inflict 1 Ruptured on all units.";
            delta.Rarity = Rarity.Rare;
            delta.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targeting.AllUnits)];
            delta.AddIntentsToTarget(Targeting.Unit_AllAllies, ["Status_Ruptured"]);
            delta.AddIntentsToTarget(Targeting.Unit_AllOpponents, ["Status_Ruptured"]);
            delta.Visuals = CustomVisuals.GetVisuals("Salt/Hunt");
            delta.AnimationTarget = Targeting.AllUnits;


            //ADD ENEMY
            insider.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                alpha.GenerateEnemyAbility(true),
                beta.GenerateEnemyAbility(true),
                gamma.GenerateEnemyAbility(true),
                delta.GenerateEnemyAbility(true)
            });
            insider.AddEnemy(true, true);
        }
    }
}
