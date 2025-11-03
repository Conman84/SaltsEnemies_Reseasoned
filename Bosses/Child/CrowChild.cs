using BrutalAPI;
using SaltEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned
{
    public static class CrowChild
    {
        public static void Add()
        {
            Enemy template = new Enemy("Crow Child", "CrowChild_BOSS")
            {
                Health = 50,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CrowChildWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CrowChildWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CrowChildWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("TheCrow_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("TheCrow_EN").deathSound,
            };
            template.PrepareMultiEnemyPrefab("Assets/Bosses/Crow/CrowChild_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/Bosses/Crow/CrowChild_Gibs.prefab").GetComponent<ParticleSystem>());
            (template.enemy.enemyTemplate as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Body").Find("Outline").GetComponent<SpriteRenderer>(),
                template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("LeftLeg").Find("Outline").GetComponent<SpriteRenderer>(),
                template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("RightLeg").Find("Outline").GetComponent<SpriteRenderer>(),
                template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").Find("LeftEar").Find("Outline").GetComponent<SpriteRenderer>(),
                template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").Find("RightEar").Find("Outline").GetComponent<SpriteRenderer>(),
                template.enemy.enemyTemplate.m_Data.m_Locator.transform.Find("Sprite").Find("Head").Find("Face").Find("Outline").GetComponent<SpriteRenderer>(),
            };

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.MultiAttack2, Passives.SlipperyGenerator(3), Violent.Generate(4) });
            template.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_NoRepeats>();

            template.AddUnitType("Bird");

            Ability first = new Ability("Masquerade", "CC_Masquerade_A");
            first.Description = "Inflict 1 Ruptured and 1 Frail to the Left and Right party members.";
            first.Rarity = Rarity.GetCustomRarity("rarity5");
            first.Effects = new EffectInfo[2];
            first.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, Slots.LeftRight);
            first.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, Slots.LeftRight);
            first.AddIntentsToTarget(Slots.LeftRight, ["Status_Ruptured", "Status_Frail"]);
            first.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            first.AnimationTarget = Slots.LeftRight;

            Ability second = new Ability("Charades", "CC_Charades_A");
            second.Description = "Deal a Little damage to this enemy.";
            second.Rarity = Rarity.CreateAndAddCustomRarityToPool("crowChildHigh", 6);
            second.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self)];
            second.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            second.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            second.AnimationTarget = Slots.Self;

            AnimationVisualsIfUnitEffect adulting = ScriptableObject.CreateInstance<AnimationVisualsIfUnitEffect>();
            adulting._animationTarget = Slots.Front;
            adulting._visuals = CustomVisuals.GetVisuals("Salt/Adulting");
            adulting._noUnitAnimationTarget = Slots.Front;
            adulting._noUnitVisuals = CustomVisuals.GetVisuals("Salt/Hunt");

            Ability third = new Ability("Adulting", "CC_Adulting_A");
            third.Description = "Deal an Evil amount of damage to the Opposing party member.";
            third.Rarity = Rarity.GetCustomRarity("rarity5");
            third.Effects = [
                Effects.GenerateEffect(adulting, 1, Slots.Front),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 13, Slots.Front)
                ];
            third.AddIntentsToTarget(Slots.Front, ["Damage_11_15"]);
            third.Visuals = null;
            third.AnimationTarget = Slots.Front;

            Ability fourth = new Ability("Regression", "CC_Regression_A");
            fourth.Description = "Move Left or Right.";
            fourth.Rarity = Rarity.CreateAndAddCustomRarityToPool("crowSmall", 4);
            fourth.Priority = Priority.Fast;
            fourth.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Slots.Self)];
            fourth.AddIntentsToTarget(Slots.Self, ["Swap_Sides"]);
            fourth.Visuals = null;

            //ADD ENEMY
            template.AddEnemyAbilities(new EnemyAbilityInfo[]
            {
                first.GenerateEnemyAbility(true),
                second.GenerateEnemyAbility(true),
                third.GenerateEnemyAbility(true),
                fourth.GenerateEnemyAbility(true)
            });
            template.AddEnemy(true);
        }
    }
}
