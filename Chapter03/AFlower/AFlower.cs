using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class AFlower
    {
        public static void Add()
        {
            //Enemy Code
            Enemy AFlower = new Enemy("A 'Flower'", "AFlower_EN")
            {
                Health = 18,
                HealthColor = Pigments.Red,
                Priority = BrutalAPI.Priority.GetCustomPriority("priority0"),
                CombatSprite = ResourceLoader.LoadSprite("AnglerIconB.png"),
                OverworldDeadSprite = ResourceLoader.LoadSprite("AnglerDead.png", new Vector2(0.5f, 0f), 32),
                OverworldAliveSprite = ResourceLoader.LoadSprite("AnglerIcon.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("Voboola_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("Voboola_EN").deathSound,
            };
            AFlower.PrepareMultiEnemyPrefab("assets/Senis3/Angler_Enemy.prefab", SaltsReseasoned.saltsAssetBundle, SaltsReseasoned.saltsAssetBundle.LoadAsset<GameObject>("assets/Senis3/Angler_Gibs.prefab").GetComponent<ParticleSystem>());
            (AFlower.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                AFlower.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("body").GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>()
            };

            AFlower.AddPassives(new BasePassiveAbilitySO[]
            {
                Passives.Fleeting3,
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1]
            });
            AFlower.UnitTypes = new List<string>()
            {
                "Fish"
            };
            
            //Catch
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            IfConstrictingAnimationVisualsEffect chomp = ScriptableObject.CreateInstance<IfConstrictingAnimationVisualsEffect>();
            chomp._visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals;
            chomp._animationTarget = Targeting.Slot_Front;

            Ability catching = new Ability("Catch", "Salt_Catch_A");
            catching.Description = "If the opposing party member is Constricted, deal an Agonizing damage to them. \nThen, move this enemy to a random position and apply 4 Stunned to itself. \nIf damage was dealt, reset this enemy's fleeting.";
            catching.Rarity = Rarity.GetCustomRarity("rarity5");
            catching.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(chomp, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageIfConstrictedEffect>(), 8, Targeting.Slot_Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, Targeting.Slot_SelfSlot, didThat),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 4, Targeting.Slot_SelfSlot, didThat),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetFleetingEffect>(), 1, Targeting.Slot_SelfSlot, BasicEffects.DidThat(true, 3))
            };
            catching.Visuals = null;
            catching.AnimationTarget = Targeting.Slot_SelfSlot;
            catching.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Damage_7_10"
            });
            catching.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[]
            {
                "Swap_Mass",
                "Status_Stunned",
                FleetingValue.Intent
            });
            
            //Allure
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;
            AnglerCheckEffect angle = ScriptableObject.CreateInstance<AnglerCheckEffect>();

            Ability baiting = new Ability("Allure", "Salt_Allure_A");
            baiting.Description = "Move all party members closer to this enemy. Apply 3 Constricted to the opposing position if there is a party member there.";
            baiting.Rarity = Rarity.GetCustomRarity("rarity3");
            baiting.Effects = new EffectInfo[]
            {
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -1 })),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -2 })),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -3 })),
                Effects.GenerateEffect(goRight, 1, Targeting.GenerateSlotTarget(new int[1] { -4 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 1 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 2 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 3 })),
                Effects.GenerateEffect(goLeft, 1, Targeting.GenerateSlotTarget(new int[1] { 4 })),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<IfTargetApplyConstrictedSlotEffect>(), 3, Targeting.Slot_Front),
                Effects.GenerateEffect(angle, 1, Targeting.Slot_Front),
            };
            baiting.Visuals = CustomVisuals.GetVisuals("Salt/Rose");
            baiting.AnimationTarget = Targeting.Slot_SelfSlot;
            baiting.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[4] { -1, -2, -3, -4 }, false), new string[]
            {
                "Swap_Right",
            });
            baiting.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[4] { 1, 2, 3, 4 }, false), new string[]
            {
                "Swap_Left",
            });
            baiting.AddIntentsToTarget(Targeting.Slot_Front, new string[]
            {
                "Field_Constricted"
            });
            AFlower.enemy.passiveAbilities[1] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(AFlower.enemy.passiveAbilities[1]);
            AFlower.enemy.passiveAbilities[1]._passiveName = "Allure";
            AFlower.enemy.passiveAbilities[1]._enemyDescription = "A 'Flower' will perforn an extra ability \"Allure\" each turn.";
            ((ExtraAttackPassiveAbility)AFlower.enemy.passiveAbilities[1])._extraAbility.ability = baiting.GenerateEnemyAbility(true).ability;
            
            //Add
            AFlower.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                catching.GenerateEnemyAbility(true),
            });
            AFlower.AddEnemy(true, true, false);
        }
    }
}
