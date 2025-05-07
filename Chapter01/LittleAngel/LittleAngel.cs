using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SaltsEnemies_Reseasoned
{
    public class LittleAngel
    {
        public static void Add()
        {
            //Lightweight
            PerformEffectPassiveAbility lightweight = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            lightweight._passiveName = "Lightweight";
            lightweight.m_PassiveID = "Lightweight_PA";
            lightweight.passiveIcon = ResourceLoader.LoadSprite("Lightweight.png");
            lightweight._characterDescription = "Upon moving, 50% chance to move again.";
            lightweight._enemyDescription = "Upon moving, 50% chance to move again.";
            lightweight.doesPassiveTriggerInformationPanel = true;
            lightweight.effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            lightweight._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };
            PercentageEffectorCondition light50P = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            light50P.triggerPercentage = 50;
            lightweight.conditions = new EffectorConditionSO[1] { light50P };
            AddPassivesToGlossary.AddPassive(ResourceLoader.LoadSprite("Lightweight.png"), "Lightweight", lightweight._enemyDescription);

            //Enemy Code
            Enemy LittleAngel = new Enemy("Little Angel", "LittleAngel_EN")
            {
                Health = 10,
                HealthColor = Pigments.Purple,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("littleAngel_IconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("littleAngel_Dead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("littleAngel_Icon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetCharacter("Hans_CH").damageSound,
                DeathSound = LoadedAssetsHandler.GetCharacter("Hans_CH").deathSound
            };
            LittleAngel.PrepareEnemyPrefab("assets/PissShitFartCum/Angel_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Angel_Gibs.prefab").GetComponent<ParticleSystem>());

            LittleAngel.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Immortal,
                lightweight,
            });
            LittleAngel.AddUnitType("Angel");

            //Kindness
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;

            Ability kindness = new Ability("Kindness", "Salt_Kindness_A");
            kindness.Description = "Heal the Opposing party member 30% of their max health and apply 50 Pale and 1 Ruptured to them. \nMove Left, Right, or stay in place.";
            kindness.Rarity = Rarity.GetCustomRarity("rarity5");
            kindness.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<HealHalfHealthEffect>(), 50, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(60)),
            };
            kindness.Visuals = CustomVisuals.GetVisuals("Salt/Nailing");
            kindness.AnimationTarget = Targeting.Slot_Front;
            kindness.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Heal_11_20",
                "Status_Pale",
                "Status_Ruptured",
            });
            kindness.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Sides",
            });

            //Tenderness
            Ability tenderness = new Ability("Tenderness", "Salt_Tenderness_A");
            tenderness.Description = "Apply 10 Pale to the Opposing, Left, and Right party members. Apply 10 Pale to self and move Left or Right.";
            tenderness.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity7", 7);
            tenderness.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, Targeting.Slot_FrontAndSides),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
            };
            tenderness.Visuals = LoadedAssetsHandler.GetCharacterAbility("Cacophony_1_A").visuals;
            tenderness.AnimationTarget = Targeting.Slot_FrontAndSides;
            tenderness.AddIntentsToTarget(Targeting.Slot_FrontAndSides, new string[]
            {
                "Status_Pale",
            });
            tenderness.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Pale",
                "Swap_Sides",
            });

            //Devotion
            AnimationVisualsEffect homonDomin = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            homonDomin._animationTarget = Targeting.Slot_Front;
            homonDomin._visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
            Ability devotion = new Ability("Devotion", "Salt_Devotion_A");
            devotion.Description = "Move Left or Right. Apply 30 Pale to the Opposing party member and 30 Pale to self.";
            devotion.Rarity = Rarity.GetCustomRarity("rarity6");
            devotion.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(homonDomin, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 30, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 30, Targeting.Slot_SelfSlot),
            };
            devotion.Visuals = null;
            devotion.AnimationTarget = Targeting.Slot_Front;
            devotion.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Sides",
                "Status_Pale",
            });
            devotion.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Status_Pale",
            });

            //Adoration
            Ability adoration = new Ability("Adoration", "Salt_Adoration_A");
            adoration.Description = "Apply 50 Pale to the Opposing party member and 50 Pale to self. Apply 2 Ruptured to self if this enemy applied Pale to the Opposing party member.";
            adoration.Rarity = Rarity.GetCustomRarity("rarity5");
            adoration.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, Targeting.Slot_SelfSlot, didThat),
            };
            adoration.Visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            adoration.AnimationTarget = Targeting.Slot_Front;
            adoration.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Status_Pale",
            });
            adoration.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Pale",
                "Status_Ruptured",
            });

            //Add
            LittleAngel.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                kindness.GenerateEnemyAbility(true),
                tenderness.GenerateEnemyAbility(true),
                devotion.GenerateEnemyAbility(true),
                adoration.GenerateEnemyAbility(true),
            });
            LittleAngel.AddEnemy(true, false, true);
        }
    }
}
