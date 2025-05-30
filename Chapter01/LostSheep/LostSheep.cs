using BrutalAPI;
using SaltEnemies_Reseasoned;
using SaltsEnemies_Reseasoned.CustomEffects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SaltsEnemies_Reseasoned
{
    public class LostSheep
    {
        public static void Add()
        {
            //Freakout
            PerformEffectPassiveAbility freakout = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            freakout._passiveName = "Freak Out";
            freakout.m_PassiveID = "FreakOut_PA";
            freakout.passiveIcon = ResourceLoader.LoadSprite("Freakout.png");
            freakout._enemyDescription = "Upon receiving any damage, apply 0-1 Power to all allies that aren't Lost Sheep.";
            freakout._characterDescription = "Upon receiving any damage, apply 0-1 Power to all allies that aren't Lost Sheep.";
            freakout.doesPassiveTriggerInformationPanel = true;
            UnitSideNotLostSheep allAlly = ScriptableObject.CreateInstance<UnitSideNotLostSheep>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;
            freakout.effects = new EffectInfo[]
            {
                 Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 0, allAlly)
            };
            freakout._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged };
            

            //Enemy Code
            Enemy LostSheep = new Enemy("Lost Sheep", "LostSheep_EN")
            {
                Health = 18,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.CreateAndAddCustomPriorityToPool("priority3", 3),
                CombatSprite = ResourceLoader.LoadSprite("lostSheep_IconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("lostSheep_Dead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("lostSheep_Icon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").deathSound,
            };
            LostSheep.PrepareMultiEnemyPrefab("assets/PissShitFartCum/CNS_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/CNS_Gibs_Prefab.prefab").GetComponent<ParticleSystem>());
            LostSheep.enemy.enemyTemplate.m_Data.m_Renderer = LostSheep.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").GetComponent<SpriteRenderer>();

            (LostSheep.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                LostSheep.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Outline").GetComponent<SpriteRenderer>(),
                LostSheep.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Eye").Find("Outline").GetComponent<SpriteRenderer>(),
                LostSheep.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("DeathEye").Find("Outline").GetComponent<SpriteRenderer>(),
            };

            LostSheep.AddPassives(new BasePassiveAbilitySO[]
            {
                freakout,
                Passives.Withering,
                Passives.Dying,
                Passives.Delicate,
            });

            //Adrenaline
            TargettingClosestNotLostSheep closestAlly = ScriptableObject.CreateInstance<TargettingClosestNotLostSheep>();
            closestAlly.getAllies = true;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            Ability adrenaline = new Ability("Adrenaline Rush", "Salt_AdrenalineRush_A");
            adrenaline.Description = "Apply 2-3 Power to the closest left and right enemies that aren't Lost Sheep. Apply 0-1 Scars to self.";
            adrenaline.Rarity = Rarity.CreateAndAddCustomRarityToPool("rarity5", 5);
            adrenaline.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 2, closestAlly),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
            };
            adrenaline.Visuals = LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals;
            adrenaline.AnimationTarget = closestAlly;
            adrenaline.AddIntentsToTarget(closestAlly, new string[]
            {
                "Status_Power"
            });
            adrenaline.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Status_Scars"
            });

            //Reflex
            Ability reflex = new Ability("Autonomous Reflex", "Salt_AutonomousReflex_A");
            reflex.Description = "Apply 0-1 Power to all enemies that aren't Lost Sheep. Deal a little bit of damage to self.";
            reflex.Rarity = Rarity.GetCustomRarity("rarity5");
            reflex.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 0, allAlly),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfSlot),
            };
            reflex.Visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;
            reflex.AnimationTarget = Targeting.Slot_SelfSlot;
            reflex.AddIntentsToTarget(allAlly, new string[]
            {
                "Status_Power"
            });
            reflex.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Damage_1_2"
            });

            //Panic
            TargettingWeakestNotLostSheep weakest = ScriptableObject.CreateInstance<TargettingWeakestNotLostSheep>();
            weakest.getAllies = true;
            weakest.ignoreCastSlot = true;
            DoubleTargetting panicAnim = ScriptableObject.CreateInstance<DoubleTargetting>();
            panicAnim.firstTargetting = weakest;
            panicAnim.secondTargetting = Targeting.Slot_SelfSlot;
            Ability panic = new Ability("Panic", "Salt_Panic_A");
            panic.Description = "Deal a little bit of damage and apply 1 Scar to self. Apply 1-4 Power to the enemy with the lowest health that isn't a Lost Sheep.";
            panic.Rarity = Rarity.GetCustomRarity("rarity5");
            panic.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyPowerRangePlusThreeEffect>(), 1, weakest),
                
            };
            panic.Visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            panic.AnimationTarget = panicAnim;
            panic.AddIntentsToTarget(weakest, new string[]
            {
                "Status_Power"
            });
            panic.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Damage_1_2",
                "Status_Scars"
            });

            //Add
            LostSheep.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                adrenaline.GenerateEnemyAbility(true),
                reflex.GenerateEnemyAbility(true),
                panic.GenerateEnemyAbility(true),
            });
            LostSheep.AddEnemy(true, true, true);
        }
    }
}
