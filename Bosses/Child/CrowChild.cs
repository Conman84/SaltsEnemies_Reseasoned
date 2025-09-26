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
                Health = 60,
                HealthColor = Pigments.Red,
                CombatSprite = ResourceLoader.LoadSprite("CrowChildWorld.png"),
                OverworldAliveSprite = ResourceLoader.LoadSprite("CrowChildWorld.png", new Vector2(0.5f, 0f), 32),
                OverworldDeadSprite = ResourceLoader.LoadSprite("CrowChildWorld.png", new Vector2(0.5f, 0f), 32),
                DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound,
            };
            template.PrepareEnemyPrefab("Assets/TestSprites/Tset_CrowChild_Enemy.prefab", SaltsReseasoned.Meow, SaltsReseasoned.Meow.LoadAsset<GameObject>("Assets/TestSprites/Test_Gibs.prefab").GetComponent<ParticleSystem>());
            //template.enemy.enemyTemplate = LoadedAssetsHandler.GetEnemy("LittleBeak_EN").enemyTemplate;

            template.AddPassives(new BasePassiveAbilitySO[] { Passives.MultiAttack2, Passives.SlipperyGenerator(3), Violent.Generate(5) });
            template.AbilitySelector = ScriptableObject.CreateInstance<AbilitySelector_NoRepeats>();

            Ability first = new Ability("Ability A", "CrowChild1_A");
            first.Description = "Inflict 1 Constricted and 3 Frail to the Left and Right party members.";
            first.Rarity = Rarity.GetCustomRarity("rarity5");
            first.Effects = new EffectInfo[2];
            first.Effects[0] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, Slots.LeftRight);
            first.Effects[1] = Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, Slots.LeftRight);
            first.AddIntentsToTarget(Slots.LeftRight, ["Field_Constricted", "Status_Frail"]);
            first.Visuals = CustomVisuals.GetVisuals("Salt/Gaze");
            first.AnimationTarget = Slots.LeftRight;

            Ability second = new Ability("Ability B", "CrowChild2_A");
            second.Description = "Deal a Little damage to this enemy.";
            second.Rarity = Rarity.CreateAndAddCustomRarityToPool("crowChildHigh", 8);
            second.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Slots.Self)];
            second.AddIntentsToTarget(Slots.Self, ["Damage_1_2"]);
            second.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            second.AnimationTarget = Slots.Self;

            Ability third = new Ability("Ability C", "CrowChild3_A");
            third.Description = "Deal an Evil amount of damage to the Opposing party member.";
            third.Rarity = Rarity.GetCustomRarity("rarity5");
            third.Effects = [Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Slots.Front)];
            third.AddIntentsToTarget(Slots.Front, ["Damage_7_10"]);
            third.Visuals = CustomVisuals.GetVisuals("Salt/Needle");
            third.AnimationTarget = Slots.Front;

            Ability fourth = new Ability("Ability D", "CrowChild4_A");
            fourth.Description = "Move Left or Right.";
            fourth.Rarity = Rarity.CreateAndAddCustomRarityToPool("crowSmall", 2);
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
